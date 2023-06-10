using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    public interface IBackupCopyRadiostationsForDocumentsCollection
    {
        /// <summary> Для автоматического сохранения коллекций радиостанций в CSV </summary>
        void AutoSaveRadiostationsFull(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);
    }
}
