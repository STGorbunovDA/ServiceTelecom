using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;
using System;

namespace ServiceTelecom.Models
{
    internal class FrequencyModel : ViewModelBase, IComparable<FrequencyModel>
    {
        private int _id;
        private string _frequency;

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Frequency { get => _frequency; set { _frequency = value; OnPropertyChanged(nameof(Frequency)); } }

        public FrequencyModel(int idBase, string frequency)
        {
            IdBase = idBase;
            Frequency = Encryption.DecryptCipherTextToPlainText(frequency);
        }

        public override string ToString()
        {
            return $"{Frequency}";
        }

        public int CompareTo(FrequencyModel other)
        {
            int result = this.Frequency.CompareTo(other.Frequency);
            if (result == 0)
                result = this.Frequency.CompareTo(other.Frequency);
            return result;
        }
    }
}
