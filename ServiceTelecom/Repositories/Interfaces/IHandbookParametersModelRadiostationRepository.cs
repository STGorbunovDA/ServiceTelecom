using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IHandbookParametersModelRadiostationRepository
    {
        /// <summary> Получение справочника параметров на модель </summary>
        ObservableCollection<HandbookParametersModelRadiostationModel>
            GetHandbookParametersAtModelForCollection(
            ObservableCollection<HandbookParametersModelRadiostationModel>
            handbookParametersModelRadiostationCollection, string model);
    }
}
