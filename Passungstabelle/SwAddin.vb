Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.InteropServices

Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports SolidWorks.Interop.swpublished
Imports SolidWorksTools
Imports SolidWorksTools.File

Imports System.Collections.Generic
Imports System.Diagnostics

<Guid("09a29164-06dc-4670-bfb9-3243404d59ca")>
<ComVisible(True)>
<SwAddin(
        Description:="Passungstabelle Add In für SolidWorks",
        Title:="Passungstabelle",
        LoadAtStartup:=True
        )>
Public Class SwAddin
    Implements SolidWorks.Interop.swpublished.SwAddin

#Region "Local Variables"
    Dim WithEvents ISwApp As SldWorks
    Dim iCmdMgr As ICommandManager
    Dim addinID As Integer
    Dim openDocs As Hashtable
    Dim SwEventPtr As SldWorks
    'Dim ppage As UserPMPage
    Dim iBmp As BitmapHandler


    Public Const mainCmdGroupID As Integer = 0
    Public Const mainItemID1 As Integer = 0
    Public Const mainItemID2 As Integer = 1
    Public Const mainItemID3 As Integer = 2
    Public Const flyoutGroupID As Integer = 91

    Public eventgesteuert As Boolean = False

    ' Public Properties
    ReadOnly Property SwApp() As SldWorks
        Get
            Return iSwApp
        End Get
    End Property

    ReadOnly Property CmdMgr() As ICommandManager
        Get
            Return iCmdMgr
        End Get
    End Property

    ReadOnly Property OpenDocumentsTable() As Hashtable
        Get
            Return openDocs
        End Get
    End Property
#End Region

#Region "SolidWorks Registration"

    <ComRegisterFunction()> Public Shared Sub RegisterFunction(ByVal t As Type)

        ' Get Custom Attribute: SwAddinAttribute
        Dim attributes() As Object
        Dim SWattr As SwAddinAttribute = Nothing

        attributes = System.Attribute.GetCustomAttributes(GetType(SwAddin), GetType(SwAddinAttribute))

        If attributes.Length > 0 Then
            SWattr = DirectCast(attributes(0), SwAddinAttribute)
        End If
        Try
            Dim hklm As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
            Dim hkcu As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            Dim keyname As String = "SOFTWARE\SolidWorks\Addins\{" + t.GUID.ToString() + "}"
            Dim addinkey As Microsoft.Win32.RegistryKey = hklm.CreateSubKey(keyname)
            addinkey.SetValue(Nothing, 0)
            addinkey.SetValue("Description", SWattr.Description)
            addinkey.SetValue("Title", SWattr.Title)

            keyname = "Software\SolidWorks\AddInsStartup\{" + t.GUID.ToString() + "}"
            addinkey = hkcu.CreateSubKey(keyname)
            addinkey.SetValue(Nothing, SWattr.LoadAtStartup, Microsoft.Win32.RegistryValueKind.DWord)
        Catch nl As System.NullReferenceException
            Console.WriteLine("There was a problem registering this dll: SWattr is null.\n " & nl.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: SWattr is null.\n" & nl.Message)
        Catch e As System.Exception
            Console.WriteLine("There was a problem registering this dll: " & e.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem registering this dll: " & e.Message)
        End Try
    End Sub

    <ComUnregisterFunction()> Public Shared Sub UnregisterFunction(ByVal t As Type)
        Try
            Dim hklm As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
            Dim hkcu As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser

            Dim keyname As String = "SOFTWARE\SolidWorks\Addins\{" + t.GUID.ToString() + "}"
            hklm.DeleteSubKey(keyname)

            keyname = "Software\SolidWorks\AddInsStartup\{" + t.GUID.ToString() + "}"
            hkcu.DeleteSubKey(keyname)
        Catch nl As System.NullReferenceException
            Console.WriteLine("There was a problem unregistering this dll: SWattr is null.\n " & nl.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: SWattr is null.\n" & nl.Message)
        Catch e As System.Exception
            Console.WriteLine("There was a problem unregistering this dll: " & e.Message)
            System.Windows.Forms.MessageBox.Show("There was a problem unregistering this dll: " & e.Message)
        End Try

    End Sub

#End Region

#Region "ISwAddin Implementation"

    Function ConnectToSW(ByVal ThisSW As Object, ByVal Cookie As Integer) As Boolean Implements SolidWorks.Interop.swpublished.SwAddin.ConnectToSW
        Dim pt As New Passungstabelle
        Dim macro_pfad As String = ""


        ISwApp = ThisSW
        addinID = Cookie

        'Ini Datei lesen
        macro_pfad = GetAppPath()
        pt.Macro_pfad = macro_pfad

        'Nur wenn die Setup-Datei gefunden wird
        If pt.Check_for_setup() Then
            'Kann auch der Wert für die Event-Steuerung gesetz werden
            eventgesteuert = pt.Attr_generell("Eventgesteuert")
        End If

        pt = Nothing

        ' Setup callbacks
        ISwApp.SetAddinCallbackInfo(0, Me, addinID)

        ' Setup the Command Manager
        iCmdMgr = ISwApp.GetCommandManager(Cookie)
        AddCommandMgr()

        'Setup the Event Handlers
        SwEventPtr = ISwApp
        openDocs = New Hashtable
        AttachEventHandlers()

        ConnectToSW = True
    End Function

    Function DisconnectFromSW() As Boolean Implements SolidWorks.Interop.swpublished.SwAddin.DisconnectFromSW

        RemoveCommandMgr()
        'RemovePMP()
        DetachEventHandlers()

        System.Runtime.InteropServices.Marshal.ReleaseComObject(iCmdMgr)
        iCmdMgr = Nothing
        System.Runtime.InteropServices.Marshal.ReleaseComObject(iSwApp)
        iSwApp = Nothing
        'The addin _must_ call GC.Collect() here in order to retrieve all managed code pointers 
        GC.Collect()
        GC.WaitForPendingFinalizers()

        GC.Collect()
        GC.WaitForPendingFinalizers()

        DisconnectFromSW = True
    End Function
#End Region

#Region "UI Methods"
    Public Sub AddCommandMgr()

        Dim cmdGroup As ICommandGroup

        If iBmp Is Nothing Then
            iBmp = New BitmapHandler()
        End If

        Dim thisAssembly As Assembly

        Dim cmdIndex0 As Integer, cmdIndex1 As Integer, cmdIndex2 As Integer
        Dim Title As String = "Passungstabelle"
        Dim ToolTip As String = "Passungstabelle"


        Dim docTypes() As Integer = {swDocumentTypes_e.swDocDRAWING}

        thisAssembly = System.Reflection.Assembly.GetAssembly(Me.GetType())

        Dim cmdGroupErr As Integer = 0
        Dim ignorePrevious As Boolean = False

        Dim registryIDs As Object = Nothing
        Dim getDataResult As Boolean = iCmdMgr.GetGroupDataFromRegistry(mainCmdGroupID, registryIDs)

        Dim knownIDs As Integer() = New Integer(2) {mainItemID1, mainItemID2, mainItemID3}

        If getDataResult Then
            If Not CompareIDs(registryIDs, knownIDs) Then 'if the IDs don't match, reset the commandGroup
                ignorePrevious = True
            End If
        End If

        cmdGroup = iCmdMgr.CreateCommandGroup2(mainCmdGroupID, Title, ToolTip, "", -1, ignorePrevious, cmdGroupErr)
        If cmdGroup Is Nothing Or thisAssembly Is Nothing Then
            Throw New NullReferenceException()
        End If

        cmdGroup.LargeIconList = iBmp.CreateFileFromResourceBitmap("Passungstabellen.MainLarge.png", thisAssembly)
        cmdGroup.SmallIconList = iBmp.CreateFileFromResourceBitmap("Passungstabellen.MainSmall.png", thisAssembly)

        Dim menuToolbarOption As Integer = swCommandItemType_e.swMenuItem Or swCommandItemType_e.swToolbarItem

        cmdIndex0 = cmdGroup.AddCommandItem2("Passungstabelle", -1, "Passungstabelle", "Passungstabelle", 0, "ErstelleTabelle", "", mainItemID1, menuToolbarOption)
        cmdIndex1 = cmdGroup.AddCommandItem2("Passungstabelle Setup", -1, "Passungstabelle Setup", "Passungstabelle Setup", 1, "PassungsTabelleSetup", "", mainItemID2, menuToolbarOption)
        cmdIndex2 = cmdGroup.AddCommandItem2("Passungstabelle Hilfe", -1, "Passungstabelle Hilfe", "Passungstabelle Hilfe", 2, "PassungsTabelleHilfe", "", mainItemID3, menuToolbarOption)

        cmdGroup.HasToolbar = True
        cmdGroup.HasMenu = True
        cmdGroup.Activate()

        For Each docType As Integer In docTypes
            Dim cmdTab As ICommandTab = iCmdMgr.GetCommandTab(docType, Title)
            Dim bResult As Boolean

            If Not cmdTab Is Nothing And Not getDataResult Or ignorePrevious Then 'if tab exists, but we have ignored the registry info, re-create the tab.  Otherwise the ids won't matchup and the tab will be blank
                Dim res As Boolean = iCmdMgr.RemoveCommandTab(cmdTab)
                cmdTab = Nothing
            End If

            If cmdTab Is Nothing Then
                cmdTab = iCmdMgr.AddCommandTab(docType, Title)

                Dim cmdBox As CommandTabBox = cmdTab.AddCommandTabBox

                Dim cmdIDs(2) As Integer
                Dim TextType(2) As Integer

                cmdIDs(0) = cmdGroup.CommandID(cmdIndex0)
                TextType(0) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal

                cmdIDs(1) = cmdGroup.CommandID(cmdIndex1)
                TextType(1) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal

                cmdIDs(2) = cmdGroup.CommandID(cmdIndex2)
                TextType(2) = swCommandTabButtonTextDisplay_e.swCommandTabButton_TextHorizontal

                bResult = cmdBox.AddCommands(cmdIDs, TextType)

                Dim cmdBox1 As CommandTabBox = cmdTab.AddCommandTabBox()
                ReDim cmdIDs(1)
                ReDim TextType(1)

                bResult = cmdBox1.AddCommands(cmdIDs, TextType)
            End If
        Next

        thisAssembly = Nothing
    End Sub

    Public Sub RemoveCommandMgr()
        Try
            iBmp.Dispose()
            iCmdMgr.RemoveCommandGroup(mainCmdGroupID)
            iCmdMgr.RemoveFlyoutGroup(flyoutGroupID)
        Catch e As Exception
        End Try
    End Sub

    Function CompareIDs(ByVal storedIDs() As Integer, ByVal addinIDs() As Integer) As Boolean

        Dim storeList As New List(Of Integer)(storedIDs)
        Dim addinList As New List(Of Integer)(addinIDs)

        addinList.Sort()
        storeList.Sort()

        If Not addinList.Count = storeList.Count Then
            Return False
        Else
            For i As Integer = 0 To addinList.Count - 1
                If Not addinList(i) = storeList(i) Then

                    Return False
                End If
            Next
        End If

        Return True
    End Function
#End Region

#Region "Event Methods"
    Sub AttachEventHandlers()
        AttachSWEvents()

        'Listen for events on all currently open docs
        AttachEventsToAllDocuments()
    End Sub

    Sub DetachEventHandlers()
        DetachSWEvents()

        'Close events on all currently open docs
        Dim docHandler As DocumentEventHandler
        Dim key As ModelDoc2
        Dim numKeys As Integer
        numKeys = openDocs.Count
        If numKeys > 0 Then
            Dim keys() As Object = New Object(numKeys - 1) {}

            'Remove all document event handlers
            openDocs.Keys.CopyTo(keys, 0)
            For Each key In keys
                docHandler = openDocs.Item(key)
                docHandler.DetachEventHandlers() 'This also removes the pair from the hash
                docHandler = Nothing
                key = Nothing
            Next
        End If
    End Sub

    Sub AttachSWEvents()
        Try
            AddHandler ISwApp.FileNewNotify2, AddressOf Me.SldWorks_FileNewNotify2
            AddHandler ISwApp.FileOpenPostNotify, AddressOf Me.SldWorks_FileOpenPostNotify
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    Sub DetachSWEvents()
        Try
            RemoveHandler ISwApp.FileNewNotify2, AddressOf Me.SldWorks_FileNewNotify2
            RemoveHandler ISwApp.FileOpenPostNotify, AddressOf Me.SldWorks_FileOpenPostNotify
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub

    Sub AttachEventsToAllDocuments()
        Dim modDoc As ModelDoc2
        modDoc = iSwApp.GetFirstDocument()
        While Not modDoc Is Nothing
            If Not openDocs.Contains(modDoc) Then
                AttachModelDocEventHandler(modDoc)
            End If
            modDoc = modDoc.GetNext()
        End While
    End Sub

    Function AttachModelDocEventHandler(ByVal modDoc As ModelDoc2) As Boolean
        If modDoc Is Nothing Then
            Return False
        End If
        Dim docHandler As DocumentEventHandler = Nothing

        If Not openDocs.Contains(modDoc) Then
            Select Case modDoc.GetType
                Case swDocumentTypes_e.swDocPART
                    docHandler = New PartEventHandler()
                Case swDocumentTypes_e.swDocASSEMBLY
                    docHandler = New AssemblyEventHandler()
                Case swDocumentTypes_e.swDocDRAWING
                    docHandler = New DrawingEventHandler()
            End Select

            docHandler.Init(iSwApp, Me, modDoc)
            docHandler.AttachEventHandlers()
            openDocs.Add(modDoc, docHandler)
        End If
    End Function

    Sub DetachModelEventHandler(ByVal modDoc As ModelDoc2)
        Dim docHandler As DocumentEventHandler
        docHandler = openDocs.Item(modDoc)
        openDocs.Remove(modDoc)
        modDoc = Nothing
        docHandler = Nothing
    End Sub
#End Region

#Region "Event Handlers"

    Function SldWorks_FileNewNotify2(ByVal newDoc As Object, ByVal doctype As Integer, ByVal templateName As String) As Integer
        AttachEventsToAllDocuments()
    End Function

    Function SldWorks_FileOpenPostNotify(ByVal FileName As String) As Integer
        AttachEventsToAllDocuments()
    End Function

#End Region

#Region "UI Callbacks"
    Sub PassungsTabelleSetup()
        Dim setupdlg As New SetupDialog With {.Swapp = SwApp}

        setupdlg.ShowDialog()
        setupdlg.Close()

        setupdlg = Nothing
    End Sub

    Sub PassungsTabelleHilfe()
        Dim p As New Process()
        Dim psi As New ProcessStartInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location) & "\Help\HtmlHelp\Willkommen.html")
        psi.Verb = "open"
        p.StartInfo = psi
        p.Start()
    End Sub

    Sub ErstelleTabelle()
        Dim Fittable As New Passungstabelle
        Fittable.Main(ISwApp)
        Fittable = Nothing
    End Sub

    Public Function GetAppPath() As String
        Dim path As String
        path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location)
        GetAppPath = path
    End Function

#End Region

End Class

