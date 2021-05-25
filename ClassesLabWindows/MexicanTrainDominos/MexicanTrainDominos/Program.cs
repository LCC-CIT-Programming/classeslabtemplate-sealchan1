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


        

        #endregion
    }
}
