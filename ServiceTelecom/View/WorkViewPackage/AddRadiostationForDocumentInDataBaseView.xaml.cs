﻿using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using System;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.View.WorkViewPackage
{
    public partial class AddRadiostationForDocumentInDataBaseView : Window
    {
        public AddRadiostationForDocumentInDataBaseView(string road)
        {
            InitializeComponent();
            datePickerDateMaintenance.Text = DateTime.Now.ToString("dd.MM.yyyy");
            datePickerDateOfIssuanceOfTheCertificate.Text = "Дата Выдачи";

            foreach (var item in GlobalCollection.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION)
            {
                if(road == item.RoadBase)
                {
                    txtRoad.Text = item.RoadBase;
                    txbNumberAct.Text = item.NumberPrintDocumentBase + "/";
                    break;
                }   
            }
            cmbModel.SelectedIndex = 0;
            txbLocation.Text = "ст. ";
        }
        public AddRadiostationForDocumentInDataBaseView(RadiostationForDocumentsDataBaseModel selectedRadiostationForDocumentsDataBaseModel)
        {
            InitializeComponent();
            txbNumberAct.Text = selectedRadiostationForDocumentsDataBaseModel.NumberAct;
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
            datePickerDateMaintenance.Text = DateTime.Now.ToString("dd.MM.yyyy");
            txbComment.Text = selectedRadiostationForDocumentsDataBaseModel.Comment;
            txbPrice.Text = selectedRadiostationForDocumentsDataBaseModel.Price;
            if (txbPrice.Text == GlobalValue.PRICE_ANALOG_TECHNICAL_SERVICES) 
                CheckBoxPrice.IsChecked = true;
            else
            {
                txbPrice.Text = GlobalValue.PRICE_DIGITAL_TECHNICAL_SERVICES;
                CheckBoxPrice.IsChecked = false;
            }
            if (selectedRadiostationForDocumentsDataBaseModel.Manipulator == "1")
                CheckBoxManipulator.IsChecked = true;
            if (selectedRadiostationForDocumentsDataBaseModel.Antenna == "1")
                CheckBoxAntenna.IsChecked = true;
            if (selectedRadiostationForDocumentsDataBaseModel.Charger == "1")
                CheckBoxCharger.IsChecked = true;
            txbBattery.Text = selectedRadiostationForDocumentsDataBaseModel.Battery;
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
