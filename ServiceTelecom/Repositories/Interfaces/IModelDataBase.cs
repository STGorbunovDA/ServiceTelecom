using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IModelDataBase
    {
        ObservableCollection<string> GetModelDataBase(ObservableCollection<string> modelCollections);
    }
}
