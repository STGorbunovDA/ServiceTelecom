using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories
{
    internal class StaffRegistrationRepository : IStaffRegistrationRepository
    {
        public ObservableCollection<StaffRegistrationsDataBaseModel>
           GetStaffRegistrationDataBase(ObservableCollection<StaffRegistrationsDataBaseModel> staffRegistrations)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return null;
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
                return null;
            }
            catch (Exception) { return null; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }

        }
    }
}
