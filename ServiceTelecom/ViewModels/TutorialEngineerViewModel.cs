using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels
{
    internal class TutorialEngineerViewModel : ViewModelBase
    {
        TutorialEngineerRepository tutorialEngineerRepository;
        TutorialEngineerDataBaseModel _tutorialEngineer;

        public ObservableCollection<TutorialEngineerDataBaseModel> TutorialsEngineer { get; set; }

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

        public TutorialEngineerDataBaseModel SelectedTutorialEngineerViewModel
        {
            get => _tutorialEngineer;
            set
            {
                _tutorialEngineer = value;
                OnPropertyChanged(nameof(SelectedTutorialEngineerViewModel));
                //if (_reportCard != null)
                //{
                //    User = _reportCard.User;
                    
                //}
            }
        }
        public TutorialEngineerViewModel()
        {
            tutorialEngineerRepository = new TutorialEngineerRepository();
            TutorialsEngineer = new ObservableCollection<TutorialEngineerDataBaseModel>();
            GetTutorialsEngineerForUpdate();
        }

        /// <summary> Получить всё из БД </summary>
        private void GetTutorialsEngineerForUpdate()
        {
            if(TutorialsEngineer.Count != 0)
            {
                TutorialsEngineer.Clear();
            }

            TutorialsEngineer = tutorialEngineerRepository.GetTutorialsEngineerDataBase(TutorialsEngineer);
        }
    }
}
