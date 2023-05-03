using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories
{
    internal class RoadDataBaseRepository : IRoadDataBase
    {
        public ObservableCollection<string> GetRoadDataBase(ObservableCollection<string> roadCollections)
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
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(0)));
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
    }
}
