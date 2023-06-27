using Microsoft.Win32;
using ServiceTelecom.Infrastructure.Interfaces;
using ServiceTelecom.Models;
using System;
using System.Collections.Generic;

namespace ServiceTelecom.Infrastructure
{
    internal class GetSetRegistryServiceTelecomSetting :
        IGetSetRegistryServiceTelecomSetting
    {
        public void SetRegistryUser(string user)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey(
                "SOFTWARE\\ServiceTelekomSetting\\Login");
            helloKey.SetValue("Login", $"{user}");
            helloKey.Close();
        }

        public string GetRegistryUser()
        {
            try
            {
                RegistryKey reg1 = Registry.CurrentUser.OpenSubKey(
                    $"SOFTWARE\\ServiceTelekomSetting\\Login");
                if (reg1 != null)
                {
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey(
                        $"SOFTWARE\\ServiceTelekomSetting\\Login");
                    return helloKey.GetValue("Login").ToString();
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SetRegistryCity(string city)
        {
            if (String.IsNullOrWhiteSpace(city))
                return;
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey(
                "SOFTWARE\\ServiceTelekomSetting\\City");
            helloKey.SetValue("Город проверки", $"{city}");
            helloKey.Close();
        }

        public string GetRegistryCity()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\ServiceTelekomSetting\\City");
                if (reg != null)
                {
                    RegistryKey currentUserKey2 = Registry.CurrentUser;
                    RegistryKey helloKey2 = currentUserKey2.OpenSubKey(
                        "SOFTWARE\\ServiceTelekomSetting\\City");
                    return helloKey2.GetValue("Город проверки").ToString();
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SetRegistryCityForAddChangeDelete(string city)
        {
            if (String.IsNullOrWhiteSpace(city))
                return;
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey(
                "SOFTWARE\\ServiceTelekomSetting\\CityAddChangeDelete");
            helloKey.SetValue("Город для добавления и сохранения", $"{city}");
            helloKey.Close();
        }

        public string GetRegistryCityForAddChangeDelete()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\\ServiceTelekomSetting\\CityAddChangeDelete");
                if (reg != null)
                {
                    RegistryKey currentUserKey2 = Registry.CurrentUser;
                    RegistryKey helloKey2 = currentUserKey2.OpenSubKey(
                        "SOFTWARE\\ServiceTelekomSetting\\CityAddChangeDelete");
                    return helloKey2.GetValue("Город для добавления и сохранения").ToString();
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SetRegistryNumberActForSignCollections(string numberActSignCollections)
        {
            if (String.IsNullOrWhiteSpace(numberActSignCollections))
                return;
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey(
                $"SOFTWARE\\ServiceTelekomSetting\\Акты_на_подпись");
            helloKey.SetValue("Акты_на_подпись", $"{numberActSignCollections}");
            helloKey.Close();
        }

        public string GetRegistryNumberActForSignCollections()
        {
            try
            {
                RegistryKey reg3 = Registry.CurrentUser.OpenSubKey(
                $"SOFTWARE\\ServiceTelekomSetting\\Акты_на_подпись");
                if (reg3 != null)
                {
                    string addRegistry = String.Empty;
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey(
                        $"SOFTWARE\\ServiceTelekomSetting\\Акты_на_подпись");
                    return helloKey.GetValue("Акты_на_подпись").ToString();
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public void SetRegistryNumberActForFillOutCollections(string numberActFillOutCollections)
        {
            if (String.IsNullOrWhiteSpace(numberActFillOutCollections))
                return;
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey(
                $"SOFTWARE\\ServiceTelekomSetting\\Акты_незаполненные");
            helloKey.SetValue("Акты_незаполненные", $"{numberActFillOutCollections}");
            helloKey.Close();
        }

        public string GetRegistryNumberActForFillOutCollections()
        {
            try
            {
                RegistryKey reg3 = Registry.CurrentUser.OpenSubKey(
               $"SOFTWARE\\ServiceTelekomSetting\\Акты_незаполненные");
                if (reg3 != null)
                {
                    string addRegistry = String.Empty;
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey(
                        $"SOFTWARE\\ServiceTelekomSetting\\Акты_незаполненные");
                    return helloKey.GetValue("Акты_незаполненные").ToString();
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public List<RepairDataCompanyModel> GetRepairData(string company)
        {
            List<RepairDataCompanyModel> repairData = new List<RepairDataCompanyModel>();

            try
            {
                RegistryKey reg =
                    Registry.CurrentUser.OpenSubKey(
                        $"SOFTWARE\\ServiceTelekomSetting\\Данные для ремонта\\{company}");
                if (reg != null)
                {
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey(
                         $"SOFTWARE\\ServiceTelekomSetting\\Данные для ремонта\\{company}");

                    RepairDataCompanyModel repairDataCompanyModel 
                        = new RepairDataCompanyModel(
                            helloKey.GetValue("ОКПО").ToString(),
                            helloKey.GetValue("БЕ").ToString(),
                            helloKey.GetValue("Полное наименование предприятия").ToString(),
                            helloKey.GetValue("Руководитель ФИО").ToString(),
                            helloKey.GetValue("Руководитель Должность").ToString(),
                            helloKey.GetValue("Председатель ФИО").ToString(),
                            helloKey.GetValue("Председатель Должность").ToString(),
                            helloKey.GetValue("1 представитель комиссии ФИО").ToString(),
                            helloKey.GetValue("1 представитель комиссии Должность").ToString(),
                            helloKey.GetValue("2 представитель комиссии ФИО").ToString(),
                            helloKey.GetValue("2 представитель комиссии Должность").ToString(),
                            helloKey.GetValue("3 представитель комиссии ФИО").ToString(),
                            helloKey.GetValue("3 представитель комиссии Должность").ToString());
                    repairData.Add(repairDataCompanyModel);

                    helloKey.Close();
                    return repairData;
                }
                return repairData;
            }
            catch (Exception)
            {
                return repairData;
            }
        }

        public bool SetRepairData(string company, string okpo, string be,
            string fullNameCompany, string chiefСompanyFIO, string chiefСompanyPost,
            string chairmanСompanyFIO, string chairmanСompanyPost,
            string firstMemberCommissionFIO, string firstMemberCommissionPost,
            string secondMemberCommissionFIO, string secondMemberCommissionPost,
            string thirdMemberCommissionFIO, string thirdMemberCommissionPost)
        {
            try
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey helloKey = currentUserKey.CreateSubKey(
                    $"SOFTWARE\\ServiceTelekomSetting\\Данные для ремонта\\{company}");
                helloKey.SetValue("ОКПО", $"{okpo}");
                helloKey.SetValue("БЕ", $"{be}");
                helloKey.SetValue("Полное наименование предприятия", $"{fullNameCompany}");
                helloKey.SetValue("Руководитель ФИО", $"{chiefСompanyFIO}");
                helloKey.SetValue("Руководитель Должность", $"{chiefСompanyPost}");
                helloKey.SetValue("Председатель ФИО", $"{chairmanСompanyFIO}");
                helloKey.SetValue("Председатель Должность", $"{chairmanСompanyPost}");
                helloKey.SetValue("1 представитель комиссии ФИО", $"{firstMemberCommissionFIO}");
                helloKey.SetValue("1 представитель комиссии Должность", $"{firstMemberCommissionPost}");
                helloKey.SetValue("2 представитель комиссии ФИО", $"{secondMemberCommissionFIO}");
                helloKey.SetValue("2 представитель комиссии Должность", $"{secondMemberCommissionPost}");
                helloKey.SetValue("3 представитель комиссии ФИО", $"{thirdMemberCommissionFIO}");
                helloKey.SetValue("3 представитель комиссии Должность", $"{thirdMemberCommissionPost}");
                helloKey.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
         

        public List<RepositoryDataBaseModel> GetRegistryForRepositoryDataBase()
        {
            List<RepositoryDataBaseModel> listRepositoryDataBaseModel = new List<RepositoryDataBaseModel>();
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(
                        $"SOFTWARE\\ServiceTelekomSetting\\RepositoryDataBaseModel");
                if (reg != null)
                {
                    RegistryKey currentUserKey = Registry.CurrentUser;
                    RegistryKey helloKey = currentUserKey.OpenSubKey(
                         $"SOFTWARE\\ServiceTelekomSetting\\RepositoryDataBaseModel");

                    RepositoryDataBaseModel repositoryDataBaseModel
                        = new RepositoryDataBaseModel(
                            helloKey.GetValue("Server").ToString(),
                            helloKey.GetValue("Port").ToString(),
                            helloKey.GetValue("Username").ToString(),
                            helloKey.GetValue("Password").ToString(),
                            helloKey.GetValue("Database").ToString(),
                            helloKey.GetValue("CodeWord").ToString());
                    listRepositoryDataBaseModel.Add(repositoryDataBaseModel);

                    helloKey.Close();
                    return listRepositoryDataBaseModel;
                }
                return listRepositoryDataBaseModel;
            }
            catch
            {
                return listRepositoryDataBaseModel;
            }
        }
        public bool SetRegistryForRepositoryDataBaseAndCodeWord(string server, string port, 
            string username, string password, string database, string codeWord)
        {
            try
            {
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey helloKey = currentUserKey.CreateSubKey(
                     $"SOFTWARE\\ServiceTelekomSetting\\RepositoryDataBaseModel");
                helloKey.SetValue("Server", $"{server}");
                helloKey.SetValue("Port", $"{port}");
                helloKey.SetValue("Username", $"{username}");
                helloKey.SetValue("Password", $"{password}");
                helloKey.SetValue("Database", $"{database}");
                helloKey.SetValue("CodeWord", $"{codeWord}");
                helloKey.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
