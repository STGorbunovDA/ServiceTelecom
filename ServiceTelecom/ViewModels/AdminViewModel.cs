using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class AdminViewModel : ViewModelBase
    {

        private int _id;
        private string _login = string.Empty;
        private string _password;
        private string _post;
        private string _message;

        public int Id { get => _id; set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Login { get => _login; set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string Post { get => _post; set { _post = value; OnPropertyChanged(nameof(Post)); } }
        public string Message { get => _message; set { _message = value; OnPropertyChanged(nameof(Message)); } }

        private UserRepository userRepository;
        public ObservableCollection<UserDBModel> Users { get; set; }

        private UserDBModel _user;
        public ICommand AddUserDataBase { get; }
        public UserDBModel SelectedUser
        {
            get => _user;
            set 
            { 
                _user = value;
                OnPropertyChanged(nameof(SelectedUser));
                Id = _user.IdBase;
                Login = _user.LoginBase;
                Password = _user.PasswordBase;
                Post = _user.PostBase;
            }
        }

        public AdminViewModel()
        {
            userRepository = new UserRepository();
            Users = new ObservableCollection<UserDBModel>();
            Users = userRepository.GetAllUsersDataBase(Users);
            AddUserDataBase = new ViewModelCommand(ExecuteAddUserDataBaseCommand, CanExecuteAddUserDataBaseCommand);
        }

        private bool CanExecuteAddUserDataBaseCommand(object obj)
        {
            return true;
        }

        private void ExecuteAddUserDataBaseCommand(object obj)
        {
            if (!Login.Contains("-"))
            {
                if (!Regex.IsMatch(Login, @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    Message = "Введите корректно поле \"Логин\"P.s. пример: Иванов В.В.";
                    return;
                }
            }
            else if (Login.Contains("-"))
            {
                if (!Regex.IsMatch(Login, @"^[А-ЯЁ][а-яё]*(([\-][А-Я][а-яё]*[\s]+[А-Я]+[\.]+[А-Я]+[\.])$)"))
                {
                    //MessageBox.Show("Введите корректно поле \"Логин\"P.s. пример: Иванов-Петров В.В.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Message = "Введите корректно поле \"Логин\"P.s. пример: Иванов-Петров В.В.";
                    return;
                }
            }
            bool flag = userRepository.AddUserDataBase(Login, Password, Post);
            if (flag)
            {
                Message = "Successfully adding a user";
                Users.Clear();
                Users = userRepository.GetAllUsersDataBase(Users);
            }
            else
            {
                Message = "Error adding a user";
            }
        }
    }
}
