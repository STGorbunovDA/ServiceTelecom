using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace ServiceTelecom.Repositories
{
    internal class StaffRegistrationRepository : IStaffRegistrationRepository
    {
        public ObservableCollection<StaffRegistrationDataBaseModel>
        GetStaffRegistrationsDataBase(ObservableCollection<StaffRegistrationDataBaseModel> staffRegistrations)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return staffRegistrations;
                using (MySqlCommand command = new MySqlCommand("GetStaffRegistrationsDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StaffRegistrationDataBaseModel staffRegistration = new StaffRegistrationDataBaseModel(
                                    reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4),reader.GetString(5), reader.GetString(6), reader.GetString(7));
                                staffRegistrations.Add(staffRegistration);
                            }
                        }
                        reader.Close();
                        return staffRegistrations;
                    }
                }
            }
            catch (Exception) { return staffRegistrations; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddStaffRegistrationDataBase(string sectionForeman, string engineer, string attorney,
           string road, string numberPrintDocument, string curator, string radioCommunicationDirectorate)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("AddStaffRegistrationDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"sectionForeman", Encryption.EncryptPlainTextToCipherText(sectionForeman));
                    command.Parameters.AddWithValue($"engineer", Encryption.EncryptPlainTextToCipherText(engineer));
                    command.Parameters.AddWithValue($"attorney", Encryption.EncryptPlainTextToCipherText(attorney));
                    command.Parameters.AddWithValue($"road", Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"numberPrintDocument", Encryption.EncryptPlainTextToCipherText(numberPrintDocument));
                    command.Parameters.AddWithValue($"curator", Encryption.EncryptPlainTextToCipherText(curator));
                    command.Parameters.AddWithValue($"radioCommunicationDirectorate", Encryption.EncryptPlainTextToCipherText(radioCommunicationDirectorate));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeStaffRegistrationDataBase(int id, string sectionForeman, string engineer, string attorney,
           string road, string numberPrintDocument, string curator, string radioCommunicationDirectorate)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("ChangeStaffRegistrationDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"sectionForeman", Encryption.EncryptPlainTextToCipherText(sectionForeman));
                    command.Parameters.AddWithValue($"engineer", Encryption.EncryptPlainTextToCipherText(engineer));
                    command.Parameters.AddWithValue($"attorney", Encryption.EncryptPlainTextToCipherText(attorney));
                    command.Parameters.AddWithValue($"road", Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"numberPrintDocument", Encryption.EncryptPlainTextToCipherText(numberPrintDocument));
                    command.Parameters.AddWithValue($"curator", Encryption.EncryptPlainTextToCipherText(curator));
                    command.Parameters.AddWithValue($"radioCommunicationDirectorate", Encryption.EncryptPlainTextToCipherText(radioCommunicationDirectorate));
                    command.Parameters.AddWithValue($"uID", id);
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public void DeleteStaffRegistrationsDataBase(int id)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return;
                using (MySqlCommand command = new MySqlCommand("DeleteStaffRegistrationsDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"dID", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public ObservableCollection<StaffRegistrationDataBaseModel> 
            GetStaffRegistrationsDataBasePerLogin(string login, 
            ObservableCollection<StaffRegistrationDataBaseModel> 
            staffRegistrationsDataBaseModelCollection)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return staffRegistrationsDataBaseModelCollection;
                using (MySqlCommand command = new MySqlCommand(
                    "GetStaffRegistrationsDataBasePerLogin",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"userLogin",
                        Encryption.EncryptPlainTextToCipherText(login));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StaffRegistrationDataBaseModel staffRegistrationsDataBaseModel
                                    = new StaffRegistrationDataBaseModel(
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                    reader.GetString(6), reader.GetString(7));
                                staffRegistrationsDataBaseModelCollection.Add(staffRegistrationsDataBaseModel);
                            }
                        }
                        reader.Close();
                        return staffRegistrationsDataBaseModelCollection;
                    }
                }
            }
            catch (Exception) { return staffRegistrationsDataBaseModelCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
