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
            /*
            // BJHand Testing
            TestBJHandConstructor();

            ContinuePrompt();

            TestScoreIsBusted();
            //*/ 

            #region ---More Tests---
            /*
            // Hand Testing
            Console.WriteLine("Creating a shuffled deck...");
            Console.WriteLine();

            Deck d = new Deck();
            d.Shuffle();
            Random ranGen = new Random();
            int rnd = ranGen.Next(2, 14);

            Hand h = TestHandConstructor(d, rnd);

            ContinuePrompt();

            TestAddGetNumCard(d, h, rnd);

            ContinuePrompt();

            TestIndexOfHasCardDiscard(h, ranGen);
            //*/

            // Deck Testing
            //TestDeckConstructor();
            //TestDeckShuffle();
            //TestDeckDeal();

            /*
            // Card Testing
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
            TestDefaultConstructor();
            //*/
            #endregion

            // Exit
            Console.Write("Press any key to exit > ");
            Console.ReadKey();
        }

        #region ---BJHand Tests---
        private static void TestBJHandConstructor()
        {
            Console.WriteLine("Test BJHand constructor");
            Console.WriteLine();

            Console.WriteLine("Creating a BJHand with 2 cards...");

            Deck d = new Deck();
            BJHand bjHand = new BJHand(d, 2);

            Console.WriteLine("Expect: BJHand has 2 cards");
            Console.WriteLine("Result: BJHand has " + bjHand.NumCards.ToString() + " cards");
            Console.WriteLine();
        }

        private static void TestScoreIsBusted()
        {
            Random ranGen = new Random();

            // Non-Face Cards, Non-Aces
            Console.WriteLine("Testing non-face cards, non-Aces scoring...");
            Console.WriteLine();

            BJHand bjHand = new BJHand();
            bjHand.AddCard(new Card(2, ranGen.Next(1, 5)));
            bjHand.AddCard(new Card(8, ranGen.Next(1, 5)));

            Console.WriteLine(bjHand.ToString());

            Console.WriteLine("Expect: Score = 10");
            Console.WriteLine("Result: Score = " + bjHand.Score.ToString());
            Console.WriteLine();

            Console.WriteLine("Expect: IsBusted = False");
            Console.WriteLine("Result: IsBusted = " + bjHand.IsBusted.ToString());
            Console.WriteLine();

            bjHand.AddCard(new Card(9, ranGen.Next(1, 5)));
            bjHand.AddCard(new Card(5, ranGen.Next(1, 5)));

            Console.WriteLine(bjHand.ToString());

            Console.WriteLine("Expect: Score = 24");
            Console.WriteLine("Result: Score = " + bjHand.Score.ToString());
            Console.WriteLine();

            Console.WriteLine("Expect: IsBusted = True");
            Console.WriteLine("Result: IsBusted = " + bjHand.IsBusted.ToString());
            Console.WriteLine();

            ContinuePrompt();

            // Face Cards
            Console.WriteLine("Testing face card scoring ...");
            Console.WriteLine();

            bjHand = new BJHand();
            bjHand.AddCard(new Card(11, ranGen.Next(1, 5)));
            bjHand.AddCard(new Card(12, ranGen.Next(1, 5)));

            Console.WriteLine(bjHand.ToString());

            Console.WriteLine("Expect: Score = 20");
            Console.WriteLine("Result: Score = " + bjHand.Score.ToString());
            Console.WriteLine();

            Console.WriteLine("Expect: IsBusted = False");
            Console.WriteLine("Result: IsBusted = " + bjHand.IsBusted.ToString());
            Console.WriteLine();

            bjHand.AddCard(new Card(13, ranGen.Next(1, 5)));

            Console.WriteLine(bjHand.ToString());

            Console.WriteLine("Expect: Score = 30");
            Console.WriteLine("Result: Score = " + bjHand.Score.ToString());
            Console.WriteLine();

            Console.WriteLine("Expect: IsBusted = True");
            Console.WriteLine("Result: IsBusted = " + bjHand.IsBusted.ToString());
            Console.WriteLine();

            ContinuePrompt();

            Console.WriteLine("Testing ace scoring ...");
            Console.WriteLine();

            bjHand = new BJHand();
            bjHand.AddCard(new Card(1, ranGen.Next(1, 5)));
            bjHand.AddCard(new Card(10, ranGen.Next(1, 5)));

            Console.WriteLine(bjHand.ToString());

            Console.WriteLine("Expect: Score = 21");
            Console.WriteLine("Result: Score = " + bjHand.Score.ToString());
            Console.WriteLine();

            Console.WriteLine("Expect: IsBusted = False");
            Console.WriteLine("Result: IsBusted = " + bjHand.IsBusted.ToString());
            Console.WriteLine();

            bjHand.AddCard(new Card(1, ranGen.Next(1, 5)));

            Console.WriteLine(bjHand.ToString());

            Console.WriteLine("Expect: Score = 12");
            Console.WriteLine("Result: Score = " + bjHand.Score.ToString());
            Console.WriteLine();

            Console.WriteLine("Expect: IsBusted = False");
            Console.WriteLine("Result: IsBusted = " + bjHand.IsBusted.ToString());
            Console.WriteLine();
        }
        #endregion

        #region ---Hand Tests---
        private static Hand TestHandConstructor(Deck d, int num)
        {
            Console.WriteLine("Test parametered constructor");
            Console.WriteLine();

            Console.WriteLine("Creating a Hand object from " + num.ToString()
                + " cards from a Deck");
            Hand retVal = new Hand(d, num);
            Console.WriteLine("Result:");
            Console.WriteLine(retVal.ToString());

            return retVal;
        }

        private static void TestAddGetNumCard(Deck d, Hand h, int num)
        {
            Console.WriteLine("Check number of Cards in Hand");
            Console.WriteLine("Expect: " + num.ToString());
            Console.WriteLine("Result: " + h.NumCards.ToString());
            Console.WriteLine();

            Console.WriteLine("Add a card to the Hand from the Deck");
            Card c = d.Deal();
            h.AddCard(c);

            Console.WriteLine("Check number of Cards in Hand");
            Console.WriteLine("Expect: " + (num + 1).ToString());
            Console.WriteLine("Result: " + h.NumCards.ToString());
            Console.WriteLine();

            Console.WriteLine("Get card just added to Hand");
            Console.WriteLine("Expected: " + c.ToString());
            Console.WriteLine("Result: " + h.GetCard(num).ToString());
            Console.WriteLine();
        } 

        private static void TestIndexOfHasCardDiscard(Hand h, Random ranGen)
        {
            Console.WriteLine("Choose a random Card from the Hand");
            int rnd = ranGen.Next(0, h.NumCards);
            Card c = h.GetCard(rnd);
            Console.WriteLine("Card at index " + rnd.ToString()
                + " is " + c.ToString());

            Console.WriteLine("Test IndexOf(Card)");
            Console.WriteLine("Expect: " + rnd.ToString());
            Console.WriteLine("Result: " + h.IndexOf(c));
            Console.WriteLine();
            Console.WriteLine("Test IndexOf(Value)");
            Console.WriteLine("Expect: " + rnd.ToString());
            Console.WriteLine("Result: " + h.IndexOf(c.Value));
            Console.WriteLine();
            Console.WriteLine("Test IndexOf(Suit, Value)");
            Console.WriteLine("Expect: " + rnd.ToString());
            Console.WriteLine("Result: " + h.IndexOf(c.Suit, c.Value));
            Console.WriteLine();

            Console.WriteLine("Test HasCard(Card)");
            Console.WriteLine("Expect: True");
            Console.WriteLine("Result: " + h.HasCard(c));
            Console.WriteLine();
            Console.WriteLine("Test HasCard(Value)");
            Console.WriteLine("Expect: True");
            Console.WriteLine("Result: " + h.HasCard(c.Value));
            Console.WriteLine();
            Console.WriteLine("Test HasCard(Suit, Value)");
            Console.WriteLine("Expect: True");
            Console.WriteLine("Result: " + h.HasCard(c.Suit, c.Value));
            Console.WriteLine();

            ContinuePrompt();

            Console.WriteLine("Discard that Card");
            Card dis = h.Discard(rnd);
            Console.WriteLine("The card " + dis.ToString()
                + " at index " + rnd.ToString()
                + " has been discarded");

            Console.WriteLine("Test IndexOf(Card)");
            Console.WriteLine("Expect: -1");
            Console.WriteLine("Result: " + h.IndexOf(c));
            Console.WriteLine();
            Console.WriteLine("Test IndexOf(Value)");
            Console.WriteLine("Expect: -1");
            Console.WriteLine("Result: " + h.IndexOf(c.Value));
            Console.WriteLine();
            Console.WriteLine("Test IndexOf(Suit, Value)");
            Console.WriteLine("Expect: -1");
            Console.WriteLine("Result: " + h.IndexOf(c.Suit, c.Value));
            Console.WriteLine();

            Console.WriteLine("Test HasCard(Card)");
            Console.WriteLine("Expect: False");
            Console.WriteLine("Result: " + h.HasCard(c));
            Console.WriteLine();
            Console.WriteLine("Test HasCard(Value)");
            Console.WriteLine("Expect: False");
            Console.WriteLine("Result: " + h.HasCard(c.Value));
            Console.WriteLine();
            Console.WriteLine("Test HasCard(Suit, Value)");
            Console.WriteLine("Expect: False");
            Console.WriteLine("Result: " + h.HasCard(c.Suit, c.Value));
            Console.WriteLine();

        }

        #endregion

        #region ---Deck Tests---
        static void TestDeckConstructor()
        {
            Deck d = new Deck();

            Console.WriteLine("Testing deck of cards default constructor");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("ToString.  Expect a ton of cards in order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckShuffle()
        {
            Deck d = new Deck();
            d.Shuffle();
            Console.WriteLine("Testing deck of cards shuffle");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
            Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckDeal()
        {
            Deck d = new Deck();
            Card c = d.Deal();

            Console.WriteLine("Testing deck of cards deal");
            Console.WriteLine("NumCards.  Expecting 51. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);

            // now let's deal them all and see what happens at the end
            for (int i = 1; i <= 51; i++)
                c = d.Deal();
            Console.WriteLine("Dealt all 52 cards");
            Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting true. " + d.IsEmpty);
            Console.WriteLine("Last Card should be King of Spades. " + c);
            Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));

            Console.WriteLine();
        }
        #endregion

        #region ---Card Tests---
        /// <summary>
        /// TestParameteredConstructor - Runs three tests that demonstrate the behavior of the constructor 
        /// with valid and invalid information in each propert
        /// </summary>
        private static void TestParameteredConstructor()
        {
            Console.WriteLine("Test Parametered Contructor");
            Console.WriteLine();

            Console.WriteLine("Creating Ace of Hearts with (1, 3)...");
            try
            {
                Card aCard = new Card(1, 3);
                Console.WriteLine("Created card > " + aCard.ToString());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("Creating Ace of Hearts with (1, 5) where 5 is an invalid suit...");
            try
            {
                Card aCard = new Card(1, 5);
                Console.WriteLine("Created card > " + aCard.ToString());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Creating Ace of Hearts with (15, 3) where 15 is an invalid value...");
            try
            {
                Card aCard = new Card(15, 3);
                Console.WriteLine("Created card > " + aCard.ToString());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
        private static void TestDefaultConstructor()
        {
            Console.WriteLine("Test Default Contructor");
            Console.WriteLine();
            Card aCard;

            try
            {
                aCard = new Card();
                Console.WriteLine("Expect valid card as provided by ToString() method > " + aCard.ToString());
                //Console.WriteLine("Should have a valid suit and IsValidSuit is " + Card.IsValidSuit(aCard.Suit).ToString());
                //Console.WriteLine("Should have a valid value and IsValidValue is " + Card.IsValidValue(aCard.Suit).ToString());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }

}
