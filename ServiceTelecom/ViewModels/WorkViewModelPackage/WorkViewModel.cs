using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        public ObservableCollection<string> RoadCollections { get; }
        private RoadDataBaseRepository _roadDataBase;

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

        public WorkViewModel()
        {
            RadiostationsForDocumentsCollection = new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            RoadCollections = new ObservableCollection<string>();

            if (UserModelStatic.StaffRegistrationsDataBaseModelCollection.Count == 0)
            {
                _roadDataBase = new RoadDataBaseRepository();
                RoadCollections = _roadDataBase.GetRoadDataBase(RoadCollections);
            }
            else
            {
                foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                {
                    RoadCollections.Add(item.RoadBase);
                }
            }
        }
    }
}
