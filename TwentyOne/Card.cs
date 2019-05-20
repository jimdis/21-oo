using System;
using System.Collections.Generic;
namespace TwentyOne
{
    /// <summary>
    /// Represents a Playing Card.
    /// </summary>
    public class Card
    {
        /// <summary>
        ///     Gets the Suit of the Card.
        /// </summary>
        public Suit Suit { get; }

        /// <summary>
        ///     Gets the Rank of the Card.
        /// </summary>
        public int Rank { get; }

        /// <summary>
        ///     Initializes a new instance of the Card class.
        /// </summary>
        /// <param name="suit">Suit of the Card.</param>
        /// <param name="rank">Rank of the Card.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if Rank is set to < 1 or > 13.</exception>
        public Card(Suit suit, int rank)
        {
            Suit = suit;
            if (rank < 1 || rank > 13)
            {
                throw new ArgumentOutOfRangeException("Rank must be between 1 and 13");
            }
            Rank = rank;
        }

        /// <summary>
        ///     Converts this Card to a human-readable string.
        /// </summary>
        /// <returns>A string representation of this Card.</returns>
        public override string ToString()
        {
            var suits = new Dictionary<Suit, string>
                {
                    [Suit.Hearts] = "\u2665",
                    [Suit.Diamonds] = "\u2666",
                    [Suit.Cloves] = "\u2663",
                    [Suit.Spades] = "\u2660"
                };

            var ranks = new Dictionary<int, string>
                {
                    [1] = "A",
                    [11] = "J",
                    [12] = "Q",
                    [13] = "K"
                };

            string rank = Rank.ToString();

            if (Rank == 1 || Rank > 10)
            {
                rank = ranks[Rank];
            }

            return $"{rank}{suits[Suit]}";
        }
    }
}