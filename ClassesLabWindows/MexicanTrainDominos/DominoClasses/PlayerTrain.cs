using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class PlayerTrain : Train
    {
        #region ---Fields---
        
        private Hand hand;
        private bool isOpen;

        #endregion

        #region ---Properties---
        /// <summary>
        /// IsOpen - Is the player train open to be played on
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        #endregion

        #region ---Constructors---

        /// <summary>
        /// PlayerTrain - Default constructor
        /// </summary>
        public PlayerTrain() : base() 
        { 
        }

        /// <summary>
        /// PlayerTrain - Constructor
        /// </summary>
        /// <param name="engValue">Engine value</param>
        public PlayerTrain(Hand h, int engValue) : base(engValue)
        {
            this.hand = h;
        }

        #endregion

        #region ---Methods---

        /// <summary>
        /// Close - The train cannot be played on
        /// </summary>
        public void Close()
        {
            this.isOpen = false;
        }

        /// <summary>
        /// IsPlayable - Determines if a domino is playable including if the train is open
        /// </summary>
        /// <param name="h">Hand</param>
        /// <param name="d">Domino</param>
        /// <param name="mustFlip">True if domino must be flipped to be played</param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            bool retVal = false;
            mustFlip = false;

            if(h.Equals(this.hand) || this.isOpen)
            {
                
                retVal = IsPlayable(d, out mustFlip);
            }

            return retVal;
        }

        /// <summary>
        /// Open - Opens the train to be played on
        /// </summary>
        public void Open()
        {
            this.isOpen = true;
        }

        #endregion
    }
}
