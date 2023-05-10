﻿using ServiceTelecom.Infrastructure;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Models
{
    public class UserModelStatic
    {
        //TODO решить проблему StaffRegistrationsDataBaseModelCollection
        public static ObservableCollection<StaffRegistrationDataBaseModel> StaffRegistrationsDataBaseModelCollection { get; set; }
        public static string Login { get; private set; }
        public static string Post { get; private set; }//TODO продумать
        public UserModelStatic(string login, string post)
        {
            Login = Encryption.DecryptCipherTextToPlainText(login.Trim());
            Post = Encryption.DecryptCipherTextToPlainText(post);
            StaffRegistrationsDataBaseModelCollection = new ObservableCollection<StaffRegistrationDataBaseModel>();
        }    
    }
}
