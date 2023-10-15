using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceTelecom.Repositories
{
    internal class WorkRadiostantionRepository : IWorkRadiostantionRepository
    {
        public ObservableCollection<string> GetCityAlongRoadForCityCollection(
            string road, ObservableCollection<string> cityCollections)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return cityCollections;

                using (MySqlCommand command = new MySqlCommand("GetCityAlongRoadForCityCollection",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                                cityCollections.Add(Encryption.DecryptCipherTextToPlainText(reader.GetString(0)));
                        }
                        reader.Close();
                    }
                    return cityCollections;
                }
            }
            catch (Exception) { return cityCollections; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            HowMuchToCheckRadiostantionsByCityForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return radiostationsForDocumentsCollection;
                using (MySqlCommand command = new MySqlCommand(
                    "HowMuchToCheckRadiostantionsByCityForDocumentsCollection",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
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
            catch (Exception) { return radiostationsForDocumentsCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetFullByRoadRadiostationsForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return radiostationsForDocumentsCollection;
                using (MySqlCommand command = new MySqlCommand(
                    "GetFullByRoadRadiostationsForDocumentsCollection",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
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
            catch (Exception) { return radiostationsForDocumentsCollection; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }


        public async Task<ObservableCollection<RadiostationForDocumentsDataBaseModel>> 
            GetRadiostationsForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET()) 
                    return await Task.Run(() => { return radiostationsForDocumentsCollection; });
                
                using (MySqlCommand command = new MySqlCommand(
                    "GetRadiostationsForDocumentsCollection",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
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
                    }
                    return await Task.Run(() => { return radiostationsForDocumentsCollection; });
                }
            }
            catch (Exception) { return await Task.Run(() => { return radiostationsForDocumentsCollection; }); }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRadiostationForDocumentInDataBase(string road, string numberAct,
            string dateMaintenance, string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificate, string phoneNumber, string post,
            string comment, string city, string location, string poligon, string company,
            string model, string serialNumber, string inventoryNumber, string networkNumber,
            string price, string battery, string manipulator, string antenna, string charger,
            string remont)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "AddRadiostationForDocumentInDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"dateMaintenanceUser",
                        Convert.ToDateTime(dateMaintenance).ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue($"representativeUser",
                        Encryption.EncryptPlainTextToCipherText(representative));
                    command.Parameters.AddWithValue($"numberIdentificationUser",
                        Encryption.EncryptPlainTextToCipherText(numberIdentification));
                    command.Parameters.AddWithValue($"dateOfIssuanceOfTheCertificateUser",
                        Convert.ToDateTime(dateOfIssuanceOfTheCertificate).ToString("yyyy-MM-dd"));
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

        public bool CheckSerialNumberForDocumentInDataBaseRadiostantion(
            string road, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "CheckSerialNumberForDocumentInDataBaseRadiostantion",
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
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool CheckNumberActOverTwentyForDocumentInDataBase(
            string road, string city, string numberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "CheckNumberActOverTwentyForDocumentInDataBase",
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
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 19) return true;
                        else return false;
                    }
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeNumberActBySerialNumberInDatabase(string road,
            string city, string serialNumber, string numberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeNumberActBySerialNumberFromTheDatabase",
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
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantion(
            string road, string city, string serialNumber, string decommissionNumberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeDecommissionNumberActBySerialNumberInDBRadiostantion",
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

        public bool ChangeByNumberActRepresentativeForDocumentInDataBase(
            string road, string city, string numberAct,
            string dateOfIssuanceOfTheCertificate,
            string representative, string numberIdentification,
            string post, string phoneNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeByNumberActRepresentativeForDocumentInDataBase",
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
                         Convert.ToDateTime(dateOfIssuanceOfTheCertificate).ToString("yyyy-MM-dd"));
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

        public bool ChangeByCompanyRepresentativeForDocumentInDataBase(
            string road, string city, string company,
            string dateOfIssuanceOfTheCertificate,
            string representative, string numberIdentification,
            string post, string phoneNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeByCompanyRepresentativeForDocumentInDataBase",
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
                        Convert.ToDateTime(dateOfIssuanceOfTheCertificate).ToString("yyyy-MM-dd"));
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

        public bool ChangeRadiostationForDocumentInDataBase(
            string road, string numberAct, string dateMaintenance,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificate, string phoneNumber,
            string post, string comment, string city, string location,
            string poligon, string company, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string price,
            string battery, string manipulator, string antenna,
            string charger, string remont)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeRadiostationForDocumentInDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"dateMaintenanceUser",
                       Convert.ToDateTime(dateMaintenance).ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue($"representativeUser",
                        Encryption.EncryptPlainTextToCipherText(representative));
                    command.Parameters.AddWithValue($"numberIdentificationUser",
                        Encryption.EncryptPlainTextToCipherText(numberIdentification));
                    command.Parameters.AddWithValue($"dateOfIssuanceOfTheCertificateUser",
                        Convert.ToDateTime(dateOfIssuanceOfTheCertificate).ToString("yyyy-MM-dd"));
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

        public void DeleteRadiostationFromDataBase(int idBase)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteRadiostationFromDataBase",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"idUser", idBase);
                    command.ExecuteNonQuery();
                }
            }
            catch { }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool CheckRepairInDBRadiostantionBySerialNumber(
            string road, string city, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "CheckRepairInDBRadiostantionBySerialNumber",
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
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0) return true;
                        else return false;
                    }
                }

            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeNumberActRepairBySerialNumberInDataBase(
            string road, string city, string serialNumber, string numberActRepair)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeNumberActRepairBySerialNumberInDataBase",
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
                    command.Parameters.AddWithValue($"numberActRepairUser",
                        Encryption.EncryptPlainTextToCipherText(numberActRepair));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRepairRadiostationForDocumentInDataBase(
            string road, string city, string serialNumber,
            string numberActRepair, string category, string priceRepair,
            string completedWorks_1, string parts_1,
            string completedWorks_2, string parts_2,
            string completedWorks_3, string parts_3,
            string completedWorks_4, string parts_4,
            string completedWorks_5, string parts_5,
            string completedWorks_6, string parts_6,
            string completedWorks_7, string parts_7)
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
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"numberActRepairUser",
                        Encryption.EncryptPlainTextToCipherText(numberActRepair));
                    command.Parameters.AddWithValue($"categoryUser",
                        Encryption.EncryptPlainTextToCipherText(category));
                    command.Parameters.AddWithValue($"priceRepairUser",
                        Encryption.EncryptPlainTextToCipherText(priceRepair));
                    command.Parameters.AddWithValue($"completedWorks_1User",
                        Encryption.EncryptPlainTextToCipherText(completedWorks_1));
                    command.Parameters.AddWithValue($"parts_1User",
                        Encryption.EncryptPlainTextToCipherText(parts_1));
                    command.Parameters.AddWithValue($"completedWorks_2User",
                        Encryption.EncryptPlainTextToCipherText(completedWorks_2));
                    command.Parameters.AddWithValue($"parts_2User",
                        Encryption.EncryptPlainTextToCipherText(parts_2));
                    command.Parameters.AddWithValue($"completedWorks_3User",
                       Encryption.EncryptPlainTextToCipherText(completedWorks_3));
                    command.Parameters.AddWithValue($"parts_3User",
                        Encryption.EncryptPlainTextToCipherText(parts_3));
                    command.Parameters.AddWithValue($"completedWorks_4User",
                       Encryption.EncryptPlainTextToCipherText(completedWorks_4));
                    command.Parameters.AddWithValue($"parts_4User",
                        Encryption.EncryptPlainTextToCipherText(parts_4));
                    command.Parameters.AddWithValue($"completedWorks_5User",
                      Encryption.EncryptPlainTextToCipherText(completedWorks_5));
                    command.Parameters.AddWithValue($"parts_5User",
                        Encryption.EncryptPlainTextToCipherText(parts_5));
                    command.Parameters.AddWithValue($"completedWorks_6User",
                      Encryption.EncryptPlainTextToCipherText(completedWorks_6));
                    command.Parameters.AddWithValue($"parts_6User",
                        Encryption.EncryptPlainTextToCipherText(parts_6));
                    command.Parameters.AddWithValue($"completedWorks_7User",
                     Encryption.EncryptPlainTextToCipherText(completedWorks_7));
                    command.Parameters.AddWithValue($"parts_7User",
                        Encryption.EncryptPlainTextToCipherText(parts_7));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteRepairRadiostationForDocumentInDataBase(
            string road, string city, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteRepairRadiostationForDocumentInDataBase",
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
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddDecommissionNumberActRadiostationInDB(
            string road, string city, string serialNumber,
            string decommissionNumberAct, string reasonDecommissionNumberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "AddDecommissionNumberActRadiostationInDB",
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
                    command.Parameters.AddWithValue($"reasonDecommissionNumberActUser",
                        Encryption.EncryptPlainTextToCipherText(reasonDecommissionNumberAct));
                    command.Parameters.AddWithValue($"priceUser",
                        Encryption.EncryptPlainTextToCipherText(GlobalValue.NULL_PRICE_TECHNICAL_SERVICES));
                    command.Parameters.AddWithValue($"decommissionUser",
                        Encryption.EncryptPlainTextToCipherText(
                            GlobalValue.DECOMMISSION_RADIOSTANTION));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteDecommissionNumberActRadiostationInDB(
            string road, string city, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteDecommissionNumberActRadiostationInDB",
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
                    command.Parameters.AddWithValue($"decommissionUser",
                       Encryption.EncryptPlainTextToCipherText(
                           GlobalValue.IN_WORK_TECHNICAL_SERVICES));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public string GetOfTheLastNumberActRepair(string road)
        {
            List<string> numberActRepairList = new List<string>();
            string numberActRepair = string.Empty;
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return numberActRepair;
                using (MySqlCommand command = new MySqlCommand(
                    "GetOfTheLastNumberActRepair",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                        Encryption.EncryptPlainTextToCipherText(road));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                numberActRepairList.Add(
                                    Encryption.DecryptCipherTextToPlainText(
                                        reader.GetString(0)));

                        reader.Close();
                        numberActRepairList.Sort();
                        return numberActRepairList.LastOrDefault();
                    }
                }
            }
            catch { return numberActRepair; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
  
        public bool ChangeStatusVerifiedRST(
            string road, string city, string serialNumber, 
            string noteRadioStationParameters, string verifiedRST)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeStatusVerifiedRST",
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
                    command.Parameters.AddWithValue($"noteRadioStationParametersUser",
                       Encryption.EncryptPlainTextToCipherText(noteRadioStationParameters));
                    command.Parameters.AddWithValue($"VerifiedRSTUser",
                        Encryption.EncryptPlainTextToCipherText(verifiedRST));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
