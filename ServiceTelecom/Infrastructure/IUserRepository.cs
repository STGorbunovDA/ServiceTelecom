using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace ServiceTelecom.Models
{
    public interface IUserRepository
    {
        UserModel getAuthorizationUser(NetworkCredential credential);
       
    }
}
