using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class User
    {
        private bool isAdmin;
        private string username;
        private string password;
        private string email;
        public User (string username, string password, string email, bool isAdmin)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.isAdmin = isAdmin;
        }

    }
}
