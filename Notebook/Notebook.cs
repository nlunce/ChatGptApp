using System;
using System.Collections.Generic;
using System.IO;

namespace ChatGptApp
{
    public class Notebook
    {
        public List<Note> _notes;

        public Notebook()
        {
             _notes = new List<Note>();
        }

        public List<Note> GetAllNotes()
        {
            return _notes;

        }
        
        public void StoreEntry(Note note)
        {
            if(!_notes.Contains(note))
            {
                this._notes.Add(note);
            }
        }

        
    }
}
