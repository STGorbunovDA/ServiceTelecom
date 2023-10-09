using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Interfaces;
using ServiceTelecom.View.WorkViewPackage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        /// <summary> для сохранения индекса выделенной строки </summary>
        int TEMPORARY_INDEX_DATAGRID = 0;

        /// <summary> для сохранения индекса коллекции дорог </summary>
        int TEMPORARY_INDEX_ROAD_COLLECTION = 0;

        /// <summary> Для получения значения только один раз из реестра  </summary>
        int NUMBER_LIMIT_LOADING_REGESTRY_CITY = 0;

        /// <summary> Для ограничения функционала при загрузке радиостанций из общей таблицы  </summary>
        bool CHECK_HOW_MUCH = false;

        #region свойства

        string _serialNumberView;
        public string SerialNumberView
        {
            get => _serialNumberView;
            set
            {
                _serialNumberView = value;
                OnPropertyChanged(nameof(SerialNumberView));
            }
        }

        string _fillOut;
        public string FillOut
        {
            get => _fillOut;
            set
            {
                _fillOut = value;
                OnPropertyChanged(nameof(FillOut));
            }
        }

        string _sign;
        public string Sign
        {
            get => _sign;
            set
            {
                _sign = value;
                OnPropertyChanged(nameof(Sign));
            }
        }

        string _selectedRowsCounterAmountRadiostantion;
        public string SelectedRowsCounterAmountRadiostantion
        {
            get => _selectedRowsCounterAmountRadiostantion;
            set
            {
                _selectedRowsCounterAmountRadiostantion = value;
                OnPropertyChanged(nameof(SelectedRowsCounterAmountRadiostantion));
            }
        }

        string _selectedRows;
        public string SelectedRows
        {
            get => _selectedRows;
            set
            {
                _selectedRows = value;
                OnPropertyChanged(nameof(SelectedRows));
            }
        }

        string _сounterDecommissionNumberActs;
        public string CounterDecommissionNumberActs
        {
            get => _сounterDecommissionNumberActs;
            set
            {
                _сounterDecommissionNumberActs = value;
                OnPropertyChanged(nameof(CounterDecommissionNumberActs));
            }
        }

        string _сounterInRepairRadiostantionsTechnicalServices;
        public string CounterInRepairRadiostantionsTechnicalServices
        {
            get => _сounterInRepairRadiostantionsTechnicalServices;
            set
            {
                _сounterInRepairRadiostantionsTechnicalServices = value;
                OnPropertyChanged(nameof(CounterInRepairRadiostantionsTechnicalServices));
            }
        }

        string _сounterVerifiedRadiostantions;
        public string CounterVerifiedRadiostantions
        {
            get => _сounterVerifiedRadiostantions;
            set
            {
                _сounterVerifiedRadiostantions = value;
                OnPropertyChanged(nameof(CounterVerifiedRadiostantions));
            }
        }

        string _сounterInWorkRadiostantions;
        public string CounterInWorkRadiostantions
        {
            get => _сounterInWorkRadiostantions;
            set
            {
                _сounterInWorkRadiostantions = value;
                OnPropertyChanged(nameof(CounterInWorkRadiostantions));
            }
        }

        string _counterAmountRepair;
        public string CounterAmountRepair
        {
            get => _counterAmountRepair;
            set
            {
                _counterAmountRepair = value;
                OnPropertyChanged(nameof(CounterAmountRepair));
            }
        }

        string _counterQuantityRepair;
        public string CounterQuantityRepair
        {
            get => _counterQuantityRepair;
            set
            {
                _counterQuantityRepair = value;
                OnPropertyChanged(nameof(CounterQuantityRepair));
            }
        }

        string _counterAmountRadiostantion;
        public string CounterAmountRadiostantion
        {
            get => _counterAmountRadiostantion;
            set
            {
                _counterAmountRadiostantion = value;
                OnPropertyChanged(nameof(CounterAmountRadiostantion));
            }
        }

        string _counterQuantityRadiostantion;
        public string CounterQuantityRadiostantion
        {
            get => _counterQuantityRadiostantion;
            set
            {
                _counterQuantityRadiostantion = value;
                OnPropertyChanged(nameof(CounterQuantityRadiostantion));
            }
        }

        string _cmbChoiseSearch;
        public string CmbChoiseSearch
        {
            get => _cmbChoiseSearch;
            set
            {
                _cmbChoiseSearch = value;
                OnPropertyChanged(nameof(CmbChoiseSearch));
            }
        }

        string _choiсeUniqueValue;
        public string ChoiсeUniqueValue
        {
            get => _choiсeUniqueValue;
            set
            {
                _choiсeUniqueValue = value;
                SearchByChoiseUniqueValueInRadiostationsForDocumentsCollection(value);
                OnPropertyChanged(nameof(ChoiсeUniqueValue));
            }
        }

        string _road;
        public string Road
        {
            get => _road;
            set
            {
                _road = value;
                OnPropertyChanged(nameof(Road));
            }
        }

        string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        string _serialNumber;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        string _verifiedRST;
        public string VerifiedRST
        {
            get => _verifiedRST;
            set
            {
                _verifiedRST = value;
                OnPropertyChanged(nameof(VerifiedRST));
            }
        }

        string _representative;
        public string Representative
        {
            get => _representative;
            set
            {
                _representative = value;
                OnPropertyChanged(nameof(Representative));
            }
        }

        string _numberIdentification;
        public string NumberIdentification
        {
            get => _numberIdentification;
            set
            {
                _numberIdentification = value;
                OnPropertyChanged(nameof(NumberIdentification));
            }
        }

        string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        string _post;
        public string Post
        {
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged(nameof(Post));
            }
        }

        string _dateOfIssuanceOfTheCertificate;
        public string DateOfIssuanceOfTheCertificate
        {
            get => _dateOfIssuanceOfTheCertificate;
            set
            {
                _dateOfIssuanceOfTheCertificate = value;
                OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate));
            }
        }

        string _poligon;
        public string Poligon
        {
            get => _poligon;
            set
            {
                _poligon = value;
                OnPropertyChanged(nameof(Poligon));
            }
        }

        string _company;
        public string Company
        {
            get => _company;
            set
            {
                _company = value;
                OnPropertyChanged(nameof(Company));
            }
        }

        string _location;
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        string _inventoryNumber;
        public string InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged(nameof(InventoryNumber));
            }
        }

        string _networkNumber;
        public string NetworkNumber
        {
            get => _networkNumber;
            set
            {
                _networkNumber = value;
                OnPropertyChanged(nameof(NetworkNumber));
            }
        }

        string _dateMaintenance;
        public string DateMaintenance
        {
            get => _dateMaintenance;
            set
            {
                _dateMaintenance = value;
                OnPropertyChanged(nameof(DateMaintenance));
            }
        }

        string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        string _price;
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        string _numberAct;
        public string NumberAct
        {
            get => _numberAct;
            set
            {
                _numberAct = value;
                OnPropertyChanged(nameof(NumberAct));
            }
        }

        string _numberActRepair;
        public string NumberActRepair
        {
            get => _numberActRepair;
            set
            {
                _numberActRepair = value;
                OnPropertyChanged(nameof(NumberActRepair));
            }
        }

        string _manipulator;
        public string Manipulator
        {
            get => _manipulator;
            set
            {
                _manipulator = value;
                OnPropertyChanged(nameof(Manipulator));
            }
        }

        string _antenna;
        public string Antenna
        {
            get => _antenna;
            set
            {
                _antenna = value;
                OnPropertyChanged(nameof(Antenna));
            }
        }

        string _battery;
        public string Battery
        {
            get => _battery;
            set
            {
                _battery = value;
                OnPropertyChanged(nameof(Battery));
            }
        }

        string _charger;
        public string Charger
        {
            get => _charger;
            set
            {
                _charger = value;
                OnPropertyChanged(nameof(Charger));
            }
        }

        string _decommissionNumberAct;
        public string DecommissionNumberAct
        {
            get => _decommissionNumberAct;
            set
            {
                _decommissionNumberAct = value;
                OnPropertyChanged(nameof(DecommissionNumberAct));
            }
        }

        #endregion

        BackupCopyRadiostationsForDocumentsCollection backupCopyRadiostationsForDocuments;
        DispatcherTimer dispatcherTimer;
        GetSetRegistryServiceTelecomSetting _getSetRegistryServiceTelecomSetting;
        Print printExcel;

        IWorkRadiostantionRepository _workRadiostantionRepository;
        IWorkRadiostantionFullRepository _workRadiostantionFullRepository;
        IRoadDataBaseRepository _roadDataBaseRepository;
        IRadiostationParametersRepository _radiostationParametersRepository;

        ChangeNumberActView changeNumberActView = null;
        PrintTagTechnicalWorkView printTagTechnicalWorkView = null;
        AddRadiostationForDocumentInDataBaseView addRadiostationForDocumentInDataBaseView = null;
        ChangeRadiostationForDocumentInDataBaseView changeRadiostationForDocumentInDataBaseView = null;
        AddRepairRadiostationForDocumentInDataBaseView addRepairRadiostationForDocumentInDataBaseView = null;
        AddDecommissionNumberActView addDecommissionNumberActView = null;
        SelectingSaveView selectingSaveView = null;
        PrintRepairView printRepairView = null;
        AddRadiostationParametersView addRadiostationParametersView = null;
        PrintReportsView printReportsView = null;
        AddChangeRepresentativeRCSView addChangeRepresentativeRCSView = null;

        public ObservableCollection<RoadModel> RoadsCollection { get; set; }
        public ObservableCollection<string> CitiesCollection { get; set; }
        public ObservableCollection<string> ChoiсeUniqueValuesCollection { get; set; }
        public ObservableCollection<string> SignCollection { get; set; }
        public ObservableCollection<string> FillOutCollection { get; set; }

        public List<RadiostationForDocumentsDataBaseModel> PrintWordDecommissionNumberActCollection { get; set; }
        public List<RadiostationForDocumentsDataBaseModel> PrintExcelNumberActRepairCollection { get; set; }
        public List<RadiostationParametersDataBaseModel> PrintStatementParametersCollection { get; set; }
        public List<RadiostationForDocumentsDataBaseModel> PrintExcelNumberActTechnicalWorkCollection { get; set; }
        public List<RadiostationForDocumentsDataBaseModel> SelectedRadiostationForAddRadiostationParametersViewCollection { get; set; }
        public List<RadiostationParametersDataBaseModel> ParametersRadiostationForAddRadiostationParametersViewCollection { get; set; }
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }
        public ObservableCollection<RadiostationParametersDataBaseModel> RadiostationsParametersCollection { get; set; }

        ObservableCollection<RadiostationForDocumentsDataBaseModel> ReserveRadiostationsForDocumentsCollection;

        int _selectedIndexFillOutCollection;
        public int SelectedIndexFillOutCollection
        {
            get => _selectedIndexFillOutCollection;
            set
            {
                _selectedIndexFillOutCollection = value;
                OnPropertyChanged(nameof(SelectedIndexFillOutCollection));
            }
        }

        int _selectedIndexSignCollection;
        public int SelectedIndexSignCollection
        {
            get => _selectedIndexSignCollection;
            set
            {
                _selectedIndexSignCollection = value;
                OnPropertyChanged(nameof(SelectedIndexSignCollection));
            }
        }

        int _selectedIndexRadiostantionDataGrid;
        public int SelectedIndexRadiostantionDataGrid
        {
            get => _selectedIndexRadiostantionDataGrid;
            set
            {
                _selectedIndexRadiostantionDataGrid = value;
                OnPropertyChanged(nameof(SelectedIndexRadiostantionDataGrid));
            }
        }

        int _selectedIndexRoadCollection;
        public int SelectedIndexRoadCollection
        {
            get => _selectedIndexRoadCollection;
            set
            {
                if (value >= 0)
                    TEMPORARY_INDEX_ROAD_COLLECTION = value;
                GetCityOnTheRoad(value);
                _selectedIndexRoadCollection = value;
                OnPropertyChanged(nameof(SelectedIndexRoadCollection));
            }
        }


        int _selectedIndexCityCollection;
        public int SelectedIndexCityCollection
        {
            get => _selectedIndexCityCollection;
            set
            {
                _selectedIndexCityCollection = value;
                if (value < 0 || CitiesCollection.Count == 0)
                {
                    if (RadiostationsForDocumentsCollection.Count != 0)
                        RadiostationsForDocumentsCollection.Clear();
                }
                else
                {
                    GetRadiostations(RoadsCollection[TEMPORARY_INDEX_ROAD_COLLECTION].ToString(),
                        CitiesCollection[value].ToString());

                }

                OnPropertyChanged(nameof(SelectedIndexCityCollection));
            }
        }

        RadiostationForDocumentsDataBaseModel _selectedRadiostation;
        public RadiostationForDocumentsDataBaseModel SelectedRadiostation
        {
            get => _selectedRadiostation;
            set
            {
                if (value == null)
                    return;
                _selectedRadiostation = value;
                SerialNumberView = value.SerialNumber;
                OnPropertyChanged(nameof(SelectedRadiostation));
            }
        }

        IList _selectedModels = new ArrayList();
        public IList RadiostationsForDocumentsMulipleSelectedDataGrid
        {
            get => _selectedModels;
            set
            {
                _selectedModels = value;

                if (RadiostationsForDocumentsMulipleSelectedDataGrid != null)
                {
                    SelectedRows =
                    RadiostationsForDocumentsMulipleSelectedDataGrid.Count.ToString();
                    decimal selectedRowsCounterAmountRadiostantion = 0;
                    foreach (RadiostationForDocumentsDataBaseModel item
                        in RadiostationsForDocumentsMulipleSelectedDataGrid)
                    {
                        selectedRowsCounterAmountRadiostantion += Convert.ToDecimal(
                            item.Price);
                        SelectedRowsCounterAmountRadiostantion =
                            selectedRowsCounterAmountRadiostantion.ToString() + " руб.";
                    }
                }
                OnPropertyChanged(nameof(RadiostationsForDocumentsMulipleSelectedDataGrid));
            }
        }

        public ICommand AddRadiostationForDocumentInDataBase { get; }
        public ICommand ChangeRadiostationForDocumentInDataBase { get; }
        public ICommand UpdateRadiostationForDocumentInDataBase { get; }
        public ICommand DeleteRadiostationForDocumentInDataBase { get; }
        public ICommand SaveCollectionRadiostationsForDocument { get; }
        public ICommand AddRepairRadiostationForDocumentInDataBase { get; }
        public ICommand DeleteRepairRadiostationForDocumentInDataBase { get; }
        public ICommand AddDecommissionNumberActRadiostationForDocumentInDataBase { get; }
        public ICommand DeleteDecommissionNumberActRadiostationInDB { get; }
        public ICommand ChangeNumberActAtRadiostationsInDB { get; }
        public ICommand AddNumberActInSignCollection { get; }
        public ICommand RemoveFromSignCollection { get; }
        public ICommand SearchBySingNumberActInRadiostationsForDocumentsCollection { get; }
        public ICommand AddNumberActInFillOutCollection { get; }
        public ICommand RemoveFromFillOutCollection { get; }
        public ICommand SearchByNumberActFillOutInRadiostationsForDocumentsCollection { get; }
        public ICommand GetFullRadiostantionsByRoadInRadiostationsForDocumentsCollection { get; }
        public ICommand HowMuchToCheckRadiostantionsByRoadInRadiostationsForDocumentsCollection { get; }
        public ICommand PrintActs { get; }
        public ICommand PrintExcelNumberActTechnicalWork { get; }
        public ICommand PrintExcelNumberActRepair { get; }
        public ICommand PrintWordDecommissionNumberAct { get; }
        public ICommand ShowDecommissioned { get; }
        public ICommand ShowNumberActRepair { get; }
        public ICommand PrintTagTechnicalWork { get; }
        public ICommand AddRadiostationParameters { get; }
        public ICommand PrintStatementParameters { get; }
        public ICommand PrintReports { get; }
        public WorkViewModel()
        {
            printExcel = new Print();
            backupCopyRadiostationsForDocuments = new BackupCopyRadiostationsForDocumentsCollection();
            _workRadiostantionRepository = new WorkRadiostantionRepository();
            _workRadiostantionFullRepository = new WorkRadiostantionFullRepository();
            _radiostationParametersRepository = new RadiostationParametersRepository();
            RadiostationsForDocumentsCollection = new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            RadiostationsParametersCollection = new ObservableCollection<RadiostationParametersDataBaseModel>();
            ReserveRadiostationsForDocumentsCollection = new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            PrintExcelNumberActRepairCollection = new List<RadiostationForDocumentsDataBaseModel>();
            SelectedRadiostationForAddRadiostationParametersViewCollection = new List<RadiostationForDocumentsDataBaseModel>();
            ParametersRadiostationForAddRadiostationParametersViewCollection = new List<RadiostationParametersDataBaseModel>();
            _getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();
            RoadsCollection = new ObservableCollection<RoadModel>();
            CitiesCollection = new ObservableCollection<string>();
            ChoiсeUniqueValuesCollection = new ObservableCollection<string>();
            SignCollection = new ObservableCollection<string>();
            FillOutCollection = new ObservableCollection<string>();
            AddRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteAddRadiostationForDocumentInDataBaseCommand);
            ChangeRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteChangeRadiostationForDocumentInDataBaseCommand);
            DeleteRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteDeleteRadiostationForDocumentInDataBaseCommand);
            UpdateRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteUpdateRadiostationForDocumentInDataBaseCommand);
            SaveCollectionRadiostationsForDocument = new ViewModelCommand(ExecuteSaveCollectionRadiostationsForDocumentCommand);
            AddRepairRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteAddRepairRadiostationForDocumentInDataBaseCommand);
            DeleteRepairRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteDeleteRepairRadiostationForDocumentInDataBaseCommand);
            AddDecommissionNumberActRadiostationForDocumentInDataBase = new ViewModelCommand(ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand);
            DeleteDecommissionNumberActRadiostationInDB = new ViewModelCommand(ExecuteDeleteDecommissionNumberActRadiostationInDBCommand);
            ChangeNumberActAtRadiostationsInDB = new ViewModelCommand(ExecuteChangeNumberActAtRadiostationsInDBCommand);
            AddNumberActInSignCollection = new ViewModelCommand(ExecuteAddNumberActInSignCollectionsCommand);
            RemoveFromSignCollection = new ViewModelCommand(ExecuteRemoveFromSignCollectionsCommand);
            SearchBySingNumberActInRadiostationsForDocumentsCollection = new ViewModelCommand(ExecuteSearchBySingNumberActInRadiostationsForDocumentsCollectionCommand);
            AddNumberActInFillOutCollection = new ViewModelCommand(ExecuteAddNumberActInFillOutCollectionsCommand);
            RemoveFromFillOutCollection = new ViewModelCommand(ExecuteRemoveFromFillOutCollectionsCommand);
            SearchByNumberActFillOutInRadiostationsForDocumentsCollection = new ViewModelCommand(ExecuteSearchByNumberActFillOutInRadiostationsForDocumentsCollectionCommand);
            GetFullRadiostantionsByRoadInRadiostationsForDocumentsCollection = new ViewModelCommand(ExecuteGetFullRadiostantionsByRoadInRadiostationsForDocumentsCollectionCommand);
            HowMuchToCheckRadiostantionsByRoadInRadiostationsForDocumentsCollection = new ViewModelCommand(ExecuteHowMuchToCheckRadiostantionsByRoadInRadiostationsForDocumentsCollectionCommand);
            PrintActs = new ViewModelCommand(ExecutePrintActsCommand);
            PrintExcelNumberActTechnicalWork = new ViewModelCommand(ExecutePrintExcelNumberActTechnicalWorkCommand);
            PrintExcelNumberActRepair = new ViewModelCommand(ExecutePrintExcelNumberActRepairCommand);
            PrintWordDecommissionNumberAct = new ViewModelCommand(ExecutePrintWordDecommissionNumberActCommand);
            PrintStatementParameters = new ViewModelCommand(ExecutePrintStatementParametersCommand);
            PrintReports = new ViewModelCommand(ExecutePrintReportsCommand);
            ShowDecommissioned = new ViewModelCommand(ExecuteShowDecommissionedCommand);
            ShowNumberActRepair = new ViewModelCommand(ExecuteShowNumberActRepairCommand);
            PrintTagTechnicalWork = new ViewModelCommand(ExecutePrintTagTechnicalWorkCommand);
            AddRadiostationParameters = new ViewModelCommand(ExecuteAddRadiostationParametersCommand);

            Task.Run(async () => await GetRoad()).GetAwaiter().GetResult();
            GetNumberActForSignCollections();
            GetNumberActForFillOutCollections();
            GetNameAndPostRadioCommunicationDirectorate();
            Timer();
        }

        #region GetNameAndPostRadioCommunicationDirectorate

        void GetNameAndPostRadioCommunicationDirectorate()
        {
            GlobalValue.RCS_REPRESENTATIVE_TO_SIGN_ACTS
                   = _getSetRegistryServiceTelecomSetting.GetRegistryNameRepresentativeRCS();
            GlobalValue.RCS_POST_TO_SIGN_ACTS =
                _getSetRegistryServiceTelecomSetting.GetRegistryPostRepresentativeRCS();
        }

        #endregion

        #region PrintReports

        void ExecutePrintReportsCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (printReportsView != null)
                return;
            if (RadiostationsParametersCollection.Count == 0)
                return;
            if (CHECK_HOW_MUCH)
                return;

            foreach (var item in RadiostationsForDocumentsCollection)
                if (SelectedRadiostation.NumberAct == item.NumberAct)
                {
                    if (item.VerifiedRST != GlobalValue.PASSED_TECHNICAL_SERVICES)
                    {
                        MessageBox.Show(
                        $"Нельзя напечатать отчёт есть радиостанция, " +
                        $"которая не прошла проверку {item.SerialNumber}", "Отмена",
                         MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

            GlobalCollection.PARAMETERS_RADIOSTATION_GENERAL = RadiostationsParametersCollection;

            printReportsView = new PrintReportsView();
            printReportsView.Closed += (sender, args) => printReportsView = null;
            printReportsView.ShowDialog();
        }

        #endregion

        #region AddRadiostationParameters

        private void ExecuteAddRadiostationParametersCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (addRadiostationParametersView != null)
                return;
            if (SelectedRadiostation == null)
                return;

            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Нельзя добавить параметры на радиостанцию" +
                    $"{SelectedRadiostation.SerialNumber} " +
                    $"есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(SelectedRadiostation.NumberAct))
            {
                MessageBox.Show(
                   $"Нельзя добавить параметры на радиостанцию" +
                   $"Отсутствует номер акта", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            #region поиск и заполнение характеристик(документы) для коллекции

            if (SelectedRadiostationForAddRadiostationParametersViewCollection.Count != 0)
                SelectedRadiostationForAddRadiostationParametersViewCollection.Clear();

            foreach (var item in RadiostationsForDocumentsCollection)
                if (SelectedRadiostation.SerialNumber == item.SerialNumber)
                    SelectedRadiostationForAddRadiostationParametersViewCollection.Add(item);
            if (SelectedRadiostationForAddRadiostationParametersViewCollection.Count == 0)
                return;
            if (SelectedRadiostationForAddRadiostationParametersViewCollection.Count > 1)
                return;

            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID =
                SelectedRadiostationForAddRadiostationParametersViewCollection;

            #endregion

            #region поиск и заполнение характеристик(параметры) для коллекции

            if (ParametersRadiostationForAddRadiostationParametersViewCollection.Count != 0)
                ParametersRadiostationForAddRadiostationParametersViewCollection.Clear();

            foreach (var item in RadiostationsParametersCollection)
                if (SelectedRadiostation.SerialNumber == item.SerialNumber)
                    ParametersRadiostationForAddRadiostationParametersViewCollection.Add(item);

            GlobalCollection.PARAMETERS_RADIOSTATION_FOR_ADD_RADIOSTATION_PARAMETERS_VIEW =
                ParametersRadiostationForAddRadiostationParametersViewCollection;

            #endregion

            addRadiostationParametersView = new AddRadiostationParametersView();
            addRadiostationParametersView.Closed += (sender, args) =>
            addRadiostationParametersView = null;
            addRadiostationParametersView.Closed += (sender, args) =>
            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID = null;
            addRadiostationParametersView.Closed += (sender, args) =>
            GlobalCollection.PARAMETERS_RADIOSTATION_FOR_ADD_RADIOSTATION_PARAMETERS_VIEW = null;
            addRadiostationParametersView.Closed += (sender, args) =>
            GetRadiostations(Road, City);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            addRadiostationParametersView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            addRadiostationParametersView.Show();
        }

        #endregion

        #region PrintTagTechnicalWork

        private void ExecutePrintTagTechnicalWorkCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (printTagTechnicalWorkView != null)
                return;
            if (SelectedRadiostation == null)
                return;

            GlobalValue.ROAD = SelectedRadiostation.Road;
            GlobalValue.CITY = SelectedRadiostation.City;
            printTagTechnicalWorkView = new PrintTagTechnicalWorkView();
            printTagTechnicalWorkView.Closed += (sender, args) =>
            printTagTechnicalWorkView = null;
            printTagTechnicalWorkView.Closed += (sender, args) =>
            ClearUserModelStaticRoadCitySerialNumber();
            printTagTechnicalWorkView.ShowDialog();
        }

        #endregion

        #region PrintWordDecommissionNumberAct

        private void ExecutePrintWordDecommissionNumberActCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.NumberAct))
            {
                MessageBox.Show(
                    $"Нельзя напечатать списание на радиостанцию " +
                    $"{SelectedRadiostation.SerialNumber} " +
                    $"она есть в акте: {SelectedRadiostation.NumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PrintWordDecommissionNumberActCollection =
               new List<RadiostationForDocumentsDataBaseModel>();

            foreach (var item in RadiostationsForDocumentsCollection)
                if (SelectedRadiostation.DecommissionNumberAct
                    == item.DecommissionNumberAct)
                    PrintWordDecommissionNumberActCollection.Add(item);

            if (PrintWordDecommissionNumberActCollection.Count == 0)
                return;
            if (PrintWordDecommissionNumberActCollection.Count > 1)
                return;

            new Thread(() =>
            {
                printExcel.PrintWordDecommissionNumberAct(
                PrintWordDecommissionNumberActCollection);
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintStatementParameters

        private void ExecutePrintStatementParametersCommand(object obj)
        {
            if (RadiostationsForDocumentsCollection.Count == 0)
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;

            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Нельзя напечатать ремонт на радиостанцию " +
                    $"{SelectedRadiostation.SerialNumber} " +
                    $"есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (var item in RadiostationsForDocumentsCollection)
                if (SelectedRadiostation.NumberAct == item.NumberAct)
                {
                    if (item.VerifiedRST != GlobalValue.PASSED_TECHNICAL_SERVICES)
                    {
                        MessageBox.Show(
                        $"Нельзя напечатать ведомость т.к. есть радиостанция " +
                        $"которая не прошла проверку {item.SerialNumber}", "Отмена",
                         MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

            PrintStatementParametersCollection =
                new List<RadiostationParametersDataBaseModel>();

            foreach (var item in RadiostationsParametersCollection)
                if (SelectedRadiostation.NumberAct == item.NumberAct)
                    PrintStatementParametersCollection.Add(item);

            if (PrintStatementParametersCollection.Count == 0)
                return;
            if (PrintStatementParametersCollection.Count > 20)
                return;

            PrintStatementParametersCollection.Sort();

            //addChangeRepresentativeRCSView =
            //    new AddChangeRepresentativeRCSView();
            //addChangeRepresentativeRCSView.ShowDialog();

            new Thread(() =>
            {
                printExcel.PrintStatementParameters(
                PrintStatementParametersCollection);
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintExcelNumberActRepair

        private void ExecutePrintExcelNumberActRepairCommand(object obj)
        {
            if (printRepairView != null)
                return;
            if (RadiostationsForDocumentsCollection.Count == 0)
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;
            if (string.IsNullOrWhiteSpace(SelectedRadiostation.NumberActRepair))
                return;

            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Нельзя напечатать ремонт на радиостанцию " +
                    $"{SelectedRadiostation.SerialNumber} " +
                    $"есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (PrintExcelNumberActRepairCollection.Count != 0)
                PrintExcelNumberActRepairCollection.Clear();

            foreach (var item in RadiostationsForDocumentsCollection)
                if (SelectedRadiostation.NumberActRepair == item.NumberActRepair)
                    PrintExcelNumberActRepairCollection.Add(item);

            if (PrintExcelNumberActRepairCollection == null ||
                PrintExcelNumberActRepairCollection.Count == 0 ||
                PrintExcelNumberActRepairCollection.Count > 1)
                return;

            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID =
                PrintExcelNumberActRepairCollection;

            printRepairView = new PrintRepairView();
            printRepairView.Closed += (sender, args) => printRepairView = null;
            printRepairView.Closed += (sender, args) =>
            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID = null;

            printRepairView.ShowDialog();
        }


        #endregion

        #region PrintExcelNumberActTechnicalWork

        private void ExecutePrintExcelNumberActTechnicalWorkCommand(object obj)
        {
            if (RadiostationsForDocumentsCollection.Count == 0)
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;
            if (String.IsNullOrWhiteSpace(SelectedRadiostation.NumberAct))
            {
                MessageBox.Show(
                    $"Нельзя напечатать на радиостанцию " +
                    $"{SelectedRadiostation.SerialNumber} " +
                    $"у неё отсутсвует номер акта!", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            PrintExcelNumberActTechnicalWorkCollection =
                new List<RadiostationForDocumentsDataBaseModel>();

            foreach (var item in RadiostationsForDocumentsCollection)
                if (SelectedRadiostation.NumberAct == item.NumberAct)
                    PrintExcelNumberActTechnicalWorkCollection.Add(item);

            if (PrintExcelNumberActTechnicalWorkCollection.Count == 0)
                return;
            if (PrintExcelNumberActTechnicalWorkCollection.Count > 20)
                return;
            PrintExcelNumberActTechnicalWorkCollection.Sort();

            new Thread(() =>
            {
                printExcel.PrintExcelNumberActTechnicalWork(
                PrintExcelNumberActTechnicalWorkCollection);
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region PrintActs

        private void ExecutePrintActsCommand(object obj)
        {
            if (RadiostationsForDocumentsCollection.Count == 0)
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (UserModelStatic.POST == "Дирекция связи")
                return;

            if (CmbChoiseSearch == "№ акта ТО")
            {
                PrintExcelNumberActTechnicalWorkCollection =
                new List<RadiostationForDocumentsDataBaseModel>();

                foreach (var item in RadiostationsForDocumentsCollection)
                    if (ChoiсeUniqueValue == item.NumberAct)
                        PrintExcelNumberActTechnicalWorkCollection.Add(item);

                if (PrintExcelNumberActTechnicalWorkCollection.Count == 0)
                    return;
                if (PrintExcelNumberActTechnicalWorkCollection.Count > 20)
                    return;
                PrintExcelNumberActTechnicalWorkCollection.Sort();

                new Thread(() =>
                {
                    printExcel.PrintExcelNumberActTechnicalWork(
                    PrintExcelNumberActTechnicalWorkCollection);
                })
                { IsBackground = true }.Start();

            }
            if (CmbChoiseSearch == "№ акта Ремонта")
            {
                if (printRepairView != null)
                    return;

                if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
                {
                    MessageBox.Show(
                        $"Нельзя напечатать ремонт на радиостанцию" +
                        $"{SelectedRadiostation.SerialNumber} " +
                        $"есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                         MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                foreach (var item in RadiostationsForDocumentsCollection)
                    if (ChoiсeUniqueValue == item.NumberActRepair)
                        PrintExcelNumberActRepairCollection.Add(item);
                if (PrintExcelNumberActRepairCollection.Count == 0)
                    return;
                if (PrintExcelNumberActRepairCollection.Count > 1)
                    return;

                GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID =
                    PrintExcelNumberActRepairCollection;

                printRepairView = new PrintRepairView();
                printRepairView.Closed += (sender, args) => printRepairView = null;
                printRepairView.Closed += (sender, args) =>
                GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID = null;
                printRepairView.Show();
            }
            if (CmbChoiseSearch == "№ акта списания")
            {
                PrintWordDecommissionNumberActCollection =
                new List<RadiostationForDocumentsDataBaseModel>();

                foreach (var item in RadiostationsForDocumentsCollection)
                    if (ChoiсeUniqueValue == item.DecommissionNumberAct)
                        PrintWordDecommissionNumberActCollection.Add(item);
                if (PrintWordDecommissionNumberActCollection.Count == 0)
                    return;
                if (PrintWordDecommissionNumberActCollection.Count > 1)
                    return;

                new Thread(() =>
                {
                    printExcel.PrintWordDecommissionNumberAct(
                    PrintWordDecommissionNumberActCollection);
                })
                { IsBackground = true }.Start();
            }
            if (CmbChoiseSearch == "Ведомость")
            {
                if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
                {
                    MessageBox.Show(
                        $"Нельзя напечатать ремонт на радиостанцию " +
                        $"{SelectedRadiostation.SerialNumber} " +
                        $"есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                         MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                foreach (var item in RadiostationsForDocumentsCollection)
                    if (SelectedRadiostation.NumberAct == item.NumberAct)
                    {
                        if (item.VerifiedRST != GlobalValue.PASSED_TECHNICAL_SERVICES)
                        {
                            MessageBox.Show(
                            $"Нельзя напечатать ведомость т.к. есть радиостанция " +
                            $"которая не прошла проверку {item.SerialNumber}", "Отмена",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                PrintStatementParametersCollection =
                new List<RadiostationParametersDataBaseModel>();

                foreach (var item in RadiostationsParametersCollection)
                    if (SelectedRadiostation.NumberAct == item.NumberAct)
                        PrintStatementParametersCollection.Add(item);

                if (PrintStatementParametersCollection.Count == 0)
                    return;
                if (PrintStatementParametersCollection.Count > 20)
                    return;

                PrintStatementParametersCollection.Sort();

                new Thread(() =>
                {
                    printExcel.PrintStatementParameters(
                    PrintStatementParametersCollection);
                })
                { IsBackground = true }.Start();
            }
        }

        #endregion

        #region Timer and BackupCopyRadiostationsForDocumentsCollection

        private void Timer()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(BackupCopyRadiostationsForDocumentsCollection);
            dispatcherTimer.Interval = new TimeSpan(0, 30, 0);
            dispatcherTimer.Start();
        }

        private void BackupCopyRadiostationsForDocumentsCollection(object sender, EventArgs e)
        {
            if (RadiostationsForDocumentsCollection.Count == 0)
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (UserModelStatic.POST == "Дирекция связи")
                return;

            new Thread(() =>
            {
                backupCopyRadiostationsForDocuments.
                AutoSaveRadiostationsFullJson(City, RadiostationsForDocumentsCollection);
            })
            { IsBackground = true }.Start();

            new Thread(() =>
            {
                backupCopyRadiostationsForDocuments.
                CopyDataBaseRadiostantionInRadiostantionCopy();
            })
            { IsBackground = true }.Start();

            new Thread(() =>
            {
                backupCopyRadiostationsForDocuments.
                AutoSaveRadiostationsFullCSV(City, RadiostationsForDocumentsCollection);
            })
            { IsBackground = true }.Start();
        }

        #endregion

        #region ChangeNumberActAtRadiostationsInDB

        private void ExecuteChangeNumberActAtRadiostationsInDBCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;

            if (RadiostationsForDocumentsMulipleSelectedDataGrid == null ||
               RadiostationsForDocumentsMulipleSelectedDataGrid.Count == 0)
                return;

            foreach (RadiostationForDocumentsDataBaseModel item
                in RadiostationsForDocumentsMulipleSelectedDataGrid)
            {
                if (!String.IsNullOrWhiteSpace(item.DecommissionNumberAct))
                {
                    MessageBox.Show(
                    $"У выбранной радиостанции {item.SerialNumber} " +
                    $"есть списание {item.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (changeNumberActView != null)
                return;
            GlobalValue.ROAD = Road;
            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID
                = RadiostationsForDocumentsMulipleSelectedDataGrid;

            changeNumberActView = new ChangeNumberActView(
                SelectedRadiostation.NumberAct);
            changeNumberActView.Closed += (sender, args) => changeNumberActView = null;
            changeNumberActView.Closed += (sender, args) => GlobalValue.ROAD = null;
            changeNumberActView.Closed += (sender, args) =>
            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID = null;
            changeNumberActView.Closed += (sender, args) =>
            RadiostationsForDocumentsMulipleSelectedDataGrid = null;
            changeNumberActView.Closed += (sender, args) =>
            GetRadiostations(Road, City);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            changeNumberActView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            changeNumberActView.Show();
        }

        #endregion

        #region DeleteDecommissionNumberActRadiostationInDB

        private void ExecuteDeleteDecommissionNumberActRadiostationInDBCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
                return;
            if (MessageBox.Show("Подтверждаете удаление списания?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (_workRadiostantionFullRepository.
                DeleteDecommissionNumberActRadiostationInDBRadiostationFull(
                    Road, City, SelectedRadiostation.SerialNumber))
            { }
            else
                MessageBox.Show($"Ошибка удаления списания у радиостанции " +
                    $"{SelectedRadiostation.SerialNumber} из radiostantionFull(общая база)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            if (_workRadiostantionRepository.DeleteDecommissionNumberActRadiostationInDB(
                    Road, City, SelectedRadiostation.SerialNumber))
                MessageBox.Show("Успешно! Добавь номер акта ТО и исправь Price!", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка удаления списания у радиостанции " +
                    $"{SelectedRadiostation.SerialNumber}",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            GetRadiostations(Road, City);
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region AddDecommissionNumberActRadiostationForDocumentInDataBase

        private void ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Уже есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.NumberActRepair))
            {
                MessageBox.Show(
                    $"Есть ремонт: {SelectedRadiostation.NumberActRepair}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (addDecommissionNumberActView != null)
                return;

            addDecommissionNumberActView = new AddDecommissionNumberActView(
                SelectedRadiostation.Road,
                SelectedRadiostation.City,
                SelectedRadiostation.SerialNumber,
                SelectedRadiostation.NumberAct);
            addDecommissionNumberActView.Closed += (sender, args) =>
            addDecommissionNumberActView = null;
            addDecommissionNumberActView.Closed += (sender, args) =>
            GetRadiostations(Road, City);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            addDecommissionNumberActView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            addDecommissionNumberActView.Show();
        }

        #endregion

        #region DeleteRepairRadiostationForDocumentInDataBase

        private void ExecuteDeleteRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (String.IsNullOrWhiteSpace(SelectedRadiostation.NumberActRepair))
                return;
            if (MessageBox.Show("Подтверждаете удаление ремонта?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (_workRadiostantionFullRepository.
                DeleteRepairRadiostationForDocumentInDBRadiostantionFull(
                    Road, City, SelectedRadiostation.SerialNumber))
            { }
            else
                MessageBox.Show($"Ошибка удаления номера акта ремонта радиостанции " +
                    $"{SelectedRadiostation.SerialNumber} из radiostantionFull(общая таблица)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);

            if (_workRadiostantionRepository.DeleteRepairRadiostationForDocumentInDataBase(
                    Road, City, SelectedRadiostation.SerialNumber))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка удаления номера акта ремонта радиостанции " +
                    $"{SelectedRadiostation.SerialNumber}", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            GetRadiostations(Road, City);
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region SaveCollectionRadiostationsForDocument

        private void ExecuteSaveCollectionRadiostationsForDocumentCommand(object obj)
        {
            if (RadiostationsForDocumentsCollection.Count == 0)
                return;
            if (selectingSaveView == null)
            {
                selectingSaveView = new SelectingSaveView(SelectedRadiostation.City,
                    RadiostationsForDocumentsCollection);
                selectingSaveView.Closed += (sender, args) => selectingSaveView = null;
                selectingSaveView.Show();
            }
        }

        #endregion

        #region UpdateRadiostationForDocumentInDataBase

        private void ExecuteUpdateRadiostationForDocumentInDataBaseCommand(object obj)
        {
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;

            GetCityOnTheRoad(RoadsCollection.FirstOrDefault(item => item.Road == Road)?.IdBase ?? 0);

            if (RadiostationsForDocumentsCollection.Count > 0)
                GetRadiostations(Road, _getSetRegistryServiceTelecomSetting.GetRegistryCityForAddChangeDelete());
            else GetRadiostations(Road, City);

            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region DeleteRadiostationForDocumentInDataBase

        private void ExecuteDeleteRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (RadiostationsForDocumentsMulipleSelectedDataGrid == null ||
               RadiostationsForDocumentsMulipleSelectedDataGrid.Count == 0)
                return;
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (MessageBox.Show("Подтверждаете удаление радиостанции?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            foreach (RadiostationForDocumentsDataBaseModel radiostationForDocumentsDataBaseModel in
                RadiostationsForDocumentsMulipleSelectedDataGrid)
            {
                _workRadiostantionRepository.DeleteRadiostationFromDataBase(
                    radiostationForDocumentsDataBaseModel.IdBase);
                if (_radiostationParametersRepository.CheckSerialNumberInRadiostationParameters(
                    radiostationForDocumentsDataBaseModel.Road, radiostationForDocumentsDataBaseModel.SerialNumber))
                {
                    if (!_radiostationParametersRepository.DeleteRadiostantionFromRadiostationParameters(
                        radiostationForDocumentsDataBaseModel.Road, radiostationForDocumentsDataBaseModel.SerialNumber))
                        MessageBox.Show("Ошибка удаления радиостанции из radiostation_parameters(таблица)",
                            "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            GetCityOnTheRoad(RoadsCollection.FirstOrDefault(item => item.Road == Road)?.IdBase ?? 0);
            GetRadiostations(Road,
                _getSetRegistryServiceTelecomSetting.GetRegistryCityForAddChangeDelete());
            GetRowAfterAddingRadiostantionInDataGrid();
        }

        #endregion

        #region AddRepairRadiostationForDocumentInDataBase

        private void ExecuteAddRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Нельзя добавить ремонт на радиостанцию{SelectedRadiostation.SerialNumber} " +
                    $"есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (addRepairRadiostationForDocumentInDataBaseView != null)
                return;

            GlobalValue.ROAD = SelectedRadiostation.Road;
            GlobalValue.CITY = SelectedRadiostation.City;
            GlobalValue.MODEL = SelectedRadiostation.Model;
            GlobalValue.SERIAL_NUMBER = SelectedRadiostation.SerialNumber;

            addRepairRadiostationForDocumentInDataBaseView =
                new AddRepairRadiostationForDocumentInDataBaseView(
                    SelectedRadiostation);

            addRepairRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            addRepairRadiostationForDocumentInDataBaseView = null;
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            addRepairRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRadiostations(Road, City);
            addRepairRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            addRepairRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            ClearUserModelStaticRoadCitySerialNumber();
            addRepairRadiostationForDocumentInDataBaseView.Show();
        }

        #endregion

        #region ClearUserModelStaticRoadCitySerialNumber 

        private void ClearUserModelStaticRoadCitySerialNumber()
        {
            GlobalValue.ROAD = null;
            GlobalValue.CITY = null;
            GlobalValue.MODEL = null;
            GlobalValue.SERIAL_NUMBER = null;
        }

        #endregion

        #region ChangeRadiostationForDocumentInDataBase

        private void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (changeRadiostationForDocumentInDataBaseView != null)
                return;
            if (SelectedRadiostation == null)
                return;
            changeRadiostationForDocumentInDataBaseView =
            new ChangeRadiostationForDocumentInDataBaseView(
                SelectedRadiostation);
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            changeRadiostationForDocumentInDataBaseView = null;
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            _getSetRegistryServiceTelecomSetting.SetRegistryCityForAddChangeDelete(City);
            //changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            //GetCityOnTheRoad(RoadsCollection.IndexOf(Road));
            //changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            //GetRadiostations(Road,
            //_getSetRegistryServiceTelecomSetting.GetRegistryCityForAddChangeDelete());
            //TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            //changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            //GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            changeRadiostationForDocumentInDataBaseView.Show();

        }

        #endregion

        #region AddRadiostationForDocumentInDataBase

        private void ExecuteAddRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (addRadiostationForDocumentInDataBaseView == null)
            {
                if (SelectedRadiostation == null)
                    addRadiostationForDocumentInDataBaseView =
                    new AddRadiostationForDocumentInDataBaseView(Road);
                else addRadiostationForDocumentInDataBaseView =
                    new AddRadiostationForDocumentInDataBaseView(
                        SelectedRadiostation);
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                _getSetRegistryServiceTelecomSetting.SetRegistryCityForAddChangeDelete(City);
                //addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                //GetCityOnTheRoad(RoadsCollection.IndexOf(Road));
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                addRadiostationForDocumentInDataBaseView = null;

                //if (RadiostationsForDocumentsCollection.Count > 0)
                //{
                //    addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                //    GetRadiostations(Road,
                //    _getSetRegistryServiceTelecomSetting.GetRegistryCityForAddChangeDelete());
                //    addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                //    GetRowAfterAddingRadiostantionInDataGrid();
                //}
                //else
                //{
                //    addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                //    GetRadiostations(Road, City);
                //}

                addRadiostationForDocumentInDataBaseView.Show();
            }
        }

        #endregion

        #region GetRoad

        async Task GetRoad()
        {
            int i = 0; // для id дороги

            if (RoadsCollection.Count != 0)
                RoadsCollection.Clear();

            if (GlobalCollection.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION.Count == 0)
            {
                _roadDataBaseRepository = new RoadDataBaseRepository();
                RoadsCollection = await _roadDataBaseRepository.GetRoadDataBase(RoadsCollection);
            }
            else
            {
                foreach (var item in GlobalCollection.STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION)
                    RoadsCollection.Add(new RoadModel(i++, item.RoadBase));
            }
        }


        #endregion

        #region GetCityOnTheRoad

        async void GetCityOnTheRoad(int index)
        {
            if (index < 0)
                return;

            if (CitiesCollection.Count != 0)
            {
                SelectedIndexCityCollection = -1;
                CitiesCollection.Clear();
            }

            CitiesCollection = await _workRadiostantionRepository.
                GetCityAlongRoadForCityCollection(RoadsCollection[index].ToString(), CitiesCollection);
            SelectedIndexCityCollection = 0;

            if (CitiesCollection.Count != 0)
                Counters();
        }

        #endregion

        #region Получаем крайнюю строку DataGrid после добавления радиостанции

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

        #region HowMuchToCheckRadiostantionsByRoadInRadiostationsForDocumentsCollection

        private void ExecuteHowMuchToCheckRadiostantionsByRoadInRadiostationsForDocumentsCollectionCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (Road == null)
                return;
            if (City == null)
                return;
            if (RoadsCollection.Count == 0) return;
            if (CitiesCollection.Count == 0) return;

            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();
            RadiostationsForDocumentsCollection =
                _workRadiostantionRepository.
                HowMuchToCheckRadiostantionsByCityForDocumentsCollection(
                RadiostationsForDocumentsCollection, Road, City);
            if (ReserveRadiostationsForDocumentsCollection.Count != 0)
                ReserveRadiostationsForDocumentsCollection.Clear();
            foreach (var item in RadiostationsForDocumentsCollection)
                ReserveRadiostationsForDocumentsCollection.Add(item);
            Counters();
            CHECK_HOW_MUCH = true;
        }

        #endregion

        #region GetFullRadiostantionsByRoadInRadiostationsForDocumentsCollection

        private void ExecuteGetFullRadiostantionsByRoadInRadiostationsForDocumentsCollectionCommand(object obj)
        {
            if (Road == null)
                return;
            if (RoadsCollection.Count == 0) return;

            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();
            RadiostationsForDocumentsCollection =
                _workRadiostantionRepository.GetFullByRoadRadiostationsForDocumentsCollection(
                RadiostationsForDocumentsCollection, Road);
            if (ReserveRadiostationsForDocumentsCollection.Count != 0)
                ReserveRadiostationsForDocumentsCollection.Clear();
            foreach (var item in RadiostationsForDocumentsCollection)
                ReserveRadiostationsForDocumentsCollection.Add(item);
            Counters();
            CHECK_HOW_MUCH = false;
        }

        #endregion

        #region GetRadiostations

        void GetRadiostations(string road, string city)
        {
            if (road == null)
                return;
            if (city == null)
                return;
            if (NUMBER_LIMIT_LOADING_REGESTRY_CITY == 0)
            {
                city = _getSetRegistryServiceTelecomSetting.GetRegistryCity();
                NUMBER_LIMIT_LOADING_REGESTRY_CITY++;
            }

            GetRadiostationsForDocumentsCollection(road, city);

            GetRadiostationsParametersCollection(road, city);

            City = city;

            _getSetRegistryServiceTelecomSetting.SetRegistryCity(city);

            if (ReserveRadiostationsForDocumentsCollection.Count != 0)
                ReserveRadiostationsForDocumentsCollection.Clear();
            foreach (var item in RadiostationsForDocumentsCollection)
                ReserveRadiostationsForDocumentsCollection.Add(item);

            Counters();
            CHECK_HOW_MUCH = false;
        }

        async void GetRadiostationsForDocumentsCollection(string road, string city)
        {
            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();

            RadiostationsForDocumentsCollection =
                await _workRadiostantionRepository.GetRadiostationsForDocumentsCollection(
                    RadiostationsForDocumentsCollection, road, city);

            if (TEMPORARY_INDEX_DATAGRID != -1) // если отсутсвуют РСТ или сбой загрузки
                SelectedRadiostation = RadiostationsForDocumentsCollection[TEMPORARY_INDEX_DATAGRID];

        }

        async void GetRadiostationsParametersCollection(string road, string city)
        {
            if (RadiostationsParametersCollection.Count != 0)
                RadiostationsParametersCollection.Clear();
            RadiostationsParametersCollection =
               await _radiostationParametersRepository.GetRadiostationsParametersCollection(
                    RadiostationsParametersCollection, road, city);
        }

        #endregion

        #region ShowNumberActRepair

        private void ExecuteShowNumberActRepairCommand(object obj)
        {
            for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
            {
                if (String.IsNullOrWhiteSpace(
                    RadiostationsForDocumentsCollection[i].NumberActRepair))
                    RadiostationsForDocumentsCollection.
                        Remove(RadiostationsForDocumentsCollection[i]);
                else i++;
            }
        }

        #endregion

        #region ShowDecommissioned

        private void ExecuteShowDecommissionedCommand(object obj)
        {
            for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
            {
                if (String.IsNullOrWhiteSpace(
                    RadiostationsForDocumentsCollection[i].DecommissionNumberAct))
                    RadiostationsForDocumentsCollection.
                        Remove(RadiostationsForDocumentsCollection[i]);
                else i++;
            }
        }

        #endregion

        #region SearchByChoiseUniqueValueInRadiostationsForDocumentsCollection

        private void SearchByChoiseUniqueValueInRadiostationsForDocumentsCollection(string value)
        {
            if (String.IsNullOrWhiteSpace(City))
                return;
            if (string.IsNullOrWhiteSpace(value))
            {
                if (RadiostationsForDocumentsCollection.Count != 0)
                    RadiostationsForDocumentsCollection.Clear();
                foreach (var item in ReserveRadiostationsForDocumentsCollection)
                    RadiostationsForDocumentsCollection.Add(item);
            }

            if (CmbChoiseSearch == "Заводской №")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].SerialNumber.
                            Contains(value))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].SerialNumber.Contains(value))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "Предприятие")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].Company.
                            Contains(value.Trim().ToUpper()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].Company.Contains(value.Trim().ToUpper()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "Станция")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].Location.
                            Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].Location.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "Дата ТО")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].DateMaintenance.
                            Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].
                            DateMaintenance.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "№ акта ТО" || CmbChoiseSearch == "Ведомость")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].NumberAct.
                            Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].
                            NumberAct.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "№ акта Ремонта")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].NumberActRepair.
                            Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].
                            NumberActRepair.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "Представитель ПП")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].Representative.
                            Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].
                            Representative.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "№ акта списания")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].
                            DecommissionNumberAct.Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].
                            DecommissionNumberAct.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }
            if (CmbChoiseSearch == "Модель")
            {
                if (RadiostationsForDocumentsCollection.Count !=
                ReserveRadiostationsForDocumentsCollection.Count)
                {
                    RadiostationsForDocumentsCollection.Clear();
                    for (int i = 0; i < ReserveRadiostationsForDocumentsCollection.Count; i++)
                    {
                        if (ReserveRadiostationsForDocumentsCollection[i].
                            Model.Contains(value.Trim()))
                        {
                            RadiostationsForDocumentsCollection.Add(
                                ReserveRadiostationsForDocumentsCollection[i]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
                    {
                        if (!RadiostationsForDocumentsCollection[i].
                            Model.Contains(value.Trim()))
                            RadiostationsForDocumentsCollection.
                                Remove(RadiostationsForDocumentsCollection[i]);
                        else i++;
                    }
                }
            }

            Counters();
        }


        #endregion

        #region Counters

        void Counters()
        {
            //Кол-во радиостанций
            CounterQuantityRadiostantion =
                RadiostationsForDocumentsCollection.Count.ToString() + " шт.";

            //Общая цена ТО
            decimal amountRadiostantion = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                amountRadiostantion += Convert.ToDecimal(
                    item.Price);
            CounterAmountRadiostantion = amountRadiostantion.ToString() + " руб.";

            //Кол-во ремонтов
            int quantityRepair = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                if (!String.IsNullOrWhiteSpace(item.NumberActRepair))
                    quantityRepair++;
            CounterQuantityRepair = quantityRepair.ToString() + " шт.";

            //Сумма ремонтов
            decimal amountRepair = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                if (!String.IsNullOrWhiteSpace(item.PriceRemont))
                    amountRepair += Convert.ToDecimal(
                    item.PriceRemont);
            CounterAmountRepair = amountRepair.ToString() + " руб.";

            //В работе
            int inWorkRadiostantions = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                if (item.VerifiedRST == GlobalValue.IN_WORK_TECHNICAL_SERVICES)
                {
                    if (!String.IsNullOrWhiteSpace(item.DecommissionNumberAct))
                        continue;
                    inWorkRadiostantions++;
                }

            CounterInWorkRadiostantions = inWorkRadiostantions.ToString() + " шт.";

            //Прошла проверку
            int verifiedRadiostantions = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                if (item.VerifiedRST == GlobalValue.PASSED_TECHNICAL_SERVICES)
                    verifiedRadiostantions++;
            CounterVerifiedRadiostantions = verifiedRadiostantions.ToString() + " шт.";

            //в ремонт
            int inRepairRadiostantionsTechnicalServices = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                if (item.VerifiedRST == GlobalValue.IN_REPAIR_TECHNICAL_SERVICES)
                    inRepairRadiostantionsTechnicalServices++;
            CounterInRepairRadiostantionsTechnicalServices
                = inRepairRadiostantionsTechnicalServices.ToString() + " шт.";

            //списаний
            int decommissionNumberActs = 0;
            foreach (var item in RadiostationsForDocumentsCollection)
                if (item.VerifiedRST == GlobalValue.DECOMMISSION_RADIOSTANTION)
                    decommissionNumberActs++;
            CounterDecommissionNumberActs = decommissionNumberActs.ToString() + " шт.";
        }

        #endregion

        #region Акты заполняем

        #region AddNumberActInFillOutCollections

        private void ExecuteAddNumberActInFillOutCollectionsCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (var item in FillOutCollection)
                if (item == SelectedRadiostation.NumberAct)
                    return;

            FillOutCollection.Add(SelectedRadiostation.NumberAct);

            string temp = string.Empty;

            for (int i = 0; i < FillOutCollection.Count; i++)
            {
                for (int y = 0; y < FillOutCollection.Count - 1; y++)
                {
                    if (Convert.ToInt32(FillOutCollection[y].
                        Substring(FillOutCollection[y].IndexOf("/") + 1))
                    > Convert.ToInt32(FillOutCollection[y + 1].
                    Substring(FillOutCollection[y + 1].IndexOf("/") + 1)))
                    {
                        temp = FillOutCollection[y + 1];
                        FillOutCollection[y + 1] = FillOutCollection[y];
                        FillOutCollection[y] = temp;
                    }
                }
            }

            string addRegistry = String.Empty;
            foreach (var item in FillOutCollection)
                addRegistry += item.ToString() + ";";

            _getSetRegistryServiceTelecomSetting.SetRegistryNumberActForFillOutCollections
                (addRegistry);

            if (FillOutCollection.Count > 0)
                SelectedIndexFillOutCollection = FillOutCollection.Count - 1;
        }

        #endregion

        #region GetNumberActForFillOutCollections

        private void GetNumberActForFillOutCollections()
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            string addRegistry =
             _getSetRegistryServiceTelecomSetting.
             GetRegistryNumberActForFillOutCollections();

            if (String.IsNullOrWhiteSpace(addRegistry))
                return;

            string[] split = addRegistry.Split(new Char[] { ';' });

            foreach (string item in split)
                if (!String.IsNullOrWhiteSpace(item))
                    FillOutCollection.Add(item);

            string temp = string.Empty;

            for (int i = 0; i < FillOutCollection.Count; i++)
            {
                for (int y = 0; y < FillOutCollection.Count - 1; y++)
                {
                    if (Convert.ToInt32(FillOutCollection[y].
                        Substring(FillOutCollection[y].IndexOf("/") + 1))
                    > Convert.ToInt32(FillOutCollection[y + 1].
                    Substring(FillOutCollection[y + 1].IndexOf("/") + 1)))
                    {
                        temp = FillOutCollection[y + 1];
                        FillOutCollection[y + 1] = FillOutCollection[y];
                        FillOutCollection[y] = temp;
                    }
                }
            }

            if (FillOutCollection.Count > 0)
                SelectedIndexFillOutCollection = FillOutCollection.Count - 2;

        }

        #endregion

        #region RemoveFromFillOutCollections

        private void ExecuteRemoveFromFillOutCollectionsCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (FillOutCollection.Count == 0) return;

            if (FillOutCollection.Count > 0)
            {
                FillOutCollection.Remove(FillOut);
                SelectedIndexFillOutCollection = FillOutCollection.Count - 1;
            }

            string addRegistry = String.Empty;
            foreach (var item in FillOutCollection)
                addRegistry += item.ToString() + ";";

            _getSetRegistryServiceTelecomSetting.SetRegistryNumberActForFillOutCollections
                (addRegistry);
        }

        #endregion

        #region SearchByNumberActFillOutInRadiostationsForDocumentsCollection

        private void ExecuteSearchByNumberActFillOutInRadiostationsForDocumentsCollectionCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (String.IsNullOrWhiteSpace(City))
                return;
            if (FillOutCollection.Count < 1)
                return;

            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();
            foreach (var item in ReserveRadiostationsForDocumentsCollection)
                RadiostationsForDocumentsCollection.Add(item);

            for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
            {
                if (RadiostationsForDocumentsCollection[i].
                    NumberAct != FillOut)
                    RadiostationsForDocumentsCollection.
                        Remove(RadiostationsForDocumentsCollection[i]);
                else i++;
            }
            Counters();
        }

        #endregion


        #endregion

        #region Акты на подпись

        #region AddNumberActInSignCollections

        private void ExecuteAddNumberActInSignCollectionsCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Есть списание {SelectedRadiostation.DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (var item in SignCollection)
                if (item == SelectedRadiostation.NumberAct)
                    return;

            SignCollection.Add(SelectedRadiostation.NumberAct);

            string temp = string.Empty;

            for (int i = 0; i < SignCollection.Count; i++)
            {
                for (int y = 0; y < SignCollection.Count - 1; y++)
                {
                    if (Convert.ToInt32(SignCollection[y].
                        Substring(SignCollection[y].IndexOf("/") + 1))
                    > Convert.ToInt32(SignCollection[y + 1].
                    Substring(SignCollection[y + 1].IndexOf("/") + 1)))
                    {
                        temp = SignCollection[y + 1];
                        SignCollection[y + 1] = SignCollection[y];
                        SignCollection[y] = temp;
                    }
                }
            }

            string addRegistry = String.Empty;
            foreach (var item in SignCollection)
                addRegistry += item.ToString() + ";";

            _getSetRegistryServiceTelecomSetting.SetRegistryNumberActForSignCollections
                (addRegistry);

            if (SignCollection.Count > 0)
                SelectedIndexSignCollection = SignCollection.Count - 1;
        }

        #endregion

        #region GetNumberActForSignCollections

        private void GetNumberActForSignCollections()
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            string addRegistry =
             _getSetRegistryServiceTelecomSetting.
             GetRegistryNumberActForSignCollections();

            if (String.IsNullOrWhiteSpace(addRegistry))
                return;

            string[] split = addRegistry.Split(new Char[] { ';' });

            foreach (string item in split)
                if (!String.IsNullOrWhiteSpace(item))
                    SignCollection.Add(item);

            string temp = string.Empty;

            for (int i = 0; i < SignCollection.Count; i++)
            {
                for (int y = 0; y < SignCollection.Count - 1; y++)
                {
                    if (Convert.ToInt32(SignCollection[y].
                        Substring(SignCollection[y].IndexOf("/") + 1))
                    > Convert.ToInt32(SignCollection[y + 1].
                    Substring(SignCollection[y + 1].IndexOf("/") + 1)))
                    {
                        temp = SignCollection[y + 1];
                        SignCollection[y + 1] = SignCollection[y];
                        SignCollection[y] = temp;
                    }
                }
            }

            if (SignCollection.Count > 0)
                SelectedIndexSignCollection = SignCollection.Count - 2;
        }

        #endregion

        #region RemoveFromSignCollections

        private void ExecuteRemoveFromSignCollectionsCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (SignCollection.Count == 0) return;

            if (SignCollection.Count > 0)
            {
                SignCollection.Remove(Sign);
                SelectedIndexSignCollection = SignCollection.Count - 1;
            }

            string addRegistry = String.Empty;
            foreach (var item in SignCollection)
                addRegistry += item.ToString() + ";";

            _getSetRegistryServiceTelecomSetting.SetRegistryNumberActForSignCollections
                (addRegistry);
        }

        #endregion

        #region SearchBySingNumberActInRadiostationsForDocumentsCollection

        private void ExecuteSearchBySingNumberActInRadiostationsForDocumentsCollectionCommand(object obj)
        {
            if (UserModelStatic.POST == "Дирекция связи")
                return;
            if (CHECK_HOW_MUCH)
                return;
            if (String.IsNullOrWhiteSpace(City))
                return;
            if (SignCollection.Count < 1)
                return;

            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();
            foreach (var item in ReserveRadiostationsForDocumentsCollection)
                RadiostationsForDocumentsCollection.Add(item);

            for (int i = 0; i < RadiostationsForDocumentsCollection.Count;)
            {
                if (RadiostationsForDocumentsCollection[i].
                    NumberAct != Sign)
                    RadiostationsForDocumentsCollection.
                        Remove(RadiostationsForDocumentsCollection[i]);
                else i++;
            }
            Counters();
        }


        #endregion

        #endregion
    }
}
