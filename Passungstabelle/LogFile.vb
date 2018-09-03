Imports System.Collections.Generic

Public Class LogFile
    Property MacroPfad As String = ""
    Property Attr_generell As New Dictionary(Of String, String)

    Sub New(attr As Dictionary(Of String, String))
        MacroPfad = GetAppPath()
        Attr_generell = attr
    End Sub

    Sub New()
        MacroPfad = GetAppPath()
    End Sub

    Public Sub WriteInfo(Info As String, Msg As Boolean)
        'Wenn in die Log-Datei geschrieben werden soll
        If Attr_generell("LogDatei") = True Then
            My.Application.Log.DefaultFileLogWriter.BaseFileName = System.IO.Path.Combine(MacroPfad, Definitionen.LOGName)
            My.Application.Log.DefaultFileLogWriter.AutoFlush = True
            My.Application.Log.WriteEntry(Now.ToLocalTime & Chr(9) & Info, TraceEventType.Information)
        End If
        'Wenn Meldungen ausgegeben werden sollen und es sich um eine Meldung handelt
        If Attr_generell("Fehlermeldung") = False And Msg = True Then
            MsgBox(Info, vbOKOnly, "Meldung")
        End If
    End Sub

    Private Function GetAppPath() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        GetAppPath = path
    End Function
End Class
