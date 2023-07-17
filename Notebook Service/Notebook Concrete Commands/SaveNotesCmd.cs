using System;
using System.IO;

namespace ChatGptApp
{
    public class SaveNotesCmd : ICommandNotebookService
    {
        private Notebook _notebook;
        private string _fileName;

        public SaveNotesCmd(Notebook notebook)
        {
            _notebook = notebook;
        }

        public void Execute()
        {
            while (true)
            {
                Console.Write("What file would you like to save to? \n> ");
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

            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                 foreach (Note note in _notebook._notes) 
                {
                    string line = $"{note._title},{note._date},{note._note}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
