using ServiceTelecom.View;
using System.Windows;
using System.Configuration;
using System;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.View.TutorialEngineerViewPackage;
using ServiceTelecom.View.Base;

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

            var addModelRadiostantionView = new AddModelRadiostantionView();
            addModelRadiostantionView.Show();

            //var addTutorialEngineerView = new AddTutorialEngineerView();
            //addTutorialEngineerView.Show();

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
