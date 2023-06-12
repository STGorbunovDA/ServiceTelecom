using ServiceTelecom.Models;
using System.Collections.Generic;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface IGetSetRegistryServiceTelecomSetting
    {
        /// <summary> Запись в реестр Login </summary>
        void SetRegistryUser(string user);

        /// <summary> Получение из реестра Login </summary>
        string GetRegistryUser();

        /// <summary> Запись в реестр City </summary>
        void SetRegistryCity(string city);

        /// <summary> Получение из реестра City </summary>
        string GetRegistryCity();

        /// <summary> Сохранить город для отображения после добавления или изменения радиостанции </summary>
        void SetRegistryCityForAddChangeDelete(string city);

        /// <summary> Получить город для отображения после добавления или изменения радиостанции </summary>
        string GetRegistryCityForAddChangeDelete();

        /// <summary> Сохранить номера актов на подпись </summary>
        void SetRegistryNumberActForSignCollections(string numberActSignCollections);

        /// <summary> Получить номера актов на подпись </summary>
        string GetRegistryNumberActForSignCollections();

        /// <summary> Сохранить номера актов для заполнения </summary>
        void SetRegistryNumberActForFillOutCollections(string numberActFillOutCollections);

        /// <summary> Получить номера актов для заполнения </summary>
        string GetRegistryNumberActForFillOutCollections();

        /// <summary> Запись данных о предприятии для ремонта </summary>
        bool SetRepairData(string company, string okpo, string be,
            string fullNameCompany, string chiefСompanyFIO, string chiefСompanyPost,
            string chairmanСompanyFIO, string chairmanСompanyPost,
            string firstMemberCommissionFIO, string firstMemberCommissionPost,
            string secondMemberCommissionFIO, string secondMemberCommissionPost,
            string thirdMemberCommissionFIO, string thirdMemberCommissionPost);

        /// <summary> Получение данных о предприятии для ремонта </summary>
        List<RepairDataCompanyModel> GetRepairData(string company);
    }
}
