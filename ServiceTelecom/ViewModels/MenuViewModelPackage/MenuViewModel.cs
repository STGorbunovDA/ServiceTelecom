﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View;
using ServiceTelecom.View.WorkViewPackage;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class MenuViewModel : ViewModelBase
    {

        StaffRegistrationRepository staffRegistrationRepository;

        AdminView admin = null;

        StaffRegistrationView staffRegistration = null;

        TutorialEngineerView tutorialEngineer = null;
        WorkView work = null;

        public ICommand Adminka { get; }
        public ICommand Registration { get; }
        public ICommand Tutorial { get; }
        public ICommand Work { get; }

        public MenuViewModel()
        {
            staffRegistrationRepository = new StaffRegistrationRepository();
            Adminka = new ViewModelCommand(ExecuteAdminkaCommand);
            Registration = new ViewModelCommand(ExecuteRegistrationCommand);
            Tutorial = new ViewModelCommand(ExecuteTutorialCommand);
            Work = new ViewModelCommand(ExecuteWorkCommand);
        }

        private void ExecuteWorkCommand(object obj)
        {
            if(UserModelStatic.POST == "Начальник участка" ||
               UserModelStatic.POST == "Инженер" || 
               UserModelStatic.POST == "Куратор" ||
               UserModelStatic.POST == "Дирекция связи")
            {
                UserModelStatic.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION =
                    staffRegistrationRepository.GetStaffRegistrationsDataBasePerLogin(
                        UserModelStatic.LOGIN,
                    UserModelStatic.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION);
                if (UserModelStatic.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION.Count == 0)
                {
                    MessageBox.Show("Тебя нет в списке сформированных бригад, " +
                        "сообщи об этом руководителю", "Информация",
                   MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }     
            }
            if (work == null)
            {
                work = new WorkView();
                work.Closed += (sender, args) => work = null;
                work.Closed += (sender, args) => 
                UserModelStatic.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION.Clear();
                work.Show();
            }
        }

        private void ExecuteTutorialCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            else if (tutorialEngineer == null)
            {
                tutorialEngineer = new TutorialEngineerView();
                tutorialEngineer.Closed += (sender, args) => tutorialEngineer = null;
                tutorialEngineer.Show();
            }
        }

        private void ExecuteRegistrationCommand(object obj)
        {
            if (UserModelStatic.POST == "Admin" || 
                UserModelStatic.POST == "Руководитель")
            {
                if (staffRegistration == null)
                {
                    staffRegistration = new StaffRegistrationView();
                    staffRegistration.Closed += (sender, args) => staffRegistration = null;
                    staffRegistration.Show();
                }
            }
            else return;
        }

        private void ExecuteAdminkaCommand(object obj)
        {
            if (UserModelStatic.POST != "Admin")
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
