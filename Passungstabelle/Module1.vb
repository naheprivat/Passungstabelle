'Module1 
'dient hauptsächlich dazu die Setup.xml Datei 
'   zu erstellen
'   zu lesen
'   zu schreiben
'   die alte Ini-Datei zu konvertieren

Imports SolidWorks.Interop.sldworks
Imports System.Xml
Imports System.Data
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization


Module Module1
    Private exc As Microsoft.Office.Interop.Excel.Application   'Verweis auf Excel
    Property SwxMacroPfad As String                             'Pfad zum Verzeichnis der Applikation
    Property Setup_Pfad As String

    'Sub        Init_excel
    'Paramter:  Keine
    'Startet Excel
    'Achtung: keine Fehlerabfrage wenn Excel nicht gestartet werden kann
    Sub Init_excel()
        On Error Resume Next
        'läuft Excel bereits?
        exc = GetObject(, "Excel.Application")
        'Wenn Excel noch nicht läuft
        If Err.Number <> 0 Then
            'Excel starten
            exc = CreateObject("Excel.Application")
            exc.Visible = False
        Else
            exc.Visible = False
        End If
    End Sub

    'Sub        Create_tabels
    'Paramter:  XMLDaten
    'erstellt das Data Objekt für die Setup.XML Datei inklusive Tabellenstruktur
    'um ein Gefühl für die Datenstruktur zu bekommen, 
    'lohnt sich ein Blick in die Datei Setup-Schema.xsd (unter Resources)
    Public Sub Create_Tabels(ByRef XMLDaten As Data)
        Dim dst As DataTable                                                'Datentabelle
        Dim dsr As DataRow                                                  'Datenreihe
        Dim dsr1 As DataRow                                                 'Datenreihe
        Dim xmlSR As New System.IO.StringReader(My.Resources.Setup_Schema)  'XML Schema intern als Ressource gespeichert

        'Alle Daten sicherheitshalber löschen
        XMLDaten.Clear()
        'Schema einlesen
        XMLDaten.ReadXmlSchema(xmlSR)

        'Tabelle Sprachen holen
        dst = XMLDaten.Tables("Sprachen")
        'Neue Datenreihe erstellen
        dsr = dst.NewRow
        'Datenreihe einfügen
        dst.Rows.Add(dsr)

        'Tabelle Sprache holen
        dst = XMLDaten.Tables("Sprache")
        'Alle definierten Sprachkürzel durchlaufne
        For Each n As KeyValuePair(Of String, String) In Definitionen.SPRACHATTR
            'Neue Datenreihe
            dsr1 = dst.NewRow
            'Kürzel setzen
            dsr1("Kürzel") = n.Key
            'Sprachebezeichnung setzen
            dsr1("Sprache") = n.Value
            'Verlinkung zu Tabelle "Sprachen" setzen
            dsr1("Sprachen_Id") = 0
            'Datenreihe einfügen
            dst.Rows.Add(dsr1)
        Next

        'Tabelle Sprachkombinationen holen
        dst = XMLDaten.Tables("Sprachkombinationen")
        'Neue Datenreihe erstellen
        dsr = dst.NewRow
        'Datenreihe einfügen
        dst.Rows.Add(dsr)

        'Tabelle Sprachkombinationen erstellen
        'da es bei der initialen Erstellung nur eine Sprache (Deutsch) gibt
        'wird nur die Sprachkombination "DE" erstellt
        'Tabelle Sprachkombination holen
        dst = XMLDaten.Tables("Sprachkombination")
        'Neue Datenreihe erstellen
        dsr1 = dst.NewRow
        'Sprachkürzel setzen
        dsr1("Name") = "DE"
        'Verlinkung zu Tabelle "Spachkombinationen" setzen
        dsr1("Sprachkombinationen_Id") = 0
        'Datenreihe einfügen
        dst.Rows.Add(dsr1)

        'Tabelle Linienarten holen
        dst = XMLDaten.Tables("Linienarten")
        'Neue Datenreihe erstellen
        dsr = dst.NewRow
        'Datenreihe einfügen
        dst.Rows.Add(dsr)

        'Tabelle Linienart holen
        dst = XMLDaten.Tables("Linienart")
        'Alle definierten Sprachkürzel durchlaufen
        For Each n In Definitionen.LINIENARTEN
            'Neue Datenreihe
            dsr1 = dst.NewRow
            'Namen der Linienart setzen
            dsr1("Name") = n
            'Verlinkung zu Tabelle "Linienarten" setzen
            dsr1("Linienarten_Id") = 0
            'Datenreihe einfügen
            dst.Rows.Add(dsr1)
        Next

        'Tabelle Übersetzungen holen
        dst = XMLDaten.Tables("Übersetzungen")
        'Neue Datenreihe
        dsr = dst.NewRow
        'Datenreihe einfügen
        dst.Rows.Add(dsr)

        'Tabelle Übersetzung holen
        dst = XMLDaten.Tables("Übersetzung")
        'Neue Datenreihe
        dsr1 = dst.NewRow
        'Alle definierten Übersetzungstexte durchlaufen
        For Each n As KeyValuePair(Of String, String) In Definitionen.ÜBERSETZUNGSATTR_Init
            dsr1(n.Key) = n.Value
        Next
        'Verlinkung zu Tabelle "Übersetzungen" setzen
        dsr1("Übersetzungen_Id") = 0
        'Datenreihe einfügen
        dst.Rows.Add(dsr1)

        'Tabelle Generell holen
        dst = XMLDaten.Tables("Generell")
        'Neue Datenreihe
        dsr = dst.NewRow
        'Datenreihe einfügen
        dst.Rows.Add(dsr)

        'Tabelle GenerelleAttribute holen
        dst = XMLDaten.Tables("GenerelleAttribute")
        'Neue Datenreihe
        dsr1 = dst.NewRow
        'Alle definierten Attribute durchlaufen
        For Each n As KeyValuePair(Of String, String) In Definitionen.GENERELLE_ATTR_Init
            dsr1(n.Key) = n.Value
        Next
        'Verlinkung zu Tabelle "Generell" setzen
        dsr1("Generell_Id") = 0
        'Datenreihe einfügen
        dst.Rows.Add(dsr1)

        'Tabelle Formate holen
        dst = XMLDaten.Tables("Formate")
        'Neue Datenreihe
        dsr = dst.NewRow
        'Datenreihe einfügen
        dst.Rows.Add(dsr)

        'Datenstruktur speichern
        XMLDaten.AcceptChanges()
    End Sub

    'Function:  Read_Tab_sprachen_neu
    'Paramter:  Keine
    'Ergebnis:  Dictionary(Of String, Dictionary(Of String, String))
    'liest die Übersetzungen aus der Datei Sprachen.xls ein und gibt sie als Dictionary zurück
    Function Read_Tab_sprachen_neu() As Dictionary(Of String, Dictionary(Of String, String))
        Dim wbs As Microsoft.Office.Interop.Excel.Workbooks
        Dim wb As Microsoft.Office.Interop.Excel.Workbook
        Dim ws As Microsoft.Office.Interop.Excel.Worksheet
        Dim rg As Microsoft.Office.Interop.Excel.Range
        Dim pfad As String
        Dim temp As Dictionary(Of String, String)
        Dim temp1 As New Dictionary(Of String, Dictionary(Of String, String))
        Dim x As Integer
        Dim y As Integer

        'Verweis auf Excel holen 
        Init_excel()
        'Pfad und Dateiname definieren
        'pfad = SwxMacroPfad & "\Sprachen.xls"
        pfad = SwxMacroPfad & "Sprachen.xls"
        'Workbooks holen
        wbs = exc.Workbooks
        'Workbook holen
        wb = wbs.Open(pfad, False, True)
        'Wenn kein Workbook gefunden wurde, dann Programmabbruch
        If IsNothing(wb) Then
            MsgBox("Datei Sprachen.xls nicht gefunden" & Chr(10) & "im Verzeichnis: " & SwxMacroPfad & Chr(10) & "Import abgebrochen")
            Read_Tab_sprachen_neu = temp1
            Exit Function
        End If
        'Erstes Blatt holen
        ws = wb.Worksheets.Item(1)

        'Spalten und Zeilenzähler initialisieren
        x = 2
        y = 2

        'Rangeobjekt auf die 2. Spalte setzen
        'die 2. Spalte enthält das Sprachkürzel
        'z.B.: DE für Deutsch
        rg = CType(ws.Cells(y, x), Microsoft.Office.Interop.Excel.Range)

        'So lange Werte gefunden werden
        While rg.Value <> ""
            'Dictionary initialisieren
            temp = New Dictionary(Of String, String)
            'auf 2. Spalte springen
            x = 2
            'Für alle Übersetzungsattribute die Werte einlesen
            'ACHTUNG: da einige Übersetzungen dazugekommen sind die neuen Übersetzungen leere Strings
            For Each item As KeyValuePair(Of String, String) In Definitionen.ÜBERSETZUNGSATTR
                'Übersetzung hinzufügen
                temp.Add(item.Key, Trim(CType(ws.Cells(y, x), Microsoft.Office.Interop.Excel.Range).Value))
                'eine Spalte weiter
                x = x + 1
            Next
            'Übersetzungen mit dem Sprachkürzel der 2. Spalte (= rg.Value)
            'an das Übersetzungs-Dictionary anhänge
            temp1.Add(rg.Value, temp)
            'Spaltenzähler initialisieren
            x = 2
            'Zeilenzähler um 1 erhöhen
            y = y + 1
            'Rangeobjekt auf die 2. Spalte setzen
            rg = CType(ws.Cells(y, x), Microsoft.Office.Interop.Excel.Range)
        End While

        'Workbook schließen
        wb.Close(False)
        'Excel beenden
        exc.Quit()
        'Übersetzungen zurückgeben
        Read_Tab_sprachen_neu = temp1
    End Function

    Function Read_old_ini_neu() As List(Of Definitionen.Strctformat)
        Dim pfad As String
        Dim temp As Definitionen.Strctformat
        Dim temp1 As New List(Of Definitionen.Strctformat)
        Dim w As Definitionen.Werte
        Dim zeile As String
        Dim i As Integer

        Dim fileReader As System.IO.StreamReader


        'pfad = SwxMacroPfad & "\" & Definitionen.OLD_INI_File
        pfad = SwxMacroPfad & Definitionen.OLD_INI_File


        '* Errorhandler initialisieren
        On Error Resume Next
        '* Datei öffnen
        fileReader = My.Computer.FileSystem.OpenTextFileReader(pfad)

        If IsNothing(fileReader) Then
            MsgBox("Datei Passungstabelle.ini nicht gefunden Import abgebrochen" & Chr(10) & "im Verzeichnis: " & SwxMacroPfad)
            Read_old_ini_neu = temp1
            Exit Function
        End If

        zeile = fileReader.ReadLine()
        temp = New Definitionen.Strctformat With {.format = Mid(zeile, 3)}
        'temp.format = Mid(zeile, 3)
        Create_strct(Definitionen.Attribute.GENERELLE_Attr, Definitionen.GENERELLE_ATTR, temp)
        Create_strct(Definitionen.Attribute.TABELLENATTR, Definitionen.TABELLENATTR, temp)
        Create_strct(Definitionen.Attribute.FORMATATTR, Definitionen.FORMATATTR, temp)


        While Not fileReader.EndOfStream
            If Left(zeile, 2) = "##" Then
                temp = New Definitionen.Strctformat With {.format = Mid(zeile, 3)}
                '* Formatnamen zuweisen
                'temp.format = Mid(zeile, 3)
                Create_strct(Definitionen.Attribute.GENERELLE_Attr, Definitionen.GENERELLE_ATTR, temp)
                Create_strct(Definitionen.Attribute.TABELLENATTR, Definitionen.TABELLENATTR, temp)
                Create_strct(Definitionen.Attribute.FORMATATTR, Definitionen.FORMATATTR, temp)

                '* Zähler erhöhen
                temp1.Add(temp)

            End If
            zeile = fileReader.ReadLine()
        End While

        fileReader.Close()

        fileReader = My.Computer.FileSystem.OpenTextFileReader(pfad)

        '* nächste Zeile
        zeile = fileReader.ReadLine()
        i = -1
        '* Solang das Dateiende nicht erreicht ist
        While Not fileReader.EndOfStream
            '* wenn es sich um einen Formatnamen handelt
            If Left(zeile, 2) = "##" Then
                i = i + 1
                zeile = fileReader.ReadLine()

                'Neue Parameter auf Standardwerte setzen
                w = temp1(i).tabbellen_paramter("FarbeKopfZeile")
                w.s = "0"
                temp1(i).tabbellen_paramter("FarbeKopfZeile") = w

                w = temp1(i).tabbellen_paramter("FettKopfZeile")
                w.b = False
                temp1(i).tabbellen_paramter("FettKopfZeile") = w

                w = temp1(i).tabbellen_paramter("FarbeZeile")
                w.s = "0"
                temp1(i).tabbellen_paramter("FarbeZeile") = w

                w = temp1(i).tabbellen_paramter("FettZeile")
                w.b = False
                temp1(i).tabbellen_paramter("FettZeile") = w

                w = temp1(i).tabbellen_paramter("SpaltenBreiteAutomatisch")
                w.b = False
                temp1(i).tabbellen_paramter("SpaltenBreiteAutomatisch") = w

                w = temp1(i).generelle_paramter("Eventgesteuert")
                w.b = False
                temp1(i).generelle_paramter("Eventgesteuert") = w

                w = temp1(i).tabbellen_paramter("KursivKopfZeile")
                w.b = False
                temp1(i).tabbellen_paramter("KursivKopfZeile") = w

                w = temp1(i).tabbellen_paramter("KursivZeile")
                w.b = False
                temp1(i).tabbellen_paramter("KursivZeile") = w


            End If
            If zeile = "#EP" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).format_paramter("Einfügepunkt" & zeile)
                w.b = True
                temp1(i).format_paramter("Einfügepunkt" & zeile) = w
            ElseIf zeile = "#C1" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("BreiteSpalteMaß")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).tabbellen_paramter("BreiteSpalteMaß") = w
            ElseIf zeile = "#FB" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).format_paramter("Breite")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).format_paramter("Breite") = w
            ElseIf zeile = "#FH" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).format_paramter("Höhe")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).format_paramter("Höhe") = w
            ElseIf zeile = "#C2" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("BreiteSpaltePassung")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).tabbellen_paramter("BreiteSpaltePassung") = w
            ElseIf zeile = "#C3" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("BreiteSpalteVorbearbeitungsAbmaße")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).tabbellen_paramter("BreiteSpalteVorbearbeitungsAbmaße") = w
            ElseIf zeile = "#C4" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("BreiteSpalteAbmaß")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).tabbellen_paramter("BreiteSpalteAbmaß") = w
            ElseIf zeile = "#OPX" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).format_paramter("Offset_X")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).format_paramter("Offset_X") = w
            ElseIf zeile = "#OPY" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).format_paramter("Offset_Y")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).format_paramter("Offset_Y") = w
            ElseIf zeile = "#DEC" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("RundenAuf")
                w.i = CInt(zeile)
                temp1(i).generelle_paramter("RundenAuf") = w
            ElseIf zeile = "#TH" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("TexthöheZeile")
                w.d = CDbl(zeile.Replace(".", ",")) * 1000
                temp1(i).tabbellen_paramter("TexthöheZeile") = w
                temp1(i).tabbellen_paramter("TexthöheKopfZeile") = w
            ElseIf zeile = "#TS" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("SchriftartZeile")
                w.s = zeile
                temp1(i).tabbellen_paramter("SchriftartZeile") = w
                temp1(i).tabbellen_paramter("SchriftartKopfZeile") = w
            ElseIf zeile = "#TK" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("SchriftstilZeile")
                w.s = zeile
                temp1(i).tabbellen_paramter("SchriftstilZeile") = w
                temp1(i).tabbellen_paramter("SchriftstilKopfZeile") = w

            ElseIf zeile = "#TU" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("UnterstrichenZeile")
                w.b = CBool(zeile)
                temp1(i).tabbellen_paramter("UnterstrichenZeile") = w
                temp1(i).tabbellen_paramter("UnterstrichenKopfZeile") = w
            ElseIf zeile = "#TD" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("DurchgestrichenZeile")
                w.b = CBool(zeile)
                temp1(i).tabbellen_paramter("DurchgestrichenZeile") = w
                temp1(i).tabbellen_paramter("DurchgestrichenKopfZeile") = w
            ElseIf zeile = "#PLUS" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("PlusZeichen")
                If zeile = "+" Then w.b = True Else w.b = False
                temp1(i).generelle_paramter("PlusZeichen") = w
            ElseIf zeile = "#SST" Then
                zeile = fileReader.ReadLine()
                If Left(zeile, 3) = "Non" Then
                    'w.s = "keine"
                    w = temp1(i).generelle_paramter("SchichtStärkeKeine")
                    w.b = True
                    temp1(i).generelle_paramter("SchichtStärkeKeine") = w
                End If
                If Left(zeile, 3) = "Inp" Then
                    'w.s = "abfragen"
                    w = temp1(i).generelle_paramter("SchichtStärkeAbfragen")
                    w.b = True
                    temp1(i).generelle_paramter("SchichtStärkeAbfragen") = w
                End If
                If Left(zeile, 3) = "Fix" Then
                    'w.s = "fix"
                    w = temp1(i).generelle_paramter("SchichtStärkeFix")
                    w.b = True
                    temp1(i).generelle_paramter("SchichtStärkeFix") = w
                End If
                'temp1(i).generelle_paramter("SchichtStärkeAbfragen") = w
                If zeile = "Fix" Then
                    w = temp1(i).generelle_paramter("SchichtStärke")
                    w.d = CDbl(Replace(Mid(zeile, 4), ",", "."))
                    temp1(i).generelle_paramter("SchichtStärke") = w
                End If
            ElseIf zeile = "#LEER" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("ReaktionAufLeerePassung")
                If zeile = "ignore" Then
                    w.b = False
                Else
                    w.b = True
                End If
                temp1(i).generelle_paramter("ReaktionAufLeerePassung") = w
            ElseIf zeile = "#HEADER" Then
                zeile = fileReader.ReadLine()
                'w = temp1(i).tabbellen_paramter("Header")
                If zeile = "KOPFZEILE" Then
                    'w.s = "oben"
                    w = temp1(i).tabbellen_paramter("HeaderOben")
                    w.b = True
                    temp1(i).tabbellen_paramter("HeaderOben") = w
                Else
                    'w.s = "unten"
                    w = temp1(i).tabbellen_paramter("HeaderUnten")
                    w.b = True
                    temp1(i).tabbellen_paramter("HeaderUnten") = w
                End If
                'temp1(i).tabbellen_paramter("Header") = w
            ElseIf zeile = "#HEADER-LANG" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("HeaderLanguage")
                w.s = zeile
                temp1(i).tabbellen_paramter("HeaderLanguage") = w
            ElseIf zeile = "#TABTYPE" Then
                zeile = fileReader.ReadLine()
                ' w = temp1(i).tabbellen_paramter("TabellenTyp")
                'w.i = CInt(zeile)
                'temp1(i).tabbellen_paramter("TabellenTyp") = w

                w = temp1(i).tabbellen_paramter("TabSpalteMaß")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteMaß") = w

                w = temp1(i).tabbellen_paramter("TabSpaltePassung")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpaltePassung") = w

                w = temp1(i).tabbellen_paramter("TabSpalteMaßePassung")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteMaßePassung") = w

                w = temp1(i).tabbellen_paramter("TabSpalteToleranz")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteToleranz") = w

                w = temp1(i).tabbellen_paramter("TabSpalteAbmaß")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteAbmaß") = w

                w = temp1(i).tabbellen_paramter("TabSpalteAbmaßToleranzMitte")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteAbmaßToleranzMitte") = w

                w = temp1(i).tabbellen_paramter("TabSpalteVorbearbeitungsAbmaße")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteVorbearbeitungsAbmaße") = w

                w = temp1(i).tabbellen_paramter("TabSpalteVorbearbeitungsToleranzMitte")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteVorbearbeitungsToleranzMitte") = w

                w = temp1(i).tabbellen_paramter("TabSpalteAnzahl")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteAnzahl") = w

                w = temp1(i).tabbellen_paramter("TabSpalteZone")
                w.b = False
                temp1(i).tabbellen_paramter("TabSpalteZone") = w

                Select Case CInt(zeile)
                    Case 1
                        w = temp1(i).tabbellen_paramter("TabSpalteMaß")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteMaß") = w

                        w = temp1(i).tabbellen_paramter("TabSpaltePassung")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpaltePassung") = w

                        w = temp1(i).tabbellen_paramter("TabSpalteToleranz")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteToleranz") = w

                        w = temp1(i).tabbellen_paramter("TabSpalteAbmaß")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteAbmaß") = w
                    Case 2
                        w = temp1(i).tabbellen_paramter("TabSpalteMaßePassung")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteMaßePassung") = w
                        w = temp1(i).tabbellen_paramter("TabSpalteAbmaß")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteAbmaß") = w
                    Case 3
                        w = temp1(i).tabbellen_paramter("TabSpalteMaßePassung")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteMaßePassung") = w
                        w = temp1(i).tabbellen_paramter("TabSpalteToleranz")
                        w.b = True
                        temp1(i).tabbellen_paramter("TabSpalteToleranz") = w
                End Select
            ElseIf zeile = "#TABBORDER" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("RahmenStrichStärke")
                Select Case Trim(zeile)
                    Case "1"
                        w.s = "Dünn"
                    Case "2"
                        w.s = "Normal"
                    Case "3"
                        w.s = "Dick"
                    Case "4"
                        w.s = "Dick(2)"
                    Case "5"
                        w.s = "Dick(3)"
                    Case "6"
                        w.s = "Dick(4)"
                    Case "7"
                        w.s = "Dick(5)"
                    Case "8"
                        w.s = "Dick(6)"
                End Select
                temp1(i).tabbellen_paramter("RahmenStrichStärke") = w
            ElseIf zeile = "#TABGRID" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).tabbellen_paramter("RasterStrichStärke")
                Select Case Trim(zeile)
                    Case "1"
                        w.s = "Dünn"
                    Case "2"
                        w.s = "Normal"
                    Case "3"
                        w.s = "Dick"
                    Case "4"
                        w.s = "Dick(2)"
                    Case "5"
                        w.s = "Dick(3)"
                    Case "6"
                        w.s = "Dick(4)"
                    Case "7"
                        w.s = "Dick(5)"
                    Case "8"
                        w.s = "Dick(6)"
                End Select
                temp1(i).tabbellen_paramter("RasterStrichStärke") = w
            ElseIf zeile = "#REPOS" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("NeuPositionieren")
                w.b = CBool(zeile)
                temp1(i).generelle_paramter("NeuPositionieren") = w
            ElseIf zeile = "#LOG" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("LogDatei")
                w.b = Val(zeile)
                temp1(i).generelle_paramter("LogDatei") = w
            ElseIf zeile = "#NOMSG" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("Fehlermeldung")
                w.b = zeile
                temp1(i).generelle_paramter("Fehlermeldung") = w
            ElseIf zeile = "#PAGE1ONLY" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("NurAufErstemBlatt")
                w.b = CBool(zeile)
                temp1(i).generelle_paramter("NurAufErstemBlatt") = w
            ElseIf zeile = "#OTHER_PAGES" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("LöschenAufRestlichenBlättern")
                w.b = CBool(zeile)
                temp1(i).generelle_paramter("LöschenAufRestlichenBlättern") = w
            ElseIf zeile = "#V_TYPE" Then
                zeile = fileReader.ReadLine()
                w = temp1(i).generelle_paramter("AnsichtsTypSkizzen")
                If (CInt(zeile) Or 1) > 0 Then w.b = True Else w.b = False
                temp1(i).generelle_paramter("AnsichtsTypSkizzen") = w

                w = temp1(i).generelle_paramter("AnsichtsTypTeile")
                If (CInt(zeile) Or 2) > 0 Then w.b = True Else w.b = False
                temp1(i).generelle_paramter("AnsichtsTypTeile") = w

                w = temp1(i).generelle_paramter("AnsichtsTypBaugruppen")
                If (CInt(zeile) Or 4) > 0 Then w.b = True Else w.b = False
                temp1(i).generelle_paramter("AnsichtsTypBaugruppen") = w

            Else
            End If
            If Not EOF(1) Then zeile = fileReader.ReadLine()
        End While

        fileReader.Close()
        Read_old_ini_neu = temp1
    End Function

    Sub Write_XML_Header(ByRef XmlWrt As XmlWriter)
        With XmlWrt
            ' Write the Xml declaration.
            .WriteStartDocument()
            ' Write a comment.
            .WriteComment("Passunstabelle-INI")
            ' Write the root element.
            .WriteStartElement("Data")
        End With
    End Sub

    Sub Write_XML_Sprachen(ByRef XmlWrt As XmlWriter, Liste_Sprachen As List(Of Definitionen.Sprach_Codes))
        ' Start our first person.
        XmlWrt.WriteStartElement("Sprachen")

        For Each n In Liste_Sprachen
            With XmlWrt
                .WriteStartElement("Sprache")
                .WriteAttributeString("Kürzel", n.Kürzel)
                .WriteAttributeString("Sprache", n.Beschreibung)
                .WriteEndElement()
            End With
        Next
        ' Ende Sprachen
        XmlWrt.WriteEndElement()
    End Sub

    Sub Write_XML_Sprachen_neu(ByRef XmlWrt As XmlWriter)
        ' Start our first person.
        XmlWrt.WriteStartElement("Sprachen")

        For Each n In Definitionen.SPRACHATTR
            With XmlWrt
                .WriteStartElement("Sprache")
                .WriteAttributeString("Kürzel", n.Key)
                .WriteAttributeString("Sprache", n.Value)
                .WriteEndElement()
            End With
        Next
        ' Ende Sprachen
        XmlWrt.WriteEndElement()
    End Sub

    Sub Write_XML_Linienarten(ByRef XmlWrt As XmlWriter, Liste_Linien As List(Of String))
        ' Start our first person.
        XmlWrt.WriteStartElement("Linienarten")

        For Each n In Liste_Linien
            With XmlWrt
                .WriteStartElement("Linienart")
                .WriteAttributeString("Name", n)
                .WriteEndElement()
            End With
        Next
        ' Ende Sprachen
        XmlWrt.WriteEndElement()
    End Sub


    Sub Write_XML_Tabellenattribute_neu(ByRef XmlWrt As XmlWriter, attribute As Definitionen.Strctformat)
        Dim w As Definitionen.Werte
        Dim attr As Dictionary(Of String, String) = Definitionen.TABELLENATTR

        With XmlWrt
            ' Start Tabellenattribute
            .WriteStartElement("TabellenAttribute")

            For Each item As KeyValuePair(Of String, String) In attr
                w = attribute.tabbellen_paramter(item.Key)
                Select Case item.Value
                    Case "String"
                        .WriteAttributeString(item.Key, w.s)
                    Case "Integer"
                        .WriteAttributeString(item.Key, w.i)
                    Case "Double"
                        .WriteAttributeString(item.Key, w.d)
                    Case "Boolean"
                        .WriteAttributeString(item.Key, w.b)
                    Case "Combobox"
                        .WriteAttributeString(item.Key, w.co)
                    Case "RadioButtonGroup"
                        .WriteAttributeString(item.Key, w.s)
                    Case "ColorTextField"
                        .WriteAttributeString(item.Key, w.i)
                    Case "ComboBox"
                        .WriteAttributeString(item.Key, w.s)
                    Case Else
                        .WriteAttributeString(item.Key, "")
                End Select
            Next
            ' Ende Tabellenattribute
            .WriteEndElement()
        End With
    End Sub


    Sub Write_XML_FormatAttribute_neu(ByRef XmlWrt As XmlWriter, attribute As Definitionen.Strctformat)
        Dim w As Definitionen.Werte
        Dim attr As Dictionary(Of String, String) = Definitionen.FORMATATTR


        With XmlWrt
            ' Start Formatattribute
            .WriteStartElement("FormatAttribute")
            For Each item As KeyValuePair(Of String, String) In attr
                w = attribute.format_paramter(item.Key)
                Select Case item.Value
                    Case "String"
                        .WriteAttributeString(item.Key, w.s)
                    Case "Integer"
                        .WriteAttributeString(item.Key, w.i)
                    Case "Double"
                        .WriteAttributeString(item.Key, w.d)
                    Case "Boolean"
                        .WriteAttributeString(item.Key, w.b)
                    Case "Combobox"
                        .WriteAttributeString(item.Key, w.co)
                    Case "RadioButtonGroup"
                        .WriteAttributeString(item.Key, w.s)
                    Case "ColorTextField"
                        .WriteAttributeString(item.Key, w.i)
                    Case "ComboBox"
                        .WriteAttributeString(item.Key, w.s)
                    Case Else
                        .WriteAttributeString(item.Key, "")
                End Select
            Next
            ' Ende Formatattribute
            .WriteEndElement()
        End With
    End Sub

    Sub Write_XML_Formate_neu(ByRef XmlWrt As XmlWriter, Liste_Formate As List(Of Definitionen.Strctformat))
        'Dim attr As Dictionary(Of String, String) = Definitionen.GENERELLE_ATTR

        'Abschnitt Formate beginnen
        XmlWrt.WriteStartElement("Formate")
        For Each n In Liste_Formate
            With XmlWrt
                'Abschnitt Format beginnen
                XmlWrt.WriteStartElement("Format")
                'Formatname schreiben
                .WriteAttributeString("Formatname", n.format)
                'Formatattribute schreiben
                Write_XML_FormatAttribute_neu(XmlWrt, n)
                'Abschnitt Tabelle beginnen
                .WriteStartElement("Tabelle")
                'Tabellenattribute schreiben
                Write_XML_Tabellenattribute_neu(XmlWrt, n)
                'Abschnitt Tabelle beenden
                .WriteEndElement()
                'Abschnitt Format beenden
                .WriteEndElement()
            End With
        Next
        'Abschnitt Formate beenden
        XmlWrt.WriteEndElement()
    End Sub

    Sub Write_XML_Generell_neu(ByRef XmlWrt As XmlWriter, attribute As Definitionen.Strctformat)
        Dim w As Definitionen.Werte
        Dim attr As Dictionary(Of String, String) = Definitionen.GENERELLE_ATTR


        'Abschnitt Generell beginnen
        XmlWrt.WriteStartElement("Generell")

        With XmlWrt
            'Abschnitt GenerelleAttribute beginnen
            .WriteStartElement("GenerelleAttribute")
            'Alle generellen Attribute durchlaufen
            For Each item As KeyValuePair(Of String, String) In attr
                w = attribute.generelle_paramter(item.Key)
                Select Case item.Value
                    Case "String"
                        .WriteAttributeString(item.Key, w.s)
                    Case "Integer"
                        .WriteAttributeString(item.Key, w.i)
                    Case "Double"
                        .WriteAttributeString(item.Key, w.d)
                    Case "Boolean"
                        .WriteAttributeString(item.Key, w.b)
                    Case "Combobox"
                        .WriteAttributeString(item.Key, w.co)
                    Case "RadioButtonGroup"
                        .WriteAttributeString(item.Key, w.s)
                    Case "ColorTextField"
                        .WriteAttributeString(item.Key, w.i)
                    Case "ComboBox"
                        .WriteAttributeString(item.Key, w.s)
                    Case Else
                        .WriteAttributeString(item.Key, "")
                End Select
            Next
            'Abschnitt GenerelleAttribute beenden
            XmlWrt.WriteEndElement()
        End With
        'Abschnitt Generell beenden
        XmlWrt.WriteEndElement()
    End Sub
    'Sub Write_XML_Tab_sprachen(ByRef XmlWrt As XmlWriter, Liste_sprachen As List(Of Definitionen.Tab_Sprache))
    '    ' Start our first person.
    '    XmlWrt.WriteStartElement("Übersetzungen")
    '    For Each n In Liste_sprachen
    '        With XmlWrt
    '            .WriteStartElement("Übersetzung")
    '            .WriteAttributeString("Kürzel", n.kennung)
    '            .WriteAttributeString("Passung", n.pass)
    '            .WriteAttributeString("Maß", n.masz)
    '            .WriteAttributeString("Toleranz", n.Tol)
    '            .WriteAttributeString("Abmaß", n.Abm)
    '            .WriteAttributeString("VorbearbeitungsAbmaße", n.vor)
    '            .WriteEndElement()
    '        End With
    '    Next
    '    ' Ende Sprachen
    '    XmlWrt.WriteEndElement()
    'End Sub

    Function Berechne_Sprachkombinationen(Liste_sprachen As Dictionary(Of String, Dictionary(Of String, String))) As List(Of String)
        Dim kombinationen As New List(Of String)
        Dim temp As String
        Dim zähler As Integer


        For Each item As KeyValuePair(Of String, Dictionary(Of String, String)) In Liste_sprachen
            kombinationen.Add(item.Key)
        Next

        zähler = kombinationen.Count - 1
        For i = 0 To zähler
            temp = kombinationen.Item(i)
            For j = 0 To zähler
                If kombinationen.Item(j) <> temp Then
                    kombinationen.Add(temp & "/" & kombinationen.Item(j))
                End If
            Next
        Next
        Berechne_Sprachkombinationen = kombinationen
    End Function

    Function Berechne_Sprachkombinationen_FromSimpleList(Liste_sprachen As List(Of String)) As List(Of String)
        Dim kombinationen As New List(Of String)
        Dim temp As String
        Dim zähler As Integer


        For Each item In Liste_sprachen
            kombinationen.Add(item)
        Next

        zähler = kombinationen.Count - 1
        For i = 0 To zähler
            temp = kombinationen.Item(i)
            For j = 0 To zähler
                If kombinationen.Item(j) <> temp Then
                    kombinationen.Add(temp & "/" & kombinationen.Item(j))
                End If
            Next
        Next
        Berechne_Sprachkombinationen_FromSimpleList = kombinationen
    End Function

    Sub Write_XML_Tab_Sprachkombinationen(ByRef xmlWrt As XmlWriter, Liste_sprachen As Dictionary(Of String, Dictionary(Of String, String)))
        Dim kombinationen As New List(Of String)

        kombinationen = Berechne_Sprachkombinationen(Liste_sprachen)

        xmlWrt.WriteStartElement("Sprachkombinationen")

        With xmlWrt
            For Each n In kombinationen
                .WriteStartElement("Sprachkombination")
                .WriteAttributeString("Name", n)
                xmlWrt.WriteEndElement()
            Next
        End With
        ' Ende Sprachen
        xmlWrt.WriteEndElement()
    End Sub
    Sub Write_XML_Tab_sprachen_neu(ByRef XmlWrt As XmlWriter, Liste_sprachen As Dictionary(Of String, Dictionary(Of String, String)))
        ' Start our first person.
        XmlWrt.WriteStartElement("Übersetzungen")


        With XmlWrt
            For Each item As KeyValuePair(Of String, Dictionary(Of String, String)) In Liste_sprachen
                .WriteStartElement("Übersetzung")
                For Each spracheintrag As KeyValuePair(Of String, String) In item.Value
                    .WriteAttributeString(spracheintrag.Key, spracheintrag.Value)
                Next
                .WriteEndElement()
            Next
        End With


        ' Ende Sprachen
        XmlWrt.WriteEndElement()
    End Sub

    Function Write_XML_from_old_ini(ByRef dlg As SetupDialog) As Boolean
        Dim settings As New XmlWriterSettings()
        Dim pfad As String
        Dim temp2 As New List(Of Definitionen.Strctformat) 'Formatattribute
        Dim temp3 As New Dictionary(Of String, Dictionary(Of String, String)) 'Übersetzungen


        settings.Indent = True
        settings.IndentChars = "   "
        settings.NewLineOnAttributes = True

        dlg.ToolStripProgressBar1.Maximum = 10
        dlg.ToolStripProgressBar1.Minimum = 0

        dlg.ToolStripProgressBar1.Value = 2
        dlg.ToolStripStatusLabel1.Text = "Formate einlesen"
        dlg.Refresh()
        temp2 = Read_old_ini_neu()
        If temp2.Count = 0 Then
            Write_XML_from_old_ini = False
            Exit Function
        End If

        dlg.ToolStripProgressBar1.Value = 3
        dlg.ToolStripStatusLabel1.Text = "Übersetzungen einlesen"
        dlg.Refresh()
        temp3 = Read_Tab_sprachen_neu()
        If temp3.Count = 0 Then
            Write_XML_from_old_ini = False
            Exit Function
        End If


        'pfad = SwxMacroPfad & "\" & Definitionen.INI_File
        pfad = SwxMacroPfad & Definitionen.INI_File
        Dim XmlWrt As XmlWriter = XmlWriter.Create(pfad, settings)

        dlg.ToolStripProgressBar1.Value = 4
        dlg.ToolStripStatusLabel1.Text = "Header schreiben"
        dlg.Refresh()
        Write_XML_Header(XmlWrt)

        dlg.ToolStripProgressBar1.Value = 5
        dlg.ToolStripStatusLabel1.Text = "Sprachen schreiben"
        dlg.Refresh()
        Write_XML_Sprachen_neu(XmlWrt)

        Write_XML_Tab_Sprachkombinationen(XmlWrt, temp3)

        Write_XML_Linienarten(XmlWrt, Definitionen.LINIENARTEN)

        dlg.ToolStripProgressBar1.Value = 6
        dlg.ToolStripStatusLabel1.Text = "Generelle Einstellungen schreiben"
        dlg.Refresh()
        Write_XML_Generell_neu(XmlWrt, temp2.Item(0))

        dlg.ToolStripProgressBar1.Value = 7
        dlg.ToolStripStatusLabel1.Text = "Übersetzungen schreiben"
        dlg.Refresh()
        Write_XML_Tab_sprachen_neu(XmlWrt, temp3)

        dlg.ToolStripProgressBar1.Value = 8
        dlg.ToolStripStatusLabel1.Text = "Formate schreiben"
        dlg.Refresh()
        Write_XML_Formate_neu(XmlWrt, temp2)

        dlg.ToolStripProgressBar1.Value = 9
        dlg.ToolStripStatusLabel1.Text = "Datei schreiben"
        dlg.Refresh()

        With XmlWrt
            .WriteEndDocument()
            .Close()
        End With
        dlg.ToolStripStatusLabel1.Text = "alte INI Datei konvertiert"
        Write_XML_from_old_ini = True

    End Function

    Sub Create_strct(attr As Definitionen.Attribute, dic As Dictionary(Of String, String), ByRef temp As Definitionen.Strctformat)
        Dim w As Definitionen.Werte
        Dim p As New Dictionary(Of String, Definitionen.Werte)

        For Each item As KeyValuePair(Of String, String) In dic
            Select Case item.Value
                Case "String"
                    w = New Definitionen.Werte With {.s = ""}
                    p.Add(item.Key, w)
                Case "Double"
                    w = New Definitionen.Werte With {.d = 0.0}
                    p.Add(item.Key, w)
                Case "Integer"
                    w = New Definitionen.Werte With {.i = 0}
                    p.Add(item.Key, w)
                Case "Boolean"
                    w = New Definitionen.Werte With {.b = False}
                    p.Add(item.Key, w)
                Case "RadioButtonGroup"
                    w = New Definitionen.Werte With {.s = ""}
                    p.Add(item.Key, w)
                Case "ColorTextField"
                    w = New Definitionen.Werte With {.co = 0}
                    p.Add(item.Key, w)
                Case "ComboBox"
                    w = New Definitionen.Werte With {.s = ""}
                    p.Add(item.Key, w)
            End Select
        Next

        Select Case attr
            Case Definitionen.Attribute.FORMATATTR
                temp.format_paramter = p
            Case Definitionen.Attribute.GENERELLE_Attr
                temp.generelle_paramter = p
            Case Definitionen.Attribute.TABELLENATTR
                temp.tabbellen_paramter = p
        End Select
    End Sub

End Module
