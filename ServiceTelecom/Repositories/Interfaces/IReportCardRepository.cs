using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Получение пользователей табеля
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        ObservableCollection<string> GetAllUsersReportCardsDataBase(ObservableCollection<string> users);

        /// <summary>
        /// Удаление строки табеля сотрудника
        /// </summary>
        /// <param name="idReportCards"></param>
        void DeleteReportCardsDataBase(int idReportCards);
    }
}
