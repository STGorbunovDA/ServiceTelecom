using ServiceTelecom.View;
using System.Windows;

namespace ServiceTelecom
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    //var work = new WorkView();
                    //work.Show();
                    loginView.Close();

                }
            };
        }
    }
}
