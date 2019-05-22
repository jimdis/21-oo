using System;
using System.Collections.Generic;
using System.Linq;
namespace TwentyOne
{
    /// <summary>
    /// Represents a Deck of Playing Cards.
    /// </summary>
    public static class Deck
    {
        private static List<Card> _stock = new List<Card>();
        private static List<Card> _discardPile = new List<Card>();

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
                ShuffleStock();
            }
        }

        /// <summary>
        ///     Removes and returns the last Card item from _stock.
        ///     If there is only one Card left in _stock, it is refilled from _discardPile and shuffled.
        /// </summary>
        /// <returns>The last card from _stock.</returns>
        public static Card RemoveCard()
        {
            Card topCard = _stock.Last();
            _stock.Remove(topCard);

            if (_stock.Count == 1) ResetDeck();

            return topCard;
        }

        /// <summary>
        ///     Adds an array of Cards to _discardPile.
        /// </summary>
        /// <param name="hand">Array of Cards to be added to _discardPile.</param>
        public static void AddToDiscardPile(List<Card> hand)
        {
            _discardPile.AddRange(hand);
        }

        /// <summary>
        ///     Resets the Deck by adding _discardPile to _stock and shuffling it.
        /// </summary>
        public static void ResetDeck()
        {
            _stock.AddRange(_discardPile);
            _discardPile.Clear();
            ShuffleStock();
        }

        // Instantiates a new instance of Random.
        private static Random rng = new Random();

        /// <summary>
        ///     Shuffles elements in _stock base on the Fisher-Yates shuffle.
        ///     Solution adapted from: https://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        private static void ShuffleStock()
        {
            int n = _stock.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _stock[k];
                _stock[k] = _stock[n];
                _stock[n] = value;
            }
        }

        // FOR TESTING - REMOVE LATER!
        public static List<Card> getStock()
        {
            return _stock;

        }
        public static List<Card> getPile()
        {
            return _discardPile;

        }
    }
}