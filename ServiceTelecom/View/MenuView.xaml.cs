using ServiceTelecom.Models;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class MenuView : Window
    {
        readonly UserModel _user;
        public MenuView(UserModel user)
        {
            InitializeComponent();
            _user= user;
        }

        void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
