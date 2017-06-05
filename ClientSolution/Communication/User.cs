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
    public class User
    { private static readonly User USER = new User();
      private string username;
      private string email;
      private string password;
      private int moneyBalance;

        private User()
        {
           username = "";
           email = "";
           password = "";
           moneyBalance = -1;

        }
        public static User GetUser()
        {
            return USER;
        }
        public string GetUsername()
        {
            return username;
        }
        public string GetEmail()
        {
            return email;
        }

        public string GetPassword()
        {
            return password;
        }

        public int GetMoneyBalance()
        {
            return moneyBalance;
        }

        public void SetUserName(string username)
        {
            USER.username = username;
        }

        public void SetPassword(string password)
        {
            USER.password = password;
        }

        public void SetEmail(string email)
        {
           USER.email = email;
        }

        public void SetMoneyBalance(int moneyBalance)
        {
            USER.moneyBalance = moneyBalance;
        }

        public bool IsSet()
        {
            return (moneyBalance >= 0 && !email.Equals("") && !username.Equals("") && !password.Equals(""));

        }


    }
}
