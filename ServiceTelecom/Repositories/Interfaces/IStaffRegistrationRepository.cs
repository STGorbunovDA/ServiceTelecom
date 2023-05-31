using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IStaffRegistrationRepository
    {
        /// <summary> Получение списка зарегестрированных бригад по дороге </summary>
        ObservableCollection<StaffRegistrationDataBaseModel> GetStaffRegistrationsDataBase(
            ObservableCollection<StaffRegistrationDataBaseModel> staffRegistrations);

        /// <summary> Добавление бригады на участок дороги </summary>
        bool AddStaffRegistrationDataBase(string sectionForeman, 
            string engineer, string attorney, string road, 
            string numberPrintDocument, string curator, 
            string radioCommunicationDirectorate);
        
        /// <summary> Изменение характеристик бригад </summary>
        bool ChangeStaffRegistrationDataBase(int id, string sectionForeman, 
            string engineer, string attorney, string road,
            string numberPrintDocument, string curator, 
            string radioCommunicationDirectorate);

        /// <summary> Удаление бригады </summary>
        void DeleteStaffRegistrationsDataBase(int id);

        /// <summary> Получение списка бригад по логину</summary>
        ObservableCollection<StaffRegistrationDataBaseModel>
            GetStaffRegistrationsDataBasePerLogin(string login,
            ObservableCollection<StaffRegistrationDataBaseModel>
            staffRegistrationsDataBaseModelCollection);
    }
}
