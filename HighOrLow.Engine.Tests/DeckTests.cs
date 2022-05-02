using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HighOrLow.Engine.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void CanCreateDeck()
        {
            Deck deck = new Deck();
            Assert.IsNotNull(deck);
            Card card = deck.GetCard(0);
            Assert.AreEqual(new Card(CardRank.Ace, CardSuit.Clubs), card);
            Card card51 = deck.GetCard(51);
            Assert.AreEqual(new Card(CardRank.King, CardSuit.Spades), card51);
        }

        [TestMethod]
        public void CanShuffleDeckWithSeed()
        {
            Deck deck = new Deck();
            deck.Shuffle(3);
            Assert.AreEqual(new Card(CardRank.Ace, CardSuit.Diamonds), deck.GetCard(0));
            Assert.AreEqual(new Card(CardRank.Eight, CardSuit.Hearts), deck.GetCard(1));
        }

        [TestMethod]
        public void CanShuffleDeckWithoutSeed()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            
        }
        [TestMethod]
        public void CanPickCard()
        {
            Deck deck = new Deck();
            Card card = deck.GetTopCard();
            Card card2 = deck.GetTopCard();
            Assert.AreEqual(new Card(CardRank.Ace, CardSuit.Clubs), card);
            Assert.AreEqual(new Card(CardRank.Two, CardSuit.Clubs), card2);
        }

        [TestMethod]
        public void WhenPickingCardFromEmptyDeckReturnNull()
        {
            Deck deck = new Deck();
            for (int i = 0; i < 52; i++)
            {
                deck.GetTopCard();
            }
            Card card = deck.GetTopCard();
            Assert.IsNull(card);
        }
    }
}
