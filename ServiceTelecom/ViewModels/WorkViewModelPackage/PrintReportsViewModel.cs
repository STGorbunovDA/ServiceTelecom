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
        public PrintReportsViewModel()
        {
            printExcel = new Print();
            PrintReportGeneralAKB = new ViewModelCommand(ExecutePrintReportGeneralCommand);
        }

        #region PrintReportGeneral

        private void ExecutePrintReportGeneralCommand(object obj)
        {
            //printExcel.PrintReportGeneralAKB();
            new Thread(() =>
            {
                printExcel.PrintReportGeneralAKB();
            })
            { IsBackground = true }.Start();
        }

        #endregion
    }
}
