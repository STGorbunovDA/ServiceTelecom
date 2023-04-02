using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ServiceTelecom.Repositories
{
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// Проверка наличия USER в БД
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public UserModel getAuthorizationUser(NetworkCredential credential)
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
                        UserModel user = new UserModel(
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
       


    }
}
