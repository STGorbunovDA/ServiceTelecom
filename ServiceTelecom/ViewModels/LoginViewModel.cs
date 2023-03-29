using Microsoft.Win32;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Net;
using System.Security;
using System.Windows.Input;
using ServiceTelecom.View;
using System.Threading;
using System.Security.Principal;

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

        public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public LoginViewModel()
        {
            GetRegistry();
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
            UserModel user = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (user != null)
            {
                //Thread.CurrentPrincipal = new GenericPrincipal(
                //    new GenericIdentity(user.Post), null);
                var work = new WorkView(user);
                work.Show();
                IsViewVisible = false;
                
            }
            else ErrorMessage = "Invalid username or password";
        }

        /// <summary>Получаем если есть логин из реестра</summary>
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
                }
            }
            catch
            {
            }
        }
    }
}
