using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Input;
using DataGrid = System.Windows.Controls.DataGrid;

namespace ServiceTelecom.ViewModels
{
    internal class StaffRegistrationViewModel : ViewModelBase
    {
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

        private UserRepository userRepository;
        private StaffRegistrationRepository staffRegistrationRepository;

        public ObservableCollection<UserDataBaseModel> Users { get; set; }
        public ObservableCollection<StaffRegistrationsDataBaseModel> StaffRegistrations { get; set; } //Получаем Бригады
        public ObservableCollection<string> RoadCollections { get; } 
        public ObservableCollection<string> SectionForemanCollection { get; set; } // получаем начальников для Combobox
        public ObservableCollection<string> EngineerCollection { get; set; } // получаем инженеров для Combobox
        public ObservableCollection<string> CuratorCollection { get; set; } // получаем кураторов для Combobox
        public ObservableCollection<string> RadioCommunicationDirectorateCollection { get; set; } // получаем представителей дирекции связи для Combobox

        public ICommand AddStaffRegistrationDataBase { get; }
        public ICommand ChangeStaffRegistrationDataBase { get; }
        public ICommand DeleteStaffRegistrationDataBase { get; }
        public ICommand UpdateStaffRegistrationDataBase { get; }

        private StaffRegistrationsDataBaseModel _staffRegistration;

        public StaffRegistrationsDataBaseModel SelectedStaffRegistration
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
            StaffRegistrations = new ObservableCollection<StaffRegistrationsDataBaseModel>();

            RoadCollections = staffRegistrationRepository.GetRoadDataBase(RoadCollections);
            GetStaffRegistrationsForUpdate();
            AddStaffRegistrationDataBase = new ViewModelCommand(ExecuteAddStaffRegistrationDataBaseCommand);
            ChangeStaffRegistrationDataBase = new ViewModelCommand(ExecuteChangeStaffRegistrationDataBaseCommand);
            DeleteStaffRegistrationDataBase = new ViewModelCommand(ExecuteDeleteStaffRegistrationDataBaseCommand);
            UpdateStaffRegistrationDataBase = new ViewModelCommand(ExecuteUpdateStaffRegistrationDataBaseCommand);
        }

        #region UpdateStaffRegistrationDataBase

        private void ExecuteUpdateStaffRegistrationDataBaseCommand(object obj)
        {
            GetStaffRegistrationsForUpdate();
        }

        #endregion

        #region DeleteStaffRegistrationDataBase

        private void ExecuteDeleteStaffRegistrationDataBaseCommand(object obj)
        {
            //staffRegistrationRepository.DeleteStaffRegistrationsDataBase(Id);
            GetStaffRegistrationsForUpdate();
        }

        internal void GetAllSelectRowsStaffRegistrationsAndDeleteId(DataGrid datagrid)
        {
            if (datagrid.SelectedItems.Count > 0)
                foreach (StaffRegistrationsDataBaseModel _staffRegistration in datagrid.SelectedItems)
                    staffRegistrationRepository.DeleteStaffRegistrationsDataBase(_staffRegistration.IdStaffRegistrationBase);
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

        /// <summary>
        /// Проверка ввода значений пользователя
        /// </summary>
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

        /// <summary>
        /// Получаем данные о регистрации персонала для Обновления
        /// </summary>
        private void GetStaffRegistrationsForUpdate()
        {
            if (StaffRegistrations.Count != 0|| Users.Count != 0 || SectionForemanCollection.Count != 0 
                || EngineerCollection.Count != 0 || CuratorCollection.Count != 0 
                || RadioCommunicationDirectorateCollection.Count != 0)
            {
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
        }
    }
}
