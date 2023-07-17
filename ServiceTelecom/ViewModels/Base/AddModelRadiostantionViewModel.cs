using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddModelRadiostantionViewModel : ViewModelBase
    {
        private ModelDataBaseRepository _modelDataBaseRepository;
        public ObservableCollection<ModelRadiostantionDataBaseModel>
            ModelCollections
        { get; set; }

        private string _model;
        public string Model
        {
            get => _model;
            set { _model = value; OnPropertyChanged(nameof(Model)); }
        }

        private int _theIndexModelCollection;
        public int TheIndexModelCollection
        {
            get => _theIndexModelCollection;
            set
            {
                _theIndexModelCollection = value;
                OnPropertyChanged(nameof(TheIndexModelCollection));
            }
        }

        ModelRadiostantionDataBaseModel _selectedModelRadiostantionDataBaseModel;
        public ModelRadiostantionDataBaseModel SelectedModelRadiostantionDataBaseModel
        {
            get => _selectedModelRadiostantionDataBaseModel;
            set
            {
                if (value == null)
                    return;
                _selectedModelRadiostantionDataBaseModel = value;
                OnPropertyChanged(nameof(SelectedModelRadiostantionDataBaseModel));
            }
        }

        public ICommand AddModelDataBase { get; }
        public ICommand DeleteModelDataBase { get; }

        public AddModelRadiostantionViewModel()
        {
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            _modelDataBaseRepository = new ModelDataBaseRepository();
            GetModelDataBaseForUpdate();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            DeleteModelDataBase = new ViewModelCommand(ExecuteDeleteModelDataBaseCommand);
        }

        #region DeleteModelDataBase

        private void ExecuteDeleteModelDataBaseCommand(object obj)
        {
            if (ModelCollections.Count <= 0)
                return;
            if (string.IsNullOrWhiteSpace(Model))
                return;
            if (SelectedModelRadiostantionDataBaseModel.Model != Model) return;
            if (_modelDataBaseRepository.DeleteModelDataBase(Model)) GetModelDataBaseForUpdate();
            else
            {
                Model = string.Empty;
                MessageBox.Show("Ошибка удаления модели", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region AddModelDataBase

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Model)) return;
            var result = ModelCollections.FirstOrDefault(s => s.Model == Model);
            if (result != null)
                return;
            if (_modelDataBaseRepository.AddModelDataBase(Model)) GetModelDataBaseForUpdate();
            else MessageBox.Show("Ошибка добавления модели", "Отмена",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetModelDataBaseForUpdate

        private void GetModelDataBaseForUpdate()
        {
            TheIndexModelCollection = -1;
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = _modelDataBaseRepository.
                GetModelRadiostantionDataBase(ModelCollections);
            TheIndexModelCollection = ModelCollections.Count - 1;
        }

        #endregion
    }
}
