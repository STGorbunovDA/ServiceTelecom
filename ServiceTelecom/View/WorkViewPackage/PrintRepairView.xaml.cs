using ServiceTelecom.Infrastructure;
using ServiceTelecom.Infrastructure.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class PrintRepairView : Window
    {
        
        GetSetRegistryServiceTelecomSetting getSetRegistryServiceTelecomSetting;
        public PrintRepairView()
        {
          
            getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();

            InitializeComponent();
            Loaded += PrintRepairView_Loader;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void PrintRepairView_Loader(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
                vm.Close += () =>{ Close();};
        }
    }
}
