using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        #region ---Fields---
        protected List<Card> cards = new List<Card>();
        #endregion

        #region ---Properties---
        /// <summary>
        /// NumCards - Returns the number of cards in the player's hand
        /// </summary>
        public int NumCards
        {
            get
            {
                return cards.Count;
            }
        }
        #endregion

        #region ---Constructors---
        /// <summary>
        /// Hand - Default constructor
        /// </summary>
        public Hand() { }

        /// <summary>
        /// Hand - Constructor that adds Cards to the Hand from a Deck
        /// </summary>
        /// <param name="d">The Deck of Cards</param>
        /// <param name="numCards">The number of Cards to add to the Hand</param>
        public Hand(Deck d, int numCards)
        {
            for(int i = 0; i < numCards; i++)
            {
                cards.Add(d.Deal());
            }
        }
        #endregion

        #region ---Methods---
        /// <summary>
        /// AddCard - Add a Card to the Hand
        /// </summary>
        /// <param name="c">Card</param>
        public void AddCard(Card c)
        {
            cards.Add(c);
        }

        /// <summary>
        /// Discard - Remove a Card by index from the Hand
        /// </summary>
        /// <param name="i">Index of card</param>
        /// <returns>Card removed</returns>
        public Card Discard(int i)
        {
            Card discard = cards[i]; 
            cards.RemoveAt(i);
            return discard;
        }

        /// <summary>
        /// GetCard - Get a Card from the Hand by index
        /// </summary>
        /// <param name="i">Index of the Card in the Hand</param>
        /// <returns>Card</returns>
        public Card GetCard(int i)
        {
            return cards[i];
        }

        /// <summary>
        /// IndexOf - Determines the index of a Card in the Hand
        /// </summary>
        /// <param name="c">Card</param>
        /// <returns>Index or -1 if not found</returns>
        public int IndexOf(Card c)
        {
            // Must implement Equals and GetHashCode
            return cards.IndexOf(c);
        }

        /// <summary>
        /// IndexOf - Determines the index of a Card in the Hand
        /// </summary>
        /// <param name="val">Value of the Card</param>
        /// <returns>Index or -1 if not found</returns>
        public int IndexOf(int val)
        {
            int retVal = -1;

            for(int i = 0; i < cards.Count; i++)
            {
                if(cards[i].Value == val)
                {
                    retVal = i;
                }
            }

            return retVal;
        }

        /// <summary>
        /// IndexOf - Determines the index of a Card in the Hand
        /// </summary>
        /// <param name="suit">Suit of the Card</param>
        /// <param name="val">Value of the Card</param>
        /// <returns>Index or -1 if not found</returns>
        public int IndexOf(int suit, int val)
        {
            int retVal = -1;

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == val && cards[i].Suit == suit)
                {
                    retVal = i;
                }
            }

            return retVal;
        }

        /// <summary>
        /// HasCard - Determines if a Card is in the Hand
        /// </summary>
        /// <param name="c">Card</param>
        /// <returns>True if in Hand</returns>
        public bool HasCard(Card c)
        {
            return IndexOf(c) != -1;
        }

        /// <summary>
        /// HasCard - Determines if a Card is in the Hand
        /// </summary>
        /// <param name="val">Value of the Card</param>
        /// <returns>True if in Hand</returns>
        public bool HasCard(int val)
        {
            return IndexOf(val) != -1 ? true : false;
        }

        /// <summary>
        /// HasCard - Determines if a Card is in the Hand
        /// </summary>
        /// <param name="val">Value of the Card</param>
        /// <param name="suit">Suit of the Card</param>
        /// <returns>True if in Hand</returns>
        public bool HasCard(int suit, int val)
        {
            return IndexOf(suit, val) != -1 ? true : false;
        }
        #endregion

        #region ---Overs---
        public override string ToString()
        {
            string retVal = "This hand contains the following cards: \n";

            foreach(Card c in cards)
            {
                retVal += c.ToString() + "\n";
            }

            return retVal;
        }
        #endregion

    }
}
