using Microsoft.Win32;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Net;
using System.Security;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get =>_password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
            GetRegistry();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                    Password == null || Password.Length < 3)
                validData = false;
            else validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                //Thread.CurrentPrincipal = new GenericPrincipal(
                //    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else ErrorMessage = "Invalid username or password";
        }
        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
        private void GetRegistry()
        {
            try
            {
                RegistryKey reg1 = Registry.CurrentUser.OpenSubKey($"SOFTWARE\\ServiceTelekom_Setting\\Login_Password");
                if (reg1 != null)
                {
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey($"SOFTWARE\\ServiceTelekom_Setting\\Login_Password");
                    Username = helloKey.GetValue("Login").ToString();
                    #region 
                    // TODO 2. убрать пароль из реестра?
                    string pass = helloKey.GetValue("Password").ToString();
                    helloKey.Close();
                    for (int i = 0; i < pass.Length; i++)
                    {
                        //Password.AppendChar(pass[i]); 
                    }
                    #endregion
                }
            }
            catch
            {
            }
        }
    }
}
