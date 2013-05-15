using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public Hand(params ICard[] cards)
        {
            this.Cards = new List<ICard>();

            foreach (Card card in cards)
            {
                this.Cards.Add(card);
            }
        }

        public override string ToString()
        {
            StringBuilder hand = new StringBuilder();

            foreach (Card card in Cards)
            {
                hand.Append(card.ToString());
            }

            return hand.ToString();
        }
    }
}
