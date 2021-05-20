using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        #region ---Constructors---
        /// <summary>
        /// BJHand - Default constructor
        /// </summary>
        public BJHand() : base() { }

        /// <summary>
        /// BJHand - Constructor which takes a Deck and the number of cards in the Hand
        /// </summary>
        /// <param name="d">Deck</param>
        /// <param name="num">Number of cards to draw for the hand</param>
        public BJHand(Deck d, int num) : base(d, num) { }
        #endregion

        #region ---Properties---
        /// <summary>
        /// HasAce - Does the Hand contain an ace?
        /// </summary>
        public bool HasAce
        {
            get
            {
                return HasCard(1);
            }
        }

        /// <summary>
        /// Score - Current score of the Hand
        /// </summary>
        public int Score
        {
            get
            {
                int score = 0;

                foreach (Card c in cards)
                {
                    if (c.IsFaceCard())
                    {
                        score += 10;
                    }
                    else
                    {
                        score += c.Value;
                    }
                }

                if (HasAce && score <= 11)
                {
                    score += 10;
                }

                return score;
            }
        }

        /// <summary>
        /// IsBusted - Does the Hand's score exceed 21 points?
        /// </summary>
        public bool IsBusted
        {
            get
            {
                return Score > 21;
            }
        }
        #endregion

        #region ---Methods---
        public void AddCard(int v)
        {
            cards.Add(new Card(v, new Random().Next(1, 5)));
        }
        #endregion
    }
}
