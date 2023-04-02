using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels
{
    internal class AdminViewModel : ViewModelBase
    {
        private UserRepository userRepository;
        public ObservableCollection<UserDBModel> Users { get; set; } 

        private UserDBModel _user;

        public UserDBModel SelectedUser
        {
            get =>_user;
            set { _user = value; OnPropertyChanged(nameof(SelectedUser)); }
        }

        public AdminViewModel()
        {
            userRepository = new UserRepository();
            Users = new ObservableCollection<UserDBModel>();
            Users = userRepository.getAllUsersDataBase(Users);

        }
    }
}
