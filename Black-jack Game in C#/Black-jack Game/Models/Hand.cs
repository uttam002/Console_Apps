using System.Collections.Generic;

namespace BlackjackGame.Models
{
    public class Hand
    {
        public List<Card> Cards { get; private set; }
        public int TotalValue { get; private set; }
        public bool HasAce { get; private set; }

        public Hand()
        {
            Cards = new List<Card>();
            TotalValue = 0;
            HasAce = false;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
            TotalValue += card.Value;
            if (card.Rank == "A")
            {
                HasAce = true;
            }

            // Adjust for Aces if needed
            if (TotalValue > 21 && HasAce)
            {
                TotalValue -= 10;
                HasAce = false; // Use Ace as 1 instead of 11
            }
        }

        public override string ToString()
        {
            return string.Join(", ", Cards);
        }
    }
}
