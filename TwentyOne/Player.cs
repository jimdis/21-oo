using System;
using System.Collections.Generic;
namespace TwentyOne
{
    /// <summary>
    /// Represents a Player.
    /// </summary>
    public class Player
    {
        private int _threshold;
        private List<Card> _hand = new List<Card>();

        /// <summary>
        ///     Gets the Name of the Player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets and sets the Score of the Player.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        ///     Gets and sets the Stand status of the Player.
        /// </summary>
        public bool Stand { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="name">Name of the Player.</param>
        /// <param name="threshold">Threshold of the Player.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if Threshold is set to < 1 or > 21.</exception>
        public Player(string name, int threshold)
        {
            Name = name;
            if (threshold < 1 || threshold > 21)
            {
                throw new ArgumentOutOfRangeException("Threshold must be between 1 and 21");
            }
            _threshold = threshold;
        }

        /// <summary>
        ///     Draws a Card from Deck, adds it to Hand and updates Score.
        /// </summary>
        public void DrawCard()
        {
            _hand.Add(Deck.RemoveCard());
            UpdateScore();

        }

        /// <summary>
        ///     Calculates and updates Score based on _hand.
        /// </summary>
        public void UpdateScore()
        {

        }

    }
}