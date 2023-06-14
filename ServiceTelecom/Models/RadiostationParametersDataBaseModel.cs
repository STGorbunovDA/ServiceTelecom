using ServiceTelecom.ViewModels;
using System.Windows.Shapes;

namespace ServiceTelecom.Models
{
    internal class RadiostationParametersDataBaseModel : ViewModelBase
    {
        private int _id;
        private string _road;
        private string _city;
        private string _company;
        private string _location;
        private string _numberAct;
        private string _serialNumber;
        private string _dateMaintenance;
        private string _model;
        private string _lowPowerLevelTransmitter;
        private string _highPowerLevelTransmitter;
        private string _frequencyDeviationTransmitter;
        private string _sensitivityTransmitter;
        private string _kniTransmitter;
        private string _deviationTransmitter;
        private string _outputPowerVoltReceiver;
        private string _outputPowerWattReceiver;
        private string _selectivityReceiver;
        private string _sensitivityReceiver;
        private string _kniReceiver;
        private string _suppressorReceiver;
        private string _standbyModeCurrentConsumption;
        private string _receptionModeCurrentConsumption;
        private string _transmissionModeCurrentConsumption;
        private string _batteryDischargeAlarmCurrentConsumption;
        private string _transmitterFrequencies;
        private string _receiverFrequencies;
        private string _batteryChargerAccessories;
        private string _manipulatorAccessories;
        private string _nameAKB;
        private string _percentAKB;
        private string _noteRadioStationParameters;
        private string _verifiedRST;

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }
        public string Company { get => _company; set { _company = value; OnPropertyChanged(nameof(Company)); } }
        public string Location { get => _location; set { _location = value; OnPropertyChanged(nameof(Location)); } }
        public string NumberAct { get => _numberAct; set { _numberAct = value; OnPropertyChanged(nameof(NumberAct)); } }
        public string SerialNumber { get => _serialNumber; set { _serialNumber = value; OnPropertyChanged(nameof(SerialNumber)); } }
        public string DateMaintenance { get => _dateMaintenance; set { _dateMaintenance = value; OnPropertyChanged(nameof(DateMaintenance)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }
        public string LowPowerLevelTransmitter { get => _lowPowerLevelTransmitter; set { _lowPowerLevelTransmitter = value; OnPropertyChanged(nameof(LowPowerLevelTransmitter)); } }
        public string HighPowerLevelTransmitter { get => _highPowerLevelTransmitter; set { _highPowerLevelTransmitter = value; OnPropertyChanged(nameof(HighPowerLevelTransmitter)); } }
        public string FrequencyDeviationTransmitter { get => _frequencyDeviationTransmitter; set { _frequencyDeviationTransmitter = value; OnPropertyChanged(nameof(FrequencyDeviationTransmitter)); } }
        public string SensitivityTransmitter { get => _sensitivityTransmitter; set { _sensitivityTransmitter = value; OnPropertyChanged(nameof(SensitivityTransmitter)); } }
        public string KniTransmitter { get => _kniTransmitter; set { _kniTransmitter = value; OnPropertyChanged(nameof(KniTransmitter)); } }
        public string DeviationTransmitter { get => _deviationTransmitter; set { _deviationTransmitter = value; OnPropertyChanged(nameof(DeviationTransmitter)); } }
        public string OutputPowerVoltReceiver { get => _outputPowerVoltReceiver; set { _outputPowerVoltReceiver = value; OnPropertyChanged(nameof(OutputPowerVoltReceiver)); } }
        public string OutputPowerWattReceiver { get => _outputPowerWattReceiver; set { _outputPowerWattReceiver = value; OnPropertyChanged(nameof(OutputPowerWattReceiver)); } }
        public string SelectivityReceiver { get => _selectivityReceiver; set { _selectivityReceiver = value; OnPropertyChanged(nameof(SelectivityReceiver)); } }
        public string SensitivityReceiver { get => _sensitivityReceiver; set { _sensitivityReceiver = value; OnPropertyChanged(nameof(SensitivityReceiver)); } }
        public string KniReceiver { get => _kniReceiver; set { _kniReceiver = value; OnPropertyChanged(nameof(KniReceiver)); } }
        public string SuppressorReceiver { get => _suppressorReceiver; set { _suppressorReceiver = value; OnPropertyChanged(nameof(SuppressorReceiver)); } }
        public string StandbyModeCurrentConsumption { get => _standbyModeCurrentConsumption; set { _standbyModeCurrentConsumption = value; OnPropertyChanged(nameof(StandbyModeCurrentConsumption)); } }
        public string ReceptionModeCurrentConsumption { get => _receptionModeCurrentConsumption; set { _receptionModeCurrentConsumption = value; OnPropertyChanged(nameof(ReceptionModeCurrentConsumption)); } }
        public string TransmissionModeCurrentConsumption { get => _transmissionModeCurrentConsumption; set { _transmissionModeCurrentConsumption = value; OnPropertyChanged(nameof(TransmissionModeCurrentConsumption)); } }
        public string BatteryDischargeAlarmCurrentConsumption { get => _batteryDischargeAlarmCurrentConsumption; set { _batteryDischargeAlarmCurrentConsumption = value; OnPropertyChanged(nameof(BatteryDischargeAlarmCurrentConsumption)); } }
        public string TransmitterFrequencies { get => _transmitterFrequencies; set { _transmitterFrequencies = value; OnPropertyChanged(nameof(TransmitterFrequencies)); } }
        public string ReceiverFrequencies { get => _receiverFrequencies; set { _receiverFrequencies = value; OnPropertyChanged(nameof(ReceiverFrequencies)); } }
        public string BatteryChargerAccessories { get => _batteryChargerAccessories; set { _batteryChargerAccessories = value; OnPropertyChanged(nameof(BatteryChargerAccessories)); } }
        public string ManipulatorAccessories { get => _manipulatorAccessories; set { _manipulatorAccessories = value; OnPropertyChanged(nameof(ManipulatorAccessories)); } }
        public string NameAKB { get => _nameAKB; set { _nameAKB = value; OnPropertyChanged(nameof(NameAKB)); } }
        public string PercentAKB { get => _percentAKB; set { _percentAKB = value; OnPropertyChanged(nameof(PercentAKB)); } }
        public string NoteRadioStationParameters { get => _noteRadioStationParameters; set { _noteRadioStationParameters = value; OnPropertyChanged(nameof(NoteRadioStationParameters)); } }
        public string VerifiedRST { get => _verifiedRST; set { _verifiedRST = value; OnPropertyChanged(nameof(VerifiedRST)); } }

        public RadiostationParametersDataBaseModel(
                int idBase, string road, string city, string company,
                string location, string numberAct, string serialNumber,
                string dateMaintenance, string model, string lowPowerLevelTransmitter,
                string highPowerLevelTransmitter, string frequencyDeviationTransmitter,
                string sensitivityTransmitter, string kniTransmitter,
                string deviationTransmitter, string outputPowerVoltReceiver,
                string outputPowerWattReceiver, string selectivityReceiver,
                string sensitivityReceiver, string kniReceiver, string suppressorReceiver,
                string standbyModeCurrentConsumption, string receptionModeCurrentConsumption,
                string transmissionModeCurrentConsumption,
                string batteryDischargeAlarmCurrentConsumption,
                string transmitterFrequencies, string receiverFrequencies,
                string batteryChargerAccessories, string manipulatorAccessories,
                string nameAKB, string percentAKB, string noteRadioStationParameters,
                string verifiedRST)
        {
            IdBase = idBase;
            Road = road;
            City = city;
            Company = company;
            Location = location;
            NumberAct = numberAct;
            SerialNumber = serialNumber;
            DateMaintenance = dateMaintenance;
            Model = model;
            LowPowerLevelTransmitter = lowPowerLevelTransmitter;
            HighPowerLevelTransmitter = highPowerLevelTransmitter;
            FrequencyDeviationTransmitter = frequencyDeviationTransmitter;
            SensitivityTransmitter = sensitivityTransmitter;
            KniTransmitter = kniTransmitter;
            DeviationTransmitter = deviationTransmitter;
            OutputPowerVoltReceiver = outputPowerVoltReceiver;
            OutputPowerWattReceiver = outputPowerWattReceiver;
            SelectivityReceiver = selectivityReceiver;
            SensitivityReceiver = sensitivityReceiver;
            KniReceiver = kniReceiver;
            SuppressorReceiver = suppressorReceiver;
            StandbyModeCurrentConsumption = standbyModeCurrentConsumption;
            ReceptionModeCurrentConsumption = receptionModeCurrentConsumption;
            TransmissionModeCurrentConsumption = transmissionModeCurrentConsumption;
            BatteryDischargeAlarmCurrentConsumption = batteryDischargeAlarmCurrentConsumption;
            TransmitterFrequencies = transmitterFrequencies;
            ReceiverFrequencies = receiverFrequencies;
            BatteryChargerAccessories = batteryChargerAccessories;
            ManipulatorAccessories = manipulatorAccessories;
            NameAKB = nameAKB;
            PercentAKB = percentAKB;
            NoteRadioStationParameters = noteRadioStationParameters;
            VerifiedRST = verifiedRST;
        }
    }
}
