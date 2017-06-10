using System;

namespace Domain.GameModule
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
    public class Card : IComparable<Card>
    {
        private CardType cardType;

        public Card(CardType cardType)
        {
            this.cardType = cardType;
        }

        public CardType getCardId()
        {
            return this.cardType;
        }

        public int CompareTo(Card other)
        {
            if (this.getCardId() > other.getCardId())
                return 1;
            if (this.getCardId() == other.getCardId())
                return 0;
            return -1;
        }
    }
}
