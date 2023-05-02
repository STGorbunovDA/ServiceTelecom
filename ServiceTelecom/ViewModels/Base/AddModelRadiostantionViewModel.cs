using ServiceTelecom.Repositories.Base;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddModelRadiostantionViewModel : ViewModelBase
    {
        private ModelDataBase _modelDataBase;
        public ObservableCollection<string> ModelCollections { get; }

        private string _model;
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        public AddModelRadiostantionViewModel()
        {
            ModelCollections = new ObservableCollection<string>();
            _modelDataBase = new ModelDataBase();
            ModelCollections = _modelDataBase.GetModelDataBase(ModelCollections);
        }
    }
}
