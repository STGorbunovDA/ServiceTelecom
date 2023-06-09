using ServiceTelecom.Models;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class ChangeRadiostationForDocumentInDataBaseView : Window
    {
        public ChangeRadiostationForDocumentInDataBaseView(RadiostationForDocumentsDataBaseModel selectedRadiostationForDocumentsDataBaseModel)
        {
            InitializeComponent();
            txbNumberAct.Text = selectedRadiostationForDocumentsDataBaseModel.NumberAct;
            if (string.IsNullOrWhiteSpace(txbNumberAct.Text))
                foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                    txbNumberAct.Text = item.NumberPrintDocumentBase + "/";

            txtRoad.Text = selectedRadiostationForDocumentsDataBaseModel.Road;
            txbCity.Text = selectedRadiostationForDocumentsDataBaseModel.City;
            txbSerialNumber.Text = selectedRadiostationForDocumentsDataBaseModel.SerialNumber;
            txbRepresentative.Text = selectedRadiostationForDocumentsDataBaseModel.Representative;
            txbNumberIdentification.Text = selectedRadiostationForDocumentsDataBaseModel.NumberIdentification;
            txbPhoneNumber.Text = selectedRadiostationForDocumentsDataBaseModel.PhoneNumber;
            txbPost.Text = selectedRadiostationForDocumentsDataBaseModel.Post;
            datePickerDateOfIssuanceOfTheCertificate.Text = selectedRadiostationForDocumentsDataBaseModel.DateOfIssuanceOfTheCertificate;
            txbPoligon.Text = selectedRadiostationForDocumentsDataBaseModel.Poligon;
            txbCompany.Text = selectedRadiostationForDocumentsDataBaseModel.Company;
            txbLocation.Text = selectedRadiostationForDocumentsDataBaseModel.Location;
            cmbModel.Text = selectedRadiostationForDocumentsDataBaseModel.Model;
            txbInventoryNumber.Text = selectedRadiostationForDocumentsDataBaseModel.InventoryNumber;
            txbNetworkNumber.Text = selectedRadiostationForDocumentsDataBaseModel.NetworkNumber;
            datePickerDateMaintenance.Text = selectedRadiostationForDocumentsDataBaseModel.DateMaintenance;
            txbComment.Text = selectedRadiostationForDocumentsDataBaseModel.Comment;
            txbPrice.Text = selectedRadiostationForDocumentsDataBaseModel.Price;
            txbDecommissionNumberAct.Text = selectedRadiostationForDocumentsDataBaseModel.DecommissionNumberAct;

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

            
            if (selectedRadiostationForDocumentsDataBaseModel.Manipulator == "1")
                CheckBoxManipulator.IsChecked = true;
            if (selectedRadiostationForDocumentsDataBaseModel.Antenna == "1")
                CheckBoxAntenna.IsChecked = true;
            if (selectedRadiostationForDocumentsDataBaseModel.Charger == "1")
                CheckBoxCharger.IsChecked = true;
            txbBattery.Text = selectedRadiostationForDocumentsDataBaseModel.Battery;
            if (string.IsNullOrWhiteSpace(selectedRadiostationForDocumentsDataBaseModel.DecommissionNumberAct))
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
