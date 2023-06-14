using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
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

        public string User { get => _user; 
            set { _user = value; 
                OnPropertyChanged(nameof(User)); } }
        public string DateTimeInput { get => _dateTimeInput; 
            set { _dateTimeInput = value; 
                OnPropertyChanged(nameof(DateTimeInput)); } }

        public string SelectedItemCmbUser { get => _user; 
            set { _user = value; 
                OnPropertyChanged(nameof(SelectedItemCmbUser)); } }
        public string SelectedItemDateTimeInput { get => _dateTimeInput; 
            set { _dateTimeInput = value; 
                OnPropertyChanged(nameof(SelectedItemDateTimeInput)); } }


        private int _theIndexUsersCollection;
        public int TheIndexUsersCollection { get => _theIndexUsersCollection; 
            set { _theIndexUsersCollection = value; 
                OnPropertyChanged(nameof(TheIndexUsersCollection)); } }

        private int _theIndexDateTimeInputCollection;
        public int TheIndexDateTimeInputCollection { get => _theIndexDateTimeInputCollection; 
            set { _theIndexDateTimeInputCollection = value; 
                OnPropertyChanged(nameof(TheIndexDateTimeInputCollection)); } }

        public ReportCardsDataBaseModel SelectedReportCardDataBaseMode
        {
            get => _reportCard;
            set
            {
                _reportCard = value;
                OnPropertyChanged(nameof(SelectedReportCardDataBaseMode));
                if (_reportCard != null)
                {
                    User = _reportCard.User;
                    DateTimeInput = _reportCard.DateTimeInput.Remove(
                        _reportCard.DateTimeInput.IndexOf(" "));
                }
            }
        }

        public ICommand UpdateReportCardsDataBase { get; }
        public ICommand DeleteReportCardsDataBase { get; }
        public ICommand SaveReportCards { get; }
        public ICommand GetReportCardsAtCmbUser { get; }
        public ICommand GetReportCardsAtCmbDateTimeInput { get; }

        private IList _selectedModels = new ArrayList();
        public IList ReportCardsMulipleSelectedDataGrid
        {
            get { return _selectedModels; }
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(ReportCardsMulipleSelectedDataGrid));
            }
        }

        public ReportCardViewModel()
        {
            reportCardRepository = new ReportCardRepository();
            ReportCards = new ObservableCollection<ReportCardsDataBaseModel>();
            DateTimeInputCollections = new ObservableCollection<string>();
            Users = new ObservableCollection<string>();
            GetStaffReportCardsForUpdate();
            UpdateReportCardsDataBase = 
                new ViewModelCommand(ExecuteUpdateReportCardsDataBaseCommand);
            DeleteReportCardsDataBase =
                new ViewModelCommand(ExecuteDeleteReportCardsDataBaseCommand);
            SaveReportCards = 
                new ViewModelCommand(ExecuteSaveReportCardsCommand);
            GetReportCardsAtCmbUser = 
                new ViewModelCommand(ExecuteGetReportCardsAtCmbUserCommand);
            GetReportCardsAtCmbDateTimeInput = 
                new ViewModelCommand(ExecuteGetReportCardsAtCmbDateTimeInputCommand);
        }

        #region GetReportCardsAtCmbDateTimeInput

        private void ExecuteGetReportCardsAtCmbDateTimeInputCommand(object obj)
        {
            ReportCards.Clear();
            ReportCards = reportCardRepository.GetReportCardsAtCmbDateTimeInput(
                ReportCards, SelectedItemDateTimeInput);
        }

        #endregion

        #region GetReportCardsAtCmbUser

        private void ExecuteGetReportCardsAtCmbUserCommand(object obj)
        {
            ReportCards.Clear();
            ReportCards = reportCardRepository.GetReportCardsAtCmbUserDataBase(
                ReportCards, SelectedItemCmbUser);
        }

        #endregion

        #region SaveReportCards

        private void ExecuteSaveReportCardsCommand(object obj)
        {
            SaveCSV.GetInstance.SaveReportCard(ReportCards);
        }

        #endregion

        #region DeleteReportCardsDataBase

        private void ExecuteDeleteReportCardsDataBaseCommand(object obj)
        {
            if (ReportCardsMulipleSelectedDataGrid == null || 
                ReportCardsMulipleSelectedDataGrid.Count == 0)
                return;
            foreach (ReportCardsDataBaseModel reportCard in ReportCardsMulipleSelectedDataGrid)
                reportCardRepository.DeleteReportCardsDataBase(reportCard.IdReportCards);
            GetStaffReportCardsForUpdate();
        }


        #endregion

        #region UpdateReportCardsDataBase 

        private void ExecuteUpdateReportCardsDataBaseCommand(object obj)
        {
            GetStaffReportCardsForUpdate();
        }

        #endregion

        #region Получить всё из БД

        private void GetStaffReportCardsForUpdate()
        {
            if (ReportCards.Count != 0 || DateTimeInputCollections.Count != 0 
                || Users.Count != 0)
            {
                TheIndexUsersCollection = -1;
                TheIndexDateTimeInputCollection = -1;
                ReportCards.Clear();
                DateTimeInputCollections.Clear();
                Users.Clear();
            }
            ReportCards = reportCardRepository.GetReportCardsDataBase(ReportCards);
            DateTimeInputCollections = 
                reportCardRepository.GetDateTimeInputCollectionsDataBase(
                    DateTimeInputCollections);

            foreach (var item in ReportCards)
            {
                string searchUser = Users.FirstOrDefault(s => s == item.User);
                if (searchUser == null)
                    Users.Add(item.User.ToString());
            }
            TheIndexUsersCollection = 0;
            TheIndexDateTimeInputCollection = 0;
        }

        #endregion
    }
}
