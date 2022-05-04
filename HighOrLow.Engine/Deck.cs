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
            foreach (string suit in Enum.GetNames(typeof(CardSuit))) //Loop som går igenom alla delar i CardSuit enumen. 
            {
                foreach (string rank in Enum.GetNames(typeof(CardRank))) //Loop som går igenom alla delar i CardRank enumen så att alla kort skapas korrekt. 
                {
                    Card card = new Card((CardRank)Enum.Parse(typeof(CardRank), rank), 
                        (CardSuit)Enum.Parse(typeof(CardSuit), suit));
                    cards.Add(card);
                }
            }
        }

        public void Shuffle(int seed) //En metod som tar fram ett random värde utifårn en seed, alltså ett bestämt värde för att kunna testa så allt funkar.
        {
            var rnd = new Random(seed);
            Shuffle(rnd);
        }

        private void Shuffle(Random rnd) 
        {
            var randomizedCards = cards.OrderBy(x => rnd.Next()).ToList();
            cards = randomizedCards;
        }

        public void Shuffle() //Om man inte tar in ett värde i metoden så tar den ett "random" värde (utefter klockan eller tiden då).
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

        public void PrintDeck()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }
    }
}
