using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class MenuView : Window
    {
        UserRepository userRepository;
        UserModel _user;
        public MenuView(UserModel user)
        {
            userRepository = new UserRepository();
            InitializeComponent();
            _user = user;
        }

        void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
            if (userRepository.SetDateTimeExitUserDataBase(_user.Login))
                Close();

            //else
            //{
            //    MessageBox.Show($"Ошибка записи времени выхода из программы user: {UserStatic.Login}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
