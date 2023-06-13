using ServiceTelecom.ViewModels;
using System;

namespace ServiceTelecom.Models
{
    internal class ReportCardsDataBaseModel : ViewModelBase
    {
        private int _idReportCards;
        private string _user;
        private string _dateTimeInput;
        private string _dateTimeExit;
        private TimeSpan _timeCount;
        public int IdReportCards { get => _idReportCards; set { _idReportCards = value; OnPropertyChanged(nameof(IdReportCards)); } }
        public string User { get => _user; set { _user = value; OnPropertyChanged(nameof(User)); } }
        public string DateTimeInput { get => _dateTimeInput; set { _dateTimeInput = value; OnPropertyChanged(nameof(DateTimeInput)); } }
        public string DateTimeExit { get => _dateTimeExit; set { _dateTimeExit = value; OnPropertyChanged(nameof(DateTimeExit)); } }
        public TimeSpan TimeCount { get => _timeCount; set { _timeCount = value; OnPropertyChanged(nameof(TimeCount)); } }

        public ReportCardsDataBaseModel(int idReportCards, string user, 
            DateTime dateTimeInput, DateTime dateTimeExit)
        {
            IdReportCards = idReportCards;
            User = user;
            DateTimeInput = dateTimeInput.ToString("dd.MM.yyyy hh:mm:ss");
            DateTimeExit = dateTimeExit.ToString("dd.MM.yyyy hh:mm:ss");
            TimeCount = dateTimeExit.Subtract(dateTimeInput);
        }
    }
}
