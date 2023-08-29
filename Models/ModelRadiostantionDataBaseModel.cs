using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class ModelRadiostantionDataBaseModel : ViewModelBase
    {
        private int _id;
        private string _model;

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        public ModelRadiostantionDataBaseModel(int idBase, string model)
        {
            IdBase = idBase;
            Model = Encryption.DecryptCipherTextToPlainText(model);
        }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
