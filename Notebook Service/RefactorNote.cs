using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatGptApp
{
    class RefactorNote
    {
        private const string _openAIEndpoint = "https://api.openai.com/v1/chat/completions";

        public static async Task<string> GetRewrittenNoteAysnc(string message, Credentials credentials)
        {
            string apiKey = credentials.ApiKey;
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = $"Please rewrite the following note to be better but without using any commas: Note: {message}" }
                }
            };

            string payloadJson = JsonConvert.SerializeObject(payload);
            var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(_openAIEndpoint, content).ConfigureAwait(false);
            string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            try
            {
                dynamic responseData = JsonConvert.DeserializeObject(responseString);
                string apiResponse = responseData.choices[0].message.content;
                return apiResponse;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"---> Could not deserialize the JSON: {ex.Message}");
                Console.ResetColor();
            }

            return null;
        }
    }
}
