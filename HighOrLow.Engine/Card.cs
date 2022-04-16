﻿using System;
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

        public bool IsHigher(Card otherCard)
        {
            if (this.Rank > otherCard.Rank)
            {
                return true;
            }
            else if(this.Rank == CardRank.Ace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLower(Card otherCard)
        {
            if (this.Rank < otherCard.Rank)
            {
                return true;
            }
            else if(this.Rank == CardRank.Ace)
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        public bool IsEqual(Card otherCard)
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

        public override string ToString()
        {
            char suitString = ' ';
            string valueString = " ";

            switch(this.Suit)
            {
                case CardSuit.Hearts:
                    suitString = '\u2661';
                    break;
                case CardSuit.Spades:
                    suitString = '\u2664';
                    break;
                case CardSuit.Diamonds:
                    suitString = '\u2662';
                    break;
                case CardSuit.Clubs:
                    suitString = '\u2667';
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

    }
}