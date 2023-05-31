using System.Collections.ObjectModel;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface ISaveRadiostationsForDocumets<T> where T : class
    {
        /// <summary> Сохранить радиостанции для документов </summary>
        void SaveRadiostationsForDocumets(string city,
            ObservableCollection<T>
            radiostationsForDocumentsCollection);

        /// <summary> Сохранить все характеристики радиостанций общая база </summary>
        void SaveRadiostationsFull(string city,
            ObservableCollection<T>
            radiostationsForDocumentsCollection);
    }
}
