﻿using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddDecommissionNumberActViewModel : ViewModelBase
    {
         IWorkRadiostantionRepository _workRadiostantionRepository;
         IWorkRadiostantionFullRepository _workRadiostantionFullRepository;
         IRadiostationParametersRepository _radiostationParametersRepository;
         
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

        string _decommissionNumberAct;
        public string DecommissionNumberAct { 
            get => _decommissionNumberAct; 
            set { _decommissionNumberAct = value; 
                OnPropertyChanged(nameof(DecommissionNumberAct)); } 
        }

        string _reasonDecommissionNumberAct;
        public string ReasonDecommissionNumberAct
        {
            get => _reasonDecommissionNumberAct;
            set
            {
                _reasonDecommissionNumberAct = value;
                OnPropertyChanged(nameof(ReasonDecommissionNumberAct));
            }
        }

        public ICommand AddDecommissionNumberActRadiostationForDocumentInDataBase { get; }

        public AddDecommissionNumberActViewModel()
        {
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _workRadiostantionFullRepository = new WorkRadiostantionFullRepository();
            _radiostationParametersRepository = new RadiostationParametersRepository();
            AddDecommissionNumberActRadiostationForDocumentInDataBase =
                new ViewModelCommand(
                    ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand);
        }

        #region AddDecommissionNumberActRadiostationForDocumentInDataBase

        void ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете списание?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (String.IsNullOrWhiteSpace(ReasonDecommissionNumberAct))
            {
                MessageBox.Show("Поле \"№ списания\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show("Поле \"№ списания\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DecommissionNumberAct,
                @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ списания\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (_radiostationParametersRepository.
                CheckSerialNumberInRadiostationParameters(Road, SerialNumber))
            {
                if (!_radiostationParametersRepository.DeleteRadiostantionFromRadiostationParameters
                    (Road, SerialNumber))
                    MessageBox.Show("Ошибка удаления радиостанции из radiostation_parameters(таблица)", 
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (_workRadiostantionFullRepository.
                AddDecommissionNumberActRadiostationInDBRadiostationFull(
                Road, City, SerialNumber, DecommissionNumberAct, ReasonDecommissionNumberAct))
            {}
            else MessageBox.Show($"Ошибка списания радиостанции " +
                    $"{SerialNumber}, radiostantionFull(общая база)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);

            if (_workRadiostantionRepository.AddDecommissionNumberActRadiostationInDB(
                Road, City, SerialNumber, DecommissionNumberAct, ReasonDecommissionNumberAct))
                MessageBox.Show("Успешно", "Информация",
                         MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка списания радиостанции {SerialNumber}",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}
