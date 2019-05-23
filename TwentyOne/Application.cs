using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyOne
{
    /// <summary>
    /// Represents a console application.
    /// </summary>
    public static class Application
    {

        /// <summary>
        /// Number of players in the game.
        /// </summary>
        private static int numberOfPlayers = 10;

        /// <summary>
        /// Range of thresholds to set at random for Players and Dealer (10-18).
        /// </summary>
        private static IEnumerable<int> thresholds = Enumerable.Range(10, 9);

        /// <summary>
        /// Instantiates a new instance of Random.
        /// </summary>
        private static Random rng = new Random();

        /// <summary>
        /// Runs an application.
        /// </summary>
        public static void Run()
        {
            try
            {
                PlayGame(numberOfPlayers);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }
        }

        /// <summary>
        ///     Runs a Game of 21 and outputs the results to the Console.
        /// </summary>
        /// <param name="numberOfPlayers">The number of players in the game</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if number of players is set to < 1 or > 36.</exception>
        private static void PlayGame(int numberOfPlayers)
        {

            if (numberOfPlayers < 1 || numberOfPlayers > 36)
            {
                throw new ArgumentOutOfRangeException("Number of Players must be between 1 and 36");
            }

            Dealer dealer = new Dealer(rng.Next(thresholds.Min(), thresholds.Max()));

            Console.WriteLine($"\n--------------------------------------");
            Console.WriteLine($"Running new game with {numberOfPlayers} players!");
            Console.WriteLine($"Dealer's threshold is set to {dealer.Threshold}");
            Console.WriteLine($"--------------------------------------\n");

            Player[] players = new Player[numberOfPlayers];
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = new Player($"Player #{i + 1}", rng.Next(thresholds.Min(), thresholds.Max()));
            }

            int dealerWins = 0;

            foreach (Player player in players) player.DrawCard();

            foreach (Player player in players)
            {
                player.PlayHand();
                if (player.Stand) dealer.PlayHand();
                if (CheckWinner(player, dealer) == dealer) dealerWins++;
                ViewResult(player, dealer);
                player.DiscardHand();
                dealer.DiscardHand();
            }
            Console.WriteLine($"Dealer won {dealerWins} out of {numberOfPlayers} hands...\n");
        }

        /// <summary>
        ///     Checks if Player or Dealer won the game.
        /// </summary>
        /// <param name="player">A Dealer.</param>
        /// <param name="dealer">A Player.</param>
        /// <returns>The winner of the game.</returns>
        private static Player CheckWinner(Player player, Dealer dealer)
        {
            if (player.Score > 21) return dealer;
            if (dealer.Score > 21) return player;
            if (player.Score > dealer.Score) return player;
            return dealer;
        }

        /// <summary>
        ///     Outputs the result of a game to the console.
        /// </summary>
        /// <param name="player">A Dealer.</param>
        /// <param name="dealer">A Player.</param>
        private static void ViewResult(Player player, Dealer dealer)
        {
            Console.WriteLine($"{player.Name} (Threshold {player.Threshold})");
            Console.WriteLine("----------------------------------------");
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
            Console.WriteLine($"{CheckWinner(player, dealer).Name} Wins!");
            Console.WriteLine("----------------------------------------\n");
        }
    }
}