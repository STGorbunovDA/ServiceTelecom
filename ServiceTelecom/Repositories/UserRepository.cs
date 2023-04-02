﻿using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ServiceTelecom.Repositories
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Проверка наличия USER в БД
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public UserStatic getAuthorizationUser(NetworkCredential credential)
        {
            if (!InternetCheck.CheckSkyNET())
                return null;
            using (MySqlCommand command = new MySqlCommand("usersSelect_1",
                RepositoryDataBase.GetInstance.GetConnection()))
            {
                RepositoryDataBase.GetInstance.OpenConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue($"loginUser", Encryption.EncryptPlainTextToCipherText(credential.UserName));
                command.Parameters.AddWithValue($"passUser", Encryption.EncryptPlainTextToCipherText(credential.Password));
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count == 1)
                    {
                        UserStatic user = new UserStatic(
                            table.Rows[0].ItemArray[0].ToString(),
                            table.Rows[0].ItemArray[2].ToString());
                        RegistryKey currentUserKey = Registry.CurrentUser;
                        RegistryKey helloKey = currentUserKey.CreateSubKey("SOFTWARE\\ServiceTelekom_Setting\\Login_Password");
                        helloKey.SetValue("Login", $"{credential.UserName}");
                        helloKey.Close();
                        return user;
                    }
                    else return null;
                }
            }
        }

        public ObservableCollection<UserDBModel> getAllUsersDataBase(ObservableCollection<UserDBModel> users)
        {
            if (!InternetCheck.CheckSkyNET())
                return null;

            using (MySqlCommand command = new MySqlCommand("usersSelectFull_1",
                RepositoryDataBase.GetInstance.GetConnection()))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserDBModel user = new UserDBModel(
                                reader.GetInt32(0), 
                                Encryption.DecryptCipherTextToPlainText(reader.GetString(1)),
                                Encryption.DecryptCipherTextToPlainText(reader.GetString(2)),
                                reader.GetString(3));
                            users.Add(user);
                        }
                        reader.Close();
                        return users;
                    }
                }
            }
            return null;
        }

    }
}
