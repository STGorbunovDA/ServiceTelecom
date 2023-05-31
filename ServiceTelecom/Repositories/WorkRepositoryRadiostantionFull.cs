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
    internal class WorkRepositoryRadiostantionFull : IWorkRepositoryRadiostantionFull, 
        ISearchBySerialNumberInDatabaseRadiostantionFull
    {
        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            SearchBySerialNumberInDatabaseCharacteristics(string road,
            string city, string serialNumber,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return radiostationsForDocumentsCollection;
                using (MySqlCommand command = new MySqlCommand
                    ("SearchBySerialNumberForFeaturesAdditionsFromTheDatabase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                RadiostationForDocumentsDataBaseModel
                                    radiostationForDocumentsDataBaseModels =
                                    new RadiostationForDocumentsDataBaseModel(
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                    reader.GetString(6), reader.GetString(7), reader.GetDateTime(8),
                                    reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                    reader.GetString(12), reader.GetString(13), reader.GetString(14),
                                    reader.GetDateTime(15), reader.GetString(16), reader.GetString(17),
                                    reader.GetString(18), reader.GetString(19), reader.GetString(20),
                                    reader.GetString(21), reader.GetString(22), reader.GetString(23),
                                    reader.GetString(24), reader.GetString(25), reader.GetString(26),
                                    reader.GetString(27), reader.GetString(28), reader.GetString(29),
                                    reader.GetString(30), reader.GetString(31), reader.GetString(32),
                                    reader.GetString(33), reader.GetString(34), reader.GetString(35),
                                    reader.GetString(36), reader.GetString(37), reader.GetString(38),
                                    reader.GetString(39), reader.GetString(40), reader.GetString(41));
                                radiostationsForDocumentsCollection.Add(
                                    radiostationForDocumentsDataBaseModels);
                            }
                        }
                        reader.Close();
                        return radiostationsForDocumentsCollection;
                    }
                }
            }
            catch { return radiostationsForDocumentsCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool CheckSerialNumberForDocumentInDataBaseRadiostantionFull(
            string road, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "CheckSerialNumberForDocumentInDataBaseRadiostantionFull",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0) return true;
                        else return false;
                    }
                }
            }
            catch { MessageBox.Show("Ошибка считывания РСТ из общей базы"); return false;  }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeRadiostationFullForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase, 
            string representative, string numberIdentification, 
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber, 
            string post, string comment, string city, string location, string poligon, 
            string company, string model, string serialNumber, string inventoryNumber, 
            string networkNumber, string price, string battery, string manipulator, 
            string antenna, string charger, string remont)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeRadiostationFullForDocumentInDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"dateMaintenanceUser",
                        dateMaintenanceDataBase);
                    command.Parameters.AddWithValue($"representativeUser",
                        Encryption.EncryptPlainTextToCipherText(representative));
                    command.Parameters.AddWithValue($"numberIdentificationUser",
                        Encryption.EncryptPlainTextToCipherText(numberIdentification));
                    command.Parameters.AddWithValue($"dateOfIssuanceOfTheCertificateUser",
                        dateOfIssuanceOfTheCertificateDataBase);
                    command.Parameters.AddWithValue($"phoneNumberUser",
                        Encryption.EncryptPlainTextToCipherText(phoneNumber));
                    command.Parameters.AddWithValue($"postUser",
                        Encryption.EncryptPlainTextToCipherText(post));
                    command.Parameters.AddWithValue($"commentUser",
                        Encryption.EncryptPlainTextToCipherText(comment));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"locationUser",
                        Encryption.EncryptPlainTextToCipherText(location));
                    command.Parameters.AddWithValue($"poligonUser",
                        Encryption.EncryptPlainTextToCipherText(poligon));
                    command.Parameters.AddWithValue($"companyUser",
                        Encryption.EncryptPlainTextToCipherText(company));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"inventoryNumberUser",
                        Encryption.EncryptPlainTextToCipherText(inventoryNumber));
                    command.Parameters.AddWithValue($"networkNumberUser",
                        Encryption.EncryptPlainTextToCipherText(networkNumber));
                    command.Parameters.AddWithValue($"priceUser",
                        Encryption.EncryptPlainTextToCipherText(price));
                    command.Parameters.AddWithValue($"batteryUser",
                        Encryption.EncryptPlainTextToCipherText(battery));
                    command.Parameters.AddWithValue($"manipulatorUser",
                        Encryption.EncryptPlainTextToCipherText(manipulator));
                    command.Parameters.AddWithValue($"antennaUser",
                        Encryption.EncryptPlainTextToCipherText(antenna));
                    command.Parameters.AddWithValue($"chargerUser",
                        Encryption.EncryptPlainTextToCipherText(charger));
                    command.Parameters.AddWithValue($"remontUser",
                        Encryption.EncryptPlainTextToCipherText(remont));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRadiostationFullForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase, 
            string representative, string numberIdentification, 
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber, 
            string post, string comment, string city, string location, 
            string poligon, string company, string model, string serialNumber, 
            string inventoryNumber, string networkNumber, string price, 
            string battery, string manipulator, string antenna, string charger, 
            string remont)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "AddRadiostationFullForDocumentInDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"dateMaintenanceUser",
                        dateMaintenanceDataBase);
                    command.Parameters.AddWithValue($"representativeUser",
                        Encryption.EncryptPlainTextToCipherText(representative));
                    command.Parameters.AddWithValue($"numberIdentificationUser",
                        Encryption.EncryptPlainTextToCipherText(numberIdentification));
                    command.Parameters.AddWithValue($"dateOfIssuanceOfTheCertificateUser",
                        dateOfIssuanceOfTheCertificateDataBase);
                    command.Parameters.AddWithValue($"phoneNumberUser",
                        Encryption.EncryptPlainTextToCipherText(phoneNumber));
                    command.Parameters.AddWithValue($"postUser",
                        Encryption.EncryptPlainTextToCipherText(post));
                    command.Parameters.AddWithValue($"commentUser",
                        Encryption.EncryptPlainTextToCipherText(comment));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"locationUser",
                        Encryption.EncryptPlainTextToCipherText(location));
                    command.Parameters.AddWithValue($"poligonUser",
                        Encryption.EncryptPlainTextToCipherText(poligon));
                    command.Parameters.AddWithValue($"companyUser",
                        Encryption.EncryptPlainTextToCipherText(company));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"inventoryNumberUser",
                        Encryption.EncryptPlainTextToCipherText(inventoryNumber));
                    command.Parameters.AddWithValue($"networkNumberUser",
                        Encryption.EncryptPlainTextToCipherText(networkNumber));
                    command.Parameters.AddWithValue($"priceUser",
                        Encryption.EncryptPlainTextToCipherText(price));
                    command.Parameters.AddWithValue($"batteryUser",
                        Encryption.EncryptPlainTextToCipherText(battery));
                    command.Parameters.AddWithValue($"manipulatorUser",
                        Encryption.EncryptPlainTextToCipherText(manipulator));
                    command.Parameters.AddWithValue($"antennaUser",
                        Encryption.EncryptPlainTextToCipherText(antenna));
                    command.Parameters.AddWithValue($"chargerUser",
                        Encryption.EncryptPlainTextToCipherText(charger));
                    command.Parameters.AddWithValue($"remontUser",
                        Encryption.EncryptPlainTextToCipherText(remont));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeDecommissionNumberActBySerialNumberFromDBRadiostantionFull(
            string road, string city, string serialNumber, string decommissionNumberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeDecommissionNumberActBySerialNumberFromDBRadiostantionFull",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"decommissionNumberActUser",
                        Encryption.EncryptPlainTextToCipherText(decommissionNumberAct));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull(
            string road, string city, string numberAct, 
            string dateOfIssuanceOfTheCertificateDataBase, 
            string representative, string numberIdentification, 
            string post, string phoneNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                       Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"numberActUser",
                       Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"dateOfIssuanceOfTheCertificateDataBaseUser",
                       dateOfIssuanceOfTheCertificateDataBase);
                    command.Parameters.AddWithValue($"representativeUser",
                           Encryption.EncryptPlainTextToCipherText(representative));
                    command.Parameters.AddWithValue($"numberIdentificationUser",
                           Encryption.EncryptPlainTextToCipherText(numberIdentification));
                    command.Parameters.AddWithValue($"postUser",
                           Encryption.EncryptPlainTextToCipherText(post));
                    command.Parameters.AddWithValue($"phoneNumberUser",
                           Encryption.EncryptPlainTextToCipherText(phoneNumber));
                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }

            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeByCompanyRepresentativeForDocumentInDBRadiostantionFull(
            string road, string city, string company, 
            string dateOfIssuanceOfTheCertificateDataBase, 
            string representative, string numberIdentification, 
            string post, string phoneNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeByCompanyRepresentativeForDocumentInDBRadiostantionFull",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                       Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"companyUser",
                       Encryption.EncryptPlainTextToCipherText(company));
                    command.Parameters.AddWithValue($"dateOfIssuanceOfTheCertificateDataBaseUser",
                       dateOfIssuanceOfTheCertificateDataBase);
                    command.Parameters.AddWithValue($"representativeUser",
                           Encryption.EncryptPlainTextToCipherText(representative));
                    command.Parameters.AddWithValue($"numberIdentificationUser",
                           Encryption.EncryptPlainTextToCipherText(numberIdentification));
                    command.Parameters.AddWithValue($"postUser",
                           Encryption.EncryptPlainTextToCipherText(post));
                    command.Parameters.AddWithValue($"phoneNumberUser",
                           Encryption.EncryptPlainTextToCipherText(phoneNumber));
                    if (command.ExecuteNonQuery() > 0) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
