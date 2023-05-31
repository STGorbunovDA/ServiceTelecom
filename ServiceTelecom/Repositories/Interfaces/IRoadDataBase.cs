using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRoadDataBase
    {
        /// <summary> Получение дорог из БД</summary>
        ObservableCollection<string> GetRoadDataBase(
            ObservableCollection<string> roadCollections);
    }
}
