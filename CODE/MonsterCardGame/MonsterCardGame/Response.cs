using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
	public class Response : IResponse
	{
		// Encoding.GetBytes 
		static Encoding enc = Encoding.UTF8;

		// Konstruktor
		public Response()
		{
			msg = new Dictionary<int, string>();
			msgCounter = 1;

		}

		// Get Response
		public void GetResponse()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");

			foreach (KeyValuePair<int, string> kvp in msg)
			{
				builder.AppendFormat("{0} {1}\n",
					kvp.Key, kvp.Value);
			}
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void GetResponseId()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat(msg[Int32.Parse(lastPart)]);
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());

			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());


		}
		public void ResponsePost()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat("Nachricht ID: {0}", msgCounter);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
			msgCounter++;

		}
		public void ResponsePut()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat("Nachricht ID: {0} is updated.", lastPart);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseDeleteId()
		{
			msg.Remove(Int32.Parse(lastPart));

			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendFormat("Nachricht ID: {0} is deleted.", lastPart);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseDelete()
		{
			msg.Clear();
			msgCounter = 1;

			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendLine("Nachrichten wurden geloescht.");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseFailed()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendLine("Error");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseReg()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Registration Succesfull");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseRegExi()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Username already exists.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseLogin()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Login Succesfull");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());

		}
		public void ResponseLoginFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Login Failed");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseCard()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Card successfully created");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseCardFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Card: Unsuccessful");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Trading: Unsuccessful");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingDeleteFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Delete Trading: Unsuccessful");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingfehler()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Trading failed.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingFailCard()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("The Card you want to trade is not in your possesion.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingIdFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Trading failed - The ID is already in use.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponsePackages()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Packages successfully created");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponsePackagesFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Creating Packages: Unsuccessful");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTransPackages()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("One Package (5 Cards) Succesfull added to your Cards.");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTransPackagesFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Package Transaction: Unsuccessful");
			builder.AppendLine("Do you have more than 5 Coins?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void GetResponseAquiredCards(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void GetResponseAquiredFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - Have you already bought a package?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void GetResponseDeck(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void GetResponseDeckPlain(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: text/plain");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseDeckFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - Have you provided your authorization?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseConfigureDeck()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("5 Cards Succesfull added to your Deck.");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseConfigureDeckFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Configure Deck failed. - Do you have the Cards you mentioned in your Cards?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseConfigureDeckSame()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Configure Deck failed. - Did you enter the same ID 2 times?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseFormatFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Your Json Format is False or Card ID is not in your Possesion.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void GetResponseUserData(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseUserDataFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - Have you provided your authorization?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseUpdateUserData()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Userdata successfully added.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public void ResponseUpdateUserDataFail()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Failed - Have you provided your authorization?");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseBattleFailDeck()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendFormat("HTTP/1.1 404 Not Found\n");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine("Please Update your Deck, one or more Cards are not in your possesion anymore.");
			builder.AppendLine("");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();
			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void GetResponseUserStats(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void GetResponseScore(string json)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendLine(json);

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponsePostCardTrade()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("One Card successfully added to the Trading Store.");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTradingDelete()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("One Card deleted from Trading Store.");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseTrading()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Trading Successfull. One Card added to your Cards.");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseBattle(int matchid)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Your Battle starts soon. - Matchid: {0} - ", matchid);
			builder.AppendLine("Check the Battle under /battle/<matchid>");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}
		public void ResponseBattleF2(int matchid)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("HTTP/1.1 200 OK");
			builder.AppendLine("Content-Type: application/json");
			builder.AppendLine("");
			builder.AppendFormat("Your Battle is Over. - Matchid: {0} - ", matchid);
			builder.AppendLine("Check the Battle under /battle/<matchid>");

			Console.WriteLine("");
			Console.WriteLine("Response:");
			Console.WriteLine(builder.ToString());
			responseMsg = builder.ToString();

			sendBytes = enc.GetBytes(builder.ToString());
		}

		public Dictionary<int, string> msg { get; set; }
		public byte[] sendBytes { get; set; }
		public string lastPart { get; set; }
		public int msgCounter { get; set; }
		public string responseMsg { get; set; }
	}
}
