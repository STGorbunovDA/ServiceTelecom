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
        private ModelRadiostantionDataBaseModel _modelRadiostantion;
        private ModelDataBaseRepository _modelDataBase;
        public ObservableCollection<ModelRadiostantionDataBaseModel> ModelCollections { get; set; }

        private string _model;
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        private int _theIndexModelCollection;
        public int TheIndexModelCollection { get => _theIndexModelCollection; set { _theIndexModelCollection = value; OnPropertyChanged(nameof(TheIndexModelCollection)); } }
        public ICommand AddModelDataBase { get; }
        public ICommand DeleteModelDataBase { get; }

        public ModelRadiostantionDataBaseModel SelectedModelRadiostantion
        {
            get => _modelRadiostantion;
            set { _modelRadiostantion = value; OnPropertyChanged(nameof(SelectedModelRadiostantion)); }
        }

        public AddModelRadiostantionViewModel()
        {
            ModelCollections = new ObservableCollection<ModelRadiostantionDataBaseModel>();
            _modelDataBase = new ModelDataBaseRepository();
            GetModelDataBaseForUpdate();
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
            DeleteModelDataBase = new ViewModelCommand(ExecuteDeleteModelDataBaseCommand);
        }

        #region DeleteModelDataBase

        private void ExecuteDeleteModelDataBaseCommand(object obj)
        {
            if (ModelCollections.Count <= 0 && string.IsNullOrWhiteSpace(Model))
                return;
            bool flag = _modelDataBase.DeleteModelDataBase(Model);
            if (flag) GetModelDataBaseForUpdate();
            //MessageBox.Show("Модель успешно добавлена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

            else
            {
                Model = string.Empty;
                MessageBox.Show("Ошибка удаления модели", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region AddModelDataBase

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            var result = ModelCollections.FirstOrDefault(s => s.Model == Model);
            if (result != null)
                return;

            bool flag = _modelDataBase.AddModelDataBase(Model);
            if (flag)
            {
                GetModelDataBaseForUpdate();
                //MessageBox.Show("Модель успешно добавлена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show("Ошибка добавления модели", "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        private void GetModelDataBaseForUpdate()
        {
            TheIndexModelCollection = -1;
            if (ModelCollections.Count != 0)
                ModelCollections.Clear();
            ModelCollections = _modelDataBase.GetModelDataBase(ModelCollections);
            TheIndexModelCollection = ModelCollections.Count;
        }
    }
}
