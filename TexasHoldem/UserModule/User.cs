namespace TexasHoldem.UserModule
{
    public class UserRank
    {
        public UserRank()
        {
            Points = 0;
            NumOfCalibrationsLeft = 10;
        }

        public int Points { get; set; }
        public int NumOfCalibrationsLeft { get; set; }
    }

    public class User
    {
        private string password;

        public User(string username, string password, string email, bool isAdmin, int money)
        {
            Username = username;
            if (password.Equals(""))
                throw new NotAPasswordException(password);
            this.password = password;
            Email = email;
            Admin = isAdmin;
            MoneyBalance = money;
            Rank = new UserRank();
            League = new DefaultLeague();
        }

        public User (string username, string password, string email, bool isAdmin)
        {
            Username = username;
            if (password.Equals(""))
                throw new NotAPasswordException(password);
            this.password = password;
            Email = email;
            Admin = isAdmin;
            Rank = new UserRank();
            League = new DefaultLeague();
            MoneyBalance = 1000;
        }

        public UserRank Rank { get; set; }

        public League League { get; set; }

        public bool Admin { get; set; }

        public string Username { get; }

        public string Email { get; }

        public int MoneyBalance { get; set; }

        public int DecreaseMoney(int money)
        {
            MoneyBalance = MoneyBalance - money;
            return MoneyBalance;
        }
        public bool CheckPassword(string password)
        {
            return this.password.Equals(password);
        }
    }
}