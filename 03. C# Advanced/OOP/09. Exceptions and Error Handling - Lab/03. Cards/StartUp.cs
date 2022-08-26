using System;
using System.Collections.Generic;

namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> deckOfCards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ");
            foreach (var item in input)
            {
                string[] faceAndSuit = item.Split();
                try
                {
                    deckOfCards.Add(new Card(faceAndSuit[0], faceAndSuit[1]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(' ', deckOfCards));
        }
    }
    class Card
    {
        private string face;
        private string suit;
        public string Face
        {
            get { return face; }
            private set
            {
                switch (value)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                    case "A":
                        face = value;
                        break;
                    default:
                        throw new Exception("Invalid card!");
                }
            }
        }
        public string Suit
        {
            get { return suit; }
            private set 
            {
                switch (value)
                {
                    case "S":
                        suit = "\u2660";
                        break;
                    case "H":
                        suit = "\u2665";
                        break;
                    case "D":
                        suit = "\u2666";
                        break;
                    case "C":
                        suit = "\u2663";
                        break;
                    default:
                        throw new Exception("Invalid card!");
                }
            }
        }
        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }
        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
