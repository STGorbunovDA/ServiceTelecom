using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class ReportCardView : Window
    {
        public ReportCardView()
        {
            InitializeComponent();
            cmbUser.SelectedIndex = 0;
            cmbDateTimeInput.SelectedIndex = 0;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
