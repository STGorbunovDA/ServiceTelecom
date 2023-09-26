using ServiceTelecom.Models;
using ServiceTelecom.Models.Base;
using System.Collections.ObjectModel;

namespace ServiceTelecom.ViewModels.WorkViewModelPackage
{
    public class RepeatsRadiostationViewModel : ViewModelBase
    {
        public ObservableCollection<RadiostationForDocumentsDataBaseModel> RadiostationsForDocumentsCollection { get; set; }

        RadiostationForDocumentsDataBaseModel _selectedRadiostation;
        public RadiostationForDocumentsDataBaseModel SelectedRadiostation
        {
            get => _selectedRadiostation;
            set
            {
                if (value == null)
                    return;

                if (GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Count != 0)
                    GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Clear();

                GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Add(value);

                _selectedRadiostation = value;
                OnPropertyChanged(nameof(SelectedRadiostation));
            }
        }

        public RepeatsRadiostationViewModel()
        {
            RadiostationsForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();

            foreach (var item in GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
                RadiostationsForDocumentsCollection.Add((RadiostationForDocumentsDataBaseModel)item);
            GlobalCollection.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Clear();
        }
    }
}
