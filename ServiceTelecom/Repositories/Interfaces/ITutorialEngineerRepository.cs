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

        /// <summary>
        /// Добавление инструкции по неисправности радиостанции
        /// </summary>
        /// <param name="model"></param>
        /// <param name="problem"></param>
        /// <param name="info"></param>
        /// <param name="actions"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        bool AddTutorialEngineer(string model, string problem, string info, string actions, string login);

        /// <summary>
        /// Изменение инструкции по неисправности радиостанции
        /// </summary>
        /// <param name="model"></param>
        /// <param name="problem"></param>
        /// <param name="info"></param>
        /// <param name="actions"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        bool ChangeTutorialEngineer(string id, string model, string problem,
            string info, string actions, string login);
    }
}
