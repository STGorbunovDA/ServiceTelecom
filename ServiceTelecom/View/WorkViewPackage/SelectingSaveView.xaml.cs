using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class SelectingSaveView : Window
    {
        string city = string.Empty;
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
           radiostationsForDocumentsCollection
        { get; }
        public SelectingSaveView(string city, 
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection)
        {
            InitializeComponent();
            this.city = city;
            this.radiostationsForDocumentsCollection = radiostationsForDocumentsCollection;
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

        private void SaveRadiostationsForDocumets(object sender, RoutedEventArgs e)
        {
            SaveCSV.GetInstance.SaveRadiostationsForDocumets(city, radiostationsForDocumentsCollection);
        }

        private void SaveRadiostationsFull(object sender, RoutedEventArgs e)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            SaveCSV.GetInstance.SaveRadiostationsFull(city, radiostationsForDocumentsCollection);
        }
    }
}
