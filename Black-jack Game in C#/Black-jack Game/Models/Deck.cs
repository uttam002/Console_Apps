using System;
using System.Collections.Generic;

namespace BlackjackGame.Models
{
    public class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            foreach (var suit in suits)
            {
                for (int i = 0; i < ranks.Length; i++)
                {
                    _cards.Add(new Card(ranks[i], suit, values[i]));
                }
            }

            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            var random = new Random();
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                var temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }

        public Card DrawCard()
        {
            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }

        public int RemainingCards => _cards.Count;
    }
}
