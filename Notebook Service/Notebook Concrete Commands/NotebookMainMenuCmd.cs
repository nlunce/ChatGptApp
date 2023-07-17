using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class NotebookMainMenuCmd : ICommandNotebookService
    {
        private bool _quit = false;
        public void Execute()
        {
            this._quit = true;
            
        }
        public bool IsQuit()
    {
        return _quit;
    }


    }
}