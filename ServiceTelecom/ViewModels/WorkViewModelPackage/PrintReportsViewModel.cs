using ServiceTelecom.Infrastructure;
using System;
using System.Threading;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class PrintReportsViewModel
    {
        private Print printExcel;
        public ICommand PrintReportGeneralAKB { get; }
        public ICommand PrintReportDetailedAKB { get; }
        public ICommand PrintReportGeneralManipulator { get; }

        public PrintReportsViewModel()
        {
            printExcel = new Print();
            PrintReportGeneralAKB = new ViewModelCommand(ExecutePrintReportGeneralCommand);
            PrintReportDetailedAKB = new ViewModelCommand(ExecutePrintReportDetailedAKBCommand);
            PrintReportGeneralManipulator = new ViewModelCommand(ExecutePrintReportGeneralManipulatorCommand);
        }



        #region PrintReportGeneralManipulator
        private void ExecutePrintReportGeneralManipulatorCommand(object obj)
        {
            new Thread(() =>
            {
                printExcel.PrintReportGeneralManipulator();
            })
            { IsBackground = true }.Start();
        }

        #endregion


        #region PrintReportDetailedAKB

        private void ExecutePrintReportDetailedAKBCommand(object obj)
        {
            new Thread(() =>
            {
                printExcel.PrintReportDetailedAKB();
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintReportGeneral

        private void ExecutePrintReportGeneralCommand(object obj)
        {
            new Thread(() =>
            {
                printExcel.PrintReportGeneralAKB();
            })
            { IsBackground = true }.Start();
        }

        #endregion
    }
}
