using ServiceTelecom.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IWorkRadiostantionRepository
    {
        /// <summary> Получение всех радиостанций по дороге и городу из radiostantion(рабочей таблице) </summary>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetRadiostationsForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city);
        
        /// <summary> Получение всех радиостанций по дороге из radiostantion(рабочей таблице) </summary>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetFullByRoadRadiostationsForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road);

        /// <summary> Получение городов из БД по дороге из radiostantion(рабочей таблице) </summary>
        Task<ObservableCollection<string>> GetCityAlongRoadForCityCollection(
             string road, ObservableCollection<string> cityCollections);

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

        /// <summary> Проверка наличия более 20 штук Радиостанций в акте по дороге и городу, нужно для формирования документа Excel в radiostantion(рабочей таблице) </summary>
        bool CheckNumberActOverTwentyForDocumentInDataBase(
            string road, string city, string numberAct);

        /// <summary> Изменить номер акта по заводскому номеру в radiostantion(рабочей таблице) </summary>
        bool ChangeNumberActBySerialNumberInDatabase(string road,
            string city, string serialNumber, string numberAct);

        /// <summary> Изменить номер акта списания в radiostantion (рабочая таблица) </summary>
        bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantion(
            string road, string city, string serialNumber, string decommissionNumberAct);

        /// <summary> Метод изменения Представителя предприятия и его характеристик удостоверения по акту, городу и дороге текущей radiostantion (рабочая таблица) </summary>
        bool ChangeByNumberActRepresentativeForDocumentInDataBase(
            string road, string city, string numberAct,
            string dateOfIssuanceOfTheCertificate,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary> Метод изменения Представителя предприятия и его характеристик удостоверения по предприятию, городу и дороге текущей radiostantion (рабочая таблица) </summary>
        bool ChangeByCompanyRepresentativeForDocumentInDataBase(
            string road, string city, string company,
            string dateOfIssuanceOfTheCertificate,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary> Метод изменения радиостанции в radiostantion(рабочей таблице) </summary>
        bool ChangeRadiostationForDocumentInDataBase(
            string road, string numberAct, string dateMaintenance,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificate, string phoneNumber,
            string post, string comment, string city, string location,
            string poligon, string company, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string price,
            string battery, string manipulator, string antenna,
            string charger, string remont);

        /// <summary> Удаление радиостанции из radiostantion(рабочей таблицы) </summary>
        void DeleteRadiostationFromDataBase(int idBase);

        /// <summary> Проверка ремонта в radiostantion(рабочей таблице) по Заводскому номеру </summary>
        bool CheckRepairInDBRadiostantionBySerialNumber(
            string road, string city, string serialNumber);

        /// <summary>Изменение акта ремонта в radiostantion(рабочей таблице) </summary>
        bool ChangeNumberActRepairBySerialNumberInDataBase(
            string road, string city, string serialNumber, string numberActRepair);

        /// <summary>Добавление ремонта в radiostantion(рабочей таблице) </summary>
        bool AddRepairRadiostationForDocumentInDataBase(
            string road, string city, string serialNumber,
            string numberActRepair, string category, string priceRepair,
            string completedWorks_1, string parts_1,
            string completedWorks_2, string parts_2,
            string completedWorks_3, string parts_3,
            string completedWorks_4, string parts_4,
            string completedWorks_5, string parts_5,
            string completedWorks_6, string parts_6,
            string completedWorks_7, string parts_7);

        /// <summary>Удаления ремонта в radiostantion(рабочей таблице) </summary>
        bool DeleteRepairRadiostationForDocumentInDataBase(
            string road, string city, string serialNumber);

        /// <summary>Добавление списания в radiostantion(рабочую таблицу) </summary>
        bool AddDecommissionNumberActRadiostationInDB(
            string road, string city, string serialNumber,
            string decommissionNumberAct, string reasonDecommissionNumberAct);

        /// <summary>Удаления списания в radiostantion(рабочая таблица) </summary>
        bool DeleteDecommissionNumberActRadiostationInDB(
            string road, string city, string serialNumber);

        /// <summary>Получение крайнего ремонта по дороге в radiostantion(рабочая таблица) </summary>
        string GetOfTheLastNumberActRepair(string road);

        /// <summary> Изменения статуса в ремонте в radiostantion(рабочая таблица) и в radiostantionFull(общую таблицу) </summary>
        bool ChangeStatusVerifiedRST(
            string road, string city, string serialNumber,
            string noteRadioStationParameters, string verifiedRST);

        /// <summary> Получение данных из radiostantionFull(общей таблицs) сколько осталось проверить </summary>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            HowMuchToCheckRadiostantionsByCityForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city);
    }
}
