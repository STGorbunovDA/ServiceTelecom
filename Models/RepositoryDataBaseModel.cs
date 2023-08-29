using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class RepositoryDataBaseModel : ViewModelBase
    {
        private string _server;
        private string _port;
        private string _username;
        private string _password;
        private string _database;
        private string _codeWord;

        public string Server { get => _server; set { _server = value; OnPropertyChanged(nameof(Server)); } }
        public string Port { get => _port; set { _port = value; OnPropertyChanged(nameof(Port)); } }
        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string Database { get => _database; set { _database = value; OnPropertyChanged(nameof(Database)); } }
        public string CodeWord { get => _codeWord; set { _codeWord = value; OnPropertyChanged(nameof(CodeWord)); } }

        public RepositoryDataBaseModel(string server, string port, 
            string username, string password, string database, string codeWord)
        {
            Server = server;
            Port = port;
            Username = username;
            Password = password;
            Database = database;
            CodeWord = codeWord;
        }
    }
}
