using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace ServiceTelecom.Repositories
{
    internal class WorkRadiostantionFullRepository : IWorkRadiostantionFullRepository,
        ISearchBySerialNumberInWorkRadiostantionFullRepository
    {
        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            SearchBySerialNumberInDatabaseCharacteristics(string road,
            string serialNumber,
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
            catch { MessageBox.Show("Ошибка считывания РСТ из общей базы"); return false; }
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

        public bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantionFull(
            string road, string city, string serialNumber, string decommissionNumberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeDecommissionNumberActBySerialNumberInDBRadiostantionFull",
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

        public bool ChangeNumberActBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeNumberActBySerialNumberInDBRadiostationFull",
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

        public string GetPrimaryMeansInDataBaseForRepair(string serialNumber, string city, string road)
        {
            string primaryMeans = string.Empty;
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return primaryMeans;
                using (MySqlCommand command = new MySqlCommand(
                   "GetPrimaryMeansInDataBase",
                   RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                primaryMeans = Encryption.DecryptCipherTextToPlainText(
                                    reader.GetString(0));

                        reader.Close();
                        return primaryMeans;
                    }
                }
            }
            catch { return primaryMeans; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public string GetProductNameInDataBaseForRepair(string serialNumber, string city, string road)
        {
            string productName = string.Empty;
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return productName;
                using (MySqlCommand command = new MySqlCommand(
                   "GetProductNameInDataBaseForRepair",
                   RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                                productName = Encryption.DecryptCipherTextToPlainText(
                                    reader.GetString(0));

                        reader.Close();
                        return productName;
                    }
                }
            }
            catch { return productName; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeNumberActRepairBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberActRepair)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeNumberActRepairBySerialNumberInDBRadiostationFull",
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

        public bool SetPrimaryMeansAndProductNameInDataBase(
            string road, string city, string serialNumber,
            string primaryMeans, string productName)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                   "SetPrimaryMeansAndProductNameInDataBase",
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
                    command.Parameters.AddWithValue($"primaryMeansUser",
                        Encryption.EncryptPlainTextToCipherText(primaryMeans));
                    command.Parameters.AddWithValue($"productNameUser",
                        Encryption.EncryptPlainTextToCipherText(productName));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRepairRadiostationForDocumentInDBRadiostantionFull(
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
                    "AddRepairRadiostationForDocumentInDBRadiostantionFull",
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

        public bool DeleteRepairRadiostationForDocumentInDBRadiostantionFull(
            string road, string city, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteRepairRadiostationForDocumentInDBRadiostantionFull",
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

        public bool AddDecommissionNumberActRadiostationInDBRadiostationFull(
            string road, string city, string serialNumber,
            string decommissionNumberAct, string reasonDecommissionNumberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "AddDecommissionNumberActRadiostationInDBRadiostationFull",
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
                        Encryption.EncryptPlainTextToCipherText(UserModelStatic.NULL_PRICE_TECHNICAL_SERVICES));
                    command.Parameters.AddWithValue($"decommissionUser",
                        Encryption.EncryptPlainTextToCipherText(
                            UserModelStatic.DECOMMISSION_RADIOSTANTION));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteDecommissionNumberActRadiostationInDBRadiostationFull(
            string road, string city, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteDecommissionNumberActRadiostationInDBRadiostationFull",
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
                            UserModelStatic.IN_WORK_TECHNICAL_SERVICES));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool LoadingFileForFullDB(string poligon, string company,
            string location, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string dateMaintenance,
            string numberAct, string city, string price, string road)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "LoadingFileForFullDB",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"poligonUser",
                        Encryption.EncryptPlainTextToCipherText(poligon));
                    command.Parameters.AddWithValue($"companyUser",
                        Encryption.EncryptPlainTextToCipherText(company));
                    command.Parameters.AddWithValue($"locationUser",
                        Encryption.EncryptPlainTextToCipherText(location));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"inventoryNumberUser",
                        Encryption.EncryptPlainTextToCipherText(inventoryNumber));
                    command.Parameters.AddWithValue($"networkNumberUser",
                        Encryption.EncryptPlainTextToCipherText(networkNumber));
                    command.Parameters.AddWithValue($"dateMaintenanceUser", dateMaintenance);
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"cityUser",
                        Encryption.EncryptPlainTextToCipherText(city));
                    command.Parameters.AddWithValue($"priceUser",
                        Encryption.EncryptPlainTextToCipherText(price));
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));

                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
