using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // Automated testing
            TestParameteredConstructor();

            ContinuePrompt();

            // Test Ace of Clubs (isAce, isBlack, isClubs) 
            Card club = new Card(1, 1);
            TestBooleanFeatureDetectors(club, true, true, true, false, false, false, false);

            ContinuePrompt();

            // Test 4 of Diamonds (isDiamond, isRed)
            Card diamond = new Card(4, 2);
            TestBooleanFeatureDetectors(diamond, false, false, false, true, false, false, false);

            ContinuePrompt();

            // Test 8 of Hearts (isHeart, isRed) 
            Card heart = new Card(8, 3);
            TestBooleanFeatureDetectors(heart, false, false, false, false, false, true, false);

            ContinuePrompt();

            // Test Queen of Spades (isBlack, IsFaceCard, IsSpade) 
            Card spade = new Card(12, 4);
            TestBooleanFeatureDetectors(spade, false, true, false, false, true, false, true);

            ContinuePrompt();


            // Compare Ace of Spades to each card
            Card match = new Card(1, 4);
            TestMatch(match, club, false, true);
            TestMatch(match, diamond, false, false);
            TestMatch(match, heart, false, false);
            TestMatch(match, spade, true, false);

            // Create a random valid card with the default constructor...
            Card testCard = TestDefaultConstructor();

            // Exit
            Console.Write("Press any key to exit > ");
            Console.ReadKey();
        }

        /// <summary>
        /// TestParameteredConstructor - Runs three tests that demonstrate the behavior of the constructor 
        /// with valid and invalid information in each propert
        /// </summary>
        private static void TestParameteredConstructor()
        {
            Console.WriteLine("Test Parametered Contructor");
            Console.WriteLine();

            Console.WriteLine("Creating Ace of Hearts with (1, 3)...");
            Card aCard = new Card(1, 3);
            Console.WriteLine("Created card > " + aCard.ToString());
            Console.WriteLine();

            Console.WriteLine("Creating Ace of Hearts with (1, 5) where 5 is an invalid suit...");
            aCard = new Card(1, 5);
            Console.WriteLine("Created card > " + aCard.ToString());
            Console.WriteLine();

            Console.WriteLine("Creating Ace of Hearts with (15, 3) where 15 is an invalid value...");
            aCard = new Card(15, 3);
            Console.WriteLine("Created card > " + aCard.ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// ContinuePrompt - Key press for human control of console output pacing
        /// </summary>
        private static void ContinuePrompt()
        {
            Console.Write("Press any key to continue > ");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// TestBooleanFeatureDetectors - Given a card and a set of expected results,
        /// show the accuracy of the various boolean methods 
        /// </summary>
        /// <param name="aCard">The Card to check</param>
        /// <param name="ace">True if Ace</param>
        /// <param name="black">True if black suit: Clubs or Spades</param>
        /// <param name="club">True if clubs</param>
        /// <param name="diamond">True if diamonds</param>
        /// <param name="face">True if a face card: Jack, Queen or King</param>
        /// <param name="heart">True if hearts</param>
        /// <param name="spade">True if spades</param>
        private static void TestBooleanFeatureDetectors(Card aCard, bool ace, bool black, bool club, bool diamond, bool face, bool heart, bool spade)
        {
            Console.WriteLine("Testing boolean feature detectors of " + aCard.ToString());
            Console.WriteLine();

            Console.WriteLine("IsBlack should be " + black.ToString() + " and it is " + aCard.IsBlack().ToString());
            Console.WriteLine("IsRed should be " + (!black).ToString() + " and it is " + aCard.IsRed().ToString());

            Console.WriteLine("IsClub should be " + club.ToString() + " and it is " + aCard.IsClub().ToString());
            Console.WriteLine("IsDiamond should be " + diamond.ToString() + " and it is " + aCard.IsDiamond().ToString());
            Console.WriteLine("IsHeart should be " + heart.ToString() + " and it is " + aCard.IsHeart().ToString());
            Console.WriteLine("IsSpade should be " + spade.ToString() + " and it is " + aCard.IsSpade().ToString());

            Console.WriteLine("IsAce should be " + ace.ToString() + " and it is " + aCard.IsAce().ToString());
            Console.WriteLine("IsFaceCard should be " + face.ToString() + " and it is " + aCard.IsFaceCard().ToString());

            Console.WriteLine();
        }

        /// <summary>
        /// TestMatch - Test the Card matching methods
        /// </summary>
        /// <param name="one">First card</param>
        /// <param name="two">Second card</param>
        /// <param name="sameSuit">True if suit is the same</param>
        /// <param name="sameValue">True if value is the same</param>
        private static void TestMatch(Card one, Card two, bool sameSuit, bool sameValue)
        {
            Console.WriteLine("Test Card Matching - " + one.ToString() + " and " + two.ToString());
            Console.WriteLine();


            Console.WriteLine("HasMatchingSuit should be " + sameSuit.ToString() + " and it is " + one.HasMatchingSuit(two).ToString());
            Console.WriteLine("HasMatchingValue should be " + sameValue.ToString() + " and it is " + one.HasMatchingValue(two).ToString());
            Console.WriteLine();
        }

        /// <summary>
        /// TestDefaultConstructor - Show a Card created randomly by the default constructor
        /// </summary>
        /// <returns></returns>
        private static Card TestDefaultConstructor()
        {
            Console.WriteLine("Test Default Contructor");
            Console.WriteLine();
 
            Card aCard = new Card();
            Console.WriteLine("Expect valid card as provided by ToString() method > " + aCard.ToString());
            Console.WriteLine("Should have a valid suit and IsValidSuit is " + Card.IsValidSuit(aCard.Suit).ToString());
            Console.WriteLine("Should have a valid value and IsValidValue is " + Card.IsValidValue(aCard.Suit).ToString());
            Console.WriteLine();

            return aCard;
        }
    }

}
