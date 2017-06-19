using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class UserInfo
    { private static readonly UserInfo USER = new UserInfo();
      private string username;
      private string password;

        private UserInfo()
        {
           username = "";
           password = "";
        }
        public static UserInfo GetUser()
        {
            return USER;
        }
        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }


        public void SetUserName(string username)
        {
            USER.username = username;
        }

        public void SetPassword(string password)
        {
            USER.password = password;
        }



    }
}
