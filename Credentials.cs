namespace ChatGptApp
{
    public class Credentials 
    {
        public string ApiKey { get; set; }
        public Credentials(string apiKey)
        {
            ApiKey = apiKey;
        }
        
    }
}