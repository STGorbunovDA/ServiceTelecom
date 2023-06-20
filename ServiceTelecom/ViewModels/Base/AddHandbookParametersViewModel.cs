﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddHandbookParametersViewModel : ViewModelBase
    {
        HandbookParametersModelRadiostationRepository _handbookParametersModelRadiostationRepository;

        public ObservableCollection<HandbookParametersModelRadiostationModel>
           HandbookParametersAllModelRadiostationCollection
        { get; set; }


        AddModelRadiostantionView addModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        public ObservableCollection<ModelRadiostantionDataBaseModel>
            ModelCollections
        { get; set; }


        #region Свойства

        private string _model;
        //Передатчик
        private string _minLowPowerLevelTransmitter;
        private string _maxLowPowerLevelTransmitter;
        private string _minHighPowerLevelTransmitter;
        private string _maxHighPowerLevelTransmitter;
        private string _minFrequencyDeviationTransmitter;
        private string _maxFrequencyDeviationTransmitter;
        private string _minSensitivityTransmitter;
        private string _maxSensitivityTransmitter;
        private string _minKNITransmitter;
        private string _maxKNITransmitter;
        private string _minDeviationTransmitter;
        private string _maxDeviationTransmitter;
        //Приёмник
        private string _minOutputPowerVoltReceiver;
        private string _maxOutputPowerVoltReceiver;
        private string _minOutputPowerWattReceiver;
        private string _maxOutputPowerWattReceiver;
        private string _minSelectivityReceiver;
        private string _maxSelectivityReceiver;
        private string _minSensitivityReceiver;
        private string _maxSensitivityReceiver;
        private string _minKNIReceiver;
        private string _maxKNIReceiver;
        private string _minSuppressorReceiver;
        private string _maxSuppressorReceiver;
        //Потребляемый ток
        private string _minStandbyModeCurrentConsumption;
        private string _maxStandbyModeCurrentConsumption;
        private string _minReceptionModeCurrentConsumption;
        private string _maxReceptionModeCurrentConsumption;
        private string _minTransmissionModeCurrentConsumption;
        private string _maxTransmissionModeCurrentConsumption;
        private string _minBatteryDischargeAlarmCurrentConsumption;
        private string _maxBatteryDischargeAlarmCurrentConsumption;

        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }
        public string MinLowPowerLevelTransmitter { get => _minLowPowerLevelTransmitter; set { _minLowPowerLevelTransmitter = value; OnPropertyChanged(nameof(MinLowPowerLevelTransmitter)); } }
        public string MaxLowPowerLevelTransmitter { get => _maxLowPowerLevelTransmitter; set { _maxLowPowerLevelTransmitter = value; OnPropertyChanged(nameof(MaxLowPowerLevelTransmitter)); } }
        public string MinHighPowerLevelTransmitter { get => _minHighPowerLevelTransmitter; set { _minHighPowerLevelTransmitter = value; OnPropertyChanged(nameof(MinHighPowerLevelTransmitter)); } }
        public string MaxHighPowerLevelTransmitter { get => _maxHighPowerLevelTransmitter; set { _maxHighPowerLevelTransmitter = value; OnPropertyChanged(nameof(MaxHighPowerLevelTransmitter)); } }
        public string MinFrequencyDeviationTransmitter { get => _minFrequencyDeviationTransmitter; set { _minFrequencyDeviationTransmitter = value; OnPropertyChanged(nameof(MinFrequencyDeviationTransmitter)); } }
        public string MaxFrequencyDeviationTransmitter { get => _maxFrequencyDeviationTransmitter; set { _maxFrequencyDeviationTransmitter = value; OnPropertyChanged(nameof(MaxFrequencyDeviationTransmitter)); } }
        public string MinSensitivityTransmitter { get => _minSensitivityTransmitter; set { _minSensitivityTransmitter = value; OnPropertyChanged(nameof(MinSensitivityTransmitter)); } }
        public string MaxSensitivityTransmitter { get => _maxSensitivityTransmitter; set { _maxSensitivityTransmitter = value; OnPropertyChanged(nameof(MaxSensitivityTransmitter)); } }
        public string MinKNITransmitter { get => _minKNITransmitter; set { _minKNITransmitter = value; OnPropertyChanged(nameof(MinKNITransmitter)); } }
        public string MaxKNITransmitter { get => _maxKNITransmitter; set { _maxKNITransmitter = value; OnPropertyChanged(nameof(MaxKNITransmitter)); } }
        public string MinDeviationTransmitter { get => _minDeviationTransmitter; set { _minDeviationTransmitter = value; OnPropertyChanged(nameof(MinDeviationTransmitter)); } }
        public string MaxDeviationTransmitter { get => _maxDeviationTransmitter; set { _maxDeviationTransmitter = value; OnPropertyChanged(nameof(MaxDeviationTransmitter)); } }
        public string MinOutputPowerVoltReceiver { get => _minOutputPowerVoltReceiver; set { _minOutputPowerVoltReceiver = value; OnPropertyChanged(nameof(MinOutputPowerVoltReceiver)); } }
        public string MaxOutputPowerVoltReceiver { get => _maxOutputPowerVoltReceiver; set { _maxOutputPowerVoltReceiver = value; OnPropertyChanged(nameof(MaxOutputPowerVoltReceiver)); } }
        public string MinOutputPowerWattReceiver { get => _minOutputPowerWattReceiver; set { _minOutputPowerWattReceiver = value; OnPropertyChanged(nameof(MinOutputPowerWattReceiver)); } }
        public string MaxOutputPowerWattReceiver { get => _maxOutputPowerWattReceiver; set { _maxOutputPowerWattReceiver = value; OnPropertyChanged(nameof(MaxOutputPowerWattReceiver)); } }
        public string MinSelectivityReceiver { get => _minSelectivityReceiver; set { _minSelectivityReceiver = value; OnPropertyChanged(nameof(MinSelectivityReceiver)); } }
        public string MaxSelectivityReceiver { get => _maxSelectivityReceiver; set { _maxSelectivityReceiver = value; OnPropertyChanged(nameof(MaxSelectivityReceiver)); } }
        public string MinSensitivityReceiver { get => _minSensitivityReceiver; set { _minSensitivityReceiver = value; OnPropertyChanged(nameof(MinSensitivityReceiver)); } }
        public string MaxSensitivityReceiver { get => _maxSensitivityReceiver; set { _maxSensitivityReceiver = value; OnPropertyChanged(nameof(MaxSensitivityReceiver)); } }
        public string MinKNIReceiver { get => _minKNIReceiver; set { _minKNIReceiver = value; OnPropertyChanged(nameof(MinKNIReceiver)); } }
        public string MaxKNIReceiver { get => _maxKNIReceiver; set { _maxKNIReceiver = value; OnPropertyChanged(nameof(MaxKNIReceiver)); } }
        public string MinSuppressorReceiver { get => _minSuppressorReceiver; set { _minSuppressorReceiver = value; OnPropertyChanged(nameof(MinSuppressorReceiver)); } }
        public string MaxSuppressorReceiver { get => _maxSuppressorReceiver; set { _maxSuppressorReceiver = value; OnPropertyChanged(nameof(MaxSuppressorReceiver)); } }
        public string MinStandbyModeCurrentConsumption { get => _minStandbyModeCurrentConsumption; set { _minStandbyModeCurrentConsumption = value; OnPropertyChanged(nameof(MinStandbyModeCurrentConsumption)); } }
        public string MaxStandbyModeCurrentConsumption { get => _maxStandbyModeCurrentConsumption; set { _maxStandbyModeCurrentConsumption = value; OnPropertyChanged(nameof(MaxStandbyModeCurrentConsumption)); } }
        public string MinReceptionModeCurrentConsumption { get => _minReceptionModeCurrentConsumption; set { _minReceptionModeCurrentConsumption = value; OnPropertyChanged(nameof(MinReceptionModeCurrentConsumption)); } }
        public string MaxReceptionModeCurrentConsumption { get => _maxReceptionModeCurrentConsumption; set { _maxReceptionModeCurrentConsumption = value; OnPropertyChanged(nameof(MaxReceptionModeCurrentConsumption)); } }
        public string MinTransmissionModeCurrentConsumption { get => _minTransmissionModeCurrentConsumption; set { _minTransmissionModeCurrentConsumption = value; OnPropertyChanged(nameof(MinTransmissionModeCurrentConsumption)); } }
        public string MaxTransmissionModeCurrentConsumption { get => _maxTransmissionModeCurrentConsumption; set { _maxTransmissionModeCurrentConsumption = value; OnPropertyChanged(nameof(MaxTransmissionModeCurrentConsumption)); } }
        public string MinBatteryDischargeAlarmCurrentConsumption { get => _minBatteryDischargeAlarmCurrentConsumption; set { _minBatteryDischargeAlarmCurrentConsumption = value; OnPropertyChanged(nameof(MinBatteryDischargeAlarmCurrentConsumption)); } }
        public string MaxBatteryDischargeAlarmCurrentConsumption { get => _maxBatteryDischargeAlarmCurrentConsumption; set { _maxBatteryDischargeAlarmCurrentConsumption = value; OnPropertyChanged(nameof(MaxBatteryDischargeAlarmCurrentConsumption)); } }

        #endregion

        private int _selectedIndexHandbookParametersModel;
        public int SelectedIndexHandbookParametersModel
        {
            get => _selectedIndexHandbookParametersModel;
            set
            {
                _selectedIndexHandbookParametersModel = value;
                OnPropertyChanged(nameof(SelectedIndexHandbookParametersModel));
            }
        }

        private IList _selectedModels = new ArrayList();
        public IList HandbookParametersModelMulipleSelectedDataGrid
        {
            get => _selectedModels;
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(HandbookParametersModelMulipleSelectedDataGrid));
            }
        }

        HandbookParametersModelRadiostationModel _selectedHandbookParametersModel;
        public HandbookParametersModelRadiostationModel SelectedHandbookParametersModel
        {
            get => _selectedHandbookParametersModel;
            set
            {
                #region получение в контролы

                if (_selectedHandbookParametersModel != null)
                {
                    Model = _selectedHandbookParametersModel.Model;

                    MinLowPowerLevelTransmitter =
                        _selectedHandbookParametersModel.MinLowPowerLevelTransmitter;
                    MaxLowPowerLevelTransmitter =
                        _selectedHandbookParametersModel.MaxLowPowerLevelTransmitter;

                    MinHighPowerLevelTransmitter =
                        _selectedHandbookParametersModel.MinHighPowerLevelTransmitter;
                    MaxHighPowerLevelTransmitter =
                        _selectedHandbookParametersModel.MaxHighPowerLevelTransmitter;

                    MinFrequencyDeviationTransmitter =
                        _selectedHandbookParametersModel.MinFrequencyDeviationTransmitter;
                    MaxFrequencyDeviationTransmitter =
                        _selectedHandbookParametersModel.MaxFrequencyDeviationTransmitter;

                    MinSensitivityTransmitter =
                        _selectedHandbookParametersModel.MinSensitivityTransmitter;
                    MaxSensitivityTransmitter =
                        _selectedHandbookParametersModel.MaxSensitivityTransmitter;

                    MinKNITransmitter =
                        _selectedHandbookParametersModel.MinKNITransmitter;
                    MaxKNITransmitter =
                        _selectedHandbookParametersModel.MaxKNITransmitter;

                    MinDeviationTransmitter =
                        _selectedHandbookParametersModel.MinDeviationTransmitter;
                    MaxDeviationTransmitter =
                        _selectedHandbookParametersModel.MaxDeviationTransmitter;

                    MinOutputPowerVoltReceiver =
                        _selectedHandbookParametersModel.MinOutputPowerVoltReceiver;
                    MaxOutputPowerVoltReceiver =
                        _selectedHandbookParametersModel.MaxOutputPowerVoltReceiver;

                    MinOutputPowerWattReceiver =
                        _selectedHandbookParametersModel.MinOutputPowerWattReceiver;
                    MaxOutputPowerWattReceiver =
                        _selectedHandbookParametersModel.MaxOutputPowerWattReceiver;

                    MinSelectivityReceiver =
                        _selectedHandbookParametersModel.MinSelectivityReceiver;
                    MaxSelectivityReceiver =
                        _selectedHandbookParametersModel.MaxSelectivityReceiver;

                    MinSensitivityReceiver =
                        _selectedHandbookParametersModel.MinSensitivityReceiver;
                    MaxSensitivityReceiver =
                        _selectedHandbookParametersModel.MaxSensitivityReceiver;

                    MinKNIReceiver =
                        _selectedHandbookParametersModel.MinKNIReceiver;
                    MaxKNIReceiver =
                        _selectedHandbookParametersModel.MaxKNIReceiver;

                    MinSuppressorReceiver =
                        _selectedHandbookParametersModel.MinSuppressorReceiver;
                    MaxSuppressorReceiver =
                        _selectedHandbookParametersModel.MaxSuppressorReceiver;

                    MinStandbyModeCurrentConsumption =
                        _selectedHandbookParametersModel.MinStandbyModeCurrentConsumption;
                    MaxStandbyModeCurrentConsumption =
                        _selectedHandbookParametersModel.MaxStandbyModeCurrentConsumption;

                    MinReceptionModeCurrentConsumption =
                        _selectedHandbookParametersModel.MinReceptionModeCurrentConsumption;
                    MaxReceptionModeCurrentConsumption =
                        _selectedHandbookParametersModel.MaxReceptionModeCurrentConsumption;

                    MinTransmissionModeCurrentConsumption =
                        _selectedHandbookParametersModel.MinTransmissionModeCurrentConsumption;
                    MaxTransmissionModeCurrentConsumption =
                        _selectedHandbookParametersModel.MaxTransmissionModeCurrentConsumption;

                    MinBatteryDischargeAlarmCurrentConsumption =
                        _selectedHandbookParametersModel.MinBatteryDischargeAlarmCurrentConsumption;
                    MaxBatteryDischargeAlarmCurrentConsumption =
                        _selectedHandbookParametersModel.MaxBatteryDischargeAlarmCurrentConsumption;
                }

                #endregion

                _selectedHandbookParametersModel = value;
                OnPropertyChanged(nameof(SelectedHandbookParametersModel));
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

        public ICommand AddModelDataBase { get; }
        public ICommand GetHandbookParametersByModelForRadiostationCollection { get; }
        public ICommand AddHandbookParametersForModel { get; }
        public AddHandbookParametersViewModel()
        {
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            _modelDataBase = new ModelDataBaseRepository();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            GetHandbookParametersByModelForRadiostationCollection =
                new ViewModelCommand(ExecuteGetHandbookParametersByModelForRadiostationCollectionCommand);
            _handbookParametersModelRadiostationRepository
                = new HandbookParametersModelRadiostationRepository();
            HandbookParametersAllModelRadiostationCollection =
                new ObservableCollection<HandbookParametersModelRadiostationModel>();
            AddHandbookParametersForModel = 
                new ViewModelCommand(ExecuteAddHandbookParametersForModelCommand);

            GetModelDataBase();
            GetHandbookParametersAllModelForCollection();
        }

        #region AddHandbookParametersForModel

        private void ExecuteAddHandbookParametersForModelCommand(object obj)
        {
            #region Проверка ввода контролов

            if (String.IsNullOrWhiteSpace(Model))
            {
                MessageBox.Show("Поле \"Модель\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinLowPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Min Low P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(MinLowPowerLevelTransmitter, @"^[2-2]{1,1}[.][0]{1,1}[0]$"))
            {
                MessageBox.Show("Введите корректно поле: \"Min Low P, W\"\n" +
                    "Пример: 2.00", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxLowPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Max Low P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(MaxLowPowerLevelTransmitter, @"^[2-2]{1,1}[.][2]{1,1}[0]$"))
            {
                MessageBox.Show("Введите корректно поле: \"Max Low P, W\"\n" +
                    "Пример: 2.20", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinHighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Min High P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(MinHighPowerLevelTransmitter, @"^[2-2]{1,1}[.][0]{1,1}[0]$"))
            {
                MessageBox.Show("Введите корректно поле: \"Min High P, W\"\n" +
                    "Пример: 2.00", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxHighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Max High P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(MaxHighPowerLevelTransmitter, @"^[5]{1,1}[.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Max High P, W\"\n" +
                    "Пример: 2.20", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (String.IsNullOrWhiteSpace(MinFrequencyDeviationTransmitter))
            {
                MessageBox.Show("Поле \"Min δf, Hz\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxFrequencyDeviationTransmitter))
            {
                MessageBox.Show("Поле \"Max δf, Hz\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinSensitivityTransmitter))
            {
                MessageBox.Show("Поле \"Min ЧУВ, mV\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxSensitivityTransmitter))
            {
                MessageBox.Show("Поле \"Max ЧУВ, mV\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinKNITransmitter))
            {
                MessageBox.Show("Поле \"Min KNI, %\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxKNITransmitter))
            {
                MessageBox.Show("Поле \"Max KNI, %\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinDeviationTransmitter))
            {
                MessageBox.Show("Поле \"Min ΔF, kHz\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxDeviationTransmitter))
            {
                MessageBox.Show("Поле \"Max ΔF, kHz\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinOutputPowerVoltReceiver))
            {
                MessageBox.Show("Поле \"Min P НЧ, V\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxOutputPowerVoltReceiver))
            {
                MessageBox.Show("Поле \"Max P НЧ, V\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinOutputPowerWattReceiver))
            {
                MessageBox.Show("Поле \"Min P НЧ, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxOutputPowerWattReceiver))
            {
                MessageBox.Show("Поле \"Max P НЧ, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinSelectivityReceiver))
            {
                MessageBox.Show("Поле \"Min ИЗ, dB\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxSelectivityReceiver))
            {
                MessageBox.Show("Поле \"Max ИЗ, dB\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinSensitivityReceiver))
            {
                MessageBox.Show("Поле \"Min ЧУВ, mkV\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxSensitivityReceiver))
            {
                MessageBox.Show("Поле \"Max ЧУВ, mkV\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinKNIReceiver))
            {
                MessageBox.Show("Поле \"Min KNI, %\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxKNIReceiver))
            {
                MessageBox.Show("Поле \"Max KNI, %\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinSuppressorReceiver))
            {
                MessageBox.Show("Поле \"Min Ш, mkV\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxSuppressorReceiver))
            {
                MessageBox.Show("Поле \"Max Ш, mkV\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinStandbyModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Min Standby, mA\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxStandbyModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Max Standby, mA\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinReceptionModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Min Reception, mA\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxReceptionModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Max Reception, mA\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinTransmissionModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Min Transmission, A\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxTransmissionModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Max Transmission, A\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinBatteryDischargeAlarmCurrentConsumption))
            {
                MessageBox.Show("Поле \"Min Battery Discharge, V\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxBatteryDischargeAlarmCurrentConsumption))
            {
                MessageBox.Show("Поле \"Max Battery Discharge, V\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            
            #endregion
        }

        #endregion


        #region GetHandbookParametersAllModelForCollection

        private void GetHandbookParametersAllModelForCollection()
        {
            if (HandbookParametersAllModelRadiostationCollection.Count != 0)
                HandbookParametersAllModelRadiostationCollection.Clear();
            HandbookParametersAllModelRadiostationCollection =
                _handbookParametersModelRadiostationRepository.
                GetHandbookParametersAllModelForCollection(
                    HandbookParametersAllModelRadiostationCollection);
        }

        #endregion

        #region GetHandbookParametersByModelForRadiostationCollection

        private void ExecuteGetHandbookParametersByModelForRadiostationCollectionCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Model))
            {
                MessageBox.Show($"Модель пуста",
                  "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (HandbookParametersAllModelRadiostationCollection.Count != 0)
                HandbookParametersAllModelRadiostationCollection.Clear();
            HandbookParametersAllModelRadiostationCollection =
                _handbookParametersModelRadiostationRepository.
                GetHandbookParametersByModelForCollection(
                    HandbookParametersAllModelRadiostationCollection, Model);
           
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
