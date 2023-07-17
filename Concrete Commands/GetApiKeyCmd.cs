using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ChatGptApp
{
    public class GetApiKeyCmd : ICommand
    {
        
        public string ApiKey { get; set; }

        public GetApiKeyCmd()
        {
            while (true)
            {
                Console.Write("Please enter your API Key:\n> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError: Invalid API Key\n");
                    Thread.Sleep(500);
                    Console.ResetColor();
                }
                else
                {
                    ApiKey = input;   
                    break;
                }

            }
        }
        public string Execute()
        {
            return ApiKey;
        }
    }
}