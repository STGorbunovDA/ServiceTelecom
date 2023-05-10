using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.TutorialEngineerViewModelPackage
{
    internal class AddTutorialEngineerViewModel : ViewModelBase
    {
        AddModelRadiostantionView addModelRadiostantion = null;
        AddProblemModelDataBaseView addProblemModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        private ProblemModelRadiostantionRepository _problemModelRadiostantion;
        private TutorialEngineerRepository _tutorialEngineerRepository;

        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelCollections { get; set; }
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel> ProblemModelCollections { get; set; }

        private string _model;
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        private string _problem;
        public string Problem { get => _problem; set { _problem = value; OnPropertyChanged(nameof(Problem)); } }

        private string _info;
        public string Info { get => _info; set { _info = value; OnPropertyChanged(nameof(Info)); } }

        private string _actions;
        public string Actions { get => _actions; set { _actions = value; OnPropertyChanged(nameof(Actions)); } }

        private int _theIndexModelChoiceCollection;
        public int TheIndexModelChoiceCollection
        {
            get
            {
                return _theIndexModelChoiceCollection;
            }
            set
            {
                _theIndexModelChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexModelChoiceCollection));
            }
        }

        private int _theIndexProblemChoiceCollection;
        public int TheIndexProblemChoiceCollection
        {
            get
            {
                return _theIndexProblemChoiceCollection;
            }
            set
            {
                _theIndexProblemChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexProblemChoiceCollection));
            }
        }

        public ICommand AddModelDataBase { get; }
        public ICommand AddProblemDataBase { get; }
        public ICommand Clear { get; }
        public ICommand AddTutorialEngineer { get; }

        public AddTutorialEngineerViewModel()
        {
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            ProblemModelCollections = new ObservableCollection<ProblemModelRadiostantionDataBaseModel>();
            _modelDataBase = new ModelDataBaseRepository();
            _problemModelRadiostantion = new ProblemModelRadiostantionRepository();
            _tutorialEngineerRepository = new TutorialEngineerRepository();
            GetModelDataBase();
            GetProblemModelRadiostantion();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            AddProblemDataBase = new ViewModelCommand(ExecuteAddProblemDataBaseCommand);
            Clear = new ViewModelCommand(ExecuteClearCommand);
            AddTutorialEngineer = new ViewModelCommand(ExecuteAddTutorialEngineerCommand);
        }

        private void GetModelDataBase()
        {
            TheIndexModelChoiceCollection = -1;
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = _modelDataBase.GetModelRadiostantionDataBase(ModelCollections);
            TheIndexModelChoiceCollection = ModelCollections.Count - 1;
        }

        private void GetProblemModelRadiostantion()
        {
            TheIndexProblemChoiceCollection = -1;
            if (ProblemModelCollections.Count != 0)
                ProblemModelCollections.Clear();
            ProblemModelCollections = _problemModelRadiostantion.GetProblemModelRadiostantionDataBase(ProblemModelCollections);
            TheIndexProblemChoiceCollection = ProblemModelCollections.Count - 1;
        }

        #region AddTutorialEngineer

        private void ExecuteAddTutorialEngineerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Info) || string.IsNullOrWhiteSpace(Actions) ||
                string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Problem) ||
                string.IsNullOrWhiteSpace(UserModelStatic.Login))
                return;
            bool flag = _tutorialEngineerRepository.AddTutorialEngineer(Model, Problem, Info, Actions, UserModelStatic.Login);
            if (flag)
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка добавления инструкции", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region Clear

        private void ExecuteClearCommand(object obj)
        {
            Info = string.Empty;
            Actions = string.Empty;
        }

        #endregion

        #region AddProblemDataBase

        private void ExecuteAddProblemDataBaseCommand(object obj)
        {
            if (addProblemModelRadiostantion == null)
            {
                addProblemModelRadiostantion = new AddProblemModelDataBaseView();
                addProblemModelRadiostantion.Closed += (sender, args) => addProblemModelRadiostantion = null;
                addProblemModelRadiostantion.Closed += (sender, args) => GetProblemModelRadiostantion();
                addProblemModelRadiostantion.Show();
            }
        }

        #endregion

        #region AddModelDataBase

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) => addModelRadiostantion = null;
                addModelRadiostantion.Closed += (sender, args) => GetModelDataBase();
                addModelRadiostantion.Show();
            }
        }

        #endregion


    }
}
