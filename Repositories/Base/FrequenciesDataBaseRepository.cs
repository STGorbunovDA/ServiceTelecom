using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace ServiceTelecom.Repositories.Base
{
    internal class FrequenciesDataBaseRepository : IFrequenciesDataBaseRepository
    {
        public ObservableCollection<FrequencyModel> GetFrequencyDataBase(
            ObservableCollection<FrequencyModel> frequenciesCollection)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return frequenciesCollection;
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
                                frequenciesCollection.Add(frequencyModel);
                            }
                            reader.Close();

                            var tempFrequenciesCollection =
                                 new ObservableCollection<FrequencyModel>
                                 (frequenciesCollection.OrderBy(i => i));

                            frequenciesCollection.Clear();
                            foreach (var item in tempFrequenciesCollection)
                                frequenciesCollection.Add(item);

                            tempFrequenciesCollection = null;

                            return frequenciesCollection;
                        }
                    }
                }
                return frequenciesCollection;
            }
            catch { return frequenciesCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public string AddFrequencyDataBase(string frequency)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return string.Empty;
                using (MySqlCommand command = new MySqlCommand("AddFrequencyDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"frequencyUser",
                        Encryption.EncryptPlainTextToCipherText(frequency));
                    if (command.ExecuteNonQuery() == 1) return frequency;
                    else return string.Empty;
                }
            }
            catch { return string.Empty; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteFrequencyDataBase(int idBase)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("DeleteFrequencyDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"idBaseUser", idBase);
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }

            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
