using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IFrequenciesDataBaseRepository
    {
        /// <summary> Получение частот радиостанции </summary>
        ObservableCollection<FrequencyModel> GetFrequencyDataBase(
            ObservableCollection<FrequencyModel> FrequenciesCollections);

        /// <summary> Добавление частоты радиостанции</summary>
        bool AddFrequencyDataBase(string frequency);
    }
}
