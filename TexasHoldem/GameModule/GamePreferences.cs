namespace TexasHoldem.GameModule
{

    public class GamePreferences
    {
        public GamePreferences()
        {
            GameType = 1;
            BuyIn = 5;
            ChipPolicy = 100;
            MinBet = 5;
            MaxPlayers = 9;
            MinPlayers = 2;
            SpectateGame = true;
        }

        public GamePreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers, bool spectateGame)
        {
            GameType = gameType;
            BuyIn = buyIn;
            ChipPolicy = chipPolicy;
            MinBet = minBet;
            MaxPlayers = maxPlayers;
            MinPlayers = minPlayers;
            SpectateGame = spectateGame;
        }

        public int GameType { get; set; }

        public int BuyIn { get; set; }

        public int ChipPolicy { get; set; }

        public int MinBet { get; set; }

        public int MaxPlayers { get; set; }

        public int MinPlayers { get; set; }

        public bool SpectateGame { get; set; }
    }

}