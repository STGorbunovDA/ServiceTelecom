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
        public ObservableCollection<StaffRegistrationsDataBaseModel>
        GetStaffRegistrationsDataBase(ObservableCollection<StaffRegistrationsDataBaseModel> staffRegistrations)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return staffRegistrations;
                using (MySqlCommand command = new MySqlCommand("settingBrigadesSelect_5",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                StaffRegistrationsDataBaseModel staffRegistration = new StaffRegistrationsDataBaseModel(
                                    reader.GetInt32(0),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(1)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(2)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(3)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(4)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(5)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(6)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(7)));
                                staffRegistrations.Add(staffRegistration);
                            }
                            reader.Close();
                            return staffRegistrations;
                        }
                    }
                }
                return staffRegistrations;
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
                using (MySqlCommand command = new MySqlCommand("settingBrigadesInsert_1",
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
                using (MySqlCommand command = new MySqlCommand("settingBrigadesUpdate_1",
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
                using (MySqlCommand command = new MySqlCommand("settingBrigadesDelete_1",
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
    }
}
