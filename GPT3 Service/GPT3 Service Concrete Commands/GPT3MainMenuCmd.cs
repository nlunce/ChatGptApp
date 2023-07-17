using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class GPT3MainMenuCmd : ICommandGpt3Service
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