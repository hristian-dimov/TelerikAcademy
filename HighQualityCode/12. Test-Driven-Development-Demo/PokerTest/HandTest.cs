using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void AllColorsToStringTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card card3 = new Card(CardFace.Five, CardSuit.Spades);
            Card card4 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);

            string actual = hand.ToString();
            string expected = "A♣8♦5♠Q♠Q♥";

            Assert.AreEqual(expected, actual);
        }
    }
}
