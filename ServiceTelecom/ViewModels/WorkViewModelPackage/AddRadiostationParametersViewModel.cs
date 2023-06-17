using ServiceTelecom.Models;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class AddRadiostationParametersViewModel : ViewModelBase
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

        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        private string _serialNumber;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        private string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        private string _numberAct;
        public string NumberAct
        {
            get => _numberAct;
            set
            {
                _numberAct = value;
                OnPropertyChanged(nameof(NumberAct));
            }
        }

        #endregion

        public AddRadiostationParametersViewModel()
        {
            foreach (RadiostationForDocumentsDataBaseModel item 
                in UserModelStatic.RadiostationsForDocumentsMulipleSelectedDataGrid)
            {
                DateMaintenance = item.DateMaintenance;
                Model = item.Model;
                SerialNumber = item.SerialNumber;
                Company = item.Company;
                NumberAct = item.NumberAct;
            }
            foreach (var item 
                in UserModelStatic.ParametersRadiostationForAddRadiostationParametersView)
            {
                //
            }
        }
    }
}
