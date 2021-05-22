using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {

            // Intro
            Console.WriteLine("BLACKJACK");
            Console.WriteLine();

            int playerWins = 0;
            int dealerWins = 0;

            // Game Loop (Round)
            do
            {
                // Reshuffle deck every round
                Deck d = new Deck();
                d.Shuffle();

                BJHand player = new BJHand(d, 2);
                BJHand dealer = new BJHand(d, 2);

                // Turn "Loop"
                // Player (then dealer), player continues until Bust or Stand
                bool stand = false;
                bool bust = false;

                while(!stand && !bust)
                {
                    Console.WriteLine("Player");
                    Console.WriteLine(player.ToString());

                    stand = !willHit();
                    Console.WriteLine();

                    if (!stand)
                    {
                        player.AddCard(d.Deal());
                    }

                    bust = player.Score > 21;
                }

                // Dealer
                bool bustD = false;
                bool standD = false;

                if(!bust)
                {
                    while (!standD && !bustD)
                    {
                        //Console.WriteLine("Dealer");
                        //Console.WriteLine(dealer.ToString());

                        if (dealer.Score <= 16)
                        {
                            dealer.AddCard(d.Deal());
                        }
                        else
                        {
                            standD = true;
                        }

                        bustD = dealer.Score > 21;
                    }
                }

                // Player Score and Hand
                Console.WriteLine("Player Score: " + player.Score.ToString() + (bust ? " (Bust)" : ""));
                Console.WriteLine(player.ToString());

                // Dealer Score and Hand
                Console.WriteLine("Dealer Score: " + dealer.Score.ToString() + (bustD ? " (Bust)" : ""));
                Console.WriteLine(dealer.ToString());

                // Announce winner
                if(bust || (!bustD && dealer.Score > player.Score))
                {
                    Console.WriteLine("The Dealer has won!");
                    dealerWins++;
                }
                else if (bustD || player.Score > dealer.Score)
                {
                    Console.WriteLine("The Player has won!");
                    playerWins++;
                }
                else
                {
                    Console.WriteLine("It's a draw!");
                }

                // Show running round score
                Console.WriteLine("Player/Dealer Wins: " + playerWins.ToString() + "/" + dealerWins.ToString());

                // Another game?
            } while (playAgain());

            // Exit
            Console.Write("Press any key to exit > ");
            Console.ReadKey();
        }

        private static bool willHit()
        {
            bool retVal = false;
            bool valid = false;
            char input = 'a';

            do
            {
                Console.Write("H)it or S)tand? > ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if(input == 'h' || input == 'H')
                {
                    retVal = true;
                    valid = true;
                }
                else if(input == 's' || input == 'S')
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid response.  Try again");
                }

            } while (!valid);

            return retVal;
        }

        private static bool playAgain()
        {
            bool retVal = false;
            bool valid = false;

            while(!valid)
            {
                Console.Write("Play again? (y/n) > ");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (input == 'y' || input == 'Y')
                {
                    retVal = true;
                    valid = true;
                }
                else if (input == 'n' || input == 'N')
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid response. Try again");
                }
            }

            Console.WriteLine();
            return retVal;
        }
    }
}

// Intro

// Game Loop (Round)
// Opt: Reshuffle deck every five rounds
// Reshuffle deck every round

// Turn Loop
// Alternate between player and computer
// Player then dealer, player continues until Bust or Stand
// Bust instant loose
// Options: Hit or Stand
// Dealer options strictly dictated by current score
// End Turn Loop

// Score once both players are at Stand or if Bust
// Announce winner

// End Game Loop
// Another game?

// Exit

// The game begins by creating the necessary objects, a deck and 2 blackjack hands (one for the player and one for the dealer),
// shuffling the deck and
// dealing 2 cards to the player and 2 cards to the dealer.

// In order to win blackjack, the player has to beat the dealer.
// If the final combined value of the cards in the player's hand is greater than that of dealer's hand, the player  wins.
// The player can "HIT" one or more times to add an additional card OR "STAND" to stop.
// The dealer always has to hit if the value of their hand is 16 or lower, and must stop hitting when the value reaches 17 or more.

// Your application must allow the player to play one or more hands
// and must keep track of the number of hands won by the player and the dealer.
// Any input from the user should be appropriately validated by the application.
