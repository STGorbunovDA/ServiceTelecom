using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IWorkRepository
    {
        /// <summary>
        /// Загрузка всех радиостанций по дороге и городу
        /// </summary>
        /// <param name="radiostationsForDocumentsCollection"></param>
        /// <param name="roadCollections"></param>
        /// <returns></returns>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetRadiostationsForDocumentsCollection(ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city);

        /// <summary>
        /// Загрузка городов из БД по дороге
        /// </summary>
        /// <param name="road"></param>
        /// <param name="cityCollections"></param>
        /// <returns></returns>
        ObservableCollection<string> GetCityAlongRoadForCityCollection(string road,
            ObservableCollection<string> cityCollections);

    }
}
