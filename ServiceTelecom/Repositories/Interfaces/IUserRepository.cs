using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;

namespace ServiceTelecom.Models
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получение авторизованного пользователя
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        UserStatic GetAuthorizationUser(NetworkCredential credential);

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        ObservableCollection<UserDataBaseModel> GetAllUsersDataBase(ObservableCollection<UserDataBaseModel> users);

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        bool AddUserDataBase(string login, string password, string post);

        /// <summary>
        /// Удаление пользователей
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeleteUsersDataBase(UserDataBaseModel user);

        /// <summary>
        /// Удаление из таблицы с характеристиками бригад
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool DeleteUserSettingBrigades(UserDataBaseModel user);

        /// <summary>
        /// Изменение характеристик пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        bool ChangeUserDataBase(int id, string login, string password, string post);

       


    }
}
