using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string cardFace = CheckCardFace(this.Face);
            string cardSuite = CheckCardSuite(this.Suit);

            return cardFace + cardSuite;
        }

        private string CheckCardSuite(CardSuit cardSuit)
        {
            switch (cardSuit)
            {
                case CardSuit.Clubs:
                    return "♣"; break;
                case CardSuit.Diamonds:
                    return "♦"; break;
                case CardSuit.Hearts:
                    return "♥"; break;
                case CardSuit.Spades:
                    return "♠"; break;
                default:
                    throw new ArgumentException("Invalid Card suite!"); break;
            }
        }

        private string CheckCardFace(CardFace cardFace)
        {
            string result = "";

            if ((int)cardFace <= 10)
            {
                return result = ((int)cardFace).ToString();
            }
            else
            {
                string cardName = cardFace.ToString();
                char firstLetter = cardName[0];
                return result = firstLetter.ToString();
            }
        }
    }
}
