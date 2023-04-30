using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories
{
    internal class TutorialEngineerRepository : ITutorialEngineerRepository
    {
        public ObservableCollection<TutorialEngineerDataBaseModel> 
            GetTutorialsEngineerDataBase(ObservableCollection<TutorialEngineerDataBaseModel> 
            tutorialsEngineer)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return tutorialsEngineer;
                using (MySqlCommand command = new MySqlCommand("GetTutorialsEngineerDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                TutorialEngineerDataBaseModel tutorialEngineer = new TutorialEngineerDataBaseModel(
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), 
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(5)));
                                tutorialsEngineer.Add(tutorialEngineer);
                            }
                        }
                        reader.Close();
                        return tutorialsEngineer;
                    }
                }
            }
            catch (Exception) { return tutorialsEngineer; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
