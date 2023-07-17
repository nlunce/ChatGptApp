using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatGptApp
{
    public class AskGpt3Cmd : ICommandGpt3Service
    {
        private const string OpenAIEndpoint = "https://api.openai.com/v1/chat/completions";
        
        private string ApiKey { get; set; }
        
        public AskGpt3Cmd(Credentials credentials)
        {
            ApiKey = credentials.ApiKey;
        }
        
        public void Execute()
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

            Console.Write("What would you like to ask?: \n> ");
            string message = Console.ReadLine();

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = message }
                }
            };

            string payloadJson = JsonConvert.SerializeObject(payload);
            var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLoading Response...\n");

            HttpResponseMessage response = client.PostAsync(OpenAIEndpoint, content).GetAwaiter().GetResult();
            string responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            try
            {
                dynamic responseData = JsonConvert.DeserializeObject(responseString);
                string apiResponse = responseData.choices[0].message.content;

                Console.WriteLine($"Response:\n{apiResponse}");
                Thread.Sleep(2000);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Could not deserialize the JSON: {ex.Message}");
                Thread.Sleep(2000);
                Console.ResetColor();
            }
        }    
    }
}
