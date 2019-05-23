using System;
namespace TwentyOne
{
    /// <summary>
    /// Represents a Dealer.
    /// </summary>
    public class Dealer : Player
    {
        /// <summary>
        ///     Initializes a new instance of the Dealer class.
        /// </summary>
        /// <param name="threshold">Threshold of the Dealer.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if Threshold is set to < 1 or > 21.</exception>
        public Dealer(int threshold) : base("Dealer", threshold) { }

        /// <summary>
        ///     Plays a hand according to threshold.
        /// </summary>
        public override void PlayHand()
        {
            Stand = false;
            do
            {
                DrawCard();
            } while (Score < _threshold);
            if (Score < 21) Stand = true;
        }
    }
}