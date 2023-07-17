using System;

namespace ChatGptApp
{
    public class CreateGPT3ServiceCmd : ICommand
    {
        Credentials _credentials;
        public CreateGPT3ServiceCmd(Credentials credentials)
        {
            _credentials = credentials;
        }
        public void Execute()
        {
            Gpt3Service gpt3Service = new(_credentials);    
            
        }
    }
}
