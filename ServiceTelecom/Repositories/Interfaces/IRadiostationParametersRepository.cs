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
    }
}
