using System;
using System.Collections.Generic;
using System.IO;

namespace ChatGptApp
{
    public class Note
    {
        public string _note = "";
        public string _date = "";

         public string GetNoteAsString()
        {
            return $"\nDate: {_date} \nResponse: {_note}";
        }

        public void StoreNote(string date, string note)
        {
            _note = note;
            _date = date;
        }
        

        
    }
}
