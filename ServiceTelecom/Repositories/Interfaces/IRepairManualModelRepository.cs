using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IRepairManualModelRepository
    {
        /// <summary> Получение справочника ремонтов радиостанций по модели </summary>
        ObservableCollection<RepairManualRadiostantionModel>
            GetRepairManualRadiostantionsCollections(
            ObservableCollection<RepairManualRadiostantionModel>
            repairManualRadiostantionsCollections, string model);

        /// <summary> добавление детали и работы в справочника ремонтов радиостанций </summary>
        bool AddRepairManualModelRadiostationForDocumentInDB(
            string model, string completedWorks, string parts);

        /// <summary> изменение: детали и работы у справочника ремонтов радиостанций </summary>
        bool ChangeRepairManualModelRadiostationForDocumentInDB(int id,
            string model, string completedWorks, string parts);

        /// <summary> Удаление справочника </summary>
        void DeleteRepairManualModelRadiostationForDocumentInDB(int idBase);
    }
}
