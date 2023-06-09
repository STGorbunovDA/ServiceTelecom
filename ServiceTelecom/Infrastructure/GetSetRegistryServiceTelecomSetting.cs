﻿using Microsoft.Win32;
using System;

namespace ServiceTelecom.Infrastructure
{
    internal class GetSetRegistryServiceTelecomSetting
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
                    RegistryKey helloKey2 = currentUserKey2.OpenSubKey("SOFTWARE\\ServiceTelekomSetting\\City");
                    return helloKey2.GetValue("Город проверки").ToString();
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }


        public void SetRegistryCityForAddChange(string city)
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey helloKey = currentUserKey.CreateSubKey(
                "SOFTWARE\\ServiceTelekomSetting\\City");
            helloKey.SetValue("Город для добавления и сохранения", $"{city}");
            helloKey.Close();
        }

        public string GetRegistryCityForAddChange()
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

        public void SetRegistryNumberActForFillOutCollections(
            string numberActFillOutCollections)
        {
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
    }
}
