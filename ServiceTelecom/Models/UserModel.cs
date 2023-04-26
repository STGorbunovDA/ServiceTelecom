namespace ServiceTelecom.Models
{
    public class UserModel
    {
        public static string Login { get; private set; }
        public static string Post { get; private set; }//TODO продумать
        public UserModel(string login, string post)
        {
            Login = login.Trim();
            Post = post;
        }
      
    }
}
