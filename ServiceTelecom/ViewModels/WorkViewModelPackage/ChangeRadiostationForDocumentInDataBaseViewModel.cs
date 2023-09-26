using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class ChangeRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        WorkRadiostantionRepository _workRadiostantionRepository;
        WorkRadiostantionFullRepository _workRadiostantionFullRepository;
        RadiostationParametersRepository _radiostationParametersRepository;

        AddModelRadiostantionView addModelRadiostantion = null;
        ModelDataBaseRepository _modelDataBaseRepository;

        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelsCollection { get; set; }
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }

        #region свойства

        string _road;
        public string Road
        {
            get => _road;
            set
            {
                _road = value;
                OnPropertyChanged(nameof(Road));
            }
        }
        string _numberAct;
        public string NumberAct
        {
            get => _numberAct;
            set
            {
                _numberAct = value;
                OnPropertyChanged(nameof(NumberAct));
            }
        }
        string _dateMaintenance;
        public string DateMaintenance
        {
            get => _dateMaintenance;
            set
            {
                _dateMaintenance = value;
                OnPropertyChanged(nameof(DateMaintenance));
            }
        }
        string _representative;
        public string Representative
        {
            get => _representative;
            set
            {
                _representative = value;
                OnPropertyChanged(nameof(Representative));
            }
        }
        string _numberIdentification;
        public string NumberIdentification
        {
            get => _numberIdentification;
            set
            {
                _numberIdentification = value;
                OnPropertyChanged(nameof(NumberIdentification));
            }
        }
        string _dateOfIssuanceOfTheCertificate;
        public string DateOfIssuanceOfTheCertificate
        {
            get => _dateOfIssuanceOfTheCertificate;
            set
            {
                _dateOfIssuanceOfTheCertificate = value;
                OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate));
            }
        }
        string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        string _post;
        public string Post
        {
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged(nameof(Post));
            }
        }
        string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }
        string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
                if (value != null) Location = "ст. " + value;
            }
        }
        string _location;
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }
        string _poligon;
        public string Poligon
        {
            get => _poligon;
            set
            {
                _poligon = value;
                OnPropertyChanged(nameof(Poligon));
            }
        }
        string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
        string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        string _serialNumber;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        string _inventoryNumber;
        public string InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged(nameof(InventoryNumber));
            }
        }
        string _networkNumber;
        public string NetworkNumber
        {
            get => _networkNumber;
            set
            {
                _networkNumber = value;
                OnPropertyChanged(nameof(NetworkNumber));
            }
        }
        string _price;
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        bool _checkBoxRemontViewModel;
        public bool CheckBoxRemontViewModel
        {
            get => _checkBoxRemontViewModel;
            set
            {
                _checkBoxRemontViewModel = value;
                OnPropertyChanged(nameof(CheckBoxRemontViewModel));
            }
        }
        string _battery;
        public string Battery
        {
            get => _battery;
            set
            {
                _battery = value;
                OnPropertyChanged(nameof(Battery));
            }
        }
        bool _checkBoxManipulatorViewModel;
        public bool CheckBoxManipulatorViewModel
        {
            get => _checkBoxManipulatorViewModel;
            set
            {
                _checkBoxManipulatorViewModel = value;
                OnPropertyChanged(nameof(CheckBoxManipulatorViewModel));
            }
        }
        bool _checkBoxAntennaViewModel;
        public bool CheckBoxAntennaViewModel
        {

            get => _checkBoxAntennaViewModel;
            set
            {
                _checkBoxAntennaViewModel = value;
                OnPropertyChanged(nameof(CheckBoxAntennaViewModel));
            }
        }
        bool _checkBoxChargerViewModel;
        public bool CheckBoxChargerViewModel
        {
            get => _checkBoxChargerViewModel;
            set
            {
                _checkBoxChargerViewModel = value;
                OnPropertyChanged(nameof(CheckBoxChargerViewModel));
            }
        }
        bool _сheckBoxPriceViewModel;
        public bool CheckBoxPriceViewModel
        {
            get => _сheckBoxPriceViewModel;
            set
            {
                if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
                    if (value)
                        Price = UserModelStatic.PRICE_ANALOG_TECHNICAL_SERVICES;
                    else Price = UserModelStatic.PRICE_DIGITAL_TECHNICAL_SERVICES;

                _сheckBoxPriceViewModel = value;
                OnPropertyChanged(nameof(CheckBoxPriceViewModel));
            }
        }

        string Manipulator { get; set; }
        string Antenna { get; set; }
        string Charger { get; set; }
        string Remont { get; set; }

        string _decommissionNumberAct;
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

        int _theIndexModelChoiceCollection;
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
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _workRadiostantionFullRepository = new WorkRadiostantionFullRepository();
            _radiostationParametersRepository = new RadiostationParametersRepository();
            _modelDataBaseRepository = new ModelDataBaseRepository();
            RadiostationsForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            ModelsCollection = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            ChangeNumberActBySerialNumberInDataBase =
                new ViewModelCommand(ExecuteChangeNumberActBySerialNumberInDataBaseCommand);
            ChangeDecommissionNumberActBySerialNumberInDataBase =
                new ViewModelCommand(
                    ExecuteChangeDecommissionNumberActBySerialNumberInDataBaseCommand);
            ChangeRadiostationForDocumentInDataBase =
                new ViewModelCommand(
                    ExecuteChangeRadiostationForDocumentInDataBaseCommand);
            SearchBySerialNumberForFeaturesAdditionsFromTheDatabase =
                    new ViewModelCommand(
                        ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDatabaseCommand);
            SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDatabase =
                new ViewModelCommand(
                    ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDBCommand);
            ChangeByNumberActRepresentativeForDocumentInDataBase =
                new ViewModelCommand(
                    ExecuteChangeByNumberActRepresentativeForDocumentInDataBaseCommand);
            ChangeByCompanyRepresentativeForDocumentInDataBase =
                new ViewModelCommand(
                    ExecuteChangeByCompanyRepresentativeForDocumentInDataBaseCommand);
            GetModelDataBase();
        }

        #region CheckValue

        bool CheckDecommissionNumberAct()
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool CheckEmployeeIdCardIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(Representative))
            {
                MessageBox.Show("Поле \"Представитель ФИО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(NumberIdentification))
            {
                MessageBox.Show("Поле \"№ Удостоверения\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(Post))
            {
                MessageBox.Show("Поле \"Должность\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(DateOfIssuanceOfTheCertificate))
            {
                MessageBox.Show("Поле \"Дата выдачи удостоверения\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool CheckEmployeeIdCardRegex()
        {
            if (!Regex.IsMatch(DateOfIssuanceOfTheCertificate,
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (!Representative.Contains("-"))
            {
                if (!Regex.IsMatch(Representative,
                    @"^[А-ЯЁ][а-яё]*(([\s]+[А-Я][\.]+[А-Я]+[\.])$)"))
                {
                    MessageBox.Show("Введите корректно поле \"Представитель ФИО\" " +
                        "пример Иванов И.И.", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
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
                    return false;
                }
            }
            if (!Regex.IsMatch(NumberIdentification, @"^[V][\s]([0-9]{6,})$"))
            {
                if (MessageBox.Show("Поле \"№ Удостоверения\" " +
                    "введено некорректно желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }

            StringBuilder sb = new StringBuilder(Post.Trim());
            sb.Replace(Environment.NewLine, " ");
            Post = sb.ToString();

            return true;
        }
        bool СheckIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(NumberAct))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(DateMaintenance))
            {
                MessageBox.Show("Поле \"Дата ТО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(City))
            {
                MessageBox.Show("Поле \"Город\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(Location))
            {
                MessageBox.Show("Поле \"Станция\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(Poligon))
            {
                MessageBox.Show("Поле \"Полигон\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(Company))
            {
                MessageBox.Show("Поле \"Предприятие\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(Price))
            {
                MessageBox.Show("Поле \"Цена ТО\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(InventoryNumber))
            {
                MessageBox.Show("Поле \"Инвентарный №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(NetworkNumber))
            {
                MessageBox.Show("Поле \"Сетевой №\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (Price == UserModelStatic.NULL_PRICE_TECHNICAL_SERVICES)
            {
                MessageBox.Show("Цена ТО не может быть 0.0 рублей", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool СheckRegexValue()
        {
            if (!Regex.IsMatch(NumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (!Regex.IsMatch(DateMaintenance,
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (!String.IsNullOrWhiteSpace(Comment))
            {
                StringBuilder sb2 = new StringBuilder(Comment.Trim());
                sb2.Replace(Environment.NewLine, " ");
                Comment = sb2.ToString();
            }
            if (!Regex.IsMatch(City, @"^[А-Я][а-я]*(?:[\s-][А-Я][а-я]*)*$"))
            {
                if (MessageBox.Show("Поле \"Город\" введено некорректно. " +
                    "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(Location,
                @"^[с][т][.][\s][А-Я][а-я]*(([\s-]?[0-9])*$)?([\s-]?[А-Я][а-я]*)*$"))
            {
                if (MessageBox.Show("Поле \"Станция\" введено некорректно. " +
                    "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    return false;
            }
            if (!Regex.IsMatch(Poligon, @"^[Р][Ц][С][-][1-9]{1,1}$"))
            {
                MessageBox.Show("Поле \"Полигон\" введено некорректно. " +
                    "Пример от РЦС-1 до РЦС-9", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool CheckRegexSerialNumberModel()
        {
            if (Model == "Motorola GP-340")
            {
                if (!Regex.IsMatch(SerialNumber,
                    @"^([6][7][2]([A-Z]{3,3}[0-9]{4,4}))?([6][7][2][A-Z]{4,4}[0-9]{3,3})*$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                         "Желаете продолжить?", "Внимание",
                      MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
                }
            }
            else if (Model == "Icom IC-F3GS")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[5][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Icom IC-F3GT")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][4]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Icom IC-F16")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0][7]([0-9]{5,5})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Icom IC-F11")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[1][0]([0-9]{4,4})$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Альтавия-301М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Элодия-351М")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{9,9}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
                }
            }
            else if (Model == "Гранит Р33П-1")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{5,5}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Гранит Р-43")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{2,2}[\s][0-9]{6,6}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
                }
            }
            else if (Model == "Радий-301")
            {
                if (!Regex.IsMatch(SerialNumber, @"^[0-9]{6,6}$"))
                {
                    if (MessageBox.Show("Поле \"Зав №.\" введено некорректно. " +
                        "Желаете продолжить?", "Внимание",
                     MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return false;
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
                        return false;
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
                        return false;
                }
            }
            return true;
        }
        void SettingValuesRadioStationConsumables()
        {
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
        }
        bool CheckDecommissionNumberActIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show("Поле \"№ акта списания\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool CheckDecommissionNumberActRegex()
        {
            if (!Regex.IsMatch(DecommissionNumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ акта списания\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool CheckNumberActIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(NumberAct))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }
        bool CheckNumberActRegex()
        {
            if (!Regex.IsMatch(NumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        #endregion

        #region ChangeByCompanyRepresentativeForDocumentInDataBase

        void ExecuteChangeByCompanyRepresentativeForDocumentInDataBaseCommand(object obj)
        {
            if (!CheckDecommissionNumberAct())
                return;

            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (!CheckEmployeeIdCardIsNullOrWhiteSpace())
                return;

            if(!CheckEmployeeIdCardRegex())
                return;

            if (_workRadiostantionFullRepository.ChangeByCompanyRepresentativeForDocumentInDBRadiostantionFull(
                Road, City, Company, DateOfIssuanceOfTheCertificate,
                Representative, NumberIdentification, Post, PhoneNumber)){ }
            else MessageBox.Show($"Ошибка изменения представителя " +
                    $"предприятия по текущему {Company} предприятию в radiostantionFull","Отмена", 
                    MessageBoxButton.OK, MessageBoxImage.Error);

            if (_workRadiostantionRepository.ChangeByCompanyRepresentativeForDocumentInDataBase(
                Road, City, Company, DateOfIssuanceOfTheCertificate,
                Representative, NumberIdentification, Post, PhoneNumber))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка изменения представителя Предприятия " +
                    $"по текущему {Company} предприятию", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region ChangeByNumberActRepresentativeForDocumentInDataBase

        void ExecuteChangeByNumberActRepresentativeForDocumentInDataBaseCommand(object obj)
        {
            if (!CheckDecommissionNumberAct())
                return;

            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            // Условия вынесено отдельно для понимания вызванных методов проверки удостоверения
            if (String.IsNullOrWhiteSpace(Company))
            {
                MessageBox.Show("Поле \"Предприятие\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!CheckEmployeeIdCardIsNullOrWhiteSpace())
                return;

            if (!CheckEmployeeIdCardRegex())
                return;

            if (_workRadiostantionFullRepository.ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull(
                Road, City, NumberAct, DateOfIssuanceOfTheCertificate,
                Representative, NumberIdentification, Post, PhoneNumber)) { }
            else MessageBox.Show($"Ошибка изменения представителя " +
                    $"Предприятия по данному № {NumberAct} акта " +
                    $"в radiostantionFull", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRadiostantionRepository.ChangeByNumberActRepresentativeForDocumentInDataBase(
                Road, City, NumberAct, DateOfIssuanceOfTheCertificate,
                Representative, NumberIdentification, Post, PhoneNumber))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка изменения представителя Предприятия " +
                    $"по данному № {NumberAct} акта", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region SearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDB

        void ExecuteSearchBySerialNumberForFeaturesAdditionsRepresentativeFromTheDBCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(SerialNumber))
                return;

            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();

            RadiostationsForDocumentsCollection =
            _workRadiostantionFullRepository.SearchBySerialNumberInDatabaseCharacteristics(
                Road, SerialNumber, RadiostationsForDocumentsCollection);
            if (RadiostationsForDocumentsCollection.Count != 0)
            {
                foreach (var item in RadiostationsForDocumentsCollection)
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

        void ExecuteSearchBySerialNumberForFeaturesAdditionsFromTheDatabaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(SerialNumber))
                return;

            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();

            RadiostationsForDocumentsCollection =
            _workRadiostantionFullRepository.SearchBySerialNumberInDatabaseCharacteristics(
                Road, SerialNumber, RadiostationsForDocumentsCollection);

            if (RadiostationsForDocumentsCollection.Count != 0)
            {
                foreach (var item in RadiostationsForDocumentsCollection)
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

        #region ChangeRadiostationForDocumentInDataBase

        void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (!CheckDecommissionNumberAct())
                return;

            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (!CheckEmployeeIdCardIsNullOrWhiteSpace())
                return;
            if (!CheckEmployeeIdCardRegex())
                return;
            if (!СheckIsNullOrWhiteSpace())
                return;
            if (!СheckRegexValue())
                return;
            if (!CheckRegexSerialNumberModel())
                return;

            SettingValuesRadioStationConsumables();

            if (_radiostationParametersRepository. CheckSerialNumberInRadiostationParameters(Road, SerialNumber))
            {
                if (!_radiostationParametersRepository.ChangeСharacteristicsRadiostantionForRadiostationParameters
                    (Road, City, Company, Location, NumberAct, Model, Comment, Battery, SerialNumber))
                    MessageBox.Show("Ошибка изменения юридических параметров радиостанции " +
                        "в radiostation_parameters(таблица)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            if (_workRadiostantionFullRepository.ChangeRadiostationFullForDocumentInDataBase(
                    Road, NumberAct, DateMaintenance, Representative,
                    NumberIdentification, DateOfIssuanceOfTheCertificate,
                    PhoneNumber, Post, Comment, City, Location, Poligon, Company,
                    Model, SerialNumber, InventoryNumber, NetworkNumber, Price, Battery,
                    Manipulator, Antenna, Charger, Remont)) { }
            else MessageBox.Show("Ошибка изменения радиостанции в radiostantionFull(таблица)",
                "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);

            if (_workRadiostantionRepository.ChangeRadiostationForDocumentInDataBase(
            Road, NumberAct, DateMaintenance, Representative,
            NumberIdentification, DateOfIssuanceOfTheCertificate,
            PhoneNumber, Post, Comment, City, Location, Poligon, Company,
            Model, SerialNumber, InventoryNumber, NetworkNumber, Price, Battery,
            Manipulator, Antenna, Charger, Remont))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else MessageBox.Show("Ошибка изменения радиостанции", "Отмена",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region ChangeDecommissionNumberActBySerialNumberInDataBase

        void ExecuteChangeDecommissionNumberActBySerialNumberInDataBaseCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (!CheckDecommissionNumberActIsNullOrWhiteSpace())
                return;
            if (!CheckDecommissionNumberActRegex())
                return;
            
            if (_workRadiostantionFullRepository.ChangeDecommissionNumberActBySerialNumberInDBRadiostantionFull(
                Road, City, SerialNumber, DecommissionNumberAct)){ }
            else MessageBox.Show("Ошибка изменения номера акта " +
                    "списания радиостанции в общей таблице(radiostantionFull)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            if (_workRadiostantionRepository.ChangeDecommissionNumberActBySerialNumberInDBRadiostantion(
                Road, City, SerialNumber, DecommissionNumberAct))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Ошибка изменения номера акта списания радиостанции",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region AddModelDataBase

        void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) =>
                addModelRadiostantion = null;
                addModelRadiostantion.Closed += (sender, args) =>
                GetModelDataBase();
                addModelRadiostantion.ShowDialog();
            }
        }

        #endregion

        #region ChangeNumberActBySerialNumberInDataBase

        void ExecuteChangeNumberActBySerialNumberInDataBaseCommand(object obj)
        {
            if (!CheckDecommissionNumberAct())
                return;

            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (!CheckNumberActIsNullOrWhiteSpace())
                return;

            if (!CheckNumberActRegex())
                return;

            if (_radiostationParametersRepository.CheckSerialNumberInRadiostationParameters(Road, SerialNumber))
            {
                if (!_radiostationParametersRepository.ChangeNumberActForRadiostationParameters
                (Road, SerialNumber, NumberAct))
                    MessageBox.Show("Ошибка изменения номера акта радиостанции " +
                        "в radiostation_parameters(таблица)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            if (_workRadiostantionFullRepository.ChangeNumberActBySerialNumberInDBRadiostationFull(
                Road, City, SerialNumber, NumberAct)){ }
            else MessageBox.Show("Ошибка изменения номера акта радиостанции " +
                    "в radiostantionFull(таблице)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRadiostantionRepository.ChangeNumberActBySerialNumberInDatabase(
                Road, City, SerialNumber, NumberAct))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Ошибка изменения номера акта радиостанции",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetModelDataBase

        void GetModelDataBase()
        {
            TheIndexModelChoiceCollection = -1;
            if (ModelsCollection.Count != 0)
                ModelsCollection.Clear();
            ModelsCollection = _modelDataBaseRepository.GetModelRadiostantionDataBase(ModelsCollection);
            TheIndexModelChoiceCollection = ModelsCollection.Count - 1;
        }

        #endregion
    }
}
