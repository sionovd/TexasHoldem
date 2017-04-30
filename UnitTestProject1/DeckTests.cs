using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TexasHoldem;

namespace UnitTestProject1
{
    class DeckTests
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
