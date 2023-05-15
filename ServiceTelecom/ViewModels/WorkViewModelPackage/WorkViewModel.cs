using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View;
using ServiceTelecom.View.WorkViewPackage;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        AddRadiostationForDocumentInDataBaseView addRadiostationForDocumentInDataBaseView = null;

        private WorkRepository _workRepository;
        private RoadDataBaseRepository _roadDataBase;

        public ICommand AddRadiostationForDocumentInDataBase { get; }

        public ObservableCollection<string> RoadCollections { get; set; }
        public ObservableCollection<string> CityCollections { get; set; }
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }

        private string _road;
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }

        private string _city;
        public string City { get => _city; set { _city = value; OnPropertyChanged(nameof(City)); } }

        private string _serialNumber;
        public string SerialNumber { get => _serialNumber; set { _serialNumber = value; OnPropertyChanged(nameof(SerialNumber)); } }

        private string _representative;
        public string Representative { get => _representative; set { _representative = value; OnPropertyChanged(nameof(Representative)); } }

        private string _numberIdentification;
        public string NumberIdentification { get => _numberIdentification; set { _numberIdentification = value; OnPropertyChanged(nameof(NumberIdentification)); } }

        private string _phoneNumber;
        public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); } }

        private string _post;
        public string Post { get => _post; set { _post = value; OnPropertyChanged(nameof(Post)); } }
        
        private string _dateOfIssuanceOfTheCertificate;
        public string DateOfIssuanceOfTheCertificate { get => _dateOfIssuanceOfTheCertificate; set { _dateOfIssuanceOfTheCertificate = value; OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate)); } }

        private string _poligon;
        public string Poligon { get => _poligon; set { _poligon = value; OnPropertyChanged(nameof(Poligon)); } }

        private string _company;
        public string Company { get => _company; set { _company = value; OnPropertyChanged(nameof(Company)); } }

        private string _location;
        public string Location { get => _location; set { _location = value; OnPropertyChanged(nameof(Location)); } }

        private string _model;
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        private string _inventoryNumber;
        public string InventoryNumber { get => _inventoryNumber; set { _inventoryNumber = value; OnPropertyChanged(nameof(InventoryNumber)); } }

        private string _networkNumber;
        public string NetworkNumber { get => _networkNumber; set { _networkNumber = value; OnPropertyChanged(nameof(NetworkNumber)); } }

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
                SerialNumber = value.SerialNumber;
                Representative = value.Representative;
                NumberIdentification = value.NumberIdentification;
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
            AddRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteAddRadiostationForDocumentInDataBaseCommand);
            GetRadiostationsForDocumentsCollection();
        }

        #region AddRadiostationForDocumentInDataBase

        private void ExecuteAddRadiostationForDocumentInDataBaseCommand(object obj)
        {

            if (addRadiostationForDocumentInDataBaseView == null)
            {
                addRadiostationForDocumentInDataBaseView = new AddRadiostationForDocumentInDataBaseView(Road, City);
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) => addRadiostationForDocumentInDataBaseView = null;
                addRadiostationForDocumentInDataBaseView.Show();
            }
        }

        #endregion

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
