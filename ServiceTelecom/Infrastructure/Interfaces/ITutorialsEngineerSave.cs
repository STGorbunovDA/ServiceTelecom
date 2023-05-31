using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface ITutorialsEngineerSave<T> where T : class
    {
        /// <summary> Сохранить методичку ремонтов сотрудников </summary>
        void SaveTutorialsEngineer(ObservableCollection<T>
            tutorialsEngineer);
    }
}
