using ServiceTelecom.Models;
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

        private bool _checkBoxRepeater;

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
        public bool CheckBoxRepeater { get => _checkBoxRepeater; set { _checkBoxRepeater = value; OnPropertyChanged(nameof(CheckBoxRepeater)); } }

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

        HandbookParametersModelRadiostationModel _selectedHandbookParametersModel;
        public HandbookParametersModelRadiostationModel SelectedHandbookParametersModel
        {
            get => _selectedHandbookParametersModel;
            set
            {
                _selectedHandbookParametersModel = value;

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
        public ICommand UpdateHandbookParametersForModel { get; }
        public ICommand ChangeHandbookParametersForModel { get; }
        public ICommand DeleteHandbookParametersForModel { get; }
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
            UpdateHandbookParametersForModel =
                new ViewModelCommand(ExecuteUpdateHandbookParametersForModelCommand);
            ChangeHandbookParametersForModel =
                new ViewModelCommand(ExecuteChangeHandbookParametersForModelCommand);
            DeleteHandbookParametersForModel =
                new ViewModelCommand(ExecuteDeleteHandbookParametersForModelCommand);
            GetModelDataBase();
            GetHandbookParametersAllModelForCollection();
        }



        #region DeleteHandbookParametersForModel

        private void ExecuteDeleteHandbookParametersForModelCommand(object obj)
        {
            if (SelectedHandbookParametersModel == null)
                return;
            if (MessageBox.Show($"Подтверждаете удаление справочника у модели: " +
                $"\"{SelectedHandbookParametersModel.Model}\"?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (_handbookParametersModelRadiostationRepository.
                DeleteHandbookParametersForModel(SelectedHandbookParametersModel.IdBase))
            {
                GetHandbookParametersAllModelForCollection();
                MessageBox.Show("Успешно!", "Информация",
                       MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show($"Ошибка удаления справочника модели!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region ChangeHandbookParametersForModel

        private void ExecuteChangeHandbookParametersForModelCommand(object obj)
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
            if (String.IsNullOrWhiteSpace(MaxLowPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Max Low P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinHighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Min High P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxHighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Max High P, W\" не должно быть пустым", "Отмена",
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

            if (!CheckBoxRepeater)
            {
                if (!Regex.IsMatch(MinLowPowerLevelTransmitter, @"^[2-2][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Low P, W\"\n" +
                        "Пример: 2.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxLowPowerLevelTransmitter, @"^[2-2][.][2][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Low P, W\"\n" +
                        "Пример: 2.20", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinHighPowerLevelTransmitter, @"^[2-2][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min High P, W\"\n" +
                        "Пример: 2.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxHighPowerLevelTransmitter, @"^[5][.][0-9]{2,2}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max High P, W\"\n" +
                        "Пример: 5.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinFrequencyDeviationTransmitter, @"^[-][0-9]{1,3}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min δf, Hz\"\n" +
                        "Пример: -999", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxFrequencyDeviationTransmitter, @"^[+][0-9]{1,3}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max δf, Hz\"\n" +
                        "Пример: +999", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSensitivityTransmitter, @"^[0-9]{1,2}[.][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ЧУВ, mV\"\n" +
                        "Пример: 7.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSensitivityTransmitter, @"^[0-9]{1,2}[.][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ЧУВ, mV\"\n" +
                        "Пример: 17.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinKNITransmitter, @"^[0][.][3][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min KNI, %\"\n" +
                        "Пример: 0.30", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxKNITransmitter, @"^[4][.][9][9]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max KNI, %\"\n" +
                        "Пример: 4.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinDeviationTransmitter, @"^[3][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ΔF, kHz\"\n" +
                        "Пример: 3.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxDeviationTransmitter, @"^[5][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ΔF, kHz\"\n" +
                        "Пример: 5.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinOutputPowerVoltReceiver, @"^[2][.][6][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min P НЧ, V\"\n" +
                        "Пример: 2.60", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxOutputPowerVoltReceiver, @"^[5][.][5][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max P НЧ, V\"\n" +
                        "Пример: 5.50", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinOutputPowerWattReceiver, @"^[0][.][4]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min P НЧ, W\"\n" +
                        "Пример: 0.4", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxOutputPowerWattReceiver, @"^[0][.][5]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max P НЧ, W\"\n" +
                        "Пример: 0.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSelectivityReceiver, @"^[7][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ИЗ, dB\"\n" +
                        "Пример: 70", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSelectivityReceiver, @"^[7][6]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ИЗ, dB\"\n" +
                        "Пример: 76", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSensitivityReceiver, @"^[0][.][1][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ЧУВ, mkV\"\n" +
                        "Пример: 0.10", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSensitivityReceiver, @"^[0][.][2][7]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ЧУВ, mkV\"\n" +
                        "Пример: 0.27", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinKNIReceiver, @"^[0][.][3][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min KNI, %\"\n" +
                        "Пример: 0.30", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxKNIReceiver, @"^[4][.][9][9]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max KNI, %\"\n" +
                        "Пример: 4.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSuppressorReceiver, @"^[0][.][1][1]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ЧУВ, mkV\"\n" +
                        "Пример: 0.11", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSuppressorReceiver, @"^[0][.][2][5]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Ш, mkV\"\n" +
                        "Пример: 0.25", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinStandbyModeCurrentConsumption, @"^[3-9]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Standby, mA\"\n" +
                        "Пример: 30", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxStandbyModeCurrentConsumption, @"^[1][1-5]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Standby, mA\"\n" +
                        "Пример: 150", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinReceptionModeCurrentConsumption, @"^[1][1-9]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Reception, mA\"\n" +
                        "Пример: 110", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxReceptionModeCurrentConsumption, @"^[4][1-9]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Reception, mA\"\n" +
                        "Пример: 490", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinTransmissionModeCurrentConsumption, @"^[1][.][1][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Transmission, A\"\n" +
                        "Пример: 1.10", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxTransmissionModeCurrentConsumption, @"^[1][.][9][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Transmission, A\"\n" +
                        "Пример: 1.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinBatteryDischargeAlarmCurrentConsumption, @"^[6][.][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Battery Discharge, V\"\n" +
                        "Пример: 6.0", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxBatteryDischargeAlarmCurrentConsumption, @"^[6][.][5]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Battery Discharge, V\"\n" +
                        "Пример: 6.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            #endregion

            if (_handbookParametersModelRadiostationRepository.ChangeHandbookParametersForModel(
                    Model, MinLowPowerLevelTransmitter, MaxLowPowerLevelTransmitter,
                    MinHighPowerLevelTransmitter, MaxHighPowerLevelTransmitter,
                    MinFrequencyDeviationTransmitter, MaxFrequencyDeviationTransmitter,
                    MinSensitivityTransmitter, MaxSensitivityTransmitter, MinKNITransmitter,
                    MaxKNITransmitter, MinDeviationTransmitter, MaxDeviationTransmitter,
                    MinOutputPowerVoltReceiver, MaxOutputPowerVoltReceiver,
                    MinOutputPowerWattReceiver, MaxOutputPowerWattReceiver,
                    MinSelectivityReceiver, MaxSelectivityReceiver, MinSensitivityReceiver,
                    MaxSensitivityReceiver, MinKNIReceiver, MaxKNIReceiver, MinSuppressorReceiver,
                    MaxSuppressorReceiver, MinStandbyModeCurrentConsumption,
                    MaxStandbyModeCurrentConsumption, MinReceptionModeCurrentConsumption,
                    MaxReceptionModeCurrentConsumption, MinTransmissionModeCurrentConsumption,
                    MaxTransmissionModeCurrentConsumption, MinBatteryDischargeAlarmCurrentConsumption,
                    MaxBatteryDischargeAlarmCurrentConsumption))
            {
                GetHandbookParametersAllModelForCollection();
                MessageBox.Show("Успешно!", "Информация",
                       MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show($"Ошибка изменения параметров модели!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region UpdateHandbookParametersForModel

        private void ExecuteUpdateHandbookParametersForModelCommand(object obj)
        {
            GetHandbookParametersAllModelForCollection();
        }

        #endregion

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
            if (String.IsNullOrWhiteSpace(MaxLowPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Max Low P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MinHighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Min High P, W\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(MaxHighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Max High P, W\" не должно быть пустым", "Отмена",
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

            if (!CheckBoxRepeater)
            {
                if (!Regex.IsMatch(MinLowPowerLevelTransmitter, @"^[2-2][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Low P, W\"\n" +
                        "Пример: 2.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxLowPowerLevelTransmitter, @"^[2-2][.][2][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Low P, W\"\n" +
                        "Пример: 2.20", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinHighPowerLevelTransmitter, @"^[2-2][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min High P, W\"\n" +
                        "Пример: 2.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxHighPowerLevelTransmitter, @"^[5][.][0-9]{2,2}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max High P, W\"\n" +
                        "Пример: 5.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinFrequencyDeviationTransmitter, @"^[-][0-9]{1,3}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min δf, Hz\"\n" +
                        "Пример: -999", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxFrequencyDeviationTransmitter, @"^[+][0-9]{1,3}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max δf, Hz\"\n" +
                        "Пример: +999", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSensitivityTransmitter, @"^[0-9]{1,2}[.][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ЧУВ, mV\"\n" +
                        "Пример: 7.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSensitivityTransmitter, @"^[0-9]{1,2}[.][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ЧУВ, mV\"\n" +
                        "Пример: 17.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinKNITransmitter, @"^[0][.][3][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min KNI, %\"\n" +
                        "Пример: 0.30", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxKNITransmitter, @"^[4][.][9][9]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max KNI, %\"\n" +
                        "Пример: 4.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinDeviationTransmitter, @"^[3][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ΔF, kHz\"\n" +
                        "Пример: 3.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxDeviationTransmitter, @"^[5][.][0][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ΔF, kHz\"\n" +
                        "Пример: 5.00", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinOutputPowerVoltReceiver, @"^[2][.][6][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min P НЧ, V\"\n" +
                        "Пример: 2.60", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxOutputPowerVoltReceiver, @"^[5][.][5][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max P НЧ, V\"\n" +
                        "Пример: 5.50", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinOutputPowerWattReceiver, @"^[0][.][4]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min P НЧ, W\"\n" +
                        "Пример: 0.4", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxOutputPowerWattReceiver, @"^[0][.][5]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max P НЧ, W\"\n" +
                        "Пример: 0.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSelectivityReceiver, @"^[7][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ИЗ, dB\"\n" +
                        "Пример: 70", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSelectivityReceiver, @"^[7][6]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ИЗ, dB\"\n" +
                        "Пример: 76", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSensitivityReceiver, @"^[0][.][1][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ЧУВ, mkV\"\n" +
                        "Пример: 0.10", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSensitivityReceiver, @"^[0][.][2][7]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max ЧУВ, mkV\"\n" +
                        "Пример: 0.27", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinKNIReceiver, @"^[0][.][3][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min KNI, %\"\n" +
                        "Пример: 0.30", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxKNIReceiver, @"^[4][.][9][9]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max KNI, %\"\n" +
                        "Пример: 4.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinSuppressorReceiver, @"^[0][.][1][1]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min ЧУВ, mkV\"\n" +
                        "Пример: 0.11", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxSuppressorReceiver, @"^[0][.][2][5]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Ш, mkV\"\n" +
                        "Пример: 0.25", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinStandbyModeCurrentConsumption, @"^[3-9]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Standby, mA\"\n" +
                        "Пример: 30", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxStandbyModeCurrentConsumption, @"^[1][1-5]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Standby, mA\"\n" +
                        "Пример: 150", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinReceptionModeCurrentConsumption, @"^[1][1-9]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Reception, mA\"\n" +
                        "Пример: 110", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxReceptionModeCurrentConsumption, @"^[4][1-9]{1,1}[0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Reception, mA\"\n" +
                        "Пример: 490", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinTransmissionModeCurrentConsumption, @"^[1][.][1][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Transmission, A\"\n" +
                        "Пример: 1.10", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxTransmissionModeCurrentConsumption, @"^[1][.][9][0-9]{1,1}$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Transmission, A\"\n" +
                        "Пример: 1.99", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MinBatteryDischargeAlarmCurrentConsumption, @"^[6][.][0]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Min Battery Discharge, V\"\n" +
                        "Пример: 6.0", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (!Regex.IsMatch(MaxBatteryDischargeAlarmCurrentConsumption, @"^[6][.][5]$"))
                {
                    MessageBox.Show("Введите корректно поле: \"Max Battery Discharge, V\"\n" +
                        "Пример: 6.5", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            #endregion


            if (!_handbookParametersModelRadiostationRepository.
                CheckModelInHandbookParameters(Model))
            {
                MessageBox.Show($"Нельзя добавить {Model}! Присутствует в справочнике с параметрами!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_handbookParametersModelRadiostationRepository.AddHandbookParametersForModel(
                    Model, MinLowPowerLevelTransmitter, MaxLowPowerLevelTransmitter,
                    MinHighPowerLevelTransmitter, MaxHighPowerLevelTransmitter,
                    MinFrequencyDeviationTransmitter, MaxFrequencyDeviationTransmitter,
                    MinSensitivityTransmitter, MaxSensitivityTransmitter, MinKNITransmitter,
                    MaxKNITransmitter, MinDeviationTransmitter, MaxDeviationTransmitter,
                    MinOutputPowerVoltReceiver, MaxOutputPowerVoltReceiver,
                    MinOutputPowerWattReceiver, MaxOutputPowerWattReceiver,
                    MinSelectivityReceiver, MaxSelectivityReceiver, MinSensitivityReceiver,
                    MaxSensitivityReceiver, MinKNIReceiver, MaxKNIReceiver, MinSuppressorReceiver,
                    MaxSuppressorReceiver, MinStandbyModeCurrentConsumption,
                    MaxStandbyModeCurrentConsumption, MinReceptionModeCurrentConsumption,
                    MaxReceptionModeCurrentConsumption, MinTransmissionModeCurrentConsumption,
                    MaxTransmissionModeCurrentConsumption, MinBatteryDischargeAlarmCurrentConsumption,
                    MaxBatteryDischargeAlarmCurrentConsumption))
            {
                GetHandbookParametersAllModelForCollection();
                MessageBox.Show("Успешно!", "Информация",
                       MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show($"Ошибка добавления параметров в справочник!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);

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
            TheIndexModelChoiceCollection = ModelCollections.Count - 1;
        }

        #endregion
    }
}
