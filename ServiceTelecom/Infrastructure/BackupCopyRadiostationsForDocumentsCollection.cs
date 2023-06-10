using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using ServiceTelecom.Infrastructure.Interfaces;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ServiceTelecom.Infrastructure
{
    internal class BackupCopyRadiostationsForDocumentsCollection
        : IBackupCopyRadiostationsForDocumentsCollection
    {
        public void AutoSaveRadiostationsFullCSV(string city,
           ObservableCollection<RadiostationForDocumentsDataBaseModel>
           radiostationsForDocumentsCollection)
        {
            DateTime today = DateTime.Today;

            if (File.Exists($@"C:\ServiceTelekom\База\{city}\База_{city}_{today.ToString("dd.MM.yyyy")}.csv"))
                File.Delete($@"C:\ServiceTelekom\База\{city}\База_{city}_{today.ToString("dd.MM.yyyy")}.csv");

            string fileNamePath = $@"C:\ServiceTelekom\База\{city}\База_{city}_{today.ToString("dd.MM.yyyy")}.csv";

            if (!File.Exists($@"С:\ServiceTelekom\База\{city}\"))
                Directory.CreateDirectory($@"C:\ServiceTelekom\База\{city}\");

            using (StreamWriter sw = new StreamWriter(fileNamePath, false, Encoding.Unicode))
            {
                string note = string.Empty;
                note += $"РЦС;Предприятие;Место нахождения;" +
                    $"Модель;Заводской номер;Инвентарный;Сетевой;Дата ТО;№ акта;" +
                    $"№ накладной;№ ведомости;Город;ЦенаТО(без НДС);" +
                    $"Представитель предприятия;Должность;№ удостоверения;" +
                    $"Дата выдачи;№ телефона;№ акта ремонта;Категория;" +
                    $"Цена ремонта(без НДС);Антенна;Манипулятор;АКБ;ЗУ;" +
                    $"Выполненные работы_1;Выполненные работы_2;Выполненные работы_3;" +
                    $"Выполненные работы_4;Выполненные работы_5;Выполненные работы_6;" +
                    $"Выполненные работы_7;Деталь_1;Деталь_2;Деталь_3;Деталь_4;" +
                    $"Деталь_5;Деталь_6;Деталь_7;№ акта списания;Примечание;Дорога";
                sw.WriteLine(note);

                for (int i = 0; i < radiostationsForDocumentsCollection.Count; i++)
                {
                    string value = radiostationsForDocumentsCollection[i].Poligon.ToString() + ";"
                        + radiostationsForDocumentsCollection[i].Company.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Location.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Model.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].SerialNumber.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].InventoryNumber.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].NetworkNumber.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].DateMaintenance.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].NumberAct.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].NumberAct.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].NumberAct.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].City.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Price.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Representative.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Post.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].NumberIdentification.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].DateOfIssuanceOfTheCertificate.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].PhoneNumber.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].NumberActRepair.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Category.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].PriceRemont.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Antenna.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Manipulator.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Battery.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Charger.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_1.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_2.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_3.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_4.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_5.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_6.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].CompletedWorks_7.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_1.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_2.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_3.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_4.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_5.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_6.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Parts_7.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].DecommissionNumberAct.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Comment.ToString() + ";" +
                        radiostationsForDocumentsCollection[i].Road.ToString();
                    sw.Write(value);
                    sw.WriteLine();
                }
            }
        }

        public void AutoSaveRadiostationsFullJson(string city,
           ObservableCollection<RadiostationForDocumentsDataBaseModel>
           radiostationsForDocumentsCollection)
        {
            JArray products = new JArray();

            foreach (RadiostationForDocumentsDataBaseModel item 
                in radiostationsForDocumentsCollection)
            {
                JObject product = JObject.FromObject(new
                {
                    id = item.IdBase,
                    poligon = item.Poligon,
                    company = item.Company,
                    location = item.Location,
                    model = item.Model,
                    serialNumber = item.SerialNumber,
                    inventoryNumber = item.InventoryNumber,
                    networkNumber = item.NetworkNumber,
                    dateTO = item.DateMaintenance,
                    numberAct = item.NumberAct,
                    city = item.City,
                    price = item.Price,
                    representative = item.Representative,
                    post = item.Post,
                    numberIdentification = item.NumberIdentification,
                    dateIssue = item.DateOfIssuanceOfTheCertificate,
                    phoneNumber = item.PhoneNumber,
                    numberActRemont = item.NumberActRepair,
                    category = item.Category,
                    priceRemont = item.PriceRemont,
                    antenna = item.Antenna,
                    manipulator = item.Manipulator,
                    battery = item.Battery,
                    charger = item.Charger,
                    completed_works_1 = item.CompletedWorks_1,
                    completed_works_2 = item.CompletedWorks_2,
                    completed_works_3 = item.CompletedWorks_3,
                    completed_works_4 = item.CompletedWorks_4,
                    completed_works_5 = item.CompletedWorks_5,
                    completed_works_6 = item.CompletedWorks_6,
                    completed_works_7 = item.CompletedWorks_7,
                    parts_1 = item.Parts_1,
                    parts_2 = item.Parts_2,
                    parts_3 = item.Parts_3,
                    parts_4 = item.Parts_4,
                    parts_5 = item.Parts_5,
                    parts_6 = item.Parts_6,
                    parts_7 = item.Parts_7,
                    decommissionSerialNumber = item.DecommissionNumberAct,
                    comment = item.Comment,
                    road = item.Road,
                    verifiedRST = item.VerifiedRST
                });
                products.Add(product);
            }

            string json = JsonConvert.SerializeObject(products);

            string fileNamePath = $@"C:\ServiceTelekom\БазаJson\{city}\БазаJson.json";

            if (!File.Exists($@"С:\ServiceTelekom\БазаJson\{city}\"))
                Directory.CreateDirectory($@"C:\ServiceTelekom\БазаJson\{city}\");

            File.WriteAllText(fileNamePath, json);
        }

        public void CopyDataBaseRadiostantionInRadiostantionCopy()
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return;
                using (MySqlCommand command = new MySqlCommand(
                "CopyDataBaseRadiostantionInRadiostantionCopy",
                RepositoryDataBase.GetInstance.GetConnection()))
                {
                    RepositoryDataBase.GetInstance.OpenConnection();
                    command.ExecuteNonQuery();
                }
            }
            catch { }
            finally { RepositoryDataBase.GetInstance.CloseConnection(); }
        }
    }
}
