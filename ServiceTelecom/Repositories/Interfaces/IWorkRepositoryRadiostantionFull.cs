﻿namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IWorkRepositoryRadiostantionFull
    {
        /// <summary>
        /// Проверка наличия радиостанции в radiostantionFull(общей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        bool CheckSerialNumberForDocumentInDataBaseRadiostantionFull(
            string road, string serialNumber);

        /// <summary>
        /// Метод изменения радиостанции в radiostantionFull(общей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="numberAct"></param>
        /// <param name="dateMaintenanceDataBase"></param>
        /// <param name="representative"></param>
        /// <param name="numberIdentification"></param>
        /// <param name="dateOfIssuanceOfTheCertificateDataBase"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="post"></param>
        /// <param name="comment"></param>
        /// <param name="city"></param>
        /// <param name="location"></param>
        /// <param name="poligon"></param>
        /// <param name="company"></param>
        /// <param name="model"></param>
        /// <param name="serialNumber"></param>
        /// <param name="inventoryNumber"></param>
        /// <param name="networkNumber"></param>
        /// <param name="price"></param>
        /// <param name="battery"></param>
        /// <param name="manipulator"></param>
        /// <param name="antenna"></param>
        /// <param name="charger"></param>
        /// <param name="remont"></param>
        /// <returns></returns>
        bool ChangeRadiostationFullForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber,
            string post, string comment, string city, string location, string poligon,
            string company, string model, string serialNumber, string inventoryNumber,
            string networkNumber, string price, string battery, string manipulator,
            string antenna, string charger, string remont);

        /// <summary>
        /// Метод добавления радиостанции в radiostantionFull(общей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="numberAct"></param>
        /// <param name="dateMaintenanceDataBase"></param>
        /// <param name="representative"></param>
        /// <param name="numberIdentification"></param>
        /// <param name="dateOfIssuanceOfTheCertificateDataBase"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="post"></param>
        /// <param name="comment"></param>
        /// <param name="city"></param>
        /// <param name="location"></param>
        /// <param name="poligon"></param>
        /// <param name="company"></param>
        /// <param name="model"></param>
        /// <param name="serialNumber"></param>
        /// <param name="inventoryNumber"></param>
        /// <param name="networkNumber"></param>
        /// <param name="price"></param>
        /// <param name="battery"></param>
        /// <param name="manipulator"></param>
        /// <param name="antenna"></param>
        /// <param name="charger"></param>
        /// <param name="remont"></param>
        /// <returns></returns>
        bool AddRadiostationFullForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber,
            string post, string comment, string city, string location,
            string poligon, string company, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string price,
            string battery, string manipulator, string antenna, string charger,
            string remont);

        /// <summary>
        /// Изменить номер акта списания в radiostantionFull (общая таблица)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="serialNumber"></param>
        /// <param name="decommissionNumberAct"></param>
        /// <returns></returns>
        bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantionFull(
            string road, string city, string serialNumber, string decommissionNumberAct);

        /// <summary>
        /// метод изменения Представителя предприятия 
        /// и его характеристик удостоверения по акту, городу 
        /// и дороге в radiostantionFull (общая таблица)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="numberAct"></param>
        /// <param name="dateOfIssuanceOfTheCertificateDataBase"></param>
        /// <param name="representative"></param>
        /// <param name="numberIdentification"></param>
        /// <param name="post"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        bool ChangeByNumberActRepresentativeForDocumentInDBRadiostantionFull(
            string road, string city, string numberAct,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary>
        /// метод изменения Представителя предприятия 
        /// и его характеристик удостоверения по предприятию, городу 
        /// и дороге в radiostantionFull (общая таблица)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="numberAct"></param>
        /// <param name="dateOfIssuanceOfTheCertificateDataBase"></param>
        /// <param name="representative"></param>
        /// <param name="numberIdentification"></param>
        /// <param name="post"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        bool ChangeByCompanyRepresentativeForDocumentInDBRadiostantionFull(
            string road, string city, string company,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary>
        /// Изменить номер акта в radiostantionFull(общей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="serialNumber"></param>
        /// <param name="numberAct"></param>
        /// <returns></returns>
        bool ChangeNumberActBySerialNumberInDBRadiostationFull(
            string road, string city, string serialNumber, string numberAct);
    }
}
