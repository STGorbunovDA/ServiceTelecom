using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IStaffRegistrationRepository
    {
        /// <summary>
        /// Получение списка зарегестрированных бригад по дороге
        /// </summary>
        /// <param name="staffRegistrations"></param>
        /// <returns></returns>
        ObservableCollection<StaffRegistrationsDataBaseModel> GetStaffRegistrationDataBase(ObservableCollection<StaffRegistrationsDataBaseModel> staffRegistrations);
    }
}
