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
                "испр.",
                "неиспр."
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
                {
                    BatteryChargerAccessories = "-";
                    IsEnabledChargerAccessories = false;
                } 
                else IsEnabledChargerAccessories = true;

                if (item.Manipulator == "-")
                {
                    ManipulatorAccessories = "-";
                    IsEnabledManipulatorAccessories = false;
                }
                else IsEnabledManipulatorAccessories = true;

                TheIndexBatteryChargerAccessories = -1;
                TheIndexManipulatorAccessories = -1;
                if (String.IsNullOrWhiteSpace(NameAKB))
                {
                    PercentAKB = "-";
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
                    
                    StandbyModeCurrentConsumption = item.StandbyModeCurrentConsumption;
                    ReceptionModeCurrentConsumption = item.ReceptionModeCurrentConsumption;
                    TransmissionModeCurrentConsumption =
                        item.TransmissionModeCurrentConsumption;
                    BatteryDischargeAlarmCurrentConsumption =
                        item.BatteryDischargeAlarmCurrentConsumption;

                    BatteryChargerAccessories = item.BatteryChargerAccessories;
                    if(!IsEnabledChargerAccessories && BatteryChargerAccessories == "испр.")
                        BatteryChargerAccessories = "-";
                    if (!IsEnabledChargerAccessories && BatteryChargerAccessories == "неиспр.")
                        BatteryChargerAccessories = "-";
                    if (IsEnabledChargerAccessories && BatteryChargerAccessories == "-")
                        TheIndexBatteryChargerAccessories = -1;
                    
                    ManipulatorAccessories = item.ManipulatorAccessories;
                    if (!IsEnabledManipulatorAccessories && ManipulatorAccessories == "испр.")
                        ManipulatorAccessories = "-";
                    if (!IsEnabledManipulatorAccessories && ManipulatorAccessories == "неиспр.")
                        ManipulatorAccessories = "-";
                    if (IsEnabledManipulatorAccessories && ManipulatorAccessories == "-")
                        TheIndexManipulatorAccessories = -1;

                    if (!IsEnablePercentAKB)
                        PercentAKB = "-";
                    else PercentAKB = item.PercentAKB;
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
            if (IsEnabledChargerAccessories)
            {
                if (String.IsNullOrWhiteSpace(BatteryChargerAccessories))
                {
                    MessageBox.Show("Поле \"З.У.\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else BatteryChargerAccessories = "-";
            if (IsEnabledManipulatorAccessories)
            {
                if (String.IsNullOrWhiteSpace(ManipulatorAccessories))
                {
                    MessageBox.Show("Поле \"МАН.\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else ManipulatorAccessories = "-";
            if (IsEnablePercentAKB)
            {
                if (String.IsNullOrWhiteSpace(PercentAKB))
                {
                    MessageBox.Show("Поле \"АКБ\" не должно быть пустым", "Отмена",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            else PercentAKB = "-";
            if (String.IsNullOrWhiteSpace(AllFrequenciesCompleted))
            {
                MessageBox.Show("Поле \"Частоты\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!Regex.IsMatch(LowPowerLevelTransmitter, @"^[2][.][0-9]{2,2}$"))
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
                    "Пример: от 5.5 до 18.0", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(KNITransmitter, @"^[0-4]{1,1}[.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"КНИ передатчика, %\"\n" +
                    "Пример: от 0.30 до 4.99", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DeviationTransmitter, @"^[4][.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Девиация, kHz.\"\n" +
                    "Пример: от 4.00 кГЦ. до 5.00 кГЦ.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(OutputPowerVoltReceiver, @"^[0-9]{1,1}[.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Выx. мощ., V.\"\n" +
                    "Пример: от 2.60 В. до 5.50 В.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(OutputPowerWattReceiver, @"^([0][.][4])?([0][.][5])*$"))
            {
                MessageBox.Show("Введите корректно поле: \"Выx. мощ., W.\"\n" +
                    "Пример: от 0.4 В. до 0.5 В.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(SelectivityReceiver, @"^[7-8][0-9]{1,1}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Избирательность, dB.\"\n" +
                    "Пример: от 70 dB. до 89 dB.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(SensitivityReceiver, @"^[0][.][1-2]{1,1}[0-9]{1,1}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Чувствительность, mkV.\"\n" +
                    "Пример: от 0.10 мкВ. до 0.29 мкВ.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(KNIReceiver, @"^[0-4]{1,1}[.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"КНИ приёмника, %\"\n" +
                    "Пример: от 0.30 до 4.99", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(SuppressorReceiver, @"^[0][.][1-2]{1,1}[0-9]{1,1}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Шумод., mkV.\"\n" +
                    "Пример: от 0.10 мкВ. до 0.29 мкВ.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(StandbyModeCurrentConsumption, @"^([3-9][0])?([1][1-5]{1,1}[0])*$"))
            {
                MessageBox.Show("Введите корректно поле: \"Деж. режим, мА.\"\n" +
                    "Пример: от 30 mA. до 150 mA.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(ReceptionModeCurrentConsumption, @"^[1-9]{1,1}[0-9]{1,1}[0]$"))
            {
                MessageBox.Show("Введите корректно поле: \"Реж. приём, мА.\"\n" +
                    "Пример: от 120 mA. до 460 mA.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(TransmissionModeCurrentConsumption, @"^[1][.][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле: \"Реж. передачи, A.\"\n" +
                    "Пример: от 1.00 A. до 1.99 A.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(BatteryDischargeAlarmCurrentConsumption, @"^[6][.][0-9]$"))
            {
                MessageBox.Show("Введите корректно поле: \"Разряд АКБ, V.\"\n" +
                    "Пример: от 6.0 V. до 6.5 V.", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            List<string> fList = new List<string>();
            string[] frequenciesArray = fList.ToArray();

            frequenciesArray = AllFrequenciesCompleted.Split(new string[] { "\n", "\r" }, StringSplitOptions.None);
            frequenciesArray = frequenciesArray.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            for (int i = 0; i < frequenciesArray.Length; i++)
            {
                if (!Regex.IsMatch(frequenciesArray[i], @"^[1][0-9]{2,2}[.][0-9]{3,3}$"))
                {
                    if (!Regex.IsMatch(frequenciesArray[i], @"^[1][0-9]{2,2}[.][0-9]{3,3}[/][1][0-9]{2,2}[.][0-9]{3,3}$"))
                    {
                        MessageBox.Show("Введите корректно частоту:\n" +
                            $"Пример: 151.825 или 155.700/151.825, № {i + 1}", "Отмена",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
            }


            foreach (var item in HandbookParametersModelRadiostationCollection)
            {
                try
                {
                    if (Convert.ToDouble(item.MinLowPowerLevelTransmitter) > Convert.ToDouble(LowPowerLevelTransmitter) ||
                       Convert.ToDouble(item.MaxLowPowerLevelTransmitter) < Convert.ToDouble(LowPowerLevelTransmitter))
                    {
                        MessageBox.Show("Введите корректно поле: \"Низкий, W.\"." +
                        $"Диапазон: от {item.MinLowPowerLevelTransmitter} W. " +
                        $"до {item.MaxLowPowerLevelTransmitter} W. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinHighPowerLevelTransmitter) > Convert.ToDouble(HighPowerLevelTransmitter) ||
                       Convert.ToDouble(item.MaxHighPowerLevelTransmitter) < Convert.ToDouble(HighPowerLevelTransmitter))
                    {
                        MessageBox.Show("Введите корректно поле: \"Высокий, W.\"." +
                        $"Диапазон: от {item.MinHighPowerLevelTransmitter} W. " +
                        $"до {item.MaxHighPowerLevelTransmitter} W. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToInt32(item.MinFrequencyDeviationTransmitter) > Convert.ToInt32(FrequencyDeviationTransmitter) ||
                       Convert.ToInt32(item.MaxFrequencyDeviationTransmitter) < Convert.ToInt32(FrequencyDeviationTransmitter))
                    {
                        MessageBox.Show("Введите корректно поле: \"Отклонение, Hz.\"." +
                        $"Диапазон: от {item.MinFrequencyDeviationTransmitter} Hz. " +
                        $"до {item.MaxFrequencyDeviationTransmitter} Hz. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinSensitivityTransmitter) > Convert.ToDouble(SensitivityTransmitter) ||
                       Convert.ToDouble(item.MaxSensitivityTransmitter) < Convert.ToDouble(SensitivityTransmitter))
                    {
                        MessageBox.Show("Введите корректно поле: \"Чувствительность передатчика, mV.\"." +
                        $"Диапазон: от {item.MinSensitivityTransmitter} mV. " +
                        $"до {item.MaxSensitivityTransmitter} mV. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinKNITransmitter) > Convert.ToDouble(KNITransmitter) ||
                       Convert.ToDouble(item.MaxKNITransmitter) < Convert.ToDouble(KNITransmitter))
                    {
                        MessageBox.Show("Введите корректно поле: \"КНИ передатчика, %\"." +
                        $"Диапазон: от {item.MinKNITransmitter} % " +
                        $"до {item.MaxKNITransmitter} % для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinDeviationTransmitter) > Convert.ToDouble(DeviationTransmitter) ||
                       Convert.ToDouble(item.MaxDeviationTransmitter) < Convert.ToDouble(DeviationTransmitter))
                    {
                        MessageBox.Show("Введите корректно поле: \"Девиация, kHz.\"." +
                        $"Диапазон: от {item.MinDeviationTransmitter} kHz. " +
                        $"до {item.MaxDeviationTransmitter} kHz. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinOutputPowerVoltReceiver) > Convert.ToDouble(OutputPowerVoltReceiver) ||
                       Convert.ToDouble(item.MaxOutputPowerVoltReceiver) < Convert.ToDouble(OutputPowerVoltReceiver))
                    {
                        MessageBox.Show("Введите корректно поле: \"Выx. мощ., V.\"." +
                        $"Диапазон: от {item.MinOutputPowerVoltReceiver} V. " +
                        $"до {item.MaxOutputPowerVoltReceiver} V. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinOutputPowerWattReceiver) > Convert.ToDouble(OutputPowerWattReceiver) ||
                       Convert.ToDouble(item.MaxOutputPowerWattReceiver) < Convert.ToDouble(OutputPowerWattReceiver))
                    {
                        MessageBox.Show("Введите корректно поле: \"Выx. мощ., W.\"." +
                        $"Диапазон: от {item.MinOutputPowerWattReceiver} W. " +
                        $"до {item.MaxOutputPowerWattReceiver} W. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinSelectivityReceiver) > Convert.ToDouble(SelectivityReceiver) ||
                       Convert.ToDouble(item.MaxSelectivityReceiver) < Convert.ToDouble(SelectivityReceiver))
                    {
                        MessageBox.Show("Введите корректно поле: \"Избирательность, dB.\"." +
                        $"Диапазон: от {item.MinSelectivityReceiver} dB. " +
                        $"до {item.MaxSelectivityReceiver} dB. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinSensitivityReceiver) > Convert.ToDouble(SensitivityReceiver) ||
                       Convert.ToDouble(item.MaxSensitivityReceiver) < Convert.ToDouble(SensitivityReceiver))
                    {
                        MessageBox.Show("Введите корректно поле: \"Чувствительность, mkV.\"." +
                        $"Диапазон: от {item.MinSensitivityReceiver} mkV. " +
                        $"до {item.MaxSensitivityReceiver} mkV. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinKNIReceiver) > Convert.ToDouble(KNIReceiver) ||
                       Convert.ToDouble(item.MaxKNIReceiver) < Convert.ToDouble(KNIReceiver))
                    {
                        MessageBox.Show("Введите корректно поле: \"КНИ передатчика, %\"." +
                        $"Диапазон: от {item.MinKNIReceiver} % " +
                        $"до {item.MaxKNIReceiver} % для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinSuppressorReceiver) > Convert.ToDouble(SuppressorReceiver) ||
                       Convert.ToDouble(item.MaxSuppressorReceiver) < Convert.ToDouble(SuppressorReceiver))
                    {
                        MessageBox.Show("Введите корректно поле: \"Шумод., mkV.\"." +
                        $"Диапазон: от {item.MinSuppressorReceiver} mkV. " +
                        $"до {item.MaxSuppressorReceiver} mkV. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinStandbyModeCurrentConsumption) > Convert.ToDouble(StandbyModeCurrentConsumption) ||
                       Convert.ToDouble(item.MaxStandbyModeCurrentConsumption) < Convert.ToDouble(StandbyModeCurrentConsumption))
                    {
                        MessageBox.Show("Введите корректно поле: \"Деж. режим, мА.\"." +
                        $"Диапазон: от {item.MinStandbyModeCurrentConsumption} mA. " +
                        $"до {item.MaxStandbyModeCurrentConsumption} mA. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinReceptionModeCurrentConsumption) > Convert.ToDouble(ReceptionModeCurrentConsumption) ||
                       Convert.ToDouble(item.MaxReceptionModeCurrentConsumption) < Convert.ToDouble(ReceptionModeCurrentConsumption))
                    {
                        MessageBox.Show("Введите корректно поле: \"Реж. приём, мА.\"." +
                        $"Диапазон: от {item.MinReceptionModeCurrentConsumption} mA. " +
                        $"до {item.MaxReceptionModeCurrentConsumption} mA. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinTransmissionModeCurrentConsumption) > Convert.ToDouble(TransmissionModeCurrentConsumption) ||
                       Convert.ToDouble(item.MaxTransmissionModeCurrentConsumption) < Convert.ToDouble(TransmissionModeCurrentConsumption))
                    {
                        MessageBox.Show("Введите корректно поле: \"Реж. передачи, A.\"." +
                        $"Диапазон: от {item.MinTransmissionModeCurrentConsumption} A. " +
                        $"до {item.MaxTransmissionModeCurrentConsumption} A. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    if (Convert.ToDouble(item.MinBatteryDischargeAlarmCurrentConsumption) > Convert.ToDouble(BatteryDischargeAlarmCurrentConsumption) ||
                       Convert.ToDouble(item.MaxBatteryDischargeAlarmCurrentConsumption) < Convert.ToDouble(BatteryDischargeAlarmCurrentConsumption))
                    {
                        MessageBox.Show("Введите корректно поле: \"Разряд АКБ, V.\"." +
                        $"Диапазон: от {item.MinBatteryDischargeAlarmCurrentConsumption} A. " +
                        $"до {item.MaxBatteryDischargeAlarmCurrentConsumption} V. для {Model}!",
                        "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show($"Системная ошибка! Convert.ToDouble в AddRadiostationParametersViewModel",
                       "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
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
                Road, City, dateMaintenanceDataBase, Location, Model, 
                SerialNumber, Company, NumberAct,
                LowPowerLevelTransmitter, HighPowerLevelTransmitter,
                FrequencyDeviationTransmitter, SensitivityTransmitter,
                KNITransmitter, DeviationTransmitter, OutputPowerVoltReceiver,
                OutputPowerWattReceiver, SelectivityReceiver, SensitivityReceiver,
                KNIReceiver, SuppressorReceiver, AllFrequenciesCompleted.Trim(),
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
                if (_radiostationParametersRepository.ChangeRadiostationParameters(
                    Road, City, dateMaintenanceDataBase, Location, Model, 
                    SerialNumber, Company, NumberAct,
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
