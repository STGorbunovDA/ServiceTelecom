﻿using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;
using System.Windows;

namespace ServiceTelecom.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserStatic GetAuthorizationUser(NetworkCredential credential)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return null;
                using (MySqlCommand command = new MySqlCommand("GetAuthorizationUser",
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
            catch { return null; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }

        }
 
        public ObservableCollection<UserDataBaseModel> GetAllUsersDataBase(ObservableCollection<UserDataBaseModel> users)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return null;
                using (MySqlCommand command = new MySqlCommand("GetAllUsersDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                UserDataBaseModel user = new UserDataBaseModel(
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
                return users;
            }
            catch (Exception) { return users; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }


        }

        public bool AddUserDataBase(string login, string password, string post)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("AddUserDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"loginUser", Encryption.EncryptPlainTextToCipherText(login));
                    command.Parameters.AddWithValue($"passUser", Encryption.EncryptPlainTextToCipherText(password));
                    command.Parameters.AddWithValue($"post", post);
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public void DeleteUsersDataBase(UserDataBaseModel user)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return;
                int dID = Convert.ToInt32(user.IdBase);
                using (MySqlCommand command = new MySqlCommand("DeleteUsersDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"dID", dID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeUserDataBase(int id, string login, string password, string post)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                string loginUser = Encryption.EncryptPlainTextToCipherText(login);
                string passUser = Encryption.EncryptPlainTextToCipherText(password);
                using (MySqlCommand command = new MySqlCommand("ChangeUserDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"loginUser", loginUser);
                    command.Parameters.AddWithValue($"passUser", passUser);
                    command.Parameters.AddWithValue($"post", post);
                    command.Parameters.AddWithValue($"uID", id);
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        
    }
}
