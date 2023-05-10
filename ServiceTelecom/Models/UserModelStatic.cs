using ServiceTelecom.Infrastructure;

namespace ServiceTelecom.Models
{
    public class UserModelStatic
    {
        public static string Login { get; private set; }
        public static string Post { get; private set; }//TODO продумать
        public UserModelStatic(string login, string post)
        {
            Login = Encryption.DecryptCipherTextToPlainText(login.Trim());
            Post = Encryption.DecryptCipherTextToPlainText(post);
        }
      
    }
}
