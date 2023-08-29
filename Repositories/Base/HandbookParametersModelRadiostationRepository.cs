using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace ServiceTelecom.Repositories
{
    internal class HandbookParametersModelRadiostationRepository : 
        IHandbookParametersModelRadiostationRepository
    {
        public ObservableCollection<HandbookParametersModelRadiostationModel> 
            GetHandbookParametersByModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel> 
            handbookParametersModelCollection, string model)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return handbookParametersModelCollection;
                using (MySqlCommand command = new MySqlCommand(
                    "GetHandbookParametersByModelForCollection",
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


        public ObservableCollection<HandbookParametersModelRadiostationModel> 
            GetHandbookParametersAllModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersModelCollection)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return handbookParametersModelCollection;
                using (MySqlCommand command = new MySqlCommand(
                    "GetHandbookParametersAllModelForCollection",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
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

        public bool AddHandbookParametersForModel(
            string model, string minLowPowerLevelTransmitter, 
            string maxLowPowerLevelTransmitter, string minHighPowerLevelTransmitter, 
            string maxHighPowerLevelTransmitter, string minFrequencyDeviationTransmitter, 
            string maxFrequencyDeviationTransmitter, string minSensitivityTransmitter, 
            string maxSensitivityTransmitter, string minKNITransmitter, 
            string maxKNITransmitter, string minDeviationTransmitter, 
            string maxDeviationTransmitter, string minOutputPowerVoltReceiver, 
            string maxOutputPowerVoltReceiver, string minOutputPowerWattReceiver, 
            string maxOutputPowerWattReceiver, string minSelectivityReceiver, 
            string maxSelectivityReceiver, string minSensitivityReceiver, 
            string maxSensitivityReceiver, string minKNIReceiver, string maxKNIReceiver, 
            string minSuppressorReceiver, string maxSuppressorReceiver, 
            string minStandbyModeCurrentConsumption, string maxStandbyModeCurrentConsumption, 
            string minReceptionModeCurrentConsumption, string maxReceptionModeCurrentConsumption, 
            string minTransmissionModeCurrentConsumption, string maxTransmissionModeCurrentConsumption, 
            string minBatteryDischargeAlarmCurrentConsumption, 
            string maxBatteryDischargeAlarmCurrentConsumption)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "AddHandbookParametersForModel",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"minLowPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minLowPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"maxLowPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxLowPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"minHighPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minHighPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"maxHighPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxHighPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"minFrequencyDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minFrequencyDeviationTransmitter));
                    command.Parameters.AddWithValue($"maxFrequencyDeviationTransmitter",
                        Encryption.EncryptPlainTextToCipherText(maxFrequencyDeviationTransmitter));
                    command.Parameters.AddWithValue($"minSensitivityTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minSensitivityTransmitter));
                    command.Parameters.AddWithValue($"maxSensitivityTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxSensitivityTransmitter));
                    command.Parameters.AddWithValue($"minKNITransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minKNITransmitter));
                    command.Parameters.AddWithValue($"maxKNITransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxKNITransmitter));
                    command.Parameters.AddWithValue($"minDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minDeviationTransmitter));
                    command.Parameters.AddWithValue($"maxDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxDeviationTransmitter));
                    command.Parameters.AddWithValue($"minOutputPowerVoltReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minOutputPowerVoltReceiver));
                    command.Parameters.AddWithValue($"maxOutputPowerVoltReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxOutputPowerVoltReceiver));
                    command.Parameters.AddWithValue($"minOutputPowerWattReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minOutputPowerWattReceiver));
                    command.Parameters.AddWithValue($"maxOutputPowerWattReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxOutputPowerWattReceiver));
                    command.Parameters.AddWithValue($"minSelectivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minSelectivityReceiver));
                    command.Parameters.AddWithValue($"maxSelectivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxSelectivityReceiver));
                    command.Parameters.AddWithValue($"minSensitivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minSensitivityReceiver));
                    command.Parameters.AddWithValue($"maxSensitivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxSensitivityReceiver));
                    command.Parameters.AddWithValue($"minKNIReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minKNIReceiver));
                    command.Parameters.AddWithValue($"maxKNIReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxKNIReceiver));
                    command.Parameters.AddWithValue($"minSuppressorReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minSuppressorReceiver));
                    command.Parameters.AddWithValue($"maxSuppressorReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxSuppressorReceiver));
                    command.Parameters.AddWithValue($"minStandbyModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(minStandbyModeCurrentConsumption));
                    command.Parameters.AddWithValue($"maxStandbyModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxStandbyModeCurrentConsumption));
                    command.Parameters.AddWithValue($"minReceptionModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(minReceptionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"maxReceptionModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxReceptionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"minTransmissionModeCurrentConsumptionUser",
                      Encryption.EncryptPlainTextToCipherText(minTransmissionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"maxTransmissionModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxTransmissionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"minBatteryDischargeAlarmCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(minBatteryDischargeAlarmCurrentConsumption));
                    command.Parameters.AddWithValue($"maxBatteryDischargeAlarmCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxBatteryDischargeAlarmCurrentConsumption));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool CheckModelInHandbookParameters(string model)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "CheckModelInHandbookParameters",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count > 0) return false;
                        else return true;
                    }
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool ChangeHandbookParametersForModel(
            string model, string minLowPowerLevelTransmitter, 
            string maxLowPowerLevelTransmitter, string minHighPowerLevelTransmitter, 
            string maxHighPowerLevelTransmitter, string minFrequencyDeviationTransmitter, 
            string maxFrequencyDeviationTransmitter, string minSensitivityTransmitter, 
            string maxSensitivityTransmitter, string minKNITransmitter, string maxKNITransmitter, 
            string minDeviationTransmitter, string maxDeviationTransmitter, 
            string minOutputPowerVoltReceiver, string maxOutputPowerVoltReceiver, 
            string minOutputPowerWattReceiver, string maxOutputPowerWattReceiver, 
            string minSelectivityReceiver, string maxSelectivityReceiver, 
            string minSensitivityReceiver, string maxSensitivityReceiver, 
            string minKNIReceiver, string maxKNIReceiver, string minSuppressorReceiver, 
            string maxSuppressorReceiver, string minStandbyModeCurrentConsumption, 
            string maxStandbyModeCurrentConsumption, string minReceptionModeCurrentConsumption, 
            string maxReceptionModeCurrentConsumption, string minTransmissionModeCurrentConsumption, 
            string maxTransmissionModeCurrentConsumption, 
            string minBatteryDischargeAlarmCurrentConsumption, 
            string maxBatteryDischargeAlarmCurrentConsumption)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "ChangeHandbookParametersForModel",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"modelUser",
                        Encryption.EncryptPlainTextToCipherText(model));
                    command.Parameters.AddWithValue($"minLowPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minLowPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"maxLowPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxLowPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"minHighPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minHighPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"maxHighPowerLevelTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxHighPowerLevelTransmitter));
                    command.Parameters.AddWithValue($"minFrequencyDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minFrequencyDeviationTransmitter));
                    command.Parameters.AddWithValue($"maxFrequencyDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxFrequencyDeviationTransmitter));
                    command.Parameters.AddWithValue($"minSensitivityTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minSensitivityTransmitter));
                    command.Parameters.AddWithValue($"maxSensitivityTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxSensitivityTransmitter));
                    command.Parameters.AddWithValue($"minKNITransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minKNITransmitter));
                    command.Parameters.AddWithValue($"maxKNITransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxKNITransmitter));
                    command.Parameters.AddWithValue($"minDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(minDeviationTransmitter));
                    command.Parameters.AddWithValue($"maxDeviationTransmitterUser",
                        Encryption.EncryptPlainTextToCipherText(maxDeviationTransmitter));
                    command.Parameters.AddWithValue($"minOutputPowerVoltReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minOutputPowerVoltReceiver));
                    command.Parameters.AddWithValue($"maxOutputPowerVoltReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxOutputPowerVoltReceiver));
                    command.Parameters.AddWithValue($"minOutputPowerWattReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minOutputPowerWattReceiver));
                    command.Parameters.AddWithValue($"maxOutputPowerWattReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxOutputPowerWattReceiver));
                    command.Parameters.AddWithValue($"minSelectivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minSelectivityReceiver));
                    command.Parameters.AddWithValue($"maxSelectivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxSelectivityReceiver));
                    command.Parameters.AddWithValue($"minSensitivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minSensitivityReceiver));
                    command.Parameters.AddWithValue($"maxSensitivityReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxSensitivityReceiver));
                    command.Parameters.AddWithValue($"minKNIReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minKNIReceiver));
                    command.Parameters.AddWithValue($"maxKNIReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxKNIReceiver));
                    command.Parameters.AddWithValue($"minSuppressorReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(minSuppressorReceiver));
                    command.Parameters.AddWithValue($"maxSuppressorReceiverUser",
                        Encryption.EncryptPlainTextToCipherText(maxSuppressorReceiver));
                    command.Parameters.AddWithValue($"minStandbyModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(minStandbyModeCurrentConsumption));
                    command.Parameters.AddWithValue($"maxStandbyModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxStandbyModeCurrentConsumption));
                    command.Parameters.AddWithValue($"minReceptionModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(minReceptionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"maxReceptionModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxReceptionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"minTransmissionModeCurrentConsumptionUser",
                      Encryption.EncryptPlainTextToCipherText(minTransmissionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"maxTransmissionModeCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxTransmissionModeCurrentConsumption));
                    command.Parameters.AddWithValue($"minBatteryDischargeAlarmCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(minBatteryDischargeAlarmCurrentConsumption));
                    command.Parameters.AddWithValue($"maxBatteryDischargeAlarmCurrentConsumptionUser",
                       Encryption.EncryptPlainTextToCipherText(maxBatteryDischargeAlarmCurrentConsumption));
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }

        public bool DeleteHandbookParametersForModel(int idBase)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand command = new MySqlCommand(
                    "DeleteHandbookParametersForModel",
                    RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue($"idUser", idBase);
                    if (command.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch { return false; }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
