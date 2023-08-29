using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRoadDataBaseRepository
    {
        /// <summary> Получение дорог из БД для WorkView</summary>
        ObservableCollection<string> GetRoadDataBaseWorkView(
            ObservableCollection<string> roadCollections);

        /// <summary> Получение дорог из БД </summary>
        ObservableCollection<RoadModel> GetRoadDataBase(ObservableCollection<RoadModel> roadCollections);
        
        /// <summary> Добавление дороги в БД </summary>
        bool AddRoadDataBase(string road);

        /// <summary> Удаление дороги из БД </summary>
        bool DeleteRoadDataBase(string road);
    }
}
