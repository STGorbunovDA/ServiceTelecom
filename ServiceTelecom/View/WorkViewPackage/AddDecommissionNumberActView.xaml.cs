using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class AddDecommissionNumberActView : Window
    {
        public AddDecommissionNumberActView(
            string road, string city, 
            string serialNumber, 
            string numberAct)
        {
            InitializeComponent();
            txtRoad.Text = road;
            txtCity.Text = city;
            txtSerialNumber.Text = serialNumber;
            txbDecommissionNumberAct.Text = numberAct + "C";
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
