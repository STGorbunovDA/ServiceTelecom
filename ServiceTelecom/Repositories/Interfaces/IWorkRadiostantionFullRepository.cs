namespace ServiceTelecom.Repositories.Interfaces
{
    internal interface IWorkRadiostantionFullRepository
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

        /// <summary>Изменить номер акта по заводскому номеру в radiostantionFull(общей таблицы) </summary>
        bool ChangeNumberActBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberAct);

        /// <summary>Получаем основное средство из radiostantionFull(общей таблицы) </summary>
        string GetPrimaryMeansInDataBaseForRepair(string serialNumber, string city, string road);

        /// <summary>Получаем наименование объекта из radiostantionFull(общей таблицы) </summary>
        string GetProductNameInDataBaseForRepair(string serialNumber, string city, string road);

        /// <summary>Изменение акта ремонта в radiostantionFull(общей таблице) </summary>
        bool ChangeNumberActRepairBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberActRepair);

        /// <summary>Запись наименование объекта и основного средства в radiostantionFull(общей таблицы) </summary>
        bool SetPrimaryMeansAndProductNameInDataBase(
            string road, string city, string serialNumber,
            string primaryMeans, string productName);

        /// <summary>Добавление ремонта в radiostantionFull(общую таблицу) </summary>
        bool AddRepairRadiostationForDocumentInDBRadiostantionFull(
            string road, string city, string serialNumber,
            string numberActRepair, string category, string priceRepair,
            string completedWorks_1, string parts_1,
            string completedWorks_2, string parts_2,
            string completedWorks_3, string parts_3,
            string completedWorks_4, string parts_4,
            string completedWorks_5, string parts_5,
            string completedWorks_6, string parts_6,
            string completedWorks_7, string parts_7);

        /// <summary>Удаления ремонта в radiostantionFull(общей таблице) </summary>
        bool DeleteRepairRadiostationForDocumentInDBRadiostantionFull(
            string road, string city, string serialNumber);

        /// <summary>Добавление списания в radiostantionFull(общая таблица) </summary>
        bool AddDecommissionNumberActRadiostationInDBRadiostationFull(
            string road, string city, string serialNumber,
            string decommissionNumberAct, string reasonDecommissionNumberAct);

        /// <summary>Удаления списания в radiostantionFull(общей таблице) </summary>
        bool DeleteDecommissionNumberActRadiostationInDBRadiostationFull(
            string road, string city, string serialNumber);

        /// <summary> Загрузка из файла для общей базы данных </summary>
        bool LoadingFileForFullDB(string poligon, string company, 
            string location, string model, string serialNumber, 
            string inventoryNumber, string networkNumber, 
            string dateMaintenance, string numberAct, 
            string city, string price, string road);
    }
}
