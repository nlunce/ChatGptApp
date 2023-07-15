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
            // while (true)
            // {
            //     Console.Write("Please enter your API Key:\n> ");
            //     ApiKey = Console.ReadLine();

            //     if (!string.IsNullOrWhiteSpace(ApiKey))
            //         break;
            // }

            string apiKey = "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";
            ApiKey = apiKey;
        }
        public string Execute()
        {
            return ApiKey;
        }
    }
}