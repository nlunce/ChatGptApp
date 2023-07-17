using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class DisplayNotesCmd : ICommandNotebookService
    {
        Notebook _notebook;
        public DisplayNotesCmd(Notebook notebook)
        {
            _notebook = notebook;
        }
        public void Execute()
        {
            foreach(Note note in _notebook._notes)
                {
                    Console.WriteLine(note.GetNoteAsString());
                    Thread.Sleep(750);
                }
            Thread.Sleep(2000);
        }

    }
}