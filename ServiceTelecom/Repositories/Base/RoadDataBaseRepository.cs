using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories
{
    internal class RoadDataBaseRepository : IRoadDataBaseRepository
    {
        public ObservableCollection<string> GetRoadDataBaseWorkView(ObservableCollection<string> roadCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return roadCollections;

                using (MySqlCommand command = new MySqlCommand("GetRoadDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                roadCollections.Add(
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(1)));
                            }
                            reader.Close();
                            return roadCollections;
                        }
                    }
                }
                return roadCollections;
            }
            catch { return roadCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public ObservableCollection<RoadModel> GetRoadDataBase(ObservableCollection<RoadModel> roadCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return roadCollections;
                using (MySqlCommand command = new MySqlCommand("GetRoadDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                roadCollections.Add( 
                                     new RoadModel(reader.GetInt32(0),
                                     reader.GetString(1)));
                            }
                            reader.Close();
                            return roadCollections;
                        }
                    }
                }
                return roadCollections;
            }
            catch { return roadCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRoadDataBase(string road)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("AddRoadDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteRoadDataBase(string road)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("DeleteRoadDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
