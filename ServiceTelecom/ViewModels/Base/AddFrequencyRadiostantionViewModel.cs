using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddFrequencyRadiostantionViewModel : ViewModelBase
    {
        FrequenciesDataBaseRepository _frequenciesDataBase;
        public ObservableCollection<FrequencyModel> FrequenciesCollections { get; set; }

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
            FrequenciesCollections = new ObservableCollection<FrequencyModel>();
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
            if (string.IsNullOrWhiteSpace(Frequency)) return;
            var result = FrequenciesCollections.FirstOrDefault(s => s.Frequency == Frequency);
            if (result != null)
                return;
            if (!Regex.IsMatch(Frequency,
                @"^[1][0-9]{1,1}[0-9]{1,1}[.][0-9]{1,1}[0-9]{1,1}[0-9]{1,1}$"))
            {
                MessageBox.Show($"Введите корректно поле: \"Частота\"\nПример: 151.825",
                   "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_frequenciesDataBase.AddFrequencyDataBase(Frequency)) GetFrequencyDataBase();
            else MessageBox.Show("Ошибка добавления модели", "Отмена",
                MessageBoxButton.OK, MessageBoxImage.Error);
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
            FrequenciesCollections = 
                new ObservableCollection<FrequencyModel>(FrequenciesCollections.OrderBy(i => i));
            TheIndexFrequencyCollection = FrequenciesCollections.Count - 1;
        }

        #endregion
    }
}
