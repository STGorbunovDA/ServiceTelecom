using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddRadiostationParametersViewModel : ViewModelBase
    {
        RadiostationParametersRepository _radiostationParametersRepository;
        WorkRadiostantionRepository _workRadiostantionRepository;
        FrequenciesDataBaseRepository _frequenciesDataBase;

        AddFrequencyRadiostantionView addFrequencyRadiostantionView;
        public ObservableCollection<FrequencyModel> FrequenciesCollections { get; set; }

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

        private string _frequenciesCompletedForRadiostantion;
        public string FrequenciesCompletedForRadiostantion
        {
            get => _frequenciesCompletedForRadiostantion;
            set
            {
                _frequenciesCompletedForRadiostantion = value;
                OnPropertyChanged(nameof(FrequenciesCompletedForRadiostantion));
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
                    PercentAKB = "неисправен";
                    IsEnablePercentAKB = false;
                }
                else
                {
                    if (PercentAKB == "неисправен")
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

        public ICommand AddRadiostationParameters { get; }
        public ICommand ChangeStatusVerifiedRSTInRepair { get; }
        public ICommand AddFrequency { get; }
        public AddRadiostationParametersViewModel()
        {
            _radiostationParametersRepository = new RadiostationParametersRepository();
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _frequenciesDataBase = new FrequenciesDataBaseRepository();
            
            FrequenciesCollections = new ObservableCollection<FrequencyModel>();

            AddRadiostationParameters =
                 new ViewModelCommand(ExecuteAddRadiostationParametersCommand);

            ChangeStatusVerifiedRSTInRepair =
                new ViewModelCommand(ExecuteChangeStatusVerifiedRSTInRepairCommand);

            AddFrequency =
                new ViewModelCommand(ExecuteAddFrequencyCommand);

            foreach (RadiostationForDocumentsDataBaseModel item
                in UserModelStatic.RadiostationsForDocumentsMulipleSelectedDataGrid)
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

            if (UserModelStatic.ParametersRadiostationForAddRadiostationParametersView.Count != 0)
            {
                foreach (RadiostationParametersDataBaseModel item
                    in UserModelStatic.ParametersRadiostationForAddRadiostationParametersView)
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

                    FrequenciesCompletedForRadiostantion
                        = item.FrequenciesCompletedForRadiostantion;
                    if (FrequenciesCompletedForRadiostantion.Contains("/"))
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

                    if (PercentAKB == "неисправен")
                        CheckBoxFaultyAKB = true;
                    else CheckBoxFaultyAKB = false;

                    NoteRadioStationParameters = item.NoteRadioStationParameters;
                    if (NoteRadioStationParameters == null)
                        NoteRadioStationParameters = string.Empty;
                }
            }
            GetFrequencyDataBase();
        }

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
                addFrequencyRadiostantionView.Show();
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
                    UserModelStatic.InRepairTechnicalServices))
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
                KNIReceiver, SuppressorReceiver, FrequenciesCompletedForRadiostantion,
                StandbyModeCurrentConsumption, ReceptionModeCurrentConsumption,
                TransmissionModeCurrentConsumption, BatteryDischargeAlarmCurrentConsumption,
                BatteryChargerAccessories, ManipulatorAccessories, NameAKB, PercentAKB,
                NoteRadioStationParameters, UserModelStatic.PassedTechnicalServices))
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
                    KNIReceiver, SuppressorReceiver, FrequenciesCompletedForRadiostantion,
                    StandbyModeCurrentConsumption, ReceptionModeCurrentConsumption,
                    TransmissionModeCurrentConsumption, BatteryDischargeAlarmCurrentConsumption,
                    BatteryChargerAccessories, ManipulatorAccessories, NameAKB, PercentAKB,
                    NoteRadioStationParameters, UserModelStatic.PassedTechnicalServices))
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
                    UserModelStatic.PassedTechnicalServices))
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
            if (FrequenciesCollections.Count != 0)
                FrequenciesCollections.Clear();
            FrequenciesCollections =
                _frequenciesDataBase.GetFrequencyDataBase(FrequenciesCollections);
            FrequenciesCollections =
                new ObservableCollection<FrequencyModel>(FrequenciesCollections.OrderBy(i => i));
            TheIndexFrequencyCollection = FrequenciesCollections.Count - 1;
        }

        #endregion
    }
}
