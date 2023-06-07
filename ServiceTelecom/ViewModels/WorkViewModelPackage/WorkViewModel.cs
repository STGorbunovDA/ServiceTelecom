using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View.WorkViewPackage;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    internal class WorkViewModel : ViewModelBase
    {
        /// <summary> для сохранения индекса выделенной строки </summary>
        private int TEMPORARY_INDEX_DATAGRID = 0;

        /// <summary> для сохранения индекса коллекции дорог </summary>
        private int TEMPORARY_INDEX_ROAD_COLLECTION = 0;

        ///// <summary> Для поиска по коллекции минуя первый раз  </summary>
        private int NUMBER_LIMIT_SEARCH_SERIALNUMBER_RADIOSTANTION_COLLECTION = 0;

        /// <summary> Для получения значения только один раз из реестра  </summary>
        private int NUMBER_LIMIT_LOADING_REGESTRY_CITY = 0;

        /// <summary> Для сохранения рабочего города из реестра  </summary>
        private string CITY_REGISTRY = string.Empty;

        AddRadiostationForDocumentInDataBaseView
            addRadiostationForDocumentInDataBaseView = null;
        ChangeRadiostationForDocumentInDataBaseView
            changeRadiostationForDocumentInDataBaseView = null;
        AddRepairRadiostationForDocumentInDataBaseView
            addRepairRadiostationForDocumentInDataBaseView = null;
        AddDecommissionNumberActView
            addDecommissionNumberActView = null;
        SelectingSaveView selectingSaveView = null;

        ChangeNumberActView changeNumberActView;

        GetSetRegistryServiceTelecomSetting getSetRegistryServiceTelecomSetting;

        private WorkRepositoryRadiostantion _workRepositoryRadiostantion;
        private WorkRepositoryRadiostantionFull _workRepositoryRadiostantionFull;
        private RoadDataBaseRepository _roadDataBase;
        public ObservableCollection<string> RoadCollections { get; set; }
        public ObservableCollection<string> CityCollections { get; set; }

        public ObservableCollection<RadiostationForDocumentsDataBaseModel>
            RadiostationsForDocumentsCollection
        { get; set; }

        private ObservableCollection<RadiostationForDocumentsDataBaseModel>
            ReserveRadiostationsForDocumentsCollection;

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

        #region свойства

        private string _road;
        public string Road
        {
            get => _road;
            set
            {
                _road = value;
                OnPropertyChanged(nameof(Road));
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string _serialNumber;
        public string SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                SearchBySerialNumberInRadiostationsForDocumentsCollection(value);
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        private string _representative;
        public string Representative
        {
            get => _representative;
            set
            {
                _representative = value;
                OnPropertyChanged(nameof(Representative));
            }
        }

        private string _numberIdentification;
        public string NumberIdentification
        {
            get => _numberIdentification;
            set
            {
                _numberIdentification = value;
                OnPropertyChanged(nameof(NumberIdentification));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _post;
        public string Post
        {
            get => _post;
            set
            {
                _post = value;
                OnPropertyChanged(nameof(Post));
            }
        }

        private string _dateOfIssuanceOfTheCertificate;
        public string DateOfIssuanceOfTheCertificate
        {
            get => _dateOfIssuanceOfTheCertificate;
            set
            {
                _dateOfIssuanceOfTheCertificate = value;
                OnPropertyChanged(nameof(DateOfIssuanceOfTheCertificate));
            }
        }

        private string _poligon;
        public string Poligon
        {
            get => _poligon;
            set
            {
                _poligon = value;
                OnPropertyChanged(nameof(Poligon));
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

        private string _location;
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
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

        private string _inventoryNumber;
        public string InventoryNumber
        {
            get => _inventoryNumber;
            set
            {
                _inventoryNumber = value;
                OnPropertyChanged(nameof(InventoryNumber));
            }
        }

        private string _networkNumber;
        public string NetworkNumber
        {
            get => _networkNumber;
            set
            {
                _networkNumber = value;
                OnPropertyChanged(nameof(NetworkNumber));
            }
        }

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

        private string _comment;
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                OnPropertyChanged(nameof(Comment));
            }
        }

        private string _price;
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
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

        private string _numberActRepair;
        public string NumberActRepair
        {
            get => _numberActRepair;
            set
            {
                _numberActRepair = value;
                OnPropertyChanged(nameof(NumberActRepair));
            }
        }

        private string _manipulator;
        public string Manipulator
        {
            get => _manipulator;
            set
            {
                _manipulator = value;
                OnPropertyChanged(nameof(Manipulator));
            }
        }

        private string _antenna;
        public string Antenna
        {
            get => _antenna;
            set
            {
                _antenna = value;
                OnPropertyChanged(nameof(Antenna));
            }
        }

        private string _battery;
        public string Battery
        {
            get => _battery;
            set
            {
                _battery = value;
                OnPropertyChanged(nameof(Battery));
            }
        }

        private string _charger;
        public string Charger
        {
            get => _charger;
            set
            {
                _charger = value;
                OnPropertyChanged(nameof(Charger));
            }
        }

        private string _decommissionNumberAct;
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

        private int _selectedIndexRoadCollection;
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


        private int _selectedIndexCityCollection;
        public int SelectedIndexCityCollection
        {
            get => _selectedIndexCityCollection;
            set
            {
                _selectedIndexCityCollection = value;
                if (value < 0 || CityCollections.Count == 0)
                {
                    if (RadiostationsForDocumentsCollection.Count != 0)
                        RadiostationsForDocumentsCollection.Clear();
                }
                else
                {
                    GetRadiostationsForDocumentsCollection(
                        RoadCollections[TEMPORARY_INDEX_ROAD_COLLECTION].ToString(),
                        CityCollections[value].ToString());

                }

                OnPropertyChanged(nameof(SelectedIndexCityCollection));
            }
        }

        RadiostationForDocumentsDataBaseModel _selectedRadiostationdel;
        public RadiostationForDocumentsDataBaseModel SelectedRadiostation
        {
            get => _selectedRadiostationdel;
            set
            {
                if (value == null)
                    return;
                //SerialNumber = value.SerialNumber;
                _selectedRadiostationdel = value;
                OnPropertyChanged(nameof(SelectedRadiostation));
            }
        }

        private IList _selectedModels = new ArrayList();
        public IList RadiostationsForDocumentsMulipleSelectedDataGrid
        {
            get => _selectedModels;
            set
            {
                _selectedModels = value;
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

        public WorkViewModel()
        {
            _workRepositoryRadiostantion = new WorkRepositoryRadiostantion();
            _workRepositoryRadiostantionFull = new WorkRepositoryRadiostantionFull();
            RadiostationsForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            ReserveRadiostationsForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();
            getSetRegistryServiceTelecomSetting = new GetSetRegistryServiceTelecomSetting();
            RoadCollections = new ObservableCollection<string>();
            CityCollections = new ObservableCollection<string>();
            AddRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddRadiostationForDocumentInDataBaseCommand);
            ChangeRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteChangeRadiostationForDocumentInDataBaseCommand);
            DeleteRadiostationForDocumentInDataBase =
                 new ViewModelCommand(ExecuteDeleteRadiostationForDocumentInDataBaseCommand);
            UpdateRadiostationForDocumentInDataBase =
                 new ViewModelCommand(ExecuteUpdateRadiostationForDocumentInDataBaseCommand);
            SaveCollectionRadiostationsForDocument =
                new ViewModelCommand(ExecuteSaveCollectionRadiostationsForDocumentCommand);
            AddRepairRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddRepairRadiostationForDocumentInDataBaseCommand);
            DeleteRepairRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteDeleteRepairRadiostationForDocumentInDataBaseCommand);
            AddDecommissionNumberActRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand);
            DeleteDecommissionNumberActRadiostationInDB =
                new ViewModelCommand(ExecuteDeleteDecommissionNumberActRadiostationInDBCommand);
            ChangeNumberActAtRadiostationsInDB =
                new ViewModelCommand(ExecuteChangeNumberActAtRadiostationsInDBCommand);
            GetRoad();
        }

        #region ChangeNumberActAtRadiostationsInDB

        private void ExecuteChangeNumberActAtRadiostationsInDBCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
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
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            if (changeNumberActView != null)
                return;

            UserModelStatic.RadiostationsForDocumentsMulipleSelectedDataGrid
                = RadiostationsForDocumentsMulipleSelectedDataGrid;

            changeNumberActView = new ChangeNumberActView(
                SelectedRadiostation.NumberAct);
            changeNumberActView.Closed += (sender, args) => changeNumberActView = null;
            changeNumberActView.Closed += (sender, args) =>
            RadiostationsForDocumentsMulipleSelectedDataGrid = null;
            changeNumberActView.Closed += (sender, args) =>
            GetRadiostationsForDocumentsCollection(Road, City);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            changeNumberActView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            changeNumberActView.Show();
        }

        #endregion

        #region DeleteDecommissionNumberActRadiostationInDB

        private void ExecuteDeleteDecommissionNumberActRadiostationInDBCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;
            if (String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
                return;
            if (MessageBox.Show("Подтверждаете удаление списания?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (_workRepositoryRadiostantionFull.
                DeleteDecommissionNumberActRadiostationInDBRadiostationFull(
                    Road, City, SerialNumber))
            { }
            else
                MessageBox.Show($"Ошибка удаления списания у радиостанции " +
                    $"{SerialNumber} из radiostantionFull(общая база)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            if (_workRepositoryRadiostantion.DeleteDecommissionNumberActRadiostationInDB(
                    Road, City, SerialNumber))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка удаления списания у радиостанции {SerialNumber}",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            GetRadiostationsForDocumentsCollection(Road, City);
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region AddDecommissionNumberActRadiostationForDocumentInDataBase

        private void ExecuteAddDecommissionNumberActRadiostationForDocumentInDBCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Уже есть списание {DecommissionNumberAct}", "Отмена",
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
            GetRadiostationsForDocumentsCollection(Road, City);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            addDecommissionNumberActView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            addDecommissionNumberActView.Show();
        }

        #endregion

        #region DeleteRepairRadiostationForDocumentInDataBase

        private void ExecuteDeleteRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;
            if (String.IsNullOrWhiteSpace(SelectedRadiostation.NumberActRepair))
                return;
            if (MessageBox.Show("Подтверждаете удаление ремонта?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (_workRepositoryRadiostantionFull.
                DeleteRepairRadiostationForDocumentInDBRadiostantionFull(
                    Road, City, SerialNumber))
            { }
            else
                MessageBox.Show($"Ошибка удаления номера акта ремонта радиостанции " +
                    $"{SerialNumber} из radiostantionFull(общая база)",
                    "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);

            if (_workRepositoryRadiostantion.DeleteRepairRadiostationForDocumentInDataBase(
                    Road, City, SerialNumber))
                MessageBox.Show("Успешно", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show($"Ошибка удаления номера акта ремонта радиостанции " +
                    $"{SerialNumber}", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            GetRadiostationsForDocumentsCollection(Road, City);
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region SaveCollectionRadiostationsForDocument

        private void ExecuteSaveCollectionRadiostationsForDocumentCommand(object obj)
        {
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
            GetRadiostationsForDocumentsCollection(Road, City);
            GetRowAfterAddingRadiostantionInDataGrid();
        }

        #endregion

        #region DeleteRadiostationForDocumentInDataBase

        private void ExecuteDeleteRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            if (RadiostationsForDocumentsMulipleSelectedDataGrid == null ||
               RadiostationsForDocumentsMulipleSelectedDataGrid.Count == 0)
                return;
            if (MessageBox.Show("Подтверждаете удаление радиостанции?", "Внимание",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            foreach (RadiostationForDocumentsDataBaseModel
                radiostationForDocumentsDataBaseModel in
                RadiostationsForDocumentsMulipleSelectedDataGrid)
                _workRepositoryRadiostantion.DeleteRadiostationFromDataBase(
                    radiostationForDocumentsDataBaseModel.IdBase);
            GetCityOnTheRoad(RoadCollections.IndexOf(Road));
            GetRadiostationsForDocumentsCollection(Road, City);
            GetRowAfterAddingRadiostantionInDataGrid();
        }

        #endregion

        #region AddRepairRadiostationForDocumentInDataBase

        private void ExecuteAddRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            if (SelectedRadiostation == null)
                return;
            if (!String.IsNullOrWhiteSpace(SelectedRadiostation.DecommissionNumberAct))
            {
                MessageBox.Show(
                    $"Нельзя добавить ремонт на радиостанцию{SerialNumber} " +
                    $"есть списание {DecommissionNumberAct}", "Отмена",
                     MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (addRepairRadiostationForDocumentInDataBaseView != null)
                return;

            UserModelStatic.road = SelectedRadiostation.Road;
            UserModelStatic.model = SelectedRadiostation.Model;
            UserModelStatic.serialNumber = SelectedRadiostation.SerialNumber;

            addRepairRadiostationForDocumentInDataBaseView =
                new AddRepairRadiostationForDocumentInDataBaseView(
                    SelectedRadiostation);

            addRepairRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            addRepairRadiostationForDocumentInDataBaseView = null;
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            addRepairRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRadiostationsForDocumentsCollection(Road, City);
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
            UserModelStatic.road = null;
            UserModelStatic.city = null;
            UserModelStatic.serialNumber = null;
        }

        #endregion

        #region ChangeRadiostationForDocumentInDataBase

        private void ExecuteChangeRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
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
            GetCityOnTheRoad(RoadCollections.IndexOf(Road));
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRadiostationsForDocumentsCollection(Road, CITY_REGISTRY);
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRadiostantionDataGrid;
            changeRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
            GetRowAfterChangeRadiostantionInDataGrid(TEMPORARY_INDEX_DATAGRID);
            changeRadiostationForDocumentInDataBaseView.Show();

        }

        #endregion

        #region AddRadiostationForDocumentInDataBase

        private void ExecuteAddRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (UserModelStatic.Post == "Дирекция связи")
                return;
            if (addRadiostationForDocumentInDataBaseView == null)
            {
                if (SelectedRadiostation == null) addRadiostationForDocumentInDataBaseView =
                    new AddRadiostationForDocumentInDataBaseView();
                else addRadiostationForDocumentInDataBaseView =
                    new AddRadiostationForDocumentInDataBaseView(
                        SelectedRadiostation);

                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                addRadiostationForDocumentInDataBaseView = null;
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                GetCityOnTheRoad(RoadCollections.IndexOf(Road));
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                GetRadiostationsForDocumentsCollection(Road, CITY_REGISTRY);
                addRadiostationForDocumentInDataBaseView.Closed += (sender, args) =>
                GetRowAfterAddingRadiostantionInDataGrid();
                addRadiostationForDocumentInDataBaseView.Show();
            }
        }

        #endregion

        #region GetRoad

        private void GetRoad()
        {
            if (RoadCollections.Count != 0)
                RoadCollections.Clear();
            if (UserModelStatic.StaffRegistrationsDataBaseModelCollection.Count == 0)
            {
                _roadDataBase = new RoadDataBaseRepository();
                RoadCollections = _roadDataBase.GetRoadDataBase(RoadCollections);
            }
            else foreach (var item in UserModelStatic.StaffRegistrationsDataBaseModelCollection)
                    RoadCollections.Add(item.RoadBase);
        }


        #endregion

        #region GetCityOnTheRoad

        private void GetCityOnTheRoad(int index)
        {
            if (index < 0)
                return;
            if (CityCollections.Count != 0)
            {
                SelectedIndexCityCollection = -1;
                CityCollections.Clear();
            }

            CityCollections = _workRepositoryRadiostantion.
                    GetCityAlongRoadForCityCollection(
                    RoadCollections[index].ToString(), CityCollections);
            SelectedIndexCityCollection = 0;
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

        #region GetRadiostationsForDocumentsCollection

        private void GetRadiostationsForDocumentsCollection(string road, string city)
        {
            if (road == null)
                return;
            if (city == null)
                return;
            if (NUMBER_LIMIT_LOADING_REGESTRY_CITY == 0)
            {
                city = getSetRegistryServiceTelecomSetting.GetRegistryCity();
                CITY_REGISTRY = city;
                NUMBER_LIMIT_LOADING_REGESTRY_CITY++;
            }
            if (RadiostationsForDocumentsCollection.Count != 0)
                RadiostationsForDocumentsCollection.Clear();
            RadiostationsForDocumentsCollection =
                _workRepositoryRadiostantion.GetRadiostationsForDocumentsCollection(
                RadiostationsForDocumentsCollection, road, city);
            City = city;

            //if (NUMBER_LIMIT_SEARCH_SERIALNUMBER_RADIOSTANTION_COLLECTION == 0)
            //{
            //    foreach (var item in RadiostationsForDocumentsCollection)
            //        ReserveRadiostationsForDocumentsCollection.Add(item);
            //    NUMBER_LIMIT_SEARCH_SERIALNUMBER_RADIOSTANTION_COLLECTION++;
            //}
            if (ReserveRadiostationsForDocumentsCollection.Count != 0)
                ReserveRadiostationsForDocumentsCollection.Clear();
            foreach (var item in RadiostationsForDocumentsCollection)
                ReserveRadiostationsForDocumentsCollection.Add(item);

        }

        #endregion

        #region SearchBySerialNumberInRadiostationsForDocumentsCollection

        private void SearchBySerialNumberInRadiostationsForDocumentsCollection(string value)
        {

            if (string.IsNullOrWhiteSpace(value))
            {
                if (RadiostationsForDocumentsCollection.Count != 0)
                    RadiostationsForDocumentsCollection.Clear();
                foreach (var item in ReserveRadiostationsForDocumentsCollection)
                    RadiostationsForDocumentsCollection.Add(item);
            }
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

        #endregion

    }
}
