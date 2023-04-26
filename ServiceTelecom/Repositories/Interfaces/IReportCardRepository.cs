using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IReportCardRepository
    {
        /// <summary>
        /// Получение табеля сотрудников
        /// </summary>
        /// <param name="reportCards"></param>
        /// <returns></returns>
        ObservableCollection<ReportCardsDataBaseModel> GetReportCardsDataBase(ObservableCollection<ReportCardsDataBaseModel> reportCards);
        
        /// <summary>
        /// Получение общих дат входа пользователей программы
        /// </summary>
        /// <param name="dateTimeInputCollections"></param>
        /// <returns></returns>
        ObservableCollection<string> GetDateTimeInputCollectionsDataBase(ObservableCollection<string> dateTimeInputCollections);

        /// <summary>
        /// Удаление строки табеля сотрудника
        /// </summary>
        /// <param name="idReportCards"></param>
        void DeleteReportCardsDataBase(int idReportCards);

        /// <summary>
        /// Получение табеля по выбранному user
        /// </summary>
        /// <param name="reportCards"></param>
        /// <param name="cmbUser"></param>
        /// <returns></returns>
        ObservableCollection<ReportCardsDataBaseModel>
            GetReportCardsAtCmbUserDataBase(ObservableCollection<ReportCardsDataBaseModel> reportCards, string cmbUser);

        /// <summary>
        /// Получение Табеля по дате входа
        /// </summary>
        /// <param name="reportCards"></param>
        /// <param name="selectedItemCmbUser"></param>
        /// <returns></returns>
        ObservableCollection<ReportCardsDataBaseModel>
            GetReportCardsAtCmbDateTimeInput(ObservableCollection<ReportCardsDataBaseModel> reportCards,
            string selectedItemCmbUser);
    }
}
