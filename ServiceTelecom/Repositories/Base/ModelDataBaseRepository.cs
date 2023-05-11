using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories.Base
{
    internal class ModelDataBaseRepository : IModelRadiostantionDataBaseModel
    {
        public ObservableCollection<ModelRadiostantionDataBaseModel> 
            GetModelRadiostantionDataBase(ObservableCollection<ModelRadiostantionDataBaseModel> modelCollections)
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
                                ModelRadiostantionDataBaseModel modelRadiostantion = new ModelRadiostantionDataBaseModel
                                    (reader.GetInt32(0), reader.GetString(1));
                                modelCollections.Add(modelRadiostantion);
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

        public bool AddModelDataBase(string modelUser)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;

                using (MySqlCommand command = new MySqlCommand("AddModelDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser", 
                        Encryption.EncryptPlainTextToCipherText(modelUser));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteModelDataBase(string modelUser)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("DeleteModelDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(modelUser));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        #region Изменение радиостанции отком. в IModelDataBase

        //public bool ChangeModelDataBase(int dID, string modelUser)
        //{
        //    try
        //    {
        //        if (!InternetCheck.CheckSkyNET())
        //            return false;
        //        using (MySqlCommand command = new MySqlCommand("ChangeModelDataBase",
        //            RepositoryDataBase.GetInstance.GetConnection()))
        //        {
        //            RepositoryDataBase.GetInstance.OpenConnection();
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue($"dID", dID);
        //            command.Parameters.AddWithValue($"modelUser",
        //                Encryption.EncryptPlainTextToCipherText(modelUser));
        //            if (command.ExecuteNonQuery() == 1) return true;
        //            else return false;
        //        }
        //    }
        //    catch { return false; }
        //    finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        //}

        #endregion
    }
}
