using System.Text;
using Newtonsoft.Json;

namespace ChatGptApp
{
    class Program
    {
         static async Task Main(string[] args)
        {

            Notebook notebook = new();
            GetApiKeyCmd getApiKeyCmd = new();
            Credentials credentials = new(getApiKeyCmd.Execute());
            Gpt3Service gpt3Service = new(credentials);

            WriteMessageCmd writeMessageCmd= new();
            Payload payload = new(writeMessageCmd.Execute());

            string payloadJson = payload.ToString();
            Console.WriteLine(payloadJson);

            







            
            

            // HttpClient client = new();

            // client.DefaultRequestHeaders.Add("Authorization", $"Bearer {credentials.ApiKey}");

            // Console.Write("What do you want to ask?: \n> ");

            // string input = Console.ReadLine();

            // var payload = new
            // {
            //     model = "gpt-3.5-turbo",
            //     messages = new[]
            //     {
            //         new { role = "system", content = "You are a helpful assistant." },
            //         new { role = "user", content = $"{input}" }
            //     }
            // };

            // string payloadJson = JsonConvert.SerializeObject(payload);
            var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await gpt3Service._client.PostAsync("https://api.openai.com/v1/chat/completions", content);

            string responseString = await response.Content.ReadAsStringAsync();


            try
            {
                var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);

                string apiResponse = $"{dyData!.choices[0].message.content}";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"GPT-3.5-Turbo:\n{apiResponse}\n");
                Console.ResetColor();

            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message}");
                Console.ResetColor();

            }
        

            // DisplayOptCmd displayOptionsCommand = new();
            // QuitCmd quitCommand = new();


            // Dictionary<string, ICommand> commands = new()
            // {
            //     { "q", quitCommand },
            //     { "3", quitCommand },
            //     { "quit", quitCommand },
            //     { "Quit", quitCommand }
            // };


            // while (!quitCommand.IsQuit()) 
            // {
            //     displayOptionsCommand.Execute();
            //     var input = Console.ReadLine();

            //     if (commands.ContainsKey(input)) 
            //     {
            //         commands[input].Execute();
            //     } 
            //     else 
            //     {
            //         Console.WriteLine("Invalid command ");
            //     }
            // }



        }
    }
}