using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System;
using System.Collections;
using System.Windows;
using ServiceTelecom.Repositories.Interfaces;

namespace ServiceTelecom.ViewModels
{
    internal class AdminViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        public ObservableCollection<UserDataBaseModel> Users { get; set; }

        int _id;
        public int Id { get => _id; 
            set { _id = value; 
                OnPropertyChanged(nameof(Id)); } 
        }

        string _login = string.Empty;
        public string Login { get => _login; 
            set { _login = value; 
                OnPropertyChanged(nameof(Login)); } 
        }

        string _password;
        public string Password { get => _password; 
            set { _password = value; 
                OnPropertyChanged(nameof(Password)); } 
        }

        string _post;
        public string Post { get => _post; 
            set { _post = value; 
                OnPropertyChanged(nameof(Post)); } 
        }

        string _message;
        public string Message { get => _message; 
            set { _message = value; 
                OnPropertyChanged(nameof(Message)); } 
        }

        IList _selectedModels = new ArrayList();
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

        UserDataBaseModel _user;
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

        void ExecuteChangeUserDataBaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Login) 
                && String.IsNullOrWhiteSpace(Password)
                && Login.Length < 3 && Password.Length < 3 && Login.Length > 22 
                && Password.Length > 22)
            {
                Message = "Error change user's";
                return;
            }
            if (userRepository.ChangeUserDataBase(Id, Login, Password, Post))
            {
                Message = "Successfully delete user's";
                Users.Clear();
                Users = userRepository.GetAllUsersDataBase(Users);
            }
            else Message = "Error delete user's";

        }

        #endregion

        #region DeleteUserDataBase

        void ExecuteDeleteUserDataBaseCommand(object obj)
        {
            if (UserMulipleSelectedDataGrid == null || 
                UserMulipleSelectedDataGrid.Count == 0)
                return;
            foreach (UserDataBaseModel user in UserMulipleSelectedDataGrid)
                userRepository.DeleteUsersDataBase(user);
            Users.Clear();
            Users = userRepository.GetAllUsersDataBase(Users);
        }

        #endregion

        #region AddUserDataBase

        void ExecuteAddUserDataBaseCommand(object obj)
        {
            if (!Login.Contains("-"))
            {
                if (!Regex.IsMatch(Login,
                    @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Login\" " +
                        "пример Иванов И.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Login.Contains("-"))
            {
                if (!Regex.IsMatch(Login, 
                    @"^[А-ЯЁ][а-яё]*(([\-][А-Я][а-яё]*[\s]+[А-Я]+[\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Представитель ФИО\" " +
                        "пример Иванова-Сидорова Я.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (userRepository.AddUserDataBase(Login, Password, Post))
            {
                Message = "Successfully adding a user";
                Users.Clear();
                Users = userRepository.GetAllUsersDataBase(Users);
            }
            else Message = "Error adding a user";
        }

        #endregion

        #region UpdateUserDataBase

        void ExecuteUpdateUserDataBaseCommand(object obj)
        {
            Users.Clear();
            Users = userRepository.GetAllUsersDataBase(Users);
        }

        #endregion
    }
}
