using ServiceTelecom.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRoadDataBaseRepository
    {
        /// <summary> Получение дорог из БД </summary>
        Task<ObservableCollection<RoadModel>> GetRoadDataBase(ObservableCollection<RoadModel> roadCollections);

        /// <summary> Добавление дороги в БД </summary>
        bool AddRoadDataBase(string road);

        /// <summary> Удаление дороги из БД </summary>
        bool DeleteRoadDataBase(string road);
    }
}
