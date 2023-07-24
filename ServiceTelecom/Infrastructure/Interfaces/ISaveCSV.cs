using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface ISaveCSV
    {
        /// <summary> Сохранить табель пользования программой сотрудников </summary>
        void SaveReportCard(ObservableCollection<ReportCardsDataBaseModel> reportCards);
        
        /// <summary> Сохранить методичку ремонтов сотрудников </summary>
        void SaveTutorialsEngineer(ObservableCollection<TutorialEngineerDataBaseModel>
            tutorialsEngineer);
        
        /// <summary> Сохранить радиостанции для документов </summary>
        void SaveRadiostationsForDocumets(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);

        // <summary> Сохранить все характеристики радиостанций общая база </summary>
        void SaveRadiostationsFull(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection);

        // <summary> Сохранить весь справочник с параметрами </summary>
        void SaveHandbookParameters(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersAll);
    }
}
