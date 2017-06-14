using Domain.GameModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
