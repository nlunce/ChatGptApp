using System;

namespace ChatGptApp
{
    public class WriteMessageCmd : ICommand
    {
        private string _message;

        public Message Execute()
        {
            Console.Write("What do you want to ask?: \n> ");
            _message = Console.ReadLine();

            Message message = new()
            {
                Content = _message
            };

            return message;
        }
    }
}
