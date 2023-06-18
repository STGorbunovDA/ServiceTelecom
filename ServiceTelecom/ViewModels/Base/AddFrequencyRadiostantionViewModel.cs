using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddFrequencyRadiostantionViewModel : ViewModelBase
    {
        FrequenciesDataBaseRepository _frequenciesDataBase;
        public List<FrequencyModel> FrequenciesCollections { get; set; }

        private string _frequency;
        public string Frequency
        {
            get => _frequency;
            set { _frequency = value; OnPropertyChanged(nameof(Frequency)); }
        }

        private int _theIndexFrequencyCollection;
        public int TheIndexFrequencyCollection
        {
            get => _theIndexFrequencyCollection;
            set
            {
                _theIndexFrequencyCollection = value;
                OnPropertyChanged(nameof(TheIndexFrequencyCollection));
            }
        }

        public ICommand AddFrequencyDataBase { get; }
        public ICommand ChangeFrequencyDataBase { get; }
        public ICommand DeleteFrequencyDataBase { get; }

        public AddFrequencyRadiostantionViewModel()
        {
            _frequenciesDataBase = new FrequenciesDataBaseRepository();
            FrequenciesCollections = new List<FrequencyModel>();
            GetFrequencyDataBase();
            AddFrequencyDataBase = new ViewModelCommand(ExecuteAddFrequencyDataBaseCommand);
            ChangeFrequencyDataBase = new ViewModelCommand(ExecuteChangeFrequencyDataBaseCommand);
            DeleteFrequencyDataBase = new ViewModelCommand(ExecuteDeleteFrequencyDataBaseCommand);
        }



        #region DeleteFrequencyDataBase

        private void ExecuteDeleteFrequencyDataBaseCommand(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ChangeFrequencyDataBase

        private void ExecuteChangeFrequencyDataBaseCommand(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region AddFrequencyDataBase

        private void ExecuteAddFrequencyDataBaseCommand(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GetFrequencyDataBase

        private void GetFrequencyDataBase()
        {
            TheIndexFrequencyCollection = -1;
            if (FrequenciesCollections.Count != 0)
                FrequenciesCollections.Clear();
            FrequenciesCollections =
                _frequenciesDataBase.GetFrequencyDataBase(FrequenciesCollections);
            TheIndexFrequencyCollection = 0;
        }

        #endregion
    }
}
