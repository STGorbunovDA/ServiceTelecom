using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IProblemModelRadiostantionRepository
    {
        /// <summary> Получение неисправностей радиостанций </summary>
        ObservableCollection<ProblemModelRadiostantionDataBaseModel>
            GetProblemModelRadiostantionDataBase(
            ObservableCollection<ProblemModelRadiostantionDataBaseModel>
            problemModelCollections);
        /// <summary> Добавление неисправности радиостанции</summary>
        bool AddProblemModelDataBase(string problemUser);

        /// <summary> Удаление неисправности радиостанции</summary>
        bool DeleteProblemModelDataBase(string problemUser);
    }
}
