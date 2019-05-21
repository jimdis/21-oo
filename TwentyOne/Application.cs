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
                List<Card> hand = new List<Card>();

                for (int i = 0; i < 5; i++)
                {
                    hand.Add(Deck.RemoveCard());
                }

                Deck.AddToDiscardPile(hand);

                List<Card> stock = Deck.getStock();
                Console.WriteLine("Stock:");
                foreach (Card card in stock)
                {
                    Console.WriteLine(card.ToString());
                }
                List<Card> pile = Deck.getPile();
                Console.WriteLine("Pile:");
                foreach (Card card in pile)
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