using System;
using System.Collections.Generic;
using System.Linq;
namespace TwentyOne
{
    /// <summary>
    /// Represents a Player.
    /// </summary>
    public class Player
    {

        /// <summary>
        ///     The hand of the Player.
        /// </summary>
        private List<Card> _hand = new List<Card>();

        /// <summary>
        ///     Gets the Name of the Player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets the threshold score where Player stops drawing new cards.
        /// </summary>
        public int Threshold { get; }

        /// <summary>
        ///     Gets and sets the Score of the Player.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        ///     Gets and sets the Stand status of the Player.
        /// </summary>
        public bool Stand { get; protected set; }

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
            Threshold = threshold;
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
        ///     Plays a hand according to threshold.
        /// </summary>
        public virtual void PlayHand()
        {
            Stand = false;
            do
            {
                DrawCard();
            } while (Score < Threshold && _hand.Count() < 5);
            if (Score < 21) Stand = true;
        }

        /// <summary>
        ///   Removes all Cards from hand and adds them to Deck's discard pile.
        /// </summary>
        public void DiscardHand()
        {
            Deck.AddToDiscardPile(_hand);
            _hand.Clear();
            UpdateScore();
        }

        /// <summary>
        ///     Calculates and updates Score based on the hand.
        /// </summary>
        public void UpdateScore()
        {
            List<Card> aces = _hand.FindAll(card => card.Rank == 1);

            Score = 0;
            Score += _hand.Sum(card => card.Rank != 1 ? card.Rank : 0);

            if (aces.Count > 0)
            {
                if (Score + 13 + aces.Count <= 21)
                {
                    Score += 13 + aces.Count;
                }
                else { Score += aces.Count; }
            }
        }

        /// <summary>
        ///     Converts this Player to a human-readable string.
        /// </summary>
        /// <returns>A string representation of this Player.</returns>
        public override string ToString()
        {
            string playerHand = $"{Name.PadRight(10)}:";
            foreach (Card card in _hand)
            {
                playerHand += $" {card.ToString()}";
            }
            return playerHand;
        }

    }
}