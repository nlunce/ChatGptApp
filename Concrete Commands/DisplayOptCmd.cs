using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class DisplayOptCmd : ICommand
    {
        public void Execute()
        {
            Console.Write("\nPlease select one of the following choices:\n1. Notes\n2. GPT3\n3. Quit\n> ");
        }
    }
}