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
        Dim holetab As HoleTable
        'Dim firstView As Boolean
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


    Property Attr_generell As New Dictionary(Of String, String)
    Property Attr_Übersetzungen As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Format As New Dictionary(Of String, String)
    Property Attr_Tabelle As New Dictionary(Of String, String)
    Property Attr_Sheet As Definitionen.BlattEigenschaften

    Property AlteTabelle As TableAnnotation
    Property AlteTabelleX As Double
    Property AlteTabelleY As Double

    Property Log As LogFile

    Property Swapp As SldWorks

    Dim swdraw As DrawingDoc
    Dim Einfügepunkt(1) As Double


    Sub New(iswapp As SldWorks, iAttr_generell As Dictionary(Of String, String), iAttr_Übersetzungen As Dictionary(Of String, Dictionary(Of String, String)), iBlatt As Sheet, model As DrawingDoc )
        swapp = iswapp
        Attr_generell = iAttr_generell
        Attr_Übersetzungen = iAttr_Übersetzungen
        swdraw = model
        Blatt = iBlatt
        Log = New LogFile(Attr_generell)
    End Sub
    Function PassungsTabelleGetViews(swmodel As SolidWorks.Interop.sldworks.ModelDoc2, blattname As String) As Boolean
        ' Dim swDraw As DrawingDoc
        Dim swView As View
        Dim AnsichtRec As Ansicht
        Dim DocType As Integer = 0

        'swDraw = swmodel

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


        'If AnzahlAnsichten = 1 And swView Is Nothing Then
        '    passungsTabelleGetViews = False
        'Else
        '    passungsTabelleGetViews = True
        'End If

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

        'Start Zeitmessung
        Dim s As DateTime = Now.ToLocalTime

        For Each ans In Ansichten
            'dokt = GetDocumentTypeFromView(ans)
            'If (dokt And dokt_setup) > 0 Then

            Log.WriteInfo(ans.ansichtsName, False)

            'Passungen in der Ansicht suchen
            Tabelle.GetViewDimension(ans.ViewRef)
            'End If

            'Wenn eine Bohrungstabelle gefunden wurde, 
            'dann wir sie untersucht
            If Not ans.holetab Is Nothing Then
                Tabelle.getHoleTableDimension(ans.holetab)
            End If
            'Tabelle.getHoleTableDimension(ans.ViewRef)
        Next

        'Ende Zeitmessung
        'Dim e As DateTime = Now.ToLocalTime
        'MsgBox("Bemaßungen" & e.Subtract(s).ToString, vbOKOnly, "Meldung")

        Tabelle.Einfügepunkt = Einfügepunkt
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
    Function GetSheetProperties() As Definitionen.BlattEigenschaften
        Dim ss As Object
        Dim prop As New Definitionen.BlattEigenschaften

        ss = Blatt.GetProperties2

        prop.Formatname = Mid(Blatt.GetTemplateName, InStrRev(Blatt.GetTemplateName, "\") + 1)
        prop.Formatname = Mid(prop.Formatname, 1, Len(prop.Formatname) - 7)
        prop.Eigenschaften = ss
        prop.sprache = swapp.GetCurrentLanguage
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
            SetSheetFormatFromDimension(Attr_Formate, Attr_Tabellen)
        End If
    End Sub

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

    Sub SetSheetFormatFromDimension(Attr_Formate As Dictionary(Of String, Dictionary(Of String, String)), Attr_Tabellen As Dictionary(Of String, Dictionary(Of String, String)))
        Dim temp As Dictionary(Of String, String)
        Dim tempname As String = ""
        Dim firstloop As Boolean = False


        'Suche nach einem Format das die Abmessungen wie das Blatt hat
        For Each n As KeyValuePair(Of String, Dictionary(Of String, String)) In Attr_Formate
            temp = n.Value
            If firstloop = False Then
                firstloop = True
                tempname = n.Key
            End If
            If temp("Höhe") = Attr_Sheet.Eigenschaften(6) * 1000 And temp("Breite") = Attr_Sheet.Eigenschaften(5) * 1000 Then
                Attr_Format = temp
                Attr_Tabelle = Attr_Tabellen(n.Key)
                Log.WriteInfo("Format " & Attr_Sheet.Formatname & " nicht gefunden", True)
                Log.WriteInfo("Abmessungen von " & n.Key & " genommen", True)
                Exit Sub
            End If
        Next

        'Es wurde keine Format mit dem Formatvorlagenamen gefunden
        'deshalb werden die Werte vom ersten Format genommen
        Log.WriteInfo("Kein Format mit den Abmessungen " & Attr_Sheet.Eigenschaften(6) * 1000 & "x" & Attr_Sheet.Eigenschaften(5) * 1000 & " gefunden", False)
        Log.WriteInfo("Abmessungen von ersten definierten Format " & tempname & " genommen", True)
        Attr_Format = Attr_Formate.Item(tempname)
        Attr_Tabelle = Attr_Tabellen(tempname)
    End Sub
    'löscht die Passungstabelle
    Sub DeleteTab()
        'Wenn keine Tabelle gesetzt wurde, dann beenden
        If AlteTabelle Is Nothing Then
            Exit Sub
        End If
        'AlteTabelle.GeneralTableFeature.GetFeature.Select(False)
        AlteTabelle.GetAnnotation.Select(True)
        'AlteTabelle.Select(False)
        BlattMod.Extension.DeleteSelection2(swDeleteSelectionOptions_e.swDelete_Absorbed)
        'BlattMod.DeleteSelection(swDeleteSelectionOptions_e.swDelete_Absorbed)
        AlteTabelle = Nothing
    End Sub
    'sucht nach einer vorhandenen Passungstabelle und setzt die entsprechenden Werte
    Sub CheckForOldTable(swView As View)
        Dim swann As Annotation
        Dim swtable As TableAnnotation
        Dim tabexists As Boolean
        Dim tabvis As Boolean
        Dim anchor As Integer
        Dim position As Object
        Dim tabarray As Object
        Dim i As Integer

        tabarray = swView.GetTableAnnotations

        If tabarray Is Nothing Then
            Exit Sub
        End If
        For i = 0 To UBound(tabarray)
            swtable = tabarray(i)
            swann = swtable.GetAnnotation
            If swann.GetName = "PASSUNGSTABELLE" Then
                If swann.Visible <> 3 Then
                    tabvis = True
                Else
                    tabvis = False
                End If
                tabexists = True
                anchor = swtable.AnchorType
                position = swann.GetPosition
                AlteTabelleX = position(0)
                AlteTabelleY = position(1)
                AlteTabelle = swtable
            End If
            If tabexists = True Then Exit For
        Next
    End Sub

    Function CheckForHoleTable(swView As View) As HoleTable
        Dim swtable As TableAnnotation
        Dim holtabann As HoleTableAnnotation
        Dim swholetable As HoleTable = Nothing
        Dim tabarray As Object
        Dim i As Integer

        tabarray = swView.GetTableAnnotations

        If tabarray Is Nothing Then
            CheckForHoleTable = Nothing
            Exit Function
        End If

        For i = 0 To UBound(tabarray)
            swtable = tabarray(i)
            'If swtable.Type = swTableAnnotationType_e.swTableAnnotation_HoleChart Then
            If swtable.Type = 1 Then
                holtabann = swtable
                swholetable = holtabann.HoleTable
                CheckForHoleTable = swholetable
                Exit Function
            End If
        Next
        CheckForHoleTable = swholetable
    End Function

    Sub SetEinfügepunkt()
        Dim temp(1) As Double
        If Attr_Format("EinfügepunktLO") = True Then
            temp(0) = 0.0
            temp(1) = Attr_Format("Höhe") / 1000.0
        ElseIf Attr_Format("EinfügepunktLU") = True Then
            temp(0) = 0.0
            temp(1) = 0.0
        ElseIf Attr_Format("EinfügepunktRO") = True Then
            temp(0) = Attr_Format("Breite") / 1000.0
            temp(1) = Attr_Format("Höhe") / 1000.0
        ElseIf Attr_Format("EinfügepunktRU") = True Then
            temp(0) = Attr_Format("Breite") / 1000.0
            temp(1) = 0.0
        End If

        temp(0) = temp(0) + Attr_Format("Offset_X") / 1000.0
        temp(1) = temp(1) + Attr_Format("Offset_Y") / 1000.0

        Einfügepunkt = temp
    End Sub

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

    Sub SetEinfügePunktPosition()
        If CBool(Attr_Format("EinfügepunktLO")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_TopLeft
        If CBool(Attr_Format("EinfügepunktLU")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomLeft
        If CBool(Attr_Format("EinfügepunktRO")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_TopRight
        If CBool(Attr_Format("EinfügepunktRU")) Then Tabelle.Einfügepunktposition = swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomRight
    End Sub

    Sub InsertTable()
        'Dim swTable As TableAnnotation

        SetEinfügepunkt()

        'Wenn nicht neu positioniert werden soll
        If CBool(Attr_generell("NeuPositionieren")) = False And Not AlteTabelle Is Nothing Then
            Tabelle.Einfügepunkt(0) = AlteTabelleX
            Tabelle.Einfügepunkt(1) = AlteTabelleY
        End If

        DeleteTab()

        'Spalten bestimmen
        Tabelle.tabellenSpaltenCount = GetColumnsCount()

        'Wenn vorhanden alte Tabelle löschen

        'Neue Tabelle einfügen
        If Tabelle.TabellenZeilen.Count > 0 Then Tabelle.InsertTable(swdraw, Blatt)
    End Sub
End Class

