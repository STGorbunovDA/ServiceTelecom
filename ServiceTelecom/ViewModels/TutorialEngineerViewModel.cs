﻿using ServiceTelecom.Infrastructure;
using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels
{
    internal class TutorialEngineerViewModel : ViewModelBase
    {
        TutorialEngineerRepository tutorialEngineerRepository;
        TutorialEngineerDataBaseModel _tutorialEngineer;

        public ObservableCollection<TutorialEngineerDataBaseModel> TutorialsEngineer { get; set; }

        public ObservableCollection<TutorialEngineerDataBaseModel> TemporaryTutorialsEngineer { get; set; }

        public ObservableCollection<string> UserChoice { get; set; }

        private int _idTutorialEngineer;
        private string _model;
        private string _problem;
        private string _info;
        private string _actions;
        private string _author;
        public int IdTutorialEngineer { get => _idTutorialEngineer; set { _idTutorialEngineer = value; OnPropertyChanged(nameof(IdTutorialEngineer)); } }
        public string Model { get => _model; set { _model = value; OnPropertyChanged(nameof(Model)); } }
        public string Problem { get => _problem; set { _problem = value; OnPropertyChanged(nameof(Problem)); } }
        public string Info { get => _info; set { _info = value; OnPropertyChanged(nameof(Info)); } }
        public string Actions { get => _actions; set { _actions = value; OnPropertyChanged(nameof(Actions)); } }
        public string Author { get => _author; set { _author = value; OnPropertyChanged(nameof(Author)); } }

        private string _cmbUserChoiceVisibility;
        public string CmbUserChoiceVisibility { get => _cmbUserChoiceVisibility; set { _cmbUserChoiceVisibility = value; OnPropertyChanged(nameof(CmbUserChoiceVisibility)); } }

        private string _txbSearchInfoVisibility;
        public string TxbSearchInfoVisibility { get => _txbSearchInfoVisibility; set { _txbSearchInfoVisibility = value; OnPropertyChanged(nameof(TxbSearchInfoVisibility)); } }

        private string _selectedItemcmbUserChoice;
        public string SelectedItemcmbUserChoice { get => _selectedItemcmbUserChoice; set { _selectedItemcmbUserChoice = value; OnPropertyChanged(nameof(SelectedItemcmbUserChoice)); } }

        private string _txbSearchInfoText;
        public string TxbSearchInfoText { get => _txbSearchInfoText; set { _txbSearchInfoText = value; OnPropertyChanged(nameof(TxbSearchInfoText)); } }


        private int _theIndexUserChoiceCollection;
        public int TheIndexUserChoiceCollection
        {
            get
            {
                return _theIndexUserChoiceCollection;
            }
            set
            {
                _theIndexUserChoiceCollection = value;
                OnPropertyChanged(nameof(TheIndexUserChoiceCollection));
            }
        }

        private int _theIndexCmbChoiceBySearchCollection;
        public int TheIndexCmbChoiceBySearchCollection
        {
            get
            {
                TheIndexUserChoiceCollection = -1;
                CmbUserChoiceVisibility = "Collapsed";
                TxbSearchInfoVisibility = "Visible";
                UserChoice.Clear();
                if (_theIndexCmbChoiceBySearchCollection == 0)
                    TxbSearchInfoVisibility = "Visible";

                else if (_theIndexCmbChoiceBySearchCollection == 1)
                    foreach (var item in TutorialsEngineer)
                    {
                        CmbUserChoiceVisibility = "Visible";
                        TxbSearchInfoVisibility = "Collapsed";
                        UserChoice.Add(item.Problem.ToString());
                    }
                else if (_theIndexCmbChoiceBySearchCollection == 2)
                    foreach (var item in TutorialsEngineer)
                    {
                        CmbUserChoiceVisibility = "Visible";
                        TxbSearchInfoVisibility = "Collapsed";
                        UserChoice.Add(item.Author.ToString());
                    }
                else if (_theIndexCmbChoiceBySearchCollection == 3)
                    foreach (var item in TutorialsEngineer)
                    {
                        CmbUserChoiceVisibility = "Visible";
                        TxbSearchInfoVisibility = "Collapsed";
                        UserChoice.Add(item.Model.ToString());
                    }

                TheIndexUserChoiceCollection = 0;
                return _theIndexCmbChoiceBySearchCollection;
            }
            set
            {
                _theIndexCmbChoiceBySearchCollection = value;
                OnPropertyChanged(nameof(TheIndexCmbChoiceBySearchCollection));
            }
        }


        public TutorialEngineerDataBaseModel SelectedTutorialEngineerViewModel
        {
            get => _tutorialEngineer;
            set
            {
                _tutorialEngineer = value;
                OnPropertyChanged(nameof(SelectedTutorialEngineerViewModel));
                //if (_reportCard != null)
                //{
                //    User = _reportCard.User;

                //}
            }
        }

        public ICommand GetBySearchInfo { get; }
        public ICommand UpdateTutorialsEngineerDataBase { get; }
        public ICommand SaveTutorialsEngineerDataBase { get; }

        public TutorialEngineerViewModel()
        {
            tutorialEngineerRepository = new TutorialEngineerRepository();
            TutorialsEngineer = new ObservableCollection<TutorialEngineerDataBaseModel>();
            TemporaryTutorialsEngineer = new ObservableCollection<TutorialEngineerDataBaseModel>();
            UserChoice = new ObservableCollection<string>();
            GetBySearchInfo = new ViewModelCommand(ExecuteGetBySearchInfoDataBaseCommand);
            UpdateTutorialsEngineerDataBase = new ViewModelCommand(ExecuteUpdateTutorialsEngineerDataBaseCommand);
            SaveTutorialsEngineerDataBase = new ViewModelCommand(ExecuteSaveTutorialsEngineerDataBaseCommand);
            GetTutorialsEngineerForUpdate();
        }



        #region SaveTutorialsEngineerDataBase

        private void ExecuteSaveTutorialsEngineerDataBaseCommand(object obj)
        {
            SaveCSV.GetInstance.TutorialsEngineerSaveCSV(TutorialsEngineer);
        }

        #endregion


        #region UpdateTutorialsEngineerDataBase

        private void ExecuteUpdateTutorialsEngineerDataBaseCommand(object obj)
        {
            GetTutorialsEngineerForUpdate();
        }

        #endregion

        #region Получение данных по описанию неисправности

        private void ExecuteGetBySearchInfoDataBaseCommand(object obj)
        {
            if (TemporaryTutorialsEngineer.Count != 0)
                TemporaryTutorialsEngineer.Clear();

            foreach (var item in TutorialsEngineer)
                if (item.Info.Contains(TxbSearchInfoText))
                    TemporaryTutorialsEngineer.Add(item);

            if (TutorialsEngineer.Count != 0)
                TutorialsEngineer.Clear();

            foreach (var item in TemporaryTutorialsEngineer)
                TutorialsEngineer.Add(item);           
        }

        #endregion

        /// <summary> Получить всё из БД </summary>
        private void GetTutorialsEngineerForUpdate()
        {
            if (TutorialsEngineer.Count != 0 || UserChoice.Count != 0)
            {
                TutorialsEngineer.Clear();
                UserChoice.Clear();
            }
            TutorialsEngineer = tutorialEngineerRepository.GetTutorialsEngineerDataBase(TutorialsEngineer);
        }
    }
}
