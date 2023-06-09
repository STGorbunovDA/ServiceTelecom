﻿using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;

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
                                    reader.GetInt32(0),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(1)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(2)),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(3)), 
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(4)), 
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

        public bool AddTutorialEngineer(string model, string problem, 
            string info, string actions, string login)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("AddTutorialEngineer",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"problemUser",
                        Encryption.EncryptPlainTextToCipherText(problem));
                    command.Parameters.AddWithValue($"infoUser",
                        Encryption.EncryptPlainTextToCipherText(info));
                    command.Parameters.AddWithValue($"actionsUser",
                        Encryption.EncryptPlainTextToCipherText(actions));
                    command.Parameters.AddWithValue($"loginUser",
                        Encryption.EncryptPlainTextToCipherText(login));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeTutorialEngineer(string id, string model, string problem, 
            string info, string actions, string login)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand("ChangeTutorialEngineer",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"idUser",Convert.ToInt32(id));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"problemUser",
                        Encryption.EncryptPlainTextToCipherText(problem));
                    command.Parameters.AddWithValue($"infoUser",
                        Encryption.EncryptPlainTextToCipherText(info));
                    command.Parameters.AddWithValue($"actionsUser",
                        Encryption.EncryptPlainTextToCipherText(actions));
                    command.Parameters.AddWithValue($"loginUser",
                        Encryption.EncryptPlainTextToCipherText(login));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public void DeleteTutorialEngineer(int id)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return;
                using (MySqlCommand command = new MySqlCommand("DeleteTutorialEngineer",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"idUser", id);
                    command.ExecuteNonQuery();
                }
            }
            catch { }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
