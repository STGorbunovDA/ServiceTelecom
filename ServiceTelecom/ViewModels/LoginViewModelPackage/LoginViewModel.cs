﻿using Microsoft.Win32;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Net;
using System.Security;
using System.Windows.Input;
using ServiceTelecom.View;
using ServiceTelecom.Infrastructure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ServiceTelecom.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private UserRepository userRepository;
        private GetSetRegistryServiceTelecomSetting getSetRegistryServiceTelecomSetting;

        public string Username { get => _username; 
            set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public SecureString Password { get => _password; 
            set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; 
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; 
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel()
        {
            getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();
            Username = getSetRegistryServiceTelecomSetting.GetRegistryUser();
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                    Password == null || Password.Length < 3 || Username.ToLower().Equals("select")
                    || Username.Length > 22 || Password.Length > 22)
                validData = false;
            else validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            UserModelStatic user = userRepository.GetAuthorizationUser(new NetworkCredential(Username, Password));
            if (user != null)
            {
                bool flag = userRepository.SetDateTimeUserDataBase(UserModelStatic.Login);
                if (flag)
                {
                    getSetRegistryServiceTelecomSetting.SetRegistryUser(UserModelStatic.Login);
                    MenuView menu = new MenuView(user);
                    menu.Show();
                    IsViewVisible = false;
                }
                else ErrorMessage = "Invalid set dateTime User DataBase";

            }
            else ErrorMessage = "Invalid username or password";
        }
    }
}
