using MySql.Data.MySqlClient;
using ServiceTelecom.Infrastructure.Interfaces;
using System.IO;
using System;
using Forms = System.Windows.Forms;
using System.Windows;
using ServiceTelecom.Repositories;

namespace ServiceTelecom.Infrastructure
{
    public class OpenCSV : IOpenCSV
    {
        private WorkRadiostantionFullRepository _workRepositoryRadiostantionFull = new WorkRadiostantionFullRepository();

        static volatile OpenCSV Class;
        static object SyncObject = new object();
        public static OpenCSV GetInstance
        {
            get
            {
                if (Class == null)
                    lock (SyncObject)
                    {
                        if (Class == null)
                            Class = new OpenCSV();
                    }
                return Class;
            }
        }

        public void OpenCSVFile()
        {
            Forms.OpenFileDialog openFile = new Forms.OpenFileDialog
            {
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            openFile.ShowDialog();

            if (!String.IsNullOrWhiteSpace(openFile.FileName))
            {
                string filename = openFile.FileName;

                int lineNumber = 0;

                using (StreamReader reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (lineNumber != 0)
                        {
                            string[] values = line.Split(';');

                            string poligon = values[0];
                            string company = values[1];
                            string location = values[2];
                            string model = values[3];
                            string serialNumber = values[4];
                            string inventoryNumber = values[5];
                            string networkNumber = values[6];
                            string dateMaintenance = Convert.ToDateTime(values[7]).ToString("yyyy-MM-dd");
                            string numberAct = values[8];
                            string city = values[9];
                            string price = values[10];
                            string road = values[11];

                            if (!_workRepositoryRadiostantionFull.
                                CheckSerialNumberForDocumentInDataBaseRadiostantionFull(
                                road, serialNumber))
                            {
                                if (_workRepositoryRadiostantionFull.LoadingFileForFullDB(
                                    poligon, company, location, model, serialNumber,
                                    inventoryNumber, networkNumber, dateMaintenance,
                                    numberAct, city, price, road))
                                    continue;
                                else
                                {
                                    MessageBox.Show("Радиостанции не добавленны.Системная ошибка ");
                                    break;
                                }
                            }
                            else continue;
                        }
                        lineNumber++;
                    }
                    if (reader.EndOfStream) MessageBox.Show("Радиостанции успешно добавлены!");
                    else MessageBox.Show("Радиостанции не добавленны.Системная ошибка ");

                }
            }
            else MessageBox.Show("Вы не выбрали файл .csv который нужно добавить!", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
