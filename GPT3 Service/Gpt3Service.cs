using System.Text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ChatGptApp
{
    public class Gpt3Service
    {
        private readonly string _apiKey;
        public HttpClient _client;
        
        public Gpt3Service(Credentials credentials)
        {
            _apiKey = credentials.ApiKey;
            _client = new();
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            DisplayGpt3OptCmd displayGpt3OptCmd = new();
            GPT3MainMenuCmd gpt3MainMenuCmd = new();
            AskGpt3Cmd askGpt3Cmd= new(credentials);

            Dictionary<string, ICommandGpt3Service> commands = new()
            {
                { "a", askGpt3Cmd},
                { "1", askGpt3Cmd},
                { "ask", askGpt3Cmd},
                { "Ask", askGpt3Cmd},
                { "ask gpt3", askGpt3Cmd},
                { "Ask Gpt3", askGpt3Cmd},
                { "Ask GPT3",askGpt3Cmd},

                { "m", gpt3MainMenuCmd},
                { "2", gpt3MainMenuCmd},
                { "menu", gpt3MainMenuCmd},
                { "Menu", gpt3MainMenuCmd},
                { "main", gpt3MainMenuCmd},
                { "main menu", gpt3MainMenuCmd},
                { "Main Menu", gpt3MainMenuCmd},
                
            };

             while (!gpt3MainMenuCmd.IsQuit()) 
            {
                displayGpt3OptCmd.Execute();
                var input = Console.ReadLine();
                

                if (commands.ContainsKey(input)) 
                {
                    commands[input].Execute();
                } 
                else 
                {
                    Console.WriteLine("Invalid command ");
                }
            }
        }
    }
}