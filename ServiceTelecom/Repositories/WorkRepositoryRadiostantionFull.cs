using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Data;
using System.Windows;

namespace ServiceTelecom.Repositories
{
    internal class WorkRepositoryRadiostantionFull : IWorkRepositoryRadiostantionFull
    {
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
    }
}
