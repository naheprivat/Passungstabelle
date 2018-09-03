Imports System.Collections.Generic
Imports System.Linq
Imports System


Public Class Passungstabelle_Zeile
    Implements IComparable(Of Passungstabelle_Zeile)
    Implements IEquatable(Of Passungstabelle_Zeile)

    '* Eigenschaften des Zeileneintrags
    Property Zeile As Dictionary(Of String, String)
    Property Prefix As String
    Property Masz As Double                 'Maß
    Property HoleFit As String              'Bohrungspassung
    Property ShaftFit As String             'Wellenpassung
    Property UpperSTolerance As Double      'obere Toleranz für Wellenpassung
    Property LowerSTolerance As Double      'untere Toleranz für Wellenpassung
    Property UpperHTolerance As Double      'obere Toleranz für Bohrungspassung
    Property LowerHTolerance As Double      'uneter Toleranz für Bohrungspassung
    Property Dwgrow As Integer              'für Erweiterung gedacht um die Position im Zeichnungsraster anzuzeiegen
    Property Dwgcol As Integer              'für Erweiterung gedacht um die Position im Zeichnungsraster anzuzeiegen
    Property Uppermasz As Double            'Oberes Abmaß
    Property Lowermasz As Double            'Unteres Abmaß
    Property Midmasz As Double              'Maß auf Toleranzmitte

    Sub New()
        HoleFit = ""
        ShaftFit = ""
        UpperSTolerance = 0.0
        LowerSTolerance = 0.0
        UpperHTolerance = 0.0
        LowerHTolerance = 0.0
        Masz = 0.0
        Dwgrow = 0
        Dwgcol = 0
        Midmasz = 0.0
        Prefix = ""
        'Zeile = New Dictionary(Of String, String) From {{"Maß", ""}, {"Passung", ""}, {"MaßPassung", ""}, {"ToleranzO", ""}, {"ToleranzU", ""}, {"AbmaßO", ""}, {"AbmaßU", ""}, {"AbmaßToleranzMitte", ""}, {"VorbearbeitungAbmaßO", ""}, {"VorbearbeitungAbmaßU", ""}, {"VorbearbeitungAbmaßToleranzMitte", ""}}
        Zeile = New Dictionary(Of String, String)
    End Sub

    '* Vergleichsfunktion um die Liste der Zeile zu sortieren
    Public Function CompareTo(other As Passungstabelle_Zeile) As Integer Implements IComparable(Of Passungstabelle_Zeile).CompareTo
        Dim r1 As Double
        Dim r2 As Double

        r1 = Convert.ToDouble(Me.Zeile("Maß"))
        r2 = Convert.ToDouble(other.Zeile("Maß"))
        ' Compare sizes.
        ' Return Me.masz().CompareTo(other.masz())
        Return r1.CompareTo(r2)
    End Function

    '* Kopieren von Zeilen
    '* wird benötigt wenn eine Passungskombination angegeben wurde z.B.: H7/g6
    Public Function Clone() As Object
        Return (Me.MemberwiseClone())
    End Function

    '* Vergleichsfunktion um eine Liste ohne doppelte Einträge zu erstellen
    Public Function Equals1(ByVal other As Passungstabelle_Zeile) As Boolean Implements IEquatable(Of Passungstabelle_Zeile).Equals
        Dim r1 As Double
        Dim r2 As Double

        r1 = Convert.ToDouble(Me.Zeile("Maß"))
        r2 = Convert.ToDouble(other.Zeile("Maß"))

        ' Check whether the compared object is null.
        If other Is Nothing Then Return False
        ' Check whether the compared object references the same data.
        If Me Is other Then Return True

        Return Zeile("Passung").Equals(other.Zeile("Passung")) AndAlso r1.Equals(r2)

        'If HoleFit = "" Or other.HoleFit = "" Then
        '    ' Check whether the products' properties are equal.
        '    Return HoleFit.Equals(other.HoleFit) AndAlso masz.Equals(other.masz)
        'Else
        '    Return ShaftFit.Equals(other.ShaftFit) AndAlso masz.Equals(other.masz)
        'End If
    End Function

    '* Vergleichsfunktion um eine Liste ohne doppelte Einträge zu erstellen
    Public Overrides Function GetHashCode() As Integer
        Dim hashmasz = If(Zeile("Maß") = "0.0", 0, Zeile("Maß").GetHashCode())

        Dim hashfit = Zeile("Passung").GetHashCode
        Return hashmasz Xor hashfit
    End Function

    'Sub SetUpperAndLowerDim(Schicht As Double)
    '    If HoleFit <> "" Then
    '        uppermasz = (masz + upperHTolerance) + 2 * Schicht
    '        lowermasz = (masz + lowerHTolerance) + 2 * Schicht
    '    ElseIf ShaftFit <> "" Then
    '        uppermasz = (masz + upperSTolerance) - 2 * Schicht
    '        lowermasz = (masz + lowerSTolerance) - 2 * Schicht
    '    End If
    '    'Wenn es sich um eine Wellenpassung handet
    '    If Asc(Zeile("Passung").Substring(1, 1)) <= Asc("Z") Then
    '        Zeile("AbmaßO") = (Zeile("Maß") + Zeile("ToleranzO") + 2 * Schicht)
    '        Zeile("AbmaßU") = (Zeile("Maß") + Zeile("ToleranzU") + 2 * Schicht)
    '    Else
    '        Zeile("AbmaßO") = (Zeile("Maß") + Zeile("ToleranzO") - 2 * Schicht)
    '        Zeile("AbmaßU") = (Zeile("Maß") + Zeile("ToleranzU") - 2 * Schicht)
    '    End If
    'End Sub

    'Sub SetMidDim(Schicht As Double)
    '    midmasz = uppermasz - ((uppermasz - uppermasz) / 2.0)
    '    Zeile("AbmaßToleranzMitte") = Zeile("AbmaßO") - ((Zeile("AbmaßO") - Zeile("AbmaßU")) / 2.0)
    'End Sub
End Class
