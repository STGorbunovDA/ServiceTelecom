using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddHandbookParametersViewModel : ViewModelBase
    {
        HandbookParametersModelRadiostationRepository _handbookParametersModelRadiostationRepository;

        public ObservableCollection<HandbookParametersModelRadiostationModel>
           HandbookParametersAllModelRadiostationCollection
        { get; set; }

        private int _selectedIndexHandbookParametersModel;
        public int SelectedIndexHandbookParametersModel
        {
            get => _selectedIndexHandbookParametersModel;
            set
            {
                _selectedIndexHandbookParametersModel = value;
                OnPropertyChanged(nameof(SelectedIndexHandbookParametersModel));
            }
        }

        private IList _selectedModels = new ArrayList();
        public IList HandbookParametersModelMulipleSelectedDataGrid
        {
            get => _selectedModels;
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(HandbookParametersModelMulipleSelectedDataGrid));
            }
        }

        HandbookParametersModelRadiostationModel _selectedHandbookParametersModel;
        public HandbookParametersModelRadiostationModel SelectedHandbookParametersModel
        {
            get => _selectedHandbookParametersModel;
            set
            {
                if (value == null)
                    return;
                _selectedHandbookParametersModel = value;
                OnPropertyChanged(nameof(SelectedHandbookParametersModel));
            }
        }

        public AddHandbookParametersViewModel()
        {
            _handbookParametersModelRadiostationRepository 
                = new HandbookParametersModelRadiostationRepository();
            HandbookParametersAllModelRadiostationCollection = 
                new ObservableCollection<HandbookParametersModelRadiostationModel>();
        }
    }
}
