using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialisterne.Delta.Blackjack
{
    internal class Deck
    {
        /// <summary>
        /// List of cards in the deck
        /// </summary>
        private readonly List<Card> Cards;
        /// <summary>
        /// Current card to be pick
        /// </summary>
        private int CurrentIndex;

        /// <summary>
        /// Create a new deck
        /// </summary>
        /// <param name="shuffleCount">Amount of times to shuffle the deck</param>
        public Deck(int shuffleCount) {
            Cards = CreateDeck();
            CurrentIndex = Cards.Count - 1;
            for (int count = 0; count < shuffleCount; count++) Shuffle();
        }

        /// <summary>
        /// Create a new list of unshufflet cards
        /// </summary>
        /// <returns>new unshufflet list</returns>
        private static List<Card> CreateDeck()
        {
            return [
                new(0,0, CardType.Heart, 1),
                new(0,0, CardType.Spade, 1),
                new(0,0, CardType.Diamond, 1),
                new(0,0, CardType.Club, 1),
                new(0,0, CardType.Heart, 2),
                new(0,0, CardType.Spade, 2),
                new(0,0, CardType.Diamond, 2),
                new(0,0, CardType.Club, 2),
                new(0,0, CardType.Heart, 3),
                new(0,0, CardType.Spade, 3),
                new(0,0, CardType.Diamond, 3),
                new(0,0, CardType.Club, 3),
                new(0,0, CardType.Heart, 4),
                new(0,0, CardType.Spade, 4),
                new(0,0, CardType.Diamond, 4),
                new(0,0, CardType.Club, 4),
                new(0,0, CardType.Heart, 5),
                new(0,0, CardType.Spade, 5),
                new(0,0, CardType.Diamond, 5),
                new(0,0, CardType.Club, 5),
                new(0,0, CardType.Heart, 6),
                new(0,0, CardType.Spade, 6),
                new(0,0, CardType.Diamond, 6),
                new(0,0, CardType.Club, 6),
                new(0,0, CardType.Heart, 7),
                new(0,0, CardType.Spade, 7),
                new(0,0, CardType.Diamond, 7),
                new(0,0, CardType.Club, 7),
                new(0,0, CardType.Heart, 8),
                new(0,0, CardType.Spade, 8),
                new(0,0, CardType.Diamond, 8),
                new(0,0, CardType.Club, 8),
                new(0,0, CardType.Heart, 9),
                new(0,0, CardType.Spade, 9),
                new(0,0, CardType.Diamond, 9),
                new(0,0, CardType.Club, 9),
                new(0,0, CardType.Heart, 10),
                new(0,0, CardType.Spade, 10),
                new(0,0, CardType.Diamond, 10),
                new(0,0, CardType.Club, 10),
                new(0,0, CardType.Heart, 11),
                new(0,0, CardType.Spade, 11),
                new(0,0, CardType.Diamond, 11),
                new(0,0, CardType.Club, 11),
                new(0,0, CardType.Heart, 12),
                new(0,0, CardType.Spade, 12),
                new(0,0, CardType.Diamond, 12),
                new(0,0, CardType.Club, 12),
                new(0,0, CardType.Heart, 13),
                new(0,0, CardType.Spade, 13),
                new(0,0, CardType.Diamond, 13),
                new(0,0, CardType.Club, 13),
            ];
        }

        /// <summary>
        /// Perform a shuffle of the cards in the deck
        /// </summary>
        private void Shuffle()
        {
            Random random = new();
            for (int index = Cards.Count - 1; index > 0; index--)
            {
                int newIndex = random.Next(0, index + 1);
                (Cards[newIndex], Cards[index]) = (Cards[index], Cards[newIndex]);
            }
        }

        public Card Next()
        {
            int currentIndex = CurrentIndex;
            CurrentIndex--;
            return Cards[currentIndex];
        }
    }
}
