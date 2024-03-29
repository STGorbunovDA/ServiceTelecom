﻿using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class RoadViewModel : ViewModelBase
    {
        IRoadDataBaseRepository _roadDataBaseRepository;
        public ObservableCollection<RoadModel> RoadCollections { get; set; }

        string _road;
        public string Road
        {
            get => _road;
            set { _road = value; OnPropertyChanged(nameof(Road)); }
        }

        int _theIndexRoadCollection;
        public int TheIndexRoadCollection
        {
            get => _theIndexRoadCollection;
            set
            {
                _theIndexRoadCollection = value;
                OnPropertyChanged(nameof(TheIndexRoadCollection));
            }
        }

        RoadModel _selectedRoadDataBaseModel;
        public RoadModel SelectedRoadDataBaseModel
        {
            get => _selectedRoadDataBaseModel;
            set
            {
                if (value == null)
                    return;
                _selectedRoadDataBaseModel = value;
                OnPropertyChanged(nameof(SelectedRoadDataBaseModel));
            }
        }
        public ICommand AddRoadDataBase { get; }
        public ICommand DeleteRoadDataBase { get; }

        public RoadViewModel()
        {
            RoadCollections = new ObservableCollection<RoadModel>();
            _roadDataBaseRepository = new RoadDataBaseRepository();
            AddRoadDataBase = new ViewModelCommand(ExecuteAddRoadDataBaseCommand);
            DeleteRoadDataBase = new ViewModelCommand(ExecuteDeleteRoadDataBaseCommand);
            GetRoadDataBase();
        }

        #region GetRoadDataBase

        async void GetRoadDataBase()
        {
            TheIndexRoadCollection = -1;
            if (RoadCollections.Count != 0)
                RoadCollections.Clear();
            RoadCollections = await _roadDataBaseRepository.GetRoadDataBase(RoadCollections);
            TheIndexRoadCollection = RoadCollections.Count - 1;
        }

        #endregion

        #region AddRoadDataBase

        void ExecuteAddRoadDataBaseCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Road)) return;
            var result = RoadCollections.FirstOrDefault(s => s.Road == Road);
            if (result != null)
                return;
            if (_roadDataBaseRepository.AddRoadDataBase(Road)) GetRoadDataBase();
            else MessageBox.Show("Ошибка добавления дороги", "Отмена",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region DeleteRoadDataBase
        void ExecuteDeleteRoadDataBaseCommand(object obj)
        {
            if (RoadCollections.Count <= 0)
                return;
            if (string.IsNullOrWhiteSpace(Road))
                return;
            if (SelectedRoadDataBaseModel.Road != Road) return;
            if (_roadDataBaseRepository.DeleteRoadDataBase(Road)) GetRoadDataBase();
            else
            {
                Road = string.Empty;
                MessageBox.Show("Ошибка удаления модели", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
