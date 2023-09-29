using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class RepairManualViewModel : ViewModelBase
    {
        /// <summary> для сохранения индекса выделенной строки </summary>
        int TEMPORARY_INDEX_DATAGRID = 0;

        IRepairManualModelRepository _repairManualModelRepository;

        public ObservableCollection<RepairManualRadiostantionModel>
            RepairManualRadiostantionsCollections
        { get; set; }

        string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        string _сompletedWorks;
        public string CompletedWorks
        {
            get => _сompletedWorks;
            set
            {
                _сompletedWorks = value;
                OnPropertyChanged(nameof(CompletedWorks));
            }
        }

        string _parts;
        public string Parts
        {
            get => _parts;
            set
            {
                _parts = value;
                OnPropertyChanged(nameof(Parts));
            }
        }

        int _selectedIndexRepairManualDataGrid;
        public int SelectedIndexRepairManualDataGrid
        {
            get => _selectedIndexRepairManualDataGrid;
            set
            {
                _selectedIndexRepairManualDataGrid = value;
                OnPropertyChanged(nameof(SelectedIndexRepairManualDataGrid));
            }
        }

        RepairManualRadiostantionModel _repairManual;
        public RepairManualRadiostantionModel SelectedRepairManualRadiostantion
        {
            get => _repairManual;
            set
            {
                _repairManual = value;
                OnPropertyChanged(nameof(SelectedRepairManualRadiostantion));
                if (_repairManual != null)
                {
                    CompletedWorks = _repairManual.CompletedWorks;
                    Parts = _repairManual.Parts;
                }
            }
        }

        IList _selectedModels = new ArrayList();
        public IList RepairManualMulipleSelectedDataGrid
        {
            get { return _selectedModels; }
            set
            {
                _selectedModels = value;
                OnPropertyChanged(nameof(RepairManualMulipleSelectedDataGrid));
            }
        }

        public ICommand AddRepairManualModelRadiostationForDocumentInDB { get; }
        public ICommand ChangeRepairManualModelRadiostationForDocumentInDB { get; }
        public ICommand DeleteRepairManualModelRadiostationForDocumentInDB { get; }
        
        public RepairManualViewModel()
        {
            _repairManualModelRepository = new RepairManualModelRepository();
            RepairManualRadiostantionsCollections = 
                new ObservableCollection<RepairManualRadiostantionModel>();
            AddRepairManualModelRadiostationForDocumentInDB =
                new ViewModelCommand(
                    ExecuteAddRepairManualModelRadiostationForDocumentInDBCommand);
            ChangeRepairManualModelRadiostationForDocumentInDB =
                new ViewModelCommand(
                    ExecuteChangeRepairManualModelRadiostationForDocumentInDBCommand);
            DeleteRepairManualModelRadiostationForDocumentInDB =
                 new ViewModelCommand(
                     ExecuteDeleteRepairManualModelRadiostationForDocumentInDBCommand);
            GetRepairManualRadiostantionsCollections();
        }

        #region DeleteRepairManualModelRadiostationForDocumentInDB

        void ExecuteDeleteRepairManualModelRadiostationForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете удаление?", "Внимание",
                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (RepairManualMulipleSelectedDataGrid == null ||
                RepairManualMulipleSelectedDataGrid.Count == 0)
                return;
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRepairManualDataGrid;
            foreach (RepairManualRadiostantionModel repairManualRadiostantion
                in RepairManualMulipleSelectedDataGrid)
                _repairManualModelRepository.
                    DeleteRepairManualModelRadiostationForDocumentInDB(
                    repairManualRadiostantion.IdBase);
            GetRepairManualRadiostantionsCollections();
            GetRowAfterChangeRepairManualInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region ChangeRepairManualModelRadiostationForDocumentInDB

        void ExecuteChangeRepairManualModelRadiostationForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (String.IsNullOrWhiteSpace(Model)
                || String.IsNullOrWhiteSpace(CompletedWorks)
                || String.IsNullOrWhiteSpace(Parts))
                return;
            if(SelectedRepairManualRadiostantion == null) return;
            if (_repairManualModelRepository.
                ChangeRepairManualModelRadiostationForDocumentInDB(
                SelectedRepairManualRadiostantion.IdBase,
                Model, CompletedWorks, Parts))
            {
                TEMPORARY_INDEX_DATAGRID = SelectedIndexRepairManualDataGrid;
                GetRepairManualRadiostantionsCollections();
                GetRowAfterChangeRepairManualInDataGrid(TEMPORARY_INDEX_DATAGRID);
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
            else MessageBox.Show("Ошибка изменения", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region AddRepairManualModelRadiostationForDocumentInDataBase

        void ExecuteAddRepairManualModelRadiostationForDocumentInDBCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Model) 
                || String.IsNullOrWhiteSpace(CompletedWorks) 
                || String.IsNullOrWhiteSpace(Parts))
                return;
            if(_repairManualModelRepository.
                AddRepairManualModelRadiostationForDocumentInDB(
                Model, CompletedWorks, Parts))
            {
                GetRepairManualRadiostantionsCollections();
                GetRowAfterAddingRadiostantionInDataGrid();
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }                   
            else MessageBox.Show("Ошибка добавления", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

        #region GetRepairManualRadiostantionsCollections

        void GetRepairManualRadiostantionsCollections()
        {
            if (RepairManualRadiostantionsCollections.Count != 0)
                RepairManualRadiostantionsCollections.Clear();
            RepairManualRadiostantionsCollections =
                _repairManualModelRepository.GetRepairManualRadiostantionsCollections(
                    RepairManualRadiostantionsCollections, GlobalValue.MODEL);
        }

        #endregion

        #region GetRowAfterAddingRadiostantionInDataGrid

        void GetRowAfterAddingRadiostantionInDataGrid()
        {
            SelectedIndexRepairManualDataGrid = RepairManualRadiostantionsCollections.Count - 1;
        }

        #endregion

        #region GetRowAfterChangeRepairManualInDataGrid

        void GetRowAfterChangeRepairManualInDataGrid(int temporaryIndexDataGrid)
        {
            SelectedIndexRepairManualDataGrid = temporaryIndexDataGrid;
        }

        #endregion
    }
}
