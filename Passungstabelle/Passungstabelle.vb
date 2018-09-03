Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Drawing
Imports System.Collections.Generic

Imports System.Data
Imports System.Xml
Imports System.IO

Public Class Passungstabelle
    Property Macro_pfad As String
    Property Log_pfad As String
    Property XMLDaten As New DataSet
    Property Attr_generell As New Dictionary(Of String, String)
    Property Attr_Übersetzungen As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Formate As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Tabelle As New Dictionary(Of String, Dictionary(Of String, String))
    Property Setup_Date_Time As Date
    Dim Log As New LogFile


    Sub Main(swapp As SldWorks, Optional iDrawingDoc As ModelDoc2 = Nothing)
        Dim swmod As SolidWorks.Interop.sldworks.ModelDoc2
        Dim pd As New Passungstabelle_Datei(swapp)
        Dim Passungengefunden As Boolean = False

        If Not iDrawingDoc Is Nothing Then
            swmod = iDrawingDoc
        Else
            swmod = swapp.ActiveDoc
        End If


        Macro_pfad = GetAppPath()
        Log_pfad = Macro_pfad & "\" & Definitionen.LOGName

        'Wenn keine Daten geladen sind oder sich die Setup Datei geändert hat, dann Setup Daten einlesen
        If Attr_generell.Count = 0 Or Setup_has_changed() Then
            If Not Check_for_setup() Then Exit Sub
        End If

        'Setup Daten der Datei zuordnen
        pd.Attr_generell = Attr_generell
        pd.Attr_Übersetzungen = Attr_Übersetzungen
        pd.Attr_Formate = Attr_Formate
        pd.Attr_Tabelle = Attr_Tabelle
        pd.Swapp = swapp
        'pd.Log = New LogFile(Attr_generell)

        Log.Attr_generell = Attr_generell
        Log.WriteInfo("Start", False)

        pd.Log = Log

        'Prüfung ob eine Zeichnung aktiv ist
        If Not Check_for_drawing(swmod) Then
            Log.WriteInfo("Keine Zeichnung geladen", True)
            Exit Sub
        End If

        'Wenn Keine Blätter in der Zeichnung vorhanden sind, dann beenden
        'Dim s As DateTime = Now.ToLocalTime
        If Not pd.PassungsTabelleGetSheets(swmod) Then
            Log.WriteInfo("Keine Blätter in der Zeichnung", True)
            Exit Sub
        End If

        pd.InsertTableOnSheets()

        Log.WriteInfo("Fertig", False)
        'MsgBox("Fertig", vbOKOnly, "Meldung")
    End Sub
    'Prüft ob eine Zeichnung geöffnet ist
    Function Check_for_drawing(swmod As ModelDoc2) As Boolean
        If swmod Is Nothing Then
            Log.WriteInfo("Keine Datei geladen", True)
            Check_for_drawing = False
            Exit Function
        End If

        If swmod.GetType <> swDocumentTypes_e.swDocDRAWING Then
            Log.WriteInfo("Keine Zeichnung geladen", True)
            Check_for_drawing = False
            Exit Function
        End If
        Check_for_drawing = True
    End Function
    'Prüft ob die Setup-Datei vorhanden ist und gelesen werden kann
    Function Check_for_setup() As Boolean
        Dim pfad As String
        Dim ok As Boolean

        Macro_pfad = GetAppPath()

        pfad = macro_pfad & "\" & Definitionen.INI_File
        ' Log_pfad = macro_pfad & "\" & Definitionen.LOGName

        Dim xmlSR As New System.IO.StringReader(My.Resources.Setup_Schema)

        XMLDaten.Clear()
        XMLDaten.ReadXmlSchema(xmlSR)

        Try
            XMLDaten.ReadXml(pfad)
            ok = True
        Catch
            ok = False
            MsgBox("Keine Setup.XML Datei gefunden" & Chr(10) & "Bitte verwenden Sie das Setup-Makro um die Einstellungen zu erzeugen", vbOKOnly, "Passungstabelle Addin")
            Check_for_setup = False
            Exit Function
        End Try

        Attr_read()

        Check_for_setup = True
    End Function

    Sub Attr_read()
        Attr_generell = Attr_get_generell()
        Attr_Übersetzungen = Attr_get_übersetzungen()
        Attr_Formate = Attr_get_formate()
        Attr_Tabelle = Attr_get_Tabelle()
        set_Setup_date()
    End Sub
    'Speichert das Ändeurngsdatum der Setup-Datei 
    Sub Set_Setup_date()
        Dim pfad As String
        pfad = macro_pfad & "\" & Definitionen.INI_File
        Setup_Date_Time = File.GetLastWriteTime(pfad)
    End Sub

    'Prüft ob sich das Datum der letzten Speicherung geändert hat
    Function Setup_has_changed() As Boolean
        Dim pfad As String
        pfad = macro_pfad & "\" & Definitionen.INI_File

        If Setup_Date_Time < File.GetLastWriteTime(pfad) Then
            Setup_Date_Time = File.GetLastWriteTime(pfad)
            Setup_has_changed = True
            Exit Function
        End If
        Setup_has_changed = False
    End Function

    'Liest die Generellen Einstellungen ein
    Function Attr_get_generell() As Dictionary(Of String, String)
        Dim temp As New Dictionary(Of String, String)
        Dim dt As DataTable
        Dim dr As DataRow

        dt = XMLDaten.Tables("GenerelleAttribute")
        dr = dt.Rows(0)

        For Each n As KeyValuePair(Of String, String) In Definitionen.GENERELLE_ATTR
            temp(n.Key) = dr(n.Key)
        Next

        Attr_get_generell = temp
    End Function
    'Liest die Übersetzungen ein
    Function Attr_get_übersetzungen() As Dictionary(Of String, Dictionary(Of String, String))
        Dim temp As New Dictionary(Of String, Dictionary(Of String, String))

        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer

        dt = XMLDaten.Tables("Übersetzung")

        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            Dim temp1 As New Dictionary(Of String, String)
            For Each n As KeyValuePair(Of String, String) In Definitionen.ÜBERSETZUNGSATTR
                temp1(n.Key) = dr(n.Key)
            Next
            temp(dr("Kürzel")) = temp1
        Next

        Attr_get_übersetzungen = temp
    End Function
    'Liest die Formateinstellungen ein
    Function Attr_get_formate() As Dictionary(Of String, Dictionary(Of String, String))
        Dim temp As New Dictionary(Of String, Dictionary(Of String, String))
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dtf As DataTable
        Dim drf As DataRow
        Dim i As Integer

        Dim id As Integer

        dt = XMLDaten.Tables("FormatAttribute")
        dtf = XMLDaten.Tables("Format")

        'Formate durchlaufen
        For i = 0 To dtf.Rows.Count - 1
            drf = dtf.Rows(i)
            'ID des Datensatzes ermittel
            id = drf("Format_Id")
            dr = dt.Select("Format_Id=" & id)(0)
            Dim temp1 As New Dictionary(Of String, String)
            For Each n As KeyValuePair(Of String, String) In Definitionen.FORMATATTR
                temp1(n.Key) = dr(n.Key)
            Next
            temp(drf("Formatname")) = temp1
        Next
        Attr_get_formate = temp
    End Function
    'Liest die Tabelleneinstellungen ein
    Function Attr_get_Tabelle() As Dictionary(Of String, Dictionary(Of String, String))
        Dim temp As New Dictionary(Of String, Dictionary(Of String, String))
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dtf As DataTable
        Dim drf As DataRow
        Dim dtt As DataTable
        Dim drt As DataRow
        Dim i As Integer

        Dim id As Integer

        dt = XMLDaten.Tables("TabellenAttribute")
        dtf = XMLDaten.Tables("Format")
        dtt = XMLDaten.Tables("Tabelle")

        'Formate durchlaufen
        For i = 0 To dtf.Rows.Count - 1
            drf = dtf.Rows(i)
            'ID des Datensatzes ermittel
            id = drf("Format_Id")
            'Datensatz des Knotens Tabelle ermitteln
            drt = dtt.Select("Format_Id=" & id)(0)
            'ID des Datensatzes ermitteln
            id = drt("Tabelle_Id")
            'Tabellenattribute auswählen
            dr = dt.Select("Tabelle_Id=" & id)(0)
            Dim temp1 As New Dictionary(Of String, String)
            For Each n As KeyValuePair(Of String, String) In Definitionen.TABELLENATTR
                temp1(n.Key) = dr(n.Key)
            Next
            temp(drf("Formatname")) = temp1
        Next
        Attr_get_Tabelle = temp
    End Function

    Public Function GetAppPath() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        GetAppPath = path
    End Function


End Class
