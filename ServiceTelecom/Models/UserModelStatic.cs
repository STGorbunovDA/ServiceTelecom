using ServiceTelecom.Infrastructure;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Models
{
    public class UserModelStatic
    {
        public const string priceAnalog = "1411.18";
        public const string priceDigital = "1919.57";
        public const string InRemontTechnicalServices = "ремонт";
        public const string PassedTechnicalServices = "прошла проверку";
        public const string InWorkTechnicalServices = "В работе";

        public const string UnitMeasureForCheckBox = "1";
        
        /// <summary> необходима для ремонтов</summary>
        public static string model = string.Empty;

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
