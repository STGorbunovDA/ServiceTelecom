using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddHandbookParametersViewModel : ViewModelBase
    {
        HandbookParametersModelRadiostationRepository _handbookParametersModelRadiostationRepository;

        public ObservableCollection<HandbookParametersModelRadiostationModel>
           HandbookParametersAllModelRadiostationCollection
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

        public AddHandbookParametersViewModel()
        {
            _handbookParametersModelRadiostationRepository 
                = new HandbookParametersModelRadiostationRepository();
            HandbookParametersAllModelRadiostationCollection = 
                new ObservableCollection<HandbookParametersModelRadiostationModel>();
        }
    }
}
