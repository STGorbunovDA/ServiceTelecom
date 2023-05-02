using ServiceTelecom.Repositories.Base;
using ServiceTelecom.View.Base;
using ServiceTelecom.View.TutorialEngineerViewPackage;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.TutorialEngineerViewModelPackage
{
    internal class AddTutorialEngineerViewModel :ViewModelBase
    {
        AddModelRadiostantionView addModelRadiostantion = null;
        private ModelDataBase _modelDataBase;
        public ObservableCollection<string> ModelCollections { get; }

        private string _model;
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }

        public ICommand AddModelDataBase { get; }

        public AddTutorialEngineerViewModel() 
        {
            ModelCollections = new ObservableCollection<string>();
            _modelDataBase = new ModelDataBase();
            ModelCollections = _modelDataBase.GetModelDataBase(ModelCollections);
            AddModelDataBase = new ViewModelCommand(ExecuteAddModelDataBaseCommand);
        }

        #region Добавить модель радиостанции

        private void ExecuteAddModelDataBaseCommand(object obj)
        {
            if (addModelRadiostantion == null)
            {
                addModelRadiostantion = new AddModelRadiostantionView();
                addModelRadiostantion.Closed += (sender, args) => addModelRadiostantion = null;
                addModelRadiostantion.Show();
            }
        }

        #endregion


    }
}
