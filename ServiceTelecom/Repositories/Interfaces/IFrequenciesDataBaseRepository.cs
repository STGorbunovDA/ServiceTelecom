using ServiceTelecom.Models;
using System.Collections.Generic;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IFrequenciesDataBaseRepository
    {
        /// <summary> Получение частот радиостанции </summary>
        List<FrequencyModel> GetFrequencyDataBase(
            List<FrequencyModel> FrequenciesCollections);
    }
}
