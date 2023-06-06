using ServiceTelecom.Infrastructure;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Models
{
    public class UserModelStatic
    {
        public const string priceAnalogTO = "1411.18";
        public const string priceDigitalTO = "1919.57";
        public const string InRepairTechnicalServices = "ремонт";
        public const string PassedTechnicalServices = "прошла проверку";
        public const string InWorkTechnicalServices = "В работе";

        public const string UnitMeasureForCheckBox = "1";

        public const string priceRepairAnalogCategory_3 = "887.94";
        public const string priceRepairAnalogCategory_4 = "1267.49";
        public const string priceRepairAnalogCategory_5 = "2535.97";
        public const string priceRepairAnalogCategory_6 = "5071.94";

        public const string priceRepairDigitalCategory_3 = "895.86";
        public const string priceRepairDigitalCategory_4 = "1280.37";
        public const string priceRepairDigitalCategory_5 = "2559.75";
        public const string priceRepairDigitalCategory_6 = "5119.51";

        public const string Category_3 = "3";
        public const string Category_4 = "4";
        public const string Category_5 = "5";
        public const string Category_6 = "6";

       
        /// <summary> необходима для ремонтов</summary>
        public static string road = string.Empty;
        /// <summary> необходима для ремонтов</summary>
        public static string city = string.Empty;
        /// <summary> необходима для ремонтов</summary>
        public static string model = string.Empty;
        /// <summary> необходима для ремонтов</summary>
        public static string serialNumber = string.Empty;

        public static ObservableCollection<StaffRegistrationDataBaseModel> 
            StaffRegistrationsDataBaseModelCollection { get; set; }

        public static string Login { get; private set; }
        public static string Post { get; private set; }//TODO продумать
        public UserModelStatic(string login, string post)
        {
            Login = Encryption.DecryptCipherTextToPlainText(login.Trim());
            Post = Encryption.DecryptCipherTextToPlainText(post);
            StaffRegistrationsDataBaseModelCollection = 
                new ObservableCollection<StaffRegistrationDataBaseModel>();
        }    
    }
}
