using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRadiostationParametersRepository
    {
        /// <summary> Получение всех параметров радиостанций по дороге и городу из radiostation_parameters </summary>
        ObservableCollection<RadiostationParametersDataBaseModel>
           GetRadiostationsParametersCollection(
           ObservableCollection<RadiostationParametersDataBaseModel>
           radiostationsParametersCollection, string road, string city);

        /// <summary> добавление параметров в radiostation_parameters </summary>
        bool AddRadiostationParameters(
             string road, string city, string dateMaintenance, string location,
             string model, string serialNumber, string company,
             string numberAct, string lowPowerLevelTransmitter,
             string highPowerLevelTransmitter, string frequencyDeviationTransmitter,
             string sensitivityTransmitter, string KNITransmitter,
             string deviationTransmitter, string outputPowerVoltReceiver,
             string outputPowerWattReceiver, string selectivityReceiver,
             string sensitivityReceiver, string KNIReceiver,
             string suppressorReceiver, string frequenciesCompletedForRadiostantion,
             string standbyModeCurrentConsumption, string receptionModeCurrentConsumption,
             string transmissionModeCurrentConsumption,
             string batteryDischargeAlarmCurrentConsumption,
             string batteryChargerAccessories, string manipulatorAccessories,
             string nameAKB, string percentAKB, string noteRadioStationParameters,
             string passedTechnicalServices);

        /// <summary> проверка наличия радиостанции в radiostation_parameters </summary>
        bool CheckSerialNumberInRadiostationParameters(
            string road, string serialNumber);

        /// <summary> изменение параметров в radiostation_parameters </summary>
        bool ChangeRadiostationParameters(
            string road, string city, string dateMaintenance, string location,
            string model, string serialNumber, string company,
            string numberAct, string lowPowerLevelTransmitter,
            string highPowerLevelTransmitter, string frequencyDeviationTransmitter,
            string sensitivityTransmitter, string KNITransmitter,
            string deviationTransmitter, string outputPowerVoltReceiver,
            string outputPowerWattReceiver, string selectivityReceiver,
            string sensitivityReceiver, string KNIReceiver,
            string suppressorReceiver, string frequenciesCompletedForRadiostantion,
            string standbyModeCurrentConsumption, string receptionModeCurrentConsumption,
            string transmissionModeCurrentConsumption,
            string batteryDischargeAlarmCurrentConsumption,
            string batteryChargerAccessories, string manipulatorAccessories,
            string nameAKB, string percentAKB, string noteRadioStationParameters,
            string passedTechnicalServices);

        /// <summary> изменение юридических характеристик(параметров) в radiostation_parameters из ChangeRadiostationForDocumentInDataBaseViewModel </summary>
        bool ChangeСharacteristicsRadiostantionForRadiostationParameters(
            string road, string city, string company, string location,
            string numberAct, string model, string comment, string battery, string serialNumber);

        /// <summary> изменение № акта в radiostation_parameters </summary>
        bool ChangeNumberActForRadiostationParameters(
             string road, string serialNumber, string newNumberAct);

    }
}
