Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic

Public Class Passungstabelle_Blatt

    ' Was wir alles von den Ansichten wissen wollen
    Structure Ansicht
        Dim ansichtsName As String      'Ansichtsname
        Dim ViewRef As View             'Verweis auf Ansicht
        Dim arefernz As ModelDoc2       'Referenz auf die die Ansicht verweist (Teil, Baugruppe, ...)
        Dim doctype As Integer          'Dockumenttyp der Ansichtsreferenz
        Dim holetab As HoleTable        'Bohrungstabelle

        'Intialisierungsfuntkion für die Strukur "Ansicht"
        Sub New(iansichtsName As String, iarefernz As ModelDoc2, idoctype As Integer, iViewRef As View)
            ansichtsName = iansichtsName
            ViewRef = iViewRef
            arefernz = iarefernz
            doctype = idoctype
            holetab = Nothing
        End Sub
    End Structure

    Property Blatt As Sheet                         'Verweis auf das Blatt
    Property BlattMod As ModelDoc2                  'Verweis auf die Datei von der die erste Ansicht abgeleitet ist
    Property Ansichten As New List(Of Ansicht)      'Liste der Ansichten auf dem Blatt
    Property AnzahlAnsichten As Integer             'Anzahl der Ansichten
    Property Tabelle As Passungstabelle_Tabelle     'Verweis auf die Tabelle

    'Attribute
    Property Attr_generell As New Dictionary(Of String, String)
    Property Attr_Übersetzungen As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Format As New Dictionary(Of String, String)
    Property Attr_Tabelle As New Dictionary(Of String, String)
    Property Attr_Sheet As Definitionen.BlattEigenschaften

    Property AlteTabelle As TableAnnotation         'Verweis auf eine eventuell vorhandene alte Passungstabelle
    Property AlteTabelleX As Double                 'X-Positon der alten Tabelle
    Property AlteTabelleY As Double                 'Y-Positon der alten Tabelle

    Property Log As LogFile                         'Verweis auf das Log-Datei Element

    Property Swapp As SldWorks                      'Verweis auf SolidWorks

    Dim swdraw As DrawingDoc                        'Verweis auf die Zeichnungsdatei
    Dim Einfügepunkt(1) As Double                   'Einfügepunkt für die Passungstabelle

    'Intialisierungsfuntkion für die Klasse "Passungstabelle_Blatt"
    Sub New(iswapp As SldWorks, iAttr_generell As Dictionary(Of String, String), iAttr_Übersetzungen As Dictionary(Of String, Dictionary(Of String, String)), iBlatt As Sheet, model As DrawingDoc)
        swapp = iswapp
        Attr_generell = iAttr_generell
        Attr_Übersetzungen = iAttr_Übersetzungen
        swdraw = model
        Blatt = iBlatt
        Log = New LogFile(Attr_generell)
    End Sub
    'Funktion:  PassungsTabelleGetViews
    '           erstellt eine Liste der Ansicht in dem angegebenen Blatt
    '           es werden nur Ansichten berücksichtigt, die auch vom konfigurierten Modell-Type abgeleitet sind
    '           sollen z.B.: Teile nicht berükcsicht werden, dann werden Ansicht die von Teilen abgeleitet sind
    '           nicht in die Liste aufgenommen
    'Parameter: swmodel     Verweis SolidWorks Datei
    '           blattname   Blattname
    'Ergebnis:  True
    Function PassungsTabelleGetViews(swmodel As ModelDoc2, blattname As String) As Boolean
        Dim swView As View
        Dim AnsichtRec As Ansicht
        Dim DocType As Integer = 0

        BlattMod = swmodel
        '* Verweis auf Blatt
        swdraw.ActivateSheet(blattname)
        Blatt = swdraw.Sheet(blattname)

        swdraw.GetViewCount()

        '* Erste Ansicht auf dem Blatt
        swView = swdraw.GetFirstView
        AnzahlAnsichten = 0


        'Dokumenttyp der auszuwertenden Ansichten holen (Teil, Baugruppe, ...)
        DocType = GetDokumentTypeFromSetup()

        '* So lange Ansichten gefunden werden
        While Not swView Is Nothing
            'Nur wenn der Dokumenttyp passt dann muss die Ansicht ausgewertet werden
            If (GetDocumentTypeFromRef(swView) And DocType) > 0 Then
                'Neuer Ansichtrekor
                AnsichtRec = New Ansicht(swView.Name, swView.ReferencedDocument, -1, swView)
                'Wenn eine Referenz extiert
                If Not AnsichtRec.arefernz Is Nothing Then
                    AnsichtRec.doctype = AnsichtRec.arefernz.GetType
                Else
                    AnsichtRec.doctype = 0
                End If
                AnzahlAnsichten = AnzahlAnsichten + 1
                'Auf Bohrungstabelle prüfen
                AnsichtRec.holetab = CheckForHoleTable(swView)
                'Ansicht zur Liste hinzufügen
                Ansichten.Add(AnsichtRec)
                'Prüfen ob eine alte Passungstabelle an der Ansicht hänt
                CheckForOldTable(swView)
            End If
            'Nächste Ansicht holen
            swView = swView.GetNextView
        End While

        PassungsTabelleGetViews = True
    End Function

    'ermittelt die Passungen für jede Ansicht
    Function PassungsTabelleGetDimensions() As Boolean
        Dim ans As Ansicht
        Dim dokt_setup As Integer = 0
        Dim dokt As Integer = 0

        'Falls es noch keine Tabelle gibt, dann eine neue erzeugen
        If Tabelle Is Nothing Then
            Tabelle = New Passungstabelle_Tabelle(Attr_generell, Attr_Tabelle, Attr_Übersetzungen)
            Tabelle.Log = Log
        End If

        For Each ans In Ansichten
            'Ansichtsnamen in Log-Datei schreiben
            Log.WriteInfo(ans.ansichtsName, False)

            'Passungen in der Ansicht suchen
            Tabelle.GetViewDimension(ans.ViewRef)

            'Wenn eine Bohrungstabelle gefunden wurde, 
            'dann wir sie untersucht
            If Not ans.holetab Is Nothing Then
                Tabelle.GetHoleTableDimension(ans.holetab)
            End If
            'Tabelle.getHoleTableDimension(ans.ViewRef)
        Next

        'Einfügepunkt setzen
        Tabelle.Einfügepunkt = Einfügepunkt
        'Sortiert die Tabelle und entfernt doppelte Einträge
        Tabelle.SetTabellenzeilenGefiltert()

        PassungsTabelleGetDimensions = True
    End Function

    'Ermittelt den Dokumenttyp der ausgewertet werden soll
    Function GetDokumentTypeFromSetup() As Integer
        Dim dokt_setup As Integer

        If Attr_generell("AnsichtsTypSkizzen") Then dokt_setup = 1
        If Attr_generell("AnsichtsTypTeile") Then dokt_setup = dokt_setup Xor 2
        If Attr_generell("AnsichtsTypBaugruppen") Then dokt_setup = dokt_setup Xor 4

        GetDokumentTypeFromSetup = dokt_setup
    End Function
    'bestimmt den Ansichtstyp der Ansicht
    Function GetDocumentTypeFromView(ans As Ansicht) As Integer
        Dim dokt As Integer = 0

        'wenn die Ansicht eine Referenz enthällt
        If Not ans.arefernz Is Nothing Then
            If ans.doctype = swDocumentTypes_e.swDocPART Then
                dokt = dokt Xor 2
            ElseIf ans.doctype = swDocumentTypes_e.swDocASSEMBLY Then
                dokt = dokt Xor 4
            End If
        Else
            dokt = dokt Xor 1
        End If
        GetDocumentTypeFromView = dokt
    End Function

    'bestimmt den Ansichtstyp der Ansicht
    Function GetDocumentTypeFromRef(ans As View) As Integer
        Dim dokt As Integer = 0
        If Not ans.ReferencedDocument Is Nothing Then
            If ans.ReferencedDocument.GetType = swDocumentTypes_e.swDocPART Then
                dokt = dokt Xor 2
            ElseIf ans.ReferencedDocument.GetType = swDocumentTypes_e.swDocASSEMBLY Then
                dokt = dokt Xor 4
            End If
        Else
            dokt = dokt Xor 1
        End If
        GetDocumentTypeFromRef = dokt
    End Function
    'ermittelt die Blatteigenschaften
    Function GetSheetProperties() As Definitionen.BlattEigenschaften
        Dim ss As Object
        Dim prop As New Definitionen.BlattEigenschaften

        'Blatteigenschaften
        ss = Blatt.GetProperties2

        'Formatname ohne Pfad
        prop.Formatname = Mid(Blatt.GetTemplateName, InStrRev(Blatt.GetTemplateName, "\") + 1)
        'Formatname ohne Erweiterung
        prop.Formatname = Mid(prop.Formatname, 1, Len(prop.Formatname) - 7)
        'Blatteigenschaften
        prop.Eigenschaften = ss
        'Sprache der SolidWorks-Installation
        prop.sprache = Swapp.GetCurrentLanguage
        GetSheetProperties = prop
    End Function

    Sub SetSheetAttr(Attr_Formate As Dictionary(Of String, Dictionary(Of String, String)), Attr_Tabellen As Dictionary(Of String, Dictionary(Of String, String)))
        'Die Eigenschaften vom Blatt holen
        Attr_Sheet = GetSheetProperties()
        'Wenn ein Name für die Formatvorlage gefunden wurde
        If Attr_Sheet.Formatname <> "" Then
            'Die entsprechenden Format Einstellungen laden
            SetSheetFormatAttr(Attr_Sheet.Formatname, Attr_Formate, Attr_Tabellen)
        Else
            'Sonst, Versuch die Formateinstellungen über die Blattabmessungen zu erhalten
            SetSheetFormatFromDimension(Attr_Formate, Attr_Tabellen)
        End If
    End Sub
    'Ermittelt die Setupeinstellungen für das übergebene Format
    Sub SetSheetFormatAttr(formatname As String, Attr_Formate As Dictionary(Of String, Dictionary(Of String, String)), Attr_Tabellen As Dictionary(Of String, Dictionary(Of String, String)))
        Dim temp As Dictionary(Of String, String)

        'Zuerst wird versucht den Formatnamen in den Einstellungen zu finden
        Try
            temp = Attr_Formate(formatname)
            'Das Format wurde gefunden und wird gesetzt
            Attr_Format = temp
            Attr_Tabelle = Attr_Tabellen(formatname)
        Catch ex As Exception
            'Format wurde nicht gefunden, dann müssen wir nach den Abmessungen suchen
            SetSheetFormatFromDimension(Attr_Formate, Attr_Tabellen)
        End Try
    End Sub
    'Sub:       SetSheetFormatFromDimension
    '           sucht nach einem Format in den Setup Einstellungen, das die gleichen Abmessungen hat wie das aktuelle Blattformat
    'Parameter: Format Attribute und Tabellen Attribute
    Sub SetSheetFormatFromDimension(Attr_Formate As Dictionary(Of String, Dictionary(Of String, String)), Attr_Tabellen As Dictionary(Of String, Dictionary(Of String, String)))
        Dim temp As Dictionary(Of String, String)
        Dim tempname As String = ""
        Dim firstloop As Boolean = False

        'Suche nach einem Format das die gleichen Abmessungen hat wie das Blatt
        For Each n As KeyValuePair(Of String, Dictionary(Of String, String)) In Attr_Formate
            temp = n.Value
            'beim ersten Durchlauf wird der Setup-Formatname des ersten Eintrags gespeichert
            'für den Fall, dass kein Format mit den selben Abemssungen gefunden wird,
            'werden die Werte vom ersten Eintrag im Setup übernommen
            If firstloop = False Then
                firstloop = True
                tempname = n.Key
            End If
            'Wenn ein Setupeintrag mit den gleichen ABmessungen gefunden wird
            If temp("Höhe") = Attr_Sheet.Eigenschaften(6) * 1000 And temp("Breite") = Attr_Sheet.Eigenschaften(5) * 1000 Then
                'Format Attribut zuweisen
                Attr_Format = temp
                'Tabellen Attribut zuweisen
                Attr_Tabelle = Attr_Tabellen(n.Key)
                'Log-Info schreiben
                Log.WriteInfo("Format " & Attr_Sheet.Formatname & " nicht gefunden", True)
                Log.WriteInfo("Abmessungen von " & n.Key & " genommen", True)
                Exit Sub
            End If
        Next

        'Es wurde keine Format mit dem Formatvorlagenamen gefunden
        'deshalb werden die Werte vom ersten Format genommen
        Log.WriteInfo("Kein Format mit den Abmessungen " & Attr_Sheet.Eigenschaften(6) * 1000 & "x" & Attr_Sheet.Eigenschaften(5) * 1000 & " gefunden", False)
        Log.WriteInfo("Abmessungen von ersten definierten Format " & tempname & " genommen", True)
        'Format Attribut vom ersten Eintrag zuweisen
        Attr_Format = Attr_Formate.Item(tempname)
        'Tabellen Attribut vom ersten Eintrag zuweisen
        Attr_Tabelle = Attr_Tabellen(tempname)
    End Sub

    'Sub:       DeleteTab
    '           löscht die Passungstabelle
    '           es wird davon ausgegangen, dass das Blatt, auf dem sich die Tabelle befindet aktiv ist
    'Parameter: keine
    Sub DeleteTab()
        Dim modeldoc As ModelDoc2

        'Wenn keine Tabelle gesetzt wurde, dann beenden
        If AlteTabelle Is Nothing Then
            Exit Sub
        End If

        modeldoc = swdraw
        modeldoc.Extension.SelectByID2("PASSUNGSTABELLE@" & Blatt.GetName, "ANNOTATIONTABLES", 0, 0, 0, False, 0, Nothing, 0)
        modeldoc.EditDelete()

        AlteTabelle = Nothing
    End Sub
    'Sub:       CheckForOldTable
    '           sucht nach einer vorhandenen Passungstabelle und setzt die entsprechenden Werte
    'Parameter: Ansicht in der gesucht werden soll
    Sub CheckForOldTable(swView As View)
        Dim swann As Annotation
        Dim swtable As TableAnnotation
        Dim tabexists As Boolean
        Dim tabvis As Boolean
        Dim anchor As Integer
        Dim position As Object
        Dim tabarray As Object
        Dim i As Integer

        'Alle Tabellen in der Ansicht ermitteln
        tabarray = swView.GetTableAnnotations

        'Wenn es keine Tabellen gibt, dann Ende der Funktion
        If tabarray Is Nothing Then
            Exit Sub
        End If

        'Alle Tabellen durchlaufen
        For i = 0 To UBound(tabarray)
            swtable = tabarray(i)
            'Das Annotationobjekt ermitteln
            swann = swtable.GetAnnotation
            'Wenn es sich um eine Passungstabelle handelt
            If swann.GetName = "PASSUNGSTABELLE" Then
                'Wenn die Passungstabelle nicht verdeckt ist
                If swann.Visible <> swAnnotationVisibilityState_e.swAnnotationHidden Then
                    tabvis = True
                Else
                    tabvis = False
                End If
                'Makrer setzen, dass eine Tabelle vorhanden ist
                tabexists = True
                'Verankerungspunkt speichern
                anchor = swtable.AnchorType
                'Einfügepunkt speichern
                position = swann.GetPosition
                AlteTabelleX = position(0)
                AlteTabelleY = position(1)
                'Verweis auf Tabellen-Objekt speichern
                AlteTabelle = swtable
            End If
            'Sobald eine Tabelle gefunden wurde, können wir die Schleife verlassen
            'sonst entstehen nur unnötige Durchläufe
            If tabexists = True Then Exit For
        Next
    End Sub
    'Function:  CheckForHoleTable
    '           prüft ob sich in der übergebenen Ansicht eine Bohrungstabelle befindet
    'Parameter: swView SWX Ansicht
    'Ergebnis:  Bohrungstabelle-Objekt 
    Function CheckForHoleTable(swView As View) As HoleTable
        Dim swtable As TableAnnotation
        Dim holtabann As HoleTableAnnotation
        Dim swholetable As HoleTable = Nothing
        Dim tabarray As Object
        Dim i As Integer

        'Alle Tabellen in der Ansicht ermitteln
        tabarray = swView.GetTableAnnotations

        'Wenn es keine Tabellen gibt, dann Ende der Funktion
        If tabarray Is Nothing Then
            CheckForHoleTable = Nothing
            Exit Function
        End If

        'Alle Tabellen durchlaufen
        For i = 0 To UBound(tabarray)
            swtable = tabarray(i)
            'Wenn es sich um eine Bohrungstabelle handelt
            'dann Ende der Funktion
            'Wir gehen davon aus, dass es nur eine Bohrungstabelle in einer Ansicht gibt
            If swtable.Type = swTableAnnotationType_e.swTableAnnotation_HoleChart Then
                holtabann = swtable
                swholetable = holtabann.HoleTable
                CheckForHoleTable = swholetable
                Exit Function
            End If
        Next
        CheckForHoleTable = swholetable
    End Function
    'Sub:       SetEinfügepunkt
    '           setzt die Koordinaten des Einfügepunkts der Tabelle an Hand der Setup Einstellungen
    'Parameter: keine
    Sub SetEinfügepunkt()
        Dim temp(1) As Double

        'X/Y Koordinaten des Einfügepunkts setzen
        'Links-Oben
        If Attr_Format("EinfügepunktLO") = True Then
            temp(0) = 0.0
            temp(1) = Attr_Format("Höhe") / 1000.0
            'Links-Unten
        ElseIf Attr_Format("EinfügepunktLU") = True Then
            temp(0) = 0.0
            temp(1) = 0.0
            'Rechts-Oben
        ElseIf Attr_Format("EinfügepunktRO") = True Then
            temp(0) = Attr_Format("Breite") / 1000.0
            temp(1) = Attr_Format("Höhe") / 1000.0
            'Rechts-Unten
        ElseIf Attr_Format("EinfügepunktRU") = True Then
            temp(0) = Attr_Format("Breite") / 1000.0
            temp(1) = 0.0
        End If

        'Offset berücksichtigen
        temp(0) = temp(0) + Attr_Format("Offset_X") / 1000.0
        temp(1) = temp(1) + Attr_Format("Offset_Y") / 1000.0

        Einfügepunkt = temp
    End Sub
    'Function:  GetColumnsCount
    '           ermittelt die Anzahl der Spalten der Tabelle
    'Parameter: keine
    'Ergebnis:  Anzahl der Spalten
    Private Function GetColumnsCount() As Integer
        Dim counter As Integer = 0

        If CBool(Attr_Tabelle("TabSpalteMaß")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpaltePassung")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpalteMaßePassung")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpalteToleranz")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpalteAbmaß")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpalteAbmaßToleranzMitte")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpalteVorbearbeitungsAbmaße")) Then counter = counter + 1
        If CBool(Attr_Tabelle("TabSpalteVorbearbeitungsToleranzMitte")) Then counter = counter + 1

        GetColumnsCount = counter
    End Function
    'Sub        SetEinfügePunktPosition
    '           setzt den Verankerungspunkt der Tabelle
    'Parameter: keine
    Sub SetEinfügePunktPosition()
        If CBool(Attr_Format("EinfügepunktLO")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_TopLeft
        If CBool(Attr_Format("EinfügepunktLU")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomLeft
        If CBool(Attr_Format("EinfügepunktRO")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_TopRight
        If CBool(Attr_Format("EinfügepunktRU")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomRight
    End Sub

    Sub InsertTable()

        SetEinfügepunkt()

        'Wenn nicht neu positioniert werden soll und es eine alte Tabelle gibt
        'dann wird der Einfügepunkt der alten Tabelle übernommen
        If CBool(Attr_generell("NeuPositionieren")) = False And Not AlteTabelle Is Nothing Then
            Tabelle.Einfügepunkt(0) = AlteTabelleX
            Tabelle.Einfügepunkt(1) = AlteTabelleY
        End If

        'Spalten bestimmen
        Tabelle.TabellenSpaltenCount = GetColumnsCount()

        'Neue Tabelle einfügen
        If Tabelle.TabellenZeilen.Count > 0 Then Tabelle.InsertTable(swdraw, Blatt)
    End Sub
End Class

