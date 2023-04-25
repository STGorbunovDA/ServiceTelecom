using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class ReportCardViewModel : ViewModelBase
    {
        private ReportCardRepository reportCardRepository;
        private ReportCardsDataBaseModel _reportCard;
        public ObservableCollection<ReportCardsDataBaseModel> ReportCards { get; set; }
        public ObservableCollection<string> DateTimeInputCollections { get; set; }
        public ObservableCollection<string> Users { get; set; }

        private string _user;
        private string _dateTimeInput;

        public string User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public string DateTimeInput { get => _dateTimeInput; set { _dateTimeInput = value; OnPropertyChanged(nameof(DateTimeInput)); } }

        public ReportCardsDataBaseModel SelectedReportCardViewModel
        {
            get => _reportCard;
            set
            {
                _reportCard = value;
                OnPropertyChanged(nameof(SelectedReportCardViewModel));
                if (_reportCard != null)
                {
                    User = _reportCard.User;
                    DateTimeInput = _reportCard.DateTimeInput.Remove(_reportCard.DateTimeInput.IndexOf(" "));
                }
            }
        }

        public ICommand UpdateReportCardsDataBase { get; }
        public ICommand SaveReportCardsDataBase { get; }
        public ICommand DeleteReportCardsDataBase { get; }

        public ReportCardViewModel()
        {
            reportCardRepository = new ReportCardRepository();
            ReportCards = new ObservableCollection<ReportCardsDataBaseModel>();
            DateTimeInputCollections = new ObservableCollection<string>();
            Users = new ObservableCollection<string>();
            GetStaffReportCardsForUpdate();
            UpdateReportCardsDataBase = new ViewModelCommand(ExecuteUpdateReportCardsDataBaseCommand);
            DeleteReportCardsDataBase = new ViewModelCommand(ExecuteDeleteReportCardsDataBaseCommand);
        }





        #region DeleteReportCardsDataBase

        private void ExecuteDeleteReportCardsDataBaseCommand(object obj)
        {
            GetStaffReportCardsForUpdate();
        }

        internal void GetAllSelectRowsReportCardsAndDeleteId(DataGrid datagrid)
        {
            if (datagrid.SelectedItems.Count > 0)
                foreach (ReportCardsDataBaseModel _reportCard in datagrid.SelectedItems)
                    reportCardRepository.DeleteReportCardsDataBase(_reportCard.IdReportCards);
        }

        #endregion

        #region UpdateReportCardsDataBase 

        private void ExecuteUpdateReportCardsDataBaseCommand(object obj)
        {
            GetStaffReportCardsForUpdate();
        }

        #endregion

        /// <summary> Получить всё из БД </summary>
        private void GetStaffReportCardsForUpdate()
        {
            if (ReportCards.Count != 0 || DateTimeInputCollections.Count != 0 || Users.Count != 0)
            {
                ReportCards.Clear();
                DateTimeInputCollections.Clear();
                Users.Clear();
            }

            ReportCards = reportCardRepository.GetReportCardsDataBase(ReportCards);
            DateTimeInputCollections = reportCardRepository.GetDateTimeInputCollectionsDataBase(DateTimeInputCollections);
            Users = reportCardRepository.GetAllUsersReportCardsDataBase(Users);
        }
    }
}
