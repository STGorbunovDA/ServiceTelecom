using ServiceTelecom.ViewModels;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class AdminView : Window
    {
        AdminViewModel adminViewModel;

        public AdminView()
        {
            adminViewModel = new AdminViewModel();
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
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            adminViewModel.GetAllSelectRowsUsers(dataGrid1);
        }
    }
}
