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
    internal class AddRepairRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        WorkRadiostantionFullRepository _workRadiostantionFullRepository;
        WorkRadiostantionRepository _workRadiostantionRepository;
        RepairManualModelRepository _repairManualModelRepository;

        RepairManualView repairManualView = null;

        public ObservableCollection<RepairManualRadiostantionModel>
            RepairManualRadiostantionsCollections
        { get; set; }
        public ObservableCollection<string> CompletedWorksCollections { get; set; }

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

        string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
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

        string _numberActRepair;
        public string NumberActRepair
        {
            get => _numberActRepair;
            set
            {
                _numberActRepair = value;
                OnPropertyChanged(nameof(NumberActRepair));
            }
        }

        string _dateRepair;
        public string DateRepair
        {
            get => _dateRepair;
            set
            {
                _dateRepair = value;
                OnPropertyChanged(nameof(DateRepair));
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

        string _category;
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                if (CheckBoxChoicePriceViewModel == true)
                {
                    if (value == "3")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_3;
                    if (value == "4")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_4;
                    if (value == "5")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_5;
                    if (value == "6")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_6;
                }
                else
                {
                    if (value == "3")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_3;
                    if (value == "4")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_4;
                    if (value == "5")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_5;
                    if (value == "6")
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_6;
                }

                OnPropertyChanged(nameof(Category));
            }
        }

        string _priceRepair;
        public string PriceRepair
        {
            get => _priceRepair;
            set
            {
                _priceRepair = value;
                OnPropertyChanged(nameof(PriceRepair));
            }
        }

        bool _checkBoxChoicePriceViewModel;
        public bool CheckBoxChoicePriceViewModel
        {
            get => _checkBoxChoicePriceViewModel;
            set
            {
                _checkBoxChoicePriceViewModel = value;
                if (value == true)
                {
                    if (Category == UserModelStatic.CATEGORY_3)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_3;
                    if (Category == UserModelStatic.CATEGORY_4)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_4;
                    if (Category == UserModelStatic.CATEGORY_5)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_5;
                    if (Category == UserModelStatic.CATEGORY_6)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_ANALOG_CATEGORY_6;
                }
                else
                {
                    if (Category == UserModelStatic.CATEGORY_3)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_3;
                    if (Category == UserModelStatic.CATEGORY_4)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_4;
                    if (Category == UserModelStatic.CATEGORY_5)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_5;
                    if (Category == UserModelStatic.CATEGORY_6)
                        PriceRepair = UserModelStatic.PRICE_REPAIR_DIGITAL_CATEGORY_6;
                }
                OnPropertyChanged(nameof(CheckBoxChoicePriceViewModel));
            }
        }

        string _primaryMeans;
        public string PrimaryMeans
        {
            get => _primaryMeans;
            set
            {
                _primaryMeans = value;
                OnPropertyChanged(nameof(PrimaryMeans));
            }
        }

        string _productName;
        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        #endregion

        #region CompletedWorks and Parts

        string _completedWorks_1;
        public string CompletedWorks_1
        {
            get => _completedWorks_1;
            set
            {
                _completedWorks_1 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_1))
                    Parts_1 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_1 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_1));
            }
        }

        string _parts_1;
        public string Parts_1
        {
            get => _parts_1;
            set
            {
                _parts_1 = value;
                OnPropertyChanged(nameof(Parts_1));
            }
        }

        string _completedWorks_2;
        public string CompletedWorks_2
        {
            get => _completedWorks_2;
            set
            {
                _completedWorks_2 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_2))
                    Parts_2 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_2 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_2));
            }
        }

        string _parts_2;
        public string Parts_2
        {
            get => _parts_2;
            set
            {
                _parts_2 = value;
                OnPropertyChanged(nameof(Parts_2));
            }
        }

        string _completedWorks_3;
        public string CompletedWorks_3
        {
            get => _completedWorks_3;
            set
            {
                _completedWorks_3 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_3))
                    Parts_3 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_3 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_3));
            }
        }

        string _parts_3;
        public string Parts_3
        {
            get => _parts_3;
            set
            {
                _parts_3 = value;
                OnPropertyChanged(nameof(Parts_3));
            }
        }

        string _completedWorks_4;
        public string CompletedWorks_4
        {
            get => _completedWorks_4;
            set
            {
                _completedWorks_4 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_4))
                    Parts_4 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_4 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_4));
            }
        }

        string _parts_4;
        public string Parts_4
        {
            get => _parts_4;
            set
            {
                _parts_4 = value;
                OnPropertyChanged(nameof(Parts_4));
            }
        }

        string _completedWorks_5;
        public string CompletedWorks_5
        {
            get => _completedWorks_5;
            set
            {
                _completedWorks_5 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_5))
                    Parts_5 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_5 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_5));
            }
        }

        string _parts_5;
        public string Parts_5
        {
            get => _parts_5;
            set
            {
                _parts_5 = value;
                OnPropertyChanged(nameof(Parts_5));
            }
        }

        string _completedWorks_6;
        public string CompletedWorks_6
        {
            get => _completedWorks_6;
            set
            {
                _completedWorks_6 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_6))
                    Parts_6 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_6 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_6));
            }
        }

        string _parts_6;
        public string Parts_6
        {
            get => _parts_6;
            set
            {
                _parts_6 = value;
                OnPropertyChanged(nameof(Parts_6));
            }
        }

        string _completedWorks_7;
        public string CompletedWorks_7
        {
            get => _completedWorks_7;
            set
            {
                _completedWorks_7 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_7))
                    Parts_7 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                    if (value == item.CompletedWorks)
                        Parts_7 = item.Parts;

                OnPropertyChanged(nameof(CompletedWorks_7));
            }
        }

        string _parts_7;
        public string Parts_7
        {
            get => _parts_7;
            set
            {
                _parts_7 = value;
                OnPropertyChanged(nameof(Parts_7));
            }
        }

        #endregion

        public ICommand ChangeNumberActRepairBySerialNumberInDataBase { get; }
        public ICommand RepairManualModelRadiostantionInDataBase { get; }
        public ICommand AddRepairRadiostationForDocumentInDataBase { get; }
        public AddRepairRadiostationForDocumentInDataBaseViewModel()
        {
            _workRadiostantionFullRepository = new WorkRadiostantionFullRepository();
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _repairManualModelRepository = new RepairManualModelRepository();
            RepairManualRadiostantionsCollections =
                new ObservableCollection<RepairManualRadiostantionModel>();
            CompletedWorksCollections = new ObservableCollection<string>();
            ChangeNumberActRepairBySerialNumberInDataBase =
                new ViewModelCommand(ExecuteChangeNumberActRepairBySerialNumberInDataBaseCommand);
            RepairManualModelRadiostantionInDataBase =
                new ViewModelCommand(ExecuteRepairManualModelRadiostantionInDataBaseCommand);
            AddRepairRadiostationForDocumentInDataBase =
                 new ViewModelCommand(ExecuteAddRepairRadiostationForDocumentInDataBaseCommand);
            GetRepairManualRadiostantionsCollections();
            GetPrimaryMeansInDataBase();
            GetOfTheLastNumberActRepair();
            GetProductNameInDataBase();
        }

        #region GetProductNameInDataBase

        void GetProductNameInDataBase()
        {
            ProductName = _workRadiostantionFullRepository.
                GetProductNameInDataBaseForRepair(
                UserModelStatic.SERIAL_NUMBER,
                UserModelStatic.CITY,
                UserModelStatic.ROAD);
        }


        #endregion

        #region GetPrimaryMeansInDataBase

        void GetPrimaryMeansInDataBase()
        {
            PrimaryMeans = _workRadiostantionFullRepository.
                GetPrimaryMeansInDataBaseForRepair(
                UserModelStatic.SERIAL_NUMBER,
                UserModelStatic.CITY,
                UserModelStatic.ROAD);
        }

        #endregion

        #region GetOfTheLastNumberActRepair

        void GetOfTheLastNumberActRepair()
        {
            string textNumberActRepair = _workRadiostantionRepository.
                GetOfTheLastNumberActRepair(UserModelStatic.ROAD);

            StringBuilder sbNumberActRepair = new StringBuilder();

            foreach (var item in UserModelStatic.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION)
            {
                if (UserModelStatic.ROAD == item.RoadBase)
                {
                    sbNumberActRepair.Append(item.NumberPrintDocumentBase);
                    sbNumberActRepair.Append("/");
                    break;
                }   
            }
            if (!String.IsNullOrWhiteSpace(textNumberActRepair))
            {
                // Используем TryParse для безопасного преобразования строки в число
                if (int.TryParse(textNumberActRepair.Substring(textNumberActRepair.IndexOf("/") + 1),
                    out int currentNumber))
                {
                    // Увеличиваем текущий номер на 1 и добавляем его к строке
                    NumberActRepair = sbNumberActRepair.Append(currentNumber + 1).ToString();
                }
            }
        }


        #endregion

        #region AddRepairRadiostationForDocumentInDataBase

        bool СheckIsNullOrWhiteSpace()
        {
            if (String.IsNullOrWhiteSpace(NumberActRepair))
            {
                MessageBox.Show("Поле \"Номер акта ремонта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(DateRepair))
            {
                MessageBox.Show("Поле \"Дата ремонта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(CompletedWorks_1))
            {
                MessageBox.Show("Поле \"Варианты работ(1)\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (String.IsNullOrWhiteSpace(Parts_1))
            {
                MessageBox.Show("Поле \"Израсходованные детали (1)\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        bool СheckNumberActRepairAndDateRepair()
        {
            if (!Regex.IsMatch(NumberActRepair,
                @"[0-9]{2,2}/[0-9]{1,}$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ремонта\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (!Regex.IsMatch(DateRepair,
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дату ремонта\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        bool СheckCompletedWorksAndParts()
        {
            Regex regCompletedWorks_1 = new Regex(Environment.NewLine);
            CompletedWorks_1 = regCompletedWorks_1.Replace(CompletedWorks_1, " ");
            CompletedWorks_1.Trim();
            Regex regParts_1 = new Regex(Environment.NewLine);
            Parts_1 = regParts_1.Replace(Parts_1, " ");
            Parts_1.Trim();

            if (!String.IsNullOrWhiteSpace(CompletedWorks_2))
            {
                if (String.IsNullOrWhiteSpace(Parts_2))
                {
                    MessageBox.Show("Поле \"Израсходованные детали (2)\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                Regex regCompletedWorks_2 = new Regex(Environment.NewLine);
                CompletedWorks_2 = regCompletedWorks_2.Replace(CompletedWorks_2, " ");
                CompletedWorks_2.Trim();
                Regex regParts_2 = new Regex(Environment.NewLine);
                Parts_2 = regParts_2.Replace(Parts_2, " ");
                Parts_2.Trim();
            }
            if (!String.IsNullOrWhiteSpace(CompletedWorks_3))
            {
                if (String.IsNullOrWhiteSpace(Parts_3))
                {
                    MessageBox.Show("Поле \"Израсходованные детали (3)\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                Regex regCompletedWorks_3 = new Regex(Environment.NewLine);
                CompletedWorks_3 = regCompletedWorks_3.Replace(CompletedWorks_3, " ");
                CompletedWorks_3.Trim();
                Regex regParts_3 = new Regex(Environment.NewLine);
                Parts_3 = regParts_3.Replace(Parts_3, " ");
                Parts_3.Trim();
            }
            if (!String.IsNullOrWhiteSpace(CompletedWorks_4))
            {
                if (String.IsNullOrWhiteSpace(Parts_4))
                {
                    MessageBox.Show("Поле \"Израсходованные детали (4)\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                Regex regCompletedWorks_4 = new Regex(Environment.NewLine);
                CompletedWorks_4 = regCompletedWorks_4.Replace(CompletedWorks_4, " ");
                CompletedWorks_4.Trim();
                Regex regParts_4 = new Regex(Environment.NewLine);
                Parts_4 = regParts_4.Replace(Parts_4, " ");
                Parts_4.Trim();
            }
            if (!String.IsNullOrWhiteSpace(CompletedWorks_5))
            {
                if (String.IsNullOrWhiteSpace(Parts_5))
                {
                    MessageBox.Show("Поле \"Израсходованные детали (5)\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                Regex regCompletedWorks_5 = new Regex(Environment.NewLine);
                CompletedWorks_5 = regCompletedWorks_5.Replace(CompletedWorks_5, " ");
                CompletedWorks_5.Trim();
                Regex regParts_5 = new Regex(Environment.NewLine);
                Parts_5 = regParts_5.Replace(Parts_5, " ");
                Parts_5.Trim();
            }
            if (!String.IsNullOrWhiteSpace(CompletedWorks_6))
            {
                if (String.IsNullOrWhiteSpace(Parts_6))
                {
                    MessageBox.Show("Поле \"Израсходованные детали (6)\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                Regex regCompletedWorks_6 = new Regex(Environment.NewLine);
                CompletedWorks_6 = regCompletedWorks_6.Replace(CompletedWorks_6, " ");
                CompletedWorks_6.Trim();
                Regex regParts_6 = new Regex(Environment.NewLine);
                Parts_6 = regParts_6.Replace(Parts_6, " ");
                Parts_6.Trim();
            }
            if (!String.IsNullOrWhiteSpace(CompletedWorks_7))
            {
                if (String.IsNullOrWhiteSpace(Parts_7))
                {
                    MessageBox.Show("Поле \"Израсходованные детали (6)\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
                Regex regCompletedWorks_7 = new Regex(Environment.NewLine);
                CompletedWorks_7 = regCompletedWorks_7.Replace(CompletedWorks_7, " ");
                CompletedWorks_7.Trim();
                Regex regParts_7 = new Regex(Environment.NewLine);
                Parts_7 = regParts_7.Replace(Parts_7, " ");
                Parts_7.Trim();
            }
            return true;
        }

        void ExecuteAddRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (!СheckIsNullOrWhiteSpace())
                return;
            if (!СheckNumberActRepairAndDateRepair())
                return;
            if (!СheckCompletedWorksAndParts())
                return;

            if (!String.IsNullOrWhiteSpace(PrimaryMeans) ||
               !String.IsNullOrWhiteSpace(ProductName))
                if (_workRadiostantionFullRepository.SetPrimaryMeansAndProductNameInDataBase(
                    Road, City, SerialNumber, PrimaryMeans, ProductName)) { }
                else MessageBox.Show("Ошибка добавления основного средства и наименования изделия" +
                    "в общую таблицу radiostantionFull", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRadiostantionFullRepository.
                AddRepairRadiostationForDocumentInDBRadiostantionFull(
                Road, City, SerialNumber, NumberActRepair, Category, PriceRepair,
                CompletedWorks_1, Parts_1, CompletedWorks_2, Parts_2,
                CompletedWorks_3, Parts_3, CompletedWorks_4, Parts_4,
                CompletedWorks_5, Parts_5, CompletedWorks_6, Parts_6,
                CompletedWorks_7, Parts_7)) { }
            else MessageBox.Show($"Ошибка добавления ремонта на радиостанцию {SerialNumber}" +
                    $"в radiostantionFull(общая таблица)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);

            if (_workRadiostantionRepository.AddRepairRadiostationForDocumentInDataBase(
                Road, City, SerialNumber, NumberActRepair, Category, PriceRepair,
                CompletedWorks_1, Parts_1, CompletedWorks_2, Parts_2,
                CompletedWorks_3, Parts_3, CompletedWorks_4, Parts_4,
                CompletedWorks_5, Parts_5, CompletedWorks_6, Parts_6,
                CompletedWorks_7, Parts_7))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка добавления ремонта на радиостанцию {SerialNumber}",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region AddRepairManualModelRadiostantionInDataBase

        void ExecuteRepairManualModelRadiostantionInDataBaseCommand(object obj)
        {
            if (repairManualView == null)
            {
                repairManualView = new RepairManualView(UserModelStatic.MODEL);
                repairManualView.Closed += (sender, args) => repairManualView = null;
                repairManualView.Closed += (sender, args) =>
                GetRepairManualRadiostantionsCollections();
                repairManualView.ShowDialog();
            }
        }

        #endregion

        #region ChangeNumberActRepairBySerialNumberInDataBase

        bool СheckNumberActRepair()
        {
            if (String.IsNullOrWhiteSpace(NumberActRepair))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            if (!Regex.IsMatch(NumberActRepair,
                @"[0-9]{2,2}/[0-9]{1,}$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ремонта\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        void ExecuteChangeNumberActRepairBySerialNumberInDataBaseCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (!СheckNumberActRepair())
                return;

            if (!_workRadiostantionRepository.CheckRepairInDBRadiostantionBySerialNumber(
                Road, City, SerialNumber))
                return;

            if (_workRadiostantionFullRepository.
                ChangeNumberActRepairBySerialNumberInDBRadiostationFull(
                Road, City, SerialNumber, NumberActRepair)){ }
            else MessageBox.Show("Ошибка изменения номера атка ремонта радиостанции " +
                    "в radiostantionFull(таблице)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRadiostantionRepository.ChangeNumberActRepairBySerialNumberInDataBase(
                Road, City, SerialNumber, NumberActRepair))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show("Ошибка изменения номера акта радиостанции",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetRepairManualRadiostantionsCollections

        void GetRepairManualRadiostantionsCollections()
        {
            if (RepairManualRadiostantionsCollections.Count != 0)
                RepairManualRadiostantionsCollections.Clear();
            RepairManualRadiostantionsCollections =
                _repairManualModelRepository.GetRepairManualRadiostantionsCollections(
                    RepairManualRadiostantionsCollections, UserModelStatic.MODEL);

            if (CompletedWorksCollections.Count != 0)
                CompletedWorksCollections.Clear();

            foreach (var item in RepairManualRadiostantionsCollections)
                CompletedWorksCollections.Add(item.CompletedWorks);
        }

        #endregion
    }
}
