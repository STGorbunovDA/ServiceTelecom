using Microsoft.Win32;
using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Net;

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
            catch { return null; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }

        }

        public ObservableCollection<UserDBModel> GetAllUsersDataBase(ObservableCollection<UserDBModel> users)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return null;
                using (MySqlCommand command = new MySqlCommand("usersSelectFull_1",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
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
            catch (Exception) { return null; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }


        }

        public bool AddUserDataBase(string login, string password, string post)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("usersInsert_2",
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

        public bool DeleteUsersDataBase(UserDBModel user)
        {
            bool flag = false;
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return flag;
                int dID = Convert.ToInt32(user.IdBase);
                using (MySqlCommand command = new MySqlCommand("usersDelete_1",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"dID", dID);
                    command.ExecuteNonQuery();
                    flag = DeleteUserSettingBrigades(user);// удаление из характеристик бригад
                }
                return flag;
            }
            catch (Exception) { return flag; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteUserSettingBrigades(UserDBModel user)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("settingBrigadesUpdate_2",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"loginUser", user.LoginBase);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception) { return false; }
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
                using (MySqlCommand command = new MySqlCommand("usersUpdate_1",
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
