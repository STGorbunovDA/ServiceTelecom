using ServiceTelecom.Models;
using ServiceTelecom.View;
using System;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class MenuViewModel : ViewModelBase
    {

        AdminView admin = null;

        StaffRegistrationView staffRegistration = null;

        TutorialEngineerView tutorialEngineer = null;

        public ICommand Adminka { get; }
        public ICommand Registration { get; }
        public ICommand Tutorial { get; }

        public MenuViewModel()
        {
            Adminka = new ViewModelCommand(ExecuteAdminkaCommand);
            Registration = new ViewModelCommand(ExecuteRegistrationCommand);
            Tutorial = new ViewModelCommand(ExecuteTutorialCommand);
        }

        private void ExecuteTutorialCommand(object obj)
        {
            if (UserModel.Post == "Дирекция связи")
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
            if (UserModel.Post == "Admin" || UserModel.Post == "Руководитель")
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
            if (UserModel.Post != "Admin")
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
