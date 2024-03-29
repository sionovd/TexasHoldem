﻿using System;
using System.Collections.Generic;
using Domain.GameModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class HandEvaluatorTests
    {

        #region private fields
        private List<Card> royalFlush;
        private List<Card> straightFlush;
        private List<Card> fourOfAKind;
        private List<Card> fullHouse;
        private List<Card> flush;
        private List<Card> straight;
        private List<Card> threeOfAKind;
        private List<Card> twoPairs;
        private List<Card> onePair;
        private List<Card> highHand;
        private List<Card> buggedCombo1;
        private List<Card> buggedCombo2;
        private List<Card> buggedCombo3;
        private List<Card> buggedCombo4;
        private HandEvaluator eval;
        #endregion

        #region constants
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
        #endregion 

        [TestInitialize]
        public void BeforeTest()
        {
            royalFlush = new List<Card>{new Card(CardType.HeartAce),
                                        new Card(CardType.HeartKing),
                                        new Card(CardType.HeartQueen),
                                        new Card(CardType.HeartJack),
                                        new Card(CardType.HeartTen),
                                        new Card(CardType.SpadesFour),
                                        new Card(CardType.SpadesJack)
            };

            straightFlush = new List<Card> {new Card(CardType.HeartKing),
                                            new Card(CardType.HeartQueen),
                                            new Card(CardType.HeartJack),
                                            new Card(CardType.HeartTen),
                                            new Card(CardType.HeartNine),
                                            new Card(CardType.SpadesFour),
                                            new Card(CardType.SpadesJack)
            };

            fourOfAKind = new List<Card> {  new Card(CardType.HeartAce),
                                            new Card(CardType.SpadesAce),
                                            new Card(CardType.DiamondAce),
                                            new Card(CardType.ClubsAce),
                                            new Card(CardType.SpadesFour),
                                            new Card(CardType.DiamondJack),
                                            new Card(CardType.ClubsSix)
            };

            fullHouse = new List<Card> {new Card(CardType.HeartKing),
                                        new Card(CardType.DiamondKing),
                                        new Card(CardType.HeartEight),
                                        new Card(CardType.ClubsEight),
                                        new Card(CardType.SpadesEight),
                                        new Card(CardType.DiamondJack),
                                        new Card(CardType.ClubsSix)
            };

            flush = new List<Card> {new Card(CardType.HeartKing),
                                    new Card(CardType.HeartFive),
                                    new Card(CardType.HeartEight),
                                    new Card(CardType.HeartJack),
                                    new Card(CardType.HeartTwo),
                                    new Card(CardType.SpadesEight),
                                    new Card(CardType.DiamondJack)
            };

            straight = new List<Card> { new Card(CardType.HeartNine), 
                                        new Card(CardType.ClubsEight),
                                        new Card(CardType.DiamondSeven),
                                        new Card(CardType.DiamondSix),
                                        new Card(CardType.HeartFive),
                                        new Card(CardType.HeartTen),
                                        new Card(CardType.DiamondQueen)
            };

            threeOfAKind = new List<Card> { new Card(CardType.HeartAce),
                                            new Card(CardType.SpadesAce),
                                            new Card(CardType.DiamondAce),
                                            new Card(CardType.SpadesEight),
                                            new Card(CardType.DiamondJack),
                                            new Card(CardType.ClubsSix),
                                            new Card(CardType.ClubsNine)
            };

            twoPairs = new List<Card> { new Card(CardType.HeartAce),
                                        new Card(CardType.SpadesAce),
                                        new Card(CardType.DiamondQueen),
                                        new Card(CardType.ClubsQueen),
                                        new Card(CardType.SpadesEight),
                                        new Card(CardType.DiamondJack),
                                        new Card(CardType.ClubsSix)
            };

            onePair = new List<Card> {  new Card(CardType.HeartAce),
                                        new Card(CardType.SpadesAce),
                                        new Card(CardType.SpadesEight),
                                        new Card(CardType.DiamondJack),
                                        new Card(CardType.ClubsSix),
                                        new Card(CardType.ClubsNine),
                                        new Card(CardType.ClubsFive)
            };

            highHand = new List<Card> { new Card(CardType.HeartAce),
                                        new Card(CardType.ClubsFour),
                                        new Card(CardType.HeartEight),
                                        new Card(CardType.SpadesTwo),
                                        new Card(CardType.DiamondJack),
                                        new Card(CardType.ClubsNine),
                                        new Card(CardType.ClubsFive)
            };

            buggedCombo1 = new List<Card> {
                                        new Card(CardType.SpadesFive),
                                        new Card(CardType.ClubsSix),
                                        new Card(CardType.SpadesNine),
                                        new Card(CardType.ClubsNine),
                                        new Card(CardType.ClubsKing),
                                        new Card(CardType.DiamondThree),
                                        new Card(CardType.ClubsThree)
            };
            buggedCombo2 = new List<Card> {
                new Card(CardType.SpadesFive),
                new Card(CardType.ClubsSix),
                new Card(CardType.SpadesNine),
                new Card(CardType.ClubsNine),
                new Card(CardType.ClubsKing),
                new Card(CardType.HeartFour),
                new Card(CardType.HeartTen)
            };
            buggedCombo3 = new List<Card> {
                new Card(CardType.DiamondFive),
                new Card(CardType.ClubsKing),
                new Card(CardType.HeartSix),
                new Card(CardType.SpadesSix),
                new Card(CardType.HeartAce),
                new Card(CardType.SpadesSeven),
                new Card(CardType.DiamondAce)
            };
            buggedCombo4 = new List<Card> {
                new Card(CardType.ClubsTen),
                new Card(CardType.SpadesSeven),
                
                new Card(CardType.HeartAce),
                new Card(CardType.SpadesSeven),
                new Card(CardType.DiamondAce),
                new Card(CardType.HeartSix),
                new Card(CardType.SpadesSix)
            };
        }

        [TestMethod]
        public void TestBug1()
        {
            eval = new HandEvaluator(buggedCombo1.ToArray());
            Console.WriteLine(eval.Evaluate());
            eval = new HandEvaluator(buggedCombo2.ToArray());
            Console.WriteLine(eval.Evaluate());
        }

        [TestMethod]
        public void TestBug2()
        {
            eval = new HandEvaluator(buggedCombo3.ToArray());
            Console.WriteLine(eval.Evaluate());
            eval = new HandEvaluator(buggedCombo4.ToArray());
            Console.WriteLine(eval.Evaluate());
        }

        [TestMethod]
        public void TestRoyalFlush()
        {
            eval = new HandEvaluator(royalFlush.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == ROYAL_FLUSH);
        }

        [TestMethod]
        public void TestStraightFlush()
        {
            eval = new HandEvaluator(straightFlush.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == STRAIGHT_FLUSH + 8 * 4);
        }

        [TestMethod]
        public void TestFourOfAKind()
        {
            eval = new HandEvaluator(fourOfAKind.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == FOUR_OF_A_KIND + 12);
        }

        [TestMethod]
        public void TestFullHouse()
        {
            eval = new HandEvaluator(fullHouse.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == FULL_HOUSE + 6);
        }

        [TestMethod]
        public void TestFlush()
        {
            eval = new HandEvaluator(flush.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == FLUSH + 11);
        }

        [TestMethod]
        public void TestStraight()
        {
            eval = new HandEvaluator(straight.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == STRAIGHT + 4);
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            eval = new HandEvaluator(threeOfAKind.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == THREE_OF_A_KIND + 12);
        }

        [TestMethod]
        public void TestTwoPairs()
        {
            eval = new HandEvaluator(twoPairs.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == TWO_PAIR + 22);
        }

        [TestMethod]
        public void TestOnePair()
        {
            eval = new HandEvaluator(onePair.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == ONE_PAIR + 12);
        }

        [TestMethod]
        public void TestHighHand()
        {
            eval = new HandEvaluator(highHand.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == HIGHEST_CARD + 12);
        }

        [TestMethod]
        public void TestRoyalBug()
        {
            List<Card> royalFlushBug = new List<Card>{new Card(CardType.SpadesAce),
                                        new Card(CardType.ClubsJack),
                                        new Card(CardType.DiamondTen),
                                        new Card(CardType.ClubsSeven),
                                        new Card(CardType.DiamondQueen),
                                        new Card(CardType.ClubsKing),
                                        new Card(CardType.HeartJack)
            };
            eval = new HandEvaluator(royalFlushBug.ToArray());
            Console.WriteLine(eval.Evaluate());
            //Assert.IsTrue(eval.Evaluate() == ROYAL_FLUSH);
            Assert.IsFalse(eval.Evaluate() == ROYAL_FLUSH);

        }
    }
}
