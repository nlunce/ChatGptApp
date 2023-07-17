using System;
using System.Collections.Generic;

namespace ChatGptApp
{
    public class DisplayNotebookOptCmd : ICommandNotebookService
    {
        public void Execute()
        {
            Console.Write("\nPlease select one of the following choices:\n1. Load Notebook\n2. Write Note\n3. View Notes\n4. Save Notes\n5. Main Menu\n> ");
        }
    }
}