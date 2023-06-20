using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.Base
{
    public partial class AddHandbookParametersView : Window
    {
        public AddHandbookParametersView()
        {
            InitializeComponent();
            cmbModel.SelectedIndex = 0;
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
