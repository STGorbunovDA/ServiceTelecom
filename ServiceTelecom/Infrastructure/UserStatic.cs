namespace ServiceTelecom.Models
{
    public class UserStatic
    {
        public static string Login { get; set; }
        public static string Post { get; set; }
        public UserStatic(string login, string post)
        {
            Login = login.Trim();
            Post = post;
        }
      
    }
}
