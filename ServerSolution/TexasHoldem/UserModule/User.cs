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
        public User(string username, string password, string email, int money)
        {
            Username = username;
            if (password.Equals(""))
                throw new NotAPasswordException("");
            this.password = password;
            Email = email;
            MoneyBalance = money;
            Rank = new UserRank();
            League = new DefaultLeague();
        }

        public User (string username, string password, string email)
        {
            Username = username;
            if (password.Equals(""))
                throw new NotAPasswordException("");
            this.password = password;
            Email = email;
            Rank = new UserRank();
            League = new DefaultLeague();
            MoneyBalance = 1000;
        }

        public UserRank Rank { get; set; }

        public League League { get; set; }

        public string Username { get; set; }

        private string password;

        public string Email { get; set; }

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