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
            foreach (string suit in Enum.GetNames(typeof(CardSuit))) // Loop that goes through all parts of the CardSuit enumen.
            {
                foreach (string rank in Enum.GetNames(typeof(CardRank))) // Loop that goes through all parts of the CardRank enumen so that all cards are created correctly.
                {
                    Card card = new Card((CardRank)Enum.Parse(typeof(CardRank), rank), 
                        (CardSuit)Enum.Parse(typeof(CardSuit), suit)); //Creates a new temporary card with the specific CardSuit and CardRank.
                    cards.Add(card);
                }
            }
        }

        public void Shuffle(int seed) // A method that produces a random value based on a seed, ie a specific value to be able to test so everything works.
        {
            var rnd = new Random(seed);
            Shuffle(rnd);
        }

        private void Shuffle(Random rnd) //Private method so that I could 
        {
            var randomizedCards = cards.OrderBy(x => rnd.Next()).ToList();
            cards = randomizedCards;
        }

        public void Shuffle() // If you do not include a value in the methods input-parameters, it takes a "random" value (according to the time etc.).
        {
            var rnd = new Random();
            Shuffle(rnd);
        }

        public Card GetCard(int index) //Method that return a card defined by the index.
        {
            return cards[index];
        }

        public Card GetTopCard() //Method that checks if the deck is empty and then finds the top card, saves it in a variable and later remove it.
        {
            if (cards.Count == 0)
            {
                return null;
            }
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        public void PrintDeck() //Method that is not used in the game however it was used to test that each and every card exsisted.
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
            Console.ReadLine();
        }
    }
}
