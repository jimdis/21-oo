using System;
using System.Collections.Generic;
namespace TwentyOne
{
    /// <summary>
    /// Represents a Deck of Playing Cards.
    /// </summary>
    public static class Deck
    {
        private static List<Card> _stock = new List<Card>();
        private static List<Card> _discardPile;

        /// <summary>
        ///     Initializes the Deck class.
        /// </summary>
        static Deck()
        {
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Card card = new Card(suit, i);
                    _stock.Add(card);
                }
            }
        }

        public static List<Card> getStock()
        {
            return _stock;

        }
    }
}