using System.Windows;
using System;
using ServiceTelecom.View;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.View.Base;

namespace ServiceTelecom
{
    public partial class App : Application
    {
        [Obsolete]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            GetSetRegistryServiceTelecomSetting getSetRegistryServiceTelecomSetting
                = new GetSetRegistryServiceTelecomSetting();

            UserModelStatic.LIST_REPOSITORY_DATABASE
                = getSetRegistryServiceTelecomSetting.GetRegistryForRepositoryDataBase();

            if (InstanceChecker.TakeMemory())
            {
                if (UserModelStatic.LIST_REPOSITORY_DATABASE.Count == 0)
                {
                    var getBaseSettingsRegistryViewModel = new GetBaseSettingsRegistryView();
                    getBaseSettingsRegistryViewModel.ShowDialog();

                    MessageBox.Show("Отлично! Перезапусти приложение!", "Успешно",
                          MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    foreach (var item in UserModelStatic.LIST_REPOSITORY_DATABASE)
                    {
                        UserModelStatic.SERVER = item.Server;
                        UserModelStatic.PORT = item.Port;
                        UserModelStatic.USERNAME = item.Username;
                        UserModelStatic.PASSWORD = item.Password;
                        UserModelStatic.DATABASE = item.Database;
                        UserModelStatic.CODE_WORD = item.CodeWord;
                    }

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
    }
}
