﻿using ServiceTelecom.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddDecommissionNumberActViewModel : ViewModelBase
    {
        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;

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

        private string _decommissionNumberAct;
        public string DecommissionNumberAct { 
            get => _decommissionNumberAct; 
            set { _decommissionNumberAct = value; 
                OnPropertyChanged(nameof(DecommissionNumberAct)); } 
        }
        private string _reasonDecommissionNumberAct;
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
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();

            AddDecommissionNumberActRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand);
        }

        #region AddDecommissionNumberActRadiostationForDocumentInDataBase

        private void ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand(object obj)
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
            //if(_workRepositoryRadiostantion.AddDecommissionNumberActRadiostationForDocumentInDB(
            //    Road,City,SerialNumber, DecommissionNumberAct, ReasonDecommissionNumberAct))
        }

        #endregion
    }
}
