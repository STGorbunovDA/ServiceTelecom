using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IRoadDataBase
    {
        ObservableCollection<string> GetRoadDataBase(ObservableCollection<string> roadCollections);
    }
}
