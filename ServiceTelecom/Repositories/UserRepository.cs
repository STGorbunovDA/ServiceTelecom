using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace ServiceTelecom.Repositories
{
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// Проверка наличия USER в БД
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        public UserModel AuthenticateUser(NetworkCredential credential)
        {
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
                        helloKey.SetValue("Password", $"{credential.Password}");//TODO 1. убрать пароль из реестра?
                        helloKey.Close();
                        return user;
                    }
                    else return null;
                }
            }
        }

        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
