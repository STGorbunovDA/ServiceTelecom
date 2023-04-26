using ServiceTelecom.Models;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    /// <summary>
    /// Логика взаимодействия для WorkView.xaml
    /// </summary>
    public partial class WorkView : Window
    {
        readonly UserModel _user;
        public WorkView(UserModel user)
        {
            _user = user;
            InitializeComponent();
        }


        void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
