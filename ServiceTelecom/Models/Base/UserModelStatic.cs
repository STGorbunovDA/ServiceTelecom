using ServiceTelecom.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ServiceTelecom.Models
{
    public class UserModelStatic
    {
        public static string LOGIN { get; private set; }
        public static string POST { get; private set; }
        public UserModelStatic(string login, string post)
        {
            LOGIN = Encryption.DecryptCipherTextToPlainText(login.Trim());
            POST = Encryption.DecryptCipherTextToPlainText(post);
        }    
    }
}
