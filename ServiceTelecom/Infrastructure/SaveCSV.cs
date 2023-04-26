using System;
using System.IO;
using System.Text;
using System.Windows;
using Forms = System.Windows.Forms;
using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure
{
    internal class SaveCSV
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


        #region выгрузка ReportCardSaveCSV

        public void ReportCardSaveCSV(ObservableCollection<ReportCardsDataBaseModel> reportCards)
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
                    note += $"Работник,Дата входа,Дата выхода,Время нахождения";
                    sw.WriteLine(note);

                    for (int i = 0; i < reportCards.Count; i++)
                    {
                        string value = reportCards[i].User.ToString() + "," 
                            + reportCards[i].DateTimeInput.ToString() + "," +
                            reportCards[i].DateTimeExit.ToString() + "," +
                            reportCards[i].TimeCount.ToString();
                        sw.Write(value);
                        sw.WriteLine();
                    }
                    
                }
                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        #endregion


    }
}
