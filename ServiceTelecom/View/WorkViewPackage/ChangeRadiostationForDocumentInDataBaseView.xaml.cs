using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
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
                foreach (var item in GlobalCollection.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION)
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

            if(txbPrice.Text != GlobalValue.NULL_PRICE_TECHNICAL_SERVICES)
            {
                if (txbPrice.Text == GlobalValue.PRICE_ANALOG_TECHNICAL_SERVICES)
                    CheckBoxPrice.IsChecked = true;
                else
                {
                    CheckBoxPrice.IsChecked = false;
                    if (!string.IsNullOrWhiteSpace(txbDecommissionNumberAct.Text))
                        txbPrice.Text = GlobalValue.NULL_PRICE_TECHNICAL_SERVICES;
                    else txbPrice.Text = GlobalValue.PRICE_DIGITAL_TECHNICAL_SERVICES;
                }
            }
            
            if (selectedRadiostation.Manipulator == "1")
                CheckBoxManipulator.IsChecked = true;
            if (selectedRadiostation.Antenna == "1")
                CheckBoxAntenna.IsChecked = true;
            if (selectedRadiostation.Charger == "1")
                CheckBoxCharger.IsChecked = true;

            txbBattery.Text = selectedRadiostation.Battery;

            if (selectedRadiostation.VerifiedRST == GlobalValue.IN_REPAIR_TECHNICAL_SERVICES)
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
