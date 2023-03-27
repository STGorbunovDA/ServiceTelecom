using System.Collections.Generic;
using System.Net;

namespace ServiceTelecom.Models
{
    public interface IUserRepository
    {
        UserModel AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
