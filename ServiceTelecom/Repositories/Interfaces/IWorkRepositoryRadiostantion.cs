﻿using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IWorkRepositoryRadiostantion
    {
        /// <summary>
        /// Загрузка всех радиостанций по дороге и городу в radiostantion(рабочей таблице)
        /// </summary>
        /// <param name="radiostationsForDocumentsCollection"></param>
        /// <param name="roadCollections"></param>
        /// <returns></returns>
        ObservableCollection<RadiostationForDocumentsDataBaseModel>
            GetRadiostationsForDocumentsCollection(
            ObservableCollection<RadiostationForDocumentsDataBaseModel>
            radiostationsForDocumentsCollection, string road, string city);

        /// <summary>
        /// Загрузка городов из БД по дороге из radiostantion(рабочей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="cityCollections"></param>
        /// <returns></returns>
        ObservableCollection<string> GetCityAlongRoadForCityCollection(
            string road,ObservableCollection<string> cityCollections);

        /// <summary>
        /// Добавление радиостанции в в radiostantion(рабочую таблицу)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="numberAct"></param>
        /// <param name="dateMaintenance"></param>
        /// <param name="representative"></param>
        /// <param name="numberIdentification"></param>
        /// <param name="dateOfIssuanceOfTheCertificate"></param>
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
        bool AddRadiostationForDocumentInDataBase(string road, string numberAct,
            string dateMaintenance, string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificate, string phoneNumber, string post,
            string comment, string city, string location, string poligon, string company,
            string model, string serialNumber, string inventoryNumber, string networkNumber,
            string price, string battery, string manipulator, string antenna, string charger,
            string remont);

        /// <summary>
        /// Проверка нахождения радиостанции по дороге и городу, в radiostantion(рабочей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        bool CheckSerialNumberForDocumentInDataBaseRadiostantion(
            string road, string serialNumber);

        /// <summary>
        /// Проверка наличия более 20 штук Радиостанций 
        /// в акте по дороге и городу, нужно 
        /// для формирования документа Excel
        /// в radiostantion(рабочей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="numberAct"></param>
        /// <returns></returns>
        bool CheckNumberActOverTwentyForDocumentInDataBase(
            string road, string city, string numberAct);

        /// <summary>
        /// Изменить номер акта в radiostantion(рабочей таблице)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="serialNumber"></param>
        /// <param name="numberAct"></param>
        /// <returns></returns>
        bool ChangeNumberActBySerialNumberInDataBase(string road,
            string city, string serialNumber, string numberAct);

        /// <summary>
        /// Изменить номер акта списания в radiostantion (рабочая таблица)
        /// </summary>
        /// <param name="road"></param>
        /// <param name="city"></param>
        /// <param name="serialNumber"></param>
        /// <param name="decommissionNumberAct"></param>
        /// <returns></returns>
        bool ChangeDecommissionNumberActBySerialNumberInDBRadiostantion(
            string road, string city, string serialNumber, string decommissionNumberAct);

        /// <summary>
        /// метод изменения Представителя предприятия 
        /// и его характеристик удостоверения по акту, городу 
        /// и дороге текущей radiostantion (рабочая таблица)
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
        bool ChangeByNumberActRepresentativeForDocumentInDataBase(
            string road, string city, string numberAct,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary>
        /// метод изменения Представителя предприятия 
        /// и его характеристик удостоверения по предприятию, городу 
        /// и дороге текущей radiostantion (рабочая таблица)
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
        bool ChangeByCompanyRepresentativeForDocumentInDataBase(
            string road, string city, string company,
            string dateOfIssuanceOfTheCertificateDataBase,
            string representative, string numberIdentification,
            string post, string phoneNumber);

        /// <summary>
        /// Метод изменения радиостанции в radiostantion(рабочей таблице)
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
        bool ChangeRadiostationForDocumentInDataBase(
            string road, string numberAct, string dateMaintenanceDataBase,
            string representative, string numberIdentification,
            string dateOfIssuanceOfTheCertificateDataBase, string phoneNumber,
            string post, string comment, string city, string location,
            string poligon, string company, string model, string serialNumber,
            string inventoryNumber, string networkNumber, string price,
            string battery, string manipulator, string antenna,
            string charger, string remont);
    }
}
