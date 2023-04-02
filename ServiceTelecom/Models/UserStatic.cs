using ServiceTelecom.Infrastructure;
using ServiceTelecom.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTelecom.Models
{
    public class UserStatic
    {
        public static string Login { get; set; }
        public static  string Post { get; set; }
        public UserStatic(string login, string post)
        {
            Login = login.Trim();
            Post = post;
        }
      
    }
}
