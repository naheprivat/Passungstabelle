'Klasse LogFile
'erledigt die Meldungsanzeige und das Schreiben der Log-Datei

Imports System.Collections.Generic
Imports System.Environment

Imports System.IO

Public Class LogFile
    Property LogPfad As String = ""                                 'Pfad zur Log_Datei
    Property Attr_generell As New Dictionary(Of String, String)     'Generelle Attribute
    Property UserName As String = ""                                'Benutzername
    Property IOAccessToLogPath As Boolean = False                   'Zeigt an ob Schreibzugriff auf das Verzeichnis der Log-Datei existiert

    'Initialisierung der Klasse mit der Liste der generellen Attribute
    Sub New(attr As Dictionary(Of String, String))
        LogPfad = GetLogPath()
        Attr_generell = attr
        UserName = Environment.UserName
    End Sub

    'Initialisierung der Klasse ohne Attribute
    Sub New()
        LogPfad = GetLogPath()
        UserName = Environment.UserName
    End Sub

    'Sub        WriteInfo  
    'Paramter:  Info (welcher Text soll ausgegeben werden
    '           Msg (True es wird auch eine Mledung am Bildschirm ausgegeben, Fals keine Meldung am Bildschirm)
    Public Sub WriteInfo(Info As String, Msg As Boolean)
        Dim tempattr As Boolean

        'Wenn LogPfad leer ist, dann besteht kein Schreibrecht in das Verzeichnis
        If LogPfad = "" Then
            Exit Sub
        End If

        'Versuch das Attribut zu lesen
        'Wenn das Attribute nicht gelesen werden konnte, dann wird eine Log-Datei geschrieben
        Try
            tempattr = Attr_generell("LogDatei")
        Catch ex As Exception
            tempattr = True
        End Try

        'Wenn in die Log-Datei geschrieben werden soll
        If tempattr = True Then
            My.Application.Log.DefaultFileLogWriter.BaseFileName = System.IO.Path.Combine(LogPfad, Definitionen.LOGName)
            My.Application.Log.DefaultFileLogWriter.AutoFlush = True
            If Info = "Start" Or Info = "Fertig" Then
                My.Application.Log.WriteEntry(Now.ToLocalTime & Chr(9) & "***" & Info & "*** User: " & UserName, TraceEventType.Information)
            Else
                My.Application.Log.WriteEntry(Now.ToLocalTime & Chr(9) & Info, TraceEventType.Information)
            End If
            If Info = "Fertig" Then
                My.Application.Log.DefaultFileLogWriter.Close()
            End If
        End If
        'Wenn Meldungen ausgegeben werden sollen und es sich um eine Meldung handelt
        'Versuch das Attribut zu lesen
        Try
            tempattr = Attr_generell("Fehlermeldung")
        Catch ex As Exception
            tempattr = False
        End Try
        If tempattr = False And Msg = True Then
            MsgBox(Info, vbOKOnly, "Meldung")
        End If
    End Sub

    'Function   GetLogPath
    'Paramter:  keine
    'Ergebnis:  liefert den Pfad der Log-Datei
    Public Function GetLogPath() As String
        Dim path As String

        'normalwerweise gibt SpecialFolder.CommonApplicationData C:\ProgramData zurück

        'Änderung Ver. 8.2.0.0
        'path = GetFolderPath(SpecialFolder.CommonApplicationData)
        path = GetFolderPath(SpecialFolder.ApplicationData)

        'path = path & "\" & My.Application.Info.CompanyName
        'If (Not System.IO.Directory.Exists(path)) Then
        '    System.IO.Directory.CreateDirectory(path)
        'End If
        'path = path & "\" & My.Application.Info.ProductName
        'If (Not System.IO.Directory.Exists(path)) Then
        '    System.IO.Directory.CreateDirectory(path)
        'End If

        If CheckLogIOAccess(path) Then
            GetLogPath = path & "\" & My.Application.Info.CompanyName & "\" & My.Application.Info.ProductName
        Else
            GetLogPath = ""
        End If
    End Function

    'Function   CheckLogIOAccess
    'Parameter: Pfad 
    'Ergebnis:  Liefert True wenn für den angegebenen Pfad Schreibrechte existieren sonst False

    Private Function CheckLogIOAccess(pfad As String) As Boolean
        If Not CreateDir(pfad & "\", My.Application.Info.CompanyName) Then
            CheckLogIOAccess = False
            Exit Function
        End If
        If Not CreateDir(pfad & "\" & My.Application.Info.CompanyName & "\", My.Application.Info.ProductName) Then
            CheckLogIOAccess = False
            Exit Function
        End If
        CheckLogIOAccess = CreateFile(pfad & "\" & My.Application.Info.CompanyName & "\" & My.Application.Info.ProductName & "\")
    End Function

    Private Function CreateDir(Pfad As String, Folder As String) As Boolean
        If Not Directory.Exists(Pfad) Then
            CreateDir = False
            Exit Function
        End If
        Try
            Directory.CreateDirectory(Pfad & Folder)
        Catch ex As Exception
            CreateDir = False
            Exit Function
        End Try
        CreateDir = True
    End Function

    Private Function CreateFile(pfad As String) As Boolean
        Dim fi As New FileInfo(pfad & "temp.txt")

        Try
            If fi.Exists Then
                fi.Delete()
            End If
        Catch ex As Exception
            CreateFile = False
            Exit Function
        End Try

        Try
            Dim afile As New IO.StreamWriter(pfad & "temp.txt", True)
            afile.WriteLine("hello")
            afile.Close()
        Catch ex As Exception
            CreateFile = False
            Exit Function
        End Try

        Try
            fi.Delete()
        Catch ex As Exception
            CreateFile = False
            Exit Function
        End Try

        CreateFile = True
    End Function

End Class
