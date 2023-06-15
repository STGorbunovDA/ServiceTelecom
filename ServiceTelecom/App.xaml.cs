using System.Windows;
using System;
using ServiceTelecom.View;
using ServiceTelecom.View.WorkViewPackage;

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
            //StaticConfig.userName = ConfigurationSettings.AppSettings["userName"];
            //StaticConfig.password = ConfigurationSettings.AppSettings["password"];
            //StaticConfig.dataBase = ConfigurationSettings.AppSettings["dataBase"];
            //StaticConfig.word = ConfigurationSettings.AppSettings["word"];


            var addRadiostationParametersView = new AddRadiostationParametersView();
            addRadiostationParametersView.Show();

            //var loginView = new LoginView();
            //loginView.Show();

            //loginView.IsVisibleChanged += (s, ev) =>
            //{
            //    if (loginView.IsVisible == false && loginView.IsLoaded)
            //        loginView.Close();
            //};
        }
    }
}
