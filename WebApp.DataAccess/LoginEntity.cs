using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class LoginEntityBase
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Type { get; set; }

    }
    public class LoginEntity : LoginEntityBase
    {
        public string Login_Info
        {
            get
            {
                return "Username: " + Username + "Login Type: " + (Type ? "Manager" : "Customer");
            }
        }
    }
}
