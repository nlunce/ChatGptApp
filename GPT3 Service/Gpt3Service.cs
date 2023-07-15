using System.Text;
using Newtonsoft.Json;

namespace ChatGptApp
{
    class Gpt3Service
    {
        private readonly string _apiKey;
        public HttpClient _client;
        
        public Gpt3Service(Credentials credentials)
        {
            _apiKey = credentials.ApiKey;
            _client = new();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

    }
}