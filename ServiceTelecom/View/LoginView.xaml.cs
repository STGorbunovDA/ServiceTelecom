using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ServiceTelecom.View
{
    /// <summary>
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ChbPass_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)chbPass.IsChecked)
            {
                txbPass.Visibility = Visibility.Visible;
                psbPass.Visibility = Visibility.Collapsed;
            }
            else
            {
                txbPass.Visibility = Visibility.Collapsed;
                psbPass.Visibility = Visibility.Visible;
            }
        }

        private void PsbPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (psbPass.Password.Length > 0)
                txbPass.Text = psbPass.Password;
        }

        private void TxbPass_KeyUp(object sender, KeyEventArgs e)
        {
            psbPass.Password = txbPass.Text;
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxbClearPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            psbPass.Password = string.Empty;
            txbPass.Text = string.Empty;
        }
    }
}
