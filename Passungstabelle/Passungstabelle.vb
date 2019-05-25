Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Drawing
Imports System.Collections.Generic

Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Environment




Public Class Passungstabelle
    Property Macro_pfad As String
    Property Log_pfad As String
    Property Setup_pfad As String
    Property XMLDaten As New DataSet
    Property Attr_generell As New Dictionary(Of String, String)
    Property Attr_Übersetzungen As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Formate As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Tabelle As New Dictionary(Of String, Dictionary(Of String, String))
    Property Setup_Date_Time As Date

    Dim Log As New LogFile

    'Sub Main
    'Parameter: swapp       (SolidWorks ModelDoc Objekt)
    '           iDrawingDoc (SolidWorks ModelDoc2 Objekt) oder kein Parameter
    '                       der optionale Parameter ist notwendig, weil diese Sub 
    '                       einmal vom Commandmanager ohne 2. Parameter und
    '                       einmal vom Event mit 2. Parameter aufgerufen wird
    Sub Main(swapp As SldWorks, Optional iDrawingDoc As ModelDoc2 = Nothing)
        Dim swmod As SolidWorks.Interop.sldworks.ModelDoc2
        Dim pd As New Passungstabelle_Datei(swapp)
        Dim Passungengefunden As Boolean = False

        'Wenn keine Parameter vorhanden ist
        If Not iDrawingDoc Is Nothing Then
            swmod = iDrawingDoc
        Else
            swmod = swapp.ActiveDoc
        End If

        'Makropfad ermitteln
        Macro_pfad = GetAppPath()
        Setup_pfad = GetSetupPath()

        'Pfad für Log-Datei setzen
        Log_pfad = GetLogPath() & "\" & Definitionen.LOGName

        'Wenn keine Daten geladen sind oder sich die Setup Datei geändert hat, dann Setup Daten einlesen
        If Attr_generell.Count = 0 Or Setup_has_changed() Then
            'Wenn keine Setup-Datei gefunden werden kann, dann Sub beenden
            If Not Check_for_setup() Then Exit Sub
        End If

        'Setup Daten der Datei zuordnen
        pd.Attr_generell = Attr_generell
        pd.Attr_Übersetzungen = Attr_Übersetzungen
        pd.Attr_Formate = Attr_Formate
        pd.Attr_Tabelle = Attr_Tabelle
        pd.Swapp = swapp

        'Eigenschaften für das Log-Objekt setzen
        Log.Attr_generell = Attr_generell

        'Log-Info schreiben
        Log.WriteInfo("Start", False)

        'Dim s As DateTime = Now.ToLocalTime (Das war nur mal um die Geschwindigkeit zu bestimmen)

        'Das Log-Datei-Objekt dem Passungstabellen-Datei-Objekt zuordnen
        pd.Log = Log

        'Prüfung ob eine Zeichnung aktiv ist
        If Not Check_for_drawing(swmod) Then
            'Log.WriteInfo("Keine Zeichnung geladen", True)
            Exit Sub
        End If

        'Wenn Keine Blätter in der Zeichnung vorhanden sind, dann beenden
        If Not pd.PassungsTabelleGetSheets(swmod) Then
            Log.WriteInfo("Keine Blätter in der Zeichnung", True)
            Exit Sub
        End If

        'Tabelle einfügen
        pd.InsertTableOnSheets()

        'Log-Info schreiben
        Log.WriteInfo("Fertig", False)
    End Sub
    'Function:  Check_for_drawing
    'Parameter: swmod (SolidWorks ModelDoc Objekt)
    'Ergebnis:  True wenn das Dokument eine Zeichnung ist sonst False
    Function Check_for_drawing(swmod As ModelDoc2) As Boolean
        'Wenn Swmod keinen Wert hat, dann ist auch nichts geladen
        If swmod Is Nothing Then
            Log.WriteInfo("Keine Datei geladen", True)
            Check_for_drawing = False
            Exit Function
        End If
        'Wenn swmod keine Zeichnung ist
        If swmod.GetType <> swDocumentTypes_e.swDocDRAWING Then
            Log.WriteInfo("Keine Zeichnung geladen", True)
            Check_for_drawing = False
            Exit Function
        End If
        Check_for_drawing = True
    End Function
    'Function:  Check_For_setup
    'Parameter: keine
    'Ergebnis:  True wenn eine Setup-Datei vorhanden ist und diese auch gelesen werden konnte
    Function Check_for_setup() As Boolean
        Dim pfad As String
        Dim ok As Boolean


        'Macro_pfad = GetAppPath()
        Setup_pfad = GetSetupPath()
        pfad = Setup_pfad & Definitionen.INI_File

        Dim xmlSR As New System.IO.StringReader(My.Resources.Setup_Schema)

        'Schema initialisieren
        XMLDaten.Clear()
        XMLDaten.ReadXmlSchema(xmlSR)

        'Versuch die Setup-Datei einzulesen
        Try
            XMLDaten.ReadXml(pfad)
            ok = True
        Catch
            ok = False
            MsgBox("Keine Setup.XML Datei gefunden" & Chr(10) & "Bitte verwenden Sie das Setup-Makro um die Einstellungen zu erzeugen", vbOKOnly, "Passungstabelle Addin")
            Check_for_setup = False
            Exit Function
        End Try

        'Wenn die Setup-Datei gelesen werden konnte werden die Attribute eingelesen
        If Attr_read() = False Then
            Check_for_setup = False
        Else
            Check_for_setup = True
        End If
    End Function
    'Sub:       Attr_read
    'Parameter: keine
    'liest die Setup-Datei ein
    Function Attr_read() As Boolean
        Attr_generell = Attr_get_generell()
        Attr_Übersetzungen = Attr_get_übersetzungen()
        Attr_Formate = Attr_get_formate()
        Attr_Tabelle = Attr_get_Tabelle()

        If Attr_generell Is Nothing Or Attr_Übersetzungen Is Nothing Or Attr_Formate Is Nothing Or Attr_Tabelle Is Nothing Then
            Attr_read = False
            Exit Function
        End If

        Set_Setup_date()
        Attr_read = True
    End Function
    'Sub:       Set_Setup_date
    'Parameter: keine
    'Speichert das Änderungsdatum der Setup-Datei 
    Sub Set_Setup_date()
        Dim pfad As String
        'pfad = macro_pfad & "\" & Definitionen.INI_File
        pfad = Setup_pfad & Definitionen.INI_File
        Setup_Date_Time = File.GetLastWriteTime(pfad)
    End Sub
    'Function:  Setup_has_changed
    'Parameter: keine
    'Ergebnis:  True wenn sich das Änderungsdatum der Setup-Datei geändert hat sonst False
    'Prüft ob sich das Datum der letzten Speicherung geändert hat
    Function Setup_has_changed() As Boolean
        Dim pfad As String

        'pfad = macro_pfad & "\" & Definitionen.INI_File
        pfad = Setup_pfad & Definitionen.INI_File

        If Setup_Date_Time < File.GetLastWriteTime(pfad) Then
            Setup_Date_Time = File.GetLastWriteTime(pfad)
            Setup_has_changed = True
            Exit Function
        End If
        Setup_has_changed = False
    End Function
    Sub SaveSetup()
        'XMLWriterSettings intialisieren
        Dim settings As New XmlWriterSettings With {.Indent = True, .IndentChars = "   ", .NewLineOnAttributes = True}
        Dim XmlWrt As XmlWriter = XmlWriter.Create(Setup_pfad & Definitionen.INI_File, settings)

        'Änderungen im Dataset speichern
        XMLDaten.AcceptChanges()
        'Daten schreiben
        XMLDaten.WriteXml(XmlWrt, True)
        'Datei schließen
        XmlWrt.Close()
    End Sub
    'Liest die Generellen Einstellungen ein
    Function Attr_get_generell() As Dictionary(Of String, String)
        Dim temp As New Dictionary(Of String, String)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim attrname As String = ""
        Dim SaveNeeded As Boolean = False

        dt = XMLDaten.Tables("GenerelleAttribute")
        dr = dt.Rows(0)
        For Each n As KeyValuePair(Of String, String) In Definitionen.GENERELLE_ATTR
            Try
                attrname = n.Key
                temp(n.Key) = dr(n.Key)
            Catch ex As Exception
                Log.WriteInfo("Fehler beim Lesen des Attributes '" & attrname & "' im Abschnitt 'generelle Attribute'" & Chr(10) & "Makro 'Passungstabelle' abgebrochen", False)
                'Attr_get_generell = Nothing
                'Exit Function
                dr(n.Key) = Definitionen.GENERELLE_ATTR_Init(attrname)
                temp(n.Key) = Definitionen.GENERELLE_ATTR_Init(attrname)
                SaveNeeded = True
            End Try
        Next
        If SaveNeeded Then SaveSetup()
        Attr_get_generell = temp
    End Function
    'Liest die Übersetzungen ein
    Function Attr_get_übersetzungen() As Dictionary(Of String, Dictionary(Of String, String))
        Dim temp As New Dictionary(Of String, Dictionary(Of String, String))
        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim attrname As String = ""
        Dim SaveNeeded As Boolean = False
        dt = XMLDaten.Tables("Übersetzung")

        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            Dim temp1 As New Dictionary(Of String, String)
            For Each n As KeyValuePair(Of String, String) In Definitionen.ÜBERSETZUNGSATTR
                Try
                    attrname = n.Key
                    temp1(n.Key) = dr(n.Key)
                Catch ex As Exception
                    Log.WriteInfo("Fehler beim Lesen des Attributes '" & attrname & "' im Abschnitt 'Übersetzung'" & Chr(10) & "Vorgabewert wird gesetzt", False)
                    'Attr_get_übersetzungen = Nothing
                    'Exit Function
                    dr(n.Key) = Definitionen.ÜBERSETZUNGSATTR_Init(attrname)
                    temp1(n.Key) = Definitionen.ÜBERSETZUNGSATTR_Init(attrname)
                    SaveNeeded = True
                End Try
            Next
            temp(dr("Kürzel")) = temp1
        Next
        If SaveNeeded Then SaveSetup()
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
        Dim attrname As String = ""
        Dim id As Integer
        Dim SaveNeeded As Boolean = False

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
                Try
                    attrname = n.Key
                    temp1(n.Key) = dr(n.Key)
                Catch ex As Exception
                    Log.WriteInfo("Fehler beim Lesen des Attributes '" & attrname & "' im Abschnitt 'Format'" & Chr(10) & "Makro 'Passungstabelle' abgebrochen", False)
                    'Attr_get_formate = Nothing
                    'Exit Function
                    dr(n.Key) = Definitionen.FORMATATTR_Init(attrname)
                    temp1(n.Key) = Definitionen.FORMATATTR_Init(attrname)
                    SaveNeeded = True
                End Try
            Next
            dr.AcceptChanges()
            temp(drf("Formatname")) = temp1
        Next

        If SaveNeeded Then SaveSetup()

        Attr_get_formate = temp
    End Function

    'Function   GetAppPath
    'Paramter:  keine
    'Ergebnis:  liefert den Pfad der Applikation
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
        Dim attrname As String = ""
        Dim SaveNeeded As Boolean = False

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
                Try
                    attrname = n.Key
                    temp1(n.Key) = dr(n.Key)
                Catch ex As Exception
                    Log.WriteInfo("Fehler beim Lesen des Attributes '" & attrname & "' im Abschnitt 'Tabelle'" & Chr(10) & "Vorgabewert wird gesetzt", False)
                    'Attr_get_Tabelle = Nothing
                    'Exit Function
                    dr(n.Key) = Definitionen.TABELLENATTR_Init(attrname)
                    temp1(attrname) = Definitionen.TABELLENATTR_Init(attrname)
                    SaveNeeded = True
                End Try
            Next
            dr.AcceptChanges()
            temp(drf("Formatname")) = temp1
        Next
        If SaveNeeded Then SaveSetup()
        Attr_get_Tabelle = temp
    End Function

    'Function   GetAppPath
    'Paramter:  keine
    'Ergebnis:  liefert den Pfad der Applikation
    Public Function GetAppPath() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        GetAppPath = path
    End Function

    'Function   GetSetupPath
    'Paramter:  keine
    'Ergebnis:  liefert den Pfad der Setup-Datei
    Public Function GetSetupPath() As String
        Dim path As String
        path = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\Software\nahe", "SetupPfad", Nothing)
        If path Is Nothing Then
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        End If
        GetSetupPath = path
    End Function
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
