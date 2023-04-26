using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class TutorialEngineerView : Window
    {
        public TutorialEngineerView()
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
            Close();
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перед началом проверки радиостанции необходимо визуально " +
                "осмотреть корпус на сквозные трещины, сколы корпуса, батарейные контакты, " +
                "уплотнитель батарейного контакта, а также ручку регулятора громкости и ручку " +
                "переключения каналов.Проивести чистку корпуса радиостанции, убрать металлическую " +
                "стружку из динамика. Чистка внешних поверхностей радиостанции включают фронтальную " +
                "крышку радиостанции, корпус радиостанции и корпус батареи. Чистку проводить неметаллической " +
                "короткошерстной щёткой для удаления грязи с радиостанции. Так же Используйте мягкую, " +
                "абсорбирующую ткань, кубки для мытья посуды или влажные салфетки.", "Информация",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
