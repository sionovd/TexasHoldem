using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public enum Cards
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
    public class Card
    {

        private int cardId = -1;
        public Card(int cardId)
        {
            this.cardId = cardId;
        }

        public int getCardId()
        {
            return this.cardId;
        }
    }
}
