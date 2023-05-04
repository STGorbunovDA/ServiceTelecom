using ServiceTelecom.ViewModels;

namespace ServiceTelecom.Models
{
    public class TutorialEngineerDataBaseModel : ViewModelBase
    {
        private int _idTutorialEngineer;
        private string _model;
        private string _problem;
        private string _info;
        private string _actions;
        private string _author;
        public int IdTutorialEngineer { get => _idTutorialEngineer; set { _idTutorialEngineer = value; OnPropertyChanged(nameof(IdTutorialEngineer)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }
        public string Problem { get => _problem; set { _problem = value; OnPropertyChanged(nameof(Problem)); } }
        public string Info { get => _info; set { _info = value; OnPropertyChanged(nameof(Info)); } }
        public string Actions { get => _actions; set { _actions = value; OnPropertyChanged(nameof(Actions)); } }
        public string Author { get => _author; set { _author = value; OnPropertyChanged(nameof(Author)); } }
        
        public TutorialEngineerDataBaseModel(int idTutorialEngineer, string model, string problem, string info, string actions, string author)
        {
            IdTutorialEngineer = idTutorialEngineer;
            Model = model;
            Problem = problem;
            Info = info;
            Actions = actions;
            Author = author;
        }

        
    }
}
