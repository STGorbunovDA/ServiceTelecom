using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddModelProblemRadiostantionViewModel : ViewModelBase
    {
        IProblemModelRadiostantionRepository _problemModelRadiostantionRepository;
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel>
            ProblemModelCollections
        { get; set; }

        string _problem;
        public string Problem
        {
            get => _problem;
            set
            {
                _problem = value;
                OnPropertyChanged(nameof(Problem));
            }
        }

        int _theIndexProblemModelCollection;
        public int TheIndexProblemModelCollection
        {
            get => _theIndexProblemModelCollection;
            set
            {
                _theIndexProblemModelCollection = value;
                OnPropertyChanged(nameof(TheIndexProblemModelCollection));
            }
        }

        public ICommand AddProblemModelDataBase { get; }
        public ICommand DeleteProblemModelDataBase { get; }


        ProblemModelRadiostantionDataBaseModel _selectedProblemModelRadiostantionDataBaseModel;
        public ProblemModelRadiostantionDataBaseModel SelectedProblemModelRadiostantionDataBaseModel
        {
            get => _selectedProblemModelRadiostantionDataBaseModel;
            set
            {
                if (value == null)
                    return;
                _selectedProblemModelRadiostantionDataBaseModel = value;
                OnPropertyChanged(nameof(SelectedProblemModelRadiostantionDataBaseModel));
            }
        }

        public AddModelProblemRadiostantionViewModel()
        {
            ProblemModelCollections =
                new ObservableCollection<ProblemModelRadiostantionDataBaseModel>();
            _problemModelRadiostantionRepository =
                new ProblemModelRadiostantionRepository();
            GetProblemModelDataBaseForUpdate();
            AddProblemModelDataBase =
                new ViewModelCommand(ExecuteAddProblemModelDataBaseCommand);
            DeleteProblemModelDataBase =
                new ViewModelCommand(ExecuteDeleteProblemModelDataBaseCommand);
        }

        #region DeleteProblemModelDataBase

        void ExecuteDeleteProblemModelDataBaseCommand(object obj)
        {
            if(ProblemModelCollections.Count <= 0) return; 
            if (string.IsNullOrWhiteSpace(Problem))
                return;
            if (SelectedProblemModelRadiostantionDataBaseModel.Problem != Problem)
                return;
            if (_problemModelRadiostantionRepository.DeleteProblemModelDataBase(Problem))
                GetProblemModelDataBaseForUpdate();
            else
            {
                Problem = string.Empty;
                MessageBox.Show("Ошибка удаления проблемы", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region AddProblemModelDataBase

        void ExecuteAddProblemModelDataBaseCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Problem)) return;
            var result = ProblemModelCollections.FirstOrDefault(s => s.Problem == Problem);
            if (result != null)
                return;
            if (_problemModelRadiostantionRepository.AddProblemModelDataBase(Problem))
                GetProblemModelDataBaseForUpdate();
            else MessageBox.Show("Ошибка добавления проблемы",
                "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetProblemModelDataBaseForUpdate

        void GetProblemModelDataBaseForUpdate()
        {
            TheIndexProblemModelCollection = -1;
            if (ProblemModelCollections.Count != 0)
                ProblemModelCollections.Clear();
            ProblemModelCollections =
                _problemModelRadiostantionRepository.
                GetProblemModelRadiostantionDataBase(ProblemModelCollections);
            TheIndexProblemModelCollection = ProblemModelCollections.Count - 1;
        }
        #endregion
    }
}
