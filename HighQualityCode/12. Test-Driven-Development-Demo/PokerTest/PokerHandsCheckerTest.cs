using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Test
{
    [TestClass]
    public class PokerHandsCheckerTest
    {

        // IsValidHand Tests
        [TestMethod]
        public void IsValidHandTrueTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Eight, CardSuit.Diamonds);
            Card card3 = new Card(CardFace.Five, CardSuit.Spades);
            Card card4 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidHandFalseTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card3 = new Card(CardFace.Five, CardSuit.Spades);
            Card card4 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidHandNot5Test()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card3 = new Card(CardFace.Five, CardSuit.Spades);
            Card card4 = new Card(CardFace.Queen, CardSuit.Spades);

            Hand hand = new Hand(card1, card2, card3, card4);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        // IsFlush Tests

        [TestMethod]
        public void IsFlushTrueTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Queen, CardSuit.Clubs);
            Card card3 = new Card(CardFace.Five, CardSuit.Clubs);
            Card card4 = new Card(CardFace.Seven, CardSuit.Clubs);
            Card card5 = new Card(CardFace.Jack, CardSuit.Clubs);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushFalseTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card3 = new Card(CardFace.Five, CardSuit.Spades);
            Card card4 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void IsFlushFalseSameCardsTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card3 = new Card(CardFace.Five, CardSuit.Spades);
            Card card4 = new Card(CardFace.Queen, CardSuit.Spades);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFlush(hand));
        }

        // IsFourOfAKind Tests

        [TestMethod]
        public void IsFourOfAKindTrueTest1()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Spades);
            Card card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFourOfAKindTrueTest2()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Spades);
            Card card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card5, card1, card2, card3, card4);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFourOfAKindTrueTest3()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Spades);
            Card card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card card4 = new Card(CardFace.Ace, CardSuit.Hearts);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card5, card3, card4);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFourOfAKindFalseTest()
        {
            Card card1 = new Card(CardFace.Ace, CardSuit.Clubs);
            Card card2 = new Card(CardFace.Ace, CardSuit.Spades);
            Card card3 = new Card(CardFace.Ace, CardSuit.Diamonds);
            Card card4 = new Card(CardFace.Queen, CardSuit.Diamonds);
            Card card5 = new Card(CardFace.Queen, CardSuit.Hearts);

            Hand hand = new Hand(card1, card2, card3, card4, card5);


            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }
    }
}
