using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IReportCardRepository
    {
        /// <summary> Получение табеля сотрудников</summary>
        ObservableCollection<ReportCardsDataBaseModel> GetReportCardsDataBase(
            ObservableCollection<ReportCardsDataBaseModel> reportCards);

        /// <summary> Получение общих дат входа пользователей программы </summary>
        ObservableCollection<string> GetDateTimeInputCollectionsDataBase(
            ObservableCollection<string> dateTimeInputCollections);

        /// <summary> Удаление строки табеля сотрудника </summary>
        void DeleteReportCardsDataBase(int idReportCards);

        /// <summary> Получение табеля по выбранному user </summary>
        ObservableCollection<ReportCardsDataBaseModel> GetReportCardsAtCmbUserDataBase(
            ObservableCollection<ReportCardsDataBaseModel> reportCards, string cmbUser);

        /// <summary> Получение Табеля по дате входа </summary>
        ObservableCollection<ReportCardsDataBaseModel>
            GetReportCardsAtCmbDateTimeInput(
            ObservableCollection<ReportCardsDataBaseModel> reportCards,
            string selectedItemCmbUser);
    }
}
