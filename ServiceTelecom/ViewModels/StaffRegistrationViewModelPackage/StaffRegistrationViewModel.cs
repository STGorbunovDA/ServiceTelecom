using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.View;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using DataGrid = System.Windows.Controls.DataGrid;

namespace ServiceTelecom.ViewModels
{
    internal class StaffRegistrationViewModel : ViewModelBase
    {
        private UserRepository userRepository;
        private StaffRegistrationRepository staffRegistrationRepository;
        private StaffRegistrationDataBaseModel _staffRegistration;
        private RoadDataBaseRepository _roadDataBase;
        ReportCardView reportCard = null;

        public ObservableCollection<UserDataBaseModel> Users { get; set; }
        public ObservableCollection<StaffRegistrationDataBaseModel> StaffRegistrations { get; set; } //Получаем Бригады
        public ObservableCollection<string> RoadCollections { get; }
        public ObservableCollection<string> SectionForemanCollection { get; set; } // получаем начальников для Combobox
        public ObservableCollection<string> EngineerCollection { get; set; } // получаем инженеров для Combobox
        public ObservableCollection<string> CuratorCollection { get; set; } // получаем кураторов для Combobox
        public ObservableCollection<string> RadioCommunicationDirectorateCollection { get; set; } // получаем представителей дирекции связи для Combobox


        private int _theIndexSectionForemanCollection;
        public int TheIndexSectionForemanCollection { get => _theIndexSectionForemanCollection; set { _theIndexSectionForemanCollection = value; OnPropertyChanged(nameof(TheIndexSectionForemanCollection)); } }

        private int _theIndexEngineerCollection;
        public int TheIndexEngineerCollection { get => _theIndexEngineerCollection; set { _theIndexEngineerCollection = value; OnPropertyChanged(nameof(TheIndexEngineerCollection)); } }

        private int _theIndexCuratorCollection;
        public int TheIndexCuratorCollection { get => _theIndexCuratorCollection; set { _theIndexCuratorCollection = value; OnPropertyChanged(nameof(TheIndexCuratorCollection)); } }

        private int _theIndexRadioCommunicationDirectorateCollection;
        public int TheIndexRadioCommunicationDirectorateCollection { get => _theIndexRadioCommunicationDirectorateCollection; set { _theIndexRadioCommunicationDirectorateCollection = value; OnPropertyChanged(nameof(TheIndexRadioCommunicationDirectorateCollection)); } }

        private int _id;
        private string _sectionForeman;
        private string _engineer;
        private string _road;
        private string _curator;
        private string _radioCommunicationDirectorate;
        private string _attorney;
        private string _numberPrintDocument;
        private string _message;
        public int Id { get => _id; set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string SectionForeman { get => _sectionForeman; set { _sectionForeman = value; OnPropertyChanged(nameof(SectionForeman)); } }
        public string Engineer { get => _engineer; set { _engineer = value; OnPropertyChanged(nameof(Engineer)); } }
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }
        public string Curator { get => _curator; set { _curator = value; OnPropertyChanged(nameof(Curator)); } }
        public string RadioCommunicationDirectorate { get => _radioCommunicationDirectorate; set { _radioCommunicationDirectorate = value; OnPropertyChanged(nameof(RadioCommunicationDirectorate)); } }
        public string Attorney { get => _attorney; set { _attorney = value; OnPropertyChanged(nameof(Attorney)); } }
        public string NumberPrintDocument { get => _numberPrintDocument; set { _numberPrintDocument = value; OnPropertyChanged(nameof(NumberPrintDocument)); } }
        public string Message { get => _message; set { _message = value; OnPropertyChanged(nameof(Message)); } }

        public ICommand AddStaffRegistrationDataBase { get; }
        public ICommand ChangeStaffRegistrationDataBase { get; }
        public ICommand DeleteStaffRegistrationDataBase { get; }
        public ICommand UpdateStaffRegistrationDataBase { get; }
        public ICommand ReportCard { get; }

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
                    RadioCommunicationDirectorate = _staffRegistration.RadioCommunicationDirectorateBase;
                    Attorney = _staffRegistration.AttorneyBase;
                    NumberPrintDocument = _staffRegistration.NumberPrintDocumentBase;
                }
            }
        }

        private IList _selectedModels = new ArrayList();
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
            RoadCollections = new ObservableCollection<string>();
            SectionForemanCollection = new ObservableCollection<string>();
            EngineerCollection = new ObservableCollection<string>();
            CuratorCollection = new ObservableCollection<string>();
            RadioCommunicationDirectorateCollection = new ObservableCollection<string>();
            StaffRegistrations = new ObservableCollection<StaffRegistrationDataBaseModel>();
            _roadDataBase = new RoadDataBaseRepository();
            RoadCollections = _roadDataBase.GetRoadDataBase(RoadCollections);
            GetStaffRegistrationsForUpdate();
            AddStaffRegistrationDataBase = new ViewModelCommand(ExecuteAddStaffRegistrationDataBaseCommand);
            ChangeStaffRegistrationDataBase = new ViewModelCommand(ExecuteChangeStaffRegistrationDataBaseCommand);
            DeleteStaffRegistrationDataBase = new ViewModelCommand(ExecuteDeleteStaffRegistrationDataBaseCommand);
            UpdateStaffRegistrationDataBase = new ViewModelCommand(ExecuteUpdateStaffRegistrationDataBaseCommand);
            ReportCard = new ViewModelCommand(ExecuteReportCardDataBaseCommand);
        }

        #region открываем табель сотрудников

        private void ExecuteReportCardDataBaseCommand(object obj)
        {
            if (reportCard == null)
            {
                reportCard = new ReportCardView();
                reportCard.Closed += (sender, args) => reportCard = null;
                reportCard.Show();
            }
        }

        #endregion

        #region UpdateStaffRegistrationDataBase

        private void ExecuteUpdateStaffRegistrationDataBaseCommand(object obj)
        {
            GetStaffRegistrationsForUpdate();
        }

        #endregion

        #region DeleteStaffRegistrationDataBase

        private void ExecuteDeleteStaffRegistrationDataBaseCommand(object obj)
        {
            if (StaffRegistrationsMulipleSelectedDataGrid == null || 
                StaffRegistrationsMulipleSelectedDataGrid.Count == 0)
                return;
            foreach (StaffRegistrationDataBaseModel staffRegistrations in StaffRegistrationsMulipleSelectedDataGrid)
                staffRegistrationRepository.DeleteStaffRegistrationsDataBase(staffRegistrations.IdStaffRegistrationBase);
            GetStaffRegistrationsForUpdate();
        }
        #endregion

        #region ChangeStaffRegistrationDataBase

        private void ExecuteChangeStaffRegistrationDataBaseCommand(object obj)
        {
            bool flag = false;
            if (CheckingUserInputValues())
                flag = staffRegistrationRepository.ChangeStaffRegistrationDataBase(Id, SectionForeman, Engineer,
                Attorney, Road, NumberPrintDocument, Curator, RadioCommunicationDirectorate);
            if (flag)
            {
                Message = "Successfully Change Registration Brigades Staff";
                GetStaffRegistrationsForUpdate();
            }
            else Message = "Error Change Registration Brigades Staff";
        }

        #endregion

        #region AddStaffRegistrationDataBase

        private void ExecuteAddStaffRegistrationDataBaseCommand(object obj)
        {
            bool flag = false;
            if (CheckingUserInputValues())
                flag = staffRegistrationRepository.AddStaffRegistrationDataBase(SectionForeman, Engineer,
                Attorney, Road, NumberPrintDocument, Curator, RadioCommunicationDirectorate);
            if (flag)
            {
                Message = "Successfully Add Registration Brigades Staff";
                GetStaffRegistrationsForUpdate();
            }
            else Message = "Error Add Registration Brigades Staff";

        }

        #endregion

        /// <summary> Проверка ввода значений пользователя </summary>
        private bool CheckingUserInputValues()
        {
            if (string.IsNullOrWhiteSpace(SectionForeman) || string.IsNullOrWhiteSpace(Engineer) ||
                string.IsNullOrWhiteSpace(Curator) || string.IsNullOrWhiteSpace(RadioCommunicationDirectorate)
                || string.IsNullOrWhiteSpace(Attorney) || string.IsNullOrWhiteSpace(NumberPrintDocument))
                return false;
            if (!Regex.IsMatch(Attorney, @"^[0-9]{1,}[\/][0-9]{1,}[\s][о][т][\s][0-9]{2,2}[\.][0-9]{2,2}[\.][2][0][0-9]{2,2}[\s][г][о][д][а]$"))
            {
                MessageBox.Show("Введите корректно \"Доверенность\"\n P.s. Пример: 53/53 от 10.01.2023 года", "Отмена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Attorney = "53/53 от 10.01.2023 года";
                return false;
            }
            if (!Regex.IsMatch(NumberPrintDocument, @"^[0-9]{2,}$"))
            {
                MessageBox.Show("Введите корректно \"№ печати\"\n P.s. Пример: 53", "Отмена",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                NumberPrintDocument = "53";
                return false;
            }
            return true;
        }

        /// <summary> Получаем данные о регистрации персонала для Обновления </summary>
        private void GetStaffRegistrationsForUpdate()
        {
            if (StaffRegistrations.Count != 0 || Users.Count != 0 || SectionForemanCollection.Count != 0 
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
            
            StaffRegistrations = staffRegistrationRepository.GetStaffRegistrationsDataBase(StaffRegistrations);
            Users = userRepository.GetAllUsersDataBase(Users);
            foreach (var item in Users)
            {
                if (item == null) return;
                if (item.PostBase == "Начальник участка") SectionForemanCollection.Add(item.LoginBase);
                else if (item.PostBase == "Инженер") EngineerCollection.Add(item.LoginBase);
                else if (item.PostBase == "Куратор") CuratorCollection.Add(item.LoginBase);
                else if (item.PostBase == "Дирекция связи") RadioCommunicationDirectorateCollection.Add(item.LoginBase);
            }
            if (SectionForemanCollection.Count == 0) MessageBox.Show("Зарегистрируйте Начальника участка");
            if (EngineerCollection.Count == 0) MessageBox.Show("Зарегистрируйте Инженера");
            if (CuratorCollection.Count == 0) MessageBox.Show("Зарегистрируйте Куратора");
            if (RadioCommunicationDirectorateCollection.Count == 0) MessageBox.Show("Зарегистрируйте представителя Дирекции связи");

            TheIndexSectionForemanCollection = 0;
            TheIndexEngineerCollection = 0;
            TheIndexCuratorCollection = 0;
            TheIndexRadioCommunicationDirectorateCollection = 0;
        }
    }
}
