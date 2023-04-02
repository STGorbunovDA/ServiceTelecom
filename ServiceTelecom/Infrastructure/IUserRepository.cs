using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Forms;

namespace ServiceTelecom.Models
{
    public interface IUserRepository
    {
        UserStatic getAuthorizationUser(NetworkCredential credential);

        ObservableCollection<UserDBModel> getAllUsersDataBase(ObservableCollection<UserDBModel> users);


    }
}
