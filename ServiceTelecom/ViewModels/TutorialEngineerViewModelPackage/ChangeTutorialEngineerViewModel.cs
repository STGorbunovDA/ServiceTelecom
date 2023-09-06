using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories;
using ServiceTelecom.View.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using System;
using ServiceTelecom.Repositories.Interfaces;
using System.Text;

namespace ServiceTelecom.ViewModels.TutorialEngineerViewModelPackage
{
    internal class ChangeTutorialEngineerViewModel : ViewModelBase
    {
        AddModelRadiostantionView addModelRadiostantion = null;
        AddProblemModelDataBaseView addProblemModelRadiostantion = null;
        IModelDataBaseRepository _modelDataBase;
        IProblemModelRadiostantionRepository _problemModelRadiostantion;
        ITutorialEngineerRepository _tutorialEngineerRepository;

        public ObservableCollection<ModelRadiostantionDataBaseModel>
            ModelCollections
        { get; set; }
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel>
            ProblemModelCollections
        { get; set; }

        string _idText;
        public string IdText
        {
            get => _idText;
            set { _idText = value; OnPropertyChanged(nameof(IdText)); }
        }

        string _model;
        public string Model
        {
            get => _model;
            set { _model = value; OnPropertyChanged(nameof(Model)); }
        }

        string _problem;
        public string Problem
        {
            get => _problem;
            set { _problem = value; OnPropertyChanged(nameof(Problem)); }
        }

        public string Info { get; set; }
        public string Actions { get; set; }

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
        public ICommand ChangeTutorialEngineer { get; }

        public ChangeTutorialEngineerViewModel()
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
            ChangeTutorialEngineer =
                new ViewModelCommand(ExecuteChangeTutorialEngineerCommand);
        }

        #region ChangeTutorialEngineer

        void ExecuteChangeTutorialEngineerCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Info) || string.IsNullOrWhiteSpace(Actions)
                || string.IsNullOrWhiteSpace(Model) || string.IsNullOrWhiteSpace(Problem)
                || string.IsNullOrWhiteSpace(UserModelStatic.LOGIN))
                return;

            StringBuilder sb = new StringBuilder(Info.Trim());
            sb.Replace(Environment.NewLine, " ");
            Info = sb.ToString();

            StringBuilder sb2 = new StringBuilder(Actions.Trim());
            sb2.Replace(Environment.NewLine, " ");
            Actions = sb2.ToString();

            if (_tutorialEngineerRepository.ChangeTutorialEngineer(IdText, Model, Problem,
                Info, Actions, UserModelStatic.LOGIN))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            else
                MessageBox.Show("Ошибка изменения инструкции", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

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
