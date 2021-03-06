using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MonsterCardGame
{
    public class DbConn
    {

        public string data = "Host=localhost;Username=postgres;Password=postgres;Database=mctg123";
        public Packages pack = new Packages();

        // Adds to Register
        public void Register(string user, string pass)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO users VALUES (@username, @password, @coins)", con);

            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("password", pass);
            cmd.Parameters.AddWithValue("coins", 20);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Adds Data for Login
        public void Login(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO loggedin VALUES (@username, @token)", con);

            string Token = "Basic " + user + "-mtcgToken";
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("token", Token);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Adds to Cards
        public void Card(int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO card VALUES (@id, @name, @damage, @element, @type)", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("damage", damage);
            cmd.Parameters.AddWithValue("element", element);
            cmd.Parameters.AddWithValue("type", type);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Get Usercards
        public string GetUserCards(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id,name,damage,element,type FROM usercards WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                output = output + rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + " " + rdr.GetString(4) + "\n";
            }
            con.Close();
            return output;
        }

        // Add Usercards
        public void AddUserCard(string username, int id, string name, int damage, string element, string type)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO usercards VALUES (@username ,@id, @name, @damage, @element, @type)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("damage", damage);
            cmd.Parameters.AddWithValue("element", element);
            cmd.Parameters.AddWithValue("type", type);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Add Userdata (MANDATORY EXTRA FEATURE)
        public void CreateUserdata(string username)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO userdata VALUES (@username, @name, @bio, @image, @age, @nickname, @currentcareer)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("name", "undefined");
            cmd.Parameters.AddWithValue("bio", "undefined");
            cmd.Parameters.AddWithValue("image", "undefined");
            cmd.Parameters.AddWithValue("age", "undefined");
            cmd.Parameters.AddWithValue("nickname", "undefined");
            cmd.Parameters.AddWithValue("currentcareer", "undefined");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Add Userstats
        public void CreateUserstats(string username)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO userstats VALUES (@username, @wins, @draws, @loses)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("wins", 0);
            cmd.Parameters.AddWithValue("draws", 0);
            cmd.Parameters.AddWithValue("loses", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Adds Data to Battlehistory
        public void BattleHistory(int id, string name, string protokol)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO battlehistory VALUES (@id, @name, @protokol)", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("protokol", protokol);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Add Values to Trading
        public void Trading(int id, string card, int mdamage, string type, string username)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO tradings VALUES (@id, @card, @damage, @type, @username)", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("card", card);
            cmd.Parameters.AddWithValue("damage", mdamage);
            cmd.Parameters.AddWithValue("type", type);
            cmd.Parameters.AddWithValue("username", username);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Add Deck
        public void CreateDeck(string username)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO deck VALUES (@username, @c1, @c2, @c3, @c4)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("c1", "undefined");
            cmd.Parameters.AddWithValue("c2", "undefined");
            cmd.Parameters.AddWithValue("c3", "undefined");
            cmd.Parameters.AddWithValue("c4", "undefined");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Insert Into ELO
        public void Elo(string username)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO elo VALUES (@username, @elo)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("elo", 100);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Insert Into Packages
        public void Packages(int id, int card1, int card2, int card3, int card4, int card5)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("INSERT INTO packages VALUES (@id, @c1, @c2, @c3, @c4, @c5 )", con);

            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("c1", card1);
            cmd.Parameters.AddWithValue("c2", card2);
            cmd.Parameters.AddWithValue("c3", card3);
            cmd.Parameters.AddWithValue("c4", card4);
            cmd.Parameters.AddWithValue("c5", card5);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Delete usercards
        public void TradingDeleteUserCard(string username, int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("DELETE FROM usercards WHERE ctid IN(Select ctid from usercards where username=@username AND id=@id LIMIT 1)", con);

            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // DeleteTrading
        public void DeleteTrading(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("DELETE FROM tradings WHERE tradingid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Update coins of users
        public void CoinsUpdate(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE users SET coins = coins - 5 WHERE username=@username", con);

            cmd.Parameters.AddWithValue("username", user);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // GetuserDeck
        public string GetUserDeck(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT card1,card2,card3,card4 FROM deck WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                // = output ist hier unnötig.
                output = output + rdr.GetString(0) + "\n" + rdr.GetString(1) + "\n" + rdr.GetString(2) + "\n" + rdr.GetString(3) + "\n";
            }
            con.Close();

            return output;
        }

        //Get Cards from Deck
        public string DeckCardIds(string user)
        {
            string output = GetUserDeck(user);
            using var reader = new StringReader(output);
            string s1 = reader.ReadLine();
            string s2 = reader.ReadLine();
            string s3 = reader.ReadLine();
            string s4 = reader.ReadLine();
            int id1 = Int32.Parse(s1.Split(',')[0]);
            int id2 = Int32.Parse(s2.Split(',')[0]);
            int id3 = Int32.Parse(s3.Split(',')[0]);
            int id4 = Int32.Parse(s4.Split(',')[0]);

            return id1 + " " + id2 + " " + id3 + " " + id4;

        }

        //Update deck SET card1 = 'undefined', card2 = 'undefined',.... WHERE username='blablabla'; 
        public void UpdateDeck(string user, string card1, string card2, string card3, string card4)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE deck SET card1=@card1, card2=@card2, card3=@card3, card4=@card4 WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("card1", card1);
            cmd.Parameters.AddWithValue("card2", card2);
            cmd.Parameters.AddWithValue("card3", card3);
            cmd.Parameters.AddWithValue("card4", card4);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // GetUserdata (MANDATORY EXTRA FEATURE)
        public string GetUserData(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT name,bio,image,age,nickname,currentcareer FROM userdata WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {

                output = rdr.GetString(0) + "\n" + rdr.GetString(1) + "\n" + rdr.GetString(2) + rdr.GetString(3) + "\n" + rdr.GetString(4) + "\n" + rdr.GetString(5);
            }
            con.Close();

            return output;
        }
        
        // GetBattleHistory
        public string GetBattleHis(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT matchid,winner,protokol FROM battlehistory WHERE matchid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {

                output = rdr.GetInt32(0).ToString() + "\n" + rdr.GetString(1) + "\n" + rdr.GetString(2);
            }
            con.Close();

            return output;
        }

        // GetUserStats
        public string GetUserStats(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT wins,draws,loses FROM userstats WHERE username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";
            try
            {
                while (rdr.Read())
                {
                    output = rdr.GetInt32(0).ToString() + "\n" + rdr.GetInt32(1).ToString() + "\n" + rdr.GetInt32(2).ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("User dont exists.");
            }
            con.Close();

            return output;
        }

        // GetUserScore
        public string GetUserScore()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM userstats GROUP BY wins, draws, loses, username ORDER BY wins DESC", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                output = output + rdr.GetString(0) + " " + rdr.GetInt32(1).ToString() + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetInt32(3).ToString() + "\n";
            }
            con.Close();

            return output;
        }

        // GetTradings
        public string GetTrading()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM tradings", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                output = output + rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + "\n";
            }
            con.Close();

            return output;
        }

        //Update <table> SET card1 = 'undefined', card2 = 'undefined',.... WHERE username='blablabla'; 
        public void UpdateUserData(string user, string name, string bio, string image, string age, string nickname, string currentcareer)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE userdata SET name=@name, bio=@bio, image=@image, age=@age, nickname=@nickname, currentcareer=@currentcareer WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("bio", bio);
            cmd.Parameters.AddWithValue("image", image);
            cmd.Parameters.AddWithValue("age", age);
            cmd.Parameters.AddWithValue("nickname", nickname);
            cmd.Parameters.AddWithValue("currentcareer", currentcareer);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Update Wins
        public void UpdateUserStatsWins(string user, int wins)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE userstats SET wins=@wins WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("wins", wins);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Update Draws
        public void UpdateUserStatsDraws(string user, int draws)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE userstats SET draws=@draws WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("draws", draws);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Update Losses
        public void UpdateUserStatsLosses(string user, int loses)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE userstats SET loses=@loses WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("loses", loses);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // UpdateUserElo
        public void UpdateUserElo(string user, int elo)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("UPDATE elo SET elo=@elo WHERE username=@username", con);
            cmd.Parameters.AddWithValue("username", user);
            cmd.Parameters.AddWithValue("elo", elo);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Check if user exists
        public Boolean CheckUserExists(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM users", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            ArrayList usersArr = new ArrayList();
            //string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                usersArr.Add(rdr.GetString(0));
            }
            con.Close();

            if (usersArr.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Weitere Checks ab hier:
        public Boolean CheckUserHasCard(string user, int iddb, int idcontains)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id FROM usercards where username=@user AND id=@id", con);
            cmd.Parameters.AddWithValue("user", user);
            cmd.Parameters.AddWithValue("id", iddb);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Boolean cont = false;
            string idCard = "";
            while (rdr.Read())
            {
                idCard = rdr.GetInt32(0).ToString();
            }

            try
            {
                if (String.Compare(idCard, idcontains.ToString()) == 0)
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Card id existiert nicht.");
            }

            return cont;

        }
        public Boolean CheckMatchidExists(int iddb, int idcontains)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT matchid FROM battlehistory where matchid=@id", con);
            cmd.Parameters.AddWithValue("id", iddb);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            Boolean cont = false;
            string idCard = "";
            while (rdr.Read())
            {
                idCard = rdr.GetInt32(0).ToString();
            }

            try
            {
                if (String.Compare(idCard, idcontains.ToString()) == 0)
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Matchid existiert nicht.");
            }

            return cont;

        }
        public int CardMaxId()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT max(id) FROM card", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    //Console.WriteLine("Has rows");
                    output = 0;
                }
                else
                {
                    output = rdr.GetInt32(0);
                }

                try
                {
                    output = rdr.GetInt32(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("NO CARD YET.");
                }
            }

            //Console.WriteLine("Last Card id is: {0}", output);

            return output;
        }
        public int MatchId()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT max(matchid) FROM battlehistory", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    //Console.WriteLine("Has rows");
                    output = 0;
                }
                else
                {
                    output = rdr.GetInt32(0);
                }

                try
                {
                    output = rdr.GetInt32(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("NO MATCH ID YET.");
                }
            }

            //Console.WriteLine("Last Card id is: {0}", output);

            return output;
        }
        public int Packidis()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT max(packid) FROM packages", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                if (rdr.HasRows)
                {
                    //Console.WriteLine("Has rows");
                    output = 0;
                }
                else
                {
                    output = rdr.GetInt32(0);
                }

                try
                {
                    output = rdr.GetInt32(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine("NO PACKAGES YET.");
                }

            }
            con.Close();

            //Console.WriteLine("packid is: {0}", output);

            return output;
        }
        public void CheckAllCard()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM card", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();


            int maxid = CardMaxId();

            while (rdr.Read())
            {
                try
                {
                    if (pack.AllCards.Any(p => p.id == maxid))
                    {
                        Console.WriteLine("Alle Karten vorhanden.");
                    }
                    else
                    {
                        //Console.WriteLine("ADDING CARD);
                        pack.AllCards.Add(new Card(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4)));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("");
                }

            }
            con.Close();

        }
        public Boolean CheckBattleHistory()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT matchid FROM battlehistory", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            ArrayList loginArr = new ArrayList();
            //string output = "";
            int i = 0;
            while (rdr.Read())
            {
                i = rdr.GetInt32(0);
                loginArr.Add(i);
            }
            con.Close();

            if (loginArr.Contains(i))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean CheckLogin(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM loggedin", con);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            ArrayList loginArr = new ArrayList();
            //string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                loginArr.Add(rdr.GetString(0));
            }
            con.Close();

            if (loginArr.Contains(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string CheckToken(string token)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT token FROM loggedin where token=@token", con);
            cmd.Parameters.AddWithValue("token", token);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetString(0);
            }
            con.Close();

            // CHECK IF TOKEN IS CORRECT
            //Console.WriteLine("Token is: {0}", output);

            return output;
        }
        public string TokenToUser(string token)
        {
            // Example:
            // Basic testuser-mtcgToken
            try
            {
                string userToken = CheckToken(token);
                // testuser-mtcgToken
                string username = userToken.Split(' ')[1];
                username = string.Concat(username.Reverse().Skip(10).Reverse());
                return username;
            }
            catch (Exception e)
            {
                return "";
            }
            // testuser



        }
        public int CheckElo(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT elo FROM elo where username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {

                output = rdr.GetInt32(0);
            }
            con.Close();
            return output;
        }
        public int CheckUserCoins(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT coins FROM users where username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
            }
            con.Close();

            // CHECK IF TOKEN IS CORRECT
            //Console.WriteLine("Token is: {0}", output);

            return output;
        }
        public int GetCardFromTradingID(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT card FROM tradings where tradingid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = Int32.Parse(rdr.GetString(0));
            }
            con.Close();
            return output;
        }
        public string CheckCardId(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT id FROM card where id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
            }
            con.Close();

            //Console.WriteLine("CardId is: {0}", output);

            return output.ToString();
        }
        public string CheckTradingId(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT tradingid FROM tradings where tradingid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
            }
            con.Close();
            return output.ToString();
        }
        public string CheckTradingUsernameId(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT username FROM tradings where tradingid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetString(0);
            }
            con.Close();
            return output;
        }
        public string CheckTradingAnforderungenId(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT mindamage,type FROM tradings where tradingid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0).ToString() + " " + rdr.GetString(1);
            }
            con.Close();
            return output;
        }
        public string FullCardInfo(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM card where id=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0).ToString() + " " + rdr.GetString(1) + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetString(3) + " " + rdr.GetString(4);
            }
            con.Close();

            //Console.WriteLine("CardId is: {0}", output);

            return output;
        }
        public string CheckCardsFromPack(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT card1,card2,card3,card4,card5 FROM packages where packid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0).ToString() + " " + rdr.GetInt32(1).ToString() + " " + rdr.GetInt32(2).ToString() + " " + rdr.GetInt32(3).ToString() + " " + rdr.GetInt32(4).ToString() + " ";
            }
            con.Close();

            //Console.WriteLine("CardId is: {0}", output);

            return output;
        }
        public string CheckPackId(int id)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT packid FROM packages where packid=@id", con);
            cmd.Parameters.AddWithValue("id", id);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            int output = 0;

            while (rdr.Read())
            {
                //Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetInt32(0);
            }
            con.Close();

            Console.WriteLine("Packid is: {0}", output);

            return output.ToString();
        }
        public string CheckUserPw(string user)
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT password FROM users where username=@user", con);
            cmd.Parameters.AddWithValue("user", user);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            string output = "";

            while (rdr.Read())
            {
                Console.WriteLine("{0}", rdr.GetString(0));
                output = rdr.GetString(0);
            }
            con.Close();

            Console.WriteLine("Password is: {0}", output);

            return output;

            /*
            foreach (Object obj in usersArr)
            Console.WriteLine("   user:{0}", obj);
            */
        }
        public void CheckRegister()
        {
            using var con = new NpgsqlConnection(data);
            con.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM users", con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2}", rdr.GetString(0), rdr.GetString(1),
                        rdr.GetInt32(2));
            }
            con.Close();
        }


    }
}
