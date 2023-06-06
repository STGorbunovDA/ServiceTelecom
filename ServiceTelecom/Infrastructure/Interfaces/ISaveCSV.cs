using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface ISaveCSV<T> where T : class
    {
        /// <summary> Сохранить табель пользования программой сотрудников </summary>
        void SaveReportCard(ObservableCollection<T> reportCards);
    }
}
