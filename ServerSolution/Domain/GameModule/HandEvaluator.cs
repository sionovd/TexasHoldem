﻿using System;

namespace Domain.GameModule
{
    public class HandEvaluator
    {
        private Card[] hand;
        private Card[] onlyDealed;
        private const int HIGHEST_CARD = 0;
        private const int ONE_PAIR = 20;
        private const int TWO_PAIR = 40;
        private const int THREE_OF_A_KIND = 80;
        private const int STRAIGHT = 100;
        private const int FLUSH = 120;
        private const int FULL_HOUSE = 140;
        private const int FOUR_OF_A_KIND = 160;
        private const int STRAIGHT_FLUSH = 180;
        private const int ROYAL_FLUSH = 220;

        public HandEvaluator(Card[] hand)
        {
            this.hand = hand;
            onlyDealed = new[] { hand[0], hand[1] };
            Array.Sort(onlyDealed);
            Array.Sort(this.hand);
        }

        public int Evaluate()
        {
            if (hand.Length != 7 && hand.Length != 5)
                return -1;
            if (isRoyalFlush())
            {
                Console.WriteLine("royal flush");
                return getRoyalFlush();
            }
            if (isStraightFlush())
            {
                Console.WriteLine("straight flush");
                return getStraightFlush();
            }
            if (isFourOfAKind())
            {
                Console.WriteLine("four of a kind");
                return getFourOfAKind();
            }
            if (isFullHouse())
            {
                Console.WriteLine("full house");
                return getFullHouse();
            }
            if (isFlush())
            {
                Console.WriteLine("flush");
                return getFlush();
            }
            if (isStraight())
            {
                Console.WriteLine("straight");
                return getStraight();
            }
            if (isThreeOfAKind())
            {
                Console.WriteLine("three of a kind");
                return getThreeOfAKind();
            }

            if (isTwoPair())
            {
                Console.WriteLine("two pair");
                return getTwoPair();
            }

            if (isOnePair())
            {
                Console.WriteLine("one pair");
                return getOnePair();
            }
            Console.WriteLine("high card");
            return getHighCard();
        }

        #region evaluate score
        private int getHighCard()
        {
            return HIGHEST_CARD + ((int)onlyDealed[1].getCardId() / 4);
        }
        private int getOnePair()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int cardScore = 0;
            bool flag = true;
            for (int i = 0; i < hand.Length && flag; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        if (oneSign == 2)
                        {
                            cardScore = 0;
                            flag = false;
                        }
                        break;
                    case 1:
                        twoSign++;
                        if (twoSign == 2)
                        {
                            cardScore = 1;
                            flag = false;
                        }
                        break;
                    case 2:
                        threeSign++;
                        if (threeSign == 2)
                        {
                            cardScore = 2;
                            flag = false;
                        }
                        break;
                    case 3:
                        fourSign++;
                        if (fourSign == 2)
                        {
                            cardScore = 3;
                            flag = false;
                        }
                        break;
                    case 4:
                        fiveSign++;
                        if (fiveSign == 2)
                        {
                            cardScore = 4;
                            flag = false;
                        }
                        break;
                    case 5:
                        sixSign++;
                        if (sixSign == 2)
                        {
                            cardScore = 5;
                            flag = false;
                        }
                        break;
                    case 6:
                        sevenSign++;
                        if (sevenSign == 2)
                        {
                            cardScore = 6;
                            flag = false;
                        }
                        break;
                    case 7:
                        eightSign++;
                        if (eightSign == 2)
                        {
                            cardScore = 7;
                            flag = false;
                        }
                        break;
                    case 8:
                        nineSign++;
                        if (nineSign == 2)
                        {
                            cardScore = 8;
                            flag = false;
                        }
                        break;
                    case 9:
                        tenSign++;
                        if (tenSign == 2)
                        {
                            cardScore = 9;
                            flag = false;
                        }
                        break;
                    case 10:
                        elevenSign++;
                        if (elevenSign == 2)
                        {
                            cardScore = 10;
                            flag = false;
                        }
                        break;
                    case 11:
                        twelveSign++;
                        if (twelveSign == 2)
                        {
                            cardScore = 11;
                            flag = false;
                        }
                        break;
                    case 12:
                        thirteenSign++;
                        if (thirteenSign == 2)
                        {
                            cardScore = 12;
                            flag = false;
                        }
                        break;
                }
            }
            return cardScore + ONE_PAIR;
        }
        private int getTwoPair()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int cardScore = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        if (oneSign == 2)
                            if (cardScore < 0) cardScore += 0;
                        break;
                    case 1:
                        twoSign++;
                        if (twoSign == 2)
                            if (cardScore < 1) cardScore += 1;
                        break;
                    case 2:
                        threeSign++;
                        if (threeSign == 2)
                            if (cardScore < 2) cardScore += 2;
                        break;
                    case 3:
                        fourSign++;
                        if (fourSign == 2)
                            if (cardScore < 3) cardScore += 3;
                        break;
                    case 4:
                        fiveSign++;
                        if (fiveSign == 2)
                            if (cardScore < 4) cardScore += 4;
                        break;
                    case 5:
                        sixSign++;
                        if (sixSign == 2)
                            if (cardScore < 5) cardScore += 5;
                        break;
                    case 6:
                        sevenSign++;
                        if (sevenSign == 2)
                            if (cardScore < 6) cardScore += 6;
                        break;
                    case 7:
                        eightSign++;
                        if (eightSign == 2)
                            if (cardScore < 7) cardScore += 7;
                        break;
                    case 8:
                        nineSign++;
                        if (nineSign == 2)
                            if (cardScore < 8) cardScore += 8;
                        break;
                    case 9:
                        tenSign++;
                        if (tenSign == 2)
                            if (cardScore < 9) cardScore += 9;
                        break;
                    case 10:
                        elevenSign++;
                        if (elevenSign == 2)
                            if (cardScore < 10) cardScore += 10;
                        break;
                    case 11:
                        twelveSign++;
                        if (twelveSign == 2)
                            if (cardScore < 11) cardScore += 11;
                        break;
                    case 12:
                        thirteenSign++;
                        if (thirteenSign == 2)
                            if (cardScore < 12) cardScore += 12;
                        break;
                }
            }
            return cardScore + TWO_PAIR;
        }
        private int getThreeOfAKind()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int cardScore = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        if (oneSign == 3)
                            if (cardScore < 0) cardScore = 0;
                        break;
                    case 1:
                        twoSign++;
                        if (twoSign == 3)
                            if (cardScore < 1) cardScore = 1;
                        break;
                    case 2:
                        threeSign++;
                        if (threeSign == 3)
                            if (cardScore < 2) cardScore = 2;
                        break;
                    case 3:
                        fourSign++;
                        if (fourSign == 3)
                            if (cardScore < 3) cardScore = 3;
                        break;
                    case 4:
                        fiveSign++;
                        if (fiveSign == 3)
                            if (cardScore < 4) cardScore = 4;
                        break;
                    case 5:
                        sixSign++;
                        if (sixSign == 3)
                            if (cardScore < 5) cardScore = 5;
                        break;
                    case 6:
                        sevenSign++;
                        if (sevenSign == 3)
                            if (cardScore < 6) cardScore = 6;
                        break;
                    case 7:
                        eightSign++;
                        if (eightSign == 3)
                            if (cardScore < 7) cardScore = 7;
                        break;
                    case 8:
                        nineSign++;
                        if (nineSign == 3)
                            if (cardScore < 8) cardScore = 8;
                        break;
                    case 9:
                        tenSign++;
                        if (tenSign == 3)
                            if (cardScore < 9) cardScore = 9;
                        break;
                    case 10:
                        elevenSign++;
                        if (elevenSign == 3)
                            if (cardScore < 10) cardScore = 10;
                        break;
                    case 11:
                        twelveSign++;
                        if (twelveSign == 3)
                            if (cardScore < 11) cardScore = 11;
                        break;
                    case 12:
                        thirteenSign++;
                        if (thirteenSign == 3)
                            if (cardScore < 12) cardScore = 12;
                        break;
                }
            }
            return cardScore + THREE_OF_A_KIND;
        }
        private int getStraight()
        {
            int currentCardValue = 0;
            int incrementalInd = 1;
            int cardScore = 0;
            for (int j = 0; j < 3; j++)
            {
                currentCardValue = (int)hand[j].getCardId() / 4;
                for (int i = j + 1; i < hand.Length; i++)
                {
                    if (currentCardValue + incrementalInd == (int)hand[i].getCardId() / 4)
                    {
                        incrementalInd = incrementalInd + 1;
                    }
                    if (incrementalInd == 5)
                    {
                        cardScore = (int)hand[j].getCardId() / 4;
                    }
                }
                incrementalInd = 1;
            }
            return cardScore + STRAIGHT;
        }
        private int getFlush()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int cardScore = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() % 4)
                {
                    case 0:
                        oneSign++;
                        break;
                    case 1:
                        twoSign++;
                        break;
                    case 2:
                        threeSign++;
                        break;
                    case 3:
                        fourSign++;
                        break;
                }
                if (oneSign == 5 || twoSign == 5 || threeSign == 5 || fourSign == 5)
                {
                    cardScore = (int)hand[i].getCardId() / 4;
                }
            }
            return cardScore + FLUSH;
        }
        private int getFullHouse()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int maxTriple = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;

                        if (oneSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 1:
                        twoSign++;

                        if (twoSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 2:
                        threeSign++;

                        if (threeSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 3:
                        fourSign++;

                        if (fourSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 4:
                        fiveSign++;

                        if (fiveSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 5:
                        sixSign++;

                        if (sixSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 6:
                        sevenSign++;

                        if (sevenSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 7:
                        eightSign++;

                        if (eightSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 8:
                        nineSign++;

                        if (nineSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 9:
                        tenSign++;

                        if (tenSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 10:
                        elevenSign++;

                        if (elevenSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 11:
                        twelveSign++;

                        if (twelveSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                    case 12:
                        thirteenSign++;

                        if (thirteenSign == 3)
                        {
                            if (maxTriple < ((int)hand[i].getCardId() / 4)) maxTriple = (int)hand[i].getCardId() / 4;
                        }
                        break;
                }
            }
            return maxTriple + FULL_HOUSE;
        }
        private int getFourOfAKind()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int cardScore = 0;
            bool flag = true;
            for (int i = 0; i < hand.Length && flag; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        if (oneSign == 2)
                        {
                            cardScore = 0;
                            flag = false;
                        }
                        break;
                    case 1:
                        twoSign++;
                        if (twoSign == 4)
                        {
                            cardScore = 1;
                            flag = false;
                        }
                        break;
                    case 2:
                        threeSign++;
                        if (threeSign == 4)
                        {
                            cardScore = 2;
                            flag = false;
                        }
                        break;
                    case 3:
                        fourSign++;
                        if (fourSign == 4)
                        {
                            cardScore = 3;
                            flag = false;
                        }
                        break;
                    case 4:
                        fiveSign++;
                        if (fiveSign == 4)
                        {
                            cardScore = 4;
                            flag = false;
                        }
                        break;
                    case 5:
                        sixSign++;
                        if (sixSign == 4)
                        {
                            cardScore = 5;
                            flag = false;
                        }
                        break;
                    case 6:
                        sevenSign++;
                        if (sevenSign == 4)
                        {
                            cardScore = 6;
                            flag = false;
                        }
                        break;
                    case 7:
                        eightSign++;
                        if (eightSign == 4)
                        {
                            cardScore = 7;
                            flag = false;
                        }
                        break;
                    case 8:
                        nineSign++;
                        if (nineSign == 4)
                        {
                            cardScore = 8;
                            flag = false;
                        }
                        break;
                    case 9:
                        tenSign++;
                        if (tenSign == 4)
                        {
                            cardScore = 9;
                            flag = false;
                        }
                        break;
                    case 10:
                        elevenSign++;
                        if (elevenSign == 4)
                        {
                            cardScore = 10;
                            flag = false;
                        }
                        break;
                    case 11:
                        twelveSign++;
                        if (twelveSign == 4)
                        {
                            cardScore = 11;
                            flag = false;
                        }
                        break;
                    case 12:
                        thirteenSign++;
                        if (thirteenSign == 4)
                        {
                            cardScore = 12;
                            flag = false;
                        }
                        break;
                }
            }
            return cardScore + FOUR_OF_A_KIND;
        }
        private int getStraightFlush()
        {
            int currentCardValue = 0;
            int incrementalInd = 4;
            bool flag = true;
            for (int j = 0; j < 3 && flag; j++)
            {
                currentCardValue = (int)hand[j].getCardId();
                for (int i = j + 1; i < hand.Length && flag; i++)
                {
                    if (currentCardValue + incrementalInd == (int)hand[i].getCardId())
                    {
                        incrementalInd = incrementalInd + 4;
                    }
                    if (incrementalInd == 20)
                    {
                        flag = false;
                        currentCardValue = currentCardValue + 4;
                    }
                }
            }
            return currentCardValue + STRAIGHT_FLUSH;
        }
        private int getRoyalFlush()
        {
            return ROYAL_FLUSH;
        }
        #endregion

        #region booleans for evaluation
        private bool isRoyalFlush()
        {

            int royalCounter = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].getCardId() == CardType.HeartAce ||
                    hand[i].getCardId() == CardType.HeartKing ||
                    hand[i].getCardId() == CardType.HeartQueen ||
                    hand[i].getCardId() == CardType.HeartJack ||
                    hand[i].getCardId() == CardType.HeartTen)
                {
                    royalCounter++;
                }
            }
            if (royalCounter == 5)
                return true;
            royalCounter = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].getCardId() == CardType.DiamondAce ||
                    hand[i].getCardId() == CardType.DiamondKing ||
                    hand[i].getCardId() == CardType.DiamondQueen ||
                    hand[i].getCardId() == CardType.DiamondJack ||
                    hand[i].getCardId() == CardType.DiamondTen)
                {
                    royalCounter++;
                }
            }
            if (royalCounter == 5)
                return true;
            royalCounter = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].getCardId() == CardType.SpadesAce ||
                    hand[i].getCardId() == CardType.SpadesKing ||
                    hand[i].getCardId() == CardType.SpadesQueen ||
                    hand[i].getCardId() == CardType.SpadesJack ||
                    hand[i].getCardId() == CardType.SpadesTen)
                {
                    royalCounter++;
                }
            }
            if (royalCounter == 5)
                return true;
            royalCounter = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                if (hand[i].getCardId() == CardType.ClubsAce ||
                    hand[i].getCardId() == CardType.ClubsKing ||
                    hand[i].getCardId() == CardType.ClubsQueen ||
                    hand[i].getCardId() == CardType.ClubsJack ||
                    hand[i].getCardId() == CardType.ClubsTen)
                {
                    royalCounter++;
                }
            }
            if (royalCounter == 5)
                return true;

            return false;
        }

        private bool isStraightFlush()
        {
            int currentCardValue = 0;
            int incrementalInd = 4;
            for (int j = 0; j < 3; j++)
            {
                currentCardValue = (int)hand[j].getCardId();
                for (int i = j + 1; i < hand.Length; i++)
                {
                    if (currentCardValue + incrementalInd == (int)hand[i].getCardId())
                    {
                        incrementalInd = incrementalInd + 4;
                    }
                    if (incrementalInd == 20)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool isFourOfAKind()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        break;
                    case 1:
                        twoSign++;
                        break;
                    case 2:
                        threeSign++;
                        break;
                    case 3:
                        fourSign++;
                        break;
                    case 4:
                        fiveSign++;
                        break;
                    case 5:
                        sixSign++;
                        break;
                    case 6:
                        sevenSign++;
                        break;
                    case 7:
                        eightSign++;
                        break;
                    case 8:
                        nineSign++;
                        break;
                    case 9:
                        tenSign++;
                        break;
                    case 10:
                        elevenSign++;
                        break;
                    case 11:
                        twelveSign++;
                        break;
                    case 12:
                        thirteenSign++;
                        break;
                }
            }
            if (oneSign == 4 || twoSign == 4 || threeSign == 4 || fourSign == 4 ||
                fiveSign == 4 || sixSign == 4 || sevenSign == 4 || eightSign == 4 ||
                nineSign == 4 || tenSign == 4 || elevenSign == 4 || twelveSign == 4 ||
                thirteenSign == 4)
            {
                return true;
            }
            return false;
        }

        private bool isFullHouse()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int pairCount = 0;
            int tripleCount = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        if (oneSign == 2)
                            pairCount++;
                        else if (oneSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 1:
                        twoSign++;
                        if (twoSign == 2)
                            pairCount++;
                        else if (twoSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 2:
                        threeSign++;
                        if (threeSign == 2)
                            pairCount++;
                        else if (threeSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 3:
                        fourSign++;
                        if (fourSign == 2)
                            pairCount++;
                        else if (fourSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 4:
                        fiveSign++;
                        if (fiveSign == 2)
                            pairCount++;
                        else if (fiveSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 5:
                        sixSign++;
                        if (sixSign == 2)
                            pairCount++;
                        else if (sixSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 6:
                        sevenSign++;
                        if (sevenSign == 2)
                            pairCount++;
                        else if (sevenSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 7:
                        eightSign++;
                        if (eightSign == 2)
                            pairCount++;
                        else if (eightSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 8:
                        nineSign++;
                        if (nineSign == 2)
                            pairCount++;
                        else if (nineSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 9:
                        tenSign++;
                        if (tenSign == 2)
                            pairCount++;
                        else if (tenSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 10:
                        elevenSign++;
                        if (elevenSign == 2)
                            pairCount++;
                        else if (elevenSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 11:
                        twelveSign++;
                        if (twelveSign == 2)
                            pairCount++;
                        else if (twelveSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                    case 12:
                        thirteenSign++;
                        if (thirteenSign == 2)
                            pairCount++;
                        else if (thirteenSign == 3)
                        {
                            tripleCount++;
                            pairCount--;
                        }
                        break;
                }
            }
            if (pairCount > 0 && tripleCount > 0)
                return true;
            return false;
        }

        private bool isFlush()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() % 4)
                {
                    case 0:
                        oneSign++;
                        break;
                    case 1:
                        twoSign++;
                        break;
                    case 2:
                        threeSign++;
                        break;
                    case 3:
                        fourSign++;
                        break;
                }
            }
            if (oneSign == 5 || twoSign == 5 || threeSign == 5 || fourSign == 5)
            {
                return true;
            }
            return false;
        }

        private bool isStraight()
        {
            int currentCardValue = 0;
            int incrementalInd = 1;
            for (int j = 0; j < 3; j++)
            {
                currentCardValue = (int)hand[j].getCardId() / 4;
                for (int i = j + 1; i < hand.Length; i++)
                {
                    if (currentCardValue + incrementalInd == (int)hand[i].getCardId() / 4)
                    {
                        incrementalInd = incrementalInd + 1;
                    }
                    if (incrementalInd == 5)
                    {
                        return true;
                    }
                }
                incrementalInd = 1;
            }
            return false;
        }

        private bool isThreeOfAKind()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        break;
                    case 1:
                        twoSign++;
                        break;
                    case 2:
                        threeSign++;
                        break;
                    case 3:
                        fourSign++;
                        break;
                    case 4:
                        fiveSign++;
                        break;
                    case 5:
                        sixSign++;
                        break;
                    case 6:
                        sevenSign++;
                        break;
                    case 7:
                        eightSign++;
                        break;
                    case 8:
                        nineSign++;
                        break;
                    case 9:
                        tenSign++;
                        break;
                    case 10:
                        elevenSign++;
                        break;
                    case 11:
                        twelveSign++;
                        break;
                    case 12:
                        thirteenSign++;
                        break;
                }
            }
            if (oneSign == 3 || twoSign == 3 || threeSign == 3 || fourSign == 3 ||
                fiveSign == 3 || sixSign == 3 || sevenSign == 3 || eightSign == 3 ||
                nineSign == 3 || tenSign == 3 || elevenSign == 3 || twelveSign == 3 ||
                thirteenSign == 3)
            {
                return true;
            }
            return false;
        }

        private bool isTwoPair()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            int pairCount = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        if (oneSign == 2)
                            pairCount++;
                        break;
                    case 1:
                        twoSign++;
                        if (twoSign == 2)
                            pairCount++;
                        break;
                    case 2:
                        threeSign++;
                        if (threeSign == 2)
                            pairCount++;
                        break;
                    case 3:
                        fourSign++;
                        if (fourSign == 2)
                            pairCount++;
                        break;
                    case 4:
                        fiveSign++;
                        if (fiveSign == 2)
                            pairCount++;
                        break;
                    case 5:
                        sixSign++;
                        if (sixSign == 2)
                            pairCount++;
                        break;
                    case 6:
                        sevenSign++;
                        if (sevenSign == 2)
                            pairCount++;
                        break;
                    case 7:
                        eightSign++;
                        if (eightSign == 2)
                            pairCount++;
                        break;
                    case 8:
                        nineSign++;
                        if (nineSign == 2)
                            pairCount++;
                        break;
                    case 9:
                        tenSign++;
                        if (tenSign == 2)
                            pairCount++;
                        break;
                    case 10:
                        elevenSign++;
                        if (elevenSign == 2)
                            pairCount++;
                        break;
                    case 11:
                        twelveSign++;
                        if (twelveSign == 2)
                            pairCount++;
                        break;
                    case 12:
                        thirteenSign++;
                        if (thirteenSign == 2)
                            pairCount++;
                        break;
                }
            }
            if (pairCount >= 2)
                return true;
            return false;
        }

        private bool isOnePair()
        {
            int oneSign = 0;
            int twoSign = 0;
            int threeSign = 0;
            int fourSign = 0;
            int fiveSign = 0;
            int sixSign = 0;
            int sevenSign = 0;
            int eightSign = 0;
            int nineSign = 0;
            int tenSign = 0;
            int elevenSign = 0;
            int twelveSign = 0;
            int thirteenSign = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                switch ((int)hand[i].getCardId() / 4)
                {
                    case 0:
                        oneSign++;
                        break;
                    case 1:
                        twoSign++;
                        break;
                    case 2:
                        threeSign++;
                        break;
                    case 3:
                        fourSign++;
                        break;
                    case 4:
                        fiveSign++;
                        break;
                    case 5:
                        sixSign++;
                        break;
                    case 6:
                        sevenSign++;
                        break;
                    case 7:
                        eightSign++;
                        break;
                    case 8:
                        nineSign++;
                        break;
                    case 9:
                        tenSign++;
                        break;
                    case 10:
                        elevenSign++;
                        break;
                    case 11:
                        twelveSign++;
                        break;
                    case 12:
                        thirteenSign++;
                        break;
                }
            }
            if (oneSign == 2 || twoSign == 2 || threeSign == 2 || fourSign == 2 ||
                fiveSign == 2 || sixSign == 2 || sevenSign == 2 || eightSign == 2 ||
                nineSign == 2 || tenSign == 2 || elevenSign == 2 || twelveSign == 2 ||
                thirteenSign == 2)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
