using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRepairManualModelRepository
    {
        /// <summary> Получение справочника ремонтов радиостанций по модели </summary>
        ObservableCollection<RepairManualRadiostantion>
            GetRepairManualRadiostantionsCollections(
            ObservableCollection<RepairManualRadiostantion>
            repairManualRadiostantionsCollections, string model);

        /// <summary> добавление детали и работы в справочника ремонтов радиостанций </summary>
        bool AddRepairRadiostationForDocumentInDataBase(
            string model, string completedWorks, string parts);
    }
}
