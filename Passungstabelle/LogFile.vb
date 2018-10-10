'Klasse LogFile
'erledigt die Meldungsanzeige und das Schreiben der Log-Datei
Imports System.Collections.Generic

Public Class LogFile
    Property MacroPfad As String = ""                               'Pfad zur Applikation
    Property Attr_generell As New Dictionary(Of String, String)     'Generelle Attribute

    Sub New(attr As Dictionary(Of String, String))
        MacroPfad = GetAppPath()
        Attr_generell = attr
    End Sub

    Sub New()
        MacroPfad = GetAppPath()
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
            My.Application.Log.DefaultFileLogWriter.BaseFileName = System.IO.Path.Combine(MacroPfad, Definitionen.LOGName)
            My.Application.Log.DefaultFileLogWriter.AutoFlush = True
            My.Application.Log.WriteEntry(Now.ToLocalTime & Chr(9) & Info, TraceEventType.Information)
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

    Private Function GetAppPath() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        GetAppPath = path
    End Function
End Class
