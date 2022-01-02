# MTCG - Protokoll
In diesem Repository werde ich mein Semesterprojekt Schritt für Schritt dokumentieren und hochladen.

# Failures

## 1 UML
Aus der Aufgabenstellung das UML zu bilden war keine großartige Herausfoderung, allerdings hatte ich Schwierigkeiten die Punkte Stack, Trading oder Package zuzuordnen. Ich wusste nicht ob ich aus denen ein Interface, Attribute oder Klassen machen soll.

## 2 Server
Am Anfang des Projekts wurde statt TCPListener HTTPServer genommen, was nicht erlaubt war. Also musste die Server Klasse komplett gelöscht und neu erstellt werden.

## 3 Struktur
Außerdem hat die (Projekt-)Struktur nicht gepasst, welche dann auch geändert wurde. Hier hat es lange gedauert bis ich weitermachen konnte, da einiges für mich unklar war. Mit der Zeit habe ich das lösen können.

# Design

## UML / Class Diagramm
Als erstes haben wir ein UML Diagramm für unser Game erstellt.

![UML](E:\Semester3\LVs\SWE1\MTCG\UML\UML_NEW.jpeg)

![ClassDiagramm](E:\Semester3\LVs\SWE1\MTCG\UML\ClassDiagramm.PNG)

## Projekt / Github Repository / Zeitaufzeichnung
Das Projekt habe ich genaus wie das Github Repositroy und die Zeitaufzeichnung im Laufe des Semester in Ruhe angefertigt.
Im Repo wird der Code gepusht damit alle Änderungen sicher gespeichert sind. Der Link zum Github Repo befindet sich unten im Dokument.

## Grundstruktur
Zuerst habe ich nach langen Überlergungen die einzelnen Klassen erstellt und dazu Interfaces. 

## DB Connection
Beim Start vom Server wird mit dieser Klasse die Datenbankverbindung hergestellt. Im Editor (VS2019) muss man NPGSQL installieren genauso wie postgreSQL auf Windows.
Wie [hier](https://moodle.technikum-wien.at/pluginfile.php/1127708/mod_resource/content/0/Install%20PostgreSQL%20from%20zip.pdf) beschrieben muss das ales auch noch "eingestellt" werden, damit alles funktionieren kann.

## Server
Hier ist die Funktionalität des Servers. Mittel der Klassen Response, Request, DbConn, Packages & BattleLogic läuft hier die "Main-Anwendung". 

## CURL-Script
Das CURL-Script habe ich etwas verändern müssen und an der Funktionalität meines Codes angepasst.

# Zeitaufzeichnung(-Link)
[Hier](https://docs.google.com/spreadsheets/d/14ewVa_gy0dWolOdndV7Aw9wKR3Yk8G37M3EwMY67MkA/edit?usp=sharing) habe ich eine Google Tabellen Datei erstellt, in der ich die für das Projekt investierte Stunden dokumentiere.

# Github(-Link)
[Hier](https://github.com/farhansaifee/MTCG) ist der Link zum Github Repository.