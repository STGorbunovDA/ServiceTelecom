using ServiceTelecom.Infrastructure;
using System.Collections;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Models
{
    public class UserModelStatic
    {
        public const string NULL_PRICE_TECHNICAL_SERVICES = "0.0";
        public const string PRICE_ANALOG_TECHNICAL_SERVICES = "1411.18";
        public const string PRICE_DIGITAL_TECHNICAL_SERVICES = "1919.57";
        public const string IN_REPAIR_TECHNICAL_SERVICES = "ремонт";
        public const string PASSED_TECHNICAL_SERVICES = "прошла проверку";
        public const string IN_WORK_TECHNICAL_SERVICES = "В работе";
        public const string DECOMMISSION_RADIOSTANTION = "списана";

        public const string UNIT_MEASURE_FOR_CHECKBOX = "1";

        public const string PRICE_REPAIR_ANALOG_CATEGORY_3 = "887.94";
        public const string PRICE_REPAIR_ANALOG_CATEGORY_4 = "1267.49";
        public const string PRICE_REPAIR_ANALOG_CATEGORY_5 = "2535.97";
        public const string PRICE_REPAIR_ANALOG_CATEGORY_6 = "5071.94";

        public const string PRICE_REPAIR_DIGITAL_CATEGORY_3 = "895.86";
        public const string PRICE_REPAIR_DIGITAL_CATEGORY_4 = "1280.37";
        public const string PRICE_REPAIR_DIGITAL_CATEGORY_5 = "2559.75";
        public const string PRICE_REPAIR_DIGITAL_CATEGORY_6 = "5119.51";

        public const string CATEGORY_3 = "3";
        public const string CATEGORY_4 = "4";
        public const string CATEGORY_5 = "5";
        public const string CATEGORY_6 = "6";

        public static string FREQUENCY = null;

        /// <summary> необходима для ремонтов</summary>
        public static string ROAD = string.Empty;
        /// <summary> необходима для ремонтов</summary>
        public static string CITY = string.Empty;
        /// <summary> необходима для ремонтов</summary>
        public static string MODEL = string.Empty;
        /// <summary> необходима для ремонтов</summary>
        public static string SERIAL_NUMBER = string.Empty;

        public static ObservableCollection<StaffRegistrationDataBaseModel> 
            STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION { get; set; }

        public static IList RADIOSTATIONS_FOR_DOCUMENTS_MULIPLE_SELECTED_DATAGRID;
        public static IList PARAMETERS_RADIOSTATION_FOR_ADD_RADIOSTATION_PARAMETERS_VIEW;
        public static IList PARAMETERS_RADIOSTATION_GENERAL;

        public static string LOGIN { get; private set; }
        public static string POST { get; private set; }//TODO продумать
        public UserModelStatic(string login, string post)
        {
            LOGIN = Encryption.DecryptCipherTextToPlainText(login.Trim());
            POST = Encryption.DecryptCipherTextToPlainText(post);
            STAFF_REGISTRATIONS_DATABASE_MODEL_COLLECTION = 
                new ObservableCollection<StaffRegistrationDataBaseModel>();
        }    
    }
}
