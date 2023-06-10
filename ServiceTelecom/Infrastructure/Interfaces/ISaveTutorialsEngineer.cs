using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface ISaveTutorialsEngineer<T> where T : class
    {
        /// <summary> Сохранить методичку ремонтов сотрудников </summary>
        void SaveTutorialsEngineer(ObservableCollection<T>
            tutorialsEngineer);
    }
}
