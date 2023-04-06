using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Forms;

namespace ServiceTelecom.Models
{
    public interface IUserRepository
    {
        UserStatic GetAuthorizationUser(NetworkCredential credential);

        ObservableCollection<UserDBModel> GetAllUsersDataBase(ObservableCollection<UserDBModel> users);

        bool AddUserDataBase(string login, string password, string post);

    }
}
