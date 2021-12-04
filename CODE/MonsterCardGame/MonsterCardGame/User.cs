using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MonsterCardGame
{
    class User
    {

        public string id { get; set; }
        public string username { get; set; }
        private string password { get; set; }
        private int coins { get; set; }

        public void register()
        {
            Console.WriteLine("User is registered!");
        }
        public void login()
        {
            Console.WriteLine("User is logged in!");
        }


        //Serializing - Deserializing
        public static async Task Main()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://localhost:8080")
            };

            //HttpClient client2 = new HttpClient();
            //client2.BaseAddress.AbsolutePath.Contains("https://localhost:8080");

            // Get the user information.
            User user = await client.GetFromJsonAsync<User>("users/1");
            Console.WriteLine($"Id: {user.id}");
            Console.WriteLine($"Username: {user.username}");
            Console.WriteLine($"Password: {user.password}");
            Console.WriteLine($"Coins: {user.coins}");

            // Post a new user.
            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

    }
}