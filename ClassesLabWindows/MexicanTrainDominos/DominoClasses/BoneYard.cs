using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class BoneYard
    {
        #region ---Fields---
        List<Domino> dominoSet = new List<Domino>();
        #endregion

        #region ---Properties---
        /// <summary>
        /// DominosRemaining - How many dominos are left in the set that have not been drawn
        /// </summary>
        public int DominosRemaining
        {
            get
            {
                return dominoSet.Count;
            }
        }

        /// <summary>
        /// this[] - Access a Domino in the set by its List index
        /// </summary>
        /// <param name="index">Index of domino in the set</param>
        /// <returns>Domino at that index</returns>
        public Domino this[int index]
        {
            get
            {
                return dominoSet[index];
            }
        }
        #endregion

        #region ---Methods---
        /// <summary>
        /// BoneYard - Constructor that creates a set of dominos
        /// </summary>
        /// <param name="maxDots"></param>
        public BoneYard(int maxDots)
        {
            for(int s1 = 0; s1 <= maxDots; s1++)
            {
                for (int s2 = s1; s2 <= maxDots; s2++)
                {
                    dominoSet.Add(new Domino(s1, s2));
                }
            }
        }

        /// <summary>
        /// Draw - Removes a domino from the boneyard
        /// </summary>
        /// <returns>Domino object from index 0</returns>
        public Domino Draw()
        {
            // if the deck still has cards
            if (!IsEmpty())
            {
                // get a reference to the first card
                Domino d = dominoSet[0];
                // remove the card from the list
                // could have used cards.RemoveAt[0];
                dominoSet.Remove(d);
                // return the first card
                return d;
            }
            // when the deck is empty, return null or throw an exception
            return null;
        }

        /// <summary>
        /// IsEmpty - Are there any dominos left in the boneyard
        /// </summary>
        /// <returns>True if empty</returns>
        public bool IsEmpty()
        {
            return (dominoSet.Count == 0);
        }

        /// <summary>
        /// Shuffle - Randomize the order of the dominos in the set
        /// </summary>
        public void Shuffle()
        {
            Random gen = new Random();

            // go through all of the dominos in the set
            for (int i = 0; i < DominosRemaining; i++)
            {
                // generate a random index
                int rnd = gen.Next(0, DominosRemaining);
                // swap the card at the random index with the card at the current index
                Domino d = dominoSet[rnd];
                dominoSet[rnd] = dominoSet[i];
                dominoSet[i] = d;
            }
        }

        /// <summary>
        /// ToString - List of each domino in the set
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            // go through every domino in the set
            foreach (Domino d in dominoSet)
                // ask the domino to convert itself to a string
                output += (d.ToString() + "\n");
            return output;
        }
        #endregion
    }
}
