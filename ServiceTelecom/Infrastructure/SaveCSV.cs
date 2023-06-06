using System;
using System.IO;
using System.Text;
using System.Windows;
using Forms = System.Windows.Forms;
using ServiceTelecom.Models;
using System.Collections.ObjectModel;
using ServiceTelecom.Infrastructure.Interfaces;

namespace ServiceTelecom.Infrastructure
{
    internal class SaveCSV : ISaveCSV<ReportCardsDataBaseModel>,
        ITutorialsEngineerSave<TutorialEngineerDataBaseModel>,
        ISaveRadiostationsForDocumets<RadiostationForDocumentsDataBaseModel>
    {
        static volatile SaveCSV Class;
        static object SyncObject = new object();
        public static SaveCSV GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        if (Class == null)
                            Class = new SaveCSV();
                    }
                return Class;
            }
        }

        public void SaveReportCard(ObservableCollection<ReportCardsDataBaseModel> reportCards)
        {
            DateTime dateTime = DateTime.Now;
            string dateTimeString = dateTime.ToString("dd.MM.yyyy");
            Forms.SaveFileDialog sfd = new Forms.SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = $"Табель сотрудников_{dateTimeString}";
            if (sfd.ShowDialog() == Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                {
                    string note = string.Empty;
                    note += $"Работник;Дата входа;Дата выхода;Время нахождения";
                    sw.WriteLine(note);

                    for (int i = 0; i < reportCards.Count; i++)
                    {
                        string value = reportCards[i].User.ToString() + ";"
                            + reportCards[i].DateTimeInput.ToString() + ";" +
                            reportCards[i].DateTimeExit.ToString() + ";" +
                            reportCards[i].TimeCount.ToString();
                        sw.Write(value);
                        sw.WriteLine();
                    }

                }
                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        public void SaveTutorialsEngineer(ObservableCollection<TutorialEngineerDataBaseModel>
            tutorialsEngineer)
        {
            DateTime dateTime = DateTime.Now;
            string dateTimeString = dateTime.ToString("dd.MM.yyyy");
            Forms.SaveFileDialog sfd = new Forms.SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = $"Методичка_инженера_{dateTimeString}";
            if (sfd.ShowDialog() == Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                {
                    string note = string.Empty;
                    note += $"Модель;Неисправность;Описание;Виды работ;Автор";
                    sw.WriteLine(note);

                    for (int i = 0; i < tutorialsEngineer.Count; i++)
                    {
                        string value = tutorialsEngineer[i].Model.ToString() + ";"
                            + tutorialsEngineer[i].Problem.ToString() + ";" +
                            tutorialsEngineer[i].Info.ToString() + ";" +
                            tutorialsEngineer[i].Actions.ToString() + ";" +
                            tutorialsEngineer[i].Author.ToString();
                        sw.Write(value);
                        sw.WriteLine();
                    }

                }
                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        public void SaveRadiostationsForDocumets(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection)
        {
            DateTime dateTime = DateTime.Now;
            string dateTimeString = dateTime.ToString("dd.MM.yyyy");
            Forms.SaveFileDialog sfd = new Forms.SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = $"База_{city}_{dateTimeString}";
            if (sfd.ShowDialog() == Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                {
                    string note = string.Empty;
                    note += $"РЦС;Предприятие(балансодержатель);Место нахождения;" +
                        $"Модель;Заводской номер;Инвентарный;Сетевой;Дата ТО;№ акта;" +
                        $"№ накладной;№ ведомости;№ акта ремонта;Категория;№ акта списания;" +
                        $"ЦенаТО(без НДС);Цена ремонта(без НДС);Город;Примечание";
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
                            radiostationsForDocumentsCollection[i].NumberActRepair.ToString() + ";" +
                            radiostationsForDocumentsCollection[i].Category.ToString() + ";" +
                            radiostationsForDocumentsCollection[i].DecommissionNumberAct.ToString() + ";" +
                            radiostationsForDocumentsCollection[i].Price.ToString() + ";" +
                            radiostationsForDocumentsCollection[i].PriceRemont.ToString() + ";" +
                            radiostationsForDocumentsCollection[i].City.ToString() + ";" +
                            radiostationsForDocumentsCollection[i].Comment.ToString();
                        sw.Write(value);
                        sw.WriteLine();
                    }

                }
                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        public void SaveRadiostationsFull(string city,
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection)
        {
            DateTime dateTime = DateTime.Now;
            string dateTimeString = dateTime.ToString("dd.MM.yyyy");
            Forms.SaveFileDialog sfd = new Forms.SaveFileDialog();
            sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            sfd.FileName = $"ОБЩАЯ_База_{city}_{dateTimeString}";
            if (sfd.ShowDialog() == Forms.DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
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
                MessageBox.Show("Файл успешно сохранен!");
            }    
        }
    }
}
