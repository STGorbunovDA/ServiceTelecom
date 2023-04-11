using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;

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
        public int Id { get => _id; set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string SectionForeman { get => _sectionForeman; set { _sectionForeman = value; OnPropertyChanged(nameof(SectionForeman)); } }
        public string Engineer { get => _engineer; set { _engineer = value; OnPropertyChanged(nameof(Engineer)); } }
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }
        public string Curator { get => _curator; set { _curator = value; OnPropertyChanged(nameof(Curator)); } }
        public string RadioCommunicationDirectorate { get => _radioCommunicationDirectorate; set { _radioCommunicationDirectorate = value; OnPropertyChanged(nameof(RadioCommunicationDirectorate)); } }

        private StaffRegistrationRepository staffRegistrationRepository;
        
        public ObservableCollection<StaffRegistrationsDataBaseModel> StaffRegistrations { get; set; } //Получаем Бригады
        public ObservableCollection<string> SectionForemanCollection { get; set; } // получаем начальников для Combobox
        public ObservableCollection<string> EngineerCollection { get; set; } // получаем инженеров для Combobox
        public ObservableCollection<string> CuratorCollection { get; set; } // получаем кураторов для Combobox
        public ObservableCollection<string> RadioCommunicationDirectorateCollection { get; set; } // получаем представителей дирекции связи для Combobox

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
                    //Login = _user.LoginBase;
                    //Password = _user.PasswordBase;
                    //Post = _user.PostBase;
                }
            }
        }
        public StaffRegistrationViewModel()
        {
            staffRegistrationRepository = new StaffRegistrationRepository();
            SectionForemanCollection = new ObservableCollection<string>();
            EngineerCollection = new ObservableCollection<string>();
            CuratorCollection= new ObservableCollection<string>();
            RadioCommunicationDirectorateCollection = new ObservableCollection<string>();
            StaffRegistrations = new ObservableCollection<StaffRegistrationsDataBaseModel>();
            StaffRegistrations = staffRegistrationRepository.GetStaffRegistrationDataBase(StaffRegistrations);
            GetStaffRegistrationsForCombobox();
        }
        /// <summary>
        /// Получаем данные в Combobox из коллекции StaffRegistrations
        /// </summary>
        private void GetStaffRegistrationsForCombobox()
        {
            foreach (var item in StaffRegistrations)
            {
                SectionForemanCollection.Add(item.SectionForemanBase);
                EngineerCollection.Add(item.EngineerBase);
                CuratorCollection.Add(item.CuratorBase);
                RadioCommunicationDirectorateCollection.Add(item.RadioCommunicationDirectorateBase);
            }
        }
    }
}
