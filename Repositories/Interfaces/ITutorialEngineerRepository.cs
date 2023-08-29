using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface ITutorialEngineerRepository
    {
        /// <summary> Получение обучебных данных (неисправностей) радиостанций из БД </summary>
        ObservableCollection<TutorialEngineerDataBaseModel>
            GetTutorialsEngineerDataBase(ObservableCollection<TutorialEngineerDataBaseModel>
            tutorialsEngineer);

        /// <summary> Добавление инструкции по неисправности радиостанции </summary>
        bool AddTutorialEngineer(string model, string problem, 
            string info, string actions, string login);

        /// <summary> Изменение инструкции по неисправности радиостанции </summary>
        bool ChangeTutorialEngineer(string id, string model, string problem,
            string info, string actions, string login);

        /// <summary> Удаление из БД Инструкции </summary>
        void DeleteTutorialEngineer(int id);
    }
}
