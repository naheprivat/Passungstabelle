Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst

'Base class for model event handlers
Public Class DocumentEventHandler
    Protected openModelViews As New Hashtable()
    Protected userAddin As SwAddin
    Protected iDocument As ModelDoc2
    Protected iSwApp As SldWorks

    Overridable Function Init(ByVal sw As SldWorks, ByVal addin As SwAddin, ByVal model As ModelDoc2) As Boolean
    End Function

    Overridable Function AttachEventHandlers() As Boolean
    End Function

    Overridable Function DetachEventHandlers() As Boolean
    End Function

    Function ConnectModelViews() As Boolean
        Dim iModelView As ModelView
        iModelView = iDocument.GetFirstModelView()

        While (Not iModelView Is Nothing)
            If Not openModelViews.Contains(iModelView) Then
                Dim mView As New DocView()
                mView.Init(userAddin, iModelView, Me)
                mView.AttachEventHandlers()
                openModelViews.Add(iModelView, mView)
            End If
            iModelView = iModelView.GetNext
        End While
    End Function

    Function DisconnectModelViews() As Boolean
        'Close events on all currently open docs
        Dim mView As DocView
        Dim key As ModelView
        Dim numKeys As Integer
        numKeys = openModelViews.Count
        Dim keys() As Object = New Object(numKeys - 1) {}

        'Remove all ModelView event handlers
        openModelViews.Keys.CopyTo(keys, 0)
        For Each key In keys
            mView = openModelViews.Item(key)
            mView.DetachEventHandlers()
            openModelViews.Remove(key)
            mView = Nothing
            key = Nothing
        Next
    End Function

    Sub DetachModelViewEventHandler(ByVal mView As ModelView)
        Dim docView As DocView
        If openModelViews.Contains(mView) Then
            docView = openModelViews.Item(mView)
            openModelViews.Remove(mView)
            mView = Nothing
            docView = Nothing
        End If

    End Sub
End Class

'Class to listen for Part Events
Public Class PartEventHandler
    Inherits DocumentEventHandler

    Dim WithEvents IPart As PartDoc

    Overrides Function Init(ByVal sw As SldWorks, ByVal addin As SwAddin, ByVal model As ModelDoc2) As Boolean
        userAddin = addin
        iPart = model
        iDocument = iPart
        iSwApp = sw
    End Function

    Overrides Function AttachEventHandlers() As Boolean
        ' AddHandler iPart.DestroyNotify, AddressOf Me.PartDoc_DestroyNotify
        ' AddHandler iPart.NewSelectionNotify, AddressOf Me.PartDoc_NewSelectionNotify
        ' ConnectModelViews()
    End Function

    Overrides Function DetachEventHandlers() As Boolean
        'RemoveHandler iPart.DestroyNotify, AddressOf Me.PartDoc_DestroyNotify
        'RemoveHandler iPart.NewSelectionNotify, AddressOf Me.PartDoc_NewSelectionNotify

        'DisconnectModelViews()

        'userAddin.DetachModelEventHandler(iDocument)
    End Function

    Function PartDoc_DestroyNotify() As Integer
        DetachEventHandlers()
    End Function

    'Function PartDoc_NewSelectionNotify() As Integer

    'End Function
End Class

'Class to listen for Assembly Events
Public Class AssemblyEventHandler
    Inherits DocumentEventHandler

    Dim WithEvents IAssembly As AssemblyDoc
    Dim swAddin As SwAddin

    Overrides Function Init(ByVal sw As SldWorks, ByVal addin As SwAddin, ByVal model As ModelDoc2) As Boolean
        userAddin = addin
        iAssembly = model
        iDocument = iAssembly
        iSwApp = sw
        swAddin = addin

    End Function

    Overrides Function AttachEventHandlers() As Boolean
        'AddHandler iAssembly.DestroyNotify, AddressOf Me.AssemblyDoc_DestroyNotify
        'AddHandler iAssembly.NewSelectionNotify, AddressOf Me.AssemblyDoc_NewSelectionNotify
        'AddHandler iAssembly.ComponentStateChangeNotify, AddressOf Me.AssemblyDoc_ComponentStateChangeNotify
        'AddHandler iAssembly.ComponentStateChangeNotify2, AddressOf Me.AssemblyDoc_ComponentStateChangeNotify2
        'AddHandler iAssembly.ComponentVisualPropertiesChangeNotify, AddressOf Me.AssemblyDoc_ComponentVisiblePropertiesChangeNotify
        'AddHandler iAssembly.ComponentDisplayStateChangeNotify, AddressOf Me.AssemblyDoc_ComponentDisplayStateChangeNotify



        ' ConnectModelViews()
    End Function

    Overrides Function DetachEventHandlers() As Boolean
        'RemoveHandler iAssembly.DestroyNotify, AddressOf Me.AssemblyDoc_DestroyNotify
        'RemoveHandler iAssembly.NewSelectionNotify, AddressOf Me.AssemblyDoc_NewSelectionNotify
        'RemoveHandler iAssembly.ComponentStateChangeNotify, AddressOf Me.AssemblyDoc_ComponentStateChangeNotify
        'RemoveHandler iAssembly.ComponentStateChangeNotify2, AddressOf Me.AssemblyDoc_ComponentStateChangeNotify2
        'RemoveHandler iAssembly.ComponentVisualPropertiesChangeNotify, AddressOf Me.AssemblyDoc_ComponentVisiblePropertiesChangeNotify
        'RemoveHandler iAssembly.ComponentDisplayStateChangeNotify, AddressOf Me.AssemblyDoc_ComponentDisplayStateChangeNotify

        ' DisconnectModelViews()

        'userAddin.DetachModelEventHandler(iDocument)
    End Function

    Function AssemblyDoc_DestroyNotify() As Integer
        DetachEventHandlers()
    End Function

    'Function AssemblyDoc_NewSelectionNotify() As Integer

    'End Function

    'Protected Function ComponentStateChange(ByVal componentModel As Object, Optional ByVal newCompState As Short = swComponentSuppressionState_e.swComponentResolved) As Integer

    '    Dim modDoc As ModelDoc2 = componentModel
    '    Dim newState As swComponentSuppressionState_e = newCompState


    '    Select Case newState

    '        Case swComponentSuppressionState_e.swComponentFullyResolved, swComponentSuppressionState_e.swComponentResolved

    '            If ((Not modDoc Is Nothing) AndAlso Not Me.swAddin.OpenDocumentsTable.Contains(modDoc)) Then
    '                Me.swAddin.AttachModelDocEventHandler(modDoc)
    '            End If

    '            Exit Select

    '    End Select

    'End Function

    ''attach events to a component if it becomes resolved
    'Public Function AssemblyDoc_ComponentStateChangeNotify(ByVal componentModel As Object, ByVal oldCompState As Short, ByVal newCompState As Short) As Integer

    '    Return ComponentStateChange(componentModel, newCompState)

    'End Function

    ''attach events to a component if it becomes resolved
    'Public Function AssemblyDoc_ComponentStateChangeNotify2(ByVal componentModel As Object, ByVal CompName As String, ByVal oldCompState As Short, ByVal newCompState As Short) As Integer

    '    Return ComponentStateChange(componentModel, newCompState)

    'End Function


    'Public Function AssemblyDoc_ComponentVisiblePropertiesChangeNotify(ByVal swObject As Object) As Integer

    '    Dim component As Component2
    '    Dim modDoc As ModelDoc2

    '    component = swObject

    '    modDoc = component.GetModelDoc

    '    Return ComponentStateChange(modDoc)

    'End Function


    'Public Function AssemblyDoc_ComponentDisplayStateChangeNotify(ByVal swObject As Object) As Integer

    '    Dim component As Component2
    '    Dim modDoc As ModelDoc2

    '    component = swObject

    '    modDoc = component.GetModelDoc

    '    Return ComponentStateChange(modDoc)

    'End Function


End Class

'Class to listen for Drawing Events
Public Class DrawingEventHandler
    Inherits DocumentEventHandler

    Dim WithEvents IDrawing As DrawingDoc


    Overrides Function Init(ByVal sw As SldWorks, ByVal addin As SwAddin, ByVal model As ModelDoc2) As Boolean
        userAddin = addin
        iDrawing = model
        iDocument = IDrawing
        iSwApp = sw
    End Function

    Overrides Function AttachEventHandlers() As Boolean
        'AddHandler iDrawing.DestroyNotify, AddressOf Me.DrawingDoc_DestroyNotify
        'AddHandler IDrawing.NewSelectionNotify, AddressOf Me.DrawingDoc_NewSelectionNotify
        If userAddin.eventgesteuert = True Then
            AddHandler IDrawing.RegenPostNotify, AddressOf Me.DrawingDoc_RegenPostNotify
        End If
        '*ConnectModelViews()
    End Function

    Overrides Function DetachEventHandlers() As Boolean
        'RemoveHandler iDrawing.DestroyNotify, AddressOf Me.DrawingDoc_DestroyNotify
        'RemoveHandler IDrawing.NewSelectionNotify, AddressOf Me.DrawingDoc_NewSelectionNotify
        If userAddin.eventgesteuert = True Then
            RemoveHandler IDrawing.RegenPostNotify, AddressOf Me.DrawingDoc_RegenPostNotify
        End If
        'DisconnectModelViews()

        userAddin.DetachModelEventHandler(iDocument)
    End Function

    Function DrawingDoc_DestroyNotify() As Integer
        DetachEventHandlers()
    End Function

    'Function DrawingDoc_NewSelectionNotify() As Integer

    'End Function

    Function DrawingDoc_RegenPostNotify() As Integer
        Dim Fittable As New Passungstabelle
        

        Fittable.Main(iSwApp, IDrawing)
        Fittable = Nothing
        Return 0
    End Function

End Class

'Class for handling ModelView events
Public Class DocView

    Dim WithEvents IModelView As ModelView
    Dim userAddin As SwAddin
    Dim parentDoc As DocumentEventHandler

    Function Init(ByVal addin As SwAddin, ByVal mView As ModelView, ByVal parent As DocumentEventHandler) As Boolean
        userAddin = addin
        iModelView = mView
        parentDoc = parent
    End Function

    Function AttachEventHandlers() As Boolean
        'AddHandler iModelView.DestroyNotify2, AddressOf Me.ModelView_DestroyNotify2
        'AddHandler iModelView.RepaintNotify, AddressOf Me.ModelView_RepaintNotify
    End Function

    Function DetachEventHandlers() As Boolean
        'RemoveHandler iModelView.DestroyNotify2, AddressOf Me.ModelView_DestroyNotify2
        'RemoveHandler iModelView.RepaintNotify, AddressOf Me.ModelView_RepaintNotify

        'parentDoc.DetachModelViewEventHandler(IModelView)
    End Function

    Function ModelView_DestroyNotify2(ByVal destroyTYpe As Integer) As Integer
        DetachEventHandlers()
    End Function

    'Function ModelView_RepaintNotify(ByVal repaintTYpe As Integer) As Integer

    'End Function
End Class
