using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories
{
    internal class HandbookParametersModelRadiostationRepository : 
        IHandbookParametersModelRadiostationRepository
    {
        public ObservableCollection<HandbookParametersModelRadiostationModel> 
            GetHandbookParametersAtModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel> 
            handbookParametersModelCollection, string model)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return handbookParametersModelCollection;

                using (MySqlCommand command = new MySqlCommand(
                    "GetHandbookParametersAtModelForCollection",
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
                                HandbookParametersModelRadiostationModel 
                                    handbookParametersModelRadiostationModel =
                                    new HandbookParametersModelRadiostationModel(
                                        reader.GetInt32(0), reader.GetString(1),
                                        reader.GetString(2), reader.GetString(3),
                                        reader.GetString(4), reader.GetString(5),
                                        reader.GetString(6), reader.GetString(7),
                                        reader.GetString(8), reader.GetString(9),
                                        reader.GetString(10), reader.GetString(11),
                                        reader.GetString(12), reader.GetString(13),
                                        reader.GetString(14), reader.GetString(15),
                                        reader.GetString(16), reader.GetString(17),
                                        reader.GetString(18), reader.GetString(19),
                                        reader.GetString(20), reader.GetString(21),
                                        reader.GetString(22), reader.GetString(23),
                                        reader.GetString(24), reader.GetString(25),
                                        reader.GetString(26), reader.GetString(27),
                                        reader.GetString(28), reader.GetString(29),
                                        reader.GetString(30), reader.GetString(31),
                                        reader.GetString(32), reader.GetString(33));
                                handbookParametersModelCollection.Add(
                                    handbookParametersModelRadiostationModel);
                            }
                            reader.Close();
                            return handbookParametersModelCollection;
                        }
                    }
                }
                return handbookParametersModelCollection;
            }
            catch { return handbookParametersModelCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
