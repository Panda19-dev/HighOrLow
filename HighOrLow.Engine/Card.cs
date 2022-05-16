using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow.Engine
{
    public class Card
    {
        //Auto Property
        public CardRank Rank { get; } //Makes it possible to retrieve the value (Rank) on a card. card.Rank

        public CardSuit Suit { get; } //Makes it possible to retrieve the color (Suit) on a card. card.Suit
        public Card(CardRank cardrank, CardSuit cardsuit) //Constructor
        {
            this.Rank = cardrank;
            this.Suit = cardsuit;
        }

        public bool IsHigher(Card otherCard)  //Method for checking if a card is higher than the card you are comparing with.
        {
            if (this.Rank == CardRank.Ace && otherCard.Rank != CardRank.Ace)
            {
                return true;
            }
            else if (this.Rank > otherCard.Rank)
            {
                return true;
            }
            else if (otherCard.Rank == CardRank.Ace && this.Rank != CardRank.Ace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsLower(Card otherCard) //Method for checking if a card is lower than the card you are comparing with.
        {
            if (this.Rank == CardRank.Ace && otherCard.Rank != CardRank.Ace)
            {
                return true;
            }
            else if (otherCard.Rank == CardRank.Ace && this.Rank != CardRank.Ace)
            {
                return true;
            }
            else if(this.Rank < otherCard.Rank)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEqual(Card otherCard) //Method for checking if a card is equal to the card you are comparing with.
        {
            if (this.Rank == otherCard.Rank)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CompareValues IsHigherLowerOrEqualThan(Card otherCard) //Method that checks if a card is larger, smaller or equal to another card. (Not used in the game but still created for future projects.)
        {
            if(this.Rank == CardRank.Ace && otherCard.Rank != CardRank.Ace)
            {
                return CompareValues.HigherAndLower;
            }
            if(this.Rank == otherCard.Rank && otherCard.Rank == CardRank.Ace)
            {
                return CompareValues.Equal;
            }
            if (this.Rank > otherCard.Rank)
            {
                return CompareValues.Higher;
            }
            if (this.Rank < otherCard.Rank)
            {
                return CompareValues.Lower;
            }
            else
            {
                return CompareValues.Equal;
            }
        }

        public override string ToString() //Overwrites the .ToString method so that it can print a card because the .ToString method is called if, for example, you use Console.WriteLine(card). so that it prints as ex. Ace : ♧ instead of Ace : Clubs
        {
            char suitString = ' ';
            string valueString = " ";

            switch(this.Suit)
            {
                case CardSuit.Hearts:
                    suitString = '\u2665';
                    break;
                case CardSuit.Spades:
                    suitString = '\u2660';
                    break;
                case CardSuit.Diamonds:
                    suitString = '\u2666';
                    break;
                case CardSuit.Clubs:
                    suitString = '\u2663';
                    break;
            }

            switch (this.Rank)
            {
                case CardRank.Ace:
                    valueString = "Ace";
                    break;
                //case CardRank.Two:
                //    valueString = "2";
                //    break;
                //case CardRank.Three:
                //    valueString = "3";
                //    break;
                //case CardRank.Four:
                //    valueString = "4";
                //    break;
                //case CardRank.Five:
                //    valueString = "5";
                //    break;
                //case CardRank.Six:
                //    valueString = "6";
                //    break;
                //case CardRank.Seven:
                //    valueString = "7";
                //    break;
                //case CardRank.Eight:
                //    valueString = "8";
                //    break;
                //case CardRank.Nine:
                //    valueString = "9";
                //    break;
                //case CardRank.Ten:
                //    valueString = "10";
                //    break;
                case CardRank.Jack:
                    valueString = "Jack";
                    break;
                case CardRank.Queen:
                    valueString = "Queen";
                    break;
                case CardRank.King:
                    valueString = "King";
                    break;
                default:
                    valueString = ((int)Rank).ToString(); //Make sure that all cases not mentioned above we take the "rank" from the enumen and turn it into an int and then use the method .ToString on the whole.
                    break;
            }

            return $"{valueString} : {suitString}";
        }

        public override bool Equals(object obj) //the method is used when we check in a test if the card deck is empty, it should return zero and not null.
        {
            var other = obj as Card;
            if(other == null)
            {
                return false;
            }
            return this.Rank == other.Rank && this.Suit == other.Suit;
        }

    }
}