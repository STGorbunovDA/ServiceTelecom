using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IHandbookParametersModelRadiostationRepository
    {
        /// <summary> Получение справочника параметров для и по модели </summary>
        ObservableCollection<HandbookParametersModelRadiostationModel>
            GetHandbookParametersByModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersModelRadiostationCollection, string model);

        /// <summary> Получение справочника параметров для всех типов моделей </summary>
        ObservableCollection<HandbookParametersModelRadiostationModel>
            GetHandbookParametersAllModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersModelCollection);

        /// <summary> добавление справочника параметров для выбранного типа модели </summary>
        bool AddHandbookParametersForModel(
            string model, string minLowPowerLevelTransmitter,
            string maxLowPowerLevelTransmitter, string minHighPowerLevelTransmitter,
            string maxHighPowerLevelTransmitter, string minFrequencyDeviationTransmitter,
            string maxFrequencyDeviationTransmitter, string minSensitivityTransmitter,
            string maxSensitivityTransmitter, string minKNITransmitter,
            string maxKNITransmitter, string minDeviationTransmitter,
            string maxDeviationTransmitter, string minOutputPowerVoltReceiver,
            string maxOutputPowerVoltReceiver, string minOutputPowerWattReceiver,
            string maxOutputPowerWattReceiver, string minSelectivityReceiver,
            string maxSelectivityReceiver, string minSensitivityReceiver,
            string maxSensitivityReceiver, string minKNIReceiver, string maxKNIReceiver,
            string minSuppressorReceiver, string maxSuppressorReceiver,
            string minStandbyModeCurrentConsumption, string maxStandbyModeCurrentConsumption,
            string minReceptionModeCurrentConsumption, string maxReceptionModeCurrentConsumption,
            string minTransmissionModeCurrentConsumption, string maxTransmissionModeCurrentConsumption,
            string minBatteryDischargeAlarmCurrentConsumption,
            string maxBatteryDischargeAlarmCurrentConsumption);
    }
}
