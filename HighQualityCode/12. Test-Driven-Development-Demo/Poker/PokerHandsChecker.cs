using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ThenByDescending(x => x.Suit);

            ICard oldCard = sortedHand.ToList()[0];
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                ICard newCard = sortedHand.ToList()[i];
                if (oldCard.Face == newCard.Face && oldCard.Suit == newCard.Suit)
                {
                    return false;
                }

                oldCard = newCard;
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int counter = 1;

            var sortedHand = hand.Cards.OrderByDescending(x => x.Face).ThenByDescending(x => x.Suit);

            ICard oldCard = sortedHand.ToList()[0];

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                ICard newCard = sortedHand.ToList()[i];
                if (oldCard.Face == newCard.Face)
                {
                    counter++;

                    if (counter == 4 && IsValidHand(hand))
                    {
                        return true;
                    }
                }
                else
                {
                    counter = 1;
                }

                oldCard = newCard;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            

            ICard oldCard = hand.Cards[0];
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                ICard newCard = hand.Cards[i];

                if (oldCard.Suit != newCard.Suit)
                {
                    return false;
                }

                oldCard = newCard;
            }

            return true && IsValidHand(hand);
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
