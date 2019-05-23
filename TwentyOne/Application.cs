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

                int playerThreshold;
                do
                {
                    Console.Write("Players should stand at score [1 - 21]: ");
                } while (!(int.TryParse(Console.ReadLine(), out playerThreshold) &&
                        playerThreshold >= 1 &&
                        playerThreshold <= 21));

                int dealerThreshold;
                do
                {
                    Console.Write("Dealer should stand at score [1 - 21]: ");
                } while (!(int.TryParse(Console.ReadLine(), out dealerThreshold) &&
                dealerThreshold >= 1 &&
                dealerThreshold <= 21));

                PlayGame(numberOfPlayers, playerThreshold, dealerThreshold);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }

        }

        private static void PlayGame(int numberOfPlayers, int playerThreshold, int dealerThreshold)
        {
            Dealer dealer = new Dealer(dealerThreshold);

            Player[] players = new Player[numberOfPlayers];
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = new Player($"Player #{i + 1}", playerThreshold);
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

        private static Player CheckWinner(Player player, Dealer dealer)
        {
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
            Console.WriteLine($"{CheckWinner(player, dealer).Name} Wins!\n");
        }
    }
}