using ServiceTelecom.Models;
using ServiceTelecom.Repositories;
using ServiceTelecom.Repositories.Base;
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
        private int TEMPORARY_INDEX_DATAGRID = 0;

        RepairManualModelRepository _repairManualModelRepository;

        public ObservableCollection<RepairManualRadiostantion>
            RepairManualRadiostantionsCollections
        { get; set; }

        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        private string _сompletedWorks;
        public string CompletedWorks
        {
            get => _сompletedWorks;
            set
            {
                _сompletedWorks = value;
                OnPropertyChanged(nameof(CompletedWorks));
            }
        }
        private string _parts;
        public string Parts
        {
            get => _parts;
            set
            {
                _parts = value;
                OnPropertyChanged(nameof(Parts));
            }
        }

        private int _selectedIndexRepairManualDataGrid;
        public int SelectedIndexRepairManualDataGrid
        {
            get => _selectedIndexRepairManualDataGrid;
            set
            {
                _selectedIndexRepairManualDataGrid = value;
                OnPropertyChanged(nameof(SelectedIndexRepairManualDataGrid));
            }
        }


        private RepairManualRadiostantion _repairManual;
        public RepairManualRadiostantion SelectedRepairManualRadiostantion
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

        private IList _selectedModels = new ArrayList();
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
                new ObservableCollection<RepairManualRadiostantion>();
            AddRepairManualModelRadiostationForDocumentInDB =
                new ViewModelCommand(ExecuteAddRepairManualModelRadiostationForDocumentInDBCommand);
            ChangeRepairManualModelRadiostationForDocumentInDB =
                new ViewModelCommand(ExecuteChangeRepairManualModelRadiostationForDocumentInDBCommand);
            DeleteRepairManualModelRadiostationForDocumentInDB =
                 new ViewModelCommand(ExecuteDeleteRepairManualModelRadiostationForDocumentInDBCommand);
            GetRepairManualRadiostantionsCollections();
        }



        #region DeleteRepairManualModelRadiostationForDocumentInDB

        private void ExecuteDeleteRepairManualModelRadiostationForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете удаление?", "Внимание",
                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (RepairManualMulipleSelectedDataGrid == null ||
                RepairManualMulipleSelectedDataGrid.Count == 0)
                return;
            TEMPORARY_INDEX_DATAGRID = SelectedIndexRepairManualDataGrid;
            foreach (RepairManualRadiostantion repairManualRadiostantion
                in RepairManualMulipleSelectedDataGrid)
                _repairManualModelRepository.DeleteRepairManualModelRadiostationForDocumentInDB(
                    repairManualRadiostantion.IdBase);
            GetRepairManualRadiostantionsCollections();
            GetRowAfterChangeRepairManualInDataGrid(TEMPORARY_INDEX_DATAGRID);
        }

        #endregion

        #region ChangeRepairManualModelRadiostationForDocumentInDB

        private void ExecuteChangeRepairManualModelRadiostationForDocumentInDBCommand(object obj)
        {
            if (MessageBox.Show("Подтверждаете изменение?", "Внимание",
                  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            if (String.IsNullOrWhiteSpace(Model)
                || String.IsNullOrWhiteSpace(CompletedWorks)
                || String.IsNullOrWhiteSpace(Parts))
                return;
            if(SelectedRepairManualRadiostantion == null) return;
            if (_repairManualModelRepository.ChangeRepairManualModelRadiostationForDocumentInDB(
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

        private void ExecuteAddRepairManualModelRadiostationForDocumentInDBCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Model) 
                || String.IsNullOrWhiteSpace(CompletedWorks) 
                || String.IsNullOrWhiteSpace(Parts))
                return;
            if(_repairManualModelRepository.AddRepairManualModelRadiostationForDocumentInDB(
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

        private void GetRepairManualRadiostantionsCollections()
        {
            if (RepairManualRadiostantionsCollections.Count != 0)
                RepairManualRadiostantionsCollections.Clear();
            RepairManualRadiostantionsCollections =
                _repairManualModelRepository.GetRepairManualRadiostantionsCollections(
                    RepairManualRadiostantionsCollections, UserModelStatic.model);
        }
        private void GetRowAfterAddingRadiostantionInDataGrid()
        {
            SelectedIndexRepairManualDataGrid = RepairManualRadiostantionsCollections.Count - 1;
        }
        private void GetRowAfterChangeRepairManualInDataGrid(int temporaryIndexDataGrid)
        {
            SelectedIndexRepairManualDataGrid = temporaryIndexDataGrid;
        }

    }
}
