using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IStaffRegistrationRepository
    {
        /// <summary>
        /// Получение списка зарегестрированных бригад по дороге
        /// </summary>
        /// <param name="staffRegistrations"></param>
        /// <returns></returns>
        ObservableCollection<StaffRegistrationDataBaseModel> GetStaffRegistrationsDataBase(ObservableCollection<StaffRegistrationDataBaseModel> staffRegistrations);

        /// <summary>
        /// Добавление бригады на участок дороги
        /// </summary>
        /// <param name="sectionForeman"></param>
        /// <param name="engineer"></param>
        /// <param name="attorney"></param>
        /// <param name="road"></param>
        /// <param name="numberPrintDocument"></param>
        /// <param name="curator"></param>
        /// <param name="radioCommunicationDirectorate"></param>
        /// <returns></returns>
        bool AddStaffRegistrationDataBase(string sectionForeman, string engineer, string attorney,
           string road, string numberPrintDocument, string curator, string radioCommunicationDirectorate);
        
        /// <summary>
        /// Изменение характеристик бригад
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sectionForeman"></param>
        /// <param name="engineer"></param>
        /// <param name="attorney"></param>
        /// <param name="road"></param>
        /// <param name="numberPrintDocument"></param>
        /// <param name="curator"></param>
        /// <param name="radioCommunicationDirectorate"></param>
        /// <returns></returns>
        bool ChangeStaffRegistrationDataBase(int id, string sectionForeman, string engineer, string attorney,
           string road, string numberPrintDocument, string curator, string radioCommunicationDirectorate);

        /// <summary>
        /// Удаление бригады
        /// </summary>
        /// <param name="staffRegistrations"></param>
        /// <returns></returns>
        void DeleteStaffRegistrationsDataBase(int id);

        /// <summary>
        /// Получение списка бригад по логину
        /// </summary>
        /// <param name="login"></param>
        /// <param name="staffRegistrationsDataBaseModelCollection"></param>
        /// <returns></returns>
        ObservableCollection<StaffRegistrationDataBaseModel>
            GetStaffRegistrationsDataBasePerLogin(string login,
            ObservableCollection<StaffRegistrationDataBaseModel>
            staffRegistrationsDataBaseModelCollection);
    }
}
