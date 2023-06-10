using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    public interface IAutoSaveCSV
    {
        /// <summary> Для автоматического сохранения коллекций радиостанций </summary>
        void AutoSaveRadiostationsFull(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);
    }
}
