# MTCG - Protokoll
In diesem Repository werde ich mein Semesterprojekt Schritt für Schritt dokumentieren und hochladen.

Zuerst wird mit den Failures und den Lessons Learned begonnen und danach wird das Design beschrieben.

# Failures

## 1 UML
Aus der Aufgabenstellung das UML zu bilden war keine großartige Herausforderung, allerdings hatte ich Schwierigkeiten die Punkte Stack, Trading oder Package zuzuordnen. Ich wusste nicht ob ich aus denen ein Interface, Attribute oder Klassen machen soll.

## 2 Server
Am Anfang des Projekts gab es ein Missverständnis meinerseits und es wurde statt TCPListener ein HTTPServer implementiert, was nicht erlaubt war. Also musste die Server Klasse komplett gelöscht und neu erstellt werden. Hierin wurde sehr viel Zeit investiert und deshalb kam es zu Verzögerungen des gesamten Projekts im Laufe der letzten Wochen.

## 3 Struktur
Außerdem hat die (Projekt-)Struktur nicht gepasst, welche dann auch geändert wurde. Hier hat es etwas lange gedauert bis ich weitermachen konnte, da einiges für mich unklar war (Zum Beispiel Schwierigkeiten mit der Zuordnung von Packages oder Trading, ob aus denen eigene Klassen oder nur Attribute erstellt werden soll). Mit der Zeit habe ich das lösen können und für mich war es sinnvoller, aus zb. Packages und Trading eigene Klassen zu erstellen.

## 4 BattleLogic
Sehr lange habe ich überlegt wie ich das Duell von 2 Spielern handhaben möchte. Ich habe mich dafür entschieden 2 Listen zu erstellen. Wenn der erste Spieler sich fürs Battle anmeldet
dann bekommt er die Response zurück:
"Dein Spiel startet in kürze - deine Matchid: 1 " - auf battle/1 Ergebnis entgegennehmen.
Dabei wird sein deck in diese 1.Liste hinzugefügt.

Sobald der 2.User sich für die Battleliste anmeldet, wird gekämpft. Er bekommt auch die
Matchid als Rückgabe.
Dabei wird vom 2.User das Deck in die zweite Liste eingefügt.
Es werden auch dabei die Userstats geändert und der ELO Wert. Wer der Gewinner war können sie in der battlehistory (battle/id) ansehen.

# Lessons Learned
Durch dieses Projekt habe ich eine Menge gelernt. In meiner bisherigen Ausbildung habe ich noch nie so viel Zeit in einem Projekt investiert wie in diesem. Ich habe viel Über RESTful Api und das ganze Zusammenspiel bzw. die Verbindung zwischen Client-Server und Datenbank-Connection gelernt (vor allem ein Server ohne ein Framework). In der HTL habe ich das damals nur kurz gehört und ein kleines Beispiel dazu zur Anschaulichung bekommen, und nur einen kleinen, simplen Chat zwischen 2 Clients, die über einen Server kommunizieren, programmiert, aber das war nur in JAVA. 
Über C# selbst habe ich durch das Projekt auch einiges gelernt wie zum Beispiel Frameworks wie NUnit.Framework.
Da ich früher bereits mit MySQL gearbeitet habe war es leicht mich auf PostgreSQL umzustellen. Auch hier habe ich neue Befehle gelernt.
Früher hatte ich Probleme Unit Tests zu schreiben, aber nach der Übung mit dem LightSaber und dem Projekt habe ich ein etwas besseres Verständnis davon bekommen.
Ich habe neben den Themen der LV auch gelernt, wie ich mir die Zeit besser einteile und dadurch dass ich eines nach dem anderen strukturiert abarbeitet habe, hat das auch ganz gut funktioniert und mir die Arbeit und den Stress während den letzten Wochen verringert.
# Design

## 1 UML / Class Diagramm
Als erstes haben wir ein UML Diagramm für unser Projekt erstellt. Mein UML und Klassen-Diagramm sieht folgendermaßen aus:

![UML](E:\Semester3\LVs\SWE1\MTCG\UML\UML_NEW.jpeg)

![ClassDiagramm](E:\Semester3\LVs\SWE1\MTCG\UML\ClassDiagramm.PNG)

## 2 Projekt / Github Repository / Zeitaufzeichnung
Das Projekt habe ich genau wie das Github Repositroy und die Zeitaufzeichnung im Laufe des Semester in Ruhe angefertigt und nach jedem Push habe ich in meiner Zeitaufzeichnung dokumentiert was ich wann gemacht habe.
Im Repo wird der Code gepusht damit alle Änderungen sicher gespeichert sind.
(Der Link zum Github Repo und zur Zeitaufzeichnung befindet sich unten im Dokument.)

## 3 Grundstruktur
Zuerst habe ich nach langen Überlergungen die einzelnen Klassen erstellt und dazu die Interfaces. 

## 4 Funktionen
- Response schickt dem User die richtige Response raus.
- DbConn stellt die Verbindung zur Datenbank her und liefert das gewünschte Ergebnis, das im Server gefragt wird.
- Battle kümmert sich um die Logik, wie die Karten gegeneinander spielen.
- Request zerstückelt den Request der vom User kommt.
- Die Server Klasse ist das Herz des Ganzen. Die Methode StartServer() kümmert sich um alle
Anfragen die reinkommen GET,POST,PUT,...

## 5 DB Connection
Beim Start vom Server wird mit dieser Klasse die Datenbankverbindung hergestellt. Im Editor (VS2019) muss man NPGSQL installieren genauso wie postgreSQL auf Windows.
Wie [hier](https://moodle.technikum-wien.at/pluginfile.php/1127708/mod_resource/content/0/Install%20PostgreSQL%20from%20zip.pdf) beschrieben muss das alles auch noch "eingestellt" werden, damit alles funktionieren kann.

## 6 Server
Hier ist die (Haupt-)Funktionalität des Servers mittels der Klassen Response, Request, DbConn, Packages & BattleLogic.
Der Server wird über einen TCP-Listener, welche die IP-Adresse und den Port (1001) einließt, gestartet. Eingehende Verbindungen der Clients werden durch Threads gestartet. 
In der StartServer-Methode werden über ROUTES mit der jeweiligen URL Funktionen beschrieben und, wie bereits oben erklärt, kümmert sich diese Methode um alle einkommenden Anfragen (GET,POST,PUT,DELETE,...).
Beispiel: Hier wird für das Scoreboard eine Liste erstellt, die die Scores darin speichert. Serialized wird das mit JSON:

```c#
else if (String.Compare(rs.Method, "GET") == 0 && String.Compare(rs.Url, "/score") == 0 && rs.RequestBody.ContainsKey("Authorization"))
            {
                if (String.Compare(rs.RequestBody["Authorization"], dbc.CheckToken(rs.RequestBody["Authorization"])) == 0)
                {
                    List<Score> scorestats = new List<Score>();
                    string score = dbc.GetUserScore();
                    Console.WriteLine(score);

                    //read line by line
                    using (StringReader reader = new StringReader(score))
                    {
                        string line;        //line
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (string.IsNullOrEmpty(line))
                            {
                                break;
                            }
                            if (line.Contains(' '))
                            {
                                string c1 = line.Split(' ')[0];
                                int c2 = Int32.Parse(line.Split(' ')[1]);
                                int c3 = Int32.Parse(line.Split(' ')[2]);
                                int c4 = Int32.Parse(line.Split(' ')[3]);
                                scorestats.Add(new Score(c1, c2, c3, c4));
                            }
                        }
                    }
                    string json = JsonConvert.SerializeObject(scorestats);

                    res.GetResponseDeck(json);
                }
                else
                {
                    // Selbe Fehlermeldung - "Failed - do you provide your authorization?"
                    res.ResponseUpdateUserDataFail();
                }
                stream.Write(res.sendBytes, 0, res.sendBytes.Length);
                rs.RequestBody.Clear();
            }
```

## 7 CURL-Script
Das CURL-Script habe ich etwas verändern müssen und es angepasst.
Hier sind einige Befehle:
```bash
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"testuser1\", \"Password\":\"password\"}"
```
Das komplette CURL-Script befindet sich im Abgabeordner unter Scripts/

## 8 Unit Tests
Ich habe mich dazu entschieden Unit Tests für die BattleLogic und Responses zu erstellen. Warum ich dafür entschieden habe ist ganz simpel:

- BattleLogic: Da es im Semesterprojekt um ein CardGame geht ist es wichtig die Logik dieses Games zu testen.
- Response: Nachdem man die CURL-Befehle in der Command Line eingibt , sollten für bestimmte Funktionen bestimmte Responses zurückgegeben werden. Auch dies war für mich wichtig, denn der User weiß somit ob beispielsweise die Registrierung eines Users geklappt hat oder nicht. 
Beispiel:
```c#
[Test]
        public void GoblinDragonTest()
        {
            //Arrange
            BattleLogic battle = new BattleLogic();

            //Act
            string winner = battle.SetWinner("Farhan", "Farasat", "Goblin", "spell", "water", 67, "Dragon", "monster", "fire", 72);

            //Assert
            Assert.AreEqual("Farasat", winner);

        }
```

## 9 Mandatory Extra Feature
Hierzu habe ich mir etwas ganz simples überlegt. 
Der User kann sein eigenes Profil einrichten. Sachen wie zum Beispiel Bio, Emoji (as a Picture) oder Lebenslauf können User wenn sie möchten einspeichern.
Ich habe eine Klasse UserData erstellt in der Name, Bio, Image, Age, Nickname und Currentcareer für den User gespeichert wird.
Mittels CURL Befehlen kann der eingeloggte User dann seine Daten einspeichern. hier ein Beispiel:
```c#
curl -X PUT http://localhost:10001/users/testuser2 --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "{\"Name\": \"TestUser2\", \"Bio\": \"... and this is my Bio...\",  \"Image\": \":-)\",  \"Age\": \"22\", \"Nickname\": \"Big Ben\", \"Currentcareer\": \"Student\"}"
```
Und ob das gespeichert wurde, sieht man in der Datenbank mittels einer Abfrage:
```postresql
select * from userdata;

username  |   name    |            bio            |   image   |    age    | nickname  | currentcareer
-----------+-----------+---------------------------+-----------+-----------+-----------+---------------
 admin     | undefined | undefined                 | undefined | undefined | undefined | undefined
 kienboec  | x         | x                         | x         | x         | x         | x
 altenhof  | x         | x                         | x         | x         | x         | x
 testuser1 | x         | x                         | x         | x         | x         | x
 testuser2 | TestUser2 | ... and this is my Bio... | :-)       | 22        | Big Ben   | Student
```

# Zeitaufzeichnung(-Link)
Zeitaufwand: ca. 101h.

[Hier](https://docs.google.com/spreadsheets/d/14ewVa_gy0dWolOdndV7Aw9wKR3Yk8G37M3EwMY67MkA/edit?usp=sharing) habe ich eine Google Tabellen Datei erstellt, in der ich die für das Projekt investierte Stunden dokumentiert habe.

# Github(-Link)
[Hier](https://github.com/farhansaifee/MTCG) ist der Link zum Github Repository.

# Abgabe
In der Abgabe befindet sich ein README.pdf File in der alles dokumentiert ist, ein ImportantCommands.md File in der einige wichtigen Befehle für PostgreSQL stehen und 3 weitere Ordner CODE, UML & Scripts.
 ## 1 Scripts
Hier ist das CURL-Script gespeichert und das Script, um die Tabellen in der DB zu erstellen.
 ## 2 UML
 Hier sind einige Versionen der UML-Diagramme die ich erstellt habe drinnen.
 ## 3 CODE
 Hier ist das Projekt abgespeichert.