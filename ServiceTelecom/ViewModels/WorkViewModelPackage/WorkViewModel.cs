using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View.WorkViewPackage;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        /// <summary> для сохранения индекса выделенной строки </summary>
        private int TEMPORARY_INDEX_DATAGRID = 0; 

        AddRadiostationForDocumentInDataBaseView addRadiostationForDocumentInDataBaseView = null;
        ChangeRadiostationForDocumentInDataBaseView changeRadiostationForDocumentInDataBaseView = null;

        private WorkRepositoryRadiostantion _workRepository;
        private RoadDataBaseRepository _roadDataBase;

        public ObservableCollection<string> RoadCollections { get; set; }
        public ObservableCollection<string> CityCollections { get; set; }
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }

        private int _selectedIndexRadiostantionDataGrid;
        public int SelectedIndexRadiostantionDataGrid
        {
            get => _selectedIndexRadiostantionDataGrid;
            set
            {
                _selectedIndexRadiostantionDataGrid = value;
                OnPropertyChanged(nameof(SelectedIndexRadiostantionDataGrid));
            }
        }

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

        private string _dateMaintenance;
        public string DateMaintenance { get => _dateMaintenance; set { _dateMaintenance = value; OnPropertyChanged(nameof(DateMaintenance)); } }

        private string _comment;
        public string Comment { get => _comment; set { _comment = value; OnPropertyChanged(nameof(Comment)); } }

        private string _price;
        public string Price { get => _price; set { _price = value; OnPropertyChanged(nameof(Price)); } }

        private string _numberAct;
        public string NumberAct { get => _numberAct; set { _numberAct = value; OnPropertyChanged(nameof(NumberAct)); } }

        private string _manipulator;
        public string Manipulator { get => _manipulator; set { _manipulator = value; OnPropertyChanged(nameof(Manipulator)); } }

        private string _antenna;
        public string Antenna { get => _antenna; set { _antenna = value; OnPropertyChanged(nameof(Antenna)); } }

        private string _battery;
        public string Battery { get => _battery; set { _battery = value; OnPropertyChanged(nameof(Battery)); } }

        private string _charger;
        public string Charger { get => _charger; set { _charger = value; OnPropertyChanged(nameof(Charger)); } }

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
                if (value == null)
                    return;
                SerialNumber = value.SerialNumber;
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

        public ICommand AddRadiostationForDocumentInDataBase { get; }
        public ICommand ChangeRadiostationForDocumentInDataBase { get; }

        public WorkViewModel()
        {
            _workRepository = new WorkRepositoryRadiostantion();
            RadiostationsForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            RoadCollections = new ObservableCollection<string>();
            CityCollections = new ObservableCollection<string>();
            AddRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddRadiostationForDocumentInDataBaseCommand);
            ChangeRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteChangeRadiostationForDocumentInDataBaseCommand);
            LoadingForControlsWorkView();
            GetRadiostationsForDocumentsCollection();
        }



        #region ChangeRadiostationForDocumentInDataBase

        private void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (changeRadiostationForDocumentInDataBaseView != null)
                return;
            if (SelectedRadiostationForDocumentsDataBaseModel == null)
                return;
            changeRadiostationForDocumentInDataBaseView =
            new ChangeRadiostationForDocumentInDataBaseView(
                SelectedRadiostationForDocumentsDataBaseModel);
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            changeRadiostationForDocumentInDataBaseView = null;
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRadiostationsForDocumentsCollection();
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            changeRadiostationForDocumentInDataBaseView.Show();

        }

        #endregion

        #region AddRadiostationForDocumentInDataBase

        private void ExecuteAddRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (addRadiostationForDocumentInDataBaseView == null)
            {
                if (SelectedRadiostationForDocumentsDataBaseModel == null)
                {
                    addRadiostationForDocumentInDataBaseView =
                    new AddRadiostationForDocumentInDataBaseView();
                }
                else
                {
                    addRadiostationForDocumentInDataBaseView =
                    new AddRadiostationForDocumentInDataBaseView(
                        SelectedRadiostationForDocumentsDataBaseModel);
                }
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                addRadiostationForDocumentInDataBaseView = null;
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                GetRadiostationsForDocumentsCollection();
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                GetRowAfterAddingRadiostantionInDataGrid();
                addRadiostationForDocumentInDataBaseView.Show();
            }
        }

        #endregion

        /// <summary>
        /// Загрузка в контролы View Дорогу и Города
        /// </summary>
        private void LoadingForControlsWorkView()
        {
            if (UserModelStatic.StaffRegistrationsDataBaseModelCollection.Count == 0)
            {
                _roadDataBase = new RoadDataBaseRepository();
                RoadCollections = _roadDataBase.GetRoadDataBase(RoadCollections);
            }
            else foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                    RoadCollections.Add(item.RoadBase);

            CityCollections = _workRepository.GetCityAlongRoadForCityCollection(RoadCollections[0].ToString(), CityCollections);
        }


        #region Получаем строку DataGrid после добавления радиостанции

        private void GetRowAfterAddingRadiostantionInDataGrid()
        {
            SelectedIndexRadiostantionDataGrid = RadiostationsForDocumentsCollection.Count - 1;
        }

        #endregion

        #region Получаем выбранную-выделенную строку DataGrid после изменения радиостанции

        private void GetRowAfterChangeRadiostantionInDataGrid(int temporaryIndexDataGrid)
        {
            SelectedIndexRadiostantionDataGrid = temporaryIndexDataGrid;
        }

        #endregion

        #region Получаем радиостанции для документов из рабочей БД

        private void GetRadiostationsForDocumentsCollection()
        {
            if (CityCollections.Count == 0)
                return;
            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();
            RadiostationsForDocumentsCollection =
                _workRepository.GetRadiostationsForDocumentsCollection(
                RadiostationsForDocumentsCollection, RoadCollections[0].ToString(),
                CityCollections[0].ToString());

        }

        #endregion
    }
}
