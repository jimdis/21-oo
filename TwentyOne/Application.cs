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
                int numberOfPlayers;
                do
                {
                    Console.Write("Select number of players [1 - 20]: ");
                } while (!(int.TryParse(Console.ReadLine(), out numberOfPlayers) &&
                        numberOfPlayers >= 1 &&
                        numberOfPlayers <= 20));

                Dealer dealer = new Dealer(16);

                Player[] players = new Player[numberOfPlayers];
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    players[i] = new Player($"Player #{i + 1}", 15);
                }

                foreach (Player player in players) player.DrawCard();

                foreach (Player player in players)
                {
                    player.PlayHand();
                    if (player.Stand) dealer.PlayHand();
                    ViewResult(player, dealer);
                    player.DiscardHand();
                    dealer.DiscardHand();
                }
                Deck.ResetDeck();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }

        }

        private static Player CheckWinner(Player player, Dealer dealer)
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
        private static void ViewResult(Player player, Dealer dealer)
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