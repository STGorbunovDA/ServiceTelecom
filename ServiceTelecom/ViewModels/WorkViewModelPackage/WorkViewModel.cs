using ServiceTelecom.Models;
using System.Collections;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }

        RadiostationForDocumentsDataBaseModel _radiostationForDocumentsDataBaseModel;

        public RadiostationForDocumentsDataBaseModel SelectedRadiostationForDocumentsDataBaseModel
        {
            get => _radiostationForDocumentsDataBaseModel;
            set
            {
                _radiostationForDocumentsDataBaseModel = value;
                OnPropertyChanged(nameof(SelectedRadiostationForDocumentsDataBaseModel));
            }
        }

        private IList _selectedModels = new ArrayList();
        public IList RadiostationsForDocumentsMulipleSelectedDataGrid
        {
            get { return _selectedModels; }
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(RadiostationsForDocumentsMulipleSelectedDataGrid));
            }
        }
    }
}
