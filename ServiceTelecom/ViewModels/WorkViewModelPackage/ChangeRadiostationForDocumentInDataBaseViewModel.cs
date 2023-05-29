using ServiceTelecom.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class ChangeRadiostationForDocumentInDataBaseViewModel : ViewModelBase
    {
        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;
        
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

        public ICommand ChangeNumberActBySerialNumberFromTheDatabase { get; }

        public ChangeRadiostationForDocumentInDataBaseViewModel()
        {
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            ChangeNumberActBySerialNumberFromTheDatabase = new ViewModelCommand(ExecuteChangeNumberActBySerialNumberFromTheDatabaseCommand);
        }

        #region ChangeNumberActBySerialNumberFromTheDatabase

        private void ExecuteChangeNumberActBySerialNumberFromTheDatabaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(NumberAct))
            {
                MessageBox.Show("Поле \"Номер акта\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberAct, @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ Акта ТО\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_workRepositoryRadiostantion.ChangeNumberActBySerialNumberFromTheDatabase(Road,City,SerialNumber, NumberAct))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта радиостанции", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion
    }
}
