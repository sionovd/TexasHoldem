using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldem;
using TexasHoldem.GameModule;

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
        private HandEvaluator eval;
        #endregion

        #region constants
        private const int HIGHEST_CARD = 0;
        private const int ONE_PAIR = 20;
        private const int TWO_PAIR = 40;
        private const int THREE_OF_A_KIND = 60;
        private const int STRAIGHT = 80;
        private const int FLUSH = 100;
        private const int FULL_HOUSE = 120;
        private const int FOUR_OF_A_KIND = 140;
        private const int STRAIGHT_FLUSH = 160;
        private const int ROYAL_FLUSH = 200;
        #endregion 

        [TestInitialize]
        public void BeforeTest()
        {
            royalFlush = new List<Card>{new Card(Cards.HeartAce),
                                        new Card(Cards.HeartKing),
                                        new Card(Cards.HeartQueen),
                                        new Card(Cards.HeartJack),
                                        new Card(Cards.HeartTen),
                                        new Card(Cards.SpadesFour),
                                        new Card(Cards.SpadesJack)
            };

            straightFlush = new List<Card> {new Card(Cards.HeartKing),
                                            new Card(Cards.HeartQueen),
                                            new Card(Cards.HeartJack),
                                            new Card(Cards.HeartTen),
                                            new Card(Cards.HeartNine),
                                            new Card(Cards.SpadesFour),
                                            new Card(Cards.SpadesJack)
            };

            fourOfAKind = new List<Card> {  new Card(Cards.HeartAce),
                                            new Card(Cards.SpadesAce),
                                            new Card(Cards.DiamondAce),
                                            new Card(Cards.ClubsAce),
                                            new Card(Cards.SpadesFour),
                                            new Card(Cards.DiamondJack),
                                            new Card(Cards.ClubsSix)
            };

            fullHouse = new List<Card> {new Card(Cards.HeartKing),
                                        new Card(Cards.DiamondKing),
                                        new Card(Cards.HeartEight),
                                        new Card(Cards.ClubsEight),
                                        new Card(Cards.SpadesEight),
                                        new Card(Cards.DiamondJack),
                                        new Card(Cards.ClubsSix)
            };

            flush = new List<Card> {new Card(Cards.HeartKing),
                                    new Card(Cards.HeartFive),
                                    new Card(Cards.HeartEight),
                                    new Card(Cards.HeartJack),
                                    new Card(Cards.HeartTwo),
                                    new Card(Cards.SpadesEight),
                                    new Card(Cards.DiamondJack)
            };

            straight = new List<Card> { new Card(Cards.HeartNine), 
                                        new Card(Cards.ClubsEight),
                                        new Card(Cards.DiamondSeven),
                                        new Card(Cards.DiamondSix),
                                        new Card(Cards.HeartFive),
                                        new Card(Cards.HeartTen),
                                        new Card(Cards.DiamondQueen)
            };

            threeOfAKind = new List<Card> { new Card(Cards.HeartAce),
                                            new Card(Cards.SpadesAce),
                                            new Card(Cards.DiamondAce),
                                            new Card(Cards.SpadesEight),
                                            new Card(Cards.DiamondJack),
                                            new Card(Cards.ClubsSix),
                                            new Card(Cards.ClubsNine)
            };

            twoPairs = new List<Card> { new Card(Cards.HeartAce),
                                        new Card(Cards.SpadesAce),
                                        new Card(Cards.DiamondQueen),
                                        new Card(Cards.ClubsQueen),
                                        new Card(Cards.SpadesEight),
                                        new Card(Cards.DiamondJack),
                                        new Card(Cards.ClubsSix)
            };

            onePair = new List<Card> {  new Card(Cards.HeartAce),
                                        new Card(Cards.SpadesAce),
                                        new Card(Cards.SpadesEight),
                                        new Card(Cards.DiamondJack),
                                        new Card(Cards.ClubsSix),
                                        new Card(Cards.ClubsNine),
                                        new Card(Cards.ClubsFive)
            };

            highHand = new List<Card> { new Card(Cards.HeartAce),
                                        new Card(Cards.ClubsFour),
                                        new Card(Cards.HeartEight),
                                        new Card(Cards.SpadesTwo),
                                        new Card(Cards.DiamondJack),
                                        new Card(Cards.ClubsNine),
                                        new Card(Cards.ClubsFive)
            };
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
            Assert.IsTrue(eval.Evaluate() == TWO_PAIR + 12);
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
            List<Card> royalFlushBug = new List<Card>{new Card(Cards.SpadesAce),
                                        new Card(Cards.ClubsJack),
                                        new Card(Cards.DiamondTen),
                                        new Card(Cards.ClubsSeven),
                                        new Card(Cards.DiamondQueen),
                                        new Card(Cards.ClubsKing),
                                        new Card(Cards.HeartJack)
            };
            eval = new HandEvaluator(royalFlushBug.ToArray());
            Console.WriteLine(eval.Evaluate());
            Assert.IsTrue(eval.Evaluate() == ROYAL_FLUSH);
        }
    }
}
