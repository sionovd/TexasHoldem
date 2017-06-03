using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.GameModule;

namespace UnitTestProject1
{
    [TestClass]
    public class DeckTests
    {
        Deck deck;

        [TestInitialize]
        public void BeforeTest()
        {
            deck = new Deck();
        }

        [TestMethod]
        public void DeckLengthIs52()
        {
            Assert.IsTrue(deck.GetSize() == 52);
        }
    }
}
