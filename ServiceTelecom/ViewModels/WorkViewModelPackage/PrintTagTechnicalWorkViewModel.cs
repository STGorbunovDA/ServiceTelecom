using System;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class PrintTagTechnicalWorkViewModel : ViewModelBase
    {
        #region свойства

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

        public PrintTagTechnicalWorkViewModel()
        {
            DateMaintenance = DateTime.Now.ToString("dd.MM.yyyy");

            PrintTagTechnicalWorkRadiostantion =
                new ViewModelCommand(ExecutePrintTagTechnicalWorkRadiostantionCommand);

        }

        #region PrintTagTechnicalWorkRadiostantion

        private void ExecutePrintTagTechnicalWorkRadiostantionCommand(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
