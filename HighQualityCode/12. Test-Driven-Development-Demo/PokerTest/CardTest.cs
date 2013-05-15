using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Poker.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void ToStringAceOfSpadesTest()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string actual = card.ToString();
            string expected = "A♠";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToStringThreeOfHearts()
        {
            Card card = new Card(CardFace.Three, CardSuit.Hearts);
            string actual = card.ToString();
            string expected = "3♥";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToStringJackOfClubs()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Clubs);
            string actual = card.ToString();
            string expected = "J♣";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ToStringTenOfDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string actual = card.ToString();
            string expected = "10♦";
            Assert.AreEqual(actual, expected);
        }
    }
}
