using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;


namespace ServiceTelecom.Models
{
    public class ProblemModelRadiostantionDataBaseModel : ViewModelBase
    {
        private int _id;
        private string _problem;

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Problem { get => _problem; set { _problem = value; OnPropertyChanged(nameof(Problem)); } }

        public ProblemModelRadiostantionDataBaseModel(int idBase, string problem)
        {
            IdBase = idBase;
            Problem = Encryption.DecryptCipherTextToPlainText(problem);
        }

        public override string ToString()
        {
            return $"{Problem}";
        }
    }
}
