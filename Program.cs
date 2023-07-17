using System.Text;
using Newtonsoft.Json;

namespace ChatGptApp
{
    class Program
    {
         static void Main(string[] args)
        {

            Notebook notebook = new();
            GetApiKeyCmd getApiKeyCmd = new();
            Credentials credentials = new(getApiKeyCmd.Execute());
            
            QuitCmd quitCmd = new();
            DisplayOptCmd displayOptCmd = new();

            CreateNotebookServiceCmd createNotebookServiceCmd= new(credentials);

            CreateGPT3ServiceCmd createGPT3ServiceCmd= new(credentials);

             Dictionary<string, ICommand> commands = new()
            {
                { "n", createNotebookServiceCmd },
                { "N", createNotebookServiceCmd },
                { "1", createNotebookServiceCmd },
                { "notes", createNotebookServiceCmd },
                { "Notes", createNotebookServiceCmd },
                { "note", createNotebookServiceCmd },
                { "Note", createNotebookServiceCmd },

                { "g", createGPT3ServiceCmd },
                { "G", createGPT3ServiceCmd },
                { "2", createGPT3ServiceCmd },
                { "gpt", createGPT3ServiceCmd },
                { "GPT", createGPT3ServiceCmd },
                { "gpt3", createGPT3ServiceCmd },
                { "GPT3", createGPT3ServiceCmd },

                { "q", quitCmd },
                { "Q", quitCmd },
                { "3", quitCmd },
                { "quit", quitCmd },
                { "Quit", quitCmd }
            };

            while (!quitCmd.IsQuit()) 
            {
                displayOptCmd.Execute();
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