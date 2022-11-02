//using System.ComponentModel;
//using System.Runtime.Intrinsics.X86;
//using System;

//Create a class Card to hold a card’s face and suit.
//•	Valid card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
//•	Valid card suits are: S(♠), H(♥), D(♦), C(♣)
//Both face and suit are expected as an uppercase string.
//The class also needs to have a toString() method
//that prints the card’s face and suit as a string in the following format:
//	"[{face}{suit}]" – example: [A♠][5♣] [10♦]
//Use the following UTF code literals to represent the suits:
//•	\u2660 – Spades(♠)
//•	\u2665 – Hearts(♥)
//•	\u2666 – Diamonds(♦)
//•	\u2663 – Clubs(♣)
//Write a program that takes a deck of cards as a string array
//and prints them as a sequence of cards (space separated).
//Print an exception message "Invalid card!" when an invalid card definition is passed as input.
//Input
//•	A single line with the faces and suits of the cards in the format:
//"{face} {suit}, {face} {suit}, …"
//Output
//•	As output, print on the console the list of cards as strings, separated by space.


using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cards
{
    public class Card
    {
        public string Face { get; set; }
        public string Suit { get; set; }

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        => $"[{this.Face}{this.Suit}]";
    }

    internal class Program
    {
        static void Main()
        {
            List<Card> cardDeck = new List<Card>();
            string[] drawnCards = Console.ReadLine().Split(", ");
            for (int i = 0; i < drawnCards.Length; i++)
            {
                string face = drawnCards[i].Split().First();
                string suit = drawnCards[i].Split().Last();
                try
                { cardDeck.Add(CreateCard(face, suit)); }
                catch (ArgumentException ex)
                { Console.WriteLine(ex.Message); }
            }
            Console.WriteLine(string.Join(" ", cardDeck));
        }

        static Card CreateCard(string face, string suit)
        {
            string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = new string[] { "S", "H", "D", "C" };
            if (!validFaces.Contains(face) || !validSuits.Contains(suit))
                throw new ArgumentException("Invalid card!");

            string utfSuit = string.Empty;
            switch (suit)
            {
                case "S": utfSuit = "\u2660"; break;
                case "H": utfSuit = "\u2665"; break;
                case "D": utfSuit = "\u2666"; break;
                case "C": utfSuit = "\u2663"; break;
            }

            return new Card(face, utfSuit);
        }
    }
}
