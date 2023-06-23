﻿using ServiceTelecom.Models;
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
    internal class AddRadiostationParametersViewModel : ViewModelBase
    {
        RadiostationParametersRepository _radiostationParametersRepository;
        WorkRadiostantionRepository _workRadiostantionRepository;
        FrequenciesDataBaseRepository _frequenciesDataBaseRepository;
        HandbookParametersModelRadiostationRepository _handbookParametersModelRadiostationRepository;

        AddHandbookParametersView addHandbookParametersView;
        AddFrequencyRadiostantionView addFrequencyRadiostantionView;
        public ObservableCollection<FrequencyModel> FrequenciesCollection { get; set; }

        public ObservableCollection<HandbookParametersModelRadiostationModel>
            HandbookParametersModelRadiostationCollection
        { get; set; }

        public ObservableCollection<string> DefectiveFaultyCollection { get; set; }

        #region свойства

        public string Road { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string NameAKB { get; set; }

        private bool _isEnablePercentAKB;
        public bool IsEnablePercentAKB
        {
            get => _isEnablePercentAKB;
            set
            {
                _isEnablePercentAKB = value;
                OnPropertyChanged(nameof(IsEnablePercentAKB));
            }
        }

        private bool _isEnableCheckBoxFaultyAKB;
        public bool IsEnableCheckBoxFaultyAKB
        {
            get => _isEnableCheckBoxFaultyAKB;
            set
            {
                _isEnableCheckBoxFaultyAKB = value;
                OnPropertyChanged(nameof(IsEnableCheckBoxFaultyAKB));
            }
        }

        private bool _isEnabledChargerAccessories;
        public bool IsEnabledChargerAccessories
        {
            get => _isEnabledChargerAccessories;
            set
            {
                _isEnabledChargerAccessories = value;
                OnPropertyChanged(nameof(IsEnabledChargerAccessories));
            }
        }

        private bool _isEnabledManipulatorAccessories;
        public bool IsEnabledManipulatorAccessories
        {
            get => _isEnabledManipulatorAccessories;
            set
            {
                _isEnabledManipulatorAccessories = value;
                OnPropertyChanged(nameof(IsEnabledManipulatorAccessories));
            }
        }


        private string _dateMaintenance;
        public string DateMaintenance
        {
            get => _dateMaintenance;
            set
            {
                _dateMaintenance = value;
                OnPropertyChanged(nameof(DateMaintenance));
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

        private string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
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

        private string _lowPowerLevelTransmitter;
        public string LowPowerLevelTransmitter
        {
            get => _lowPowerLevelTransmitter;
            set
            {
                _lowPowerLevelTransmitter = value;
                OnPropertyChanged(nameof(LowPowerLevelTransmitter));
            }
        }

        private string _highPowerLevelTransmitter;
        public string HighPowerLevelTransmitter
        {
            get => _highPowerLevelTransmitter;
            set
            {
                _highPowerLevelTransmitter = value;
                OnPropertyChanged(nameof(HighPowerLevelTransmitter));
            }
        }

        private string _frequencyDeviationTransmitter;
        public string FrequencyDeviationTransmitter
        {
            get => _frequencyDeviationTransmitter;
            set
            {
                _frequencyDeviationTransmitter = value;
                OnPropertyChanged(nameof(FrequencyDeviationTransmitter));
            }
        }

        private string _sensitivityTransmitter;
        public string SensitivityTransmitter
        {
            get => _sensitivityTransmitter;
            set
            {
                _sensitivityTransmitter = value;
                OnPropertyChanged(nameof(SensitivityTransmitter));
            }
        }

        private string _kniTransmitter;
        public string KNITransmitter
        {
            get => _kniTransmitter;
            set
            {
                _kniTransmitter = value;
                OnPropertyChanged(nameof(KNITransmitter));
            }
        }

        private string _deviationTransmitter;
        public string DeviationTransmitter
        {
            get => _deviationTransmitter;
            set
            {
                _deviationTransmitter = value;
                OnPropertyChanged(nameof(DeviationTransmitter));
            }
        }

        private string _outputPowerVoltReceiver;
        public string OutputPowerVoltReceiver
        {
            get => _outputPowerVoltReceiver;
            set
            {
                _outputPowerVoltReceiver = value;
                OnPropertyChanged(nameof(OutputPowerVoltReceiver));
            }
        }

        private string _outputPowerWattReceiver;
        public string OutputPowerWattReceiver
        {
            get => _outputPowerWattReceiver;
            set
            {
                _outputPowerWattReceiver = value;
                OnPropertyChanged(nameof(OutputPowerWattReceiver));
            }
        }

        private string _selectivityReceiver;
        public string SelectivityReceiver
        {
            get => _selectivityReceiver;
            set
            {
                _selectivityReceiver = value;
                OnPropertyChanged(nameof(SelectivityReceiver));
            }
        }

        private string _sensitivityReceiver;
        public string SensitivityReceiver
        {
            get => _sensitivityReceiver;
            set
            {
                _sensitivityReceiver = value;
                OnPropertyChanged(nameof(SensitivityReceiver));
            }
        }

        private string _kniReceiver;
        public string KNIReceiver
        {
            get => _kniReceiver;
            set
            {
                _kniReceiver = value;
                OnPropertyChanged(nameof(KNIReceiver));
            }
        }

        private string _suppressorReceiver;
        public string SuppressorReceiver
        {
            get => _suppressorReceiver;
            set
            {
                _suppressorReceiver = value;
                OnPropertyChanged(nameof(SuppressorReceiver));
            }
        }

        private string _frequency;
        public string Frequency
        {
            get => _frequency;
            set
            {
                _frequency = value;
                OnPropertyChanged(nameof(Frequency));
            }
        }

        private string _allFrequenciesCompleted;
        public string AllFrequenciesCompleted
        {
            get => _allFrequenciesCompleted;
            set
            {
                _allFrequenciesCompleted = value;
                OnPropertyChanged(nameof(AllFrequenciesCompleted));
            }
        }

        private bool _checkBoxRepeater;
        public bool CheckBoxRepeater
        {
            get => _checkBoxRepeater;
            set
            {
                _checkBoxRepeater = value;
                OnPropertyChanged(nameof(CheckBoxRepeater));
            }
        }

        private string _standbyModeCurrentConsumption;
        public string StandbyModeCurrentConsumption
        {
            get => _standbyModeCurrentConsumption;
            set
            {
                _standbyModeCurrentConsumption = value;
                OnPropertyChanged(nameof(StandbyModeCurrentConsumption));
            }
        }

        private string _receptionModeCurrentConsumption;
        public string ReceptionModeCurrentConsumption
        {
            get => _receptionModeCurrentConsumption;
            set
            {
                _receptionModeCurrentConsumption = value;
                OnPropertyChanged(nameof(ReceptionModeCurrentConsumption));
            }
        }

        private string _transmissionModeCurrentConsumption;
        public string TransmissionModeCurrentConsumption
        {
            get => _transmissionModeCurrentConsumption;
            set
            {
                _transmissionModeCurrentConsumption = value;
                OnPropertyChanged(nameof(TransmissionModeCurrentConsumption));
            }
        }

        private string _batteryDischargeAlarmCurrentConsumption;
        public string BatteryDischargeAlarmCurrentConsumption
        {
            get => _batteryDischargeAlarmCurrentConsumption;
            set
            {
                _batteryDischargeAlarmCurrentConsumption = value;
                OnPropertyChanged(nameof(BatteryDischargeAlarmCurrentConsumption));
            }
        }

        private string _noteRadioStationParameters;
        public string NoteRadioStationParameters
        {
            get => _noteRadioStationParameters;
            set
            {
                _noteRadioStationParameters = value;
                OnPropertyChanged(nameof(NoteRadioStationParameters));
            }
        }

        private string _batteryChargerAccessories;
        public string BatteryChargerAccessories
        {
            get => _batteryChargerAccessories;
            set
            {
                _batteryChargerAccessories = value;
                OnPropertyChanged(nameof(BatteryChargerAccessories));
            }
        }

        private string _manipulatorAccessories;
        public string ManipulatorAccessories
        {
            get => _manipulatorAccessories;
            set
            {
                _manipulatorAccessories = value;
                OnPropertyChanged(nameof(ManipulatorAccessories));
            }
        }

        private string _percentAKB;
        public string PercentAKB
        {
            get => _percentAKB;
            set
            {
                _percentAKB = value;
                OnPropertyChanged(nameof(PercentAKB));
            }
        }

        private bool _checkBoxFaultyAKB;
        public bool CheckBoxFaultyAKB
        {
            get => _checkBoxFaultyAKB;
            set
            {
                _checkBoxFaultyAKB = value;
                if (value)
                {
                    PercentAKB = "0";
                    IsEnablePercentAKB = false;
                }
                else
                {
                    if (PercentAKB == "0")
                    {
                        PercentAKB = string.Empty;
                        IsEnablePercentAKB = true;
                    }
                }

                OnPropertyChanged(nameof(CheckBoxFaultyAKB));
            }
        }

        #endregion

        private int _theIndexFrequencyCollection;
        public int TheIndexFrequencyCollection
        {
            get => _theIndexFrequencyCollection;
            set
            {
                _theIndexFrequencyCollection = value;
                OnPropertyChanged(nameof(TheIndexFrequencyCollection));
            }
        }

        private int _theIndexBatteryChargerAccessories;
        public int TheIndexBatteryChargerAccessories
        {
            get => _theIndexBatteryChargerAccessories;
            set
            {
                _theIndexBatteryChargerAccessories = value;
                OnPropertyChanged(nameof(TheIndexBatteryChargerAccessories));
            }
        }
        private int _theIndexManipulatorAccessories;
        public int TheIndexManipulatorAccessories
        {
            get => _theIndexManipulatorAccessories;
            set
            {
                _theIndexManipulatorAccessories = value;
                OnPropertyChanged(nameof(TheIndexManipulatorAccessories));
            }
        }

        public ICommand AddRadiostationParameters { get; }
        public ICommand ChangeStatusVerifiedRSTInRepair { get; }
        public ICommand AddFrequency { get; }
        public ICommand HandbookAddRadiostationParameters { get; }
        public ICommand AddFrequencyInAllFrequenciesCompleted { get; }

        public AddRadiostationParametersViewModel()
        {
            _radiostationParametersRepository = new RadiostationParametersRepository();
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _frequenciesDataBaseRepository = new FrequenciesDataBaseRepository();
            
            _handbookParametersModelRadiostationRepository =
                new HandbookParametersModelRadiostationRepository();

            FrequenciesCollection = new ObservableCollection<FrequencyModel>();

            DefectiveFaultyCollection = new ObservableCollection<string>
            {
                "Исправно",
                "Неисправно"
            };

            HandbookParametersModelRadiostationCollection =
                new ObservableCollection<HandbookParametersModelRadiostationModel>();

            AddRadiostationParameters =
                 new ViewModelCommand(ExecuteAddRadiostationParametersCommand);

            ChangeStatusVerifiedRSTInRepair =
                new ViewModelCommand(ExecuteChangeStatusVerifiedRSTInRepairCommand);

            AddFrequency =
                new ViewModelCommand(ExecuteAddFrequencyCommand);

            HandbookAddRadiostationParameters =
                 new ViewModelCommand(ExecuteHandbookAddRadiostationParametersCommand);

            AddFrequencyInAllFrequenciesCompleted =
                new ViewModelCommand(ExecuteAddFrequencyInAllFrequenciesCompletedCommand);

            AssigningDataDocumentsFromRadiostationForDocumentsDataBaseModel();
            AssigningParametersInEditorsFromUserModelStaticParametersRadiostation();
            GetFrequencyDataBase();
            GetHandbookParametersModelRadiostationCollection();
            AssigningParametersInEditorsFromHandbookParameters();

            
        }

        #region AddFrequencyInAllFrequenciesCompleted

        private void ExecuteAddFrequencyInAllFrequenciesCompletedCommand(object obj)
        {
            if (Regex.IsMatch(Frequency,
                @"^[1][0-9]{1,1}[0-9]{1,1}[.][0-9]{1,1}[0-9]{1,1}[0-9]{1,1}$"))
            {
                if (String.IsNullOrWhiteSpace(AllFrequenciesCompleted))
                    AllFrequenciesCompleted = string.Empty;

                AllFrequenciesCompleted += Frequency + "\n";
            }
        }

        #endregion

        #region AssigningDataDocumentsFromRadiostationForDocumentsDataBaseModel

        private void AssigningDataDocumentsFromRadiostationForDocumentsDataBaseModel()
        {
            foreach (RadiostationForDocumentsDataBaseModel item
                in UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
            {
                Road = item.Road;
                City = item.City;
                DateMaintenance = item.DateMaintenance;
                Location = item.Location;
                Model = item.Model;
                SerialNumber = item.SerialNumber;
                Company = item.Company;
                NumberAct = item.NumberAct;
                NameAKB = item.Battery;
                NoteRadioStationParameters = item.Comment;

                if (item.Charger == "-")
                    IsEnabledChargerAccessories = false;
                else IsEnabledChargerAccessories = true;
                if (item.Manipulator == "-")
                    IsEnabledManipulatorAccessories = false;
                else IsEnabledManipulatorAccessories = true;

                TheIndexBatteryChargerAccessories = -1;
                TheIndexManipulatorAccessories = -1;
                if (String.IsNullOrWhiteSpace(NameAKB))
                {
                    IsEnablePercentAKB = false;
                    IsEnableCheckBoxFaultyAKB = false;
                }
                else
                {
                    IsEnablePercentAKB = true;
                    IsEnableCheckBoxFaultyAKB = true;
                }
            }
        }


        #endregion

        #region AssigningParametersInEditorsFromUserModelStatic

        private void AssigningParametersInEditorsFromUserModelStaticParametersRadiostation()
        {
            if (UserModelStatic.PARAMETERS_RADIOSTATION_FOR_ADD_RADIOSTATION_PARAMETERS_VIEW.Count != 0)
            {
                foreach (RadiostationParametersDataBaseModel item
                    in UserModelStatic.PARAMETERS_RADIOSTATION_FOR_ADD_RADIOSTATION_PARAMETERS_VIEW)
                {

                    LowPowerLevelTransmitter = item.LowPowerLevelTransmitter;
                    HighPowerLevelTransmitter = item.HighPowerLevelTransmitter;
                    FrequencyDeviationTransmitter = item.FrequencyDeviationTransmitter;
                    SensitivityTransmitter = item.SensitivityTransmitter;
                    KNITransmitter = item.KNITransmitter;
                    DeviationTransmitter = item.DeviationTransmitter;

                    OutputPowerVoltReceiver = item.OutputPowerVoltReceiver;
                    OutputPowerWattReceiver = item.OutputPowerWattReceiver;
                    SelectivityReceiver = item.SelectivityReceiver;
                    SensitivityReceiver = item.SensitivityReceiver;
                    KNIReceiver = item.KNIReceiver;
                    SuppressorReceiver = item.SuppressorReceiver;

                    AllFrequenciesCompleted
                        = item.FrequenciesCompletedForRadiostantion;
                    if (AllFrequenciesCompleted.Contains("/"))
                        CheckBoxRepeater = true;
                    else CheckBoxRepeater = false;

                    StandbyModeCurrentConsumption = item.StandbyModeCurrentConsumption;
                    ReceptionModeCurrentConsumption = item.ReceptionModeCurrentConsumption;
                    TransmissionModeCurrentConsumption =
                        item.TransmissionModeCurrentConsumption;
                    BatteryDischargeAlarmCurrentConsumption =
                        item.BatteryDischargeAlarmCurrentConsumption;

                    BatteryChargerAccessories = item.BatteryChargerAccessories;
                    if (BatteryChargerAccessories == null)
                        BatteryChargerAccessories = string.Empty;

                    ManipulatorAccessories = item.ManipulatorAccessories;
                    if (ManipulatorAccessories == null)
                        ManipulatorAccessories = string.Empty;

                    PercentAKB = item.PercentAKB;
                    if (PercentAKB == null)
                        PercentAKB = string.Empty;

                    if (PercentAKB == "0")
                        CheckBoxFaultyAKB = true;
                    else CheckBoxFaultyAKB = false;

                    NoteRadioStationParameters = item.NoteRadioStationParameters;
                    if (NoteRadioStationParameters == null)
                        NoteRadioStationParameters = string.Empty;
                }
            }
        }


        #endregion

        #region AssigningParametersInEditorsFromHandbookParameters

        private void AssigningParametersInEditorsFromHandbookParameters()
        {
            if (!String.IsNullOrWhiteSpace(LowPowerLevelTransmitter))
                return;

            if (HandbookParametersModelRadiostationCollection.Count == 0)
                return;

            foreach (var item in HandbookParametersModelRadiostationCollection)
            {
                LowPowerLevelTransmitter = item.MinLowPowerLevelTransmitter;
                HighPowerLevelTransmitter = item.MaxHighPowerLevelTransmitter;
                FrequencyDeviationTransmitter = item.MinFrequencyDeviationTransmitter;
                SensitivityTransmitter = item.MinSensitivityTransmitter;
                KNITransmitter = item.MinKNITransmitter;
                DeviationTransmitter = item.MaxDeviationTransmitter;
                OutputPowerVoltReceiver = item.MaxOutputPowerVoltReceiver;
                OutputPowerWattReceiver = item.MaxOutputPowerWattReceiver;
                SelectivityReceiver = item.MaxSelectivityReceiver;
                SensitivityReceiver = item.MaxSensitivityReceiver;
                KNIReceiver = item.MinKNIReceiver;
                SuppressorReceiver = item.MinSuppressorReceiver;
                StandbyModeCurrentConsumption = item.MinStandbyModeCurrentConsumption;
                ReceptionModeCurrentConsumption = item.MaxReceptionModeCurrentConsumption;
                TransmissionModeCurrentConsumption = item.MaxTransmissionModeCurrentConsumption;
                BatteryDischargeAlarmCurrentConsumption = item.MinBatteryDischargeAlarmCurrentConsumption;
            }
        }

        #endregion

        #region HandbookAddRadiostationParameters

        private void ExecuteHandbookAddRadiostationParametersCommand(object obj)
        {
            if (UserModelStatic.LOGIN != "Admin")
                return;
            if (addHandbookParametersView == null)
            {
                addHandbookParametersView = new AddHandbookParametersView();
                addHandbookParametersView.Closed += (sender, args) =>
                addHandbookParametersView = null;
                addHandbookParametersView.Closed += (sender, args) =>
                GetHandbookParametersModelRadiostationCollection();
                addHandbookParametersView.Show();
            }
        }

        #endregion

        #region AddFrequency

        private void ExecuteAddFrequencyCommand(object obj)
        {
            if (addFrequencyRadiostantionView == null)
            {
                addFrequencyRadiostantionView = new AddFrequencyRadiostantionView();
                addFrequencyRadiostantionView.Closed += (sender, args) =>
                addFrequencyRadiostantionView = null;
                addFrequencyRadiostantionView.Closed += (sender, args) =>
                GetFrequencyDataBase();
                addFrequencyRadiostantionView.Closed += (sender, args) =>
                AssigningAllFrequenciesCompletedForUserModelStaticFrequency();
                addFrequencyRadiostantionView.Show();
            }
        }

        #endregion

        #region AssigningAllFrequenciesCompletedForUserModelStaticFrequency

        private void AssigningAllFrequenciesCompletedForUserModelStaticFrequency()
        {
            if (!String.IsNullOrWhiteSpace(UserModelStatic.FREQUENCY))
            {
                AllFrequenciesCompleted += UserModelStatic.FREQUENCY + "\n";
                UserModelStatic.FREQUENCY = null;
            }
        }

        #endregion

        #region ChangeStatusVerifiedRSTInRepairInRadiostationForDocumentIn

        private void ExecuteChangeStatusVerifiedRSTInRepairCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(NoteRadioStationParameters))
            {
                MessageBox.Show($"При добавлении в ремонт, поле \"Примечание\" не должно быть пустым",
                   "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Regex re = new Regex(Environment.NewLine);
            NoteRadioStationParameters = re.Replace(NoteRadioStationParameters, " ");
            NoteRadioStationParameters.Trim();

            if (_workRadiostantionRepository.ChangeStatusVerifiedRST(
                    Road, City, SerialNumber, NoteRadioStationParameters,
                    UserModelStatic.IN_REPAIR_TECHNICAL_SERVICES))
            { }
            else
            {
                MessageBox.Show($"Ошибка добавления статуса \"в ремонт\" в " +
                    $"radiostantion(рабочая таблица) и в radiostantionFull(общая таблица)",
                   "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region AddRadiostationParameters

        private void ExecuteAddRadiostationParametersCommand(object obj)
        {

            #region проверка контролов 

            if (String.IsNullOrWhiteSpace(LowPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Низкий, W.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(HighPowerLevelTransmitter))
            {
                MessageBox.Show("Поле \"Высокий, W.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(FrequencyDeviationTransmitter))
            {
                MessageBox.Show("Поле \"Отклонение, Hz.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(SensitivityTransmitter))
            {
                MessageBox.Show("Поле \"Чувствительность, mV.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(KNITransmitter))
            {
                MessageBox.Show("Поле \"КНИ передатчика, %. \" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(DeviationTransmitter))
            {
                MessageBox.Show("Девиация, kHz.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(OutputPowerVoltReceiver))
            {
                MessageBox.Show("Выx. мощ., V.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(OutputPowerWattReceiver))
            {
                MessageBox.Show("Выx. мощ., W.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(SelectivityReceiver))
            {
                MessageBox.Show("Избирательность, dB.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(SensitivityReceiver))
            {
                MessageBox.Show("Чувствительность, mkV.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(KNIReceiver))
            {
                MessageBox.Show("Поле \"КНИ приёмника, %.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(SuppressorReceiver))
            {
                MessageBox.Show("Поле \"Шумод., mkV.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(StandbyModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Деж. режим, мА.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(ReceptionModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Реж. приём, мА.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(TransmissionModeCurrentConsumption))
            {
                MessageBox.Show("Поле \"Реж. передачи, A.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (String.IsNullOrWhiteSpace(BatteryDischargeAlarmCurrentConsumption))
            {
                MessageBox.Show("Поле \"Разряд АКБ, V.\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(IsEnabledChargerAccessories)
            {
                if (String.IsNullOrWhiteSpace(BatteryChargerAccessories))
                {
                    MessageBox.Show("Поле \"З.У.\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (IsEnabledManipulatorAccessories)
            {
                if (String.IsNullOrWhiteSpace(ManipulatorAccessories))
                {
                    MessageBox.Show("Поле \"МАН.\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (IsEnablePercentAKB)
            {
                if (String.IsNullOrWhiteSpace(PercentAKB))
                {
                    MessageBox.Show("Поле \"АКБ\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            if (String.IsNullOrWhiteSpace(AllFrequenciesCompleted))
            {
                MessageBox.Show("Поле \"Частоты\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!Regex.IsMatch(LowPowerLevelTransmitter, @"^[2][.][0-9]{1,1}[0-9]$"))
            {
                MessageBox.Show("Введите корректно поле: \"Низкий, W.\"\n" +
                    "Пример: от 2.00 Вт. до 2.99 Вт.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(HighPowerLevelTransmitter, @"^[2-5]{1,1}[.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Высокий, W.\"\n" +
                    "Пример: от 2.00 Вт. до 5.99 Вт.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(FrequencyDeviationTransmitter, @"^[+?-][0-9]{1,3}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Отклонение, Hz.\"\n" +
                    "Пример: от -999 до +900", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(SensitivityTransmitter, @"^[0-9]{1,2}[.][0-9]{1,1}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Чувствительность передатчика, mV.\"\n" +
                    "Пример: от 7.5 до 18.0", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(KNITransmitter, @"^[0-4]{1,1}[.][0-9]{1,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"КНИ передатчика, %\"\n" +
                    "Пример: от 0.30 до 4.99", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DeviationTransmitter, @"^[4]{1,1}[.][0-9]{1,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Девиация, kHz.\"\n" +
                    "Пример: от 4.00 кГЦ. до 5.00 кГЦ.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }



            foreach (var item in HandbookParametersModelRadiostationCollection)
            {
                if(Convert.ToDouble(item.MinLowPowerLevelTransmitter) > Convert.ToDouble(LowPowerLevelTransmitter) ||
                   Convert.ToDouble(item.MaxLowPowerLevelTransmitter) < Convert.ToDouble(LowPowerLevelTransmitter))
                {
                    MessageBox.Show("Введите корректно поле: \"Низкий, W.\"." +
                    $"Диапазон: от {item.MinLowPowerLevelTransmitter} Вт. " +
                    $"до {item.MaxLowPowerLevelTransmitter} Вт. для {Model}!", 
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (Convert.ToDouble(item.MinHighPowerLevelTransmitter) > Convert.ToDouble(HighPowerLevelTransmitter) ||
                   Convert.ToDouble(item.MaxHighPowerLevelTransmitter) < Convert.ToDouble(HighPowerLevelTransmitter))
                {
                    MessageBox.Show("Введите корректно поле: \"Высокий, W.\"." +
                    $"Диапазон: от {item.MinHighPowerLevelTransmitter} Вт. " +
                    $"до {item.MaxHighPowerLevelTransmitter} Вт. для {Model}!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (Convert.ToInt32(item.MinFrequencyDeviationTransmitter) > Convert.ToInt32(FrequencyDeviationTransmitter) ||
                   Convert.ToInt32(item.MaxFrequencyDeviationTransmitter) < Convert.ToInt32(FrequencyDeviationTransmitter))
                {
                    MessageBox.Show("Введите корректно поле: \"Отклонение, Hz.\"." +
                    $"Диапазон: от {item.MinFrequencyDeviationTransmitter} Вт. " +
                    $"до {item.MaxFrequencyDeviationTransmitter} Вт. для {Model}!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (Convert.ToDouble(item.MinSensitivityTransmitter) > Convert.ToDouble(SensitivityTransmitter) ||
                   Convert.ToDouble(item.MaxSensitivityTransmitter) < Convert.ToDouble(SensitivityTransmitter))
                {
                    MessageBox.Show("Введите корректно поле: \"Чувствительность передатчика, mV.\"." +
                    $"Диапазон: от {item.MinSensitivityTransmitter} Вт. " +
                    $"до {item.MaxSensitivityTransmitter} Вт. для {Model}!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (Convert.ToDouble(item.MinKNITransmitter) > Convert.ToDouble(KNITransmitter) ||
                   Convert.ToDouble(item.MaxKNITransmitter) < Convert.ToDouble(KNITransmitter))
                {
                    MessageBox.Show("Введите корректно поле: \"КНИ передатчика, %\"." +
                    $"Диапазон: от {item.MinKNITransmitter} Вт. " +
                    $"до {item.MaxKNITransmitter} Вт. для {Model}!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (Convert.ToDouble(item.MinDeviationTransmitter) > Convert.ToDouble(DeviationTransmitter) ||
                   Convert.ToDouble(item.MaxDeviationTransmitter) < Convert.ToDouble(DeviationTransmitter))
                {
                    MessageBox.Show("Введите корректно поле: \"Девиация, kHz.\"." +
                    $"Диапазон: от {item.MinDeviationTransmitter} Вт. " +
                    $"до {item.MaxDeviationTransmitter} Вт. для {Model}!",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            #endregion


            string dateMaintenanceDataBase =
                Convert.ToDateTime(DateMaintenance).ToString("yyyy-MM-dd");

            Regex re = new Regex(Environment.NewLine);
            NoteRadioStationParameters = re.Replace(NoteRadioStationParameters, " ");
            NoteRadioStationParameters.Trim();

            if (!_radiostationParametersRepository.
                CheckSerialNumberInRadiostationParameters(Road, SerialNumber))
            {
                if (_radiostationParametersRepository.AddRadiostationParameters(
                Road, City, dateMaintenanceDataBase, Location, Model, SerialNumber, Company, NumberAct,
                LowPowerLevelTransmitter, HighPowerLevelTransmitter,
                FrequencyDeviationTransmitter, SensitivityTransmitter,
                KNITransmitter, DeviationTransmitter, OutputPowerVoltReceiver,
                OutputPowerWattReceiver, SelectivityReceiver, SensitivityReceiver,
                KNIReceiver, SuppressorReceiver, AllFrequenciesCompleted,
                StandbyModeCurrentConsumption, ReceptionModeCurrentConsumption,
                TransmissionModeCurrentConsumption, BatteryDischargeAlarmCurrentConsumption,
                BatteryChargerAccessories, ManipulatorAccessories, NameAKB, PercentAKB,
                NoteRadioStationParameters, UserModelStatic.PASSED_TECHNICAL_SERVICES))
                { }
                else
                {
                    MessageBox.Show($"Ошибка добавления параметров",
                       "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                if (_radiostationParametersRepository.ChangeRadiostationInRadiostationParameters(
                    Road, City, dateMaintenanceDataBase, Location, Model, SerialNumber, Company, NumberAct,
                    LowPowerLevelTransmitter, HighPowerLevelTransmitter,
                    FrequencyDeviationTransmitter, SensitivityTransmitter,
                    KNITransmitter, DeviationTransmitter, OutputPowerVoltReceiver,
                    OutputPowerWattReceiver, SelectivityReceiver, SensitivityReceiver,
                    KNIReceiver, SuppressorReceiver, AllFrequenciesCompleted,
                    StandbyModeCurrentConsumption, ReceptionModeCurrentConsumption,
                    TransmissionModeCurrentConsumption, BatteryDischargeAlarmCurrentConsumption,
                    BatteryChargerAccessories, ManipulatorAccessories, NameAKB, PercentAKB,
                    NoteRadioStationParameters, UserModelStatic.PASSED_TECHNICAL_SERVICES))
                { }
                else
                {
                    MessageBox.Show($"Ошибка изменения параметров",
                       "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (_workRadiostantionRepository.ChangeStatusVerifiedRST(
                    Road, City, SerialNumber, NoteRadioStationParameters,
                    UserModelStatic.PASSED_TECHNICAL_SERVICES))
            { }
            else
            {
                MessageBox.Show($"Ошибка добавления статуса \"прошла проверку\" в " +
                    $"radiostantion(рабочая таблица) и в radiostantionFull(общую таблицу)",
                   "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);

        }


        #endregion

        #region GetFrequencyDataBase

        private void GetFrequencyDataBase()
        {
            TheIndexFrequencyCollection = -1;
            if (FrequenciesCollection.Count != 0)
                FrequenciesCollection.Clear();
            FrequenciesCollection =
                _frequenciesDataBaseRepository.GetFrequencyDataBase(FrequenciesCollection);
            TheIndexFrequencyCollection = FrequenciesCollection.Count - 1;
        }

        #endregion

        #region GetHandbookParametersModelRadiostationCollection

        private void GetHandbookParametersModelRadiostationCollection()
        {
            if (String.IsNullOrWhiteSpace(Model))
            {
                MessageBox.Show($"Модель пуста",
                  "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (HandbookParametersModelRadiostationCollection.Count != 0)
                HandbookParametersModelRadiostationCollection.Clear();
            HandbookParametersModelRadiostationCollection =
                _handbookParametersModelRadiostationRepository.
                GetHandbookParametersByModelForCollection(
                    HandbookParametersModelRadiostationCollection, Model);
            if (HandbookParametersModelRadiostationCollection.Count == 0)
            {
                MessageBox.Show($"Отсутствует справочник на модель радиостанции. " +
                    $"Сохранение параметров невозможно!",
                  "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        #endregion
    }
}
