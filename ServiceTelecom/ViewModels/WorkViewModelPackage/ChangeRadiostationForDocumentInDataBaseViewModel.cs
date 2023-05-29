using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
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
        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelCollections { get; set; }


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

        public ICommand ChangeNumberActBySerialNumberFromTheDatabase { get; }
        public ICommand AddModelDataBase { get; }
        public ICommand ChangeDecommissionNumberActBySerialNumberFromTheDatabase { get; }
        public ICommand ChangeRadiostationForDocumentInDataBase { get; }

        public ChangeRadiostationForDocumentInDataBaseViewModel()
        {
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            _modelDataBase = new ModelDataBaseRepository();
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            ChangeNumberActBySerialNumberFromTheDatabase = new ViewModelCommand(ExecuteChangeNumberActBySerialNumberFromTheDatabaseCommand);
            ChangeDecommissionNumberActBySerialNumberFromTheDatabase = new ViewModelCommand(ExecuteChangeDecommissionNumberActBySerialNumberFromTheDatabaseCommand);
            ChangeRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteChangeRadiostationForDocumentInDataBaseCommand);
        }


        #region ChangeRadiostationForDocumentInDataBase

        private void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if(!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        #endregion

        #region ExecuteChangeDecommissionNumberActBySerialNumberFromTheDatabaseCommand

        private void ExecuteChangeDecommissionNumberActBySerialNumberFromTheDatabaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show("Поле \"№ акта списания\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(NumberAct, @"[0-9]{2,2}/([0-9]+([A-Z]?[А-Я]?)*[.\-]?[0-9]?[0-9]?[0-9]?[A-Z]?[А-Я]?)$"))
            {
                MessageBox.Show("Введите корректно поле \"№ акта списания\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(_workRepositoryRadiostantionFull.ChangeDecommissionNumberActBySerialNumberFromDBRadiostantionFull(Road, City, SerialNumber, DecommissionNumberAct))
            { }
            else
                MessageBox.Show("Ошибка изменения номера акта списания радиостанции в общей таблице(radiostantionFull)", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            if (_workRepositoryRadiostantion.ChangeDecommissionNumberActBySerialNumberFromDBRadiostantion(Road, City, SerialNumber, DecommissionNumberAct))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения номера акта списания радиостанции", "Отмена", MessageBoxButton.OK,
                    MessageBoxImage.Error);
        }

        #endregion

        #region ExecuteAddModelDataBaseCommand

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) => addModelRadiostantion = null;
                addModelRadiostantion.Closed += (sender, args) => GetModelDataBase();
                addModelRadiostantion.Show();
            }
        }

        #endregion

        #region ChangeNumberActBySerialNumberFromTheDatabase

        private void ExecuteChangeNumberActBySerialNumberFromTheDatabaseCommand(object obj)
        {
            if (!String.IsNullOrWhiteSpace(DecommissionNumberAct))
            {
                MessageBox.Show($"У радиостанции \"{SerialNumber}\" " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
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
