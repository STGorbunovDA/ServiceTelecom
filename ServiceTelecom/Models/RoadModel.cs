using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class RoadModel : ViewModelBase
    {
        private int _id;
        private string _road;

        public int IdBase { get => _id; set { _id = value; OnPropertyChanged(nameof(IdBase)); } }
        public string Road { get => _road; set { _road = value; OnPropertyChanged(nameof(Road)); } }

        public RoadModel(int idBase, string road)
        {
            IdBase = idBase;
            Road = road;
        }

        public override string ToString()
        {
            return $"{Road}";
        }
    }
}
