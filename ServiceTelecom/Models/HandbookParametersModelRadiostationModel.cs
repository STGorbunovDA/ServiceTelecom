using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    internal class HandbookParametersModelRadiostationModel : ViewModelBase
    {
        private int _id;
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

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
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

        public HandbookParametersModelRadiostationModel(
            int idBase, string model, string minLowPowerLevelTransmitter, 
            string maxLowPowerLevelTransmitter, string minHighPowerLevelTransmitter, 
            string maxHighPowerLevelTransmitter, string minFrequencyDeviationTransmitter, 
            string maxFrequencyDeviationTransmitter, string minSensitivityTransmitter, 
            string maxSensitivityTransmitter, string minKNITransmitter, 
            string maxKNITransmitter, string minDeviationTransmitter, 
            string maxDeviationTransmitter, string minOutputPowerVoltReceiver, 
            string maxOutputPowerVoltReceiver, string minOutputPowerWattReceiver, 
            string maxOutputPowerWattReceiver, string minSelectivityReceiver, 
            string maxSelectivityReceiver, string minSensitivityReceiver, 
            string maxSensitivityReceiver, string minKNIReceiver,
            string maxKNIReceiver, string minSuppressorReceiver, 
            string maxSuppressorReceiver, string minStandbyModeCurrentConsumption, 
            string maxStandbyModeCurrentConsumption, 
            string minReceptionModeCurrentConsumption, 
            string maxReceptionModeCurrentConsumption, 
            string minTransmissionModeCurrentConsumption, 
            string maxTransmissionModeCurrentConsumption, 
            string minBatteryDischargeAlarmCurrentConsumption, 
            string maxBatteryDischargeAlarmCurrentConsumption)
        {
            IdBase = idBase;
            Model = Encryption.DecryptCipherTextToPlainText(model);
            MinLowPowerLevelTransmitter = 
                Encryption.DecryptCipherTextToPlainText(minLowPowerLevelTransmitter);
            MaxLowPowerLevelTransmitter = 
                Encryption.DecryptCipherTextToPlainText(maxLowPowerLevelTransmitter);
            MinHighPowerLevelTransmitter =
                Encryption.DecryptCipherTextToPlainText(minHighPowerLevelTransmitter);
            MaxHighPowerLevelTransmitter = 
                Encryption.DecryptCipherTextToPlainText(maxHighPowerLevelTransmitter);
            MinFrequencyDeviationTransmitter = 
                Encryption.DecryptCipherTextToPlainText(minFrequencyDeviationTransmitter);
            MaxFrequencyDeviationTransmitter = 
                Encryption.DecryptCipherTextToPlainText(maxFrequencyDeviationTransmitter);
            MinSensitivityTransmitter = 
                Encryption.DecryptCipherTextToPlainText(minSensitivityTransmitter);
            MaxSensitivityTransmitter = 
                Encryption.DecryptCipherTextToPlainText(maxSensitivityTransmitter);
            MinKNITransmitter = 
                Encryption.DecryptCipherTextToPlainText(minKNITransmitter);
            MaxKNITransmitter = 
                Encryption.DecryptCipherTextToPlainText(maxKNITransmitter);
            MinDeviationTransmitter = 
                Encryption.DecryptCipherTextToPlainText(minDeviationTransmitter);
            MaxDeviationTransmitter = 
                Encryption.DecryptCipherTextToPlainText(maxDeviationTransmitter);
            MinOutputPowerVoltReceiver = 
                Encryption.DecryptCipherTextToPlainText(minOutputPowerVoltReceiver);
            MaxOutputPowerVoltReceiver = 
                Encryption.DecryptCipherTextToPlainText(maxOutputPowerVoltReceiver);
            MinOutputPowerWattReceiver = 
                Encryption.DecryptCipherTextToPlainText(minOutputPowerWattReceiver);
            MaxOutputPowerWattReceiver = 
                Encryption.DecryptCipherTextToPlainText(maxOutputPowerWattReceiver);
            MinSelectivityReceiver = 
                Encryption.DecryptCipherTextToPlainText(minSelectivityReceiver);
            MaxSelectivityReceiver = 
                Encryption.DecryptCipherTextToPlainText(maxSelectivityReceiver);
            MinSensitivityReceiver = 
                Encryption.DecryptCipherTextToPlainText(minSensitivityReceiver);
            MaxSensitivityReceiver = 
                Encryption.DecryptCipherTextToPlainText(maxSensitivityReceiver);
            MinKNIReceiver = 
                Encryption.DecryptCipherTextToPlainText(minKNIReceiver);
            MaxKNIReceiver = 
                Encryption.DecryptCipherTextToPlainText(maxKNIReceiver);
            MinSuppressorReceiver = 
                Encryption.DecryptCipherTextToPlainText(minSuppressorReceiver);
            MaxSuppressorReceiver = 
                Encryption.DecryptCipherTextToPlainText(maxSuppressorReceiver);
            MinStandbyModeCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(minStandbyModeCurrentConsumption);
            MaxStandbyModeCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(maxStandbyModeCurrentConsumption);
            MinReceptionModeCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(minReceptionModeCurrentConsumption);
            MaxReceptionModeCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(maxReceptionModeCurrentConsumption);
            MinTransmissionModeCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(minTransmissionModeCurrentConsumption);
            MaxTransmissionModeCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(maxTransmissionModeCurrentConsumption);
            MinBatteryDischargeAlarmCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(minBatteryDischargeAlarmCurrentConsumption);
            MaxBatteryDischargeAlarmCurrentConsumption = 
                Encryption.DecryptCipherTextToPlainText(maxBatteryDischargeAlarmCurrentConsumption);
        }
    }
}
