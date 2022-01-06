@echo off

REM --------------------------------------------------
REM Monster Trading Cards Game
REM --------------------------------------------------
title Monster Trading Cards Game
echo CURL Testing for Monster Trading Cards Game
echo.

REM --------------------------------------------------
echo 1) Create Users (Registration)
REM Create User
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"testuser1\", \"Password\":\"password\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"testuser2\", \"Password\":\"password\"}"
echo.

echo should fail:
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:10001/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"different\"}"
echo. 
echo.

REM --------------------------------------------------
echo 2) Login Users
curl -X POST http://localhost:10001/sessions --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:10001/sessions --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:10001/sessions --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.
curl -X POST http://localhost:10001/sessions --header "Content-Type: application/json" -d "{\"Username\":\"testuser1\",    \"Password\":\"password\"}"
echo.
curl -X POST http://localhost:10001/sessions --header "Content-Type: application/json" -d "{\"Username\":\"testuser2\",    \"Password\":\"password\"}"
echo.

echo should fail:
curl -X POST http://localhost:10001/sessions --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"different\"}"
echo.
echo.

REM --------------------------------------------------
echo 3.1) create card (done by "admin")
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 1, \"name\": \"Goblin\", \"damage\": 67, \"element\": \"water\", \"type\": \"spell\"}"
echo.																																																																																 				    
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 2, \"name\": \"Dragon\", \"damage\": 72, \"element\": \"fire\", \"type\": \"monster\"}"
echo.																																																																																 				    
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 3, \"name\": \"Spell\", \"damage\": 41, \"element\": \"water\", \"type\": \"spell\"}"
echo.																																																																															 				    
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 4, \"name\": \"Ork\", \"damage\": 79, \"element\": \"water\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 5, \"name\": \"Wizzard\", \"damage\": 39, \"element\": \"normal\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 6, \"name\": \"Knight\", \"damage\": 41, \"element\": \"normal\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 7, \"name\": \"Kraken\", \"damage\": 73, \"element\": \"water\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 8, \"name\": \"Elves\", \"damage\": 59, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 9, \"name\": \"Troll\", \"damage\": 68, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 10, \"name\": \"Goblin\", \"damage\": 63, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 11, \"name\": \"Dragon\", \"damage\": 76, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 12, \"name\": \"Spell\", \"damage\": 74, \"element\": \"fire\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 13, \"name\": \"Ork\", \"damage\": 76, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 14, \"name\": \"Wizzard\", \"damage\": 47, \"element\": \"normal\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 15, \"name\": \"Knight\", \"damage\": 45, \"element\": \"normal\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 16, \"name\": \"Kraken\", \"damage\": 42, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 17, \"name\": \"Elves\", \"damage\": 44, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 18, \"name\": \"Troll\", \"damage\": 43, \"element\": \"fire\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 19, \"name\": \"Troll\", \"damage\": 48, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 20, \"name\": \"Elves\", \"damage\": 41, \"element\": \"water\", \"type\": \"spell\"}"



echo should fail:
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{"id":1,"name":"WaterGoblin","damage":37,"element":"water","type": "spell"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 1, \"name\": \"WaterGoblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 0, \"name\": \"WaterGoblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:10001/card --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"id\": 1, \"name\": \"WaterGoblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"

REM --------------------------------------------------
echo 3) create (random) packages (done by "admin")
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																	
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
echo.

REM --------------------------------------------------
echo 4) acquire packages kienboec
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d ""
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d ""
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d ""
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d ""
echo.
echo should fail (no money):
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d ""
echo.
echo.

REM --------------------------------------------------
echo 4.1) acquire cards testuser1 & testuser2 FOR TESTING
curl -X POST http://localhost:10001/testinsert
echo.

REM --------------------------------------------------
echo 5) acquire packages altenhof
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d ""
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d ""
echo.
echo should fail (no package):
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d ""
echo.
echo.

REM --------------------------------------------------
echo 6) add new packages
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
curl -X POST http://localhost:10001/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
echo.

REM --------------------------------------------------
echo 7) acquire newly created packages altenhof
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d ""
echo.
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d ""
echo.
echo should fail (no money):
curl -X POST http://localhost:10001/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d ""
echo.
echo.

REM --------------------------------------------------
echo 8) show all acquired cards kienboec
curl -X GET http://localhost:10001/cards --header "Authorization: Basic kienboec-mtcgToken"
echo should fail (no token)
curl -X GET http://localhost:10001/cards 
echo.
echo.

REM --------------------------------------------------
echo 9) show all acquired cards altenhof
curl -X GET http://localhost:10001/cards --header "Authorization: Basic altenhof-mtcgToken"
echo should fail (no token)
curl -X GET http://localhost:10001/cards 
echo.
echo.

REM --------------------------------------------------
echo 9.1) show all acquired cards testuser1
curl -X GET http://localhost:10001/cards --header "Authorization: Basic testuser1-mtcgToken"
echo should fail (no token)
curl -X GET http://localhost:10001/cards 
echo.
echo.

REM --------------------------------------------------
echo 9.2) show all acquired cards testuser2
curl -X GET http://localhost:10001/cards --header "Authorization: Basic testuser2-mtcgToken"
echo should fail (no token)
curl -X GET http://localhost:10001/cards 
echo.
echo.

REM --------------------------------------------------
echo 10) show unconfigured deck
curl -X GET http://localhost:10001/deck --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 11) configure deck
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "[\"1\", \"3\", \"6\", \"9\"]"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"12\", \"14\", \"16\", \"18\"]"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "[\"1\", \"4\", \"6\", \"10\"]"
echo.
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "[\"12\", \"13\", \"18\", \"19\"]"
echo.
echo should fail and show original from before:
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "[\"1\", \"2\", \"3\", \"4\"]"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.
echo should fail ... only 3 cards set
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"1\", \"2\", \"3\"]"
echo should fail, bc card not in his posession.
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "[\"1\", \"2\", \"3\", \"4\"]"
echo.
echo should fail, bc he want to use 2 of the same cards.
curl -X PUT http://localhost:10001/deck --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "[\"1\", \"2\", \"2\", \"4\"]"
echo.


REM --------------------------------------------------
echo 12) show configured deck 
curl -X GET http://localhost:10001/deck --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic testuser1-mtcgToken"
echo.
curl -X GET http://localhost:10001/deck --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 13) show configured deck different representation
echo kienboec
curl -X GET http://localhost:10001/deck?format=plain --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.
echo altenhof
curl -X GET http://localhost:10001/deck?format=plain --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.
echo testuser1
curl -X GET http://localhost:10001/deck?format=plain --header "Authorization: Basic testuser1-mtcgToken"
echo.
echo.
echo testuser2
curl -X GET http://localhost:10001/deck?format=plain --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 14) edit user data
echo.
curl -X GET http://localhost:10001/users/kienboec --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/altenhof --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/testuser1 --header "Authorization: Basic testuser1-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/testuser2 --header "Authorization: Basic testuser2-mtcgToken"
echo.
curl -X PUT http://localhost:10001/users/kienboec --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Name\": \"Kienboeck\",  \"Bio\": \"me playin...\", \"Image\": \":-)\,  \"Age\": \"-\", \"Nickname\": \"-\", \"Currentcareer\": \"Teacher\"}"
echo.
curl -X PUT http://localhost:10001/users/altenhof --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "{\"Name\": \"Altenhofer\", \"Bio\": \"me codin...\",  \"Image\": \":-D\,  \"Age\": \"-\", \"Nickname\": \"-\", \"Currentcareer\": \"Teacher\"}"
echo.
curl -X PUT http://localhost:10001/users/testuser1 --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "{\"Name\": \"TestUser1\",  \"Bio\": \"Hi, This is my Bio...\", \"Image\": \":-C\,  \"Age\": \"21\", \"Nickname\": \"Little Player\", \"Currentcareer\": \"Student\"}"
echo.
curl -X PUT http://localhost:10001/users/testuser2 --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "{\"Name\": \"TestUser2\", \"Bio\": \"... and this is my Bio...\",  \"Image\": \":-)\",  \"Age\": \"22\", \"Nickname\": \"Big Ben\", \"Currentcareer\": \"Student\"}"
echo.
curl -X GET http://localhost:10001/users/kienboec --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/altenhof --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/testuser1 --header "Authorization: Basic testuser1-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/testuser2 --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.
echo should fail:
curl -X GET http://localhost:10001/users/altenhof --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/users/kienboec --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X PUT http://localhost:10001/users/kienboec --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "{\"Name\": \"Hoax\",  \"Bio\": \"me playin...\", \"Image\": \":-)\"}"
echo.
curl -X PUT http://localhost:10001/users/altenhof --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Name\": \"Hoax\", \"Bio\": \"me codin...\",  \"Image\": \":-D\"}"
echo.
curl -X GET http://localhost:10001/users/someGuy  --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 15) stats
curl -X GET http://localhost:10001/stats --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/stats --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X GET http://localhost:10001/stats --header "Authorization: Basic testuser1-mtcgToken"
echo.
curl -X GET http://localhost:10001/stats --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 16) scoreboard
curl -X GET http://localhost:10001/score --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 17) battle
echo.
curl -X POST http://localhost:10001/battle --header "Authorization: Basic testuser1-mtcgToken"
echo.
curl -X POST http://localhost:10001/battle --header "Authorization: Basic testuser2-mtcgToken"
echo.
start /b "kienboec battle" curl -X POST http://localhost:10001/battles --header "Authorization: Basic kienboec-mtcgToken"
start /b "altenhof battle" curl -X POST http://localhost:10001/battles --header "Authorization: Basic altenhof-mtcgToken"
ping localhost -n 10 >NUL 2>NUL

REM --------------------------------------------------
echo 17.1) BattleHistory
echo.
curl -X GET http://localhost:10001/battle/1 --header "Authorization: Basic kienboec-mtcgToken" 
echo.   
curl -X GET http://localhost:10001/battle/1 --header "Authorization: Basic altenhof-mtcgToken" 
echo should fail: matchid dont exists
echo.   
curl -X GET http://localhost:10001/battle/2 --header "Authorization: Basic testuser1-mtcgToken"
echo.   
curl -X GET http://localhost:10001/battle/2 --header "Authorization: Basic testuser2-mtcgToken"

REM --------------------------------------------------
echo 18) Stats 
echo kienboec
curl -X GET http://localhost:10001/stats --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo altenhof
curl -X GET http://localhost:10001/stats --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo testuser1
curl -X GET http://localhost:10001/stats --header "Authorization: Basic testuser1-mtcgToken"
echo.
echo testuser2
curl -X GET http://localhost:10001/stats --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 19) scoreboard
curl -X GET http://localhost:10001/score --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 19.1) ELO
curl -X GET http://localhost:10001/elo/kienboec --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/elo/testuser1 --header "Authorization: Basic testuser1-mtcgToken"
echo.
curl -X GET http://localhost:10001/elo/altenhof --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X GET http://localhost:10001/elo/testuser2 --header "Authorization: Basic testuser2-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 20) trade
echo check trading deals - testuser1
curl -X GET http://localhost:10001/tradings --header "Authorization: Basic testuser1-mtcgToken"
echo.
echo create trading deal
curl -X POST http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "{\"Tradingid\": \"1\", \"Karte\": \"1\", \"MinDamage\": \"30\", \"Type\": \"spell\"}"
echo.
echo check trading deals
curl -X GET http://localhost:10001/tradings --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/tradings --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo delete trading deals
curl -X DELETE http://localhost:10001/tradings/1 --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 21) check trading deals
curl -X GET http://localhost:10001/tradings  --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X POST http://localhost:10001/tradings --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "{\"Tradingid\": \"1\", \"Karte\": \"1\", \"MinDamage\": \"30\", \"Type\": \"spell\"}"
echo.
echo check trading deals
curl -X GET http://localhost:10001/tradings  --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/tradings  --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo try to trade with yourself (should fail)
curl -X POST http://localhost:10001/tradings/1 --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "3"
echo.
echo try to trade 
echo.
echo SHOULD FAIL BECAUSE 11 is a MONSTER
curl -X POST http://localhost:10001/tradings/1 --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "11"
echo.
curl -X POST http://localhost:10001/tradings/1 --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "13"
echo.
curl -X GET http://localhost:10001/tradings --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:10001/tradings --header "Authorization: Basic altenhof-mtcgToken"
echo.

REM --------------------------------------------------
echo end...

REM this is approx a sleep 
ping localhost -n 100 >NUL 2>NUL
@echo on
