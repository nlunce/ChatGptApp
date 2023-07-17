using System;
using System.Collections.Generic;
using System.IO;

namespace ChatGptApp
{
    public class Note
    {
        public string _title = "";
        public string _date = "";
        public string _note = "";
        public string GetNoteAsString()
        {
            return $"\n{_title} \nDate: {_date} \n{_note}";
        }
        public void StoreNote(string title, string date, string note)
        {
            _title = title;
            _date = date;
            _note = note;   
        }  
    }
}
