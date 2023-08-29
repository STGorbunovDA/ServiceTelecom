using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface ISearchBySerialNumberInWorkRadiostantionFullRepository
    {
        /// <summary> Поиск радиостанции в БД по дороге, городу и заводскому номеру </summary>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            SearchBySerialNumberInDatabaseCharacteristics(string road, string serialNumber,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);
    }
}
