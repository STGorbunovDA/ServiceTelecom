using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IModelDataBaseRepository
    {
        /// <summary> Получение моделей радиостанции </summary>
        ObservableCollection<ModelRadiostantionDataBaseModel>
            GetModelRadiostantionDataBase(
            ObservableCollection<ModelRadiostantionDataBaseModel> modelCollections);

        /// <summary> Добавление модели радиостанции</summary>
        bool AddModelDataBase(string modelUser);

        /// <summary> Удаление модели радиостанции</summary>
        bool DeleteModelDataBase(string modelUser);
    }
}
