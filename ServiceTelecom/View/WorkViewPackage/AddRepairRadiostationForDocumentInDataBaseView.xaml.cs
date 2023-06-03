using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class AddRepairRadiostationForDocumentInDataBaseView : Window
    {
        private WorkRepositoryRadiostantionFull _workRepositoryRadiostantionFull;
        
        public AddRepairRadiostationForDocumentInDataBaseView(
            RadiostationForDocumentsDataBaseModel radiostation)
        {
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            
            InitializeComponent();

            txtRoad.Text = radiostation.Road;
            txtCity.Text = radiostation.City;
            txbSerialNumber.Text = radiostation.SerialNumber;

            if (!string.IsNullOrWhiteSpace(radiostation.NumberActRepair))
                txbNumberActRepair.Text = radiostation.NumberActRepair;
            else
            {
                foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                    txbNumberActRepair.Text = item.NumberPrintDocumentBase + "/";
            }

            datePickerDateRepair.Text = radiostation.DateMaintenance;

            txbModel.Text = radiostation.Model;

            if (!string.IsNullOrWhiteSpace(radiostation.Category))
            {
                cmbCategory.Text = radiostation.Category;
                txbPriceRepair.Text = radiostation.Price;
                if (txbPriceRepair.Text == "887.94" || txbPriceRepair.Text == "895.86" ||
                   txbPriceRepair.Text == "1267.49" || txbPriceRepair.Text == "2535.97" ||
                   txbPriceRepair.Text == "5071.94")
                    CheckBoxChoicePriceAnalogDigital.IsChecked = true;
                else CheckBoxChoicePriceAnalogDigital.IsChecked = false;
            }
            else
            {
                cmbCategory.Text = "6";
                CheckBoxChoicePriceAnalogDigital.IsChecked = true;
                txbPriceRepair.Text = "5071.94";
            }

            txbPrimaryMeans.Text = _workRepositoryRadiostantionFull.
                GetPrimaryMeansInDataBase(
                radiostation.SerialNumber, radiostation.City, radiostation.Road);

            txbProductName.Text = _workRepositoryRadiostantionFull.
                GetProductNameInDataBase(
                radiostation.SerialNumber, radiostation.City, radiostation.Road);

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
