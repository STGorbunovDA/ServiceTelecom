using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories
{
    internal class WorkRepository : IWorkRepository
    {
        public ObservableCollection<string> GetCityAlongRoadForCityCollection(string road,
            ObservableCollection<string> cityCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return cityCollections;
                using (MySqlCommand command = new MySqlCommand("GetCityAlongRoadForCityCollection",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //cityCollections.Add(reader.GetString(0));
                                cityCollections.Add(
                                     Encryption.DecryptCipherTextToPlainText(reader.GetString(0)));
                            }
                        }
                        reader.Close();
                        return cityCollections;
                    }
                }


            }
            catch (Exception) { return cityCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }


        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetRadiostationsForDocumentsCollection(ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return radiostationsForDocumentsCollection;

                using (MySqlCommand command = new MySqlCommand("GetRadiostationsForDocumentsCollection",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser", Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser", Encryption.EncryptPlainTextToCipherText(city));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RadiostationForDocumentsDataBaseModel radiostationForDocumentsDataBaseModels = new RadiostationForDocumentsDataBaseModel(
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                    reader.GetString(6), reader.GetString(7), reader.GetDateTime(8),
                                    reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                    reader.GetString(12), reader.GetString(13), reader.GetString(14),
                                    reader.GetDateTime(15), reader.GetString(16), reader.GetString(17),
                                    reader.GetString(18), reader.GetString(19), reader.GetString(20),
                                    reader.GetString(21), reader.GetString(22), reader.GetString(23),
                                    reader.GetString(24), reader.GetString(25), reader.GetString(26),
                                    reader.GetString(27), reader.GetString(28), reader.GetString(29),
                                    reader.GetString(30), reader.GetString(31), reader.GetString(32),
                                    reader.GetString(33), reader.GetString(34), reader.GetString(35),
                                    reader.GetString(36), reader.GetString(37), reader.GetString(38),
                                    reader.GetString(39), reader.GetString(40), reader.GetString(41));
                                radiostationsForDocumentsCollection.Add(radiostationForDocumentsDataBaseModels);
                            }
                        }
                        reader.Close();
                        return radiostationsForDocumentsCollection;
                    }
                }
            }
            catch (Exception) { return radiostationsForDocumentsCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
