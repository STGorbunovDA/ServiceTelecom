using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class MenuViewModel : ViewModelBase
    {

        AdminView admin = null;

        public ICommand Adminka { get; }
        public MenuViewModel()
        {
            Adminka = new ViewModelCommand(ExecuteAdminkaCommand);
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
