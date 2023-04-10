﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View;
using System;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class MenuViewModel : ViewModelBase
    {

        AdminView admin = null;

        StaffRegistrationView staffRegistration = null;
        public ICommand Adminka { get; }
        public ICommand Registration { get; }
        public MenuViewModel()
        {
            Adminka = new ViewModelCommand(ExecuteAdminkaCommand);
            Registration = new ViewModelCommand(ExecuteRegistrationCommand);
        }

        private void ExecuteRegistrationCommand(object obj)
        {
            if (UserStatic.Post == "Admin" || UserStatic.Post == "Руководитель")
            {
                if (staffRegistration == null)
                {
                    staffRegistration = new StaffRegistrationView();
                    staffRegistration.Closed += (sender, args) => staffRegistration = null;
                    staffRegistration.Show();
                }
            } else return;
        }

        private void ExecuteAdminkaCommand(object obj)
        {
            //Application.Current.Windows.OfType<AdminView>().Where(x => x.Name == "admin").FirstOrDefault() != null
            if (UserStatic.Post != "Admin")
                return;
            else if (admin == null)
            {
                admin = new AdminView();
                admin.Closed += (sender, args) => admin = null;
                admin.Show();
            }
        }
    }
}
