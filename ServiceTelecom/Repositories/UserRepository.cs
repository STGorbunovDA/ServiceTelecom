using Microsoft.Win32;
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
        public UserModel GetAuthorizationUser(NetworkCredential credential)
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
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(3)));
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
                    command.Parameters.AddWithValue($"post", Encryption.EncryptPlainTextToCipherText(post));
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
                string postUser = Encryption.EncryptPlainTextToCipherText(post);
                using (MySqlCommand command = new MySqlCommand("ChangeUserDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"loginUser", loginUser);
                    command.Parameters.AddWithValue($"passUser", passUser);
                    command.Parameters.AddWithValue($"post", postUser);
                    command.Parameters.AddWithValue($"uID", id);
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
       
        public bool SetDateTimeUserDataBase(string user)
        {
            if (!InternetCheck.CheckSkyNET())
                return false;
            try
            {
                DateTime date = DateTime.Now;
                string entryDate = date.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime getDateTimeFromDataBase = GetDateTimeUserDataBase(user, date);

                if (getDateTimeFromDataBase == DateTime.MinValue) return false;

                if (date.ToString("yyyy-MM-dd") != getDateTimeFromDataBase.ToString("yyyy-MM-dd"))
                {
                    using (MySqlCommand command = new MySqlCommand("SetDateTimeUserDataBase", RepositoryDataBase.GetInstance.GetConnection()))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue($"user", user);
                        command.Parameters.AddWithValue($"dateTimeInput", entryDate);
                        RepositoryDataBase.GetInstance.OpenConnection();
                        if (command.ExecuteNonQuery() == 1) return true;
                        else return false;
                    }
                }
                else return true;
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }   
        }
       
        public DateTime GetDateTimeUserDataBase(string user, DateTime date)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("GetDateTimeUserDataBase", RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"userLogin", user);
                    command.Parameters.AddWithValue($"date", date.ToString("yyyy-MM-dd"));
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0) return Convert.ToDateTime(table.Rows[table.Rows.Count - 1].ItemArray[0]);
                        else return DateTime.MaxValue;
                    }
                }
            }
            catch{ return DateTime.MinValue; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
            
            
        }

        public bool SetDateTimeExitUserDataBase(string user)
        {
            if (!InternetCheck.CheckSkyNET())
                return false;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите закрыть программу?", "Подтверждение", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                try
                {
                    DateTime date = DateTime.Now;
                    string exitDate = date.ToString("yyyy-MM-dd HH:mm:ss");
                    DateTime getDateTimeFromDataBase = GetDateTimeUserDataBase(user, date);

                    if (getDateTimeFromDataBase == DateTime.MinValue) return false;

                    if (date.ToString("yyyy-MM-dd") == getDateTimeFromDataBase.ToString("yyyy-MM-dd"))
                    {
                        using (MySqlCommand command = new MySqlCommand("SetDateTimeExitUserDataBase", 
                            RepositoryDataBase.GetInstance.GetConnection()))
                        {
                            RepositoryDataBase.GetInstance.OpenConnection();
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue($"dateTimeExit", exitDate);
                            command.Parameters.AddWithValue($"userLogin", user);
                            command.Parameters.AddWithValue($"dateTimeInputApp", getDateTimeFromDataBase.ToString("yyyy-MM-dd HH:mm:ss"));
                            if (command.ExecuteNonQuery() == 1) return true;
                            else return false;
                        }
                    }
                    else return true;
                }
                catch { return false; }
                finally { RepositoryDataBase.GetInstance.CloseConnection(); }
            }
            else return false;               
        }
    }
}
