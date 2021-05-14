using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Card
    {
        
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        #region ---Fields---
        private int value;
        private int suit;
        #endregion

        #region ---Properties---
        /// <summary>
        /// Suit - Integer representing the suit of the card
        /// (see static string array suits[])
        /// </summary>
        public int Suit
        {
            get { return suit; }
            set 
            { 
                if(value >= 1 && value <= 4)
                {
                    suit = value;
                }
                else
                {
                    throw new ArgumentException("Unable to set suit: initializing value must be in the range of 1 to 4");
                }
            }
        }

        /// <summary>
        /// Value - Integer representing the value of the card
        /// (see static string array values[]
        /// </summary>
        public int Value
        {
            get { return value; }
            set 
            { 
                if(value >= 1 && value <= 13)
                {
                    this.value = value;
                }
                else
                {
                    throw new ArgumentException("Unable to set value: initializing value must be in the range of 1 to 13");
                }
            }
        }
        #endregion

        #region ---Constructors---
        /// <summary>
        /// Default constructor - Creates valid random card
        /// </summary>
        public Card() : this (generator.Next(1, 14), generator.Next(1, 5)) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="val">Integer value of the card</param>
        /// <param name="suit">Integer value for the suit of the card</param>
        public Card(int val, int suit)
        {
            try
            {
                this.Value = val;
                this.Suit = suit;
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException("Unable to create Card: " + ex.Message);
            }
        }
        #endregion

        #region ---Methods---
        /// <summary>
        /// hasMatchingSuit()
        /// </summary>
        /// <param name="other">Card to compare to</param>
        /// <returns>True if same suit</returns>
        public bool HasMatchingSuit(Card other)
        {
            return this.suit == other.suit;
        }

        /// <summary>
        /// HasMatchingValue
        /// </summary>
        /// <param name="other">Card to compare to</param>
        /// <returns>True if same value</returns>
        public bool HasMatchingValue(Card other)
        {
            return this.value == other.value;
        }

        /// <summary>
        /// IsAce()
        /// </summary>
        /// <returns>True if value is 1</returns>
        public bool IsAce()
        {
            return value == 1;
        }

        /// <summary>
        /// IsBlack()
        /// </summary>
        /// <returns>True if clubs (1) or spades (4)</returns>
        public bool IsBlack()
        {
            return suit == 1 || suit == 4;
        }

        /// <summary>
        /// IsClub()
        /// </summary>
        /// <returns>True if suit is 1</returns>
        public bool IsClub()
        {
            return suit == 1;
        }

        /// <summary>
        /// IsDiamond()
        /// </summary>
        /// <returns>True if suit is 2</returns>
        public bool IsDiamond()
        {
            return suit == 2;
        }

        /// <summary>
        /// IsFaceCard()
        /// </summary>
        /// <returns>True if value < 10</returns>
        public bool IsFaceCard()
        {
            return value > 10;
        }

        /// <summary>
        /// IsHeart()
        /// </summary>
        /// <returns>True if suit is 3</returns>
        public bool IsHeart()
        {
            return suit == 3;
        }

        /// <summary>
        /// IsRed()
        /// </summary>
        /// <returns>True if suit is 2 or 3</returns>
        public bool IsRed()
        {
            return suit == 2 || suit == 3;
        }

        /// <summary>
        /// IsSpade()
        /// </summary>
        /// <returns>True if suit is 4</returns>
        public bool IsSpade()
        {
            return suit == 4;
        }
        #endregion

        #region ---Overs---
        public override string ToString()
        {
            return (values[value] + " of " + suits[suit]);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Card other = (Card)obj;
                return 
                    other.Suit == Suit 
                    &&
                    other.Value == Value;
            }
        }

        public override int GetHashCode()
        {
            return 13 + 7 * suit.GetHashCode() +
                7 * value.GetHashCode();
        }
        #endregion

    }
}
