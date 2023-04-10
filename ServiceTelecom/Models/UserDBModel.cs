using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class UserDBModel : ViewModelBase
    {
        private int _id;
        private string _login;
        private string _password;
        private string _post;

        public UserDBModel(int id, string login, string password, string post)
        {
            IdBase = id;
            LoginBase = login;
            PasswordBase = password;
            PostBase = post;
        }

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string LoginBase { get => _login; set { _login = value; OnPropertyChanged(nameof(LoginBase)); } }
        public string PasswordBase { get => _password; set { _password = value; OnPropertyChanged(nameof(PasswordBase)); } }
        public string PostBase { get => _post; set { _post = value; OnPropertyChanged(nameof(PostBase)); } }
        
    }
}
