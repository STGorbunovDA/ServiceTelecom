using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddRepairRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        private WorkRepositoryRadiostantionFull _workRepositoryRadiostantionFull;
        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;
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

        private string _completedWorks_1;
        public string CompletedWorks_1
        {
            get => _completedWorks_1;
            set
            {
                _completedWorks_1 = value;
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
        public AddRepairRadiostationForDocumentInDataBaseViewModel()
        {
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            ChangeNumberActRepairBySerialNumberInDataBase =
                new ViewModelCommand(ExecuteChangeNumberActRepairBySerialNumberInDataBaseCommand);
        }


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
    }
}
