using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace ServiceTelecom.Repositories
{
    internal class RadiostationParametersRepository : IRadiostationParametersRepository
    {
        public async Task<ObservableCollection<RadiostationParametersDataBaseModel>>
            GetRadiostationsParametersCollection(
            ObservableCollection<RadiostationParametersDataBaseModel>
            radiostationsParametersCollection, string road, string city)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return await Task.Run(() => { return radiostationsParametersCollection; });
                using (MySqlCommand command = new MySqlCommand(
                    "GetRadiostationsParametersCollection",
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
                                RadiostationParametersDataBaseModel
                                    radiostationParametersDataBaseModel =
                                    new RadiostationParametersDataBaseModel(
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                    reader.GetString(6), reader.GetDateTime(7), reader.GetString(8),
                                    reader.GetString(9), reader.GetString(10), reader.GetString(11),
                                    reader.GetString(12), reader.GetString(13), reader.GetString(14),
                                    reader.GetString(15), reader.GetString(16), reader.GetString(17),
                                    reader.GetString(18), reader.GetString(19), reader.GetString(20),
                                    reader.GetString(21), reader.GetString(22), reader.GetString(23),
                                    reader.GetString(24), reader.GetString(25), reader.GetString(26),
                                    reader.GetString(27), reader.GetString(28), reader.GetString(29),
                                    reader.GetString(30), reader.GetString(31));
                                radiostationsParametersCollection.Add(
                                radiostationParametersDataBaseModel);
                            }
                        }
                        reader.Close();
                    }
                    return await Task.Run(() => { return radiostationsParametersCollection; });
                }
            }
            catch (Exception) { return await Task.Run(() => { return radiostationsParametersCollection; }); }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool AddRadiostationParameters(
            string road, string city, string dateMaintenance, string location,
            string model, string serialNumber, string company,
            string numberAct, string lowPowerLevelTransmitter,
            string highPowerLevelTransmitter, string frequencyDeviationTransmitter,
            string sensitivityTransmitter, string KNITransmitter,
            string deviationTransmitter, string outputPowerVoltReceiver,
            string outputPowerWattReceiver, string selectivityReceiver,
            string sensitivityReceiver, string KNIReceiver,
            string suppressorReceiver, string frequenciesCompletedForRadiostantion,
            string standbyModeCurrentConsumption, string receptionModeCurrentConsumption,
            string transmissionModeCurrentConsumption,
            string batteryDischargeAlarmCurrentConsumption,
            string batteryChargerAccessories, string manipulatorAccessories,
            string nameAKB, string percentAKB, string noteRadioStationParameters,
            string passedTechnicalServices)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "AddRadiostationParameters",
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
                    command.Parameters.AddWithValue($"locationUser",
                       Encryption.EncryptPlainTextToCipherText(location));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"dateMaintenanceUser",
                        Convert.ToDateTime(dateMaintenance).ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"lowPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(lowPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"highPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(highPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"frequencyDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(frequencyDeviationTransmitter));
                    command.Parameters.AddWithValue($"sensitivityTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(sensitivityTransmitter));
                    command.Parameters.AddWithValue($"KNITransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(KNITransmitter));
                    command.Parameters.AddWithValue($"deviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(deviationTransmitter));
                    command.Parameters.AddWithValue($"outputPowerVoltReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(outputPowerVoltReceiver));
                    command.Parameters.AddWithValue($"outputPowerWattReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(outputPowerWattReceiver));
                    command.Parameters.AddWithValue($"selectivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(selectivityReceiver));
                    command.Parameters.AddWithValue($"sensitivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(sensitivityReceiver));
                    command.Parameters.AddWithValue($"KNIReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(KNIReceiver));
                    command.Parameters.AddWithValue($"suppressorReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(suppressorReceiver));
                    command.Parameters.AddWithValue($"frequenciesCompletedForRadiostantionUser",
                        Encryption.EncryptPlainTextToCipherText(frequenciesCompletedForRadiostantion));
                    command.Parameters.AddWithValue($"standbyModeCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(standbyModeCurrentConsumption));
                    command.Parameters.AddWithValue($"receptionModeCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(receptionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"transmissionModeCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(transmissionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"batteryDischargeAlarmCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(batteryDischargeAlarmCurrentConsumption));
                    command.Parameters.AddWithValue($"batteryChargerAccessoriesUser",
                        Encryption.EncryptPlainTextToCipherText(batteryChargerAccessories));
                    command.Parameters.AddWithValue($"manipulatorAccessoriesUser",
                        Encryption.EncryptPlainTextToCipherText(manipulatorAccessories));
                    command.Parameters.AddWithValue($"nameAKBUser",
                        Encryption.EncryptPlainTextToCipherText(nameAKB));
                    command.Parameters.AddWithValue($"percentAKBUser",
                        Encryption.EncryptPlainTextToCipherText(percentAKB));
                    command.Parameters.AddWithValue($"noteRadioStationParametersUser",
                        Encryption.EncryptPlainTextToCipherText(noteRadioStationParameters));
                    command.Parameters.AddWithValue($"passedTechnicalServicesUser",
                        Encryption.EncryptPlainTextToCipherText(passedTechnicalServices));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool CheckSerialNumberInRadiostationParameters(
            string road, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "CheckSerialNumberInRadiostationParameters",
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

        public bool ChangeRadiostationParameters(
            string road, string city, string dateMaintenance, string location,
            string model, string serialNumber, string company,
            string numberAct, string lowPowerLevelTransmitter,
            string highPowerLevelTransmitter, string frequencyDeviationTransmitter,
            string sensitivityTransmitter, string KNITransmitter,
            string deviationTransmitter, string outputPowerVoltReceiver,
            string outputPowerWattReceiver, string selectivityReceiver,
            string sensitivityReceiver, string KNIReceiver,
            string suppressorReceiver, string frequenciesCompletedForRadiostantion,
            string standbyModeCurrentConsumption, string receptionModeCurrentConsumption,
            string transmissionModeCurrentConsumption,
            string batteryDischargeAlarmCurrentConsumption,
            string batteryChargerAccessories, string manipulatorAccessories,
            string nameAKB, string percentAKB, string noteRadioStationParameters,
            string passedTechnicalServices)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeRadiostationParameters",
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
                    command.Parameters.AddWithValue($"locationUser",
                       Encryption.EncryptPlainTextToCipherText(location));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"dateMaintenanceUser",
                        Convert.ToDateTime(dateMaintenance).ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"lowPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(lowPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"highPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(highPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"frequencyDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(frequencyDeviationTransmitter));
                    command.Parameters.AddWithValue($"sensitivityTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(sensitivityTransmitter));
                    command.Parameters.AddWithValue($"KNITransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(KNITransmitter));
                    command.Parameters.AddWithValue($"deviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(deviationTransmitter));
                    command.Parameters.AddWithValue($"outputPowerVoltReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(outputPowerVoltReceiver));
                    command.Parameters.AddWithValue($"outputPowerWattReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(outputPowerWattReceiver));
                    command.Parameters.AddWithValue($"selectivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(selectivityReceiver));
                    command.Parameters.AddWithValue($"sensitivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(sensitivityReceiver));
                    command.Parameters.AddWithValue($"KNIReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(KNIReceiver));
                    command.Parameters.AddWithValue($"suppressorReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(suppressorReceiver));
                    command.Parameters.AddWithValue($"frequenciesCompletedForRadiostantionUser",
                        Encryption.EncryptPlainTextToCipherText(frequenciesCompletedForRadiostantion));
                    command.Parameters.AddWithValue($"standbyModeCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(standbyModeCurrentConsumption));
                    command.Parameters.AddWithValue($"receptionModeCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(receptionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"transmissionModeCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(transmissionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"batteryDischargeAlarmCurrentConsumptionUser",
                        Encryption.EncryptPlainTextToCipherText(batteryDischargeAlarmCurrentConsumption));
                    command.Parameters.AddWithValue($"batteryChargerAccessoriesUser",
                        Encryption.EncryptPlainTextToCipherText(batteryChargerAccessories));
                    command.Parameters.AddWithValue($"manipulatorAccessoriesUser",
                        Encryption.EncryptPlainTextToCipherText(manipulatorAccessories));
                    command.Parameters.AddWithValue($"nameAKBUser",
                        Encryption.EncryptPlainTextToCipherText(nameAKB));
                    command.Parameters.AddWithValue($"percentAKBUser",
                        Encryption.EncryptPlainTextToCipherText(percentAKB));
                    command.Parameters.AddWithValue($"noteRadioStationParametersUser",
                        Encryption.EncryptPlainTextToCipherText(noteRadioStationParameters));
                    command.Parameters.AddWithValue($"passedTechnicalServicesUser",
                        Encryption.EncryptPlainTextToCipherText(passedTechnicalServices));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeСharacteristicsRadiostantionForRadiostationParameters(
            string road, string city, string company, string location,
            string numberAct, string model, string comment, string battery,
            string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeСharacteristicsRadiostantionForRadiostationParameters",
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
                    command.Parameters.AddWithValue($"locationUser",
                       Encryption.EncryptPlainTextToCipherText(location));
                    command.Parameters.AddWithValue($"numberActUser",
                        Encryption.EncryptPlainTextToCipherText(numberAct));
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"commentUser",
                        Encryption.EncryptPlainTextToCipherText(comment));
                    command.Parameters.AddWithValue($"batteryUser",
                        Encryption.EncryptPlainTextToCipherText(battery));
                    command.Parameters.AddWithValue($"serialNumberUser",
                        Encryption.EncryptPlainTextToCipherText(serialNumber));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeNumberActForRadiostationParameters(
            string road, string serialNumber, string newNumberAct)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeNumberActForRadiostationParameters",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"serialNumberUser",
                       Encryption.EncryptPlainTextToCipherText(serialNumber));
                    command.Parameters.AddWithValue($"newNumberActUser",
                       Encryption.EncryptPlainTextToCipherText(newNumberAct));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteRadiostantionFromRadiostationParameters(
            string road, string serialNumber)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteRadiostantionFromRadiostationParameters",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"roadUser",
                       Encryption.EncryptPlainTextToCipherText(road));
                    command.Parameters.AddWithValue($"serialNumberUser",
                       Encryption.EncryptPlainTextToCipherText(serialNumber));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }

            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
