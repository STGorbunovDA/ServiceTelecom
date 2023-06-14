using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class AddRepairRadiostationForDocumentInDataBaseView : Window
    {
        private WorkRadiostantionFullRepository _workRepositoryRadiostantionFull;

        public AddRepairRadiostationForDocumentInDataBaseView(
            RadiostationForDocumentsDataBaseModel radiostation)
        {
            _workRepositoryRadiostantionFull = new WorkRadiostantionFullRepository();

            InitializeComponent();

            txtRoad.Text = radiostation.Road;
            txtCity.Text = radiostation.City;
            txbSerialNumber.Text = radiostation.SerialNumber;
            txtCompany.Text = radiostation.Company;
            if (!string.IsNullOrWhiteSpace(radiostation.NumberActRepair))
                txbNumberActRepair.Text = radiostation.NumberActRepair; 

            datePickerDateRepair.Text = radiostation.DateMaintenance;

            txbModel.Text = radiostation.Model;

            if (!string.IsNullOrWhiteSpace(radiostation.Category))
            {
                cmbCategory.Text = radiostation.Category;
                txbPriceRepair.Text = radiostation.PriceRemont;
                if (txbPriceRepair.Text == UserModelStatic.priceRepairAnalogCategory_3 ||
                    txbPriceRepair.Text == UserModelStatic.priceRepairAnalogCategory_4 ||
                    txbPriceRepair.Text == UserModelStatic.priceRepairAnalogCategory_5 ||
                    txbPriceRepair.Text == UserModelStatic.priceRepairAnalogCategory_6)
                    CheckBoxChoicePriceAnalogDigital.IsChecked = true;
                else CheckBoxChoicePriceAnalogDigital.IsChecked = false;
            }
            else
            {
                cmbCategory.Text = UserModelStatic.Category_6;
                CheckBoxChoicePriceAnalogDigital.IsChecked = true;
                txbPriceRepair.Text = UserModelStatic.priceRepairAnalogCategory_6;
            }

            cmbCompletedWorks_1.Text = radiostation.CompletedWorks_1;
            txbParts_1.Text = radiostation.Parts_1;
            cmbCompletedWorks_2.Text = radiostation.CompletedWorks_2;
            txbParts_2.Text = radiostation.Parts_2;
            cmbCompletedWorks_3.Text = radiostation.CompletedWorks_3;
            txbParts_3.Text = radiostation.Parts_3;
            cmbCompletedWorks_4.Text = radiostation.CompletedWorks_4;
            txbParts_4.Text = radiostation.Parts_4;
            cmbCompletedWorks_5.Text = radiostation.CompletedWorks_5;
            txbParts_5.Text = radiostation.Parts_5;
            cmbCompletedWorks_6.Text = radiostation.CompletedWorks_6;
            txbParts_6.Text = radiostation.Parts_6;
            cmbCompletedWorks_7.Text = radiostation.CompletedWorks_7;
            txbParts_7.Text = radiostation.Parts_7;
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
    }
}
