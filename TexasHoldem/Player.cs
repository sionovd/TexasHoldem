using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TexasHoldem
{
    public class Player
    {
        public Player(int playerID)
        {
            // this = game.getPlayer(playerID);
        }

        private static int counter = 0;

        public Player(int moneyBalance, string name)
        {
            counter++;
            PlayerId = counter;
            this.MoneyBalance = moneyBalance;
            this.Name = name;
            this.Cards = new Dictionary<int, Card[]>();
            this.IsPlayingCurrentGames = new Dictionary<int, bool>();
            this.AlreadyPayed = 0;
            Position = -1;
        }

        public Player(string name)//???
        {
            counter++;
            PlayerId = counter;
            this.Name = name;
            Position = -1;
        }

        public int getBestHand(Card[] tableCards, int GameId)
        {
            Card[] unionCards = new Card[7];
            for (int i = 0; i < tableCards.Length; i++)
            {
                unionCards[i] = tableCards[i];
            }
            unionCards[5] = this.Cards[GameId][0];
            unionCards[6] = this.Cards[GameId][1];
            // need to evaluate Hand
            HandEvaluator handEval = new HandEvaluator(unionCards);
            return handEval.Evaluate();
        }

        public void AddHand(int GameId, Card c1, Card c2)
        {
            Cards.Add(GameId, new Card[] { c1, c2 });
        }
        public bool IsPlaying(int GameId)
        {
            return IsPlayingCurrentGames[GameId];
        }
        public void PlayMove()
        {
            //either bet, check, call or fold
        }

        public void GetUp()
        {
            this.Position = -1;
        }

        public void TakeSit(int pos)
        {
            this.Position = pos;
        }

        public int MoneyBalance { get; set; }

        public string Name { get; set; }

        public int Position { get; set; }

        public int PlayerId { get; set; }

        public Dictionary <int, Card[]> Cards { get; set; }
        public Dictionary<int, bool> IsPlayingCurrentGames { get; set; }
        public int AlreadyPayed { get; set; }
    }
}