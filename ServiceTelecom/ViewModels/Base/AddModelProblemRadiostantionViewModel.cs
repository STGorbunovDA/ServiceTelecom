using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddModelProblemRadiostantionViewModel : ViewModelBase
    {
        private ProblemModelRadiostantionRepository _problemModelRadiostantionDataBase;
        public ObservableCollection<ProblemModelRadiostantionDataBaseModel> 
            ProblemModelCollections { get; set; }
        
        private string _problem;
        public string Problem { get => _problem; 
            set { _problem = value; 
                OnPropertyChanged(nameof(Problem)); } 
        }

        private int _theIndexProblemModelCollection;
        public int TheIndexProblemModelCollection 
        { get => _theIndexProblemModelCollection; 
            set { _theIndexProblemModelCollection = value; 
                OnPropertyChanged(nameof(TheIndexProblemModelCollection)); 
            } 
        }

        public ICommand AddProblemModelDataBase { get; }
        public ICommand DeleteProblemModelDataBase { get; }
        
        public AddModelProblemRadiostantionViewModel()
        {
            ProblemModelCollections = 
                new ObservableCollection<ProblemModelRadiostantionDataBaseModel>();
            _problemModelRadiostantionDataBase = 
                new ProblemModelRadiostantionRepository();
            GetProblemModelDataBaseForUpdate();
            AddProblemModelDataBase = 
                new ViewModelCommand(ExecuteAddProblemModelDataBaseCommand);
            DeleteProblemModelDataBase = 
                new ViewModelCommand(ExecuteDeleteProblemModelDataBaseCommand);
        }

        #region DeleteProblemModelDataBase

        private void ExecuteDeleteProblemModelDataBaseCommand(object obj)
        {
            if (ProblemModelCollections.Count <= 0 && string.IsNullOrWhiteSpace(Problem))
                return;
            if (_problemModelRadiostantionDataBase.DeleteProblemModelDataBase(Problem)) 
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

        private void ExecuteAddProblemModelDataBaseCommand(object obj)
        {
            if(string.IsNullOrWhiteSpace(Problem)) return;
            var result = ProblemModelCollections.FirstOrDefault(s => s.Problem == Problem);
            if (result != null)
                return;
            if (_problemModelRadiostantionDataBase.AddProblemModelDataBase(Problem)) 
                GetProblemModelDataBaseForUpdate();
            else MessageBox.Show("Ошибка добавления проблемы", 
                "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetProblemModelDataBaseForUpdate

        private void GetProblemModelDataBaseForUpdate()
        {
            TheIndexProblemModelCollection = -1;
            if (ProblemModelCollections.Count != 0)
                ProblemModelCollections.Clear();
            ProblemModelCollections = 
                _problemModelRadiostantionDataBase.
                GetProblemModelRadiostantionDataBase(ProblemModelCollections);
            TheIndexProblemModelCollection = ProblemModelCollections.Count;
        }
        #endregion
    }
}
