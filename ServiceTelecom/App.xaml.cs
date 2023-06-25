using System.Windows;
using System;
using ServiceTelecom.View;
using System.Threading;
using ServiceTelecom.View.WorkViewPackage;
using ServiceTelecom.Infrastructure;

namespace ServiceTelecom
{
    public partial class App : Application
    {
        [Obsolete]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (InstanceChecker.TakeMemory())
            {
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
