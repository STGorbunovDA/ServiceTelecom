using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        private WorkRepository _workRepository;
        private RoadDataBaseRepository _roadDataBase;

        public ObservableCollection<string> RoadCollections { get; set; }
        public ObservableCollection<string> CityCollections { get; set; }
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }

        private string _road;
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }

        private string _city;
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }

        //private int _selectedItemUserChoiceRoadCollection;
        //public int SelectedItemUserChoiceRoadCollection
        //{
        //    get
        //    {
        //        TheIndexUserChoiceCityCollection = -1;

        //        if (CityCollections.Count != 0)
        //            CityCollections.Clear();
        //        CityCollections = _workRepository.GetCityAlongRoadForCityCollection(Road, CityCollections);

        //        TheIndexUserChoiceCityCollection = 0;
        //        return _selectedItemUserChoiceRoadCollection;
        //    }
        //    set
        //    {
        //        _selectedItemUserChoiceRoadCollection = value;
        //        OnPropertyChanged(nameof(SelectedItemUserChoiceRoadCollection));
        //    }
        //}

        private int _theIndexUserChoiceCityCollection;
        public int TheIndexUserChoiceCityCollection
        {
            get
            {
                return _theIndexUserChoiceCityCollection;
            }
            set
            {
                _theIndexUserChoiceCityCollection = value;
                OnPropertyChanged(nameof(TheIndexUserChoiceCityCollection));
            }
        }


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
            _workRepository = new WorkRepository();
            RadiostationsForDocumentsCollection = new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            RoadCollections = new ObservableCollection<string>();
            CityCollections = new ObservableCollection<string>();
            GetRadiostationsForDocumentsCollection();
        }



        private void GetRadiostationsForDocumentsCollection()
        {
            if (UserModelStatic.StaffRegistrationsDataBaseModelCollection.Count == 0)
            {
                _roadDataBase = new RoadDataBaseRepository();
                RoadCollections = _roadDataBase.GetRoadDataBase(RoadCollections);
            }
            else foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                    RoadCollections.Add(item.RoadBase);

            CityCollections = _workRepository.GetCityAlongRoadForCityCollection(RoadCollections[0].ToString(), CityCollections);
            if (CityCollections.Count != 0)
                RadiostationsForDocumentsCollection = _workRepository.GetRadiostationsForDocumentsCollection(
                    RadiostationsForDocumentsCollection, RoadCollections[0].ToString(), CityCollections[0].ToString());
        }
    }
}
