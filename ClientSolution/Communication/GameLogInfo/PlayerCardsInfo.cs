using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

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
        public CardType[] PlayerCards { get; set; }

        public PlayerCardsInfo(string content)
        {
            PlayerCardsInfo playerCardsInfo = new JavaScriptSerializer().Deserialize<PlayerCardsInfo>(content);
            this.PlayerCards = playerCardsInfo.PlayerCards;
        }

        public PlayerCardsInfo(CardType first, CardType second)
        {
            PlayerCards = new CardType[2];
            PlayerCards[0] = first;
            PlayerCards[1] = second;
        }

    }
}
