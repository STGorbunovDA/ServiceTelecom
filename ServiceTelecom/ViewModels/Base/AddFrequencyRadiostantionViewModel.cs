using ServiceTelecom.Models;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class AddFrequencyRadiostantionViewModel : ViewModelBase
    {
        IFrequenciesDataBaseRepository _frequenciesDataBaseRepository;
        public ObservableCollection<FrequencyModel> FrequenciesCollection { get; set; }

        string _frequency;
        public string Frequency
        {
            get => _frequency;
            set { _frequency = value; }
        }

        int _theIndexFrequencyCollection;
        public int TheIndexFrequencyCollection
        {
            get => _theIndexFrequencyCollection;
            set
            {
                _theIndexFrequencyCollection = value;
                OnPropertyChanged(nameof(TheIndexFrequencyCollection));
            }
        }

        FrequencyModel _selectedFrequencyModel;
        public FrequencyModel SelectedFrequencyModel
        {
            get => _selectedFrequencyModel;
            set
            {
                if (value == null)
                    return;
                _selectedFrequencyModel = value;
                OnPropertyChanged(nameof(SelectedFrequencyModel));
            }
        }

        public ICommand AddFrequencyDataBase { get; }
        public ICommand DeleteFrequencyDataBase { get; }

        public AddFrequencyRadiostantionViewModel()
        {
            _frequenciesDataBaseRepository = new FrequenciesDataBaseRepository();
            FrequenciesCollection = new ObservableCollection<FrequencyModel>();
            GetFrequencyDataBase();
            AddFrequencyDataBase = new ViewModelCommand(ExecuteAddFrequencyDataBaseCommand);
            DeleteFrequencyDataBase = new ViewModelCommand(ExecuteDeleteFrequencyDataBaseCommand);
        }



        #region DeleteFrequencyDataBase

        private void ExecuteDeleteFrequencyDataBaseCommand(object obj)
        {
            if (FrequenciesCollection.Count <= 0) return;
            if (String.IsNullOrWhiteSpace(Frequency)) return;
            if (SelectedFrequencyModel.Frequency != Frequency) return;
            if (_frequenciesDataBaseRepository.DeleteFrequencyDataBase(SelectedFrequencyModel.IdBase))
                GetFrequencyDataBase();
            else MessageBox.Show("Ошибка удаления частоты", "Отмена",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region AddFrequencyDataBase

        private void ExecuteAddFrequencyDataBaseCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Frequency)) return;
            var result = FrequenciesCollection.FirstOrDefault(s => s.Frequency == Frequency);
            if (result != null)
                return;
            if (!Regex.IsMatch(Frequency,
                @"^[1][0-9]{2,2}[.][0-9]{3,3}$"))
            {
                MessageBox.Show($"Введите корректно поле: \"Частота\"\nПример: 151.825",
                   "Отмена", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            UserModelStatic.FREQUENCY = _frequenciesDataBaseRepository.AddFrequencyDataBase(Frequency);
            if (!String.IsNullOrWhiteSpace(UserModelStatic.FREQUENCY))
            {
                GetFrequencyDataBase();
                MessageBox.Show("Успешно!", "Информация",
                       MessageBoxButton.OK, MessageBoxImage.Information);
            }  
            else MessageBox.Show("Ошибка добавления частоты", "Отмена",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetFrequencyDataBase

        private void GetFrequencyDataBase()
        {
            TheIndexFrequencyCollection = -1;
            if (FrequenciesCollection.Count != 0)
                FrequenciesCollection.Clear();
            FrequenciesCollection =
                _frequenciesDataBaseRepository.GetFrequencyDataBase(FrequenciesCollection);
            if (!String.IsNullOrWhiteSpace(UserModelStatic.FREQUENCY))
                Frequency = UserModelStatic.FREQUENCY;
            else TheIndexFrequencyCollection = FrequenciesCollection.Count - 1;
            
        }

        #endregion
    }
}
