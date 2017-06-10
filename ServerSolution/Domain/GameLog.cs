using System.Collections.Generic;
using Domain.GameLogInfo;
using Domain.GameModule;

namespace Domain
{
    public class GameLog
    {
        private List<string> logOfCards;
        private List<string> logOfGameStates;
        private Dictionary<int, string> logOfMoves;
        private Game game;
        private int moveLogCounter;
        public string LatestAction { get; private set; }
        public GameLog(Game game)
        {
            //this = database.getGameLog(gameLogID);
            this.game = game;
            logOfCards = new List<string>();
            logOfMoves = new Dictionary<int, string>();
            moveLogCounter = 0;
            logOfGameStates = new List<string>();
        }

        public void LogPlayerCards(Player player, Card[] cards)
        {
            PlayerCardsInfo pci = new PlayerCardsInfo(cards[0].getCardId(), cards[1].getCardId(), game.Id, player.PlayerId);
            string str = PlayerCardsInfo.ConvertToString(pci);
            LatestAction = str;
            logOfCards.Add(str);
            game.Subject.NotifyCards(player.Username);
        }

        public void LogGameState()
        {
            CardType[] tableCards = new CardType[5];
            for (int i = 0; i < 5; i++)
                tableCards[i] = game.State.TableCards[i].getCardId();
            List<PlayerInfo> playerInfos = new List<PlayerInfo>();
            foreach (var player in game.Seats)
            {
                playerInfos.Add(new PlayerInfo(player.PlayerId, player.Username, player.ChipBalance, player.AmountBetOnCurrentRound, player.Folded));
            }
            GameInfo gameInfo = new GameInfo(game.Id, game.State.Pot, game.State.CurrentStake, game.State.RoundNumber, game.State.CurrentPlayer.PlayerId, playerInfos, tableCards);
            string str = GameInfo.ConvertToString(gameInfo);
            logOfGameStates.Add(str);
            LatestAction = str;
            game.Subject.NotifyGameState();
        }

        public void LogTurn(Player player, string Move)
        {
            if (player == null)
            {
                //means no player conducted move.
                //can be: add card to table, declare score
                LatestAction = Move;
                logOfMoves.Add(moveLogCounter++, Move);
                //game.Subject.NotifyAll();
            }
            else
            {
                string line = "Player: " + player.PlayerId + " " + Move;
                LatestAction = line;
                logOfMoves.Add(moveLogCounter++, line); //while parsing, check if first word is "Player:" then strip by spaces the ID
                //game.Subject.NotifyAll();
            }
        }
    }
}