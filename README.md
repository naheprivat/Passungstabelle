# Passungstabelle
Allgemeine Hinweise
Bei diesem Add-In handelt es sich um ein Add-In für SolidWorks.
Es erstellt eine Passungstabelle auf Zeichnungen.

Dieses Add-In ist "just for fun" entstanden
Da ich kein Programmierer bin, stehen einem professionellen Programmierer
unter Umständen bei manchen Teilen, die Haare zu Berge.
Dieses Add-In erhebt keinen Anspruch auf Professionalität und die Verwendung erfolgt auf eigene Gefahr

Add-In Hinweise
Der Pfad zur Setup.XML Datei wird in der Registry gespeichert unter "HKEY_LOCAL_MACHINE\Software\nahe"
und unter dem Schlüssel "SetupPfad"
Wird der Schlüssel nicht gefunden wird die Setup.XML Datei im ausführenden Verzeichnis des Add-In´s gesucht
Bei der Installation durch das Setup-Projekt wird dieser Schlüssel automatisch gesetzt.
Wird das Add-In debugged, muss der Schlüssel ev. manuell gesetzt werden

Setup Hinweise
um im Installationsdialog zwei Pfade abzufragen muss der Standarddilaog angepasst werden
dazu war es in meinem Fall (Verwendung von Visual Studio 2017) notwendig, 
den bestehenden Dialog 
"VsdFolderDlg.wid"
im Verzechnis 
C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\VSI\bin\VsdDialogs\1031
durch den im Verzeichnis
SetupDialog Anpassung
zu ersetzen.
ACHTUNG: bitte unbedingt vorher die bestehende Datei sichern

Für die Erstellung der Hilfe wurde das Programm HelpNDoc verwendet
Ein Download dazu findet sich unter https://www.helpndoc.com

