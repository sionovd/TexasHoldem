using Domain.DomainLayerExceptions;

namespace Domain.UserModule
{
    public class Statistics
    {
        public int Points { get; set; }
        public int NumOfGames { get; set; }
        public int TotalGrossProfit { get; set; }
        public int HighestCashGain { get; set; }
        public int AvgGrossProfit { get; set; }
        public int AvgCashGain { get; set; }

        public Statistics()
        {
            Points = 0;
            NumOfGames = 0;
            TotalGrossProfit = 0;
            HighestCashGain = 0;
            AvgGrossProfit = 0;
            AvgCashGain = 0;
        }
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
            Stats = new Statistics();
            League = new DefaultLeague();
        }

        public User (string username, string password, string email)
        {
            Username = username;
            if(username.Equals(""))
                throw new DomainException("Invalid username - can't be empty");
            if (password.Equals(""))
                throw new NotAPasswordException("");
            this.password = password;
            Email = email;
            Stats = new Statistics();
            League = new DefaultLeague();
            MoneyBalance = 1000;
        }

        public Statistics Stats { get; set; }

        public League League { get; set; }

        public string Username { get; set; }

        private string password;

        public string Email { get; set; }

        public int MoneyBalance { get; set; }

        public int IncreaseMoney(int money)
        {
            MoneyBalance = MoneyBalance + money;
            return MoneyBalance;
        }

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