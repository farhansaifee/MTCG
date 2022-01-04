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

## Mandatory Extra Feature
Hierzu habe ich mir etwas ganz simples überlegt. 
Der User kann sein eigenes Profil einrichten. Sachen wie zum Beispiel Bio, Emoji (as a Picture) oder Lebenslauf können User wenn sie möchten einspeichern.

# Zeitaufzeichnung(-Link)
[Hier](https://docs.google.com/spreadsheets/d/14ewVa_gy0dWolOdndV7Aw9wKR3Yk8G37M3EwMY67MkA/edit?usp=sharing) habe ich eine Google Tabellen Datei erstellt, in der ich die für das Projekt investierte Stunden dokumentiere.

# Github(-Link)
[Hier](https://github.com/farhansaifee/MTCG) ist der Link zum Github Repository.

# Einige CURL Befehle
```bash
curl -X PUT http://localhost:10001/users/kienboec --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Name\": \"Kienboeck\",  \"Bio\": \"me playin...\", \"Image\": \":-)\,  \"Age\": \"-\", \"Nickname\": \"-\", \"Currentcareer\": \"Teacher\"}"
echo.
curl -X PUT http://localhost:10001/users/altenhof --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "{\"Name\": \"Altenhofer\", \"Bio\": \"me codin...\",  \"Image\": \":-D\,  \"Age\": \"-\", \"Nickname\": \"-\", \"Currentcareer\": \"Teacher\"}"
echo.
curl -X PUT http://localhost:10001/users/testuser1 --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "{\"Name\": \"TestUser1\",  \"Bio\": \"Hi, This is my Bio...\", \"Image\": \":-C\,  \"Age\": \"21\", \"Nickname\": \"Little Player\", \"Currentcareer\": \"Student\"}"
echo.
curl -X PUT http://localhost:10001/users/testuser2 --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "{\"Name\": \"TestUser2\", \"Bio\": \"... and this is my Bio...\",  \"Image\": \":-)\",  \"Age\": \"22\", \"Nickname\": \"Big Ben\", \"Currentcareer\": \"Student\"}"
```
