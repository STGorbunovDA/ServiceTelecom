using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;
using System;

namespace ServiceTelecom.Models
{
    public class RadiostationForDocumentsDataBaseModel : ViewModelBase
    {
        private int _id;
        private string _poligon;
        private string _company;
        private string _location;
        private string _model;
        private string _serialNumber;
        private string _inventoryNumber;
        private string _networkNumber;
        private string _dateMaintenance;
        private string _numberAct;
        private string _city;
        private string _price;
        private string _representative;
        private string _post;
        private string _numberIdentification;
        private string _dateOfIssuanceOfTheCertificate;
        private string _phoneNumber;
        private string _numberActRepair;
        private string _category;
        private string _priceRemont;
        private string _antenna;
        private string _manipulator;
        private string _battery;
        private string _сharger;
        private string _completedWorks_1;
        private string _completedWorks_2;
        private string _completedWorks_3;
        private string _completedWorks_4;
        private string _completedWorks_5;
        private string _completedWorks_6;
        private string _completedWorks_7;
        private string _parts_1;
        private string _parts_2;
        private string _parts_3;
        private string _parts_4;
        private string _parts_5;
        private string _parts_6;
        private string _parts_7;
        private string _decommissionNumber;
        private string _comment;
        private string _road;
        private string _verifiedRST;

        public RadiostationForDocumentsDataBaseModel(int idBase, string poligon, 
            string company, string location, string model, string serialNumber, 
            string inventoryNumber, string networkNumber, DateTime dateMaintenance, 
            string numberAct, string city, string price, string representative, 
            string post, string numberIdentification, DateTime dateOfIssuanceOfTheCertificate, 
            string phoneNumber, string numberActRepair, string category, string priceRemont, 
            string antenna, string manipulator, string battery, string charger, 
            string completedWorks_1, string completedWorks_2, string completedWorks_3, 
            string completedWorks_4, string completedWorks_5, string completedWorks_6, 
            string completedWorks_7, string parts_1, string parts_2, string parts_3, 
            string parts_4, string parts_5, string parts_6, string parts_7, 
            string decommissionNumber, string comment, string road, string verifiedRST)
        {
            IdBase = idBase;
            Poligon = Encryption.DecryptCipherTextToPlainText(poligon);
            Company = Encryption.DecryptCipherTextToPlainText(company);
            Location = Encryption.DecryptCipherTextToPlainText(location);
            Model = Encryption.DecryptCipherTextToPlainText(model);
            SerialNumber = Encryption.DecryptCipherTextToPlainText(serialNumber);
            InventoryNumber = Encryption.DecryptCipherTextToPlainText(inventoryNumber);
            NetworkNumber = Encryption.DecryptCipherTextToPlainText(networkNumber);
            DateMaintenance = dateMaintenance.ToString("dd.MM.yyyy");
            NumberAct = Encryption.DecryptCipherTextToPlainText(numberAct);
            City = Encryption.DecryptCipherTextToPlainText(city);
            Price = Encryption.DecryptCipherTextToPlainText(price);
            Representative = Encryption.DecryptCipherTextToPlainText(representative);
            Post = Encryption.DecryptCipherTextToPlainText(post);
            NumberIdentification = Encryption.DecryptCipherTextToPlainText(numberIdentification);
            DateOfIssuanceOfTheCertificate = dateOfIssuanceOfTheCertificate.ToString("dd.MM.yyyy");
            PhoneNumber = Encryption.DecryptCipherTextToPlainText(phoneNumber);
            NumberActRepair = Encryption.DecryptCipherTextToPlainText(numberActRepair);
            Category = Encryption.DecryptCipherTextToPlainText(category);
            PriceRemont = Encryption.DecryptCipherTextToPlainText(priceRemont);
            Antenna = Encryption.DecryptCipherTextToPlainText(antenna);
            Manipulator = Encryption.DecryptCipherTextToPlainText(manipulator);
            Battery = Encryption.DecryptCipherTextToPlainText(battery);
            Charger = Encryption.DecryptCipherTextToPlainText(charger);
            CompletedWorks_1 = Encryption.DecryptCipherTextToPlainText(completedWorks_1);
            CompletedWorks_2 = Encryption.DecryptCipherTextToPlainText(completedWorks_2);
            CompletedWorks_3 = Encryption.DecryptCipherTextToPlainText(completedWorks_3);
            CompletedWorks_4 = Encryption.DecryptCipherTextToPlainText(completedWorks_4);
            CompletedWorks_5 = Encryption.DecryptCipherTextToPlainText(completedWorks_5);
            CompletedWorks_6 = Encryption.DecryptCipherTextToPlainText(completedWorks_6);
            CompletedWorks_7 = Encryption.DecryptCipherTextToPlainText(completedWorks_7);
            Parts_1 = Encryption.DecryptCipherTextToPlainText(parts_1);
            Parts_2 = Encryption.DecryptCipherTextToPlainText(parts_2);
            Parts_3 = Encryption.DecryptCipherTextToPlainText(parts_3);
            Parts_4 = Encryption.DecryptCipherTextToPlainText(parts_4);
            Parts_5 = Encryption.DecryptCipherTextToPlainText(parts_5);
            Parts_6 = Encryption.DecryptCipherTextToPlainText(parts_6);
            Parts_7 = Encryption.DecryptCipherTextToPlainText(parts_7);
            DecommissionNumberAct = Encryption.DecryptCipherTextToPlainText(decommissionNumber);
            Comment = Encryption.DecryptCipherTextToPlainText(comment);
            Road = Encryption.DecryptCipherTextToPlainText(road);
            VerifiedRST = Encryption.DecryptCipherTextToPlainText(verifiedRST);
        }

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Poligon { get => _poligon; set { _poligon = value; OnPropertyChanged(nameof(Poligon)); } }
        public string Company { get => _company; set { _company = value; OnPropertyChanged(nameof(Company)); } }
        public string Location { get => _location; set { _location = value; OnPropertyChanged(nameof(Location)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }
        public string SerialNumber { get => _serialNumber; set { _serialNumber = value; OnPropertyChanged(nameof(SerialNumber)); } }
        public string InventoryNumber { get => _inventoryNumber; set { _inventoryNumber = value; OnPropertyChanged(nameof(InventoryNumber)); } }
        public string NetworkNumber { get => _networkNumber; set { _networkNumber = value; OnPropertyChanged(nameof(NetworkNumber)); } }
        public string DateMaintenance { get => _dateMaintenance; set { _dateMaintenance = value; OnPropertyChanged(nameof(DateMaintenance)); } }
        public string NumberAct { get => _numberAct; set { _numberAct = value; OnPropertyChanged(nameof(NumberAct)); } }
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }
        public string Price { get => _price; set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public string Representative { get => _representative; set { _representative = value; OnPropertyChanged(nameof(Representative)); } }
        public string Post { get => _post; set { _post = value; OnPropertyChanged(nameof(Post)); } }
        public string NumberIdentification { get => _numberIdentification; set { _numberIdentification = value; OnPropertyChanged(nameof(NumberIdentification)); } }
        public string DateOfIssuanceOfTheCertificate { get => _dateOfIssuanceOfTheCertificate; set { _dateOfIssuanceOfTheCertificate = value; OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate)); } }
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }
        public string NumberActRepair { get => _numberActRepair; set { _numberActRepair = value; OnPropertyChanged(nameof(NumberActRepair)); } }
        public string Category { get => _category; set { _category = value; OnPropertyChanged(nameof(Category)); } }
        public string PriceRemont { get => _priceRemont; set { _priceRemont = value; OnPropertyChanged(nameof(PriceRemont)); } }
        public string Antenna { get => _antenna; set { _antenna = value; OnPropertyChanged(nameof(Antenna)); } }
        public string Manipulator { get => _manipulator; set { _manipulator = value; OnPropertyChanged(nameof(Manipulator)); } }
        public string Battery { get => _battery; set { _battery = value; OnPropertyChanged(nameof(Battery)); } }
        public string Charger { get => _сharger; set { _сharger = value; OnPropertyChanged(nameof(Charger)); } }
        public string CompletedWorks_1 { get => _completedWorks_1; set { _completedWorks_1 = value; OnPropertyChanged(nameof(CompletedWorks_1)); } }
        public string CompletedWorks_2 { get => _completedWorks_2; set { _completedWorks_2 = value; OnPropertyChanged(nameof(CompletedWorks_2)); } }
        public string CompletedWorks_3 { get => _completedWorks_3; set { _completedWorks_3 = value; OnPropertyChanged(nameof(CompletedWorks_3)); } }
        public string CompletedWorks_4 { get => _completedWorks_4; set { _completedWorks_4 = value; OnPropertyChanged(nameof(CompletedWorks_4)); } }
        public string CompletedWorks_5 { get => _completedWorks_5; set { _completedWorks_5 = value; OnPropertyChanged(nameof(CompletedWorks_5)); } }
        public string CompletedWorks_6 { get => _completedWorks_6; set { _completedWorks_6 = value; OnPropertyChanged(nameof(CompletedWorks_6)); } }
        public string CompletedWorks_7 { get => _completedWorks_7; set { _completedWorks_7 = value; OnPropertyChanged(nameof(CompletedWorks_7)); } }
        public string Parts_1 { get => _parts_1; set { _parts_1 = value; OnPropertyChanged(nameof(Parts_1)); } }
        public string Parts_2 { get => _parts_2; set { _parts_2 = value; OnPropertyChanged(nameof(Parts_2)); } }
        public string Parts_3 { get => _parts_3; set { _parts_3 = value; OnPropertyChanged(nameof(Parts_3)); } }
        public string Parts_4 { get => _parts_4; set { _parts_4 = value; OnPropertyChanged(nameof(Parts_4)); } }
        public string Parts_5 { get => _parts_5; set { _parts_5 = value; OnPropertyChanged(nameof(Parts_5)); } }
        public string Parts_6 { get => _parts_6; set { _parts_6 = value; OnPropertyChanged(nameof(Parts_6)); } }
        public string Parts_7 { get => _parts_7; set { _parts_7 = value; OnPropertyChanged(nameof(Parts_7)); } }
        public string DecommissionNumberAct { get => _decommissionNumber; set { _decommissionNumber = value; OnPropertyChanged(nameof(DecommissionNumberAct)); } }
        public string Comment { get => _comment; set { _comment = value; OnPropertyChanged(nameof(Comment)); } }
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }
        public string VerifiedRST { get => _verifiedRST; set { _verifiedRST = value; OnPropertyChanged(nameof(VerifiedRST)); } }



    }
}
