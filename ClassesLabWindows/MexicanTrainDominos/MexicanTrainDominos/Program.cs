using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DominoClasses;

namespace MexicanTrainDominos
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ---PlayerTrain Tests---
            //*
            TestOpenCloseIsOpen();

            //*/
            #endregion


            #region ---MexicanTrain Tests---
            /* Mexican Train Tests
            TestMTConstructorProperties();

            ContinuePrompt();

            TestMTIsPlayable();

            ContinuePrompt();

            TestMTPlay();
            //*/
            #endregion---


            // Exit
            Console.Write("Press any key to exit > ");
            Console.ReadKey();
        }


        #region ---PlayerTrain Tests---

        private static void TestOpenCloseIsOpen()
        {
            Console.WriteLine("Testing Open(), Close(), IsOpen");
            Console.WriteLine(); 
            
            Random rndGen = new Random();
            int engVal = rndGen.Next(1, 7);
            PlayerTrain test = new PlayerTrain(engVal);

            Console.WriteLine("Expect: IsOpen = False");
            Console.WriteLine("Result: IsOpen = " + test.IsOpen.ToString());
            Console.WriteLine();

            Console.WriteLine("Calling Open()");
            Console.WriteLine();

            test.Open();

            Console.WriteLine("Expect: IsOpen = True");
            Console.WriteLine("Result: IsOpen = " + test.IsOpen.ToString());
            Console.WriteLine();

            Console.WriteLine("Calling Close()");
            Console.WriteLine();

            test.Close();

            Console.WriteLine("Expect: IsOpen = False");
            Console.WriteLine("Result: IsOpen = " + test.IsOpen.ToString());
            Console.WriteLine();
        }

        #endregion


        #region ---MexicanTrain Tests---

        private static void TestMTConstructorProperties()
        {
            Console.WriteLine("Test MexicanTrain constructor");
            Console.WriteLine();

            Random rndGen = new Random();
            int engVal = rndGen.Next(1, 7);
            MexicanTrain test = new MexicanTrain(engVal);

            const int MAXDOTS = 6;
            BoneYard b = new BoneYard(MAXDOTS);
            b.Shuffle();

            // IsEmpty (True)
            Console.WriteLine("Expect: IsEmpty True");
            Console.WriteLine("Result: IsEmpty " + test.IsEmpty.ToString());
            Console.WriteLine();

            int handSize = rndGen.Next(1, 7);
            Domino last = new Domino();

            for(int i = 0; i < handSize; i++)
            {
                Domino dom = b.Draw();

                if(i == handSize -1)
                {
                    last = dom;
                }

                test.Add(dom);
            }

            // Dominos Drawn
            Console.WriteLine("Dominos: \n" + test.ToString());

            // Count
            Console.WriteLine("Expect: Count " + handSize.ToString());
            Console.WriteLine("Result: Count " + test.Count.ToString());
            Console.WriteLine();

            // EngineValue
            Console.WriteLine("Expect: Engine Value " + engVal.ToString());
            Console.WriteLine("Result: Engine Value " + test.EngineValue.ToString());
            Console.WriteLine();

            // IsEmpty (False)
            Console.WriteLine("Expect: IsEmpty False");
            Console.WriteLine("Result: IsEmpty " + test.IsEmpty.ToString());
            Console.WriteLine();

            // LastDomino
            Console.WriteLine("Expect: LastDomino is " + last.ToString());
            Console.WriteLine("Result: LastDomino is " + test.LastDomino.ToString());
            Console.WriteLine();

            // PlayableValue
            Console.WriteLine("Expect: PlayableValue is " + last.Side2.ToString());
            Console.WriteLine("Result: PlayableValue is " + test.PlayableValue.ToString());
            Console.WriteLine();

            // Index
            Console.WriteLine("Expect: last domino by index is " + last.ToString());
            Console.WriteLine("Result: last domino by index is " + test[test.Count - 1].ToString());
            Console.WriteLine();
        }

        private static void TestMTIsPlayable()
        {
            Console.WriteLine("Test MexicanTrain IsPlayable");
            Console.WriteLine();

            Random rndGen = new Random();
            int engVal = rndGen.Next(1, 7);
            MexicanTrain test = new MexicanTrain(engVal);

            const int MAXDOTS = 6;
            BoneYard b = new BoneYard(MAXDOTS);
            b.Shuffle();

            const int LOOPS = 10;

            Console.WriteLine("Engine value = " + engVal);
            Console.WriteLine("Playable value = " + test.PlayableValue);
            Console.WriteLine();

            Domino d;

            for (int i = 0; i < LOOPS; i++)
            {
                d = b.Draw();
                Console.WriteLine(d.ToString());

                bool checkPlay = d.Side1 == test.PlayableValue || d.Side2 == test.PlayableValue;
                bool checkFlip = checkPlay ? d.Side1 != test.PlayableValue : false;  // Good form?

                Console.WriteLine("Test IsPlayable");
                Console.WriteLine("Expect: " + checkPlay.ToString());
                Console.WriteLine("Result: " + test.IsPlayable(new Hand(), d, out bool mustFlip).ToString());
                Console.WriteLine("Test mustFlip");
                Console.WriteLine("Expect: " + checkFlip.ToString());
                Console.WriteLine("Result: " + mustFlip.ToString());
                Console.WriteLine();
            }
        }

        private static void TestMTPlay()
        {
            Console.WriteLine("Test MexicanTrain Play");
            Console.WriteLine();

            const int MAXDOTS = 6;
            Random rndGen = new Random();
            int engVal = rndGen.Next(1, MAXDOTS + 1);
            
            // Test Train
            MexicanTrain test = new MexicanTrain(engVal);
            
            // Shuffled Boneyard
            BoneYard b = new BoneYard(MAXDOTS);
            b.Shuffle();

            // Find Unplayable
            Hand h = new Hand();
            Domino d;
            do
            {
                d = b.Draw();
            } while (test.IsPlayable(h, d, out bool mustFlip));

            Console.WriteLine("Test unplayable");
            Console.WriteLine();
            Console.WriteLine("Train playable value: " + test.PlayableValue.ToString());
            Console.WriteLine("Drew unplayable: " + d.ToString());
            Console.WriteLine("Train Before: " + test.ToString());

            Console.WriteLine("Expect: Domino " + d.ToString() + "does not match last domino in the train and cannot be played.");
            string result = String.Empty;

            try
            {
                test.Play(h, d);
            }
            catch(Exception ex)
            {
                result = ex.Message;
            }

            Console.WriteLine("Result: " + result);

            Console.WriteLine("Train After: " + test.ToString());
            Console.WriteLine();

            //Find Playable
            do
            {
                d = b.Draw();
            } while (!test.IsPlayable(h, d, out bool mustFlip));

            Console.WriteLine("Test playable");
            Console.WriteLine();
            Console.WriteLine("Train playable value: " + test.PlayableValue.ToString());
            Console.WriteLine("Drew playable: " + d.ToString());
            Console.WriteLine("Train Before: " + test.ToString());
            
            test.Play(h, d);

            Console.WriteLine("Train After: " + test.ToString());
        }

        #endregion

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
    }
}
