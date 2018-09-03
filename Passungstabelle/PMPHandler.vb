Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished


Public Class PMPageHandler
    Implements PropertyManagerPage2Handler8


    Dim iSwApp As SldWorks
    Dim userAddin As SwAddin

    Function Init(ByVal sw As SldWorks, ByVal addin As SwAddin) As Integer
        iSwApp = sw
        userAddin = addin
    End Function

    'Implement these methods from the interface
    Sub AfterClose() Implements PropertyManagerPage2Handler8.AfterClose
        ''This function must contain code, even if it does nothing, to prevent the
        ''.NET runtime environment from doing garbage collection at the wrong time.
        Dim IndentSize As Integer
        IndentSize = System.Diagnostics.Debug.IndentSize
        System.Diagnostics.Debug.WriteLine(IndentSize)

    End Sub

    Sub OnCheckboxCheck(ByVal id As Integer, ByVal status As Boolean) Implements PropertyManagerPage2Handler8.OnCheckboxCheck

    End Sub

    Sub OnClose(ByVal reason As Integer) Implements PropertyManagerPage2Handler8.OnClose
        ''This function must contain code, even if it does nothing, to prevent the
        ''.NET runtime environment from doing garbage collection at the wrong time.
        Dim IndentSize As Integer
        IndentSize = System.Diagnostics.Debug.IndentSize
        System.Diagnostics.Debug.WriteLine(IndentSize)
    End Sub

    Sub OnComboboxEditChanged(ByVal id As Integer, ByVal text As String) Implements PropertyManagerPage2Handler8.OnComboboxEditChanged

    End Sub

    Function OnActiveXControlCreated(ByVal id As Integer, ByVal status As Boolean) As Integer Implements PropertyManagerPage2Handler8.OnActiveXControlCreated
        OnActiveXControlCreated = -1
    End Function

    Sub OnButtonPress(ByVal id As Integer) Implements PropertyManagerPage2Handler8.OnButtonPress

    End Sub

    Sub OnComboboxSelectionChanged(ByVal id As Integer, ByVal item As Integer) Implements PropertyManagerPage2Handler8.OnComboboxSelectionChanged

    End Sub

    Sub OnGroupCheck(ByVal id As Integer, ByVal status As Boolean) Implements PropertyManagerPage2Handler8.OnGroupCheck

    End Sub

    Sub OnGroupExpand(ByVal id As Integer, ByVal status As Boolean) Implements PropertyManagerPage2Handler8.OnGroupExpand

    End Sub

    Function OnHelp() As Boolean Implements PropertyManagerPage2Handler8.OnHelp
        OnHelp = True
    End Function

    Sub OnListboxSelectionChanged(ByVal id As Integer, ByVal item As Integer) Implements PropertyManagerPage2Handler8.OnListboxSelectionChanged

    End Sub

    Function OnNextPage() As Boolean Implements PropertyManagerPage2Handler8.OnNextPage
        OnNextPage = True
    End Function

    Sub OnNumberboxChanged(ByVal id As Integer, ByVal val As Double) Implements PropertyManagerPage2Handler8.OnNumberboxChanged

    End Sub

    Sub OnOptionCheck(ByVal id As Integer) Implements PropertyManagerPage2Handler8.OnOptionCheck

    End Sub

    Function OnPreviousPage() As Boolean Implements PropertyManagerPage2Handler8.OnPreviousPage
        OnPreviousPage = True
    End Function

    Sub OnSelectionboxCalloutCreated(ByVal id As Integer) Implements PropertyManagerPage2Handler8.OnSelectionboxCalloutCreated

    End Sub

    Sub OnSelectionboxCalloutDestroyed(ByVal id As Integer) Implements PropertyManagerPage2Handler8.OnSelectionboxCalloutDestroyed

    End Sub

    Sub OnSelectionboxFocusChanged(ByVal Id As Integer) Implements PropertyManagerPage2Handler8.OnSelectionboxFocusChanged

    End Sub

    Sub OnSelectionboxListChanged(ByVal id As Integer, ByVal item As Integer) Implements PropertyManagerPage2Handler8.OnSelectionboxListChanged

    End Sub

    Sub OnTextboxChanged(ByVal id As Integer, ByVal text As String) Implements PropertyManagerPage2Handler8.OnTextboxChanged

    End Sub

    Public Sub AfterActivation() Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.AfterActivation

    End Sub

    Public Function OnKeystroke(ByVal Wparam As Integer, ByVal Message As Integer, ByVal Lparam As Integer, ByVal Id As Integer) As Boolean Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnKeystroke

    End Function

    Public Sub OnPopupMenuItem(ByVal Id As Integer) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnPopupMenuItem

    End Sub

    Public Sub OnPopupMenuItemUpdate(ByVal Id As Integer, ByRef retval As Integer) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnPopupMenuItemUpdate

    End Sub

    Public Function OnPreview() As Boolean Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnPreview

    End Function

    Public Sub OnSliderPositionChanged(ByVal Id As Integer, ByVal Value As Double) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnSliderPositionChanged

    End Sub

    Public Sub OnSliderTrackingCompleted(ByVal Id As Integer, ByVal Value As Double) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnSliderTrackingCompleted

    End Sub

    Public Function OnSubmitSelection(ByVal Id As Integer, ByVal Selection As Object, ByVal SelType As Integer, ByRef ItemText As String) As Boolean Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnSubmitSelection

    End Function

    Public Function OnTabClicked(ByVal Id As Integer) As Boolean Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnTabClicked

    End Function

    Public Sub OnUndo() Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnUndo

    End Sub

    Public Sub OnWhatsNew() Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnWhatsNew

    End Sub

    Function OnWindowFromHandleControlCreated(ByVal Id As Integer, ByVal Status As Boolean) As Integer Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnWindowFromHandleControlCreated

    End Function

    Sub OnGainedFocus(ByVal Id As Integer) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnGainedFocus

    End Sub

    Sub OnListboxRMBUp(ByVal Id As Integer, ByVal PosX As Integer, ByVal PosY As Integer) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnListboxRMBUp

    End Sub

    Sub OnLostFocus(ByVal Id As Integer) Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnLostFocus

    End Sub

    Sub OnRedo() Implements SolidWorks.Interop.swpublished.IPropertyManagerPage2Handler8.OnRedo

    End Sub
End Class
