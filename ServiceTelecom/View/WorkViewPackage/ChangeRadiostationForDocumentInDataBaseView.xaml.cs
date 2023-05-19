using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ServiceTelecom.View.WorkViewPackage
{
    /// <summary>
    /// Логика взаимодействия для ChangeRadiostationForDocumentInDataBaseView.xaml
    /// </summary>
    public partial class ChangeRadiostationForDocumentInDataBaseView : Window
    {
        public ChangeRadiostationForDocumentInDataBaseView()
        {
            InitializeComponent();
        }

        public ChangeRadiostationForDocumentInDataBaseView(RadiostationForDocumentsDataBaseModel selectedRadiostationForDocumentsDataBaseModel)
        {
            SelectedRadiostationForDocumentsDataBaseModel = selectedRadiostationForDocumentsDataBaseModel;
        }

        public RadiostationForDocumentsDataBaseModel SelectedRadiostationForDocumentsDataBaseModel { get; }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
