using System;
using Controls = System.Windows.Controls;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

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
        //internal void ReportCardSaveCSV(Controls.DataGrid dataGridView1)
        //{
        //    DateTime dateTime = DateTime.Now;
        //    string dateTimeString = dateTime.ToString("dd.MM.yyyy");
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
        //    sfd.FileName = $"Табель сотрудников_{dateTimeString}";

        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
        //        {
        //            string note = string.Empty;
        //            note += $"Работник\tДата входа\tДата выхода\tВремя нахождения";
        //            sw.WriteLine(note);
        //            for (int i = 0; i < dataGridView1.; i++)
        //            {
        //                for (int j = 0; j < dataGridView1.ColumnCount; j++)
        //                {
        //                    Regex re = new Regex(Environment.NewLine);
        //                    string value = dataGridView1.Rows[i].Cells[j].Value.ToString();
        //                    value = re.Replace(value, " ");
        //                    if (dataGridView1.Columns[j].HeaderText.ToString() == "№")
        //                    {

        //                    }
        //                    else if (dataGridView1.Columns[j].HeaderText.ToString() == "Время нахождения")
        //                    {
        //                        sw.Write(value);
        //                    }
        //                    else if (dataGridView1.Columns[j].HeaderText.ToString() == "Модификатор")
        //                    {

        //                    }
        //                    else sw.Write(value + "\t");
        //                }
        //                sw.WriteLine();
        //            }
        //        }
        //        MessageBox.Show("Файл успешно сохранен!");
        //    }
        //}
    }
}
