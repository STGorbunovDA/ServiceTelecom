using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IWorkRepositoryRadiostantion
    {
        /// <summary> Загрузка всех радиостанций по дороге и городу в radiostantion(рабочей таблице) </summary>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetRadiostationsForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city);

        /// <summary> Загрузка городов из БД по дороге из radiostantion(рабочей таблице) </summary>
        ObservableCollection<string> GetCityAlongRoadForCityCollection(
            string road,ObservableCollection<string> cityCollections);

        /// <summary> Добавление радиостанции в в radiostantion(рабочую таблицу) </summary>
        bool AddRadiostationForDocumentInDataBase(string road, string numberAct,
            string dateMaintenance, string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificate, string phoneNumber, string post,
            string comment, string city, string location, string poligon, string company,
            string model, string serialNumber, string inventoryNumber, string networkNumber,
            string price, string battery, string manipulator, string antenna, string charger,
            string remont);

        /// <summary> Проверка нахождения радиостанции по дороге и городу, в radiostantion(рабочей таблице) </summary>
        bool CheckSerialNumberForDocumentInDataBaseRadiostantion(
            string road, string serialNumber);

        /// <summary>Проверка наличия более 20 штук Радиостанций в акте по дороге и городу, нужно для формирования документа Excel в radiostantion(рабочей таблице) </summary>
        bool CheckNumberActOverTwentyForDocumentInDataBase(
            string road, string city, string numberAct);

        /// <summary> Изменить номер акта в radiostantion(рабочей таблице) </summary>
        bool ChangeNumberActBySerialNumberInDataBase(string road,
            string city, string serialNumber, string numberAct);

        /// <summary> Изменить номер акта списания в radiostantion (рабочая таблица) </summary>
        bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantion(
            string road, string city, string serialNumber, string decommissionNumberAct);

        /// <summary> Метод изменения Представителя предприятия и его характеристик удостоверения по акту, городу и дороге текущей radiostantion (рабочая таблица) </summary>
        bool ChangeByNumberActRepresentativeForDocumentInDataBase(
            string road, string city, string numberAct,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary> Метод изменения Представителя предприятия и его характеристик удостоверения по предприятию, городу и дороге текущей radiostantion (рабочая таблица) </summary>
        bool ChangeByCompanyRepresentativeForDocumentInDataBase(
            string road, string city, string company,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary> Метод изменения радиостанции в radiostantion(рабочей таблице) </summary>
        bool ChangeRadiostationForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber,
            string post, string comment, string city, string location,
            string poligon, string company, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string price,
            string battery, string manipulator, string antenna,
            string charger, string remont);

        /// <summary> Удаление радиостанции из radiostantion(рабочей таблицы) </summary>
        void DeleteRadiostationFromDataBase(int idBase);
    }
}
