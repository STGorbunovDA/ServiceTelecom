using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories;
using ServiceTelecom.View.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using System;

namespace ServiceTelecom.ViewModels.TutorialEngineerViewModelPackage
{
    internal class ChangeTutorialEngineerViewModel : ViewModelBase
    {
        AddModelRadiostantionView addModelRadiostantion = null;
        AddProblemModelDataBaseView addProblemModelRadiostantion = null;
        private ModelDataBaseRepository _modelDataBase;
        private ProblemModelRadiostantionRepository _problemModelRadiostantion;
        private TutorialEngineerRepository _tutorialEngineerRepository;

        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelCollections { get; set; }
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel> ProblemModelCollections { get; set; }

        private string _idText;
        public string IdText { get => _idText; set { _idText = value; OnPropertyChanged(nameof(IdText)); } }
        
        private string _model;
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        private string _problem;
        public string Problem { get => _problem; set { _problem = value; OnPropertyChanged(nameof(Problem)); } }

        public string Info { get; set; }
        public string Actions { get; set ; }

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
        public ICommand ChangeTutorialEngineer { get; }

        public ChangeTutorialEngineerViewModel()
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
            ChangeTutorialEngineer = new ViewModelCommand(ExecuteChangeTutorialEngineerCommand);
        }

        #region ChangeTutorialEngineer

        private void ExecuteChangeTutorialEngineerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Info) || string.IsNullOrWhiteSpace(Actions) ||
                string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Problem) ||
                string.IsNullOrWhiteSpace(UserModelStatic.Login))
                return;

            Regex re = new Regex(Environment.NewLine);
            Info = re.Replace(Info, " ");
            Info.Trim();

            Regex re2 = new Regex(Environment.NewLine);
            Actions = re2.Replace(Actions, " ");
            Actions.Trim();

            bool flag = _tutorialEngineerRepository.ChangeTutorialEngineer(IdText, Model, Problem, Info, Actions, UserModelStatic.Login);
            if (flag)
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения инструкции", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

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
