Imports SolidWorks.Interop.sldworks
Imports SolidWorks.Interop.swconst
Imports System.Collections.Generic
Imports System.Drawing

Imports System.Windows.Forms
Imports System.Linq


Public Class Passungstabelle_Tabelle
    Property Attr_generell As New Dictionary(Of String, String)
    Property Attr_Übersetzungen As New Dictionary(Of String, Dictionary(Of String, String))
    Property Attr_Tabelle As New Dictionary(Of String, String)
    Property Attr_Sprache As String
    Property Einfügepunkt As Double()
    Property Einfügepunktposition As Integer

    Property TabellenZeilen As New List(Of Passungstabelle_Zeile)
    Property TabellenZeilengefiltert As IEnumerable(Of Passungstabelle_Zeile)
    Property Tabellenzeilencount As Integer
    Property TabellenSpaltenCount As Integer

    Property HeadStyle As TextFormat
    Property RowStyle As TextFormat

    Property Log As LogFile


    Dim SpaltenBreite As New Dictionary(Of String, Integer) From {{"Spalte1", 0}, {"Spalte2", 0}, {"Spalte3", 0}, {"Spalte4", 0}, {"Spalte5", 0}, {"Spalte6", 0}, {"Spalte7", 0}, {"Spalte8", 0}}
    Dim RundenAuf As Integer
    Dim SchichtStärke As Double
    Dim swdraw As DrawingDoc
    Dim fac As Double

    Dim HeadColor As String
    Dim RowColor As String

    'Dim Log As LogFile = Nothing

    Sub New()
        tabellenzeilencount = 0
        tabellenSpaltenCount = 0
    End Sub

    'Tabelle initialisieren
    Sub New(iAttr_generell As Dictionary(Of String, String), iAttr_Tabelle As Dictionary(Of String, String), iAttr_Übersetzungen As Dictionary(Of String, Dictionary(Of String, String)))
        Attr_generell = iAttr_generell
        Attr_Übersetzungen = iAttr_Übersetzungen
        Attr_Tabelle = iAttr_Tabelle
        Attr_Sprache = Attr_Tabelle("HeaderLanguage")
        RundenAuf = Attr_generell("RundenAuf")
        SchichtStärke = Attr_generell("SchichtStärke")
        fac = 1000.0
        Log = New LogFile(Attr_generell)
    End Sub

    'Ermittelt die Passungen aus der Ansicht
    'Function GetViewDimensionALT(swView As SolidWorks.Interop.sldworks.View) As Boolean
    '    Dim dispdim As DisplayDimension
    '    Dim dimen As Dimension
    '    Dim prefix As String = ""
    '    Dim holeVariables As Object()

    '    dispdim = swView.GetFirstDisplayDimension5

    '    'So lange Bemaßungen gefunden werden
    '    While Not dispdim Is Nothing
    '        'Dimension ermittel
    '        'dort befinden sich die Passungsangabe und Toleranzen
    '        dimen = dispdim.GetDimension2(0)
    '        'Wenn es sich um einen Durchmsser handelt dann wird dem Maß ein Ø Symbol vorangestellt
    '        If dispdim.GetType2 = swDimensionType_e.swDiameterDimension Then
    '            prefix = "Ø"
    '        End If

    '        'Passung und Toleranzen ermitteln
    '        Gettolfromdim(dimen, prefix)

    '        'Prüfung ob es sich um eine Bohrungsbeschreibung handelt
    '        holeVariables = dispdim.GetHoleCalloutVariables
    '        'Wenn Bohrungs-Beschreibungs-Variablen gefunden wurden
    '        If Not holeVariables Is Nothing Then
    '            gettolfromcalloutvar(prefix, holeVariables)
    '        End If


    '        'Nächste Bemaßung
    '        dispdim = dispdim.GetNext5
    '    End While

    '    GetViewDimensionALT = True
    'End Function

    Function GetViewDimension(swView As SolidWorks.Interop.sldworks.View) As Boolean
        Dim dispdim As DisplayDimension
        Dim dimen As Dimension
        Dim prefix As String = ""
        Dim holeVariables As Object()
        Dim a1 As Object
        Dim counter As Long

        'dispdim = swView.GetFirstDisplayDimension5

        a1 = swView.GetDisplayDimensions

        If Not (a1 Is Nothing) Then
            counter = UBound(a1)
            'So lange Bemaßungen gefunden werden
            For i = 0 To counter
                dispdim = a1(i)
                'Dimension ermittel
                'dort befinden sich die Passungsangabe und Toleranzen
                dimen = dispdim.GetDimension2(0)
                'Wenn es sich um einen Durchmsser handelt dann wird dem Maß ein Ø Symbol vorangestellt
                If dispdim.Type2 = swDimensionType_e.swDiameterDimension Then
                    prefix = "Ø"
                End If

                'Passung und Toleranzen ermitteln
                Gettolfromdim(dimen, prefix)

                'Prüfung ob es sich um eine Bohrungsbeschreibung handelt
                holeVariables = dispdim.GetHoleCalloutVariables

                'Wenn Bohrungs-Beschreibungs-Variablen gefunden wurden
                If Not holeVariables Is Nothing Then
                    gettolfromcalloutvar(prefix, holeVariables)
                End If
            Next
        End If
        GetViewDimension = True
    End Function

    ' ermittelt die Passung und Toleranzen aus dem Dimension-Objekt
    Private Function Gettolfromdim(dimen As Dimension, prefix As String) As Boolean
        Dim temp As New Passungstabelle_Zeile
        Dim temp1 As New Passungstabelle_Zeile
        Dim tempz As New List(Of Passungstabelle_Zeile)
        Dim tol As DimensionTolerance
        'Dim fac As Double
        Dim flag As Boolean 'Marker um zu erkennen ob Passung manuell eingetragen wurde

        'Toleranz holen
        tol = dimen.Tolerance
        flag = False


        'Nur wenn es sich auch um eine Passungsangabe handelt, wird ausgewertet
        If tol.Type = swTolType_e.swTolFIT Or tol.Type = swTolType_e.swTolFITTOLONLY Or tol.Type = swTolType_e.swTolFITWITHTOL Then

            'Umrechnungsfaktor ermitteln
            'normalerweise gibt SWX die Werte in Meter zurück
            'fac = GetDimFactor(dimen)

            'Prüfung ob auch Passungswerte eingetragen sind
            'Könnte ja auch sein, dass als Toleranzttyp Passung eingestellt ist und keine Passung gewählt wurde
            'Wenn kein Passungswert gefunden wird, dann Abbruch der Funktion
            If Not CheckForFitValues(tol.GetHoleFitValue, tol.GetShaftFitValue, dimen.GetSystemValue2("") * fac) Then
                Gettolfromdim = False
                Exit Function
            End If

            'temp.HoleFit = tol.GetHoleFitValue
            'temp.ShaftFit = tol.GetShaftFitValue

            'Toleranzen von Bohrungspassung
            If tol.GetHoleFitValue <> "" And tol.GetShaftFitValue = "" Then
                temp = SetColumnsFromDim(dimen, True)
                temp.prefix = prefix
                'wenn die Passungswerte nicht gewählt wurden sondern manuel eingetragen wurden
                If tol.GetMinValue = 0.0 And tol.GetMaxValue = 0.0 Then
                    'tempz = Gettolfromfit(dimen)
                    CheckForFitToleranceValues(temp)
                    temp = Nothing
                Else
                    tempz.Add(temp)
                    temp1 = Nothing
                End If
                'Toleranzen von Wellenpassung
            ElseIf tol.GetShaftFitValue <> "" And tol.GetHoleFitValue = "" Then
                temp = SetColumnsFromDim(dimen, False)
                temp.prefix = prefix

                If tol.GetMinValue = 0.0 And tol.GetMaxValue = 0.0 Then
                    'tempz = Gettolfromfit(dimen)
                    CheckForFitToleranceValues(temp)
                    temp = Nothing
                Else
                    tempz.Add(temp)
                    temp1 = Nothing
                End If
                'Prüfung ob Doppelpassung angegeben z.B. H7/g6
            ElseIf tol.GetHoleFitValue <> "" And tol.GetShaftFitValue <> "" Then
                temp = SetColumnsFromDim(dimen, True)
                temp.Prefix = prefix

                '* Bohungswerte ermitteln
                ' tol.SetFitValues(temp.Zeile("Passung"), "")
                If temp.Zeile("ToleranzO") = 0.0 And temp.Zeile("ToleranzU") = 0.0 Then flag = True


                '* wellenwerte ermitteln
                temp1 = SetColumnsFromDim(dimen, False)
                temp1.Prefix = prefix
                'tol.SetFitValues("", temp1.Zeile("Passung"))
                If temp.Zeile("ToleranzO") = 0.0 And temp.Zeile("ToleranzU") = 0.0 Then flag = True

                '* Alten Wert wieder setzen
                tol.SetFitValues(temp.Zeile("Passung"), temp1.Zeile("Passung"))

                If flag = True Then
                    'tempz = Gettolfromfit(dimen)
                    If CheckForFitToleranceValues(temp) Then
                        tempz.Add(temp)
                    End If
                    If CheckForFitToleranceValues(temp1) Then
                        tempz.Add(temp1)
                    End If
                Else
                    tempz.Add(temp)
                    tempz.Add(temp1)
                End If
            End If

            For Each temp In tempz
                If Not temp Is Nothing Then
                    TabellenZeilen.Add(temp)
                    Log.WriteInfo("Bemaßung: " & temp.Zeile("Maß").ToString & Chr(9) & temp.Zeile("Passung"), False)
                    temp = Nothing
                    Tabellenzeilencount = Tabellenzeilencount + 1
                End If
            Next
            Gettolfromdim = True
        Else
            Gettolfromdim = False
        End If
    End Function

    ' ermittelt die Toleranzen, wenn die Passungswerte nicht gewählt wurden 
    ' sondern manuel eingetragen wurden
    Private Function Gettolfromfit(dimen As Dimension) As List(Of Passungstabelle_Zeile)
        Dim temp As New Passungstabelle_Zeile
        Dim temp1 As New Passungstabelle_Zeile
        Dim tempz As New List(Of Passungstabelle_Zeile)
        Dim tol As DimensionTolerance
        Dim fac As Double

        '
        tol = dimen.Tolerance
        fac = GetDimFactor(dimen)
        temp.Masz = dimen.GetSystemValue2("") * fac
        temp.HoleFit = tol.GetHoleFitValue
        temp.ShaftFit = tol.GetShaftFitValue

        'Prüfung ob auch Passungswerte eingetragen sind
        'Könnte ja auch sein, dass als Toleranzttyp Passung eingestellt ist und keine Passung gewählt wurde
        If Not CheckForFitValues(tol.GetHoleFitValue, tol.GetShaftFitValue, dimen.GetSystemValue2("") * fac) Then
            tempz = Nothing
            Gettolfromfit = tempz
            Exit Function
        End If

        'Toleranzen von Bohrungspassung
        If temp.HoleFit <> "" And temp.ShaftFit = "" Then
            tol.SetFitValues(temp.HoleFit, "")
            temp.LowerHTolerance = tol.GetMinValue * fac
            temp.UpperHTolerance = tol.GetMaxValue * fac

            'Toleranzen von Wellenpassung
        ElseIf temp.ShaftFit <> "" And temp.HoleFit = "" Then
            tol.SetFitValues("", temp.ShaftFit)
            temp.LowerSTolerance = tol.GetMinValue * fac
            temp.UpperSTolerance = tol.GetMaxValue * fac
        ElseIf temp.HoleFit <> "" And temp.ShaftFit <> "" Then
            '* Bohungswerte ermitteln
            tol.SetFitValues(temp.HoleFit, "")
            temp.LowerHTolerance = tol.GetMinValue * fac
            temp.UpperHTolerance = tol.GetMaxValue * fac
            '* wellenwerte ermitteln
            tol.SetFitValues("", temp.ShaftFit)
            temp.LowerSTolerance = tol.GetMinValue * fac
            temp.UpperSTolerance = tol.GetMaxValue * fac
            '* Alten Wert wieder setzen
            tol.SetFitValues(temp.HoleFit, temp.ShaftFit)
            '*Aufteilung Wellen/ Bohrungspassung auf zwei Zeilen
            temp1 = temp.Clone
            temp.ShaftFit = ""
            temp.LowerSTolerance = 0.0
            temp.UpperSTolerance = 0.0
            temp1.HoleFit = ""
            temp1.LowerHTolerance = 0.0
            temp1.UpperHTolerance = 0.0
        End If
        If Not IsNothing(temp) Then
            If CheckForFitToleranceValues(temp) Then tempz.Add(temp)
        End If
        If Not IsNothing(temp1) Then
            If CheckForFitToleranceValues(temp1) Then tempz.Add(temp1)
        End If
        Gettolfromfit = tempz
    End Function

    ' ermittelt die Toleranzen, wenn die Passungswerte nicht gewählt wurden 
    ' sondern manuel eingetragen wurden
    Private Function GettolfromfitCallOut(swCalloutVariable As CalloutVariable, swCalloutLengthVariable As CalloutLengthVariable) As List(Of Passungstabelle_Zeile)
        Dim temp As New Passungstabelle_Zeile
        Dim temp1 As New Passungstabelle_Zeile
        Dim tempz As New List(Of Passungstabelle_Zeile)
        'Dim tol As DimensionTolerance
        Dim fac As Double

        '
        'tol = dimen.Tolerance
        'fac = GetDimFactor(dimen)
        fac = 1000
        temp.Masz = swCalloutLengthVariable.Length * fac
        temp.HoleFit = swCalloutVariable.HoleFit
        temp.ShaftFit = swCalloutVariable.ShaftFit

        'Prüfung ob auch Passungswerte eingetragen sind
        'Könnte ja auch sein, dass als Toleranzttyp Passung eingestellt ist und keine Passung gewählt wurde
        If Not CheckForFitValues(swCalloutVariable.HoleFit, swCalloutVariable.ShaftFit, swCalloutLengthVariable.Length * fac) Then
            tempz = Nothing
            GettolfromfitCallOut = tempz
            Exit Function
        End If

        'Toleranzen von Bohrungspassung
        If temp.HoleFit <> "" And temp.ShaftFit = "" Then
            swCalloutVariable.HoleFit = temp.HoleFit
            temp.LowerHTolerance = swCalloutVariable.ToleranceMin * fac
            temp.UpperHTolerance = swCalloutVariable.ToleranceMax * fac
            'Toleranzen von Wellenpassung
        ElseIf temp.ShaftFit <> "" And temp.HoleFit = "" Then
            swCalloutVariable.ShaftFit = temp.ShaftFit
            temp.LowerSTolerance = swCalloutVariable.ToleranceMin * fac
            temp.UpperSTolerance = swCalloutVariable.ToleranceMin * fac
        ElseIf temp.HoleFit <> "" And temp.ShaftFit <> "" Then
            '* Bohungswerte ermitteln
            swCalloutVariable.HoleFit = temp.HoleFit
            temp.LowerHTolerance = swCalloutVariable.ToleranceMin * fac
            temp.UpperHTolerance = swCalloutVariable.ToleranceMax * fac
            '* wellenwerte ermitteln
            swCalloutVariable.sh = temp.ShaftFit
            temp.LowerSTolerance = swCalloutVariable.ToleranceMin * fac
            temp.UpperSTolerance = swCalloutVariable.ToleranceMin * fac
            '* Alten Wert wieder setzen
            swCalloutVariable.HoleFit = temp.HoleFit
            swCalloutVariable.ShaftFit = temp.ShaftFit
            '*Aufteilung Wellen/ Bohrungspassung auf zwei Zeilen
            temp1 = temp.Clone
            temp.ShaftFit = ""
            temp.LowerSTolerance = 0.0
            temp.UpperSTolerance = 0.0
            temp1.HoleFit = ""
            temp1.LowerHTolerance = 0.0
            temp1.UpperHTolerance = 0.0
        End If
        If Not IsNothing(temp) Then
            If CheckForFitToleranceValues(temp) Then
                tempz.Add(temp)
                Log.WriteInfo("Bemaßung: " & temp.Zeile("Maß").ToString & Chr(9) & temp.Zeile("Passung"), False)
            End If
        End If
        If Not IsNothing(temp1) Then
            If CheckForFitToleranceValues(temp1) Then
                tempz.Add(temp1)
                Log.WriteInfo("Bemaßung: " & temp.Zeile("Maß").ToString & Chr(9) & temp.Zeile("Passung"), False)
            End If
        End If
        GettolfromfitCallOut = tempz
    End Function

    ' ermittelt die Passung und Toleranzen aus einer Bohrungsbeschreibung
    Private Function Gettolfromcalloutvar(prefix As String, calloutvar As Object()) As Boolean
        Dim temp As New Passungstabelle_Zeile
        Dim temp1 As New Passungstabelle_Zeile
        Dim tempz As New List(Of Passungstabelle_Zeile)
        'Dim tol As DimensionTolerance
        Dim fac As Double
        Dim flag As Boolean 'Marker um zu erkennen ob Passung manuell eingetragen wurde
        Dim swCalloutLengthVariable As CalloutLengthVariable
        Dim swCalloutVariable As CalloutVariable
        Dim i As Integer

        For i = 0 To UBound(calloutvar)
            swCalloutVariable = calloutvar(i)

            If swCalloutVariable.Type = swCalloutVariableType_e.swCalloutVariableType_Length Then
                swCalloutLengthVariable = swCalloutVariable

                flag = False

                'MsgBox(dimen.Value & " / " & tol.Type & "/ " & swTolType_e.swTolFIT)

                'Nur wenn es sich auch um eine Passungsangabe handelt, wird ausgewertet
                If swCalloutVariable.ToleranceType = swTolType_e.swTolFIT Or swCalloutVariable.ToleranceType = swTolType_e.swTolFITTOLONLY Or swCalloutVariable.ToleranceType = swTolType_e.swTolFITWITHTOL Then
                    'Umrechnungsfaktor ermitteln
                    'normalerweise gibt SWX die Werte in Meter zurück
                    'fac = GetDimFactor(dimen)
                    'Annahme, dass der Faktor immer 1000 ist
                    fac = 1000.0

                    'Prüfung ob auch Passungswerte eingetragen sind
                    'Könnte ja auch sein, dass als Toleranzttyp Passung eingestellt ist und keine Passung gewählt wurde
                    'Wenn kein Passungswert gefunden wird, dann Abbruch der Funktion
                    If Not CheckForFitValues(swCalloutVariable.HoleFit, swCalloutVariable.ShaftFit, swCalloutLengthVariable.Length * fac) Then
                        Gettolfromcalloutvar = False
                        Exit Function
                    End If

                    'Toleranzen von Bohrungspassung
                    If swCalloutVariable.HoleFit <> "" And swCalloutVariable.ShaftFit = "" Then
                        temp = SetColumnsFromCallOut(swCalloutVariable, swCalloutLengthVariable, True)
                        temp.prefix = prefix
                        'wenn die Passungswerte nicht gewählt wurden sondern manuel eingetragen wurden
                        If swCalloutVariable.ToleranceMin = 0.0 And swCalloutVariable.ToleranceMax = 0.0 Then
                            tempz = GettolfromfitCallOut(swCalloutVariable, swCalloutLengthVariable)
                        Else
                            tempz.Add(temp)
                            temp1 = Nothing
                        End If
                        'Toleranzen von Wellenpassung
                    ElseIf swCalloutVariable.ShaftFit <> "" And swCalloutVariable.HoleFit = "" Then
                        temp = SetColumnsFromCallOut(swCalloutVariable, swCalloutLengthVariable, True)
                        temp.prefix = prefix

                        If swCalloutVariable.ToleranceMin = 0.0 And swCalloutVariable.ToleranceMax = 0.0 Then
                            tempz = GettolfromfitCallOut(swCalloutVariable, swCalloutLengthVariable)
                        Else
                            tempz.Add(temp)
                            temp1 = Nothing
                        End If
                        'Prüfung ob Doppelpassung angegeben z.B. H7/g6
                    ElseIf swCalloutVariable.HoleFit <> "" And swCalloutVariable.ShaftFit <> "" Then
                        '* Bohungswerte ermitteln
                        'tol.SetFitValues(temp.HoleFit, "")
                        swCalloutVariable.HoleFit = temp.HoleFit
                        temp = SetColumnsFromCallOut(swCalloutVariable, swCalloutLengthVariable, True)
                        temp.prefix = prefix
                        If swCalloutVariable.ToleranceMin = 0.0 And swCalloutVariable.ToleranceMax = 0.0 Then flag = True

                        '* wellenwerte ermitteln
                        'tol.SetFitValues("", temp.ShaftFit)
                        swCalloutVariable.ShaftFit = temp.ShaftFit
                        'tol.SetFitValues(temp.HoleFit, "")
                        temp1 = SetColumnsFromCallOut(swCalloutVariable, swCalloutLengthVariable, True)
                        temp1.prefix = prefix

                        If swCalloutVariable.ToleranceMin = 0.0 And swCalloutVariable.ToleranceMax = 0.0 Then flag = True
                        '* Alten Wert wieder setzen
                        swCalloutVariable.ShaftFit = temp.ShaftFit
                        swCalloutVariable.HoleFit = temp.HoleFit

                        If flag = True Then
                            tempz = GettolfromfitCallOut(swCalloutVariable, swCalloutLengthVariable)
                        Else
                            tempz.Add(temp)
                            tempz.Add(temp1)
                        End If
                    End If

                    For Each temp In tempz
                        If Not temp Is Nothing Then
                            TabellenZeilen.Add(temp)
                            Log.WriteInfo("Bohrungsbeschreibung", False)
                            Log.WriteInfo("Bemaßung: " & temp.Zeile("Maß").ToString & Chr(9) & temp.Zeile("Passung"), False)
                            temp = Nothing
                            Tabellenzeilencount = Tabellenzeilencount + 1
                        End If
                    Next
                    Gettolfromcalloutvar = True
                Else
                    Gettolfromcalloutvar = False
                End If
            End If
        Next
    End Function
    'Prüfung ob auch Passungswerte eingetragen sind
    'Könnte ja auch sein, dass als Toleranzttyp Passung eingestellt ist und keine Passung gewählt wurde
    Function CheckForFitValues(HoleFitStr As String, ShaftFitStr As String, MaszStr As String) As Boolean
        If ShaftFitStr = "" And HoleFitStr = "" Then
            'If (Attr_generell("ReaktionAufLeerePassung") = True) And (Attr_generell("Fehlermeldung") = True) Then
            If (Attr_generell("ReaktionAufLeerePassung") = False) Then
                Log.WriteInfo("Keine Passung für " & MaszStr & " eingetragen", True)
            End If
            CheckForFitValues = False
                Exit Function
            End If
            CheckForFitValues = True
    End Function
    'Prüfung ob auch Toleranzwertwerte für die Passung gefunden wurden
    'z.B.: Passung M3 ist nur bis zu einer Größe von max. 50mm definiert
    Function CheckForFitToleranceValues(temp As Passungstabelle_Zeile) As Boolean
        Dim log As New LogFile(Attr_generell)

        If temp.Zeile("Passung") <> "" And temp.Zeile("ToleranzO") = 0.0 And temp.Zeile("ToleranzU") = 0.0 Then
            log.WriteInfo("Keine Passungswerte für Passung " & temp.Zeile("Maß") & "/" & temp.Zeile("Passung") & " gefunden", True)
            CheckForFitToleranceValues = False
            Exit Function
        End If
        CheckForFitToleranceValues = True
    End Function
    'setzt die Zeileneinträge für diese Maß/Passungskombination
    Function SetColumnsFromDim(dimen As Dimension, Hole As Boolean) As Passungstabelle_Zeile
        Dim temp As New Passungstabelle_Zeile
        Dim temp1 As New Passungstabelle_Zeile
        Dim tempz As New List(Of Passungstabelle_Zeile)
        Dim tol As DimensionTolerance
        Dim flag As Boolean
        Dim Shaftvalue As String = ""
        Dim HoleValue As String = ""

        tol = dimen.Tolerance
        flag = False

        HoleValue = tol.GetHoleFitValue
        Shaftvalue = tol.GetShaftFitValue

        If Hole Then tol.SetFitValues(tol.GetHoleFitValue, "") Else tol.SetFitValues("", tol.GetShaftFitValue)

        temp.Zeile("Maß") = Math.Round((dimen.GetSystemValue2("") * fac), RundenAuf).ToString
        If Attr_generell("PlusZeichen") And tol.GetMaxValue > 0 Then
            temp.Zeile("ToleranzO") = "+" & tol.GetMaxValue * fac
        Else
            temp.Zeile("ToleranzO") = tol.GetMaxValue * fac
        End If
        If Attr_generell("PlusZeichen") And tol.GetMinValue > 0 Then
            temp.Zeile("ToleranzU") = "+" & tol.GetMinValue * fac
        Else
            temp.Zeile("ToleranzU") = tol.GetMinValue * fac
        End If

        temp.Zeile("AbmaßO") = Convert.ToDouble(temp.Zeile("Maß")) + Convert.ToDouble(temp.Zeile("ToleranzO"))
        temp.Zeile("AbmaßU") = Convert.ToDouble(temp.Zeile("Maß")) + Convert.ToDouble(temp.Zeile("ToleranzU"))
        temp.Zeile("AbmaßToleranzMitte") = Convert.ToDouble(temp.Zeile("AbmaßU")) + (Convert.ToDouble(temp.Zeile("AbmaßO")) - Convert.ToDouble(temp.Zeile("AbmaßU"))) / 2.0

        'Wenn die Bohrungspassung benötigt wird
        If Hole Then
            temp.Zeile("Passung") = tol.GetHoleFitValue
            temp.Zeile("VorbearbeitungAbmaßO") = Convert.ToDouble(temp.Zeile("AbmaßO")) + SchichtStärke * 2
            temp.Zeile("VorbearbeitungAbmaßU") = Convert.ToDouble(temp.Zeile("AbmaßU")) + SchichtStärke * 2
        Else
            temp.Zeile("Passung") = tol.GetShaftFitValue
            temp.Zeile("VorbearbeitungAbmaßO") = Convert.ToDouble(temp.Zeile("AbmaßO")) - SchichtStärke * 2
            temp.Zeile("VorbearbeitungAbmaßU") = Convert.ToDouble(temp.Zeile("AbmaßU")) - SchichtStärke * 2
        End If

        temp.Zeile("VorbearbeitungAbmaßToleranzMitte") = Convert.ToDouble(temp.Zeile("VorbearbeitungAbmaßU")) + (Convert.ToDouble(temp.Zeile("VorbearbeitungAbmaßO")) - Convert.ToDouble(temp.Zeile("VorbearbeitungAbmaßU"))) / 2.0

        temp.Zeile("MaßPassung") = temp.prefix & temp.Zeile("Maß") & " " & temp.Zeile("Passung")

        tol.SetFitValues(HoleValue, Shaftvalue)
        SetColumnsFromDim = temp
    End Function

    'setzt die Zeileneinträge für diese Maß/Passungskombination
    Function SetColumnsFromCallOut(swCalloutVariable As CalloutVariable, swCalloutLengthVariable As CalloutLengthVariable, Hole As Boolean) As Passungstabelle_Zeile
        Dim temp As New Passungstabelle_Zeile
        Dim fac As Double

        fac = 1000

        temp.Zeile("Maß") = Math.Round((swCalloutLengthVariable.Length * fac), RundenAuf).ToString
        If Attr_generell("PlusZeichen") And swCalloutVariable.ToleranceMax > 0 Then
            temp.Zeile("ToleranzO") = "+" & swCalloutVariable.ToleranceMax * fac
        Else
            temp.Zeile("ToleranzO") = swCalloutVariable.ToleranceMax * fac
        End If

        If Attr_generell("PlusZeichen") And swCalloutVariable.ToleranceMin > 0 Then
            temp.Zeile("ToleranzU") = "+" & swCalloutVariable.ToleranceMin * fac
        Else
            temp.Zeile("ToleranzU") = swCalloutVariable.ToleranceMin * fac
        End If

        temp.Zeile("AbmaßO") = Convert.ToDouble(temp.Zeile("Maß")) + Convert.ToDouble(temp.Zeile("ToleranzO"))
        temp.Zeile("AbmaßU") = Convert.ToDouble(temp.Zeile("Maß")) + Convert.ToDouble(temp.Zeile("ToleranzU"))
        temp.Zeile("AbmaßToleranzMitte") = Convert.ToDouble(temp.Zeile("AbmaßU")) + (Convert.ToDouble(temp.Zeile("AbmaßO")) - Convert.ToDouble(temp.Zeile("AbmaßU"))) / 2.0

        'Wenn die Bohrungspassung benötigt wird
        If Hole Then
            temp.Zeile("Passung") = swCalloutVariable.HoleFit
            temp.Zeile("VorbearbeitungAbmaßO") = Convert.ToDouble(temp.Zeile("AbmaßO")) + SchichtStärke * 2
            temp.Zeile("VorbearbeitungAbmaßU") = Convert.ToDouble(temp.Zeile("AbmaßU")) + SchichtStärke * 2
        Else
            temp.Zeile("Passung") = swCalloutVariable.ShaftFit
            temp.Zeile("VorbearbeitungAbmaßO") = Convert.ToDouble(temp.Zeile("AbmaßO")) - SchichtStärke * 2
            temp.Zeile("VorbearbeitungAbmaßU") = Convert.ToDouble(temp.Zeile("AbmaßU")) - SchichtStärke * 2
        End If

        temp.Zeile("VorbearbeitungAbmaßToleranzMitte") = Convert.ToDouble(temp.Zeile("VorbearbeitungAbmaßU")) + (Convert.ToDouble(temp.Zeile("VorbearbeitungAbmaßO")) - Convert.ToDouble(temp.Zeile("VorbearbeitungAbmaßU"))) / 2.0

        temp.Zeile("MaßPassung") = temp.prefix & temp.Zeile("Maß") & " " & temp.Zeile("Passung")

        SetColumnsFromCallOut = temp
    End Function

    Function GetHoleTableDimension(HoleTab As HoleTable) As Boolean
        Dim dispdim As DisplayDimension
        Dim dimen As Dimension
        Dim tabs As Object
        Dim feat As Feature
        Dim prefix As String = ""
        'Dim hv() As Object
        Dim holeVariables As Object()


        tabs = HoleTab.GetTableAnnotations

        If tabs Is Nothing Then
            GetHoleTableDimension = False
            Exit Function
        End If

        For i = 0 To UBound(tabs)
            feat = tabs(i).HoleTable.GetFeature
            dispdim = feat.GetFirstDisplayDimension
            Do While Not dispdim Is Nothing
                If dispdim.Type2 = swDimensionType_e.swDiameterDimension Then
                    prefix = "Ø"
                End If

                dimen = dispdim.GetDimension2(0)

                Gettolfromdim(dimen, prefix)

                'Prüfung ob es sich um eine Bohrungsbeschreibung handelt
                holeVariables = dispdim.GetHoleCalloutVariables
                'Wenn Bohrungs-Beschreibungs-Variablen gefunden wurden
                If Not holeVariables Is Nothing Then
                    Gettolfromcalloutvar(prefix, holeVariables)
                End If
                dispdim = feat.GetNextDisplayDimension(dispdim)
            Loop
        Next
        GetHoleTableDimension = True
    End Function
    Private Sub SetColors()
        RowColor = ConvertColorToSwxHex(Attr_Tabelle("FarbeZeile"))
        HeadColor = ConvertColorToSwxHex(Attr_Tabelle("FarbeKopfZeile"))
    End Sub

    Private Function ConvertColorToSwxHex(colorcode As Long) As String
        Dim temps1 As String
        Dim temps2 As String

        temps1 = Right("000000" & Hex(colorcode), 6)

        temps2 = ""
        temps2 = Mid(temps1, Len(temps1) - 1, 1) + Right(temps1, 1)

        temps1 = Left(temps1, 4)
        temps2 = temps2 + Mid(temps1, Len(temps1) - 1, 1) + Right(temps1, 1)

        temps1 = Left(temps1, 2)
        temps2 = temps2 + Mid(temps1, Len(temps1) - 1, 1) + Right(temps1, 1)

        ConvertColorToSwxHex = "0x" & temps2
    End Function

    Sub InsertTable(swdraw As DrawingDoc, swsheet As Sheet)
        Dim swTable As TableAnnotation

        swdraw.ActivateSheet(swsheet.GetName)
        swTable = swdraw.InsertTableAnnotation2(False, Einfügepunkt(0), Einfügepunkt(1), Einfügepunktposition, "", tabellenzeilencount * 2 + 1, tabellenSpaltenCount)
        swTable.GetAnnotation.SetName("PASSUNGSTABELLE")
        swTable.Title = "Passungstabelle"
        swTable.GeneralTableFeature.GetFeature.Name = "Passungstabelle-" & swsheet.GetName
        SetColors()

        HeadStyle = GetTextStyle(True, swTable)
        RowStyle = GetTextStyle(False, swTable)

        SetTabelHeader(swTable)

        swTable.SetTextFormat(False, RowStyle)

        SetColumnHeader(swTable)

        InsertRowsText(swTable)

        For i = 0 To TabellenSpaltenCount - 1
            swTable.SetColumnWidth(i, swsheet.GetProperties2(5), swTableRowColSizeChangeBehavior_e.swTableRowColChange_TableSizeCanChange)
        Next

        If Attr_Tabelle("SpaltenBreiteAutomatisch") = True Then
            SetColumnWithAuto(swTable)
        Else
            SetColumnWithValue(swTable)
        End If

    End Sub
    Private Function GetTextStyle(Header As Boolean, swTable As TableAnnotation) As TextFormat
        Dim temp As SolidWorks.Interop.sldworks.TextFormat

        temp = swTable.GetTextFormat

        If Header = True Then
            temp.TypeFaceName = Attr_Tabelle("SchriftartKopfZeile")
            temp.CharHeight = Attr_Tabelle("TexthöheKopfZeile").Replace(".", ",") / 1000.0
            temp.Bold = Attr_Tabelle("FettKopfZeile")
            temp.Underline = Attr_Tabelle("UnterstrichenKopfZeile")
            temp.Strikeout = Attr_Tabelle("DurchgestrichenKopfZeile")
            temp.Italic = Attr_Tabelle("KursivKopfZeile")
        Else
            temp.TypeFaceName = Attr_Tabelle("SchriftartZeile")
            temp.CharHeight = Attr_Tabelle("TexthöheZeile").Replace(".", ",") / 1000.0
            temp.Bold = Attr_Tabelle("FettZeile")
            temp.Underline = Attr_Tabelle("UnterstrichenZeile")
            temp.Strikeout = Attr_Tabelle("DurchgestrichenZeile")
            temp.Italic = Attr_Tabelle("KursivZeile")
        End If
        GetTextStyle = temp
    End Function

    Private Function GetFontStyle(Header As Boolean) As Font
        Dim style As New FontStyle
        Dim höheK As Single
        Dim höheR As Single
        Dim temp As Font

        'höheK = Attr_Tabelle("TexthöheKopfZeile").Replace(".", ",") * 72 / 25.4
        höheK = Attr_Tabelle("TexthöheKopfZeile").Replace(".", ",")
        'höheR = Attr_Tabelle("TexthöheZeile").Replace(".", ",") * 72 / 25.4
        höheR = Attr_Tabelle("TexthöheZeile").Replace(".", ",")

        If Header = True Then
            If Attr_Tabelle("FettKopfZeile") = True Then style = style Xor FontStyle.Bold
            If Attr_Tabelle("KursivKopfZeile") = True Then style = style Xor FontStyle.Italic
            temp = New Font(Attr_Tabelle("SchriftartKopfZeile"), höheK, style, GraphicsUnit.Millimeter)
        Else
            If Attr_Tabelle("FettZeile") = True Then style = style Xor FontStyle.Bold
            If Attr_Tabelle("KursivZeile") = True Then style = style Xor FontStyle.Italic
            temp = New Font(Attr_Tabelle("SchriftartZeile"), höheR, style, GraphicsUnit.Millimeter)
        End If
        GetFontStyle = temp
    End Function

    Private Sub SetTabelHeader(swTable As TableAnnotation)
        Dim rows As Integer

        'Wenn zweisprachig dann auch zwei Zeilen
        'If Attr_Sprache.Contains("/") Then rows = 2 Else rows = 1


        If Attr_Tabelle("HeaderOben") = True Then
            swTable.SetHeader(swTableHeaderPosition_e.swTableHeader_Top, rows)
        Else
            swTable.SetHeader(swTableHeaderPosition_e.swTableHeader_Bottom, rows)
        End If


    End Sub

    Private Sub SetColumnHeader(swTable As TableAnnotation)
        Dim lang1 As String = ""
        Dim lang2 As String = ""

        Dim lang1l As New Dictionary(Of String, String)
        Dim lang2l As New Dictionary(Of String, String)


        If Attr_Sprache.Contains("/") Then
            lang1 = Attr_Sprache.Substring(0, 2)
            lang2 = Attr_Sprache.Substring(3, 2)
        Else
            lang1 = Attr_Sprache.Substring(0, 2)
        End If

        If Attr_Sprache.Contains("/") Then
            lang1l = Attr_Übersetzungen(lang1)
            lang2l = Attr_Übersetzungen(lang2)
        Else
            lang1l = Attr_Übersetzungen(lang1)
        End If

        InsertHeaderText(swTable, lang1l, lang2l)

        If Attr_Tabelle("SpaltenBreiteAutomatisch") = True Then
        Else

        End If
    End Sub

    Private Sub SetColumnWith(swtable As TableAnnotation)
        Dim pos As Integer = 0

        For Each n As KeyValuePair(Of String, String) In Definitionen.TABELLENATTR_Init
            If n.Key.Length > 10 Then
                If n.Key.Substring(0, 9) = "TabSpalte" Then
                    If Attr_Tabelle(n.Key) = True Then

                        pos = pos + 1
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub InsertHeaderText(swTable As TableAnnotation, lang1l As Dictionary(Of String, String), lang2l As Dictionary(Of String, String))
        Dim pos As Integer = 0
        Dim ann As Annotation

        For Each n As KeyValuePair(Of String, String) In Definitionen.TABELLENATTR_Init
            If n.Key.Length > 10 Then
                If n.Key.Substring(0, 9) = "TabSpalte" Then
                    If Attr_Tabelle(n.Key) = True Then
                        swTable.SetColumnTitle2(pos, "<FONT color=" & HeadColor & ">" & lang1l(n.Key.Substring(9)), True)
                        swTable.SetCellTextFormat(0, pos, False, HeadStyle)
                        If lang2l.Count > 0 Then
                            swTable.SetColumnTitle2(pos, swTable.GetColumnTitle2(pos, True) & Chr(13) & lang2l(n.Key.Substring(9)), True)
                            swTable.SetCellTextFormat(0, pos, False, HeadStyle)
                        End If
                        pos = pos + 1
                    End If
                End If
            End If
        Next
        ann = swTable.GetAnnotation
    End Sub

    Private Sub InsertRowsText(swTable As TableAnnotation)
        Dim rowpos As Integer
        Dim rowstep As Integer

        If swTable.GetHeaderStyle = swTableHeaderPosition_e.swTableHeader_Top Then
            rowpos = 1
            rowstep = 2
        Else
            rowpos = swTable.RowCount - 2
            rowstep = -2
        End If
        For Each row In tabellenZeilengefiltert
            InsertRowText(swTable, rowpos, rowstep, row)
            rowpos = rowpos + rowstep
        Next
    End Sub

    Private Sub InsertRowText(swTable As TableAnnotation, rowpos As Integer, rowstep As Integer, row As Passungstabelle_Zeile)
        Dim pos As Integer = 0
        Dim rstep As Integer

        If rowstep < 0 Then
            rstep = -1
        Else
            rstep = 1
        End If
        For Each n As KeyValuePair(Of String, String) In Definitionen.TABELLENATTR_Init
            If n.Key.Length > 10 Then
                If n.Key.Substring(0, 9) = "TabSpalte" Then
                    If Attr_Tabelle(n.Key) = True Then
                        Select Case n.Key.Substring(9)
                            Case "Maß"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Prefix & row.Zeile("Maß")
                                swTable.MergeCells(rowpos, pos, rowpos + rstep, pos)
                            Case "Passung"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("Passung")
                                swTable.MergeCells(rowpos, pos, rowpos + rstep, pos)
                            Case "MaßePassung"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.prefix & row.Zeile("Maß") & " " & row.Zeile("Passung")
                                swTable.MergeCells(rowpos, pos, rowpos + rstep, pos)
                            Case "Toleranz"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("ToleranzO")
                                swTable.Text(rowpos + rstep, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("ToleranzU")
                            Case "Abmaß"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("AbmaßO")
                                swTable.Text(rowpos + rstep, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("AbmaßU")
                            Case "AbmaßToleranzMitte"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("AbmaßToleranzMitte")
                                swTable.MergeCells(rowpos, pos, rowpos + rstep, pos)
                            Case "VorbearbeitungsAbmaße"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("VorbearbeitungAbmaßO")
                                swTable.Text(rowpos + rstep, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("VorbearbeitungAbmaßU")
                            Case "VorbearbeitungsToleranzMitte"
                                swTable.Text(rowpos, pos) = "<FONT color=" & RowColor & ">" & row.Zeile("VorbearbeitungAbmaßToleranzMitte")
                                swTable.MergeCells(rowpos, pos, rowpos + rstep, pos)
                        End Select
                        pos = pos + 1
                    End If
                End If
            End If
        Next
    End Sub

    'Setzt die Spaltenbreiten an Hand der Setup Einstellungen
    'Achtung: Die Reihenfolge der Spaltennamen muss mit der Reihenfolge der Spaltenbreiten übereinstimmen
    Sub SetColumnWithValue(swTable As TableAnnotation)
        Dim i As Integer = 0

        For Each n As KeyValuePair(Of String, String) In Definitionen.TABELLENATTR_Init
            If n.Key.Length > 10 Then
                If n.Key.Substring(0, 9) = "TabSpalte" Then
                    If Attr_Tabelle(n.Key) = True Then
                        swTable.SetColumnWidth(i, CDbl(Attr_Tabelle("BreiteSpalte" & n.Key.Substring(9)) / 1000), swTableRowColSizeChangeBehavior_e.swTableRowColChange_TableSizeCanChange)
                        i = i + 1
                    End If
                End If
            End If
        Next
    End Sub

    'Setzt die Spaltenbreiten automatisch an Hand des breitesten Texts der jeweiligen Spalte
    Sub SetColumnWithAuto(swTable As TableAnnotation)
        Dim index As Integer = 0
        Dim swAnnotation As Annotation
        Dim swDislplayData As DisplayData
        Dim TextWidth As Double = 0.0
        Dim HeaderZweizeilig As Boolean = False

        swAnnotation = swTable.GetAnnotation
        swDislplayData = swAnnotation.GetDisplayData

        If Attr_Sprache.Contains("/") Then HeaderZweizeilig = True

        For i = 0 To swTable.ColumnCount - 1
            For j = 0 To swTable.RowCount - 1
                If j = 0 And HeaderZweizeilig Then
                    If swDislplayData.GetTextInBoxWidthAtIndex(index) > TextWidth Then
                        TextWidth = swDislplayData.GetTextInBoxWidthAtIndex(index)
                    End If
                    If swDislplayData.GetTextInBoxWidthAtIndex(index + 1) > TextWidth Then
                        TextWidth = swDislplayData.GetTextInBoxWidthAtIndex(index + 1)
                    End If
                    index = index + swTable.ColumnCount * 2
                Else
                    If swDislplayData.GetTextInBoxWidthAtIndex(index) > TextWidth Then
                        TextWidth = swDislplayData.GetTextInBoxWidthAtIndex(index)
                    End If
                    index = index + swTable.ColumnCount
                End If
            Next
            swTable.SetColumnWidth(i, TextWidth + 0.001, swTableRowColSizeChangeBehavior_e.swTableRowColChange_TableSizeCanChange)
            TextWidth = 0.0
            If HeaderZweizeilig Then
                index = i * 2 + 2
            Else
                index = i + 1
            End If

        Next
    End Sub

    '** Umrechungsfaktor von SWX Einheiten zu mm bzw.Grad
    Private Function GetDimFactor(swDim As Dimension) As Double
        Const PI As Double = 3.14159265
        Const LEN_FACTOR As Double = 1000.0#
        Const ANG_FACTOR As Double = 180.0# / PI

        Select Case Int(swDim.GetType)
            Case swDimensionParamType_e.swDimensionParamTypeDoubleLinear
                GetDimFactor = LEN_FACTOR
            Case swDimensionParamType_e.swDimensionParamTypeDoubleAngular
                GetDimFactor = ANG_FACTOR
            Case Else
                Return 0
        End Select
    End Function

    Private Function Count_passungen(swdrw As SolidWorks.Interop.sldworks.DrawingDoc) As Integer
        Dim zaehler As Integer
        Count_passungen = zaehler
    End Function

    'Filtert die Tabellzeilen ohne Duplikate
    Sub SetTabellenzeilenGefiltert()
        TabellenZeilen.Sort()
        TabellenZeilengefiltert = TabellenZeilen.Distinct
        Tabellenzeilencount = tabellenZeilengefiltert.Count
    End Sub

End Class

