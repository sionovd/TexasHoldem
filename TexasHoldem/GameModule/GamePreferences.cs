namespace TexasHoldem.GameModule
{

    public class GamePreferences
    {
        private int gameType;
        private int buyIn;
        private int chipPolicy;
        private int minBet;
        private int maxPlayers;
        private int minPlayers;
        private bool spectateGame;

        public GamePreferences()
        {
            gameType = 1;
            buyIn = 5;
            chipPolicy = 100;
            minBet = 5;
            maxPlayers = 9;
            minPlayers = 2;
            spectateGame = true;
        }

        public GamePreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers, bool spectateGame)
        {
            this.gameType = gameType;
            this.buyIn = buyIn;
            this.chipPolicy = chipPolicy;
            this.minBet = minBet;
            this.maxPlayers = maxPlayers;
            this.MinPlayers = minPlayers;
            this.spectateGame = spectateGame;
        }

        public int GameType
        {
            get
            {
                return gameType;
            }

            set
            {
                gameType = value;
            }
        }

        public int BuyIn
        {
            get
            {
                return buyIn;
            }

            set
            {
                buyIn = value;
            }
        }

        public int ChipPolicy
        {
            get
            {
                return chipPolicy;
            }

            set
            {
                chipPolicy = value;
            }
        }

        public int MinBet
        {
            get
            {
                return minBet;
            }

            set
            {
                minBet = value;
            }
        }

        public int MaxPlayers
        {
            get
            {
                return maxPlayers;
            }

            set
            {
                maxPlayers = value;
            }
        }

        public int MinPlayers
        {
            get
            {
                return minPlayers;
            }

            set
            {
                minPlayers = value;
            }
        }

        public bool SpectateGame
        {
            get
            {
                return spectateGame;
            }

            set
            {
                spectateGame = value;
            }
        }
    }

}