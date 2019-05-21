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
                Player player1 = new Player("Player #1", 15);
                Player player2 = new Player("Player #2", 10);
                Player dealer = new Player("Dealer", 16);

                player1.DrawCard();
                player2.DrawCard();
                player1.PlayHand();
                if (player1.Stand) dealer.PlayHand();
                Console.WriteLine(player1.ToString());
                Console.WriteLine(player1.Score);
                Console.WriteLine(dealer.ToString());
                Console.WriteLine(dealer.Score);
                player2.PlayHand();
                if (player2.Stand) dealer.PlayHand();
                Console.WriteLine(player2.ToString());
                Console.WriteLine(player2.Score);
                Console.WriteLine(dealer.ToString());
                Console.WriteLine(dealer.Score);


                // List<Card> hand = new List<Card>();

                // for (int i = 0; i < 5; i++)
                // {
                //     hand.Add(Deck.RemoveCard());
                // }

                // Deck.AddToDiscardPile(hand);

                // List<Card> stock = Deck.getStock();
                // Console.WriteLine("Stock:");
                // foreach (Card card in stock)
                // {
                //     Console.WriteLine(card.ToString());
                // }
                // List<Card> pile = Deck.getPile();
                // Console.WriteLine("Pile:");
                // foreach (Card card in pile)
                // {
                //     Console.WriteLine(card.ToString());
                // }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }

        }
    }
}