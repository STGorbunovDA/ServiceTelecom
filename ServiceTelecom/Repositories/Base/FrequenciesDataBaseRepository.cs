using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.Generic;

namespace ServiceTelecom.Repositories.Base
{
    internal class FrequenciesDataBaseRepository : IFrequenciesDataBaseRepository
    {
        public List<FrequencyModel> GetFrequencyDataBase(
            List<FrequencyModel> FrequenciesCollections)
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
    }
}
