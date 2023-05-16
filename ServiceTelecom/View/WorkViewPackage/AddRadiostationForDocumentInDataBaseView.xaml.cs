using System;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class AddRadiostationForDocumentInDataBaseView : Window
    {
        public AddRadiostationForDocumentInDataBaseView()
        {
            InitializeComponent();
            datePickerDateMaintenance.Text = DateTime.Now.ToString("dd.MM.yyyy");
            datePickerDateOfIssuanceOfTheCertificate.Text = "Дата Выдачи";
        }
        public AddRadiostationForDocumentInDataBaseView(string road, string city, 
            string serialNumber, string representative, string numberIdentification, 
            string phoneNumber, string post, string dateOfIssuanceOfTheCertificate, 
            string poligon, string company, string location, string model, 
            string inventoryNumber, string networkNumber, string dateMaintenance, 
            string comment, string price, string numberAct, string manipulator, 
            string antenna, string battery, string charger)
        {
            InitializeComponent();
            txtRoad.Text = road;
            txbCity.Text = city;
            txbSerialNumber.Text = serialNumber;
            txbRepresentative.Text = representative;
            txbNumberIdentification.Text = numberIdentification;
            txbPhoneNumber.Text = phoneNumber;
            txbPost.Text = post;
            datePickerDateOfIssuanceOfTheCertificate.Text = dateOfIssuanceOfTheCertificate;
            txbPoligon.Text = poligon;
            txbCompany.Text = company;
            txbLocation.Text = location;
            cmbModel.Text = model;
            txbInventoryNumber.Text = inventoryNumber;
            txbNetworkNumber.Text = networkNumber;
            datePickerDateMaintenance.Text = dateMaintenance;
            txbComment.Text = comment;
            txbPrice.Text = price;
            if (price == "1411.18")
            {
                CheckBoxAnalog.IsChecked = true;
                CheckBoxDigital.IsChecked = false;
            }
            else
            {
                CheckBoxAnalog.IsChecked = false;
                CheckBoxDigital.IsChecked = true;
            }
            txbNumberAct.Text = numberAct;
            if(manipulator == "1")
                CheckBoxManipulator.IsChecked = true;
            if(antenna == "1")
                CheckBoxAntenna.IsChecked = true;
            if(charger == "1")
                CheckBoxCharger.IsChecked = true;
            txbBattery.Text = battery;
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
