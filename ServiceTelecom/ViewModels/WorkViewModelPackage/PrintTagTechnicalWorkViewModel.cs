using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class PrintTagTechnicalWorkViewModel : ViewModelBase
    {
        Print printExcel;

        #region свойства

        public string Road { get; set; }
        public string City { get; set; }

        string _dateMaintenance;
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
            printExcel = new Print();
            Road = GlobalValue.ROAD;
            City = GlobalValue.CITY;
        }

        #region CheckValue

        bool IsNullOrWhiteSpaceDateMaintenance()
        {
            if (String.IsNullOrWhiteSpace(DateMaintenance))
            {
                MessageBox.Show("Поле \"Дата\" не должно быть пустым",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        bool СheckRegexDateMaintenance()
        {
            if (!Regex.IsMatch(DateMaintenance,
               @"^[0-9]{2,2}[.][0-9]{2,2}[.][2][0][0-9]{2,2}$"))
            {
                MessageBox.Show("Введите корректно поле \"Дата\"",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        #endregion

        #region PrintTagTechnicalWorkManipulator

        void ExecutePrintTagTechnicalWorkManipulatorCommand(object obj)
        {
            if (!IsNullOrWhiteSpaceDateMaintenance())
                return;
            if (!СheckRegexDateMaintenance())
                return;

            new Thread(() =>
            {
                printExcel.PrintTagTechnicalWorkRadiostantion(Road, City, DateMaintenance, "МАН");
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintTagTechnicalWorkRadiostantion

        void ExecutePrintTagTechnicalWorkRadiostantionCommand(object obj)
        {
            if (!IsNullOrWhiteSpaceDateMaintenance())
                return;
            if (!СheckRegexDateMaintenance())
                return;

            new Thread(() =>
            {
                printExcel.PrintTagTechnicalWorkRadiostantion(Road, City, DateMaintenance, "РСТ");
            })
            { IsBackground = true }.Start();
        }

        #endregion
    }
}
