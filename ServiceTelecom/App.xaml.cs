using ServiceTelecom.View;
using System.Windows;
using System.Configuration;
using System;
using ServiceTelecom.Infrastructure;

namespace ServiceTelecom
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        [Obsolete]
        protected void ApplicationStart(object sender, StartupEventArgs e)
        {
            //TODO  разобраться с конфигом
            StaticConfig.userName = ConfigurationSettings.AppSettings["userName"];
            StaticConfig.password = ConfigurationSettings.AppSettings["password"];
            StaticConfig.dataBase = ConfigurationSettings.AppSettings["dataBase"];
            StaticConfig.word = ConfigurationSettings.AppSettings["word"];

            var loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                    loginView.Close();
            };
        }
    }
}
