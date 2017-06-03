using System;

namespace Domain.GameModule
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
    public class Card : IComparable<Card>
    {
        private Cards cards;

        public Card(Cards cards)
        {
            this.cards = cards;
        }

        public Cards getCardId()
        {
            return this.cards;
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
