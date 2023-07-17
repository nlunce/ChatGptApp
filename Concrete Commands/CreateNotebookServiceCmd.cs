using System;

namespace ChatGptApp
{
    public class CreateNotebookServiceCmd : ICommand
    {
        private Credentials _credentials;
        public CreateNotebookServiceCmd(Credentials credentials)
        {
            _credentials = credentials;
        }
        public async void Execute()
        {
            NotebookService notebookService= new(_credentials);
            notebookService.Run();
            
        }
    }
}
