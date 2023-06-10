using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    public interface IBackupCopyRadiostationsForDocumentsCollection
    {
        /// <summary> Для автоматического сохранения коллекций радиостанций в CSV </summary>
        void AutoSaveRadiostationsFullCSV(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);

        /// <summary> Для автоматического сохранения коллекций радиостанций в Json </summary>
        void AutoSaveRadiostationsFullJson(string city,
           ObservableCollection<RadiostationForDocumentsDataBaseModel>
           radiostationsForDocumentsCollection);

        // <summary> Копируем рабочую таблицу radiostantion в radiostantion_copy</summary>
        void CopyDataBaseRadiostantionInRadiostantionCopy();
    }
}
