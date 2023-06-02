using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    internal class RepairManualRadiostantion : ViewModelBase
    {
        private int _id;
        private string _model;
        private string _completedWorks;
        private string _parts;
        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }
        public string CompletedWorks { get => _completedWorks; set { _completedWorks = value; OnPropertyChanged(nameof(CompletedWorks)); } }
        public string Parts { get => _parts; set { _parts = value; OnPropertyChanged(nameof(Parts)); } }
        public RepairManualRadiostantion(int idBase, 
            string model, string completedWorks, string parts)
        {
            IdBase = idBase;
            Model = model;
            CompletedWorks = completedWorks;
            Parts = parts;
        } 
    }
}
