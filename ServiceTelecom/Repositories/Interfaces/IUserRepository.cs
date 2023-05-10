using System;
using System.Collections.ObjectModel;
using System.Net;

namespace ServiceTelecom.Models
{
    public interface IUserRepository
    {
        /// <summary> Получение авторизованного пользователя</summary>
        UserModelStatic GetAuthorizationUser(NetworkCredential credential);

        /// <summary> Получение списка всех пользователей </summary>
        ObservableCollection<UserDataBaseModel> GetAllUsersDataBase(ObservableCollection<UserDataBaseModel> users);

        /// <summary> Добавление нового пользователя </summary>
        bool AddUserDataBase(string login, string password, string post);

        /// <summary> Удаление пользователей </summary>
        void DeleteUsersDataBase(UserDataBaseModel user);

        /// <summary> Изменение характеристик пользователя </summary>
        bool ChangeUserDataBase(int id, string login, string password, string post);

        /// <summary> Запись времени захода пользователя в Базу данных </summary>
        bool SetDateTimeUserDataBase(string user);

        /// <summary> Получаем время захода пользователя из Базы данных  </summary>
        DateTime GetDateTimeUserDataBase(string user, DateTime date);

        /// <summary> Запись времени выхода пользователя в Базу данных </summary>
        bool SetDateTimeExitUserDataBase(string user);
    }
}
