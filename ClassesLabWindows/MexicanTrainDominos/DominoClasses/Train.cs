using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public abstract class Train
    {
        #region ---Fields---
        
        List<Domino> dominos = new List<Domino>();
        int engineValue;

        #endregion

        #region ---Constructors---

        /// <summary>
        /// Train - Default constructor
        /// </summary>
        public Train() { }

        /// <summary>
        /// Train - Constructor
        /// </summary>
        /// <param name="engValue">Engine value for new train object</param>
        public Train(int engValue)
        {
            this.engineValue = engValue;
        }

        #endregion

        #region ---Properties---
        /// <summary>
        /// Count - The number of dominos in the train
        /// </summary>
        public int Count
        {
            get
            {
                return dominos.Count;
            }
        }

        /// <summary>
        /// EngineValue - The starting value for the train
        /// </summary>
        public int EngineValue
        {
            get
            {
                return engineValue;
            }
            set
            {
                this.engineValue = value;
            }
        }

        /// <summary>
        /// IsEmpty - True if there are no dominos in the train
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return dominos.Count == 0;
            }
        }

        /// <summary>
        /// LastDomino - Return the address for the last domino in the train
        /// </summary>
        public Domino LastDomino
        {
            get
            {
                return dominos[this.Count - 1];
            }
        }

        /// <summary>
        /// PlayableValue - The value that must be matched to play a domino at the end of the train
        /// </summary>
        public int PlayableValue
        {
            get
            {
                return LastDomino.Side2;
            }
        }

        /// <summary>
        /// this[] - Access the domino by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Domino this[int index]
        {
            get
            {
                return dominos[index];
            }
            
        }

        #endregion

        #region ---Methods---

        /// <summary>
        /// Add - Add a domino to the train
        /// </summary>
        /// <param name="d"></param>
        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        /// <summary>
        /// IsPlayable - True if the provided domino can be added to this train
        /// </summary>
        /// <param name="d">Domino</param>
        /// <param name="mustFlip">True if the domino must be flipped to be played</param>
        /// <returns></returns>
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            bool retVal = false;
            mustFlip = false;

            if(d.Side1 == this.PlayableValue)
            {
                retVal = true;
            }
            else if(d.Side2 == this.PlayableValue)
            {
                mustFlip = true;
                retVal = true;
            }
            // else retVal still = false

            return retVal;
        }

        /// <summary>
        /// IsPlayable - Abstract method which must be implemented to determine if a domino is playable in a hand
        /// </summary>
        /// <param name="h">Hand</param>
        /// <param name="d">Domino to play</param>
        /// <param name="mustFlip">True if domino must be flipped to be played</param>
        /// <returns></returns>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        /// <summary>
        /// Play - Add a valid domino in the proper orientation to the end of the train
        /// </summary>
        /// <param name="h"></param>
        /// <param name="d"></param>
        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if(IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip) d.Flip();
                Add(d);
            }
            else
            {
                throw new Exception("Domino" + d.ToString()
                    + "does not match last domino in the train and cannot be played.");
            }
        }

        /// <summary>
        /// ToString - Display the list of dominos in the train
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retVal = String.Empty;

            foreach (Domino d in dominos)
            {
                retVal += d.ToString() + '\n';
            }

            return retVal;
        }

        #endregion
    }
}
