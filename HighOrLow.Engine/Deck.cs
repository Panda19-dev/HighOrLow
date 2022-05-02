using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow.Engine
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        public Deck()
        {
            foreach (string suit in Enum.GetNames(typeof(CardSuit)))
            {
                foreach (string rank in Enum.GetNames(typeof(CardRank)))
                {
                    Card card = new Card((CardRank)Enum.Parse(typeof(CardRank), rank), 
                        (CardSuit)Enum.Parse(typeof(CardSuit), suit));
                    cards.Add(card);
                }
            }
        }

        public void Shuffle(int seed)
        {
            var rnd = new Random(seed);
            Shuffle(rnd);
        }

        private void Shuffle(Random rnd)
        {
            var randomizedCards = cards.OrderBy(x => rnd.Next()).ToList();
            cards = randomizedCards;
        }

        public void Shuffle()
        {
            var rnd = new Random();
            Shuffle(rnd);
        }

        public Card GetCard(int index)
        {
            return cards[index];
        }

        public Card GetTopCard()
        {
            if (cards.Count == 0)
            {
                return null;
            }
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
