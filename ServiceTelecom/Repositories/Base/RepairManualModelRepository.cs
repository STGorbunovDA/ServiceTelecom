using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories.Base
{
    internal class RepairManualModelRepository : IRepairManualModelRepository
    {
        public ObservableCollection<RepairManualRadiostantion>
            GetRepairManualRadiostantionsCollections(
            ObservableCollection<RepairManualRadiostantion>
            repairManualRadiostantionsCollections, string model)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return repairManualRadiostantionsCollections;
                using (MySqlCommand command = new MySqlCommand(
                   "GetRepairManualRadiostantionsCollections",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RepairManualRadiostantion
                                    repairManualRadiostantion =
                                    new RepairManualRadiostantion(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3));
                                repairManualRadiostantionsCollections.Add(
                                    repairManualRadiostantion);
                            }
                        }
                        reader.Close();
                        return repairManualRadiostantionsCollections;
                    }
                }

            }
            catch { return repairManualRadiostantionsCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRepairRadiostationForDocumentInDataBase(
            string model, string completedWorks, string parts)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;

                using (MySqlCommand command = new MySqlCommand(
                    "AddRepairRadiostationForDocumentInDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"completedWorksUser",
                        Encryption.EncryptPlainTextToCipherText(completedWorks));
                    command.Parameters.AddWithValue($"partsUser",
                        Encryption.EncryptPlainTextToCipherText(parts));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
