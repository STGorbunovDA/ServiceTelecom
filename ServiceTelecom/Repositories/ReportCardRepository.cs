using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace ServiceTelecom.Repositories
{
    internal class ReportCardRepository : IReportCardRepository
    {
        public ObservableCollection<ReportCardsDataBaseModel> 
            GetReportCardsDataBase(ObservableCollection<ReportCardsDataBaseModel> reportCards)
        {
			try
			{
                if (!InternetCheck.CheckSkyNET())
                    return reportCards;
                using (MySqlCommand command = new MySqlCommand("GetReportCardsDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ReportCardsDataBaseModel reportCard = new ReportCardsDataBaseModel(
                                    reader.GetInt32(0),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(1)),
                                    reader.GetDateTime(2), reader.GetDateTime(3));
                                reportCards.Add(reportCard);
                            }
                        }
                        reader.Close();
                        return reportCards;
                    }
                }
            }
            catch (Exception) { return reportCards; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }


        public ObservableCollection<string> 
            GetDateTimeInputCollectionsDataBase(ObservableCollection<string> dateTimeInputCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return dateTimeInputCollections;

                using (MySqlCommand command = new MySqlCommand("GetDateTimeInputCollectionsDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                                dateTimeInputCollections.Add(reader.GetDateTime(0).ToString("dd.MM.yyyy"));
                        }
                        reader.Close();
                        return dateTimeInputCollections;
                    }
                }
            }
            catch (Exception) { return dateTimeInputCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public void DeleteReportCardsDataBase(int idReportCards)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return;
                using (MySqlCommand command = new MySqlCommand("DeleteReportCardsDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"dID", idReportCards);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public ObservableCollection<ReportCardsDataBaseModel> 
            GetReportCardsAtCmbUserDataBase(ObservableCollection<ReportCardsDataBaseModel> 
            reportCards, string cmbUser)
        {
            try
            {

                if (!InternetCheck.CheckSkyNET())
                    return reportCards;
                using (MySqlCommand command = new MySqlCommand("GetReportCardsAtCmbUserDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"cmbUser", Encryption.EncryptPlainTextToCipherText(cmbUser));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ReportCardsDataBaseModel reportCard = new ReportCardsDataBaseModel(
                                    reader.GetInt32(0),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(1)),
                                    reader.GetDateTime(2), reader.GetDateTime(3));
                                reportCards.Add(reportCard);
                            }
                        }
                        reader.Close();
                        return reportCards;
                    }
                }
            }
            catch (Exception) { return reportCards; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }


        public ObservableCollection<ReportCardsDataBaseModel> 
            GetReportCardsAtCmbDateTimeInput(ObservableCollection<ReportCardsDataBaseModel> reportCards, 
            string selectedItemCmbUser)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return reportCards;
                using (MySqlCommand command = new MySqlCommand("GetReportCardsAtCmbDateTimeInput",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    string date = Convert.ToDateTime(selectedItemCmbUser).ToString("yyyy-MM-dd");
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"date", date);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ReportCardsDataBaseModel reportCard = new ReportCardsDataBaseModel(
                                    reader.GetInt32(0),
                                    Encryption.DecryptCipherTextToPlainText(reader.GetString(1)),
                                    reader.GetDateTime(2), reader.GetDateTime(3));
                                reportCards.Add(reportCard);
                            }
                        }
                        reader.Close();
                        return reportCards;
                    }
                }
            }
            catch (Exception) { return reportCards; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
