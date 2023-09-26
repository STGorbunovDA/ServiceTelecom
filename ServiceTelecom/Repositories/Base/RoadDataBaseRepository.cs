using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories
{
    internal class RoadDataBaseRepository : IRoadDataBaseRepository
    {
        public async Task<ObservableCollection<RoadModel>> GetRoadDataBase(ObservableCollection<RoadModel> roadCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET()) return await Task.Run(() => { return roadCollections; });

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
                                     Encryption.DecryptCipherTextToPlainText(reader.GetString(1))));
                            }
                            reader.Close();
                        }
                    }
                }
                return await Task.Run(() => { return roadCollections; });
            }
            catch { return await Task.Run(() => { return roadCollections; }); }
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
