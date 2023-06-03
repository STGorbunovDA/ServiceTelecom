using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Controls;
using System;
using System.Collections;

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
        public string Login { get => _login; 
            set { _login = value; OnPropertyChanged(nameof(Login)); } }
        public string Password { get => _password; 
            set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string Post { get => _post; 
            set { _post = value; OnPropertyChanged(nameof(Post)); } }
        public string Message { get => _message; 
            set { _message = value; OnPropertyChanged(nameof(Message)); } }

        private UserRepository userRepository;
        public ObservableCollection<UserDataBaseModel> Users { get; set; }

        private IList _selectedModels = new ArrayList();
        public IList UserMulipleSelectedDataGrid
        {
            get { return _selectedModels; }
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(UserMulipleSelectedDataGrid));
            }
        }

        public ICommand AddUserDataBase { get; }
        public ICommand UpdateUsersDataBase { get; }
        public ICommand DeleteUserDataBase { get; }
        public ICommand AddUsersListCommand { get; }
        public ICommand ChangeUserDataBase { get; }

        private UserDataBaseModel _user;
        public UserDataBaseModel SelectedUser
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(SelectedUser));
                if (_user != null)
                {
                    Id = _user.IdBase;
                    Login = _user.LoginBase;
                    Password = _user.PasswordBase;
                    Post = _user.PostBase;
                }
            }
        }

        public AdminViewModel()
        {
            userRepository = new UserRepository();
            Users = new ObservableCollection<UserDataBaseModel>();
            Users = userRepository.GetAllUsersDataBase(Users);
            DeleteUserDataBase = new ViewModelCommand(ExecuteDeleteUserDataBaseCommand);
            AddUserDataBase = new ViewModelCommand(ExecuteAddUserDataBaseCommand);
            UpdateUsersDataBase = new ViewModelCommand(ExecuteUpdateUserDataBaseCommand);
            ChangeUserDataBase = new ViewModelCommand(ExecuteChangeUserDataBaseCommand);
        }

        #region ChangeUsersDataBase

        private void ExecuteChangeUserDataBaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Login) && String.IsNullOrWhiteSpace(Password)
                && Login.Length < 3 && Password.Length < 3 && Login.Length > 22 && Password.Length > 22)
            {
                Message = "Error change user's";
                return;
            }
            bool flag = userRepository.ChangeUserDataBase(Id, Login, Password, Post);
            if (flag)
            {
                Message = "Successfully delete user's";
                Users.Clear();
                Users = userRepository.GetAllUsersDataBase(Users);
            }
            else Message = "Error delete user's";

        }

        #endregion

        #region DeleteUserDataBase

        private void ExecuteDeleteUserDataBaseCommand(object obj)
        {
            if (UserMulipleSelectedDataGrid == null || UserMulipleSelectedDataGrid.Count == 0)
                return;
            foreach (UserDataBaseModel user in UserMulipleSelectedDataGrid)
                userRepository.DeleteUsersDataBase(user);
            Users.Clear();
            Users = userRepository.GetAllUsersDataBase(Users);
        }

        #endregion

        #region AddUserDataBase

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
            else Message = "Error adding a user";
        }

        #endregion

        #region UpdateUserDataBase

        private void ExecuteUpdateUserDataBaseCommand(object obj)
        {
            Users.Clear();
            Users = userRepository.GetAllUsersDataBase(Users);
        }

        #endregion
    }
}
