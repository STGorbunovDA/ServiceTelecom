using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class WorkView : Window
    {
        public WorkView()
        {
            InitializeComponent();
            cmbRoad.SelectedIndex = 0;
            cmbChoiseSearch.SelectedIndex = 0;
            cmbSign.SelectedIndex = 0;
            cmbFillOut.SelectedIndex = 0;
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
