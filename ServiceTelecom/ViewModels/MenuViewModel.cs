﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class MenuViewModel : ViewModelBase
    {
        private UserRepository userRepository;
        public ICommand Adminka { get; }
        public MenuViewModel()
        {
            userRepository = new UserRepository();
            Adminka = new ViewModelCommand(ExecuteAdminkaCommand, CanExecuteAdminkaCommand);
        }

        private bool CanExecuteAdminkaCommand(object obj)
        {
            bool validData;
            if (UserStatic.Post != "Admin")
                validData = false;
            else validData = true;
            return validData;
        }
        private void ExecuteAdminkaCommand(object obj)
        {
            AdminView admin = new AdminView();
            admin.Show();

            //UserModel user = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            //if (user != null)
            //{
            //    MenuView menu = new MenuView();
            //    menu.Show();

            //}
            //else ErrorMessage = "Invalid username or password";
        }
    }
}
