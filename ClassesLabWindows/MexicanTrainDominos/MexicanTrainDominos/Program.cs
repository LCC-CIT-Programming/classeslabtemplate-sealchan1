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
            #region ---MexicanTrain Tests
            //* Mexican Train Tests
            TestMTConstructorProperties();

            ContinuePrompt();

            TestMTIsPlayable();
            //*/
            #endregion


            // Exit
            Console.Write("Press any key to exit > ");
            Console.ReadKey();
        }


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
            //Domino[] drawn = new Domino[LOOPS];

            Console.WriteLine("Engine value = " + engVal);
            Console.WriteLine("Playable value = " + test.PlayableValue);
            Console.WriteLine();

            Domino d;

            for (int i = 0; i < LOOPS; i++)
            {
                d = b.Draw();
                //Domino trainD = test.LastDomino;
                
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
