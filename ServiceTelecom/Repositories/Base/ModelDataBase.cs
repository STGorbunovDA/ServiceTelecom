using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Base
{
    internal class ModelDataBase : IModelDataBase
    {
        public ObservableCollection<string> GetModelDataBase(ObservableCollection<string> modelCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return modelCollections;

                using (MySqlCommand command = new MySqlCommand("GetModelDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                modelCollections.Add(reader.GetString(0));
                            }
                            reader.Close();
                            return modelCollections;
                        }
                    }
                }
                return modelCollections;
            }
            catch { return modelCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
