using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
using ServiceTelecom.View.Base;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.TutorialEngineerViewModelPackage
{
    internal class AddTutorialEngineerViewModel : ViewModelBase
    {
        AddModelRadiostantionView addModelRadiostantion = null;
        AddProblemModelDataBaseView addProblemModelRadiostantion = null;
        IModelDataBaseRepository _modelDataBase;
        IProblemModelRadiostantionRepository _problemModelRadiostantion;
        ITutorialEngineerRepository _tutorialEngineerRepository;

        public ObservableCollection<ModelRadiostantionDataBaseModel> 
            ModelCollections { get; set; }
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel> 
            ProblemModelCollections { get; set; }

        string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        string _problem;
        public string Problem
        {
            get => _problem;
            set { _problem = value; OnPropertyChanged(nameof(Problem)); }
        }

        string _info;
        public string Info
        {
            get => _info; set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }

        string _actions;
        public string Actions
        {
            get => _actions; set
            {
                _actions = value;
                OnPropertyChanged(nameof(Actions));
            }
        }

        int _theIndexModelChoiceCollection;
        public int TheIndexModelChoiceCollection
        {
            get => _theIndexModelChoiceCollection;
            set
            {
                _theIndexModelChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexModelChoiceCollection));
            }
        }

        int _theIndexProblemChoiceCollection;
        public int TheIndexProblemChoiceCollection
        {
            get => _theIndexProblemChoiceCollection;
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
            ProblemModelCollections = 
                new ObservableCollection<ProblemModelRadiostantionDataBaseModel>();
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

        #region GetModelDataBase

        void GetModelDataBase()
        {
            TheIndexModelChoiceCollection = -1;
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = 
                _modelDataBase.GetModelRadiostantionDataBase(ModelCollections);
            TheIndexModelChoiceCollection = ModelCollections.Count - 1;
        }

        #endregion

        #region GetProblemModelRadiostantion

        void GetProblemModelRadiostantion()
        {
            TheIndexProblemChoiceCollection = -1;
            if (ProblemModelCollections.Count != 0)
                ProblemModelCollections.Clear();
            ProblemModelCollections = 
                _problemModelRadiostantion.GetProblemModelRadiostantionDataBase(
                    ProblemModelCollections);
            TheIndexProblemChoiceCollection = ProblemModelCollections.Count - 1;
        }

        #endregion

        #region AddTutorialEngineer

        void ExecuteAddTutorialEngineerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Info) || string.IsNullOrWhiteSpace(Actions) 
                ||string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Problem) 
                ||string.IsNullOrWhiteSpace(UserModelStatic.LOGIN))
                return;

            StringBuilder sb = new StringBuilder(Info.Trim());
            sb.Replace(Environment.NewLine, " ");
            Info = sb.ToString();


            StringBuilder sb2 = new StringBuilder(Actions.Trim());
            sb2.Replace(Environment.NewLine, " ");
            Actions = sb2.ToString();
           
            if (_tutorialEngineerRepository.AddTutorialEngineer(Model, Problem, Info,
                Actions, UserModelStatic.LOGIN))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка добавления инструкции", "Отмена", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region Clear

        void ExecuteClearCommand(object obj)
        {
            Info = string.Empty;
            Actions = string.Empty;
        }

        #endregion

        #region AddProblemDataBase

        void ExecuteAddProblemDataBaseCommand(object obj)
        {
            if (addProblemModelRadiostantion == null)
            {
                addProblemModelRadiostantion = new AddProblemModelDataBaseView();
                addProblemModelRadiostantion.Closed += (sender, args) => 
                addProblemModelRadiostantion = null;
                addProblemModelRadiostantion.Closed += (sender, args) => 
                GetProblemModelRadiostantion();
                addProblemModelRadiostantion.ShowDialog();
            }
        }

        #endregion

        #region AddModelDataBase

        void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) => 
                addModelRadiostantion = null;
                addModelRadiostantion.Closed += (sender, args) => 
                GetModelDataBase();
                addModelRadiostantion.ShowDialog();
            }
        }

        #endregion
    }
}
