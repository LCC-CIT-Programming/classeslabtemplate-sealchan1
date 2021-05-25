using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class MexicanTrain : Train
    {
        #region ---Constructors---

        /// <summary>
        /// MexicanTrain - Default constructor
        /// </summary>
        public MexicanTrain() : base() { }

        /// <summary>
        /// MexicanTrain - Constructor
        /// </summary>
        /// <param name="engValue">Engine value</param>
        public MexicanTrain(int engValue) : base(engValue) { }

        #endregion

        #region ---Methods---

        /// <summary>
        /// IsPlayable - Determines if a domino can be played on this train
        /// </summary>
        /// <param name="h">Hand, ignored</param>
        /// <param name="d">Domino to check</param>
        /// <param name="mustFlip">True if domino must be flipped to be played</param>
        /// <returns>True if playable</returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            mustFlip = false;
            return IsPlayable(d, out mustFlip);
        }

        #endregion
    }
}
