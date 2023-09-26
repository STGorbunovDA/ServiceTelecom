using ServiceTelecom.Infrastructure;
using System.Threading;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class PrintReportsViewModel
    {
        Print printExcel;
        public ICommand PrintReportGeneralAKB { get; }
        public ICommand PrintReportDetailedAKB { get; }
        public ICommand PrintReportGeneralManipulator { get; }
        public ICommand PrintReportDetailedManipulator { get; }
        public PrintReportsViewModel()
        {
            printExcel = new Print();
            PrintReportGeneralAKB = new ViewModelCommand(ExecutePrintReportGeneralCommand);
            PrintReportDetailedAKB = new ViewModelCommand(ExecutePrintReportDetailedAKBCommand);
            PrintReportGeneralManipulator = new ViewModelCommand(ExecutePrintReportGeneralManipulatorCommand);
            PrintReportDetailedManipulator = new ViewModelCommand(ExecutePrintPrintReportDetailedManipulatorCommand);
        }


        #region PrintReportDetailedManipulator

        void ExecutePrintPrintReportDetailedManipulatorCommand(object obj)
        {
            new Thread(() =>
            {
                printExcel.PrintReportDetailedManipulator();
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintReportGeneralManipulator
        void ExecutePrintReportGeneralManipulatorCommand(object obj)
        {
            new Thread(() =>
            {
                printExcel.PrintReportGeneralManipulator();
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintReportDetailedAKB

        void ExecutePrintReportDetailedAKBCommand(object obj)
        {
            new Thread(() =>
            {
                printExcel.PrintReportDetailedAKB();
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintReportGeneral

        void ExecutePrintReportGeneralCommand(object obj)
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
