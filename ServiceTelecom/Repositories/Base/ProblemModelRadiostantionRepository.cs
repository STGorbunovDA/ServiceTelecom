using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories.Base
{
    internal class ProblemModelRadiostantionRepository : IProblemModelRadiostantionRepository
    {
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel> 
            GetProblemModelRadiostantionDataBase(ObservableCollection<ProblemModelRadiostantionDataBaseModel> 
            problemModelCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return problemModelCollections;

                using (MySqlCommand command = new MySqlCommand("GetProblemModelRadiostantionDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ProblemModelRadiostantionDataBaseModel problemModel = new ProblemModelRadiostantionDataBaseModel
                                    (reader.GetInt32(0), Encryption.DecryptCipherTextToPlainText(reader.GetString(1)));
                                problemModelCollections.Add(problemModel);
                            }
                            reader.Close();
                            return problemModelCollections;
                        }
                    }
                }
                return problemModelCollections;
            }
            catch { return problemModelCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddProblemModelDataBase(string problemUser)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;

                using (MySqlCommand command = new MySqlCommand("AddProblemModelDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"problemUser",
                        Encryption.EncryptPlainTextToCipherText(problemUser));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteProblemModelDataBase(string problemUser)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("DeleteProblemModelDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"problemUser",
                        Encryption.EncryptPlainTextToCipherText(problemUser));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
