Imports System.Windows.Forms
Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Xml
Imports System.IO

Public Class SetupDialog
    Property Swapp As SldWorks
    Property Macro_pfad As String
    Property Setup_pfad As String
    Property Pos As Integer = -1

    Dim SpaltenBoxen As New Dictionary(Of String, List(Of Control))

    'Wandelt einen Integerwert in ein Color-Objekt mit Transparenz um
    'IntegerToColor(ByRef RGB As Int32)
    'Parameter      
    '   RGB          Integerwert der Farbe
    'Rückgabewert
    '   Color-Objekt
    Public Function IntegerToColor(ByRef RGB As Int32) As System.Drawing.Color
        Dim Bytes As Byte() = BitConverter.GetBytes(RGB)
        Dim Alpha As Byte = 255
        Dim Red As Byte = Bytes(2)
        Dim Green As Byte = Bytes(1)
        Dim Blue As Byte = Bytes(0)
        Return Color.FromArgb(Alpha, Red, Green, Blue)
    End Function

    'Wandelt einen Integerwert in ein Color-Objekt ohne Transparenz um
    'IntegerToColor(ByRef RGB As Int32)
    'Parameter      
    '   RGB          Integerwert der Farbe
    'Rückgabewert
    '   Color-Objekt
    Public Function IntegerToColorAlpha(ByRef RGB As Int32) As System.Drawing.Color
        Dim Bytes As Byte() = BitConverter.GetBytes(RGB)
        'Transparenz auf 0 setzen
        Dim Alpha As Byte = 0
        Dim Red As Byte = Bytes(2)
        Dim Green As Byte = Bytes(1)
        Dim Blue As Byte = Bytes(0)
        Return Color.FromArgb(Alpha, Red, Green, Blue)
    End Function

    'Sichert die Setupeinstellungen im Makropfad als Setup.XML
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim XmlWrt As XmlWriter

        'XMLWriterSettings intialisieren
        Dim settings As New XmlWriterSettings With {.Indent = True, .IndentChars = "   ", .NewLineOnAttributes = True}

        Try
            XmlWrt = XmlWriter.Create(Setup_pfad & Definitionen.INI_File, settings)
        Catch ex As Exception
            MsgBox("Fehler beim Schreiben der Datei" & Chr(10) & Setup_pfad & Chr(10) & "Datei kann nicht gesichert werden")
            Exit Sub
        End Try

        'Nur wenn es Einträge gibt wird gesichert
        If ListBoxFormate.Items.Count = 0 Then
            MsgBox("Keine Formate zum speichern vorhanden", vbInformation & vbOKOnly, "Meldung")
            Exit Sub
        End If
        'Änderungen im Dataset speichern
        Data.AcceptChanges()
        'Daten schreiben
        If Not XmlWrt Is Nothing Then
            Try
                Data.WriteXml(XmlWrt, True)
            Catch ex As Exception
                MsgBox("Fehler beim Schreiben der Datei" & Chr(10) & Setup_pfad & Chr(10) & "Datei kann nicht gesichert werden")
                Exit Sub
            End Try
        End If

        'Datei schließen
        If Not XmlWrt Is Nothing Then
            XmlWrt.Close()
        End If
    End Sub

    'Abbruch
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Data = Nothing
        Me.Close()
    End Sub

    'Textattribute für die Tabellenkopfzeile einstellen
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles TabellenKopfZeileBT.Click
        Dim st As FontStyle
        Dim d As Single

        'Aktuelle Werte des Schrifstils ermitteln und zuweisen
        If UnterstrichenKopfZeile.Checked Then st = st Xor FontStyle.Underline
        If DurchgestrichenKopfZeile.Checked Then st = st Xor FontStyle.Strikeout
        If FettKopfZeile.Checked Then st = st Xor FontStyle.Bold
        If KursivKopfZeile.Checked Then st = st Xor FontStyle.Italic

        'Wenn ein Wert für die Schrifthöhe vorhanden ist
        If TexthöheZeile.Text <> "" Then d = (CDbl(TexthöheZeile.Text) / 10) * 72 / 2.54 Else d = 10

        'Werte dem Fontobjekt zuordnen, damit das auch im Fontdialog angezeigt wird
        Dim schrift = New Font(SchriftartKopfZeile.Text, d, st)

        'Fontdialog intialisieren
        FontDialog1.Font = schrift
        FontDialog1.Color = FarbeKopfZeile.BackColor
        FontDialog1.ShowEffects = True
        FontDialog1.ShowColor = True

        'Wenn nicht Abbruch gewählt wurde
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            'Werte in Dialogfelder übernehmen
            FarbeKopfZeile.BackColor = FontDialog1.Color
            FarbeKopfZeile.ForeColor = FontDialog1.Color
            FarbeKopfZeile.Text = FontDialog1.Color.ToArgb
            SchriftartKopfZeile.Text = FontDialog1.Font.Name
            If FontDialog1.Font.Style And FontStyle.Underline Then UnterstrichenKopfZeile.Checked = True Else UnterstrichenKopfZeile.Checked = False
            If FontDialog1.Font.Style And FontStyle.Strikeout Then DurchgestrichenKopfZeile.Checked = True Else DurchgestrichenKopfZeile.Checked = False
            If FontDialog1.Font.Style And FontStyle.Bold Then FettKopfZeile.Checked = True Else FettKopfZeile.Checked = False
            If FontDialog1.Font.Style And FontStyle.Italic Then KursivKopfZeile.Checked = True Else KursivKopfZeile.Checked = False
        End If
    End Sub
    'Textattribute für die Tabellenzeile einstellen
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles TabellenZeilenBT.Click
        Dim st As FontStyle
        Dim d As Single

        'FontDialog1.ShowEffects = True
        'FontDialog1.ShowColor = True

        If UnterstrichenZeile.Checked Then st = st Xor FontStyle.Underline
        If DurchgestrichenZeile.Checked Then st = st Xor FontStyle.Strikeout
        If FettZeile.Checked Then st = st Xor FontStyle.Bold
        If KursivKopfZeile.Checked Then st = st Xor FontStyle.Italic

        If TexthöheZeile.Text <> "" Then d = (CDbl(TexthöheZeile.Text) / 10) * 72 / 2.54 Else d = 10

        Dim schrift = New Font(SchriftartZeile.Text, d, st)

        FontDialog1.Font = schrift
        FontDialog1.Color = FarbeZeile.BackColor

        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            FarbeZeile.BackColor = FontDialog1.Color
            FarbeZeile.ForeColor = FontDialog1.Color
            FarbeZeile.Text = FontDialog1.Color.ToArgb
            SchriftartZeile.Text = FontDialog1.Font.Name
            If FontDialog1.Font.Style And FontStyle.Underline Then UnterstrichenZeile.Checked = True Else UnterstrichenZeile.Checked = False
            If FontDialog1.Font.Style And FontStyle.Strikeout Then DurchgestrichenZeile.Checked = True Else DurchgestrichenZeile.Checked = False
            If FontDialog1.Font.Style And FontStyle.Bold Then FettZeile.Checked = True Else FettZeile.Checked = False
            If FontDialog1.Font.Style And FontStyle.Italic Then KursivZeile.Checked = True Else KursivZeile.Checked = False
        End If
    End Sub

    'Alte INI Datei einlesen
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim pfad As String
        Dim ok As Boolean

        'Abfrage ob die Setup-Datei auch wirkllich ersetzt werden soll
        If MsgBox("Achtung: Dadurch wird eine ev. vorhandene Setup Datei ersetzt." & Chr(10) & "Wählen Sie Ja wenn Sie die Datei importieren möchten", vbYesNo, "Meldung") = vbNo Then
            Exit Sub
        End If

        pfad = Setup_pfad & Definitionen.INI_File

        If WriteAccess(pfad) = False Then
            MsgBox("Sie haben keinen Schreibzugriff auf die Datei " & pfad & " oder sie existiert nicht", vbOKOnly, "Meldung")
            Exit Sub
        End If

        ok = False

        'Wenn die alte Ini-Datei eingelsen werden konnte
        If Module1.Write_XML_from_old_ini(Me) Then
            'Fortschrittbalken und Text setzen
            ToolStripProgressBar1.Value = 9
            ToolStripStatusLabel1.Text = "Datei lesen"
            Refresh()
            'Versuche die XML-Datei einzulesen
            Try
                Data.ReadXml(pfad)
                'Dataset zurücksetzen
                'erst nachdem wir sicher sind, dass die Datei auch gelesen werden kann
                'wird das Dataset Objekt gelöscht
                Data.Clear()
                Data.ReadXml(pfad)
                GenerelleAttributeBindingSource.Position = 0
                ToolStripProgressBar1.Value = 0
                ToolStripStatusLabel1.Text = "Alte Datei konvertiert"
            Catch
                'Falls das Lesen nicht erfolgreich war
                Module1.Create_Tabels(Data)
                MsgBox("Fehler beim Lesen der Setup.XML Datei", vbOKOnly, "Meldung")
                ToolStripProgressBar1.Value = 0
                ToolStripStatusLabel1.Text = "Fehler bei der Konvertierung"
            End Try
        End If
        Refresh()
        TabControl1.SelectedTab = TabPage4
        MsgBox("Achtung:" & Chr(10) & "da zusätzliche Spalten dazugekommen sind" & Chr(10) & "müssen Sie die Spaltenübersetzungen, im Tabulator, 'Sprachen' ergänzen", vbInformation, "Meldung")
    End Sub

    Private Sub SetSpaltenFarbe(Spalte As String, Aktiv As Boolean)
        Dim ctrlList As New List(Of Control)

        ctrlList = SpaltenBoxen(Spalte)

        For Each ctrl In ctrlList
            If Aktiv Then ctrl.BackColor = Color.LightGreen Else ctrl.BackColor = Color.White
        Next
    End Sub

    Private Sub SetSpaltenBoxen()
        Dim ctrls As Control()
        Dim j As Integer = 1
        Dim i As Integer = 1

        While Me.Controls.Find("CB_Spalte" & j, True).Length >= 1
            Dim ctrlList As New List(Of Control)
            ctrls = Me.Controls.Find("CB_Spalte" & j, True)
            Do
                ctrls = Me.Controls.Find("SP" & j & "_TB" & i, True)
                If ctrls.Length = 1 Then ctrlList.Add(ctrls(0))
                i = i + 1
            Loop Until ctrls.Length < 1
            SpaltenBoxen.Add("CB_Spalte" & j, ctrlList)
            i = 1
            j = j + 1
        End While
    End Sub

    Private Sub SetupDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim pfad As String
        Dim ok As Boolean

        'Macro_pfad = GetAppPath()
        Setup_Pfad = GetSetupPath()

        pfad = Setup_pfad & Definitionen.INI_File

        'Versuch die Setup Datei zu lesen
        Try
            Data.ReadXml(pfad)
            GenerelleAttributeBindingSource.Position = 0
            ok = True
        Catch
            ok = False
            Module1.Create_Tabels(Data)
            MsgBox("Keine Setup.XML Datei gefunden, Daten werden mit Standardwerten befüllt", vbOKOnly, "Meldung")
        End Try

        'Check ob die Setup Datei geschrieben werden kann
        If WriteAccess(pfad) = False Then
            MsgBox("Sie haben kein Schreibrecht für die Datei " & Chr(10) & pfad & Chr(10) & " Setup wird abgebrochen", vbOKOnly, "Meldung")
            Me.Close()
            Exit Sub
        End If

        Module1.SwxMacroPfad = Setup_pfad
        TabControl1.TabPages(2).Refresh()
        TabControl1.TabPages(0).Refresh()
        SetSpaltenBoxen()

        Setup_pfad = GetSetupPath()

        Me.Text = "Passungstabelle Ver. " & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & " Setup für - " & ListBoxFormate.Text
    End Sub

    Private Sub FarbeZeile_TextChanged(sender As Object, e As EventArgs) Handles FarbeZeile.TextChanged
        sender.BackColor = IntegerToColor(sender.text)
        sender.ForeColor = sender.BackColor
    End Sub

    Private Sub FarbeKopfZeile_TextChanged(sender As Object, e As EventArgs) Handles FarbeKopfZeile.TextChanged
        sender.BackColor = IntegerToColor(sender.text)
        sender.ForeColor = sender.BackColor
    End Sub

    Private Sub ListBoxFormate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxFormate.SelectedIndexChanged
        pos = sender.SelectedIndex

        TabellenAttributeBindingSource.Position = pos
        FormatAttributeBindingSource.Position = Pos
        FormatBindingSource1.Position = Pos
        Me.Text = "Passungstabelle Ver. " & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString & " Setup für - " & ListBoxFormate.Text

    End Sub

    Sub Insert_sprachkombinationen()
        Dim sprachen As New List(Of String)
        Dim dr As DataRow
        Dim i As Integer
        Dim bs As BindingSource
        Dim dt As DataTable = New DataTable()

        For i = 0 To DataGridÜbersetzungen.Rows.Count - 2
            sprachen.Add(DataGridÜbersetzungen.Rows(i).Cells(0).Value.ToString)
        Next

        sprachen = Module1.berechne_Sprachkombinationen_FromSimpleList(sprachen)

        bs = HeaderLanguage.DataSource
        dt = CType(bs.DataSource.Tables("Sprachkombination"), DataTable)
        dt.Rows.Clear()

        For Each n In sprachen
            dr = dt.NewRow
            dr("Name") = n
            dr("Sprachkombinationen_Id") = 0
            dt.Rows.Add(dr)
        Next
    End Sub


    Function GetSheetProperties() As Definitionen.BlattEigenschaften
        Dim doc As SolidWorks.Interop.sldworks.ModelDoc2
        Dim drw As SolidWorks.Interop.sldworks.DrawingDoc
        Dim sh As SolidWorks.Interop.sldworks.Sheet
        Dim ss As Object
        Dim prop As New Definitionen.BlattEigenschaften


        doc = swapp.ActiveDoc
        If doc Is Nothing Then
            MsgBox("Keine Datei geladen", vbInformation, "Meldung")
            GetSheetProperties = prop
            Exit Function
        End If

        If doc.GetType <> SolidWorks.Interop.swconst.swDocumentTypes_e.swDocDRAWING Then
            MsgBox("Keine Zeichnung geladen", vbInformation, "Meldung")
            GetSheetProperties = prop
            Exit Function
        End If

        drw = doc
        sh = drw.GetCurrentSheet
        ss = sh.GetProperties2

        prop.Formatname = Mid(sh.GetTemplateName, InStrRev(sh.GetTemplateName, "\") + 1)
        prop.Formatname = Mid(prop.Formatname, 1, Len(prop.Formatname) - 7)
        prop.Eigenschaften = ss
        prop.sprache = swapp.GetCurrentLanguage
        GetSheetProperties = prop
    End Function

    Function FormatBereitsVorhanden(format As String) As Boolean
        If ListBoxFormate.Items.Contains(format) Then
            FormatBereitsVorhanden = True
        Else
            FormatBereitsVorhanden = False
        End If
    End Function

    Private Function Format_anlegen() As String
        Dim name As String

        name = InputBox("Formatname: ", "Format anlegen", "")
        If name = "" Then
            Format_anlegen = ""
        Else
            Format_anlegen = name
        End If
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim prop As New Definitionen.BlattEigenschaften
        Dim bs As BindingSource
        Dim dtf As DataTable 'Formate Tabelle
        Dim dta As DataTable 'Formatattribute Tabelle
        Dim dtt As DataTable 'Tabellen Tabell
        Dim dtta As DataTable 'Tabellenattribute Tabelle
        Dim drf As DataRow 'Formate Zeile
        Dim dra As DataRow 'Formatattribute Zeile
        Dim drt As DataRow 'Tabellen Zeile
        Dim drta As DataRow 'Tabellenattribute Zeile
        Dim antwort As Integer
        Dim name As String

        prop = GetSheetProperties()

        If prop.Eigenschaften Is Nothing Then
            antwort = MsgBox("Keine Format gefunden. Möchten Sie ein Format manuell erstellen?", vbYesNo, "Meldung")
            If antwort = vbNo Then
                Exit Sub
            End If
            name = Format_anlegen()
            If name = "" Then
                Exit Sub
            End If
            prop.Formatname = name
            prop.Eigenschaften = New VariantType
            ReDim prop.Eigenschaften(6)
            prop.Eigenschaften(5) = 210 / 1000.0
            prop.Eigenschaften(6) = 297 / 1000.0
            prop.sprache = swapp.GetCurrentLanguage
        End If

        If FormatBereitsVorhanden(prop.Formatname) Then
            MsgBox("Format ist bereits definiert", vbInformation, "Meldung")
            Exit Sub
        End If

        bs = ListBoxFormate.DataSource
        dtf = CType(bs.DataSource.Tables("Format"), DataTable)
        drf = dtf.NewRow
        drf("Formatname") = prop.Formatname
        drf("Formate_id") = 0
        dtf.Rows.Add(drf)

        'Formatattribute
        dta = Data.Tables("FormatAttribute")
        dra = dta.NewRow
        dra("Breite") = (CDbl(prop.Eigenschaften(5)) * 1000).ToString
        dra("Höhe") = (CDbl(prop.Eigenschaften(6)) * 1000).ToString
        dra("Format_Id") = drf("Format_Id")
        dra("EinfügepunktLO") = "False"
        dra("EinfügepunktRO") = "True"
        dra("EinfügepunktLU") = "False"
        dra("EinfügepunktRU") = "False"
        dra("OFfset_X") = "0"
        dra("OFfset_Y") = "0"
        dta.Rows.Add(dra)

        'Tabelle
        dtt = Data.Tables("Tabelle")
        drt = dtt.NewRow
        drt("Format_Id") = drf("Format_Id")
        dtt.Rows.Add(drt)

        'Tabellenattribute
        dtta = Data.Tables("TabellenAttribute")
        drta = dtta.NewRow
        drta("Tabelle_Id") = drt("Tabelle_Id")
        For Each n As KeyValuePair(Of String, String) In Definitionen.TABELLENATTR
            drta(n.Key) = Definitionen.TABELLENATTR_Init(n.Key)
        Next
        dtta.Rows.Add(drta)

        ListBoxFormate.SelectedIndex = ListBoxFormate.Items.Count - 1

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dr As DataRow
        Dim antwort As Integer
        Dim dtf As DataTable
        Dim bs As BindingSource
        Dim delpos As Integer

        If ListBoxFormate.SelectedIndex = -1 Then
            MsgBox("Kein Eintrag gewählt", vbInformation & vbOKOnly, "Meldung")
            Exit Sub
        End If

        antwort = MsgBox("Sind Sie sicher, dass Sie den Eintrag löschen möchten?", vbQuestion & vbYesNo, "Meldung")

        If antwort <> vbYes Then
            Exit Sub
        End If

        bs = ListBoxFormate.DataSource
        dtf = CType(bs.DataSource.Tables("Format"), DataTable)

        delpos = 0
        For Each dr In dtf.Rows
            If dr.Item("Formatname").ToString = ListBoxFormate.SelectedItem("Formatname") Then
                Exit For
            End If
            delpos = delpos + 1
        Next

        dtf.Rows(delpos).Delete()

        ListBoxFormate.SelectedIndex = -1
    End Sub

    Private Sub DataGridÜbersetzungen_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridÜbersetzungen.CellValueChanged
        Dim sprachen As New List(Of String)
        Dim i As Integer


        For i = 0 To DataGridÜbersetzungen.Rows.Count - 3
            sprachen.Add(DataGridÜbersetzungen.Rows(i).Cells(0).Value)
        Next

        If e.ColumnIndex > 0 Then
            Exit Sub
        End If

        If sprachen.Count > 0 Then
            If DataGridÜbersetzungen.Rows(e.RowIndex).Cells(0).Value.ToString <> "" Then
                If sprachen.Contains(DataGridÜbersetzungen.Rows(e.RowIndex).Cells(0).Value.ToString) = True Then
                    MsgBox("Diese Sprache ist bereits definiert", vbInformation, "Meldung")
                    DataGridÜbersetzungen.Rows(e.RowIndex).Cells(0).Value = ""
                Else
                    'Id speichern
                    DataGridÜbersetzungen.Rows(e.RowIndex).Cells(DataGridÜbersetzungen.Rows(0).Cells.Count - 1).Value = DataGridÜbersetzungen.Rows(0).Cells(DataGridÜbersetzungen.Rows(0).Cells.Count - 1).Value
                    Insert_sprachkombinationen()
                End If
            End If
        End If
    End Sub

    Private Sub DataGridÜbersetzungen_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles DataGridÜbersetzungen.UserDeletingRow
        Dim antwort As Integer
        Dim kombinationen As New List(Of String)
        Dim s1 As String
        Dim i As Integer


        If DataGridÜbersetzungen.Rows.Count = 0 Then
            e.Cancel = vbCancel
            Exit Sub
        End If

        If DataGridÜbersetzungen.Rows.Count = 1 And pos = 0 Then
            MsgBox("Der einzige Eintrag kann nicht gelöscht werden", vbInformation, "Meldung")
            e.Cancel = vbCancel
            Exit Sub
        End If

        TabellenAttributeBindingSource.MoveFirst()
        For i = 0 To TabellenAttributeBindingSource.Count - 1
            kombinationen.Add(TabellenAttributeBindingSource.Current.row("Headerlanguage"))
            TabellenAttributeBindingSource.MoveNext()
        Next

        s1 = DataGridÜbersetzungen.Rows(e.Row.Index).Cells(0).Value.ToString

        For Each n In kombinationen
            If InStr(n, s1) Then
                MsgBox("Diese Sprache wird in einer Tabelle verwendet und kann nicht gelöscht werden", vbInformation, "Meldung")
                e.Cancel = vbCancel
                Exit Sub
            End If
        Next

        antwort = MsgBox("Sind Sie sicher, dass Sie den Eintrag löschen möchten?", vbQuestion & vbYesNo, "Meldung")

        If antwort <> vbYes Then
            e.Cancel = vbCancel
            Exit Sub
        End If

    End Sub

    Private Sub DataGridÜbersetzungen_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridÜbersetzungen.UserDeletedRow
        Insert_sprachkombinationen()
    End Sub

    Private Sub HeaderLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeaderLanguage.SelectedIndexChanged
        Dim bs As BindingSource

        bs = HeaderLanguage.DataSource
        If Not bs Is Nothing Then
            bs.EndEdit()
        End If
    End Sub

    Private Sub AlleFormateGleichBT_Click(sender As Object, e As EventArgs)
        Dim temppos As Integer
        Dim z As Integer
        Dim drta As DataRow 'Tabellen Zeile
        Dim dta As DataTable 'Tabellen tabelle

        'macht nur Sinn wenn mehr als 2 Formate vorhanden sind
        If ListBoxFormate.Items.Count <= 1 Then
            MsgBox("Keine oder zu wenige Formate zum abgleichen vorhanden", vbOKOnly, "Meldung")
            Exit Sub
        End If

        'wenn kein Format ausgewählt ist, dann können keine Werte übertragen werden
        If ListBoxFormate.SelectedIndex = -1 Then
            MsgBox("Sie haben kein Format gewählt von dem die Werte übernommen werden sollen", vbOKOnly, "Meldung")
            Exit Sub
        End If

        'aktuell gewähltes Format
        temppos = ListBoxFormate.SelectedIndex

        'Tabelleattribute vom aktuellen Format holen
        dta = Data.Tables("TabellenAttribute")
        drta = dta.Rows(temppos)

        'Die Formatliste durchlaufen
        For z = 0 To ListBoxFormate.Items.Count - 1
            'wenn es sich nicht um das aktuell gewählte Format handelt
            If z <> temppos Then
                'Werte der aktuellen Tabellenattribute übertragen
                dta.Rows(z).ItemArray = drta.ItemArray.Clone()
            End If
        Next
    End Sub

    Private Sub CB_Spalte1_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte1.CheckedChanged
        SetSpaltenFarbe("CB_Spalte1", CB_Spalte1.Checked)
    End Sub

    Private Sub CB_Spalte2_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte2.CheckedChanged
        SetSpaltenFarbe("CB_Spalte2", CB_Spalte2.Checked)
    End Sub

    Private Sub CB_Spalte3_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte3.CheckedChanged
        SetSpaltenFarbe("CB_Spalte3", CB_Spalte3.Checked)
    End Sub

    Private Sub CB_Spalte4_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte4.CheckedChanged
        SetSpaltenFarbe("CB_Spalte4", CB_Spalte4.Checked)
    End Sub

    Private Sub CB_Spalte5_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte5.CheckedChanged
        SetSpaltenFarbe("CB_Spalte5", CB_Spalte5.Checked)
    End Sub

    Private Sub CB_Spalte6_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte6.CheckedChanged
        SetSpaltenFarbe("CB_Spalte6", CB_Spalte6.Checked)
    End Sub

    Private Sub CB_Spalte7_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte7.CheckedChanged
        SetSpaltenFarbe("CB_Spalte7", CB_Spalte7.Checked)
    End Sub

    Private Sub CB_Spalte8_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte8.CheckedChanged
        SetSpaltenFarbe("CB_Spalte8", CB_Spalte8.Checked)
    End Sub

    Private Sub CB_Spalte9_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte9.CheckedChanged
        SetSpaltenFarbe("CB_Spalte9", CB_Spalte9.Checked)
    End Sub

    Private Sub CB_Spalte10_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Spalte10.CheckedChanged
        SetSpaltenFarbe("CB_Spalte10", CB_Spalte10.Checked)
    End Sub

    Private Sub CB_AutomatischeSpaltenBreite_CheckedChanged(sender As Object, e As EventArgs)
        If CB_AutomatischeSpaltenBreite.Checked Then
            BreiteSpalte1.Enabled = False
            BreiteSpalte2.Enabled = False
            BreiteSpalte3.Enabled = False
            BreiteSpalte4.Enabled = False
        Else
            BreiteSpalte1.Enabled = True
            BreiteSpalte2.Enabled = True
            BreiteSpalte3.Enabled = True
            BreiteSpalte4.Enabled = True
        End If
    End Sub

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


    Private Sub NurAufErstemBlatt_CheckedChanged(sender As Object, e As EventArgs) Handles NurAufErstemBlatt.CheckedChanged
        If Not NurAufErstemBlatt.Checked And LöschenAufRestlichenBlättern.Checked Then
            MsgBox("Achtung: durch diese Kombination" & Chr(10) _
             & "(nur auf erstem Blatt nein UND auf restlichen Blättern löschen ja)" & Chr(10) _
             & "wird auf keinem Baltt die Passungstabelle eingefügt")
        End If
    End Sub

    Private Sub LöschenAufRestlichenBlättern_CheckedChanged(sender As Object, e As EventArgs) Handles LöschenAufRestlichenBlättern.CheckedChanged
        If Not NurAufErstemBlatt.Checked And LöschenAufRestlichenBlättern.Checked Then
            MsgBox("Achtung: durch diese Kombination" & Chr(10) _
             & "(nur auf erstem Blatt nein UND auf restlichen Blättern löschen ja)" & Chr(10) _
             & "wird auf keinem Baltt die Passungstabelle eingefügt")
        End If
    End Sub

    Private Sub CB_AutomatischeSpaltenBreite_CheckedChanged_1(sender As Object, e As EventArgs) Handles CB_AutomatischeSpaltenBreite.CheckedChanged
        If CB_AutomatischeSpaltenBreite.Checked Then
            BreiteSpalte1.Enabled = False
            BreiteSpalte2.Enabled = False
            BreiteSpalte3.Enabled = False
            BreiteSpalte4.Enabled = False
            BreiteSpalte5.Enabled = False
            BreiteSpalte6.Enabled = False
            BreiteSpalte7.Enabled = False
            BreiteSpalte8.Enabled = False
            BreiteSpalte9.Enabled = False
            BreiteSpalte10.Enabled = False
        Else
            BreiteSpalte1.Enabled = True
            BreiteSpalte2.Enabled = True
            BreiteSpalte3.Enabled = True
            BreiteSpalte4.Enabled = True
            BreiteSpalte5.Enabled = True
            BreiteSpalte6.Enabled = True
            BreiteSpalte7.Enabled = True
            BreiteSpalte8.Enabled = True
            BreiteSpalte9.Enabled = True
            BreiteSpalte10.Enabled = True
        End If
    End Sub

    Private Sub SchichtStärkeKeine_CheckedChanged(sender As Object, e As EventArgs) Handles SchichtStärkeKeine.CheckedChanged
        If SchichtStärkeKeine.Checked Then
            Schichtstärke.Enabled = False
        Else
            Schichtstärke.Enabled = True
        End If
    End Sub

    Private Sub SchichtStärkeFix_CheckedChanged(sender As Object, e As EventArgs) Handles SchichtStärkeFix.CheckedChanged
        If SchichtStärkeFix.Checked Then
            Schichtstärke.Enabled = True
        Else
            Schichtstärke.Enabled = False
        End If
    End Sub

    Private Sub AlleFormateGleichBT_Click_1(sender As Object, e As EventArgs) Handles AlleFormateGleichBT.Click
        Dim TempPos As Integer = -1
        Dim dt As DataTable = New DataTable()

        dt = TabellenAttributeBindingSource.DataSource.tables("TabellenAttribute")
        For TempPos = 0 To ListBoxFormate.Items.Count - 1
            For c = 0 To dt.Columns.Count - 1
                If TempPos <> Pos Then
                    If dt.Columns(c).ToString <> "Tabelle_Id" Then
                        dt.Rows(TempPos)(dt.Columns(c).ToString) = dt.Rows(Pos)(dt.Columns(c))
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub AbmessungenVomBlatt_Click(sender As Object, e As EventArgs) Handles AbmessungenVomBlatt.Click
        Dim prop As New Definitionen.BlattEigenschaften

        prop = GetSheetProperties()

        If prop.Eigenschaften Is Nothing Then
            MsgBox("Keine Format gefunden", vbOKOnly, "Meldung")
            Exit Sub
        Else
            Breite.Text = prop.Eigenschaften(5) * 1000.0
            Höhe.Text = prop.Eigenschaften(6) * 1000.0
        End If
    End Sub

    Private Sub ListBoxFormate_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxFormate.DoubleClick
        Dim DlgRename As New RenameFormat
        Dim antwort As Integer = 0
        Dim dta As DataTable 'Formate tabelle

        DlgRename.FormatName.Text = ListBoxFormate.Items(ListBoxFormate.SelectedIndex)("Formatname")

        antwort = DlgRename.ShowDialog

        If antwort = vbCancel Then
            Exit Sub
        End If

        For i = 0 To ListBoxFormate.Items.Count - 1
            If ListBoxFormate.Items(i).ToString.ToUpper = DlgRename.FormatName.Text.ToUpper Then
                MsgBox("Dieser Formatname existiert bereits", vbOKOnly, "Meldung")
                Exit Sub
            End If
        Next

        'Formate Tabelle
        dta = Data.Tables("Format")
        dta.Rows(ListBoxFormate.SelectedIndex)("Formatname") = DlgRename.FormatName.Text
        dta = Nothing
    End Sub
    Private Function WriteAccess(Pfad As String) As Boolean
        Dim fs As FileStream
        Dim zugriff As Boolean = False

        If File.Exists(Pfad) Then
            Try
                fs = New FileStream(Pfad, FileMode.Append, FileAccess.Write)
                fs.Close()
                WriteAccess = True
                Exit Function
            Catch ex As Exception
                WriteAccess = False
                Exit Function
            End Try
        Else
            WriteAccess = False
        End If
    End Function

    Private Function CreateAccess(Pfad As String) As Boolean
        Dim fs As FileStream
        Dim zugriff As Boolean = False

        If File.Exists(Pfad) Then
            Try
                fs = New FileStream(Pfad, FileMode.Create, FileAccess.Write)
                fs.Close()
                File.Delete(Pfad)
                CreateAccess = True
                Exit Function
            Catch ex As Exception
                CreateAccess = False
                Exit Function
            End Try
        Else
            CreateAccess = False
        End If
    End Function

    Private Function ReadAccess(Pfad As String) As Boolean
        Dim fs As FileStream
        Dim zugriff As Boolean = False

        If File.Exists(Pfad) Then
            Try
                fs = New FileStream(Pfad, FileMode.Create, FileAccess.Write)
                fs.Close()
                ReadAccess = True
                Exit Function
            Catch ex As Exception
                ReadAccess = False
                Exit Function
            End Try
        Else
            ReadAccess = False
        End If
    End Function

End Class
