<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SetupDialog
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupDialog))
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DataGridÜbersetzungen = New System.Windows.Forms.DataGridView()
        Me.KürzelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SpracheBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Data = New Passungstabellen.Data()
        Me.Maß = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PassungDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaßePassung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToleranzDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AbmaßDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VorbearbeitungsAbmaßeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ÜbersetzungenIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ÜbersetzungBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.AlleFormateGleichBT = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.HeaderLanguage = New System.Windows.Forms.ComboBox()
        Me.TabellenAttributeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SprachkombinationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.KursivKopfZeile = New System.Windows.Forms.CheckBox()
        Me.FettKopfZeile = New System.Windows.Forms.CheckBox()
        Me.FarbeKopfZeile = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DurchgestrichenKopfZeile = New System.Windows.Forms.CheckBox()
        Me.UnterstrichenKopfZeile = New System.Windows.Forms.CheckBox()
        Me.TexthöheKopfZeile = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.SchriftstilKopfZeile = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.SchriftartKopfZeile = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Zeilenparameter = New System.Windows.Forms.GroupBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.KursivZeile = New System.Windows.Forms.CheckBox()
        Me.FettZeile = New System.Windows.Forms.CheckBox()
        Me.FarbeZeile = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DurchgestrichenZeile = New System.Windows.Forms.CheckBox()
        Me.UnterstrichenZeile = New System.Windows.Forms.CheckBox()
        Me.TexthöheZeile = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SchriftstilZeile = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.SchriftartZeile = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.HeaderGRP = New System.Windows.Forms.GroupBox()
        Me.HeaderUnten = New System.Windows.Forms.RadioButton()
        Me.HeaderOben = New System.Windows.Forms.RadioButton()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.RasterStrichStärke = New System.Windows.Forms.ComboBox()
        Me.RasterLinien = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.RahmenStrichStärke = New System.Windows.Forms.ComboBox()
        Me.RahmenLinien = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabellenZeilenBT = New System.Windows.Forms.Button()
        Me.TabellenKopfZeileBT = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Offset_Y = New System.Windows.Forms.TextBox()
        Me.FormatAttributeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Offset_X = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.EinfügepunktGRP = New System.Windows.Forms.GroupBox()
        Me.Einfügepunkt_RU = New System.Windows.Forms.RadioButton()
        Me.Einfügepunkt_LU = New System.Windows.Forms.RadioButton()
        Me.Einfügepunkt_RO = New System.Windows.Forms.RadioButton()
        Me.Einfügepunkt_LO = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AbmessungenVomBlatt = New System.Windows.Forms.Button()
        Me.Höhe = New System.Windows.Forms.TextBox()
        Me.Breite = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBoxFormate = New System.Windows.Forms.ListBox()
        Me.FormatBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GenerelleAttributeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Schichtstärke = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.NurAufErstemBlatt = New System.Windows.Forms.CheckBox()
        Me.AnsichtsTypBaugruppen = New System.Windows.Forms.CheckBox()
        Me.AnsichtsTypTeile = New System.Windows.Forms.CheckBox()
        Me.AnsichtsTypSkizzen = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ReaktionAufLeerePassung = New System.Windows.Forms.CheckBox()
        Me.LöschenAufRestlichenBlättern = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RundenAuf = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LogDatei = New System.Windows.Forms.CheckBox()
        Me.Fehlermeldung = New System.Windows.Forms.CheckBox()
        Me.NeuPositionieren = New System.Windows.Forms.CheckBox()
        Me.PlusZeichen = New System.Windows.Forms.CheckBox()
        Me.SchichtStärkeAbfragenGrp = New System.Windows.Forms.GroupBox()
        Me.SchichtStärkeFix = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.SchichtStärkeKeine = New System.Windows.Forms.RadioButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.BreiteSpalte8 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BreiteSpalte7 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.BreiteSpalte6 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.BreiteSpalte5 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CB_AutomatischeSpaltenBreite = New System.Windows.Forms.CheckBox()
        Me.BreiteSpalte4 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BreiteSpalte3 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BreiteSpalte2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.BreiteSpalte1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.CB_Spalte8 = New System.Windows.Forms.CheckBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.CB_Spalte7 = New System.Windows.Forms.CheckBox()
        Me.CB_Spalte6 = New System.Windows.Forms.CheckBox()
        Me.CB_Spalte5 = New System.Windows.Forms.CheckBox()
        Me.CB_Spalte4 = New System.Windows.Forms.CheckBox()
        Me.CB_Spalte3 = New System.Windows.Forms.CheckBox()
        Me.CB_Spalte2 = New System.Windows.Forms.CheckBox()
        Me.CB_Spalte1 = New System.Windows.Forms.CheckBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatLab1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage4.SuspendLayout()
        CType(Me.DataGridÜbersetzungen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpracheBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Data, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ÜbersetzungBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.TabellenAttributeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SprachkombinationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        Me.Zeilenparameter.SuspendLayout()
        Me.HeaderGRP.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.RasterLinien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RahmenLinien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.FormatAttributeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EinfügepunktGRP.SuspendLayout()
        CType(Me.FormatBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.GenerelleAttributeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SchichtStärkeAbfragenGrp.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(554, 440)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Sichern"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(627, 440)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Abbrechen"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.Controls.Add(Me.DataGridÜbersetzungen)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(677, 393)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Sprache"
        '
        'DataGridÜbersetzungen
        '
        Me.DataGridÜbersetzungen.AutoGenerateColumns = False
        Me.DataGridÜbersetzungen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridÜbersetzungen.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.KürzelDataGridViewTextBoxColumn, Me.Maß, Me.PassungDataGridViewTextBoxColumn, Me.MaßePassung, Me.ToleranzDataGridViewTextBoxColumn, Me.AbmaßDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn1, Me.VorbearbeitungsAbmaßeDataGridViewTextBoxColumn, Me.VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn, Me.ÜbersetzungenIdDataGridViewTextBoxColumn})
        Me.DataGridÜbersetzungen.DataSource = Me.ÜbersetzungBindingSource
        Me.DataGridÜbersetzungen.Location = New System.Drawing.Point(16, 18)
        Me.DataGridÜbersetzungen.Name = "DataGridÜbersetzungen"
        Me.DataGridÜbersetzungen.Size = New System.Drawing.Size(646, 247)
        Me.DataGridÜbersetzungen.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.DataGridÜbersetzungen, "mit rechts-Klick können Sie Daten " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "hinzufügen, ändern oder löschen")
        '
        'KürzelDataGridViewTextBoxColumn
        '
        Me.KürzelDataGridViewTextBoxColumn.DataPropertyName = "Kürzel"
        Me.KürzelDataGridViewTextBoxColumn.DataSource = Me.SpracheBindingSource
        Me.KürzelDataGridViewTextBoxColumn.DisplayMember = "Kürzel"
        Me.KürzelDataGridViewTextBoxColumn.HeaderText = "Kürzel"
        Me.KürzelDataGridViewTextBoxColumn.Name = "KürzelDataGridViewTextBoxColumn"
        Me.KürzelDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.KürzelDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.KürzelDataGridViewTextBoxColumn.ValueMember = "Kürzel"
        '
        'SpracheBindingSource
        '
        Me.SpracheBindingSource.DataMember = "Sprache"
        Me.SpracheBindingSource.DataSource = Me.Data
        '
        'Data
        '
        Me.Data.DataSetName = "Data"
        Me.Data.Locale = New System.Globalization.CultureInfo("en-US")
        Me.Data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Maß
        '
        Me.Maß.DataPropertyName = "Maß"
        Me.Maß.HeaderText = "Maß"
        Me.Maß.Name = "Maß"
        '
        'PassungDataGridViewTextBoxColumn
        '
        Me.PassungDataGridViewTextBoxColumn.DataPropertyName = "Passung"
        Me.PassungDataGridViewTextBoxColumn.HeaderText = "Passung"
        Me.PassungDataGridViewTextBoxColumn.Name = "PassungDataGridViewTextBoxColumn"
        '
        'MaßePassung
        '
        Me.MaßePassung.DataPropertyName = "MaßePassung"
        Me.MaßePassung.HeaderText = "MaßePassung"
        Me.MaßePassung.Name = "MaßePassung"
        '
        'ToleranzDataGridViewTextBoxColumn
        '
        Me.ToleranzDataGridViewTextBoxColumn.DataPropertyName = "Toleranz"
        Me.ToleranzDataGridViewTextBoxColumn.HeaderText = "Toleranz"
        Me.ToleranzDataGridViewTextBoxColumn.Name = "ToleranzDataGridViewTextBoxColumn"
        '
        'AbmaßDataGridViewTextBoxColumn
        '
        Me.AbmaßDataGridViewTextBoxColumn.DataPropertyName = "Abmaß"
        Me.AbmaßDataGridViewTextBoxColumn.HeaderText = "Abmaß"
        Me.AbmaßDataGridViewTextBoxColumn.Name = "AbmaßDataGridViewTextBoxColumn"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "AbmaßToleranzMitte"
        Me.DataGridViewTextBoxColumn1.HeaderText = "AbmaßToleranzMitte"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'VorbearbeitungsAbmaßeDataGridViewTextBoxColumn
        '
        Me.VorbearbeitungsAbmaßeDataGridViewTextBoxColumn.DataPropertyName = "VorbearbeitungsAbmaße"
        Me.VorbearbeitungsAbmaßeDataGridViewTextBoxColumn.HeaderText = "VorbearbeitungsAbmaße"
        Me.VorbearbeitungsAbmaßeDataGridViewTextBoxColumn.Name = "VorbearbeitungsAbmaßeDataGridViewTextBoxColumn"
        '
        'VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn
        '
        Me.VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn.DataPropertyName = "VorbearbeitungsToleranzMitte"
        Me.VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn.HeaderText = "VorbearbeitungsToleranzMitte"
        Me.VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn.Name = "VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn"
        '
        'ÜbersetzungenIdDataGridViewTextBoxColumn
        '
        Me.ÜbersetzungenIdDataGridViewTextBoxColumn.DataPropertyName = "Übersetzungen_Id"
        Me.ÜbersetzungenIdDataGridViewTextBoxColumn.HeaderText = "Übersetzungen_Id"
        Me.ÜbersetzungenIdDataGridViewTextBoxColumn.Name = "ÜbersetzungenIdDataGridViewTextBoxColumn"
        Me.ÜbersetzungenIdDataGridViewTextBoxColumn.Visible = False
        '
        'ÜbersetzungBindingSource
        '
        Me.ÜbersetzungBindingSource.DataMember = "Übersetzung"
        Me.ÜbersetzungBindingSource.DataSource = Me.Data
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.AlleFormateGleichBT)
        Me.TabPage3.Controls.Add(Me.Label32)
        Me.TabPage3.Controls.Add(Me.HeaderLanguage)
        Me.TabPage3.Controls.Add(Me.GroupBox12)
        Me.TabPage3.Controls.Add(Me.Zeilenparameter)
        Me.TabPage3.Controls.Add(Me.HeaderGRP)
        Me.TabPage3.Controls.Add(Me.GroupBox8)
        Me.TabPage3.Controls.Add(Me.TabellenZeilenBT)
        Me.TabPage3.Controls.Add(Me.TabellenKopfZeileBT)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(677, 393)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tabelleneinstellungen"
        '
        'AlleFormateGleichBT
        '
        Me.AlleFormateGleichBT.Location = New System.Drawing.Point(17, 224)
        Me.AlleFormateGleichBT.Name = "AlleFormateGleichBT"
        Me.AlleFormateGleichBT.Size = New System.Drawing.Size(172, 32)
        Me.AlleFormateGleichBT.TabIndex = 27
        Me.AlleFormateGleichBT.Text = "Alle Formate gleich"
        Me.ToolTip1.SetToolTip(Me.AlleFormateGleichBT, resources.GetString("AlleFormateGleichBT.ToolTip"))
        Me.AlleFormateGleichBT.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(19, 166)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(144, 13)
        Me.Label32.TabIndex = 26
        Me.Label32.Text = "Spracheinstellung für Tabelle"
        '
        'HeaderLanguage
        '
        Me.HeaderLanguage.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TabellenAttributeBindingSource, "HeaderLanguage", True))
        Me.HeaderLanguage.DataSource = Me.SprachkombinationBindingSource
        Me.HeaderLanguage.DisplayMember = "Name"
        Me.HeaderLanguage.FormattingEnabled = True
        Me.HeaderLanguage.Location = New System.Drawing.Point(17, 188)
        Me.HeaderLanguage.Name = "HeaderLanguage"
        Me.HeaderLanguage.Size = New System.Drawing.Size(140, 21)
        Me.HeaderLanguage.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.HeaderLanguage, "gibt an welche Sprache oder Sprachkombination" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in der Passungstabelle verwendet w" &
        "ird")
        Me.HeaderLanguage.ValueMember = "Name"
        '
        'TabellenAttributeBindingSource
        '
        Me.TabellenAttributeBindingSource.DataMember = "TabellenAttribute"
        Me.TabellenAttributeBindingSource.DataSource = Me.Data
        '
        'SprachkombinationBindingSource
        '
        Me.SprachkombinationBindingSource.DataMember = "Sprachkombination"
        Me.SprachkombinationBindingSource.DataSource = Me.Data
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label33)
        Me.GroupBox12.Controls.Add(Me.KursivKopfZeile)
        Me.GroupBox12.Controls.Add(Me.FettKopfZeile)
        Me.GroupBox12.Controls.Add(Me.FarbeKopfZeile)
        Me.GroupBox12.Controls.Add(Me.Label28)
        Me.GroupBox12.Controls.Add(Me.DurchgestrichenKopfZeile)
        Me.GroupBox12.Controls.Add(Me.UnterstrichenKopfZeile)
        Me.GroupBox12.Controls.Add(Me.TexthöheKopfZeile)
        Me.GroupBox12.Controls.Add(Me.Label29)
        Me.GroupBox12.Controls.Add(Me.SchriftstilKopfZeile)
        Me.GroupBox12.Controls.Add(Me.Label30)
        Me.GroupBox12.Controls.Add(Me.SchriftartKopfZeile)
        Me.GroupBox12.Controls.Add(Me.Label31)
        Me.GroupBox12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.GroupBox12.Location = New System.Drawing.Point(323, 245)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(290, 145)
        Me.GroupBox12.TabIndex = 21
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Kopfzeilenparameter"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(131, 76)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(23, 13)
        Me.Label33.TabIndex = 28
        Me.Label33.Text = "mm"
        '
        'KursivKopfZeile
        '
        Me.KursivKopfZeile.AutoSize = True
        Me.KursivKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "KursivKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KursivKopfZeile.Enabled = False
        Me.KursivKopfZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.KursivKopfZeile.Location = New System.Drawing.Point(174, 118)
        Me.KursivKopfZeile.Name = "KursivKopfZeile"
        Me.KursivKopfZeile.Size = New System.Drawing.Size(55, 17)
        Me.KursivKopfZeile.TabIndex = 27
        Me.KursivKopfZeile.Text = "Kursiv"
        Me.KursivKopfZeile.UseVisualStyleBackColor = True
        '
        'FettKopfZeile
        '
        Me.FettKopfZeile.AutoSize = True
        Me.FettKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "FettKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FettKopfZeile.Enabled = False
        Me.FettKopfZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FettKopfZeile.Location = New System.Drawing.Point(175, 95)
        Me.FettKopfZeile.Name = "FettKopfZeile"
        Me.FettKopfZeile.Size = New System.Drawing.Size(44, 17)
        Me.FettKopfZeile.TabIndex = 26
        Me.FettKopfZeile.Text = "Fett"
        Me.FettKopfZeile.UseVisualStyleBackColor = True
        '
        'FarbeKopfZeile
        '
        Me.FarbeKopfZeile.BackColor = System.Drawing.Color.Black
        Me.FarbeKopfZeile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FarbeKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "FarbeKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FarbeKopfZeile.Location = New System.Drawing.Point(73, 97)
        Me.FarbeKopfZeile.Name = "FarbeKopfZeile"
        Me.FarbeKopfZeile.ReadOnly = True
        Me.FarbeKopfZeile.Size = New System.Drawing.Size(53, 20)
        Me.FarbeKopfZeile.TabIndex = 25
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label28.Location = New System.Drawing.Point(34, 100)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(34, 13)
        Me.Label28.TabIndex = 24
        Me.Label28.Text = "Farbe"
        '
        'DurchgestrichenKopfZeile
        '
        Me.DurchgestrichenKopfZeile.AutoSize = True
        Me.DurchgestrichenKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TabellenAttributeBindingSource, "DurchgestrichenKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DurchgestrichenKopfZeile.Enabled = False
        Me.DurchgestrichenKopfZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DurchgestrichenKopfZeile.Location = New System.Drawing.Point(175, 73)
        Me.DurchgestrichenKopfZeile.Name = "DurchgestrichenKopfZeile"
        Me.DurchgestrichenKopfZeile.Size = New System.Drawing.Size(104, 17)
        Me.DurchgestrichenKopfZeile.TabIndex = 23
        Me.DurchgestrichenKopfZeile.Text = "Durchgestrichen"
        Me.DurchgestrichenKopfZeile.UseVisualStyleBackColor = True
        '
        'UnterstrichenKopfZeile
        '
        Me.UnterstrichenKopfZeile.AutoSize = True
        Me.UnterstrichenKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TabellenAttributeBindingSource, "UnterstrichenKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.UnterstrichenKopfZeile.Enabled = False
        Me.UnterstrichenKopfZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UnterstrichenKopfZeile.Location = New System.Drawing.Point(175, 51)
        Me.UnterstrichenKopfZeile.Name = "UnterstrichenKopfZeile"
        Me.UnterstrichenKopfZeile.Size = New System.Drawing.Size(89, 17)
        Me.UnterstrichenKopfZeile.TabIndex = 22
        Me.UnterstrichenKopfZeile.Text = "Unterstrichen"
        Me.UnterstrichenKopfZeile.UseVisualStyleBackColor = True
        '
        'TexthöheKopfZeile
        '
        Me.TexthöheKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "TexthöheKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TexthöheKopfZeile.Location = New System.Drawing.Point(74, 73)
        Me.TexthöheKopfZeile.Name = "TexthöheKopfZeile"
        Me.TexthöheKopfZeile.Size = New System.Drawing.Size(52, 20)
        Me.TexthöheKopfZeile.TabIndex = 21
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(7, 76)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(61, 13)
        Me.Label29.TabIndex = 20
        Me.Label29.Text = "Schrifthöhe"
        '
        'SchriftstilKopfZeile
        '
        Me.SchriftstilKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "SchriftstilKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SchriftstilKopfZeile.Enabled = False
        Me.SchriftstilKopfZeile.Location = New System.Drawing.Point(74, 48)
        Me.SchriftstilKopfZeile.Name = "SchriftstilKopfZeile"
        Me.SchriftstilKopfZeile.Size = New System.Drawing.Size(80, 20)
        Me.SchriftstilKopfZeile.TabIndex = 19
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label30.Location = New System.Drawing.Point(7, 51)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(46, 13)
        Me.Label30.TabIndex = 18
        Me.Label30.Text = "Schrifstil"
        '
        'SchriftartKopfZeile
        '
        Me.SchriftartKopfZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "SchriftartKopfZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SchriftartKopfZeile.Enabled = False
        Me.SchriftartKopfZeile.Location = New System.Drawing.Point(74, 25)
        Me.SchriftartKopfZeile.Name = "SchriftartKopfZeile"
        Me.SchriftartKopfZeile.Size = New System.Drawing.Size(205, 20)
        Me.SchriftartKopfZeile.TabIndex = 17
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label31.Location = New System.Drawing.Point(7, 28)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(46, 13)
        Me.Label31.TabIndex = 16
        Me.Label31.Text = "Schrifart"
        '
        'Zeilenparameter
        '
        Me.Zeilenparameter.Controls.Add(Me.Label34)
        Me.Zeilenparameter.Controls.Add(Me.KursivZeile)
        Me.Zeilenparameter.Controls.Add(Me.FettZeile)
        Me.Zeilenparameter.Controls.Add(Me.FarbeZeile)
        Me.Zeilenparameter.Controls.Add(Me.Label27)
        Me.Zeilenparameter.Controls.Add(Me.DurchgestrichenZeile)
        Me.Zeilenparameter.Controls.Add(Me.UnterstrichenZeile)
        Me.Zeilenparameter.Controls.Add(Me.TexthöheZeile)
        Me.Zeilenparameter.Controls.Add(Me.Label24)
        Me.Zeilenparameter.Controls.Add(Me.SchriftstilZeile)
        Me.Zeilenparameter.Controls.Add(Me.Label25)
        Me.Zeilenparameter.Controls.Add(Me.SchriftartZeile)
        Me.Zeilenparameter.Controls.Add(Me.Label26)
        Me.Zeilenparameter.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Zeilenparameter.Location = New System.Drawing.Point(323, 54)
        Me.Zeilenparameter.Name = "Zeilenparameter"
        Me.Zeilenparameter.Size = New System.Drawing.Size(290, 141)
        Me.Zeilenparameter.TabIndex = 20
        Me.Zeilenparameter.TabStop = False
        Me.Zeilenparameter.Text = "Zeilenparameter"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(131, 77)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(23, 13)
        Me.Label34.TabIndex = 29
        Me.Label34.Text = "mm"
        '
        'KursivZeile
        '
        Me.KursivZeile.AutoSize = True
        Me.KursivZeile.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "KursivZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KursivZeile.Enabled = False
        Me.KursivZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.KursivZeile.Location = New System.Drawing.Point(174, 118)
        Me.KursivZeile.Name = "KursivZeile"
        Me.KursivZeile.Size = New System.Drawing.Size(55, 17)
        Me.KursivZeile.TabIndex = 27
        Me.KursivZeile.Text = "Kursiv"
        Me.KursivZeile.UseVisualStyleBackColor = True
        '
        'FettZeile
        '
        Me.FettZeile.AutoSize = True
        Me.FettZeile.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "FettZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FettZeile.Enabled = False
        Me.FettZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FettZeile.Location = New System.Drawing.Point(174, 95)
        Me.FettZeile.Name = "FettZeile"
        Me.FettZeile.Size = New System.Drawing.Size(44, 17)
        Me.FettZeile.TabIndex = 26
        Me.FettZeile.Text = "Fett"
        Me.FettZeile.UseVisualStyleBackColor = True
        '
        'FarbeZeile
        '
        Me.FarbeZeile.BackColor = System.Drawing.Color.Black
        Me.FarbeZeile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FarbeZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "FarbeZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FarbeZeile.ForeColor = System.Drawing.Color.Black
        Me.FarbeZeile.Location = New System.Drawing.Point(73, 97)
        Me.FarbeZeile.Name = "FarbeZeile"
        Me.FarbeZeile.ReadOnly = True
        Me.FarbeZeile.Size = New System.Drawing.Size(53, 20)
        Me.FarbeZeile.TabIndex = 25
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label27.Location = New System.Drawing.Point(34, 100)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "Farbe"
        '
        'DurchgestrichenZeile
        '
        Me.DurchgestrichenZeile.AutoSize = True
        Me.DurchgestrichenZeile.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TabellenAttributeBindingSource, "DurchgestrichenZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DurchgestrichenZeile.Enabled = False
        Me.DurchgestrichenZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DurchgestrichenZeile.Location = New System.Drawing.Point(174, 73)
        Me.DurchgestrichenZeile.Name = "DurchgestrichenZeile"
        Me.DurchgestrichenZeile.Size = New System.Drawing.Size(104, 17)
        Me.DurchgestrichenZeile.TabIndex = 23
        Me.DurchgestrichenZeile.Text = "Durchgestrichen"
        Me.DurchgestrichenZeile.UseVisualStyleBackColor = True
        '
        'UnterstrichenZeile
        '
        Me.UnterstrichenZeile.AutoSize = True
        Me.UnterstrichenZeile.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.TabellenAttributeBindingSource, "UnterstrichenZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.UnterstrichenZeile.Enabled = False
        Me.UnterstrichenZeile.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UnterstrichenZeile.Location = New System.Drawing.Point(174, 51)
        Me.UnterstrichenZeile.Name = "UnterstrichenZeile"
        Me.UnterstrichenZeile.Size = New System.Drawing.Size(89, 17)
        Me.UnterstrichenZeile.TabIndex = 22
        Me.UnterstrichenZeile.Text = "Unterstrichen"
        Me.UnterstrichenZeile.UseVisualStyleBackColor = True
        '
        'TexthöheZeile
        '
        Me.TexthöheZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "TexthöheZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TexthöheZeile.Location = New System.Drawing.Point(74, 73)
        Me.TexthöheZeile.Name = "TexthöheZeile"
        Me.TexthöheZeile.Size = New System.Drawing.Size(52, 20)
        Me.TexthöheZeile.TabIndex = 21
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(7, 76)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(61, 13)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "Schrifthöhe"
        '
        'SchriftstilZeile
        '
        Me.SchriftstilZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "SchriftstilZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SchriftstilZeile.Enabled = False
        Me.SchriftstilZeile.Location = New System.Drawing.Point(74, 48)
        Me.SchriftstilZeile.Name = "SchriftstilZeile"
        Me.SchriftstilZeile.Size = New System.Drawing.Size(80, 20)
        Me.SchriftstilZeile.TabIndex = 19
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label25.Location = New System.Drawing.Point(7, 51)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 13)
        Me.Label25.TabIndex = 18
        Me.Label25.Text = "Schrifstil"
        '
        'SchriftartZeile
        '
        Me.SchriftartZeile.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "SchriftartZeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SchriftartZeile.Enabled = False
        Me.SchriftartZeile.Location = New System.Drawing.Point(74, 25)
        Me.SchriftartZeile.Name = "SchriftartZeile"
        Me.SchriftartZeile.Size = New System.Drawing.Size(204, 20)
        Me.SchriftartZeile.TabIndex = 17
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label26.Location = New System.Drawing.Point(7, 28)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(46, 13)
        Me.Label26.TabIndex = 16
        Me.Label26.Text = "Schrifart"
        '
        'HeaderGRP
        '
        Me.HeaderGRP.Controls.Add(Me.HeaderUnten)
        Me.HeaderGRP.Controls.Add(Me.HeaderOben)
        Me.HeaderGRP.Location = New System.Drawing.Point(151, 18)
        Me.HeaderGRP.Name = "HeaderGRP"
        Me.HeaderGRP.Size = New System.Drawing.Size(84, 72)
        Me.HeaderGRP.TabIndex = 17
        Me.HeaderGRP.TabStop = False
        Me.HeaderGRP.Text = "Überschrift"
        '
        'HeaderUnten
        '
        Me.HeaderUnten.AutoSize = True
        Me.HeaderUnten.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "HeaderUnten", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HeaderUnten.Location = New System.Drawing.Point(7, 43)
        Me.HeaderUnten.Name = "HeaderUnten"
        Me.HeaderUnten.Size = New System.Drawing.Size(52, 17)
        Me.HeaderUnten.TabIndex = 1
        Me.HeaderUnten.TabStop = True
        Me.HeaderUnten.Text = "unten"
        Me.ToolTip1.SetToolTip(Me.HeaderUnten, "die Überschrift erscheint als Fußzeile")
        Me.HeaderUnten.UseVisualStyleBackColor = True
        '
        'HeaderOben
        '
        Me.HeaderOben.AutoSize = True
        Me.HeaderOben.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "HeaderOben", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.HeaderOben.Location = New System.Drawing.Point(7, 20)
        Me.HeaderOben.Name = "HeaderOben"
        Me.HeaderOben.Size = New System.Drawing.Size(49, 17)
        Me.HeaderOben.TabIndex = 0
        Me.HeaderOben.TabStop = True
        Me.HeaderOben.Text = "oben"
        Me.ToolTip1.SetToolTip(Me.HeaderOben, "die Überschrift erscheint als Kopfzeile")
        Me.HeaderOben.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label15)
        Me.GroupBox8.Controls.Add(Me.RasterStrichStärke)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.RahmenStrichStärke)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 18)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(120, 128)
        Me.GroupBox8.TabIndex = 16
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Tabellenlinien"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Gitter"
        '
        'RasterStrichStärke
        '
        Me.RasterStrichStärke.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TabellenAttributeBindingSource, "RasterStrichStärke", True))
        Me.RasterStrichStärke.DataSource = Me.RasterLinien
        Me.RasterStrichStärke.DisplayMember = "Name"
        Me.RasterStrichStärke.FormattingEnabled = True
        Me.RasterStrichStärke.Location = New System.Drawing.Point(6, 89)
        Me.RasterStrichStärke.Name = "RasterStrichStärke"
        Me.RasterStrichStärke.Size = New System.Drawing.Size(98, 21)
        Me.RasterStrichStärke.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.RasterStrichStärke, "definiert die Strichstärke der Rasterlinen")
        Me.RasterStrichStärke.ValueMember = "Name"
        '
        'RasterLinien
        '
        Me.RasterLinien.DataMember = "Linienart"
        Me.RasterLinien.DataSource = Me.Data
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Umrandung"
        '
        'RahmenStrichStärke
        '
        Me.RahmenStrichStärke.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TabellenAttributeBindingSource, "RahmenStrichStärke", True))
        Me.RahmenStrichStärke.DataSource = Me.RahmenLinien
        Me.RahmenStrichStärke.DisplayMember = "Name"
        Me.RahmenStrichStärke.FormattingEnabled = True
        Me.RahmenStrichStärke.Location = New System.Drawing.Point(6, 39)
        Me.RahmenStrichStärke.Name = "RahmenStrichStärke"
        Me.RahmenStrichStärke.Size = New System.Drawing.Size(98, 21)
        Me.RahmenStrichStärke.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.RahmenStrichStärke, "definiert die Strichstärke der Rahmenlinien" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.RahmenStrichStärke.ValueMember = "Name"
        '
        'RahmenLinien
        '
        Me.RahmenLinien.DataMember = "Linienart"
        Me.RahmenLinien.DataSource = Me.Data
        '
        'TabellenZeilenBT
        '
        Me.TabellenZeilenBT.Location = New System.Drawing.Point(323, 10)
        Me.TabellenZeilenBT.Name = "TabellenZeilenBT"
        Me.TabellenZeilenBT.Size = New System.Drawing.Size(134, 38)
        Me.TabellenZeilenBT.TabIndex = 15
        Me.TabellenZeilenBT.Text = "Schrift Tabellenzeilen"
        Me.ToolTip1.SetToolTip(Me.TabellenZeilenBT, "Definiert die Texteinstellungen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "für die Tabellenzeilen")
        Me.TabellenZeilenBT.UseVisualStyleBackColor = True
        '
        'TabellenKopfZeileBT
        '
        Me.TabellenKopfZeileBT.Location = New System.Drawing.Point(323, 201)
        Me.TabellenKopfZeileBT.Name = "TabellenKopfZeileBT"
        Me.TabellenKopfZeileBT.Size = New System.Drawing.Size(134, 38)
        Me.TabellenKopfZeileBT.TabIndex = 14
        Me.TabellenKopfZeileBT.Text = "Schrift Kopfzeile"
        Me.ToolTip1.SetToolTip(Me.TabellenKopfZeileBT, "Definiert die Texteinstellungen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "für die Kopfzeile")
        Me.TabellenKopfZeileBT.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.EinfügepunktGRP)
        Me.TabPage2.Controls.Add(Me.Button3)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.AbmessungenVomBlatt)
        Me.TabPage2.Controls.Add(Me.Höhe)
        Me.TabPage2.Controls.Add(Me.Breite)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.ListBoxFormate)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(677, 393)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Formateinstellungen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Offset_Y)
        Me.GroupBox2.Controls.Add(Me.Offset_X)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(465, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(130, 82)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Einfügepunkt Offset"
        '
        'Offset_Y
        '
        Me.Offset_Y.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormatAttributeBindingSource, "Offset_Y", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Offset_Y.Location = New System.Drawing.Point(34, 45)
        Me.Offset_Y.Name = "Offset_Y"
        Me.Offset_Y.Size = New System.Drawing.Size(60, 20)
        Me.Offset_Y.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.Offset_Y, "Offset in Y-Richtung vom Einfügepunkt in mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "d.h. ist der Einfügepunkt rechts obe" &
        "n und der " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Offset ist 10mm " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wird die Tabelle um 10m weiter unten eingefügt")
        '
        'FormatAttributeBindingSource
        '
        Me.FormatAttributeBindingSource.DataMember = "FormatAttribute"
        Me.FormatAttributeBindingSource.DataSource = Me.Data
        '
        'Offset_X
        '
        Me.Offset_X.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormatAttributeBindingSource, "Offset_X", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Offset_X.Location = New System.Drawing.Point(34, 19)
        Me.Offset_X.Name = "Offset_X"
        Me.Offset_X.Size = New System.Drawing.Size(60, 20)
        Me.Offset_X.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.Offset_X, "Offset in X-Richtung vom Einfügepunkt in mm" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "d.h. ist der Einfügepunkt rechts obe" &
        "n und der " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Offset ist 10mm " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wird die Tabelle um 10m weiter links eingefügt")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(99, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "mm"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(99, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "mm"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Y:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "X:"
        '
        'EinfügepunktGRP
        '
        Me.EinfügepunktGRP.Controls.Add(Me.Einfügepunkt_RU)
        Me.EinfügepunktGRP.Controls.Add(Me.Einfügepunkt_LU)
        Me.EinfügepunktGRP.Controls.Add(Me.Einfügepunkt_RO)
        Me.EinfügepunktGRP.Controls.Add(Me.Einfügepunkt_LO)
        Me.EinfügepunktGRP.Location = New System.Drawing.Point(465, 17)
        Me.EinfügepunktGRP.Name = "EinfügepunktGRP"
        Me.EinfügepunktGRP.Size = New System.Drawing.Size(96, 117)
        Me.EinfügepunktGRP.TabIndex = 17
        Me.EinfügepunktGRP.TabStop = False
        Me.EinfügepunktGRP.Text = "Einfügepunkt"
        '
        'Einfügepunkt_RU
        '
        Me.Einfügepunkt_RU.AutoSize = True
        Me.Einfügepunkt_RU.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.FormatAttributeBindingSource, "EinfügepunktRU", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Einfügepunkt_RU.Location = New System.Drawing.Point(6, 88)
        Me.Einfügepunkt_RU.Name = "Einfügepunkt_RU"
        Me.Einfügepunkt_RU.Size = New System.Drawing.Size(84, 17)
        Me.Einfügepunkt_RU.TabIndex = 3
        Me.Einfügepunkt_RU.TabStop = True
        Me.Einfügepunkt_RU.Text = "rechts unten"
        Me.ToolTip1.SetToolTip(Me.Einfügepunkt_RU, "Einfügepunkt rechts unten")
        Me.Einfügepunkt_RU.UseVisualStyleBackColor = True
        '
        'Einfügepunkt_LU
        '
        Me.Einfügepunkt_LU.AutoSize = True
        Me.Einfügepunkt_LU.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.FormatAttributeBindingSource, "EinfügepunktLU", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Einfügepunkt_LU.Location = New System.Drawing.Point(6, 65)
        Me.Einfügepunkt_LU.Name = "Einfügepunkt_LU"
        Me.Einfügepunkt_LU.Size = New System.Drawing.Size(76, 17)
        Me.Einfügepunkt_LU.TabIndex = 2
        Me.Einfügepunkt_LU.TabStop = True
        Me.Einfügepunkt_LU.Text = "links unten"
        Me.ToolTip1.SetToolTip(Me.Einfügepunkt_LU, "Einfügepunkt links unten")
        Me.Einfügepunkt_LU.UseVisualStyleBackColor = True
        '
        'Einfügepunkt_RO
        '
        Me.Einfügepunkt_RO.AutoSize = True
        Me.Einfügepunkt_RO.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.FormatAttributeBindingSource, "EinfügepunktRO", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Einfügepunkt_RO.Location = New System.Drawing.Point(6, 42)
        Me.Einfügepunkt_RO.Name = "Einfügepunkt_RO"
        Me.Einfügepunkt_RO.Size = New System.Drawing.Size(81, 17)
        Me.Einfügepunkt_RO.TabIndex = 1
        Me.Einfügepunkt_RO.TabStop = True
        Me.Einfügepunkt_RO.Text = "rechts oben"
        Me.ToolTip1.SetToolTip(Me.Einfügepunkt_RO, "Einfügepunkt rechts oben")
        Me.Einfügepunkt_RO.UseVisualStyleBackColor = True
        '
        'Einfügepunkt_LO
        '
        Me.Einfügepunkt_LO.AutoSize = True
        Me.Einfügepunkt_LO.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.FormatAttributeBindingSource, "EinfügepunktLO", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Einfügepunkt_LO.Location = New System.Drawing.Point(6, 19)
        Me.Einfügepunkt_LO.Name = "Einfügepunkt_LO"
        Me.Einfügepunkt_LO.Size = New System.Drawing.Size(73, 17)
        Me.Einfügepunkt_LO.TabIndex = 0
        Me.Einfügepunkt_LO.TabStop = True
        Me.Einfügepunkt_LO.Text = "links oben"
        Me.ToolTip1.SetToolTip(Me.Einfügepunkt_LO, "Einfügepunkt links oben")
        Me.Einfügepunkt_LO.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(390, 142)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 30)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.Button3, "erstellt eine neue Formatdefinition")
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(390, 86)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 30)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.Button2, "entfernt das ausgewählte Format aus der Liste")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'AbmessungenVomBlatt
        '
        Me.AbmessungenVomBlatt.Location = New System.Drawing.Point(20, 92)
        Me.AbmessungenVomBlatt.Name = "AbmessungenVomBlatt"
        Me.AbmessungenVomBlatt.Size = New System.Drawing.Size(184, 54)
        Me.AbmessungenVomBlatt.TabIndex = 8
        Me.AbmessungenVomBlatt.Text = "Abmesssungen vom aktuell Blatt"
        Me.ToolTip1.SetToolTip(Me.AbmessungenVomBlatt, "ermittelt die Abmessungen " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "vom aktuellem Zeichnungsblatt")
        Me.AbmessungenVomBlatt.UseVisualStyleBackColor = True
        '
        'Höhe
        '
        Me.Höhe.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormatAttributeBindingSource, "Höhe", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Höhe.Location = New System.Drawing.Point(95, 56)
        Me.Höhe.Name = "Höhe"
        Me.Höhe.Size = New System.Drawing.Size(80, 20)
        Me.Höhe.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.Höhe, "gibt die Höhe es aktuell gewählten Formats in mm an")
        '
        'Breite
        '
        Me.Breite.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FormatAttributeBindingSource, "Breite", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Breite.Location = New System.Drawing.Point(95, 30)
        Me.Breite.Name = "Breite"
        Me.Breite.Size = New System.Drawing.Size(80, 20)
        Me.Breite.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.Breite, "gibt die Breite es aktuell gewählten Formats in mm an")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(181, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "mm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "mm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Format Höhe:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Format Breite:"
        '
        'ListBoxFormate
        '
        Me.ListBoxFormate.DataSource = Me.FormatBindingSource1
        Me.ListBoxFormate.DisplayMember = "Formatname"
        Me.ListBoxFormate.FormattingEnabled = True
        Me.ListBoxFormate.Location = New System.Drawing.Point(232, 33)
        Me.ListBoxFormate.Name = "ListBoxFormate"
        Me.ListBoxFormate.Size = New System.Drawing.Size(143, 212)
        Me.ListBoxFormate.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ListBoxFormate, "Liste mit im Setup definierten Formaten" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "durch einen Doppelklick auf einen Format" &
        "namen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "kann dieser umbenannt werden")
        Me.ListBoxFormate.ValueMember = "Formatname"
        '
        'FormatBindingSource1
        '
        Me.FormatBindingSource1.DataMember = "Format"
        Me.FormatBindingSource1.DataSource = Me.Data
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(229, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Formate"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Schichtstärke)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Button10)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.SchichtStärkeAbfragenGrp)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(677, 393)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generelle Einstellungen"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "Eventgesteuert", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox1.Location = New System.Drawing.Point(239, 195)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Eventgesteuert"
        Me.ToolTip1.SetToolTip(Me.CheckBox1, resources.GetString("CheckBox1.ToolTip"))
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GenerelleAttributeBindingSource
        '
        Me.GenerelleAttributeBindingSource.DataMember = "GenerelleAttribute"
        Me.GenerelleAttributeBindingSource.DataSource = Me.Data
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(526, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "mm"
        '
        'Schichtstärke
        '
        Me.Schichtstärke.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GenerelleAttributeBindingSource, "SchichtStärke", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Schichtstärke.Location = New System.Drawing.Point(434, 137)
        Me.Schichtstärke.Name = "Schichtstärke"
        Me.Schichtstärke.Size = New System.Drawing.Size(86, 20)
        Me.Schichtstärke.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.Schichtstärke, "Dicke der Schichtstärke in mm")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(431, 121)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Schichtstärke"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(476, 325)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(178, 49)
        Me.Button10.TabIndex = 5
        Me.Button10.Text = "Alte-Ini-Datei einlesen"
        Me.ToolTip1.SetToolTip(Me.Button10, "Liest die alte INI-Datei ein und konvertiert sie" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "und erstellt eine neue INI-Date" &
        "i im XML Format")
        Me.Button10.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.NurAufErstemBlatt)
        Me.GroupBox7.Controls.Add(Me.AnsichtsTypBaugruppen)
        Me.GroupBox7.Controls.Add(Me.AnsichtsTypTeile)
        Me.GroupBox7.Controls.Add(Me.AnsichtsTypSkizzen)
        Me.GroupBox7.Location = New System.Drawing.Point(233, 21)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(178, 145)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Einschränkungen"
        '
        'NurAufErstemBlatt
        '
        Me.NurAufErstemBlatt.AutoSize = True
        Me.NurAufErstemBlatt.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "NurAufErstemBlatt", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NurAufErstemBlatt.Location = New System.Drawing.Point(6, 116)
        Me.NurAufErstemBlatt.Name = "NurAufErstemBlatt"
        Me.NurAufErstemBlatt.Size = New System.Drawing.Size(119, 17)
        Me.NurAufErstemBlatt.TabIndex = 3
        Me.NurAufErstemBlatt.Text = "Nur auf erstem Blatt"
        Me.ToolTip1.SetToolTip(Me.NurAufErstemBlatt, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wir die Passunsgtabelle nur auf dem ersten Blatt eingefügt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sonst" &
        " auf jedem Blatt")
        Me.NurAufErstemBlatt.UseVisualStyleBackColor = True
        '
        'AnsichtsTypBaugruppen
        '
        Me.AnsichtsTypBaugruppen.AutoSize = True
        Me.AnsichtsTypBaugruppen.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "AnsichtsTypBaugruppen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AnsichtsTypBaugruppen.Location = New System.Drawing.Point(6, 66)
        Me.AnsichtsTypBaugruppen.Name = "AnsichtsTypBaugruppen"
        Me.AnsichtsTypBaugruppen.Size = New System.Drawing.Size(84, 17)
        Me.AnsichtsTypBaugruppen.TabIndex = 2
        Me.AnsichtsTypBaugruppen.Text = "Baugruppen"
        Me.ToolTip1.SetToolTip(Me.AnsichtsTypBaugruppen, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden nur Maße von Baugruppen auf Paßungen geprüft")
        Me.AnsichtsTypBaugruppen.UseVisualStyleBackColor = True
        '
        'AnsichtsTypTeile
        '
        Me.AnsichtsTypTeile.AutoSize = True
        Me.AnsichtsTypTeile.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "AnsichtsTypTeile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AnsichtsTypTeile.Location = New System.Drawing.Point(6, 43)
        Me.AnsichtsTypTeile.Name = "AnsichtsTypTeile"
        Me.AnsichtsTypTeile.Size = New System.Drawing.Size(49, 17)
        Me.AnsichtsTypTeile.TabIndex = 1
        Me.AnsichtsTypTeile.Text = "Teile"
        Me.ToolTip1.SetToolTip(Me.AnsichtsTypTeile, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden nur Maße von Teilen auf Paßungen geprüft")
        Me.AnsichtsTypTeile.UseVisualStyleBackColor = True
        '
        'AnsichtsTypSkizzen
        '
        Me.AnsichtsTypSkizzen.AutoSize = True
        Me.AnsichtsTypSkizzen.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "AnsichtsTypSkizzen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.AnsichtsTypSkizzen.Location = New System.Drawing.Point(6, 21)
        Me.AnsichtsTypSkizzen.Name = "AnsichtsTypSkizzen"
        Me.AnsichtsTypSkizzen.Size = New System.Drawing.Size(63, 17)
        Me.AnsichtsTypSkizzen.TabIndex = 0
        Me.AnsichtsTypSkizzen.Text = "Skizzen"
        Me.ToolTip1.SetToolTip(Me.AnsichtsTypSkizzen, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden nur Maße von Skizzen auf Paßungen geprüft")
        Me.AnsichtsTypSkizzen.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ReaktionAufLeerePassung)
        Me.GroupBox5.Controls.Add(Me.LöschenAufRestlichenBlättern)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.RundenAuf)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.LogDatei)
        Me.GroupBox5.Controls.Add(Me.Fehlermeldung)
        Me.GroupBox5.Controls.Add(Me.NeuPositionieren)
        Me.GroupBox5.Controls.Add(Me.PlusZeichen)
        Me.GroupBox5.Location = New System.Drawing.Point(23, 21)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(184, 269)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Allgemeine Einstellungen"
        '
        'ReaktionAufLeerePassung
        '
        Me.ReaktionAufLeerePassung.AutoSize = True
        Me.ReaktionAufLeerePassung.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "ReaktionAufLeerePassung", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ReaktionAufLeerePassung.Location = New System.Drawing.Point(6, 134)
        Me.ReaktionAufLeerePassung.Name = "ReaktionAufLeerePassung"
        Me.ReaktionAufLeerePassung.Size = New System.Drawing.Size(154, 17)
        Me.ReaktionAufLeerePassung.TabIndex = 11
        Me.ReaktionAufLeerePassung.Text = "leere Passungen ignorieren"
        Me.ToolTip1.SetToolTip(Me.ReaktionAufLeerePassung, "Wenn markiert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden Passungen ohne Passungsangabe ignoriert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sonst wird eine M" &
        "eldung ausgegeben" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "vorausgesetzt die Option ""Meldung unterdrücken"" ist nicht akt" &
        "iv")
        Me.ReaktionAufLeerePassung.UseVisualStyleBackColor = True
        '
        'LöschenAufRestlichenBlättern
        '
        Me.LöschenAufRestlichenBlättern.AutoSize = True
        Me.LöschenAufRestlichenBlättern.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "LöschenAufRestlichenBlättern", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LöschenAufRestlichenBlättern.Location = New System.Drawing.Point(6, 111)
        Me.LöschenAufRestlichenBlättern.Name = "LöschenAufRestlichenBlättern"
        Me.LöschenAufRestlichenBlättern.Size = New System.Drawing.Size(168, 17)
        Me.LöschenAufRestlichenBlättern.TabIndex = 7
        Me.LöschenAufRestlichenBlättern.Text = "auf restlichen Blättern löschen"
        Me.ToolTip1.SetToolTip(Me.LöschenAufRestlichenBlättern, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "und die Option ""Nur auf erstem Blatt"" aktiv ist" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dann werden die " &
        "Passungstabellen auf den " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "restlichen Blättern gelöscht")
        Me.LöschenAufRestlichenBlättern.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(101, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Stellen"
        '
        'RundenAuf
        '
        Me.RundenAuf.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.GenerelleAttributeBindingSource, "RundenAuf", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RundenAuf.Location = New System.Drawing.Point(9, 230)
        Me.RundenAuf.Name = "RundenAuf"
        Me.RundenAuf.Size = New System.Drawing.Size(86, 20)
        Me.RundenAuf.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.RundenAuf, "Da SWX nicht immer korrekte Maßwerte zurückliefert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "z.B.: 2,4 als 2,399999999993" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden standardmäßig alle Maße auf 8 Kommastellen gerundet")
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 197)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(124, 30)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Nachkommastellen gerundet auf"
        '
        'LogDatei
        '
        Me.LogDatei.AutoSize = True
        Me.LogDatei.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "LogDatei", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.LogDatei.Location = New System.Drawing.Point(6, 89)
        Me.LogDatei.Name = "LogDatei"
        Me.LogDatei.Size = New System.Drawing.Size(121, 17)
        Me.LogDatei.TabIndex = 3
        Me.LogDatei.Text = "Log-Datei schreiben"
        Me.ToolTip1.SetToolTip(Me.LogDatei, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wird eine Log-Datei mit Meldungen und Informationen erstellt")
        Me.LogDatei.UseVisualStyleBackColor = True
        '
        'Fehlermeldung
        '
        Me.Fehlermeldung.AutoSize = True
        Me.Fehlermeldung.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "Fehlermeldung", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Fehlermeldung.Location = New System.Drawing.Point(6, 66)
        Me.Fehlermeldung.Name = "Fehlermeldung"
        Me.Fehlermeldung.Size = New System.Drawing.Size(145, 17)
        Me.Fehlermeldung.TabIndex = 2
        Me.Fehlermeldung.Text = "Meldungen unterdrücken"
        Me.ToolTip1.SetToolTip(Me.Fehlermeldung, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "werden Fehlermeldungen unterdrückt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sonst werden Fehlermeldungen " &
        "ausgegeben" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "diese Option wird hauptsächlich zu Fehlersuche aktiviert")
        Me.Fehlermeldung.UseVisualStyleBackColor = True
        '
        'NeuPositionieren
        '
        Me.NeuPositionieren.AutoSize = True
        Me.NeuPositionieren.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "NeuPositionieren", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NeuPositionieren.Location = New System.Drawing.Point(6, 43)
        Me.NeuPositionieren.Name = "NeuPositionieren"
        Me.NeuPositionieren.Size = New System.Drawing.Size(144, 17)
        Me.NeuPositionieren.TabIndex = 1
        Me.NeuPositionieren.Text = "Tabelle neu positionieren"
        Me.ToolTip1.SetToolTip(Me.NeuPositionieren, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wird eine vorhandene Tabelle auf Grund der Einfügeparameter neu p" &
        "ositioniert" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sonst wird sie an der vorhandenen Positon eingefügt")
        Me.NeuPositionieren.UseVisualStyleBackColor = True
        '
        'PlusZeichen
        '
        Me.PlusZeichen.AutoSize = True
        Me.PlusZeichen.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "PlusZeichen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.PlusZeichen.Location = New System.Drawing.Point(6, 21)
        Me.PlusZeichen.Name = "PlusZeichen"
        Me.PlusZeichen.Size = New System.Drawing.Size(142, 17)
        Me.PlusZeichen.TabIndex = 0
        Me.PlusZeichen.Text = "PLUS-Zeichen anzeigen"
        Me.ToolTip1.SetToolTip(Me.PlusZeichen, "Wenn markiert," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "wird das Pluszeichen ""+"" bei positiven Werten angezeigt")
        Me.PlusZeichen.UseVisualStyleBackColor = True
        '
        'SchichtStärkeAbfragenGrp
        '
        Me.SchichtStärkeAbfragenGrp.Controls.Add(Me.SchichtStärkeFix)
        Me.SchichtStärkeAbfragenGrp.Controls.Add(Me.RadioButton7)
        Me.SchichtStärkeAbfragenGrp.Controls.Add(Me.SchichtStärkeKeine)
        Me.SchichtStärkeAbfragenGrp.Location = New System.Drawing.Point(428, 21)
        Me.SchichtStärkeAbfragenGrp.Name = "SchichtStärkeAbfragenGrp"
        Me.SchichtStärkeAbfragenGrp.Size = New System.Drawing.Size(141, 97)
        Me.SchichtStärkeAbfragenGrp.TabIndex = 2
        Me.SchichtStärkeAbfragenGrp.TabStop = False
        Me.SchichtStärkeAbfragenGrp.Text = "Schichtstärke"
        '
        'SchichtStärkeFix
        '
        Me.SchichtStärkeFix.AutoSize = True
        Me.SchichtStärkeFix.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "SchichtStärkeFix", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SchichtStärkeFix.Location = New System.Drawing.Point(6, 66)
        Me.SchichtStärkeFix.Name = "SchichtStärkeFix"
        Me.SchichtStärkeFix.Size = New System.Drawing.Size(35, 17)
        Me.SchichtStärkeFix.TabIndex = 4
        Me.SchichtStärkeFix.Text = "fix"
        Me.ToolTip1.SetToolTip(Me.SchichtStärkeFix, "Schichtstärke wird als fixer Wert berücksichtigt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "dies setzt voraus, dass im Feld" &
        " Schichtstärke " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ein Wert eingetragen wird")
        Me.SchichtStärkeFix.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "SchichtStärkeAbfragen", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.RadioButton7.Enabled = False
        Me.RadioButton7.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.RadioButton7.Location = New System.Drawing.Point(6, 43)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(67, 17)
        Me.RadioButton7.TabIndex = 3
        Me.RadioButton7.Text = "abfragen"
        Me.ToolTip1.SetToolTip(Me.RadioButton7, "Schichtstärke wird abgefragt berücksichtigt")
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'SchichtStärkeKeine
        '
        Me.SchichtStärkeKeine.AutoSize = True
        Me.SchichtStärkeKeine.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.GenerelleAttributeBindingSource, "SchichtStärkeKeine", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.SchichtStärkeKeine.Location = New System.Drawing.Point(6, 20)
        Me.SchichtStärkeKeine.Name = "SchichtStärkeKeine"
        Me.SchichtStärkeKeine.Size = New System.Drawing.Size(51, 17)
        Me.SchichtStärkeKeine.TabIndex = 2
        Me.SchichtStärkeKeine.Text = "keine"
        Me.ToolTip1.SetToolTip(Me.SchichtStärkeKeine, "Schichtstärke wird nicht berücksichtigt")
        Me.SchichtStärkeKeine.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(14, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(685, 419)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage5.Controls.Add(Me.GroupBox10)
        Me.TabPage5.Controls.Add(Me.TextBox23)
        Me.TabPage5.Controls.Add(Me.TextBox12)
        Me.TabPage5.Controls.Add(Me.TextBox13)
        Me.TabPage5.Controls.Add(Me.TextBox14)
        Me.TabPage5.Controls.Add(Me.TextBox15)
        Me.TabPage5.Controls.Add(Me.TextBox16)
        Me.TabPage5.Controls.Add(Me.TextBox17)
        Me.TabPage5.Controls.Add(Me.TextBox18)
        Me.TabPage5.Controls.Add(Me.TextBox19)
        Me.TabPage5.Controls.Add(Me.TextBox20)
        Me.TabPage5.Controls.Add(Me.TextBox21)
        Me.TabPage5.Controls.Add(Me.TextBox22)
        Me.TabPage5.Controls.Add(Me.TextBox11)
        Me.TabPage5.Controls.Add(Me.CB_Spalte8)
        Me.TabPage5.Controls.Add(Me.TextBox9)
        Me.TabPage5.Controls.Add(Me.TextBox10)
        Me.TabPage5.Controls.Add(Me.CB_Spalte7)
        Me.TabPage5.Controls.Add(Me.CB_Spalte6)
        Me.TabPage5.Controls.Add(Me.CB_Spalte5)
        Me.TabPage5.Controls.Add(Me.CB_Spalte4)
        Me.TabPage5.Controls.Add(Me.CB_Spalte3)
        Me.TabPage5.Controls.Add(Me.CB_Spalte2)
        Me.TabPage5.Controls.Add(Me.CB_Spalte1)
        Me.TabPage5.Controls.Add(Me.TextBox8)
        Me.TabPage5.Controls.Add(Me.TextBox7)
        Me.TabPage5.Controls.Add(Me.TextBox6)
        Me.TabPage5.Controls.Add(Me.TextBox5)
        Me.TabPage5.Controls.Add(Me.TextBox4)
        Me.TabPage5.Controls.Add(Me.TextBox3)
        Me.TabPage5.Controls.Add(Me.TextBox2)
        Me.TabPage5.Controls.Add(Me.TextBox1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(677, 393)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Tabellenspalten"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte8)
        Me.GroupBox10.Controls.Add(Me.Label23)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte7)
        Me.GroupBox10.Controls.Add(Me.Label21)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte6)
        Me.GroupBox10.Controls.Add(Me.Label19)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte5)
        Me.GroupBox10.Controls.Add(Me.Label17)
        Me.GroupBox10.Controls.Add(Me.CB_AutomatischeSpaltenBreite)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte4)
        Me.GroupBox10.Controls.Add(Me.Label22)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte3)
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte2)
        Me.GroupBox10.Controls.Add(Me.Label18)
        Me.GroupBox10.Controls.Add(Me.BreiteSpalte1)
        Me.GroupBox10.Controls.Add(Me.Label16)
        Me.GroupBox10.Location = New System.Drawing.Point(3, 162)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(421, 95)
        Me.GroupBox10.TabIndex = 65
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Spaltenbreiten"
        '
        'BreiteSpalte8
        '
        Me.BreiteSpalte8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteVorbearbeitungsToleranzMitte", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte8.Location = New System.Drawing.Point(358, 16)
        Me.BreiteSpalte8.Name = "BreiteSpalte8"
        Me.BreiteSpalte8.Size = New System.Drawing.Size(50, 20)
        Me.BreiteSpalte8.TabIndex = 75
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte8, "Breite der vierten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(372, 39)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(23, 13)
        Me.Label23.TabIndex = 74
        Me.Label23.Text = "mm"
        '
        'BreiteSpalte7
        '
        Me.BreiteSpalte7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteVorbearbeitungsAbmaße", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte7.Location = New System.Drawing.Point(312, 16)
        Me.BreiteSpalte7.Name = "BreiteSpalte7"
        Me.BreiteSpalte7.Size = New System.Drawing.Size(40, 20)
        Me.BreiteSpalte7.TabIndex = 73
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte7, "Breite der vierten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(319, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 13)
        Me.Label21.TabIndex = 72
        Me.Label21.Text = "mm"
        '
        'BreiteSpalte6
        '
        Me.BreiteSpalte6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteAbmaßToleranzMitte", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte6.Location = New System.Drawing.Point(256, 16)
        Me.BreiteSpalte6.Name = "BreiteSpalte6"
        Me.BreiteSpalte6.Size = New System.Drawing.Size(45, 20)
        Me.BreiteSpalte6.TabIndex = 71
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte6, "Breite der vierten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(265, 39)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(23, 13)
        Me.Label19.TabIndex = 70
        Me.Label19.Text = "mm"
        '
        'BreiteSpalte5
        '
        Me.BreiteSpalte5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteAbmaß", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte5.Location = New System.Drawing.Point(210, 16)
        Me.BreiteSpalte5.Name = "BreiteSpalte5"
        Me.BreiteSpalte5.Size = New System.Drawing.Size(40, 20)
        Me.BreiteSpalte5.TabIndex = 69
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte5, "Breite der vierten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(217, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 13)
        Me.Label17.TabIndex = 68
        Me.Label17.Text = "mm"
        '
        'CB_AutomatischeSpaltenBreite
        '
        Me.CB_AutomatischeSpaltenBreite.AutoSize = True
        Me.CB_AutomatischeSpaltenBreite.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "SpaltenBreiteAutomatisch", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_AutomatischeSpaltenBreite.Location = New System.Drawing.Point(16, 65)
        Me.CB_AutomatischeSpaltenBreite.Name = "CB_AutomatischeSpaltenBreite"
        Me.CB_AutomatischeSpaltenBreite.Size = New System.Drawing.Size(155, 17)
        Me.CB_AutomatischeSpaltenBreite.TabIndex = 67
        Me.CB_AutomatischeSpaltenBreite.Text = "Automatische Spaltenbreite"
        Me.CB_AutomatischeSpaltenBreite.UseVisualStyleBackColor = True
        '
        'BreiteSpalte4
        '
        Me.BreiteSpalte4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteToleranz", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte4.Location = New System.Drawing.Point(164, 16)
        Me.BreiteSpalte4.Name = "BreiteSpalte4"
        Me.BreiteSpalte4.Size = New System.Drawing.Size(37, 20)
        Me.BreiteSpalte4.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte4, "Breite der vierten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(169, 39)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(23, 13)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "mm"
        '
        'BreiteSpalte3
        '
        Me.BreiteSpalte3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteMaßePassung", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte3.Location = New System.Drawing.Point(108, 16)
        Me.BreiteSpalte3.Name = "BreiteSpalte3"
        Me.BreiteSpalte3.Size = New System.Drawing.Size(50, 20)
        Me.BreiteSpalte3.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte3, "Breite der dritten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(123, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 13)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "mm"
        '
        'BreiteSpalte2
        '
        Me.BreiteSpalte2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpaltePassung", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte2.Location = New System.Drawing.Point(62, 16)
        Me.BreiteSpalte2.Name = "BreiteSpalte2"
        Me.BreiteSpalte2.Size = New System.Drawing.Size(40, 20)
        Me.BreiteSpalte2.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte2, "Breite der zweiten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(71, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(23, 13)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "mm"
        '
        'BreiteSpalte1
        '
        Me.BreiteSpalte1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TabellenAttributeBindingSource, "BreiteSpalteMaß", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.BreiteSpalte1.Location = New System.Drawing.Point(16, 16)
        Me.BreiteSpalte1.Name = "BreiteSpalte1"
        Me.BreiteSpalte1.Size = New System.Drawing.Size(40, 20)
        Me.BreiteSpalte1.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.BreiteSpalte1, "Breite der ersten Splate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sieh auch Tabellentyp")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(23, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "mm"
        '
        'TextBox23
        '
        Me.TextBox23.BackColor = System.Drawing.SystemColors.MenuBar
        Me.TextBox23.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox23.Location = New System.Drawing.Point(417, 53)
        Me.TextBox23.Multiline = True
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(240, 92)
        Me.TextBox23.TabIndex = 64
        Me.TextBox23.Text = "markieren Sie die Spalten die Sie angezeigt bekommen möchten" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "für die Beispiele o" &
    "ben wurde eine Schichtstärke von 0,012mm angenommen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox12
        '
        Me.TextBox12.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox12.Enabled = False
        Me.TextBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox12.Location = New System.Drawing.Point(361, 99)
        Me.TextBox12.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox12.MaximumSize = New System.Drawing.Size(50, 40)
        Me.TextBox12.MinimumSize = New System.Drawing.Size(50, 46)
        Me.TextBox12.Multiline = True
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(50, 46)
        Me.TextBox12.TabIndex = 63
        Me.TextBox12.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "25,9905"
        Me.TextBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox13
        '
        Me.TextBox13.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox13.Enabled = False
        Me.TextBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox13.Location = New System.Drawing.Point(315, 122)
        Me.TextBox13.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox13.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox13.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox13.Multiline = True
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.ReadOnly = True
        Me.TextBox13.Size = New System.Drawing.Size(40, 23)
        Me.TextBox13.TabIndex = 62
        Me.TextBox13.Text = "25,984"
        Me.TextBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox14
        '
        Me.TextBox14.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox14.Enabled = False
        Me.TextBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox14.Location = New System.Drawing.Point(315, 99)
        Me.TextBox14.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox14.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox14.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox14.Multiline = True
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.ReadOnly = True
        Me.TextBox14.Size = New System.Drawing.Size(40, 23)
        Me.TextBox14.TabIndex = 61
        Me.TextBox14.Text = "25,997"
        Me.TextBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox15
        '
        Me.TextBox15.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox15.Enabled = False
        Me.TextBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox15.Location = New System.Drawing.Point(259, 99)
        Me.TextBox15.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox15.MaximumSize = New System.Drawing.Size(50, 40)
        Me.TextBox15.MinimumSize = New System.Drawing.Size(50, 46)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(50, 46)
        Me.TextBox15.TabIndex = 60
        Me.TextBox15.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26,0145"
        Me.TextBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox16
        '
        Me.TextBox16.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox16.Enabled = False
        Me.TextBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox16.Location = New System.Drawing.Point(111, 99)
        Me.TextBox16.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox16.MaximumSize = New System.Drawing.Size(50, 40)
        Me.TextBox16.MinimumSize = New System.Drawing.Size(50, 46)
        Me.TextBox16.Multiline = True
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(50, 46)
        Me.TextBox16.TabIndex = 59
        Me.TextBox16.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26 m6"
        Me.TextBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox17
        '
        Me.TextBox17.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox17.Enabled = False
        Me.TextBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox17.Location = New System.Drawing.Point(65, 99)
        Me.TextBox17.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox17.MaximumSize = New System.Drawing.Size(40, 40)
        Me.TextBox17.MinimumSize = New System.Drawing.Size(40, 46)
        Me.TextBox17.Multiline = True
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(40, 46)
        Me.TextBox17.TabIndex = 58
        Me.TextBox17.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "m6"
        Me.TextBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox18
        '
        Me.TextBox18.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox18.Enabled = False
        Me.TextBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox18.Location = New System.Drawing.Point(213, 122)
        Me.TextBox18.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox18.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox18.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox18.Multiline = True
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.Size = New System.Drawing.Size(40, 23)
        Me.TextBox18.TabIndex = 57
        Me.TextBox18.Text = "26,008"
        Me.TextBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox19
        '
        Me.TextBox19.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox19.Enabled = False
        Me.TextBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox19.Location = New System.Drawing.Point(213, 99)
        Me.TextBox19.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox19.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox19.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox19.Multiline = True
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ReadOnly = True
        Me.TextBox19.Size = New System.Drawing.Size(40, 23)
        Me.TextBox19.TabIndex = 56
        Me.TextBox19.Text = "26,021"
        Me.TextBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox20
        '
        Me.TextBox20.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox20.Enabled = False
        Me.TextBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox20.Location = New System.Drawing.Point(167, 122)
        Me.TextBox20.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox20.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox20.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox20.Multiline = True
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.Size = New System.Drawing.Size(40, 23)
        Me.TextBox20.TabIndex = 55
        Me.TextBox20.Text = "+0,008"
        Me.TextBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox21
        '
        Me.TextBox21.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox21.Enabled = False
        Me.TextBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox21.Location = New System.Drawing.Point(167, 99)
        Me.TextBox21.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox21.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox21.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox21.Multiline = True
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.ReadOnly = True
        Me.TextBox21.Size = New System.Drawing.Size(40, 23)
        Me.TextBox21.TabIndex = 54
        Me.TextBox21.Text = "+0,021"
        Me.TextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox22
        '
        Me.TextBox22.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox22.Enabled = False
        Me.TextBox22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox22.Location = New System.Drawing.Point(19, 99)
        Me.TextBox22.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox22.MaximumSize = New System.Drawing.Size(40, 40)
        Me.TextBox22.MinimumSize = New System.Drawing.Size(40, 46)
        Me.TextBox22.Multiline = True
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.ReadOnly = True
        Me.TextBox22.Size = New System.Drawing.Size(40, 46)
        Me.TextBox22.TabIndex = 53
        Me.TextBox22.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.TextBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox11
        '
        Me.TextBox11.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox11.Enabled = False
        Me.TextBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox11.Location = New System.Drawing.Point(361, 53)
        Me.TextBox11.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox11.MaximumSize = New System.Drawing.Size(50, 40)
        Me.TextBox11.MinimumSize = New System.Drawing.Size(50, 46)
        Me.TextBox11.Multiline = True
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(50, 46)
        Me.TextBox11.TabIndex = 52
        Me.TextBox11.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26,0345"
        Me.TextBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CB_Spalte8
        '
        Me.CB_Spalte8.AutoSize = True
        Me.CB_Spalte8.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteVorbearbeitungsToleranzMitte", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte8.Location = New System.Drawing.Point(378, 27)
        Me.CB_Spalte8.Name = "CB_Spalte8"
        Me.CB_Spalte8.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte8.TabIndex = 51
        Me.ToolTip1.SetToolTip(Me.CB_Spalte8, "Vorberbeitung Toleranzmitte")
        Me.CB_Spalte8.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox9.Enabled = False
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(315, 76)
        Me.TextBox9.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox9.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox9.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox9.Multiline = True
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(40, 23)
        Me.TextBox9.TabIndex = 50
        Me.TextBox9.Text = "26,024"
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox10
        '
        Me.TextBox10.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox10.Enabled = False
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(315, 53)
        Me.TextBox10.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox10.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox10.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox10.Multiline = True
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(40, 23)
        Me.TextBox10.TabIndex = 49
        Me.TextBox10.Text = "26,045"
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CB_Spalte7
        '
        Me.CB_Spalte7.AutoSize = True
        Me.CB_Spalte7.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteVorbearbeitungsAbmaße", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte7.Location = New System.Drawing.Point(325, 27)
        Me.CB_Spalte7.Name = "CB_Spalte7"
        Me.CB_Spalte7.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte7.TabIndex = 48
        Me.ToolTip1.SetToolTip(Me.CB_Spalte7, "Vorberbeitungsabmaße")
        Me.CB_Spalte7.UseVisualStyleBackColor = True
        '
        'CB_Spalte6
        '
        Me.CB_Spalte6.AutoSize = True
        Me.CB_Spalte6.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteAbmaßToleranzMitte", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte6.Location = New System.Drawing.Point(276, 27)
        Me.CB_Spalte6.Name = "CB_Spalte6"
        Me.CB_Spalte6.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte6.TabIndex = 47
        Me.ToolTip1.SetToolTip(Me.CB_Spalte6, "Abmaß Toleranzmitte")
        Me.CB_Spalte6.UseVisualStyleBackColor = True
        '
        'CB_Spalte5
        '
        Me.CB_Spalte5.AutoSize = True
        Me.CB_Spalte5.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteAbmaß", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte5.Location = New System.Drawing.Point(223, 27)
        Me.CB_Spalte5.Name = "CB_Spalte5"
        Me.CB_Spalte5.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte5.TabIndex = 46
        Me.CB_Spalte5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.CB_Spalte5, "Abmaß")
        Me.CB_Spalte5.UseVisualStyleBackColor = True
        '
        'CB_Spalte4
        '
        Me.CB_Spalte4.AutoSize = True
        Me.CB_Spalte4.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteToleranz", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte4.Location = New System.Drawing.Point(180, 27)
        Me.CB_Spalte4.Name = "CB_Spalte4"
        Me.CB_Spalte4.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte4.TabIndex = 45
        Me.ToolTip1.SetToolTip(Me.CB_Spalte4, "Toleranz")
        Me.CB_Spalte4.UseVisualStyleBackColor = True
        '
        'CB_Spalte3
        '
        Me.CB_Spalte3.AutoSize = True
        Me.CB_Spalte3.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteMaßePassung", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte3.Location = New System.Drawing.Point(129, 27)
        Me.CB_Spalte3.Name = "CB_Spalte3"
        Me.CB_Spalte3.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte3.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.CB_Spalte3, "Maß+Passung")
        Me.CB_Spalte3.UseVisualStyleBackColor = True
        '
        'CB_Spalte2
        '
        Me.CB_Spalte2.AutoSize = True
        Me.CB_Spalte2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpaltePassung", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte2.Location = New System.Drawing.Point(77, 27)
        Me.CB_Spalte2.Name = "CB_Spalte2"
        Me.CB_Spalte2.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte2.TabIndex = 43
        Me.ToolTip1.SetToolTip(Me.CB_Spalte2, "Passung")
        Me.CB_Spalte2.UseVisualStyleBackColor = True
        '
        'CB_Spalte1
        '
        Me.CB_Spalte1.AutoSize = True
        Me.CB_Spalte1.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.TabellenAttributeBindingSource, "TabSpalteMaß", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CB_Spalte1.Location = New System.Drawing.Point(33, 27)
        Me.CB_Spalte1.Name = "CB_Spalte1"
        Me.CB_Spalte1.Size = New System.Drawing.Size(15, 14)
        Me.CB_Spalte1.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.CB_Spalte1, "Maß")
        Me.CB_Spalte1.UseVisualStyleBackColor = True
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox8.Enabled = False
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(259, 53)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox8.MaximumSize = New System.Drawing.Size(50, 40)
        Me.TextBox8.MinimumSize = New System.Drawing.Size(50, 46)
        Me.TextBox8.Multiline = True
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(50, 46)
        Me.TextBox8.TabIndex = 41
        Me.TextBox8.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26,0105"
        Me.TextBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox7.Enabled = False
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(111, 53)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox7.MaximumSize = New System.Drawing.Size(50, 40)
        Me.TextBox7.MinimumSize = New System.Drawing.Size(50, 46)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(50, 46)
        Me.TextBox7.TabIndex = 40
        Me.TextBox7.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26 H7"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox6.Enabled = False
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(65, 53)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox6.MaximumSize = New System.Drawing.Size(40, 40)
        Me.TextBox6.MinimumSize = New System.Drawing.Size(40, 46)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(40, 46)
        Me.TextBox6.TabIndex = 39
        Me.TextBox6.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "H7"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox5.Enabled = False
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(213, 76)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox5.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox5.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(40, 23)
        Me.TextBox5.TabIndex = 38
        Me.TextBox5.Text = "26"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(213, 53)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox4.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox4.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(40, 23)
        Me.TextBox4.TabIndex = 37
        Me.TextBox4.Text = "26,021"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(167, 76)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox3.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox3.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(40, 23)
        Me.TextBox3.TabIndex = 36
        Me.TextBox3.Text = "0"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(167, 53)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox2.MaximumSize = New System.Drawing.Size(40, 23)
        Me.TextBox2.MinimumSize = New System.Drawing.Size(40, 23)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(40, 23)
        Me.TextBox2.TabIndex = 35
        Me.TextBox2.Text = "+0,021"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(19, 53)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TextBox1.MaximumSize = New System.Drawing.Size(40, 40)
        Me.TextBox1.MinimumSize = New System.Drawing.Size(40, 46)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(40, 46)
        Me.TextBox1.TabIndex = 34
        Me.TextBox1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatLab1, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 475)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(711, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatLab1
        '
        Me.StatLab1.Name = "StatLab1"
        Me.StatLab1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel1.Text = "-"
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Hinweis:"
        '
        'SetupDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(711, 497)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Passungstabelle Setup"
        Me.TabPage4.ResumeLayout(False)
        CType(Me.DataGridÜbersetzungen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpracheBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Data, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ÜbersetzungBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.TabellenAttributeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SprachkombinationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.Zeilenparameter.ResumeLayout(False)
        Me.Zeilenparameter.PerformLayout()
        Me.HeaderGRP.ResumeLayout(False)
        Me.HeaderGRP.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.RasterLinien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RahmenLinien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.FormatAttributeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EinfügepunktGRP.ResumeLayout(False)
        Me.EinfügepunktGRP.PerformLayout()
        CType(Me.FormatBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GenerelleAttributeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.SchichtStärkeAbfragenGrp.ResumeLayout(False)
        Me.SchichtStärkeAbfragenGrp.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents FontDialog1 As Windows.Forms.FontDialog
    Friend WithEvents TabPage4 As Windows.Forms.TabPage
    Friend WithEvents DataGridÜbersetzungen As Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents HeaderGRP As Windows.Forms.GroupBox
    Friend WithEvents HeaderUnten As Windows.Forms.RadioButton
    Friend WithEvents HeaderOben As Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As Windows.Forms.GroupBox
    Friend WithEvents Label15 As Windows.Forms.Label
    Friend WithEvents RasterStrichStärke As Windows.Forms.ComboBox
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents RahmenStrichStärke As Windows.Forms.ComboBox
    Friend WithEvents TabellenZeilenBT As Windows.Forms.Button
    Friend WithEvents TabellenKopfZeileBT As Windows.Forms.Button
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Offset_Y As Windows.Forms.TextBox
    Friend WithEvents Offset_X As Windows.Forms.TextBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents EinfügepunktGRP As Windows.Forms.GroupBox
    Friend WithEvents Einfügepunkt_RU As Windows.Forms.RadioButton
    Friend WithEvents Einfügepunkt_LU As Windows.Forms.RadioButton
    Friend WithEvents Einfügepunkt_RO As Windows.Forms.RadioButton
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents AbmessungenVomBlatt As Windows.Forms.Button
    Friend WithEvents Höhe As Windows.Forms.TextBox
    Friend WithEvents Breite As Windows.Forms.TextBox
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents ListBoxFormate As Windows.Forms.ListBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As Windows.Forms.GroupBox
    Friend WithEvents AnsichtsTypBaugruppen As Windows.Forms.CheckBox
    Friend WithEvents AnsichtsTypTeile As Windows.Forms.CheckBox
    Friend WithEvents AnsichtsTypSkizzen As Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As Windows.Forms.GroupBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents RundenAuf As Windows.Forms.TextBox
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents LogDatei As Windows.Forms.CheckBox
    Friend WithEvents Fehlermeldung As Windows.Forms.CheckBox
    Friend WithEvents NeuPositionieren As Windows.Forms.CheckBox
    Friend WithEvents PlusZeichen As Windows.Forms.CheckBox
    Friend WithEvents SchichtStärkeAbfragenGrp As Windows.Forms.GroupBox
    Friend WithEvents SchichtStärkeFix As Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As Windows.Forms.RadioButton
    Friend WithEvents SchichtStärkeKeine As Windows.Forms.RadioButton
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents Button10 As Windows.Forms.Button
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents StatLab1 As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As Windows.Forms.ToolStripProgressBar
    Friend WithEvents Einfügepunkt_LO As Windows.Forms.RadioButton
    Friend WithEvents Zeilenparameter As Windows.Forms.GroupBox
    Friend WithEvents TexthöheZeile As Windows.Forms.TextBox
    Friend WithEvents Label24 As Windows.Forms.Label
    Friend WithEvents SchriftstilZeile As Windows.Forms.TextBox
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents SchriftartZeile As Windows.Forms.TextBox
    Friend WithEvents Label26 As Windows.Forms.Label
    Friend WithEvents DurchgestrichenZeile As Windows.Forms.CheckBox
    Friend WithEvents UnterstrichenZeile As Windows.Forms.CheckBox
    Friend WithEvents GroupBox12 As Windows.Forms.GroupBox
    Friend WithEvents FarbeKopfZeile As Windows.Forms.TextBox
    Friend WithEvents Label28 As Windows.Forms.Label
    Friend WithEvents DurchgestrichenKopfZeile As Windows.Forms.CheckBox
    Friend WithEvents UnterstrichenKopfZeile As Windows.Forms.CheckBox
    Friend WithEvents TexthöheKopfZeile As Windows.Forms.TextBox
    Friend WithEvents Label29 As Windows.Forms.Label
    Friend WithEvents SchriftstilKopfZeile As Windows.Forms.TextBox
    Friend WithEvents Label30 As Windows.Forms.Label
    Friend WithEvents SchriftartKopfZeile As Windows.Forms.TextBox
    Friend WithEvents Label31 As Windows.Forms.Label
    Friend WithEvents FarbeZeile As Windows.Forms.TextBox
    Friend WithEvents Label27 As Windows.Forms.Label
    Friend WithEvents FettKopfZeile As Windows.Forms.CheckBox
    Friend WithEvents FettZeile As Windows.Forms.CheckBox
    Friend WithEvents LöschenAufRestlichenBlättern As Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents NurAufErstemBlatt As Windows.Forms.CheckBox
    Friend WithEvents ReaktionAufLeerePassung As Windows.Forms.CheckBox
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Schichtstärke As Windows.Forms.TextBox
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents BindingSource1 As Windows.Forms.BindingSource
    Friend WithEvents Label32 As Windows.Forms.Label
    Friend WithEvents HeaderLanguage As Windows.Forms.ComboBox
    Friend WithEvents GenerelleAttributeBindingSource As Windows.Forms.BindingSource
    Friend WithEvents FormatBindingSource1 As Windows.Forms.BindingSource
    Friend WithEvents SprachkombinationBindingSource As Windows.Forms.BindingSource
    Friend WithEvents TabellenAttributeBindingSource As Windows.Forms.BindingSource
    Friend WithEvents RasterLinien As Windows.Forms.BindingSource
    Friend WithEvents RahmenLinien As Windows.Forms.BindingSource
    Friend WithEvents SpracheBindingSource As Windows.Forms.BindingSource
    Friend WithEvents ÜbersetzungBindingSource As Windows.Forms.BindingSource
    Friend WithEvents FormatAttributeBindingSource As Windows.Forms.BindingSource
    Friend WithEvents ToolStripStatusLabel1 As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AlleFormateGleichBT As Windows.Forms.Button
    Friend WithEvents TabPage5 As Windows.Forms.TabPage
    Friend WithEvents TextBox23 As Windows.Forms.TextBox
    Friend WithEvents TextBox12 As Windows.Forms.TextBox
    Friend WithEvents TextBox13 As Windows.Forms.TextBox
    Friend WithEvents TextBox14 As Windows.Forms.TextBox
    Friend WithEvents TextBox15 As Windows.Forms.TextBox
    Friend WithEvents TextBox16 As Windows.Forms.TextBox
    Friend WithEvents TextBox17 As Windows.Forms.TextBox
    Friend WithEvents TextBox18 As Windows.Forms.TextBox
    Friend WithEvents TextBox19 As Windows.Forms.TextBox
    Friend WithEvents TextBox20 As Windows.Forms.TextBox
    Friend WithEvents TextBox21 As Windows.Forms.TextBox
    Friend WithEvents TextBox22 As Windows.Forms.TextBox
    Friend WithEvents TextBox11 As Windows.Forms.TextBox
    Friend WithEvents CB_Spalte8 As Windows.Forms.CheckBox
    Friend WithEvents TextBox9 As Windows.Forms.TextBox
    Friend WithEvents TextBox10 As Windows.Forms.TextBox
    Friend WithEvents CB_Spalte7 As Windows.Forms.CheckBox
    Friend WithEvents CB_Spalte6 As Windows.Forms.CheckBox
    Friend WithEvents CB_Spalte5 As Windows.Forms.CheckBox
    Friend WithEvents CB_Spalte4 As Windows.Forms.CheckBox
    Friend WithEvents CB_Spalte3 As Windows.Forms.CheckBox
    Friend WithEvents CB_Spalte2 As Windows.Forms.CheckBox
    Friend WithEvents CB_Spalte1 As Windows.Forms.CheckBox
    Friend WithEvents TextBox8 As Windows.Forms.TextBox
    Friend WithEvents TextBox7 As Windows.Forms.TextBox
    Friend WithEvents TextBox6 As Windows.Forms.TextBox
    Friend WithEvents TextBox5 As Windows.Forms.TextBox
    Friend WithEvents TextBox4 As Windows.Forms.TextBox
    Friend WithEvents TextBox3 As Windows.Forms.TextBox
    Friend WithEvents TextBox2 As Windows.Forms.TextBox
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As Windows.Forms.GroupBox
    Friend WithEvents BreiteSpalte4 As Windows.Forms.TextBox
    Friend WithEvents Label22 As Windows.Forms.Label
    Friend WithEvents BreiteSpalte3 As Windows.Forms.TextBox
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents BreiteSpalte2 As Windows.Forms.TextBox
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents BreiteSpalte1 As Windows.Forms.TextBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents CB_AutomatischeSpaltenBreite As Windows.Forms.CheckBox
    Friend WithEvents Data As Data
    Friend WithEvents AbmaßToleranzmitteDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KursivKopfZeile As Windows.Forms.CheckBox
    Friend WithEvents KursivZeile As Windows.Forms.CheckBox
    Friend WithEvents BreiteSpalte8 As Windows.Forms.TextBox
    Friend WithEvents Label23 As Windows.Forms.Label
    Friend WithEvents BreiteSpalte7 As Windows.Forms.TextBox
    Friend WithEvents Label21 As Windows.Forms.Label
    Friend WithEvents BreiteSpalte6 As Windows.Forms.TextBox
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents BreiteSpalte5 As Windows.Forms.TextBox
    Friend WithEvents Label17 As Windows.Forms.Label
    Friend WithEvents KürzelDataGridViewTextBoxColumn As Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Maß As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PassungDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaßePassung As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToleranzDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AbmaßDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VorbearbeitungsAbmaßeDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VorbearbeitungsToleranzMitteDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ÜbersetzungenIdDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label33 As Windows.Forms.Label
    Friend WithEvents Label34 As Windows.Forms.Label
End Class
