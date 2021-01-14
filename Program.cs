using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;


namespace JokeOfToday
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Program program = new Program();

            while (true)
            {
                Clear(); Console.CursorVisible = false;
                WriteLine("Välkommen till Joke of the day !!");
                WriteLine();
                WriteLine("1. Läs dagens top tio jokes!");
                WriteLine("2. ?");
                WriteLine("X. Avsluta\n");


                string inp = ReadLine().ToLower();

                switch(inp)
                {
                    case "1":
                        
                            await program.GetJokeItems();
                            
                        
                        break;

                    case "x":
                        Environment.Exit(0);
                        break;
                }
            }
          
        }
        private async Task GetJokeItems()
        {
            string response = await client.GetStringAsync
                ("https://official-joke-api.appspot.com/random_ten");

            List<Joke> joke = JsonConvert.DeserializeObject<List<Joke>>(response);
            

                foreach (var item in joke)
                {
                    Console.WriteLine(item.setup);
                    ReadKey();
                    Console.WriteLine(item.punchline);
                    ReadKey();
                    WriteLine();
                }
        }
        private async Task GetJokeId()
        {
            string response = await client.GetStringAsync
                ("https://official-joke-api.appspot.com/random_ten");

            List<Joke> joke = JsonConvert.DeserializeObject<List<Joke>>(response);
            foreach (var item in joke)
            {
                Console.WriteLine(item.id);
                
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
