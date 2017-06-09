using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communication.GameLogInfo
{

    public enum CardType
    {
        HeartTwo, DiamondTwo, SpadesTwo, ClubsTwo,
        HeartThree, DiamondThree, SpadesThree, ClubsThree,
        HeartFour, DiamondFour, SpadesFour, ClubsFour,
        HeartFive, DiamondFive, SpadesFive, ClubsFive,
        HeartSix, DiamondSix, SpadesSix, ClubsSix,
        HeartSeven, DiamondSeven, SpadesSeven, ClubsSeven,
        HeartEight, DiamondEight, SpadesEight, ClubsEight,
        HeartNine, DiamondNine, SpadesNine, ClubsNine,
        HeartTen, DiamondTen, SpadesTen, ClubsTen,
        HeartJack, DiamondJack, SpadesJack, ClubsJack,
        HeartQueen, DiamondQueen, SpadesQueen, ClubsQueen,
        HeartKing, DiamondKing, SpadesKing, ClubsKing,
        HeartAce, DiamondAce, SpadesAce, ClubsAce
    };
    public class PlayerCardsInfo
    {
        private CardType[] cards = new CardType[2];

        public PlayerCardsInfo()
        {
            
        }

        public PlayerCardsInfo(CardType first, CardType second)
        {
            cards[0] = first;
            cards[1] = second;
        }

        
        public CardType[] GetCards()
        {
            return cards;
        }

        public PlayerCardsInfo Parse(string content)
        {
            return this;
        }
    }
}
