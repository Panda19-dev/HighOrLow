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
        public CardRank Rank { get; } //Gör det möjligt att hämta värdet(Rank) på ett kort ex. kort.Rank

        public CardSuit Suit { get; } //Gör det möjligt att hämta färgen(Suit) på ett kort ex. kort.Suit
        public Card(CardRank cardrank, CardSuit cardsuit)
        {
            this.Rank = cardrank;
            this.Suit = cardsuit;
        }

        public bool IsHigher(Card otherCard)  //Metod för att kolla om ett kort är högre än det kortet man jämför med.
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
        public bool IsLower(Card otherCard) //Metod för att kolla om ett kort är lägre än det kortet man jämför med.
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

        public bool IsEqual(Card otherCard) //Metod för att kolla om ett kort är lika med det kortet man jämför med.
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

        public CompareValues IsHigherLowerOrEqualThan(Card otherCard)
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

        public override string ToString() //Skriver över metoden .ToString så att den kan skriva ut ett kort eftersom att .ToString metoden anropas om man till exempel anänvder Console.ReadLine(card). så att den skriver ut som ex. Ace : ♧
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
                    valueString = ((int)Rank).ToString(); //Gör så att alla fall som inte nämns ovan så tar vi "ranken" från enumen och gör om den till en int och därefter använder metoden .ToString på hela.
                    break;
            }

            return $"{valueString} : {suitString}";
        }

        public override bool Equals(object obj) //Skrev över metoden då metoden används när vi kollar i ett test om kortleken är tom så ska den retunera null.
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