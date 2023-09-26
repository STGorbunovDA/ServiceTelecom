using ServiceTelecom.Models;
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

                if (UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Count != 0)
                    UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Clear();

                UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Add(value);

                _selectedRadiostation = value;
                OnPropertyChanged(nameof(SelectedRadiostation));
            }
        }

        public RepeatsRadiostationViewModel()
        {
            RadiostationsForDocumentsCollection =
                new ObservableCollection<RadiostationForDocumentsDataBaseModel>();

            foreach (var item in UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID)
                RadiostationsForDocumentsCollection.Add((RadiostationForDocumentsDataBaseModel)item);
            UserModelStatic.RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID.Clear();
        }
    }
}
