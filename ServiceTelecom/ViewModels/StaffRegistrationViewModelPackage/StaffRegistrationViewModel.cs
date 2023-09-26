using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Interfaces;
using ServiceTelecom.View;
using ServiceTelecom.View.Base;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class StaffRegistrationViewModel : ViewModelBase
    {
        IUserRepository userRepository;
        IStaffRegistrationRepository staffRegistrationRepository;
        StaffRegistrationDataBaseModel _staffRegistration;
        RoadDataBaseRepository _roadDataBase;
        ReportCardView reportCard = null;
        RoadView roadView = null;
        ObservableCollection<UserDataBaseModel> Users { get; set; }
        public ObservableCollection<StaffRegistrationDataBaseModel> 
            StaffRegistrations { get; set; } 

        public ObservableCollection<RoadModel> RoadCollections { get; set; }
        public ObservableCollection<string> SectionForemanCollection { get; set; } 
        public ObservableCollection<string> EngineerCollection { get; set; } 
        public ObservableCollection<string> CuratorCollection { get; set; } 
        public ObservableCollection<string> 
            RadioCommunicationDirectorateCollection { get; set; }

        Visibility _staffRegistrationWindowVisibility;
        public Visibility StaffRegistrationWindowVisibility
        {
            get { return _staffRegistrationWindowVisibility; }
            set
            {
                _staffRegistrationWindowVisibility = value;
                OnPropertyChanged(nameof(StaffRegistrationWindowVisibility));
            }
        }


        int _theIndexSectionForemanCollection;
        public int TheIndexSectionForemanCollection { 
            get => _theIndexSectionForemanCollection; 
            set { _theIndexSectionForemanCollection = value; 
                OnPropertyChanged(nameof(TheIndexSectionForemanCollection)); } 
        }

        int _theIndexEngineerCollection;
        public int TheIndexEngineerCollection {
            get => _theIndexEngineerCollection; 
            set { _theIndexEngineerCollection = value; 
                OnPropertyChanged(nameof(TheIndexEngineerCollection)); } 
        }

        int _theIndexCuratorCollection;
        public int TheIndexCuratorCollection { 
            get => _theIndexCuratorCollection; 
            set { _theIndexCuratorCollection = value; 
                OnPropertyChanged(nameof(TheIndexCuratorCollection)); } 
        }

        int _theIndexRadioCommunicationDirectorateCollection;
        public int TheIndexRadioCommunicationDirectorateCollection { 
            get => _theIndexRadioCommunicationDirectorateCollection; 
            set { _theIndexRadioCommunicationDirectorateCollection = value; 
                OnPropertyChanged(nameof(TheIndexRadioCommunicationDirectorateCollection)); } 
        }

        int _theIndexRoadCollection;
        public int TheIndexRoadCollection
        {
            get => _theIndexRoadCollection;
            set
            {
                _theIndexRoadCollection = value;
                OnPropertyChanged(nameof(TheIndexRoadCollection));
            }
        }

        #region свойства

        int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        string _sectionForeman;
        public string SectionForeman
        {
            get => _sectionForeman;
            set
            {
                _sectionForeman = value;
                OnPropertyChanged(nameof(SectionForeman));
            }
        }
        string _engineer;
        public string Engineer
        {
            get => _engineer;
            set
            {
                _engineer = value;
                OnPropertyChanged(nameof(Engineer));
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

        string _curator;
        public string Curator
        {
            get => _curator;
            set
            {
                _curator = value;
                OnPropertyChanged(nameof(Curator));
            }
        }

        string _radioCommunicationDirectorate;
        public string RadioCommunicationDirectorate
        {
            get => _radioCommunicationDirectorate;
            set
            {
                _radioCommunicationDirectorate = value;
                OnPropertyChanged(nameof(RadioCommunicationDirectorate));
            }
        }

        string _attorney;
        public string Attorney
        {
            get => _attorney;
            set
            {
                _attorney = value;
                OnPropertyChanged(nameof(Attorney));
            }
        }

        string _numberPrintDocument;
        public string NumberPrintDocument
        {
            get => _numberPrintDocument;
            set
            {
                _numberPrintDocument = value;
                OnPropertyChanged(nameof(NumberPrintDocument));
            }
        }

        string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        #endregion

        public ICommand AddStaffRegistrationDataBase { get; }
        public ICommand ChangeStaffRegistrationDataBase { get; }
        public ICommand DeleteStaffRegistrationDataBase { get; }
        public ICommand UpdateStaffRegistrationDataBase { get; }
        public ICommand ReportCard { get; }
        public ICommand AddRoadDataBase { get; }
        public ICommand LoadingFileForFullDB { get; }
        public StaffRegistrationDataBaseModel SelectedStaffRegistration
        {
            get => _staffRegistration;
            set
            {
                _staffRegistration = value;
                OnPropertyChanged(nameof(SelectedStaffRegistration));
                if (_staffRegistration != null)
                {
                    Id = _staffRegistration.IdStaffRegistrationBase;
                    SectionForeman = _staffRegistration.SectionForemanBase;
                    Engineer = _staffRegistration.EngineerBase;
                    Road = _staffRegistration.RoadBase;
                    Curator = _staffRegistration.CuratorBase;
                    RadioCommunicationDirectorate = 
                        _staffRegistration.RadioCommunicationDirectorateBase;
                    Attorney = _staffRegistration.AttorneyBase;
                    NumberPrintDocument = _staffRegistration.NumberPrintDocumentBase;
                }
            }
        }

        IList _selectedModels = new ArrayList();
        public IList StaffRegistrationsMulipleSelectedDataGrid
        {
            get { return _selectedModels; }
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(StaffRegistrationsMulipleSelectedDataGrid));
            }
        }

        public StaffRegistrationViewModel()
        {
            userRepository = new UserRepository();
            Users = new ObservableCollection<UserDataBaseModel>();
            staffRegistrationRepository = new StaffRegistrationRepository();
            RoadCollections = new ObservableCollection<RoadModel>();
            SectionForemanCollection = new ObservableCollection<string>();
            EngineerCollection = new ObservableCollection<string>();
            CuratorCollection = new ObservableCollection<string>();
            RadioCommunicationDirectorateCollection = new ObservableCollection<string>();
            StaffRegistrations = new ObservableCollection<StaffRegistrationDataBaseModel>();
            _roadDataBase = new RoadDataBaseRepository();
            GetRoadDataBase();
            GetStaffRegistrationsForUpdate();
            AddStaffRegistrationDataBase = 
                new ViewModelCommand(ExecuteAddStaffRegistrationDataBaseCommand);
            ChangeStaffRegistrationDataBase = 
                new ViewModelCommand(ExecuteChangeStaffRegistrationDataBaseCommand);
            DeleteStaffRegistrationDataBase = 
                new ViewModelCommand(ExecuteDeleteStaffRegistrationDataBaseCommand);
            UpdateStaffRegistrationDataBase = 
                new ViewModelCommand(ExecuteUpdateStaffRegistrationDataBaseCommand);
            ReportCard = new ViewModelCommand(ExecuteReportCardDataBaseCommand);
            AddRoadDataBase = new ViewModelCommand(ExecuteAddRoadDataBaseCommand);
            LoadingFileForFullDB = new ViewModelCommand(ExecuteLoadingFileForFullDBCommand);
        }


        #region LoadingFileForFullDB

        void ExecuteLoadingFileForFullDBCommand(object obj)
        {
            OpenCSV.GetInstance.OpenCSVFile();
        }

        #endregion

        #region AddRoadDataBase

        void ExecuteAddRoadDataBaseCommand(object obj)
        {
            if (roadView == null)
            {
                roadView = new RoadView();
                roadView.Closed += (sender, args) =>
                roadView = null;
                roadView.Closed += (sender, args) =>
                GetRoadDataBase();
                roadView.Closed += (sender, args) => StaffRegistrationWindowVisibility = Visibility.Visible;
                StaffRegistrationWindowVisibility = Visibility.Collapsed;
                roadView.Show();
            }
        }

        #endregion

        #region GetRoadDataBase

        async void GetRoadDataBase()
        {
            TheIndexRoadCollection = -1;
            if (RoadCollections.Count != 0)
                RoadCollections.Clear();
                RoadCollections = await _roadDataBase.GetRoadDataBase(RoadCollections);
            TheIndexRoadCollection = RoadCollections.Count - 1;
        }

        #endregion

        #region открываем табель сотрудников

        void ExecuteReportCardDataBaseCommand(object obj)
        {
            if (reportCard == null)
            {
                reportCard = new ReportCardView();
                reportCard.Closed += (sender, args) => reportCard = null;
                reportCard.Closed += (sender, args) => StaffRegistrationWindowVisibility = Visibility.Visible;
                StaffRegistrationWindowVisibility = Visibility.Collapsed;
                reportCard.Show();
            }
        }

        #endregion

        #region UpdateStaffRegistrationDataBase

        void ExecuteUpdateStaffRegistrationDataBaseCommand(object obj)
        {
            GetStaffRegistrationsForUpdate();
        }

        #endregion

        #region DeleteStaffRegistrationDataBase

        void ExecuteDeleteStaffRegistrationDataBaseCommand(object obj)
        {
            if (StaffRegistrationsMulipleSelectedDataGrid == null || 
                StaffRegistrationsMulipleSelectedDataGrid.Count == 0)
                return;
            foreach (StaffRegistrationDataBaseModel staffRegistrations 
                in StaffRegistrationsMulipleSelectedDataGrid)
                staffRegistrationRepository.DeleteStaffRegistrationsDataBase(
                    staffRegistrations.IdStaffRegistrationBase);
            GetStaffRegistrationsForUpdate();
        }
        #endregion

        #region ChangeStaffRegistrationDataBase

        void ExecuteChangeStaffRegistrationDataBaseCommand(object obj)
        {
            bool flag = false;
            if (CheckingUserInputValues())
                flag = staffRegistrationRepository.ChangeStaffRegistrationDataBase(
                    Id, SectionForeman, Engineer, Attorney, Road, 
                    NumberPrintDocument, Curator, RadioCommunicationDirectorate);
            if (flag)
            {
                Message = "Successfully Change Registration Brigades Staff";
                GetStaffRegistrationsForUpdate();
            }
            else Message = "Error Change Registration Brigades Staff";
        }

        #endregion

        #region AddStaffRegistrationDataBase

        void ExecuteAddStaffRegistrationDataBaseCommand(object obj)
        {
            bool flag = false;
            if (CheckingUserInputValues())
                flag = staffRegistrationRepository.AddStaffRegistrationDataBase(
                    SectionForeman, Engineer, Attorney, Road, NumberPrintDocument, 
                    Curator, RadioCommunicationDirectorate);
            if (flag)
            {
                Message = "Successfully Add Registration Brigades Staff";
                GetStaffRegistrationsForUpdate();
            }
            else Message = "Error Add Registration Brigades Staff";
        }

        #endregion

        #region Проверка ввода значений пользователя

        bool CheckingUserInputValues()
        {
            if (string.IsNullOrWhiteSpace(SectionForeman) 
                || string.IsNullOrWhiteSpace(Engineer) 
                || string.IsNullOrWhiteSpace(Curator) 
                || string.IsNullOrWhiteSpace(RadioCommunicationDirectorate)
                || string.IsNullOrWhiteSpace(Attorney) 
                || string.IsNullOrWhiteSpace(NumberPrintDocument))
                return false;
            if (!Regex.IsMatch(Attorney, 
                @"^[0-9]{1,}[\/][0-9]{1,}[\s][о][т][\s][0-9]{2,2}[\.][0-9]{2,2}[\.][2][0][0-9]{2,2}[\s][г][о][д][а]$"))
            {
                MessageBox.Show("Введите корректно \"Доверенность\"\n" +
                    "P.s. Пример: 53/53 от 10.01.2023 года", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Attorney = "53/53 от 10.01.2023 года";
                return false;
            }
            if (!Regex.IsMatch(NumberPrintDocument, @"^[0-9]{2,}$"))
            {
                MessageBox.Show("Введите корректно \"№ печати\"\n" +
                    "P.s. Пример: 53", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                NumberPrintDocument = "53";
                return false;
            }
            return true;
        }

        #endregion

        #region Получаем данные о регистрации персонала для Обновления

        void GetStaffRegistrationsForUpdate()
        {
            if (StaffRegistrations.Count != 0 || Users.Count != 0 
                || SectionForemanCollection.Count != 0 
                || EngineerCollection.Count != 0 || CuratorCollection.Count != 0 
                || RadioCommunicationDirectorateCollection.Count != 0)
            {
                TheIndexSectionForemanCollection = -1;
                TheIndexEngineerCollection = -1;
                TheIndexCuratorCollection = -1;
                TheIndexRadioCommunicationDirectorateCollection = -1;

                StaffRegistrations.Clear();
                Users.Clear();
                SectionForemanCollection.Clear();
                EngineerCollection.Clear();
                CuratorCollection.Clear();
                RadioCommunicationDirectorateCollection.Clear();
            }
            
            StaffRegistrations = 
                staffRegistrationRepository.GetStaffRegistrationsDataBase(
                    StaffRegistrations);
            Users = userRepository.GetAllUsersDataBase(Users);
            foreach (var item in Users)
            {
                if (item == null) return;
                if (item.PostBase == "Начальник участка") 
                    SectionForemanCollection.Add(item.LoginBase);
                else if (item.PostBase == "Инженер") 
                    EngineerCollection.Add(item.LoginBase);
                else if (item.PostBase == "Куратор") 
                    CuratorCollection.Add(item.LoginBase);
                else if (item.PostBase == "Дирекция связи") 
                    RadioCommunicationDirectorateCollection.Add(item.LoginBase);
            }
            if (SectionForemanCollection.Count == 0) 
                MessageBox.Show("Зарегистрируйте Начальника участка");
            if (EngineerCollection.Count == 0) 
                MessageBox.Show("Зарегистрируйте Инженера");
            if (CuratorCollection.Count == 0) 
                MessageBox.Show("Зарегистрируйте Куратора");
            if (RadioCommunicationDirectorateCollection.Count == 0) 
                MessageBox.Show("Зарегистрируйте представителя Дирекции связи");

            TheIndexSectionForemanCollection = 0;
            TheIndexEngineerCollection = 0;
            TheIndexCuratorCollection = 0;
            TheIndexRadioCommunicationDirectorateCollection = 0;
        }

        #endregion
    }
}
