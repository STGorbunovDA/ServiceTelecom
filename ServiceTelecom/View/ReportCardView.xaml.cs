using ServiceTelecom.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View
{
    public partial class ReportCardView : Window
    {
        ReportCardViewModel reportCard;
        public ReportCardView()
        {
            InitializeComponent();
            reportCard = new ReportCardViewModel();
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

        private void BtnDeleteReportCardsDataBase_Click(object sender, RoutedEventArgs e)
        {
            reportCard.GetAllSelectRowsReportCardsAndDeleteId(dataGrid1);
        }
    }
}
