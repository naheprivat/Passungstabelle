'Klasse LogFile
'erledigt die Meldungsanzeige und das Schreiben der Log-Datei
Imports System.Collections.Generic
Imports System.Environment

Public Class LogFile
    'Property MacroPfad As String = ""                               'Pfad zur Applikation
    Property LogPfad As String = ""                                 'Pfad zur Applikation
    Property Attr_generell As New Dictionary(Of String, String)     'Generelle Attribute
    Property UserName As String = ""

    Sub New(attr As Dictionary(Of String, String))
        'MacroPfad = GetAppPath()
        LogPfad = GetLogPath()
        Attr_generell = attr
        UserName = Environment.UserName
    End Sub

    Sub New()
        'MacroPfad = GetAppPath()
        LogPfad = GetLogPath()
        UserName = Environment.UserName
    End Sub
    'Sub        WriteInfo  
    'Paramter:  Info (welcher Text soll ausgegeben werden
    '           Msg (True es wird auch eine Mledung am Bildschirm ausgegeben, Fals keine Meldung am Bildschirm)
    Public Sub WriteInfo(Info As String, Msg As Boolean)
        Dim tempattr As Boolean

        'Versuch das Attribut zu lesen
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

        'path = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
        'GetLogPath = path

        path = GetFolderPath(SpecialFolder.CommonApplicationData)

        path = path & "\" & My.Application.Info.CompanyName
        If (Not System.IO.Directory.Exists(path)) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        path = path & "\" & My.Application.Info.ProductName
        If (Not System.IO.Directory.Exists(path)) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        GetLogPath = path
    End Function

End Class
