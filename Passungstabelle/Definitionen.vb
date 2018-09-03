Imports System.Collections.Generic



Public Class Definitionen
    Public Property Xmlshema As System.IO.StringReader

    Public Const OLD_INI_File = "Passungstabelle.ini"
    Public Const INI_File = "Setup.XML"
    Public Const LOGName = "Passungstabelle"
    Public Const ts = "String"
    Public Const ti = "Integer"
    Public Const td = "Double"
    Public Const tb = "Boolean"
    Public Const trg = "RadioButtonGroup"
    Public Const tcolor = "ColorTextField"
    Public Const tcb = "ComboBox"

    Public Enum Attribute
        GENERELLE_Attr = 1
        TABELLENATTR = 2
        TABELLENTEXTATTR = 3
        TABELLENRASTERATTR = 4
        FORMATATTR = 5
        SPRACHATTR = 100
        ÜBERSETZUNGSATTR = 200
    End Enum

    Public Shared GENERELLE_ATTR As New Dictionary(Of String, String) From {{"RundenAuf", ti}, {"PlusZeichen", tb}, {"ReaktionAufLeerePassung", tb}, {"NeuPositionieren", tb}, {"NurAufErstemBlatt", tb}, {"AnsichtsTypSkizzen", tb}, {"AnsichtsTypTeile", tb}, {"AnsichtsTypBaugruppen", tb}, {"LogDatei", tb}, {"SchichtStärke", td}, {"SchichtStärkeAbfragen", tb}, {"SchichtStärkeKeine", tb}, {"SchichtStärkeFix", tb}, {"Fehlermeldung", tb}, {"LöschenAufRestlichenBlättern", tb}, {"Eventgesteuert", tb}}
    Public Shared GENERELLE_ATTR_Init As New Dictionary(Of String, String) From {{"RundenAuf", "8"}, {"PlusZeichen", "True"}, {"ReaktionAufLeerePassung", "False"}, {"NeuPositionieren", "True"}, {"NurAufErstemBlatt", "True"}, {"AnsichtsTypSkizzen", "True"}, {"AnsichtsTypTeile", "True"}, {"AnsichtsTypBaugruppen", "True"}, {"LogDatei", "False"}, {"SchichtStärke", "0"}, {"SchichtStärkeAbfragen", tb}, {"SchichtStärkeKeine", "True"}, {"SchichtStärkeFix", "False"}, {"Fehlermeldung", "False"}, {"LöschenAufRestlichenBlättern", "True"}, {"Eventgesteuert", "False"}}
    Public Shared TABELLENATTR As New Dictionary(Of String, String) From {{"HeaderOben", tb}, {"HeaderUnten", tb}, {"HeaderLanguage", ts}, {"SchriftartZeile", ts}, {"SchriftstilZeile", ts}, {"UnterstrichenZeile", tb}, {"DurchgestrichenZeile", tb}, {"FettZeile", tb}, {"TexthöheZeile", td}, {"FarbeZeile", ts}, {"KursivZeile", tb}, {"SchriftartKopfZeile", ts}, {"SchriftstilKopfZeile", ts}, {"UnterstrichenKopfZeile", tb}, {"DurchgestrichenKopfZeile", tb}, {"FettKopfZeile", tb}, {"TexthöheKopfZeile", td}, {"FarbeKopfZeile", ts}, {"KursivKopfZeile", tb}, {"BreiteSpalteMaß", td}, {"BreiteSpaltePassung", td}, {"BreiteSpalteMaßePassung", td}, {"BreiteSpalteToleranz", td}, {"BreiteSpalteAbmaß", td}, {"BreiteSpalteAbmaßToleranzMitte", td}, {"BreiteSpalteVorbearbeitungsAbmaße", td}, {"BreiteSpalteVorbearbeitungsToleranzMitte", td}, {"RasterStrichStärke", ts}, {"RahmenStrichStärke", ts}, {"SpaltenBreiteAutomatisch", tb}, {"TabSpalteMaß", tb}, {"TabSpaltePassung", tb}, {"TabSpalteMaßePassung", tb}, {"TabSpalteToleranz", tb}, {"TabSpalteAbmaß", tb}, {"TabSpalteAbmaßToleranzMitte", tb}, {"TabSpalteVorbearbeitungsAbmaße", tb}, {"TabSpalteVorbearbeitungsToleranzMitte", tb}}
    Public Shared TABELLENATTR_Init As New Dictionary(Of String, String) From {{"HeaderOben", "True"}, {"HeaderUnten", "False"}, {"HeaderLanguage", "DE"}, {"SchriftartZeile", "Arial"}, {"SchriftstilZeile", "Standard"}, {"UnterstrichenZeile", "False"}, {"DurchgestrichenZeile", "False"}, {"FettZeile", "False"}, {"TexthöheZeile", "2,5"}, {"FarbeZeile", "0"}, {"KursivZeile", "False"}, {"SchriftartKopfZeile", "Arial"}, {"SchriftstilKopfZeile", "Standard"}, {"UnterstrichenKopfZeile", "False"}, {"DurchgestrichenKopfZeile", "False"}, {"FettKopfZeile", "False"}, {"TexthöheKopfZeile", "2,5"}, {"FarbeKopfZeile", "0"}, {"KursivKopfZeile", "False"}, {"BreiteSpalteMaß", "15"}, {"BreiteSpaltePassung", "15"}, {"BreiteSpalteMaßePassung", "20"}, {"BreiteSpalteToleranz", "20"}, {"BreiteSpalteAbmaß", "20"}, {"BreiteSpalteAbmaßToleranzMitte", "20"}, {"BreiteSpalteVorbearbeitungsAbmaße", "20"}, {"BreiteSpalteVorbearbeitungsToleranzMitte", "20"}, {"RasterStrichStärke", "Dünn"}, {"RahmenStrichStärke", "Dick"}, {"SpaltenBreiteAutomatisch", "False"}, {"TabSpalteMaß", "True"}, {"TabSpaltePassung", "True"}, {"TabSpalteMaßePassung", "True"}, {"TabSpalteToleranz", "True"}, {"TabSpalteAbmaß", "True"}, {"TabSpalteAbmaßToleranzMitte", "True"}, {"TabSpalteVorbearbeitungsAbmaße", "True"}, {"TabSpalteVorbearbeitungsToleranzMitte", "True"}}
    Public Shared FORMATATTR As New Dictionary(Of String, String) From {{"Breite", td}, {"Höhe", td}, {"EinfügepunktLO", tb}, {"EinfügepunktRO", tb}, {"EinfügepunktLU", tb}, {"EinfügepunktRU", tb}, {"Offset_X", td}, {"Offset_Y", td}}
    Public Shared FORMATATTR_Init As New Dictionary(Of String, String) From {{"Breite", "210"}, {"Höhe", "297"}, {"EinfügepunktLO", "False"}, {"EinfügepunktRO", "True"}, {"EinfügepunktLU", "False"}, {"EinfügepunktRU", "False"}, {"Offset_X", "0"}, {"Offset_Y", "0"}}
    Public Shared ÜBERSETZUNGSATTR As New Dictionary(Of String, String) From {{"Kürzel", ts}, {"Passung", ts}, {"Toleranz", ts}, {"Abmaß", ts}, {"VorbearbeitungsAbmaße", ts}, {"Maß", ts}, {"MaßePassung", ts}, {"AbmaßToleranzMitte", ts}, {"VorbearbeitungsToleranzMitte", ts}}
    Public Shared ÜBERSETZUNGSATTR_Init As New Dictionary(Of String, String) From {{"Kürzel", "DE"}, {"Passung", "Passung"}, {"Toleranz", "Toleranz"}, {"Abmaß", "Abmaß"}, {"VorbearbeitungsAbmaße", "Vorbearbeitung"}, {"Maß", "Maß"}, {"MaßePassung", "Maß+Passung"}, {"AbmaßToleranzMitte", "Abmaß Toleranzmitte"}, {"VorbearbeitungsToleranzMitte", "Vorbearbeitungs ToleranzMitte"}}
    Public Shared LINIENARTEN As New List(Of String) From {"Dünn", "Normal", "Dick", "Dick(2)", "Dick(3)", "Dick(4)", "Dick(5)", "Dick(6)"}
    Public Shared SPRACHATTR As New Dictionary(Of String, String) From {{"AA", "Afar"}, {"AB", "Abchasisch"}, {"AF", "Afrikaans"}, {"AM", "Amharisch"}, {"AR", "Arabisch"}, {"AS", "Assamesisch"}, {"AY", "Aymara"}, {"AZ", "Aserbaidschanisch"}, {"BA", "Baschkirisch"}, {"BE", "Belorussisch"}, {"BG", "Bulgarisch"}, {"BH", "Biharisch"}, {"BI", "Bislamisch"}, {"BN", "Bengalisch"}, {"BO", "Tibetanisch"}, {"BR", "Bretonisch"}, {"CA", "Katalanisch"}, {"CO", "Korsisch"}, {"CS", "Tschechisch"}, {"CY", "Walisisch"}, {"DA", "Dänisch"}, {"DE", "Deutsch"}, {"DZ", "Dzongkha/ Bhutani"}, {"EL", "Griechisch"}, {"EN", "Englisch"}, {"EO", "Esperanto"}, {"ES", "Spanisch"}, {"ET", "Estnisch"}, {"EU", "Baskisch"}, {"FA", "Persisch"}, {"FI", "Finnisch"}, {"FJ", "Fiji"}, {"FO", "Färöisch"}, {"FR", "Französisch"}, {"FY", "Friesisch"}, {"GA", "Irisch"}, {"GD", "Schottisches Gälisch"}, {"GL", "Galizisch"}, {"GN", "Guarani"}, {"GU", "Gujaratisch"}, {"HA", "Haussa"}, {"HE", "Hebräisch"}, {"HI", "Hindi"}, {"HR", "Kroatisch"}, {"HU", "Ungarisch"}, {"HY", "Armenisch"}, {"IA", "Interlingua"}, {"ID", "Indonesisch"}, {"IE", "Interlingue"}, {"IK", "Inupiak"}, {"IS", "Isländisch"}, {"IT", "Italienisch"}, {"IU", "Inuktitut (Eskimo)"}, {"IW", "Hebräisch (aktualisiert: HE)"}, {"JA", "Japanisch"}, {"JI", "Jiddish (aktualisiert: YI)"}, {"JV", "Javanisch"}, {"KA", "Georgisch"}, {"KK", "Kasachisch"}, {"KL", "Kalaallisut"}, {"KM", "Kambodschanisch"}, {"KN", "Kannada"}, {"KO", "Koreanisch"}, {"KS", "Kaschmirisch"}, {"KU", "Kurdisch"}, {"KY", "Kirgisisch"}, {"LA", "Lateinisch"}, {"LN", "Lingala"}, {"LO", "Laotisch"}, {"LT", "Litauisch"}, {"LV", "Lettisch"}, {"MG", "Malagasisch"}, {"MI", "Maorisch"}, {"MK", "Mazedonisch"}, {"ML", "Malajalam"}, {"MN", "Mongolisch"}, {"MO", "Moldavisch"}, {"MR", "Marathi"}, {"MS", "Malaysisch"}, {"MT", "Maltesisch"}, {"MY", "Burmesisch"}, {"NA", "Nauruisch"}, {"NE", "Nepalesisch"}, {"NL", "Holländisch"}, {"NO", "Norwegisch"}, {"OC", "Okzitanisch"}, {"OM", "Oromo"}, {"OR", "Oriya"}, {"PA", "Pundjabisch"}, {"PL", "Polnisch"}, {"PS", "Paschtu"}, {"PT", "Portugiesisch"}, {"QU", "Quechua"}, {"RM", "Rätoromanisch"}, {"RN", "Kirundisch"}, {"RO", "Rumänisch"}, {"RU", "Russisch"}, {"RW", "Kijarwanda"}, {"SA", "Sanskrit"}, {"SD", "Zinti"}, {"SG", "Sango"}, {"SH", "Serbokroatisch"}, {"SI", "Singhalesisch"}, {"SK", "Slowakisch"}, {"SL", "Slowenisch"}, {"SM", "Samoanisch"}, {"SN", "Schonisch"}, {"SO", "Somalisch"}, {"SQ", "Albanisch"}, {"SR", "Serbisch"}, {"SS", "Swasiländisch"}, {"ST", "Sesothisch"}, {"SU", "Sudanesisch"}, {"SV", "Schwedisch"}, {"SW", "Suaheli"}, {"TA", "Tamilisch"}, {"TE", "Tegulu"}, {"TG", "Tadschikisch"}, {"TH", "Thai"}, {"TI", "Tigrinja"}, {"TK", "Turkmenisch"}, {"TL", "Tagalog"}, {"TN", "Sezuan"}, {"TO", "Tongaisch"}, {"TR", "Türkisch"}, {"TS", "Tsongaisch"}, {"TT", "Tatarisch"}, {"TW", "Twi"}, {"UG", "Uigur"}, {"UK", "Ukrainisch"}, {"UR", "Urdu"}, {"UZ", "Usbekisch"}, {"VI", "Vietnamesisch"}, {"VO", "Volapük"}, {"WO", "Wolof"}, {"XH", "Xhosa"}, {"YI", "Jiddish"}, {"YO", "Joruba"}, {"ZA", "Zhuang"}, {"ZH", "Chinesisch"}, {"ZU", "Zulu"}}

    Public Structure BlattEigenschaften
        Dim Formatname As String
        Dim sprache As String
        Dim Eigenschaften As Object
    End Structure
    Public Structure Werte
        Dim s As String
        Dim d As Double
        Dim i As Integer
        Dim b As Boolean
        Dim co As Int32

    End Structure

    Public Structure Strctformat
        Dim format As String
        Dim generelle_paramter As Dictionary(Of String, Werte)
        Dim tabbellen_paramter As Dictionary(Of String, Werte)
        Dim format_paramter As Dictionary(Of String, Werte)
    End Structure

    Structure Sprach_Codes
        Dim Kürzel As String
        Dim Beschreibung As String
    End Structure

    Structure Tab_Sprache
        Dim kennung As String   'Ländercode
        Dim pass As String   'String für "Passung"
        Dim Tol As String   'String für "Toleranz"
        Dim Abm As String   'String für "Abmaß"
        Dim vor As String   'String für "Vorbearbeitung"
        Dim masz As String   'String für "Maß"
    End Structure



End Class
