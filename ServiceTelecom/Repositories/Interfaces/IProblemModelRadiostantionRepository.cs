using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IProblemModelRadiostantionRepository
    {
        ObservableCollection<ProblemModelRadiostantionDataBaseModel>
            GetProblemModelRadiostantionDataBase(ObservableCollection<ProblemModelRadiostantionDataBaseModel>
            problemModelCollections);
        bool AddProblemModelDataBase(string problemUser);
        bool DeleteProblemModelDataBase(string problemUser);
    }
}
