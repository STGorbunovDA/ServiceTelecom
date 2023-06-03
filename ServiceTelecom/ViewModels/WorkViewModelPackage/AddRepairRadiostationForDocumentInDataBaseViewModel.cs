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
    internal class AddRepairRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        private WorkRepositoryRadiostantionFull _workRepositoryRadiostantionFull;
        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;
        private RepairManualModelRepository _repairManualModelRepository;

        RepairManualView repairManualView = null;

        private ObservableCollection<RepairManualRadiostantion>
            RepairManualRadiostantionsCollections
        { get; set; }
        public ObservableCollection<string> CompletedWorksCollections { get; set; }


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

        private string _numberActRepair;
        public string NumberActRepair
        {
            get => _numberActRepair;
            set
            {
                _numberActRepair = value;
                OnPropertyChanged(nameof(NumberActRepair));
            }
        }

        private string _dateRepair;
        public string DateRepair
        {
            get => _dateRepair;
            set
            {
                _dateRepair = value;
                OnPropertyChanged(nameof(DateRepair));
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

        private string _category;
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                if (CheckBoxChoicePriceViewModel == true)
                {
                    if (value == "3")
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_3;
                    if (value == "4")
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_4;
                    if (value == "5")
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_5;
                    if (value == "6")
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_6;
                }
                else
                {
                    if (value == "3")
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_3;
                    if (value == "4")
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_4;
                    if (value == "5")
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_5;
                    if (value == "6")
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_6;
                }

                OnPropertyChanged(nameof(Category));
            }
        }

        private string _priceRepair;
        public string PriceRepair
        {
            get => _priceRepair;
            set
            {
                _priceRepair = value;
                OnPropertyChanged(nameof(PriceRepair));
            }
        }

        private bool _checkBoxChoicePriceViewModel;
        public bool CheckBoxChoicePriceViewModel
        {
            get => _checkBoxChoicePriceViewModel;
            set
            {
                _checkBoxChoicePriceViewModel = value;
                if (value == true)
                {
                    if (Category == UserModelStatic.Category_3)
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_3;
                    if (Category == UserModelStatic.Category_4)
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_4;
                    if (Category == UserModelStatic.Category_5)
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_5;
                    if (Category == UserModelStatic.Category_6)
                        PriceRepair = UserModelStatic.priceRepairAnalogCategory_6;

                }
                else
                {
                    if (Category == UserModelStatic.Category_3)
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_3;
                    if (Category == UserModelStatic.Category_4)
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_4;
                    if (Category == UserModelStatic.Category_5)
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_5;
                    if (Category == UserModelStatic.Category_6)
                        PriceRepair = UserModelStatic.priceRepairDigitalCategory_6;
                }
                OnPropertyChanged(nameof(CheckBoxChoicePriceViewModel));
            }
        }

        private string _primaryMeans;
        public string PrimaryMeans
        {
            get => _primaryMeans;
            set
            {
                _primaryMeans = value;
                OnPropertyChanged(nameof(PrimaryMeans));
            }
        }

        private string _productName;
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

        private string _completedWorks_1;
        public string CompletedWorks_1
        {
            get => _completedWorks_1;
            set
            {
                _completedWorks_1 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_1))
                    Parts_1 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_1 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_1));
            }
        }

        private string _parts_1;
        public string Parts_1
        {
            get => _parts_1;
            set
            {
                _parts_1 = value;
                OnPropertyChanged(nameof(Parts_1));
            }
        }

        private string _completedWorks_2;
        public string CompletedWorks_2
        {
            get => _completedWorks_2;
            set
            {
                _completedWorks_2 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_2))
                    Parts_2 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_2 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_2));
            }
        }

        private string _parts_2;
        public string Parts_2
        {
            get => _parts_2;
            set
            {
                _parts_2 = value;
                OnPropertyChanged(nameof(Parts_2));
            }
        }

        private string _completedWorks_3;
        public string CompletedWorks_3
        {
            get => _completedWorks_3;
            set
            {
                _completedWorks_3 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_3))
                    Parts_3 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_3 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_3));
            }
        }

        private string _parts_3;
        public string Parts_3
        {
            get => _parts_3;
            set
            {
                _parts_3 = value;
                OnPropertyChanged(nameof(Parts_3));
            }
        }

        private string _completedWorks_4;
        public string CompletedWorks_4
        {
            get => _completedWorks_4;
            set
            {
                _completedWorks_4 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_4))
                    Parts_4 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_4 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_4));
            }
        }

        private string _parts_4;
        public string Parts_4
        {
            get => _parts_4;
            set
            {
                _parts_4 = value;
                OnPropertyChanged(nameof(Parts_4));
            }
        }

        private string _completedWorks_5;
        public string CompletedWorks_5
        {
            get => _completedWorks_5;
            set
            {
                _completedWorks_5 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_5))
                    Parts_5 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_5 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_5));
            }
        }

        private string _parts_5;
        public string Parts_5
        {
            get => _parts_5;
            set
            {
                _parts_5 = value;
                OnPropertyChanged(nameof(Parts_5));
            }
        }

        private string _completedWorks_6;
        public string CompletedWorks_6
        {
            get => _completedWorks_6;
            set
            {
                _completedWorks_6 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_6))
                    Parts_6 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_6 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_6));
            }
        }

        private string _parts_6;
        public string Parts_6
        {
            get => _parts_6;
            set
            {
                _parts_6 = value;
                OnPropertyChanged(nameof(Parts_6));
            }
        }

        private string _completedWorks_7;
        public string CompletedWorks_7
        {
            get => _completedWorks_7;
            set
            {
                _completedWorks_7 = value;
                if (String.IsNullOrWhiteSpace(CompletedWorks_7))
                    Parts_7 = string.Empty;
                foreach (var item in RepairManualRadiostantionsCollections)
                {
                    if (value == item.CompletedWorks)
                        Parts_7 = item.Parts;
                }
                OnPropertyChanged(nameof(CompletedWorks_7));
            }
        }

        private string _parts_7;
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
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            _repairManualModelRepository = new RepairManualModelRepository();
            RepairManualRadiostantionsCollections = new ObservableCollection<RepairManualRadiostantion>();
            CompletedWorksCollections = new ObservableCollection<string>();
            ChangeNumberActRepairBySerialNumberInDataBase =
                new ViewModelCommand(ExecuteChangeNumberActRepairBySerialNumberInDataBaseCommand);
            RepairManualModelRadiostantionInDataBase =
                new ViewModelCommand(ExecuteRepairManualModelRadiostantionInDataBaseCommand);
            AddRepairRadiostationForDocumentInDataBase =
                 new ViewModelCommand(ExecuteAddRepairRadiostationForDocumentInDataBaseCommand);
            GetRepairManualRadiostantionsCollections();
        }


        #region AddRepairRadiostationForDocumentInDataBase

        private void ExecuteAddRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {

            #region Проверка ввода контролов

            if (String.IsNullOrWhiteSpace(NumberActRepair))
            {
                MessageBox.Show("Поле \"Номер акта ремонта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberActRepair,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ремонта\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(DateRepair))
            {
                MessageBox.Show("Поле \"Дата ремонта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DateRepair,
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дату ремонта\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string dateRepairDataBase =
                Convert.ToDateTime(DateRepair).ToString("yyyy-MM-dd");

            if (String.IsNullOrWhiteSpace(CompletedWorks_1))
            {
                MessageBox.Show("Поле \"Варианты работ(1)\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(Parts_1))
            {
                MessageBox.Show("Поле \"Израсходованные детали (1)\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

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
                    return;
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
                    return;
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
                    return;
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
                    return;
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
                    return;
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
                    return;
                }
                Regex regCompletedWorks_7 = new Regex(Environment.NewLine);
                CompletedWorks_7 = regCompletedWorks_7.Replace(CompletedWorks_7, " ");
                CompletedWorks_7.Trim();
                Regex regParts_7 = new Regex(Environment.NewLine);
                Parts_7 = regParts_7.Replace(Parts_7, " ");
                Parts_7.Trim();
            }

            #endregion

            if (!String.IsNullOrWhiteSpace(PrimaryMeans) ||
               !String.IsNullOrWhiteSpace(ProductName))
                if (_workRepositoryRadiostantionFull.SetPrimaryMeansAndProductNameInDataBase(
                    Road, City, SerialNumber, PrimaryMeans, ProductName))
                { }
                else MessageBox.Show("Ошибка добавления основного средства и наименования изделия" +
                    "в общую таблицу radiostantionFull", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);


            if (_workRepositoryRadiostantion.AddRepairRadiostationForDocumentInDataBase(
                Road, City, SerialNumber, NumberActRepair, Category, PriceRepair,
                CompletedWorks_1, Parts_1, CompletedWorks_2, Parts_2,
                CompletedWorks_3, Parts_3, CompletedWorks_4, Parts_4,
                CompletedWorks_5, Parts_5, CompletedWorks_6, Parts_6,
                CompletedWorks_7, Parts_7))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка добавления ремонта на радиостанцию {SerialNumber}",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region AddRepairManualModelRadiostantionInDataBase

        private void ExecuteRepairManualModelRadiostantionInDataBaseCommand(object obj)
        {
            if (repairManualView == null)
            {
                repairManualView = new RepairManualView(UserModelStatic.model);
                repairManualView.Closed += (sender, args) => repairManualView = null;
                repairManualView.Closed += (sender, args) =>
                GetRepairManualRadiostantionsCollections();
                repairManualView.Show();
            }
        }

        #endregion

        #region ChangeNumberActRepairBySerialNumberInDataBase

        private void ExecuteChangeNumberActRepairBySerialNumberInDataBaseCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (String.IsNullOrWhiteSpace(NumberActRepair))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberActRepair,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ремонта\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!_workRepositoryRadiostantion.CheckRepairInDBRadiostantionBySerialNumber(
                Road, City, SerialNumber))
                return;

            if (_workRepositoryRadiostantionFull.
                ChangeNumberActRepairBySerialNumberInDBRadiostationFull(
                Road, City, SerialNumber, NumberActRepair))
            { }
            else
                MessageBox.Show("Ошибка изменения номера атка ремонта радиостанции " +
                    "в radiostantionFull(таблице)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.ChangeNumberActRepairBySerialNumberInDataBase(
                Road, City, SerialNumber, NumberActRepair))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта радиостанции",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        private void GetRepairManualRadiostantionsCollections()
        {
            if (RepairManualRadiostantionsCollections.Count != 0)
                RepairManualRadiostantionsCollections.Clear();
            RepairManualRadiostantionsCollections =
                _repairManualModelRepository.GetRepairManualRadiostantionsCollections(
                    RepairManualRadiostantionsCollections, UserModelStatic.model);

            if (CompletedWorksCollections.Count != 0)
                CompletedWorksCollections.Clear();

            foreach (var item in RepairManualRadiostantionsCollections)
                CompletedWorksCollections.Add(item.CompletedWorks);
        }
    }
}
