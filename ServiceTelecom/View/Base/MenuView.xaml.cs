using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class MenuView : Window
    {
        UserRepository userRepository;
        public MenuView(UserModelStatic user)
        {
            userRepository = new UserRepository();
            InitializeComponent();
        }

        void Window_MouseDown(object sender, MouseButtonEventArgs e)
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
            if (userRepository.SetDateTimeExitUserDataBase(UserModelStatic.Login))
                Application.Current.Shutdown();
        }
    }
}
