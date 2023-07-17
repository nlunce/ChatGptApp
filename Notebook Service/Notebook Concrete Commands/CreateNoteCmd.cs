using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class CreateNoteCmd : ICommandNotebookService
    {
        private Notebook _notebook;
        private Credentials _credentials;
        public CreateNoteCmd(Notebook notebook, Credentials credentials)
        {
            _notebook = notebook;
            _credentials = credentials;
           
        }
        public void Execute()
        {
            Note note = new();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Console.Write("Note Title:\n> ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Note:\n> ");
            string input = Console.ReadLine() ?? string.Empty;

            while(true)
            {
                Console.Write("Would you like to refactor your note With GPT3?:\n1. Yes\n2. No\n> ");
                string refactor = Console.ReadLine() ?? string.Empty;

                if (refactor == "1" || refactor == "yes" || refactor == "Yes")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nRefactoring Note...\n");

                    string rewrittenNote = RefactorNote.GetRewrittenNoteAysnc(input, _credentials).GetAwaiter().GetResult();

                    Console.WriteLine($"Rewritten Note:\n\n{rewrittenNote}\n");
                    Thread.Sleep(2000);
                    Console.ResetColor();
                    
                        while(true)
                        {
                            Console.Write("Would you like to keep the rewritten note?\n1. Yes\n2. No\n> ");
                            string saveRefactor = Console.ReadLine();

                            if (saveRefactor == "1" || saveRefactor == "yes" || saveRefactor == "Yes")
                            {
                                note.StoreNote(title, currentDate, rewrittenNote);
                                _notebook.StoreNote(note);
                                break;
                            }
                            else if (saveRefactor == "2" || saveRefactor == "no" || saveRefactor == "No")
                            {
                                note.StoreNote(title, currentDate, input);
                                _notebook.StoreNote(note);
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid Input\n");
                                Thread.Sleep(500);
                                Console.ResetColor();   
                            }
                            break;
                        }
                }
                else if (refactor == "2" || refactor == "no" || refactor == "No")
                {
                    note.StoreNote(title, currentDate, input);
                    _notebook.StoreNote(note);  
                    break; 
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input\n");
                    Thread.Sleep(500);
                    Console.ResetColor();
                }
                break;       
            }    
        }
    }      
}
