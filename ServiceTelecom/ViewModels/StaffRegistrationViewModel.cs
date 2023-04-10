using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels
{
    internal class StaffRegistrationViewModel : ViewModelBase
    {
        private UserRepository userRepository;
        public ObservableCollection<StaffRegistrationsDataBaseModel> StaffRegistrations { get; set; }

        private StaffRegistrationsDataBaseModel _staffRegistration;

        public StaffRegistrationsDataBaseModel SelectedStaffRegistration
        {
            get => _staffRegistration;
            set
            {
                _staffRegistration = value;
                OnPropertyChanged(nameof(SelectedStaffRegistration));
                //if (_user != null)
                //{
                //    Id = _user.IdBase;
                //    Login = _user.LoginBase;
                //    Password = _user.PasswordBase;
                //    Post = _user.PostBase;
                //}
            }
        }
        public StaffRegistrationViewModel()
        {
            userRepository = new UserRepository();
            StaffRegistrations = new ObservableCollection<StaffRegistrationsDataBaseModel>();
            StaffRegistrations = userRepository.GetStaffRegistrationDataBase(StaffRegistrations);

        }
    }
}
