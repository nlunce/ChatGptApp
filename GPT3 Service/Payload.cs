using System.Text;
using Newtonsoft.Json;

namespace ChatGptApp
{
    class Payload
    {
        public string model { get; set; }
        public dynamic[] messages { get; set; }

        public Payload(Message message)
        {
            model = "gpt-3.5-turbo";
            messages = new[]
            {
                new { role = "system", content = "You are a helpful assistant." },
                new { role = "user", content = message.Content }
            };
        
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}