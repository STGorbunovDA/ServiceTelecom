using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IModelRadiostantionDataBaseModel
    {
        /// <summary>
        /// Получение моделей радиостанции
        /// </summary>
        /// <param name="modelCollections"></param>
        /// <returns></returns>
        ObservableCollection<ModelRadiostantionDataBaseModel>
            GetModelRadiostantionDataBase(ObservableCollection<ModelRadiostantionDataBaseModel> modelCollections);

        /// <summary>
        /// Добавление моделей радиостанции
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        bool AddModelDataBase(string modelUser);

        /// <summary>
        /// Удаление модели радиостанции
        /// </summary>
        /// <param name="modelUser"></param>
        /// <returns></returns>
        bool DeleteModelDataBase(string modelUser);

        #region Изменение модели радиостанции (Не используется)
        
        //bool ChangeModelDataBase(int dID, string modelUser);

        #endregion
    }
}
