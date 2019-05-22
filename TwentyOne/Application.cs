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
                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine($"Game number: {i}");
                    Player player1 = new Player("Player #1", 9);
                    Player player2 = new Player("Player #2", 9);
                    Player dealer = new Player("Dealer", 9);

                    player1.DrawCard();
                    player2.DrawCard();
                    player1.PlayHand();
                    if (player1.Stand) dealer.PlayHand();
                    ViewResult(player1, dealer);
                    player1.DiscardHand();
                    dealer.DiscardHand();
                    player2.PlayHand();
                    if (player2.Stand) dealer.PlayHand();
                    ViewResult(player2, dealer);
                    player2.DiscardHand();
                    dealer.DiscardHand();
                    Deck.ResetDeck();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }

        }

        private static Player CheckWinner(Player player, Player dealer)
        {
            if (player.Score == dealer.Score) return null;
            if (player.Score > 21) return dealer;
            if (dealer.Score > 21) return player;
            if (player.Score > dealer.Score)
            {
                return player;
            }
            else { return dealer; }
        }
        private static void ViewResult(Player player, Player dealer)
        {
            Player[] participants = { player, dealer };
            foreach (Player p in participants)
            {
                String hand = $"{p.ToString()}";
                if (p.Score == 0)
                {
                    hand += " -";
                }
                else
                {
                    hand += $" ({p.Score}) {(p.Score > 21 ? "(BUSTED!)" : null)}";
                }
                Console.WriteLine(hand);
            }
            String winner = CheckWinner(player, dealer)?.Name;
            Console.WriteLine($"{winner}{(winner != null ? " Wins!" : "Draw!")}\n");
        }
    }
}