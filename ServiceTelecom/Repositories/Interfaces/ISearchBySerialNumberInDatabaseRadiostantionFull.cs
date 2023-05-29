using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface ISearchBySerialNumberInDatabaseRadiostantionFull
    {
        /// <summary>
        /// Поиск радиостанции в БД по дороге, городу и заводскому номеру
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="serialNumber"></param>
        /// <param name="radiostationsForDocumentsCollection"></param>
        /// <returns></returns>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            SearchBySerialNumberInDatabaseCharacteristics(string road,
            string city, string serialNumber,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);
    }
}
