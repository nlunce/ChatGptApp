using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class LoadNotebookCmd : ICommandNotebookService
    {
        private string _fileName;
        private Notebook _notebook;
        public LoadNotebookCmd(Notebook notebook)
        {
            _notebook = notebook;
            
        }
        public void Execute()
        {
            while (true)
            {
                Console.Write("What file would you like to load from? \n> ");
                _fileName = Console.ReadLine();

                if (string.IsNullOrEmpty(_fileName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError: Invalid filename. Please provide a valid filename.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }
            if(File.Exists(_fileName))
            {
                _notebook._notes.Clear();

                using (StreamReader reader = new StreamReader(_fileName)) 
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        string[] parts = line.Split(',');
                        Note note = new();
                        note.StoreNote(parts[0], parts[1], parts[2]);
                        _notebook.StoreNote(note);
                    };

                    

                }
              
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nNo such file in current directory.\n");
                Console.ResetColor();
                Thread.Sleep(2500);
            }

        }

    }
}