using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChatGptApp
{
    public class NotebookService
    {
        private Credentials _credentials;

        public NotebookService(Credentials credentials)
        {
            _credentials = credentials;
        }

        public async Task Run()
        {
            Notebook notebook = new Notebook();

            NotebookMainMenuCmd mainMenuCmd = new();
            DisplayNotebookOptCmd displayNotebookOptCmd = new();

            LoadNotebookCmd loadNotebookCmd = new(notebook);
            CreateNoteCmd createNoteCmd = new(notebook, _credentials);
            DisplayNotesCmd displayNotesCmd = new(notebook);
            SaveNotesCmd saveNotesCmd = new(notebook);

            Dictionary<string, ICommandNotebookService> commands = new()
            {
                { "l", loadNotebookCmd },
                { "L", loadNotebookCmd },
                { "1", loadNotebookCmd },
                { "load", loadNotebookCmd },
                { "load notebook", loadNotebookCmd },
                { "Load", loadNotebookCmd },
                { "Load Notebook", loadNotebookCmd },

                { "w", createNoteCmd },
                { "W", createNoteCmd },
                { "2", createNoteCmd },
                { "write", createNoteCmd },
                { "write note", createNoteCmd },
                { "Write", createNoteCmd },
                { "Write Note", createNoteCmd },

                { "v", displayNotesCmd },
                { "V", displayNotesCmd },
                { "3", displayNotesCmd },
                { "view", displayNotesCmd },
                { "view notes", displayNotesCmd },
                { "View", displayNotesCmd },
                { "View Notes", displayNotesCmd },

                { "s", saveNotesCmd },
                { "S", saveNotesCmd },
                { "4", saveNotesCmd },
                { "save", saveNotesCmd },
                { "save notes", saveNotesCmd },
                { "Save", saveNotesCmd },
                { "Save Notes", saveNotesCmd },

                { "m", mainMenuCmd },
                { "M", mainMenuCmd },
                { "5", mainMenuCmd },
                { "main", mainMenuCmd },
                { "main menu", mainMenuCmd },
                { "Main", mainMenuCmd },
                { "Main Menu", mainMenuCmd }
            };

            while (!mainMenuCmd.IsQuit())
            {
                displayNotebookOptCmd.Execute();
                var input = Console.ReadLine();

                if (commands.ContainsKey(input))
                {
                    commands[input].Execute();
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
