namespace ServiceTelecom.ViewModels.Base
{
    internal class RepairManualViewModel : ViewModelBase
    {
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
        public RepairManualViewModel()
        {

        }
    }
}
