using BlackjackGame.Models;
using System;

namespace BlackjackGame.Services
{
    public class BlackjackService
    {
        private Deck _deck;
        private Hand _playerHand;
        private Hand _dealerHand;
        private int _playerMoney = 1000; // Player starts with $1000
        private int _bet;

        public BlackjackService()
        {
            _deck = new Deck();
            _playerHand = new Hand();
            _dealerHand = new Hand();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Blackjack!");

            while (_playerMoney > 0)
            {
                PlaceBet();
                DealInitialCards();
                PlayPlayerTurn();
                PlayDealerTurn();
                DetermineWinner();
                ResetHands();
            }

            Console.WriteLine("You're out of money! Game over.");
        }

        private void PlaceBet()
        {
            Console.WriteLine($"\nYou have ${_playerMoney}.");
            Console.Write("Enter your bet: $");
            _bet = int.Parse(Console.ReadLine());

            if (_bet > _playerMoney)
            {
                Console.WriteLine("You don't have enough money for that bet. Try again.");
                PlaceBet();
            }
        }

        private void DealInitialCards()
        {
            _playerHand.AddCard(_deck.DrawCard());
            _playerHand.AddCard(_deck.DrawCard());

            _dealerHand.AddCard(_deck.DrawCard());
            _dealerHand.AddCard(_deck.DrawCard());

            Console.WriteLine($"\nYour hand: {_playerHand}");
            Console.WriteLine($"Dealer's hand: {_dealerHand.Cards[0]}, [Hidden]");
        }

        private void PlayPlayerTurn()
        {
            string action;

            while (_playerHand.TotalValue < 21)
            {
                ShowHint();

                Console.WriteLine($"\nYour total value: {_playerHand.TotalValue}");
                Console.Write("Do you want to (H)it or (S)tand? ");
                action = Console.ReadLine().ToUpper();

                if (action == "H")
                {
                    _playerHand.AddCard(_deck.DrawCard());
                    Console.WriteLine($"You drew: {_playerHand.Cards[^1]}");
                }
                else if (action == "S")
                {
                    break;
                }
            }

            if (_playerHand.TotalValue > 21)
            {
                Console.WriteLine("You busted!");
            }
        }

        private void PlayDealerTurn()
        {
            while (_dealerHand.TotalValue < 17)
            {
                _dealerHand.AddCard(_deck.DrawCard());
            }

            Console.WriteLine($"\nDealer's hand: {_dealerHand} (Total: {_dealerHand.TotalValue})");
        }

        private void DetermineWinner()
        {
            if (_playerHand.TotalValue > 21)
            {
                Console.WriteLine("Dealer wins.");
                _playerMoney -= _bet;
            }
            else if (_dealerHand.TotalValue > 21 || _playerHand.TotalValue > _dealerHand.TotalValue)
            {
                Console.WriteLine("You win!");
                _playerMoney += _bet;
            }
            else if (_playerHand.TotalValue == _dealerHand.TotalValue)
            {
                Console.WriteLine("It's a tie!");
            }
            else
            {
                Console.WriteLine("Dealer wins.");
                _playerMoney -= _bet;
            }

            Console.WriteLine($"You now have ${_playerMoney}.");
        }

        private void ResetHands()
        {
            _playerHand = new Hand();
            _dealerHand = new Hand();
            _deck.ShuffleDeck();
        }

        private void ShowHint()
        {
            // Basic card-counting hint system: If the remaining cards are mostly high, recommend to stand.
            int remainingCards = _deck.RemainingCards;
            int countOfHighCards = remainingCards / 4; // Estimate of high cards remaining

            if (countOfHighCards > remainingCards / 2)
            {
                Console.WriteLine("Hint: There are many high cards remaining. Consider standing.");
            }
            else
            {
                Console.WriteLine("Hint: Consider hitting.");
            }
        }
    }
}
