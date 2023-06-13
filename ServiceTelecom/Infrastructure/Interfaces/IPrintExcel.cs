using ServiceTelecom.Models;
using System.Collections.Generic;

namespace ServiceTelecom.Infrastructure.Interfaces
{
    internal interface IPrintExcel
    {
        /// <summary> Печать акта технического обслуживания </summary>
        void PrintExcelNumberActTechnicalWork(
            List<RadiostationForDocumentsDataBaseModel>
            radiostantionsCollection);

        /// <summary> Печать акта ремонта </summary>
        void PrintExcelNumberActRepair(string company, string okpo, string be,
            string fullNameCompany, string chiefСompanyFIO, string chiefСompanyPost,
            string chairmanСompanyFIO, string chairmanСompanyPost,
            string firstMemberCommissionFIO, string firstMemberCommissionPost,
            string secondMemberCommissionFIO, string secondMemberCommissionPost,
            string thirdMemberCommissionFIO, string thirdMemberCommissionPost,
            string primaryMeans, string productName);

        /// <summary> Печать акта списания </summary>
        void PrintWordDecommissionNumberAct(
            List<RadiostationForDocumentsDataBaseModel>
            radiostantionsCollection);
    }
}
