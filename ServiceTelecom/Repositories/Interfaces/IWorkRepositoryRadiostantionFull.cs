namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IWorkRepositoryRadiostantionFull
    {
        /// <summary>Проверка наличия радиостанции в radiostantionFull(общей таблице)</summary>
        bool CheckSerialNumberForDocumentInDataBaseRadiostantionFull(
            string road, string serialNumber);

        /// <summary>Метод изменения радиостанции в radiostantionFull(общей таблице)</summary>
        bool ChangeRadiostationFullForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber,
            string post, string comment, string city, string location, string poligon,
            string company, string model, string serialNumber, string inventoryNumber,
            string networkNumber, string price, string battery, string manipulator,
            string antenna, string charger, string remont);

        /// <summary>Метод добавления радиостанции в radiostantionFull(общей таблице) </summary>
        bool AddRadiostationFullForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber,
            string post, string comment, string city, string location,
            string poligon, string company, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string price,
            string battery, string manipulator, string antenna, string charger,
            string remont);

        /// <summary> Изменить номер акта списания в radiostantionFull (общая таблица) </summary>
        bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantionFull(
            string road, string city, string serialNumber, string decommissionNumberAct);

        /// <summary> Метод изменения Представителя предприятия и его характеристик удостоверения по акту, городу  и дороге в radiostantionFull (общая таблица)</summary>
        bool ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull(
            string road, string city, string numberAct,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary> Метод изменения Представителя предприятия и его характеристик удостоверения по предприятию, городу и дороге в radiostantionFull (общая таблица)</summary>
        bool ChangeByCompanyRepresentativeForDocumentInDBRadiostantionFull(
            string road, string city, string company,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary>Изменить номер акта в radiostantionFull(общей таблицы) </summary>
        bool ChangeNumberActBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberAct);

        /// <summary>Получаем основное средство из radiostantionFull(общей таблицы) </summary>
        string GetPrimaryMeansInDataBase(string serialNumber, string city, string road);

        /// <summary>Получаем наименование объекта из radiostantionFull(общей таблицы) </summary>
        string GetProductNameInDataBase(string serialNumber, string city, string road);

        /// <summary>Изменение акта ремонта в radiostantionFull(общей таблице) </summary>
        bool ChangeNumberActRepairBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberActRepair);
    }
}
