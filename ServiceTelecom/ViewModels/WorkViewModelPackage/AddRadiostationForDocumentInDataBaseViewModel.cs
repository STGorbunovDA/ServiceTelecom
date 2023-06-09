﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {

        private WorkRadiostantionRepository _workRepositoryRadiostantion;
        private WorkRadiostantionFullRepository _workRepositoryRadiostantionFull;
        AddModelRadiostantionView addModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        public ObservableCollection<ModelRadiostantionDataBaseModel> 
            ModelCollections { get; set; }
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> 
            RadiostationForDocumentsCollection { get; set; }

        #region свойства

        private string _road;
        public string Road
        {
            get => _road;
            set
            {
                _road = value;
                OnPropertyChanged(nameof(Road));
            }
        }
        private string _numberAct;
        public string NumberAct
        {
            get => _numberAct;
            set
            {
                _numberAct = value;
                OnPropertyChanged(nameof(NumberAct));
            }
        }
        private string _dateMaintenance;
        public string DateMaintenance
        {
            get => _dateMaintenance;
            set
            {
                _dateMaintenance = value;
                OnPropertyChanged(nameof(DateMaintenance));
            }
        }
        private string _representative;
        public string Representative
        {
            get => _representative;
            set
            {
                _representative = value;
                OnPropertyChanged(nameof(Representative));
            }
        }
        private string _numberIdentification;
        public string NumberIdentification
        {
            get => _numberIdentification;
            set
            {
                _numberIdentification = value;
                OnPropertyChanged(nameof(NumberIdentification));
            }
        }
        private string _dateOfIssuanceOfTheCertificate;
        public string DateOfIssuanceOfTheCertificate
        {
            get => _dateOfIssuanceOfTheCertificate;
            set
            {
                _dateOfIssuanceOfTheCertificate = value;
                OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate));
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        private string _post;
        public string Post
        {
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged(nameof(Post));
            }
        }
        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
                if (value != null) Location = "ст. " +  value;
            }
        }
        private string _location;
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        private string _poligon;
        public string Poligon
        {
            get => _poligon;
            set
            {
                _poligon = value;
                OnPropertyChanged(nameof(Poligon));
            }
        }
        private string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        private string _serialNumber;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));

            }
        }
        private string _inventoryNumber;
        public string InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged(nameof(InventoryNumber));
            }
        }
        private string _networkNumber;
        public string NetworkNumber
        {
            get => _networkNumber;
            set
            {
                _networkNumber = value;
                OnPropertyChanged(nameof(NetworkNumber));
            }
        }

        private string _price;
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private bool _checkBoxRemontViewModel;
        public bool CheckBoxRemontViewModel
        {
            get => _checkBoxRemontViewModel;
            set
            {
                _checkBoxRemontViewModel = value;
                OnPropertyChanged(nameof(CheckBoxRemontViewModel));
            }
        }
        private string _battery;
        public string Battery
        {
            get => _battery;
            set
            {
                _battery = value;
                OnPropertyChanged(nameof(Battery));
            }
        }
        private bool _checkBoxManipulatorViewModel;
        public bool CheckBoxManipulatorViewModel
        {
            get => _checkBoxManipulatorViewModel;
            set
            {
                _checkBoxManipulatorViewModel = value;
                OnPropertyChanged(nameof(CheckBoxManipulatorViewModel));
            }
        }

        private bool _checkBoxAntennaViewModel;
        public bool CheckBoxAntennaViewModel
        {

            get => _checkBoxAntennaViewModel;
            set
            {
                _checkBoxAntennaViewModel = value;
                OnPropertyChanged(nameof(CheckBoxAntennaViewModel));
            }
        }

        private bool _checkBoxChargerViewModel;
        public bool CheckBoxChargerViewModel
        {
            get => _checkBoxChargerViewModel;
            set
            {
                _checkBoxChargerViewModel = value;
                OnPropertyChanged(nameof(CheckBoxChargerViewModel));
            }
        }


        private bool _сheckBoxPriceViewModel;
        public bool CheckBoxPriceViewModel
        {
            get => _сheckBoxPriceViewModel;
            set
            {
                if (value == true)
                    Price = UserModelStatic.PRICE_ANALOG_TECHNICAL_SERVICES;
                else Price = UserModelStatic.PRICE_DIGITAL_TECHNICAL_SERVICES;
                _сheckBoxPriceViewModel = value;
                OnPropertyChanged(nameof(CheckBoxPriceViewModel));
            }
        }

        private string Manipulator { get; set; }
        private string Antenna { get; set; }
        private string Charger { get; set; }
        private string Remont { get; set; }

        #endregion

        private int _theIndexModelChoiceCollection;
        public int TheIndexModelChoiceCollection
        {
            get => _theIndexModelChoiceCollection;
            set
            {
                _theIndexModelChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexModelChoiceCollection));
            }
        }
        public ICommand AddModelDataBase { get; }
        public ICommand AddRadiostationForDocumentInDataBase { get; }
        public ICommand SearchBySerialNumberForFeaturesAdditionsFromTheDatabase { get; }
        public ICommand SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase { get; }

        public AddRadiostationForDocumentInDataBaseViewModel()
        {
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            RadiostationForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            _modelDataBase = new ModelDataBaseRepository();
            _workRepositoryRadiostantion = new WorkRadiostantionRepository();
            _workRepositoryRadiostantionFull = new WorkRadiostantionFullRepository();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            AddRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddRadiostationForDocumentInDataBaseCommand);
            SearchBySerialNumberForFeaturesAdditionsFromTheDatabase =
                new ViewModelCommand(
                    ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDBCommand);
            SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase =
                new ViewModelCommand(
                    ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDBCommand);
            GetModelDataBase();
        }


        #region SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase

        private void ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDBCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(SerialNumber))
                return;
            if (RadiostationForDocumentsCollection.Count != 0)
                RadiostationForDocumentsCollection.Clear();

            RadiostationForDocumentsCollection =
            _workRepositoryRadiostantionFull.SearchBySerialNumberInDatabaseCharacteristics(
                Road, City, SerialNumber, RadiostationForDocumentsCollection);
            if (RadiostationForDocumentsCollection.Count != 0)
            {
                foreach (var item in RadiostationForDocumentsCollection)
                {
                    Representative = item.Representative;
                    NumberIdentification = item.NumberIdentification;
                    DateOfIssuanceOfTheCertificate = item.DateOfIssuanceOfTheCertificate;
                    PhoneNumber = item.PhoneNumber;
                    Post = item.Post;
                }
            }
        }

        #endregion

        #region SearchBySerialNumberForFeaturesAdditionsFromTheDatabase

        private void ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDBCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(SerialNumber))
                return;
            if (RadiostationForDocumentsCollection.Count != 0)
                RadiostationForDocumentsCollection.Clear();

            RadiostationForDocumentsCollection =
            _workRepositoryRadiostantionFull.SearchBySerialNumberInDatabaseCharacteristics(
                Road, City, SerialNumber, RadiostationForDocumentsCollection);

            if (RadiostationForDocumentsCollection.Count != 0)
            {
                foreach (var item in RadiostationForDocumentsCollection)
                {
                    InventoryNumber = item.InventoryNumber;
                    NetworkNumber = item.NetworkNumber;
                    City = item.City;
                    Location = item.Location;
                    Poligon = item.Poligon;
                    Company = item.Company;
                    Model = item.Model;
                    Comment = item.Comment;
                    Battery = item.Battery;
                    Price = item.Price;

                    if (Price == UserModelStatic.PRICE_ANALOG_TECHNICAL_SERVICES)
                        CheckBoxPriceViewModel = true;
                    else CheckBoxPriceViewModel = false;
                    if (item.VerifiedRST == UserModelStatic.IN_REPAIR_TECHNICAL_SERVICES)
                        CheckBoxRemontViewModel = true;
                    if (item.Manipulator == UserModelStatic.UNIT_MEASURE_FOR_CHECKBOX)
                        CheckBoxManipulatorViewModel = true;
                    if (item.Antenna == UserModelStatic.UNIT_MEASURE_FOR_CHECKBOX)
                        CheckBoxAntennaViewModel = true;
                    if (item.Charger == UserModelStatic.UNIT_MEASURE_FOR_CHECKBOX)
                        CheckBoxChargerViewModel = true;
                }
            }
            else
            {
                InventoryNumber = String.Empty;
                NetworkNumber = String.Empty;
                Comment = String.Empty;
                Battery = String.Empty;
                CheckBoxRemontViewModel = false;
                CheckBoxManipulatorViewModel = false;
                CheckBoxAntennaViewModel = false;
                CheckBoxChargerViewModel = false;
            }
        }

        #endregion

        #region AddRadiostationForDocumentInDataBase

        private void ExecuteAddRadiostationForDocumentInDataBaseCommand(object obj)
        {
            #region Проверка ввода контролов

            if (String.IsNullOrWhiteSpace(NumberAct))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberAct, 
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(DateMaintenance))
            {
                MessageBox.Show("Поле \"Дата ТО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DateMaintenance, 
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string dateMaintenanceDataBase = 
                Convert.ToDateTime(DateMaintenance).ToString("yyyy-MM-dd");

            if (!Regex.IsMatch(DateOfIssuanceOfTheCertificate, 
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string dateOfIssuanceOfTheCertificateDataBase = 
                Convert.ToDateTime(DateOfIssuanceOfTheCertificate).ToString("yyyy-MM-dd");

            if (String.IsNullOrWhiteSpace(Representative))
            {
                MessageBox.Show("Поле \"Представитель ФИО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Representative.Contains("-"))
            {
                if (!Regex.IsMatch(Representative, 
                    @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Представитель ФИО\" " +
                        "пример Иванов И.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (Representative.Contains("-"))
            {
                if (!Regex.IsMatch(Representative, 
                    @"^[А-ЯЁ][а-яё]*(([\-][А-Я][а-яё]*[\s]+[А-Я]+[\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Представитель ФИО\" " +
                        "пример Иванова-Сидорова Я.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (String.IsNullOrWhiteSpace(NumberIdentification))
            {
                MessageBox.Show("Поле \"№ Удостоверения\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberIdentification, 
                @"^[V][\s]([0-9]{6,})$"))
            {
                if (MessageBox.Show("Поле \"№ Удостоверения\" введено " +
                    "некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (String.IsNullOrWhiteSpace(Post))
            {
                MessageBox.Show("Поле \"Должность\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Regex re = new Regex(Environment.NewLine);
            Post = re.Replace(Post, " ");
            Post.Trim();

            if (!String.IsNullOrWhiteSpace(Comment))
            {
                Regex re2 = new Regex(Environment.NewLine);
                Comment = re2.Replace(Comment, " ");
                Comment.Trim();
            }
            if (String.IsNullOrWhiteSpace(City))
            {
                MessageBox.Show("Поле \"Город\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(City, @"^[А-Я][а-я]*(?:[\s-][А-Я][а-я]*)*$"))
            {
                if (MessageBox.Show("Поле \"Город\" введено некорректно. " +
                    "Желаете продолжить?", "Внимание", MessageBoxButton.YesNo, 
                    MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (String.IsNullOrWhiteSpace(Location))
            {
                MessageBox.Show("Поле \"Станция\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(Location, 
                @"^[с][т][.][\s][А-Я][а-я]*(([\s-]?[0-9])*$)?([\s-]?[А-Я][а-я]*)*$"))
            {
                if (MessageBox.Show("Поле \"Станция\" введено некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (String.IsNullOrWhiteSpace(Poligon))
            {
                MessageBox.Show("Поле \"Полигон\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(Poligon, @"^[Р][Ц][С][-][1-9]{1,1}$"))
            {
                MessageBox.Show("Поле \"Полигон\" введено некорректно. " +
                    "Пример от РЦС-1 до РЦС-9", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Company))
            {
                MessageBox.Show("Поле \"Предприятие\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(SerialNumber))
            {
                MessageBox.Show("Поле \"Заводской №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            #region проверка заводского номера по модели

            if (Model == "Motorola GP-340")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([6][7][2]([A-Z]{3,3}[0-9]{4,4}))?([6][7][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {

                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola GP-360")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([7][4][9]([A-Z]{3,3}[0-9]{4,4}))?([7][4][9][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                         "Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola DP-2400е" || Model == "Motorola DP-2400")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([4][4][6]([A-Z]{3,3}[0-9]{4,4}))?([4][4][6][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Comrade R5")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([2][0][1][0][R][5]([0-9]{6,6}))?([2][2][1][0][R][5][V][T]([0-9]{5,5}))*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F3GS")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[5][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F3GT")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F16")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][7]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F11")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[1][0]([0-9]{4,4})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Альтавия-301М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Элодия-351М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Комбат T-44")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[T][4][4][.][0-9]{2,2}[.]+[0-9]{2,2}[.][0-9]{4,4}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Шеврон T-44 V2")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[T][4][4][.][0-9]{2,2}[.]+[0-9]{1,2}[.][0-9]{4,4}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                         "Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РН311М")
            {
                if (!Regex.IsMatch(SerialNumber,
                    @"^[0-9]{1,20}((([\S][0-9])*$)?([\s][0-9]{2,2}[.]?[0-9]{2,2}?)*$)"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola DP-4400")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([8][0][7]([A-Z]{3,3}[0-9]{4,4}))?([8][0][7][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola DP-1400")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([7][5][2]([A-Z]{3,3}[0-9]{4,4}))?([7][5][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola GP-320")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([6][3][8]([A-Z]{3,3}[0-9]{4,4}))?([6][3][8][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola GP-300")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([1][7][4]([A-Z]{3,3}[0-9]{4,4}))?([1][7][4][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                         "Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola P080")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([4][2][2]([A-Z]{3,3}[0-9]{4,4}))?([4][2][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola P040")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([4][2][2]([A-Z]{3,3}[0-9]{4,4}))?([4][2][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Гранит Р33П-1")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{5,5}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Гранит Р-43")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[0-9]{2,2}[\s][0-9]{6,6}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Радий-301")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{6,6}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РНД-500")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[0-9]{1,}[[\s]?[0-9]{2,}[\.]?[0-9]{2,}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РНД-512")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[0-9]{1,}[[\s]?[0-9]{2,}[\.]?[0-9]{2,}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }

            #endregion

            if (String.IsNullOrWhiteSpace(InventoryNumber))
            {
                MessageBox.Show("Поле \"Инвентарный №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (String.IsNullOrWhiteSpace(NetworkNumber))
            {
                MessageBox.Show("Поле \"Инвентарный №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (String.IsNullOrWhiteSpace(Price))
            {
                MessageBox.Show("Поле \"Прайс\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (CheckBoxManipulatorViewModel)
                Manipulator = UserModelStatic.UNIT_MEASURE_FOR_CHECKBOX;
            else Manipulator = "-";

            if (CheckBoxAntennaViewModel)
                Antenna = UserModelStatic.UNIT_MEASURE_FOR_CHECKBOX;
            else Antenna = "-";

            if (CheckBoxChargerViewModel)
                Charger = UserModelStatic.UNIT_MEASURE_FOR_CHECKBOX;
            else Charger = "-";

            if (CheckBoxRemontViewModel)
                Remont = UserModelStatic.IN_REPAIR_TECHNICAL_SERVICES;
            else Remont = UserModelStatic.IN_WORK_TECHNICAL_SERVICES;  
            
            #endregion

            if (_workRepositoryRadiostantion.
                CheckSerialNumberForDocumentInDataBaseRadiostantion(
                Road, SerialNumber))
            {
                if (MessageBox.Show($"Номер: \"{SerialNumber}\" " +
                    $"присутсвует в Базе Данных. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return;
            }
            if (_workRepositoryRadiostantion.CheckNumberActOverTwentyForDocumentInDataBase(
                Road, City, NumberAct))
            {
                MessageBox.Show($"В акте: \"{NumberAct}\" более 20 радиостанций. " +
                    $"Создайте другой номер акта","Отмена", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!_workRepositoryRadiostantionFull.
                CheckSerialNumberForDocumentInDataBaseRadiostantionFull(
                Road, SerialNumber))
            {
                if (_workRepositoryRadiostantionFull.AddRadiostationFullForDocumentInDataBase(
                    Road, NumberAct, dateMaintenanceDataBase, Representative, 
                    NumberIdentification, dateOfIssuanceOfTheCertificateDataBase, 
                    PhoneNumber, Post, Comment, City, Location, Poligon, Company, 
                    Model, SerialNumber, InventoryNumber, NetworkNumber, Price, Battery, 
                    Manipulator, Antenna, Charger, Remont))
                { }
                else MessageBox.Show("Ошибка добавления радиостанции " +
                    "в radiostantionFull(БД)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                if (_workRepositoryRadiostantionFull.
                    ChangeRadiostationFullForDocumentInDataBase(
                    Road, NumberAct, dateMaintenanceDataBase, Representative, 
                    NumberIdentification, dateOfIssuanceOfTheCertificateDataBase, 
                    PhoneNumber, Post, Comment, City, Location, Poligon, Company, 
                    Model, SerialNumber, InventoryNumber, NetworkNumber, Price, Battery, 
                    Manipulator, Antenna, Charger, Remont))
                { }
                else MessageBox.Show("Ошибка изменения радиостанции " +
                    "в radiostantionFull(БД)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            if (_workRepositoryRadiostantion.AddRadiostationForDocumentInDataBase(
                Road, NumberAct,dateMaintenanceDataBase, Representative, 
                NumberIdentification,dateOfIssuanceOfTheCertificateDataBase, 
                PhoneNumber, Post, Comment, City, Location, Poligon, Company, 
                Model, SerialNumber, InventoryNumber, NetworkNumber, Price, 
                Battery, Manipulator, Antenna, Charger, Remont))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка добавления радиостанции", "Отмена", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region AddModelDataBase

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) => 
                addModelRadiostantion = null;
                addModelRadiostantion.Closed += (sender, args) => 
                GetModelDataBase();
                addModelRadiostantion.Show();
            }
        }

        #endregion

        #region GetModelDataBase

        private void GetModelDataBase()
        {
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = _modelDataBase.GetModelRadiostantionDataBase(
                ModelCollections);
        }

        #endregion
    }
}
