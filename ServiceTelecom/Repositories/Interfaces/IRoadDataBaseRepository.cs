using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRoadDataBaseRepository
    {
        /// <summary> Получение дорог из БД</summary>
        ObservableCollection<string> GetRoadDataBase(
            ObservableCollection<string> roadCollections);
    }
}
