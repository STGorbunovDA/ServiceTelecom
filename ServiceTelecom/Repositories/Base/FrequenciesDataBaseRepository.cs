using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories.Base
{
    internal class FrequenciesDataBaseRepository : IFrequenciesDataBaseRepository
    {
        public ObservableCollection<FrequencyModel> GetFrequencyDataBase(
            ObservableCollection<FrequencyModel> FrequenciesCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return FrequenciesCollections;

                using (MySqlCommand command = new MySqlCommand("GetFrequencyDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FrequencyModel frequencyModel = 
                                    new FrequencyModel
                                    (reader.GetInt32(0), reader.GetString(1));
                                FrequenciesCollections.Add(frequencyModel);
                            }
                            reader.Close();
                            return FrequenciesCollections;
                        }
                    }
                }
                return FrequenciesCollections;
            }
            catch { return FrequenciesCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddFrequencyDataBase(string frequency)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("AddFrequencyDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"frequencyUser",
                        Encryption.EncryptPlainTextToCipherText(frequency));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally
            {
                RepositoryDataBase.GetInstance.CloseConnection();
            }
        }
    }
}
