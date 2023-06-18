using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IFrequenciesDataBaseRepository
    {
        /// <summary> Получение частот </summary>
        ObservableCollection<FrequencyModel> GetFrequencyDataBase(
            ObservableCollection<FrequencyModel> FrequenciesCollections);

        /// <summary> Добавление частоты /summary>
        bool AddFrequencyDataBase(string frequency);

        /// <summary> Удаление частоты</summary>
        bool DeleteFrequencyDataBase(int idBase);
    }
}
