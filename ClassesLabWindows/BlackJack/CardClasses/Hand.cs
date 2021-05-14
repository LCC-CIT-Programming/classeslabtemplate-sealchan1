using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards;

        public int IndexOf(Card c)
        {
            // Must implement Equals and GetHashCode
            return cards.IndexOf(c);
        }

        public bool HasCard(Card c)
        {
            return IndexOf(c) != -1;
        }
    }
}
