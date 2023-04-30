using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    interface ITutorialEngineerRepository
    {
        /// <summary>
        /// Получение обучебных данных (неисправностей) радиостанций из БД
        /// </summary>
        /// <param name="tutorialsEngineer"></param>
        /// <returns></returns>
        ObservableCollection<TutorialEngineerDataBaseModel>
            GetTutorialsEngineerDataBase(ObservableCollection<TutorialEngineerDataBaseModel>
            tutorialsEngineer);
    }
}
