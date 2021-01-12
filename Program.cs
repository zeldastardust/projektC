using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace JokeOfToday
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetJokeItems();
        }
        private async Task GetJokeItems()
        {
            string response = await client.GetStringAsync
                ("https://official-joke-api.appspot.com/random_ten");

            

            List<Joke> joke = JsonConvert.DeserializeObject<List<Joke>>(response);
            foreach(var item in joke)
            {
                Console.WriteLine(item.setup);
                Console.WriteLine(item.punchline);
            }

          }
        }
    class Joke
    {
        public int id { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }


    }
   
    }
   