using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IHandbookParametersModelRadiostationRepository
    {
        /// <summary> Получение справочника параметров для и по модели </summary>
        ObservableCollection<HandbookParametersModelRadiostationModel>
            GetHandbookParametersByModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersModelRadiostationCollection, string model);

        /// <summary> Получение справочника параметров для всех типов моделей </summary>
        ObservableCollection<HandbookParametersModelRadiostationModel>
            GetHandbookParametersAllModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersModelCollection);
    }
}
