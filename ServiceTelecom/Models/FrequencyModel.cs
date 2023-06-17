using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    internal class FrequencyModel : ViewModelBase
    {
        private int _id;
        private string _frequency;

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Frequency { get => _frequency; set { _frequency = value; OnPropertyChanged(nameof(Frequency)); } }

        public FrequencyModel(int idBase, string frequency)
        {
            IdBase = idBase;
            Frequency = Encryption.DecryptCipherTextToPlainText(Frequency);
        }

        public override string ToString()
        {
            return $"{Frequency}";
        }
    }
}
