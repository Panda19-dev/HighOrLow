using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HighOrLow.Engine.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CanCreateInstanceOfCard()
        {
            Card threeOfClubs = new Card(CardRank.Three, CardSuit.Clubs);
            Card aceOfSpades = new Card(CardRank.Ace, CardSuit.Spades);
            Card queenOfDiamonds = new Card(CardRank.Queen, CardSuit.Diamonds);
        }

        [TestMethod]
        public void IsHigher()
        {
            Card twoOfClubs = new Card(CardRank.Two, CardSuit.Clubs);
            Card kingOfSpades = new Card(CardRank.King, CardSuit.Spades);
            bool result = kingOfSpades.IsHigher(twoOfClubs);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLower()
        {
            Card jackOfSpades = new Card(CardRank.Jack, CardSuit.Spades);
            Card threeOfHearts = new Card(CardRank.Three, CardSuit.Hearts);
            bool result = threeOfHearts.IsLower(jackOfSpades);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEqual()
        {
            Card kingOfHearts = new Card(CardRank.King, CardSuit.Hearts);
            Card kingOfSpades = new Card(CardRank.King, CardSuit.Spades);
            bool result = kingOfHearts.IsEqual(kingOfSpades);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsHigherLowerOrEqual()
        {
            Card queenOfDiamonds = new Card(CardRank.Queen, CardSuit.Diamonds);
            Card kingOfSpades = new Card(CardRank.King, CardSuit.Spades);
            CompareValues compare = queenOfDiamonds.IsHigherLowerOrEqualThan(kingOfSpades);
            Assert.AreEqual(CompareValues.Lower, compare);
        }

        [TestMethod]
        public void ShowRank()
        {
            Card sevenOfHearts = new Card(CardRank.Seven, CardSuit.Hearts);
            Assert.AreEqual(CardRank.Seven, sevenOfHearts.Rank);
        }

        [TestMethod]
        public void ShowSuit()
        {
            Card eightOfClubs = new Card(CardRank.Eight, CardSuit.Clubs);
            Assert.AreEqual(CardSuit.Clubs, eightOfClubs.Suit);
        }

        [TestMethod]
        public void AceHasAlwaysLowerAndHigherRankThan()
        {
            Card ace = new Card(CardRank.Ace, CardSuit.Diamonds);
            Card queen = new Card(CardRank.Queen, CardSuit.Diamonds);
            Card three = new Card(CardRank.Three, CardSuit.Diamonds);

            Assert.IsTrue(ace.IsHigher(queen));
            Assert.IsTrue(ace.IsHigher(three));
            Assert.IsTrue(ace.IsLower(queen));
            Assert.IsTrue(ace.IsLower(three));
        }

        [TestMethod]
        public void IsHigherLowerOrEqualAndWorksWithAce()
        {
            Card ace = new Card(CardRank.Ace, CardSuit.Clubs);
            Card ace2 = new Card(CardRank.Ace, CardSuit.Diamonds);
            Card king = new Card(CardRank.King, CardSuit.Hearts);
            Card four = new Card(CardRank.Four, CardSuit.Spades);

            CompareValues compare = ace.IsHigherLowerOrEqualThan(king);
            CompareValues compare2 = ace.IsHigherLowerOrEqualThan(four);
            CompareValues compare3 = ace.IsHigherLowerOrEqualThan(ace2);
            CompareValues compare4 = four.IsHigherLowerOrEqualThan(king);
            CompareValues compare5 = king.IsHigherLowerOrEqualThan(four);

            Assert.AreEqual(CompareValues.HigherAndLower, compare);
            Assert.AreEqual(CompareValues.HigherAndLower, compare2);
            Assert.AreEqual(CompareValues.Equal, compare3);
            Assert.AreEqual(CompareValues.Lower, compare4);
            Assert.AreEqual(CompareValues.Higher, compare5);
        }

        [TestMethod]
        public void CorrectToStringOverride()
        {
            Card aceOfClubs = new Card(CardRank.Ace, CardSuit.Clubs);
            Card queenOfHearts= new Card(CardRank.Queen, CardSuit.Hearts);
            Card sevenOfSpades = new Card(CardRank.Seven, CardSuit.Spades);
            Card fourOfDiamonds = new Card(CardRank.Four, CardSuit.Diamonds);

            Assert.AreEqual("Ace : ♧", aceOfClubs.ToString());
            Assert.AreEqual("Queen : ♡", queenOfHearts.ToString());
            Assert.AreEqual("7 : ♤", sevenOfSpades.ToString());
            Assert.AreEqual("4 : ♢", fourOfDiamonds.ToString());
        }

        [TestMethod]
        public void CanCreateInstanceOfDeck()
        {
            
        }
    }
}
