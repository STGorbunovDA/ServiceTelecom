using ServiceTelecom.Models;
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
    internal class ChangeRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;
        private WorkRepositoryRadiostantionFull _workRepositoryRadiostantionFull;

        AddModelRadiostantionView addModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        public ObservableCollection<ModelRadiostantionDataBaseModel>
            ModelCollections
        { get; set; }

        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            RadiostationForDocumentsCollection
        { get; set; }

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
                if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
                    if (value == true)
                        Price = UserModelStatic.priceAnalogTO;
                    else Price = UserModelStatic.priceDigitalTO;

                _сheckBoxPriceViewModel = value;
                OnPropertyChanged(nameof(CheckBoxPriceViewModel));
            }
        }

        private string Manipulator { get; set; }
        private string Antenna { get; set; }
        private string Charger { get; set; }
        private string Remont { get; set; }

        private string _decommissionNumberAct;
        public string DecommissionNumberAct
        {
            get => _decommissionNumberAct;
            set
            {
                _decommissionNumberAct = value;
                OnPropertyChanged(nameof(DecommissionNumberAct));
            }
        }

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

        public ICommand ChangeNumberActBySerialNumberInDataBase { get; }
        public ICommand AddModelDataBase { get; }
        public ICommand ChangeDecommissionNumberActBySerialNumberInDataBase { get; }
        public ICommand ChangeRadiostationForDocumentInDataBase { get; }
        public ICommand SearchBySerialNumberForFeaturesAdditionsFromTheDatabase { get; }
        public ICommand SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase { get; }
        public ICommand ChangeByNumberActRepresentativeForDocumentInDataBase { get; }
        public ICommand ChangeByCompanyRepresentativeForDocumentInDataBase { get; }

        public ChangeRadiostationForDocumentInDataBaseViewModel()
        {
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            _modelDataBase = new ModelDataBaseRepository();
            RadiostationForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            ChangeNumberActBySerialNumberInDataBase =
                new ViewModelCommand(ExecuteChangeNumberActBySerialNumberInDataBaseCommand);
            ChangeDecommissionNumberActBySerialNumberInDataBase =
                new ViewModelCommand(ExecuteChangeDecommissionNumberActBySerialNumberInDataBaseCommand);
            ChangeRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteChangeRadiostationForDocumentInDataBaseCommand);
            SearchBySerialNumberForFeaturesAdditionsFromTheDatabase =
                    new ViewModelCommand(ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDatabaseCommand);
            SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase =
                new ViewModelCommand(ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabaseCommand);
            ChangeByNumberActRepresentativeForDocumentInDataBase =
                new ViewModelCommand(ExecuteChangeByNumberActRepresentativeForDocumentInDataBaseCommand);
            ChangeByCompanyRepresentativeForDocumentInDataBase =
                new ViewModelCommand(ExecuteChangeByCompanyRepresentativeForDocumentInDataBaseCommand);
            GetModelDataBase();
        }


        #region ChangeByCompanyRepresentativeForDocumentInDataBase

        private void ExecuteChangeByCompanyRepresentativeForDocumentInDataBaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            #region проверка контролов Representative

            if (String.IsNullOrWhiteSpace(Company))
            {
                MessageBox.Show("Поле \"Предприятие\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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
            if (!Regex.IsMatch(NumberIdentification, @"^[V][\s]([0-9]{6,})$"))
            {
                if (MessageBox.Show("Поле \"№ Удостоверения\" " +
                    "введено некорректно желаете продолжить?", "Внимание",
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

            #endregion

            if (_workRepositoryRadiostantionFull.
                ChangeByCompanyRepresentativeForDocumentInDBRadiostantionFull(
                Road, City, Company, dateOfIssuanceOfTheCertificateDataBase,
                Representative, NumberIdentification, Post, PhoneNumber))
            { }
            else
                MessageBox.Show($"Ошибка изменения представителя " +
                    $"предприятия по текущему {Company} предприятию в radiostantionFull",
                    "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.
                ChangeByCompanyRepresentativeForDocumentInDataBase(
                Road, City, Company, dateOfIssuanceOfTheCertificateDataBase,
                Representative, NumberIdentification, Post, PhoneNumber))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка изменения представителя Предприятия " +
                    $"по текущему {Company} предприятию", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region ChangeByNumberActRepresentativeForDocumentInDataBase

        private void ExecuteChangeByNumberActRepresentativeForDocumentInDataBaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            #region проверка контролов Representative

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
            if (!Regex.IsMatch(NumberIdentification, @"^[V][\s]([0-9]{6,})$"))
            {
                if (MessageBox.Show("Поле \"№ Удостоверения\" введено " +
                    "некорректно желаете продолжить?", "Внимание",
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

            #endregion

            if (_workRepositoryRadiostantionFull.
                ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull(
                Road, City, NumberAct, dateOfIssuanceOfTheCertificateDataBase,
                Representative, NumberIdentification, Post, PhoneNumber))
            { }
            else
                MessageBox.Show($"Ошибка изменения представителя " +
                    $"Предприятия по данному № {NumberAct} акта " +
                    $"в radiostantionFull", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.
                ChangeByNumberActRepresentativeForDocumentInDataBase(
                Road, City, NumberAct, dateOfIssuanceOfTheCertificateDataBase,
                Representative, NumberIdentification, Post, PhoneNumber))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка изменения представителя Предприятия " +
                    $"по данному № {NumberAct} акта", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase

        private void ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabaseCommand(object obj)
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

        private void ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDatabaseCommand(object obj)
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


                    if (Price == UserModelStatic.priceAnalogTO)
                        CheckBoxPriceViewModel = true;
                    else CheckBoxPriceViewModel = false;

                    if (item.VerifiedRST == UserModelStatic.InRepairTechnicalServices)
                        CheckBoxRemontViewModel = true;
                    if (item.Manipulator == UserModelStatic.UnitMeasureForCheckBox)
                        CheckBoxManipulatorViewModel = true;
                    if (item.Antenna == UserModelStatic.UnitMeasureForCheckBox)
                        CheckBoxAntennaViewModel = true;
                    if (item.Charger == UserModelStatic.UnitMeasureForCheckBox)
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

        #region ChangeRadiostationForDocumentInDataBase

        private void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

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
            string dateMaintenanceDataBase = Convert.ToDateTime(DateMaintenance).ToString("yyyy-MM-dd");

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
            if (!Regex.IsMatch(NumberIdentification, @"^[V][\s]([0-9]{6,})$"))
            {
                if (MessageBox.Show("Поле \"№ Удостоверения\" введено некорректно. " +
                    "Желаете продолжить?", "Внимание",
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
                    "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
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
                if (MessageBox.Show("Поле \"Станция\" введено некорректно. " +
                    "Желаете продолжить?", "Внимание",
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
            if (Price == UserModelStatic.nullPriceTO)
            {
                MessageBox.Show("Цена ТО не может быть 0.0 рублей", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            #region проверка заводского номера по модели

            if (Model == "Motorola GP-340")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([6][7][2]([A-Z]{3,3}[0-9]{4,4}))?([6][7][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской №\"\n" +
                        "Пример: Motorola GP-340 - \"672TTD0000 или 672TTDE000\"",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola GP-360")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([7][4][9]([A-Z]{3,3}[0-9]{4,4}))?([7][4][9][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola GP-360 \"749TTD0000 или 749TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola DP-2400е" || Model == "Motorola DP-2400")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([4][4][6]([A-Z]{3,3}[0-9]{4,4}))?([4][4][6][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola DP-2400 - \"446TTD0000 или 446TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Comrade R5")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([2][0][1][0][R][5]([0-9]{6,6}))?([2][2][1][0][R][5][V][T]([0-9]{5,5}))*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Comrade R5 - \"2010R5107867\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Icom IC-F3GS")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[5][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F3GT")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F16")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][7]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Icom IC-F11")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[1][0]([0-9]{4,4})$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Альтавия-301М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Элодия-351М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Комбат T-44")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[T][4][4][.][0-9]{2,2}[.]+[0-9]{2,2}[.][0-9]{4,4}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено " +
                        $"некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Шеврон T-44 V2")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[T][4][4][.][0-9]{2,2}[.]+[0-9]{1,2}[.][0-9]{4,4}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РН311М")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[0-9]{1,20}((([\S][0-9])*$)?([\s][0-9]{2,2}[.]?[0-9]{2,2}?)*$)"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Motorola DP-4400")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([8][0][7]([A-Z]{3,3}[0-9]{4,4}))?([8][0][7][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola DP-4400 - \"807TTD0000 или 807TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola DP-1400")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([7][5][2]([A-Z]{3,3}[0-9]{4,4}))?([7][5][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola DP-1400 - \"752TTD0000 или 752TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola GP-320")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([6][3][8]([A-Z]{3,3}[0-9]{4,4}))?([6][3][8][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola GP-320 - \"000TTD0000 или 000TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola GP-300")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([1][7][4]([A-Z]{3,3}[0-9]{4,4}))?([1][7][4][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola GP-300 - \"174TTD0000 или 174TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola P080")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([4][2][2]([A-Z]{3,3}[0-9]{4,4}))?([4][2][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola P080 - \"452TTD0000 или 452TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Motorola P040")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^([4][2][2]([A-Z]{3,3}[0-9]{4,4}))?([4][2][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    MessageBox.Show("Введите корректно поле \"Заводской номер\"\n" +
                        "Пример: Motorola P040 - \"452TTD0000 или 452TTDE000\"", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else if (Model == "Гранит Р33П-1")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{5,5}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Гранит Р-43")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{6,6}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "Радий-301")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{6,6}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РНД-500")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[0-9]{1,}[[\s]?[0-9]{2,}[\.]?[0-9]{2,}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} " +
                        $"введено некорректно. Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                }
            }
            else if (Model == "РНД-512")
            {
                if (!Regex.IsMatch(SerialNumber, 
                    @"^[0-9]{1,}[[\s]?[0-9]{2,}[\.]?[0-9]{2,}$"))
                {
                    if (MessageBox.Show($"Поле \"Заводской номер\" для {Model} введено " +
                        $"некорректно. Желаете продолжить?", "Внимание",
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
                Manipulator = UserModelStatic.UnitMeasureForCheckBox;
            else Manipulator = "-";

            if (CheckBoxAntennaViewModel)
                Antenna = UserModelStatic.UnitMeasureForCheckBox;
            else Antenna = "-";

            if (CheckBoxChargerViewModel)
                Charger = UserModelStatic.UnitMeasureForCheckBox;
            else Charger = "-";

            if (CheckBoxRemontViewModel)
                Remont = UserModelStatic.InRepairTechnicalServices;
            else Remont = UserModelStatic.InWorkTechnicalServices;

            #endregion

            if (_workRepositoryRadiostantionFull.ChangeRadiostationFullForDocumentInDataBase(
                    Road, NumberAct, dateMaintenanceDataBase, Representative,
                    NumberIdentification, dateOfIssuanceOfTheCertificateDataBase,
                    PhoneNumber, Post, Comment, City, Location, Poligon, Company,
                    Model, SerialNumber, InventoryNumber, NetworkNumber, Price, Battery,
                    Manipulator, Antenna, Charger, Remont))
            { }
            else MessageBox.Show("Ошибка изменения радиостанции в radiostantionFull(БД)",
                "Отмена", MessageBoxButton.OK,
                MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.ChangeRadiostationForDocumentInDataBase(
                Road, NumberAct, dateMaintenanceDataBase, Representative,
                NumberIdentification, dateOfIssuanceOfTheCertificateDataBase,
                PhoneNumber, Post, Comment, City, Location, Poligon, Company,
                Model, SerialNumber, InventoryNumber, NetworkNumber, Price, Battery,
                Manipulator, Antenna, Charger, Remont))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения радиостанции", "Отмена",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region ChangeDecommissionNumberActBySerialNumberInDataBase

        private void ExecuteChangeDecommissionNumberActBySerialNumberInDataBaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show("Поле \"№ акта списания\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (!Regex.IsMatch(DecommissionNumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ акта списания\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_workRepositoryRadiostantionFull.
                ChangeDecommissionNumberActBySerialNumberInDBRadiostantionFull(
                Road, City, SerialNumber, DecommissionNumberAct))
            { }
            else
                MessageBox.Show("Ошибка изменения номера акта " +
                    "списания радиостанции в общей таблице(radiostantionFull)",
                    "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            if (_workRepositoryRadiostantion.
                ChangeDecommissionNumberActBySerialNumberInDBRadiostantion(
                Road, City, SerialNumber, DecommissionNumberAct))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта списания радиостанции",
                    "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
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

        #region ChangeNumberActBySerialNumberInDataBase

        private void ExecuteChangeNumberActBySerialNumberInDataBaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

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

            if (_workRepositoryRadiostantionFull.
                ChangeNumberActBySerialNumberInDBRadiostationFull(
                Road, City, SerialNumber, NumberAct))
            { }
            else
                MessageBox.Show("Ошибка изменения номера акта радиостанции " +
                    "в radiostantionFull(таблице)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.ChangeNumberActBySerialNumberInDatabase(
                Road, City, SerialNumber, NumberAct))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта радиостанции",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        private void GetModelDataBase()
        {
            TheIndexModelChoiceCollection = -1;
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = _modelDataBase.GetModelRadiostantionDataBase(ModelCollections);
            TheIndexModelChoiceCollection = ModelCollections.Count - 1;
        }
    }
}
