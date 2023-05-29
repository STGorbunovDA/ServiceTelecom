using ServiceTelecom.Models;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Repositories.Interfaces
{
    public interface IWorkRepositoryRadiostantionFull
    {
        /// <summary>
        /// Проверка наличия радиостанции в общей БД всех радиостанций
        /// </summary>
        /// <param name="road"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        bool CheckSerialNumberForDocumentInDataBaseRadiostantionFull(string road, string serialNumber);

        /// <summary>
        /// Метод изменения радиостанции в radiostantionFull(общей БД)
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
        /// Метод добавления радиостанции в radiostantionFull(общей БД)
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
    }
}
