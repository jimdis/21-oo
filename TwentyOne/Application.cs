using System;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a console application.
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Runs an application.
        /// </summary>
        public static void Run()
        {
            try
            {
                List<Card> stock = Deck.getStock();
                foreach (Card card in stock)
                {
                    Console.WriteLine(card.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }

        }
    }
}