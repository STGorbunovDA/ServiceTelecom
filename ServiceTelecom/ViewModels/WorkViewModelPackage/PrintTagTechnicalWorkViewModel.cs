using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class PrintTagTechnicalWorkViewModel : ViewModelBase
    {
        private Print print;
        
        #region свойства

        public string Road { get; set; }
        public string City { get; set; }

        private string _dateMaintenance;
        public string DateMaintenance
        {
            get => _dateMaintenance;
            set
            {
                _dateMaintenance = value;
                OnPropertyChanged(nameof(DateMaintenance));
            }
        }

        #endregion


        public ICommand PrintTagTechnicalWorkRadiostantion { get; }
        public ICommand PrintTagTechnicalWorkManipulator { get; }
        public PrintTagTechnicalWorkViewModel()
        {
            DateMaintenance = DateTime.Now.ToString("dd.MM.yyyy");

            PrintTagTechnicalWorkRadiostantion =
                new ViewModelCommand(ExecutePrintTagTechnicalWorkRadiostantionCommand);

            PrintTagTechnicalWorkManipulator =
                new ViewModelCommand(ExecutePrintTagTechnicalWorkManipulatorCommand);
            print = new Print();
            Road = UserModelStatic.road;
            City = UserModelStatic.city;
        }



        #region PrintTagTechnicalWorkManipulator

        private void ExecutePrintTagTechnicalWorkManipulatorCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(DateMaintenance))
            {
                MessageBox.Show("Поле \"Дата\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DateMaintenance,
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            new Thread(() =>
            {
                print.PrintTagTechnicalWorkRadiostantion(Road, City, DateMaintenance, "МАН");
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintTagTechnicalWorkRadiostantion

        private void ExecutePrintTagTechnicalWorkRadiostantionCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(DateMaintenance))
            {
                MessageBox.Show("Поле \"Дата\" не должно быть пустым", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (!Regex.IsMatch(DateMaintenance,
                @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата\"", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            new Thread(() =>
            {
                print.PrintTagTechnicalWorkRadiostantion(Road, City, DateMaintenance, "РСТ");
            })
            { IsBackground = true }.Start();
        }

        #endregion
    }
}
