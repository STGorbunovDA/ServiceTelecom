using ServiceTelecom.Repositories.Base;
using ServiceTelecom.Repositories.Interfaces;
using System;
using System.Windows;
using System.Windows.Input;

namespace ServiceTelecom.ViewModels.Base
{
    internal class RepairManualViewModel : ViewModelBase
    {
        RepairManualModelRepository _repairManualModelRepository;
        
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
        public ICommand AddRepairRadiostationForDocumentInDataBase { get; }
        public RepairManualViewModel()
        {
            _repairManualModelRepository = new RepairManualModelRepository();
            AddRepairRadiostationForDocumentInDataBase =
                new ViewModelCommand(ExecuteAddRepairRadiostationForDocumentInDataBaseCommand);
        }

        #region AddRepairRadiostationForDocumentInDataBase

        private void ExecuteAddRepairRadiostationForDocumentInDataBaseCommand(object obj)
        {
            if (String.IsNullOrWhiteSpace(Model) 
                || String.IsNullOrWhiteSpace(CompletedWorks) 
                || String.IsNullOrWhiteSpace(Parts))
                return;
            if(_repairManualModelRepository.AddRepairRadiostationForDocumentInDataBase(
                Model, CompletedWorks, Parts))
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK,
                   MessageBoxImage.Information);
            else MessageBox.Show("Ошибка добавления радиостанции", "Отмена",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}
