using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.Base
{
    /// <summary>
    /// Логика взаимодействия для RepairManualView.xaml
    /// </summary>
    public partial class RepairManualView : Window
    {
        public RepairManualView(string model)
        {
            InitializeComponent();
            txtModel.Text = model;
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
    }
}
