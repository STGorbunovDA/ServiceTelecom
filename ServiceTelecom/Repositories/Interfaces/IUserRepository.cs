using System;
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
        void DeleteUsersDataBase(UserDataBaseModel user);

        /// <summary>
        /// Изменение характеристик пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        bool ChangeUserDataBase(int id, string login, string password, string post);

        /// <summary>
        /// Запись времени захода пользователя в Базу данных
        /// </summary>
        /// <param name="user"></param>
        bool SetDateTimeUserDataBase(UserStatic user);

        /// <summary>
        /// Получаем время захода пользователя из Базы данных
        /// </summary>
        /// <param name="user"></param>
        DateTime GetDateTimeUserDataBase(UserStatic user, DateTime date);


    }
}
