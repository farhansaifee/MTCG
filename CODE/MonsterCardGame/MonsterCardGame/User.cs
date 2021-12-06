using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class User : Interfaces.IUser
    {
        public User()
        {
            Cards = new ArrayList();

        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Coins { get; set; }
        public ArrayList Cards { get; set; }

        public void register()
        {
            Console.WriteLine("User is registered!");
        }
        public void login()
        {
            Console.WriteLine("User is logged in!");
        }


        //Serializing - Deserializing
        public static async Task Mainn()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://localhost:8080")
            };

            //HttpClient client2 = new HttpClient();
            //client2.BaseAddress.AbsolutePath.Contains("https://localhost:8080");

            // Get the user information.
            User user = await client.GetFromJsonAsync<User>("users/1");
            Console.WriteLine($"Id: {user.Id}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Password: {user.Password}");
            Console.WriteLine($"Coins: {user.Coins}");
            Console.WriteLine($"Cards: {user.Cards}");

            // Post a new user.
            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

    }
}