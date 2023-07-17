using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class DisplayGpt3OptCmd : ICommandGpt3Service
    {
        public void Execute()
        {
            Console.Write("\nPlease select one of the following choices:\n1. Ask GPT3\n2. Main Menu\n> ");

        }
    }
}