using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DominoClasses;

namespace DominoTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // BoneYard Tests
            //TestBoneYardConstructor();
            //TestBoneYardShuffle();
            TestBoneYardDraw();

            /*
            // Domino Tests
            TestDominoConstructors();
            TestDominoToString();
            TestDominoPropertyGetters();
            TestDominoPropertySetters();
            TestDominoFlip();
            TestDominoScore();
            TestDominoIsDouble();
            TestDominoPropertySettersWithExceptions();
            //*/

            Console.ReadLine();
        }

        #region ---BoneYard Tests---
        static void TestBoneYardConstructor()
        {
            int dotMax = 6;
            BoneYard set = new BoneYard(dotMax);

            Console.WriteLine("Testing set of dominos constructor");
            Console.WriteLine("NumCards.  Expecting 28. " + set.DominosRemaining);
            Console.WriteLine("IsEmpty.   Expecting false. " + set.IsEmpty());
            Console.WriteLine("ToString.  Expect a long list of dominos in order.\n" + set.ToString());
            Console.WriteLine();
        }
        
        static void TestBoneYardShuffle()
        {
            int dotMax = 6;
            BoneYard set = new BoneYard(dotMax);

            set.Shuffle();
            Console.WriteLine("Testing set of dominos to shuffle");
            Console.WriteLine("NumCards.  Expecting 28. " + set.DominosRemaining);
            Console.WriteLine("IsEmpty.   Expecting false. " + set.IsEmpty());
            Console.WriteLine("First domino will rarely be Side 1: 0 Side 2: 0 > " + set[0]);
            Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + set.ToString());
            Console.WriteLine();
        }

        static void TestBoneYardDraw()
        {
            int dotMax = 6;
            BoneYard set = new BoneYard(dotMax);

            Domino d = set.Draw();

            Console.WriteLine("Testing boneyard of dominos draw");
            Console.WriteLine("DominosRemaining.  Expecting 27. " + set.DominosRemaining);
            Console.WriteLine("IsEmpty.   Expecting false. " + set.IsEmpty());
            Console.WriteLine("Domino drawn should be Side 1: 0 Side 2: 0 > " + d.ToString());

            // now let's deal them all and see what happens at the end
            int total = set.DominosRemaining;
            for (int i = 1; i <= total; i++)
                d = set.Draw();
            Console.WriteLine("Drew all 28 dominos");
            Console.WriteLine("DominosRemaining.  Expecting 0. " + set.DominosRemaining);
            Console.WriteLine("IsEmpty.   Expecting true. " + set.IsEmpty());
            Console.WriteLine("Last domino should be Side 1: 6 Side 2: 6 > " + d);
            Console.WriteLine("Drawing again should return null. Expecting true. " + (set.Draw() == null));

            Console.WriteLine();
        }
        #endregion


        #region ---Domino Tests---
        static void TestDominoConstructors()
        {
            Domino d1 = new Domino();
            Domino d2 = new Domino(12, 6);

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values (0, 0). " + d1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 12, 6 " + d2.ToString());
            Console.WriteLine();
        }

        static void TestDominoToString()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 12, 6 " + d1.ToString());
            Console.WriteLine("Expecting 12, 6 " + d1);
            Console.WriteLine();
        }

        static void TestDominoPropertyGetters()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Side 1.  Expecting 12. " + d1.Side1);
            Console.WriteLine("Side 2.  Expecting 6. " + d1.Side2);
            Console.WriteLine();
        }

        static void TestDominoPropertySetters()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing setters");
            d1.Side1 = 4;
            d1.Side2 = 5;
            Console.WriteLine("Expecting 4, 5 " + d1);
            Console.WriteLine();
        }

        static void TestDominoPropertySettersWithExceptions()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing invalid setter values");
            try
            {
                d1.Side1 = -1;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side1 is negative");
                Console.WriteLine("Side1 should still be 12 " + d1.Side1);
            }
            try
            {
                d1.Side1 = 13;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side1 is more than 12");
                Console.WriteLine("Side1 should still be 12 " + d1.Side1);
            }
            try
            {
                d1.Side2 = -1;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side2 is negative");
                Console.WriteLine("Side2 should still be 6 " + d1.Side2);
            }
            try
            {
                d1.Side2 = 13;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side2 is more than 12");
                Console.WriteLine("Side2 should still be 6 " + d1.Side2);
            }
            try
            {
                d1 = new Domino(-1, 15);
            }
            catch
            {
                Console.WriteLine("Constructor should also throw an exception when values are invalid");
                Console.WriteLine("d1 is now " + d1);
            }
            Console.WriteLine();
        }

        static void TestDominoScore()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing Score");
            Console.WriteLine("Score.  Expecting 18. " + d1.Score);
            Console.WriteLine();
        }

        static void TestDominoIsDouble()
        {
            Domino d1 = new Domino(12, 12);
            Domino d2 = new Domino(12, 6);

            Console.WriteLine("Testing IsDouble");
            Console.WriteLine("12 and 12.  Expecting true. " + d1.IsDouble());
            Console.WriteLine("12 and 6.  Expecting false. " + d2.IsDouble());
            Console.WriteLine();
        }

        static void TestDominoFlip()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing Flip");
            Console.WriteLine("Before.  Expecting 12, 6. " + d1);
            d1.Flip();
            Console.WriteLine("After.  Expecting 6, 12. " + d1);
            Console.WriteLine();
        }
        #endregion
    }
}
