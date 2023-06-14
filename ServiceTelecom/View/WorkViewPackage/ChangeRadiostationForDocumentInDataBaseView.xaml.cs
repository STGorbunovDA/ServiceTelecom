using ServiceTelecom.Models;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class ChangeRadiostationForDocumentInDataBaseView : Window
    {
        public ChangeRadiostationForDocumentInDataBaseView(RadiostationForDocumentsDataBaseModel selectedRadiostation)
        {
            InitializeComponent();
            txbNumberAct.Text = selectedRadiostation.NumberAct;
            if (string.IsNullOrWhiteSpace(txbNumberAct.Text))
                foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                    txbNumberAct.Text = item.NumberPrintDocumentBase + "/";

            txtRoad.Text = selectedRadiostation.Road;
            txbCity.Text = selectedRadiostation.City;
            txbSerialNumber.Text = selectedRadiostation.SerialNumber;
            txbRepresentative.Text = selectedRadiostation.Representative;
            txbNumberIdentification.Text = selectedRadiostation.NumberIdentification;
            txbPhoneNumber.Text = selectedRadiostation.PhoneNumber;
            txbPost.Text = selectedRadiostation.Post;
            datePickerDateOfIssuanceOfTheCertificate.Text = selectedRadiostation.DateOfIssuanceOfTheCertificate;
            txbPoligon.Text = selectedRadiostation.Poligon;
            txbCompany.Text = selectedRadiostation.Company;
            txbLocation.Text = selectedRadiostation.Location;
            cmbModel.Text = selectedRadiostation.Model;
            txbInventoryNumber.Text = selectedRadiostation.InventoryNumber;
            txbNetworkNumber.Text = selectedRadiostation.NetworkNumber;
            datePickerDateMaintenance.Text = selectedRadiostation.DateMaintenance;
            txbComment.Text = selectedRadiostation.Comment;
            txbPrice.Text = selectedRadiostation.Price;
            txbDecommissionNumberAct.Text = selectedRadiostation.DecommissionNumberAct;

            if(txbPrice.Text != UserModelStatic.nullPriceTO)
            {
                if (txbPrice.Text == UserModelStatic.priceAnalogTO)
                    CheckBoxPrice.IsChecked = true;
                else
                {
                    CheckBoxPrice.IsChecked = false;
                    if (!string.IsNullOrWhiteSpace(txbDecommissionNumberAct.Text))
                        txbPrice.Text = UserModelStatic.nullPriceTO;
                    else txbPrice.Text = UserModelStatic.priceDigitalTO;
                }
            }
            
            if (selectedRadiostation.Manipulator == "1")
                CheckBoxManipulator.IsChecked = true;
            if (selectedRadiostation.Antenna == "1")
                CheckBoxAntenna.IsChecked = true;
            if (selectedRadiostation.Charger == "1")
                CheckBoxCharger.IsChecked = true;

            txbBattery.Text = selectedRadiostation.Battery;

            if (selectedRadiostation.VerifiedRST == UserModelStatic.InRepairTechnicalServices)
                CheckBoxRemont.IsChecked = true;

            if (string.IsNullOrWhiteSpace(selectedRadiostation.DecommissionNumberAct))
                txbDecommissionNumberAct.IsReadOnly = true;
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
    }
}
