Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished

Public Class UserPMPage
    Dim iSwApp As SldWorks
    Dim userAddin As SwAddin
    Dim handler As PMPageHandler
    Dim ppage As PropertyManagerPage2

#Region "Property Manager Page Controls"
    'Groups
    Dim group1 As PropertyManagerPageGroup
    Dim group2 As PropertyManagerPageGroup

    'Controls
    Dim checkbox1 As PropertyManagerPageCheckbox
    Dim option1 As PropertyManagerPageOption
    Dim option2 As PropertyManagerPageOption
    Dim option3 As PropertyManagerPageOption
    Dim list1 As PropertyManagerPageListbox

    Dim selection1 As PropertyManagerPageSelectionbox
    Dim num1 As PropertyManagerPageNumberbox
    Dim combo1 As PropertyManagerPageCombobox

    'Control IDs
    Dim group1ID As Integer = 0
    Dim group2ID As Integer = 1
    Dim checkbox1ID As Integer = 2
    Dim option1ID As Integer = 3
    Dim option2ID As Integer = 4
    Dim option3ID As Integer = 5
    Dim list1ID As Integer = 6
    Dim selection1ID As Integer = 7
    Dim num1ID As Integer = 8
    Dim combo1ID As Integer = 9
#End Region

    Sub Init(ByVal sw As SldWorks, ByVal addin As SwAddin)
        iSwApp = sw
        userAddin = addin
        CreatePage()
        AddControls()
    End Sub

    Sub Show()
        ppage.Show()
    End Sub

    Sub CreatePage()
        handler = New PMPageHandler()
        handler.Init(iSwApp, userAddin)
        Dim options As Integer
        Dim errors As Integer
        options = swPropertyManagerPageOptions_e.swPropertyManagerOptions_OkayButton + swPropertyManagerPageOptions_e.swPropertyManagerOptions_CancelButton
        ppage = iSwApp.CreatePropertyManagerPage("Sample PMP", options, handler, errors)
    End Sub

    Sub AddControls()
        Dim options As Integer
        Dim leftAlign As Integer
        Dim controlType As Integer

        'Add Groups
        options = swAddGroupBoxOptions_e.swGroupBoxOptions_Expanded + swAddGroupBoxOptions_e.swGroupBoxOptions_Visible
        group1 = ppage.AddGroupBox(group1ID, "Sample Group I", options)

        options = swAddGroupBoxOptions_e.swGroupBoxOptions_Checkbox + swAddGroupBoxOptions_e.swGroupBoxOptions_Visible
        group2 = ppage.AddGroupBox(group2ID, "Sample Group II", options)

        'Add Controls to Group1 
        'Checkbox1
        controlType = swPropertyManagerPageControlType_e.swControlType_Checkbox
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        checkbox1 = group1.AddControl(checkbox1ID, controlType, "Sample Checkbox", leftAlign, options, "True or False Checkbox")

        'Option1
        controlType = swPropertyManagerPageControlType_e.swControlType_Option
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        option1 = group1.AddControl(option1ID, controlType, "Sample Option1", leftAlign, options, "Radio Buttons")

        'Option2
        controlType = swPropertyManagerPageControlType_e.swControlType_Option
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        option2 = group1.AddControl(option2ID, controlType, "Sample Option2", leftAlign, options, "Radio Buttons")
        If Not option2 Is Nothing Then
            option2.Checked = True
        End If

        'Option3
        controlType = swPropertyManagerPageControlType_e.swControlType_Option
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        option3 = group1.AddControl(option3ID, controlType, "Sample Option3", leftAlign, options, "Radio Buttons")

        'List1
        controlType = swPropertyManagerPageControlType_e.swControlType_Listbox
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        list1 = group1.AddControl(list1ID, controlType, "Sample List", leftAlign, options, "Contains a list of items")
        If Not list1 Is Nothing Then
            Dim items() As String = New String() {"One Fish", "Two Fish", "Red Fish", "Blue Fish"}
            list1.Height = 50
            list1.AddItems(items)
        End If

        'Add Controls to Group2
        'Selection1
        controlType = swPropertyManagerPageControlType_e.swControlType_Selectionbox
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        selection1 = group2.AddControl(selection1ID, controlType, "Sample Selectionbox", leftAlign, options, "Displays items selected in main view")
        If Not selection1 Is Nothing Then
            Dim filter() As Integer = New Integer() {swSelectType_e.swSelVERTICES, swSelectType_e.swSelEDGES}
            selection1.Height = 50
            selection1.SetSelectionFilters(filter)
        End If

        'Num1
        controlType = swPropertyManagerPageControlType_e.swControlType_Numberbox
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        num1 = group2.AddControl(num1ID, controlType, "Sample Numberbox", leftAlign, options, "Allows numerical input")
        If Not num1 Is Nothing Then
            num1.SetRange(swNumberboxUnitType_e.swNumberBox_UnitlessDouble, 100.0, 0.0, 0.01, True)
            num1.Value = 50.0
        End If

        'Combo1
        controlType = swPropertyManagerPageControlType_e.swControlType_Combobox
        leftAlign = swPropertyManagerPageControlLeftAlign_e.swControlAlign_LeftEdge
        options = swAddControlOptions_e.swControlOptions_Enabled + swAddControlOptions_e.swControlOptions_Visible
        combo1 = group2.AddControl(combo1ID, controlType, "Sample Combobx", leftAlign, options, "Does Stuff")
        If Not combo1 Is Nothing Then
            Dim items() As String = New String() {"One Fish", "Two Fish", "Red Fish", "Blue Fish"}
            combo1.Height = 40
            combo1.Style = swPropMgrPageComboBoxStyle_e.swPropMgrPageComboBoxStyle_EditableText
            combo1.AddItems(items)
        End If
    End Sub

End Class

