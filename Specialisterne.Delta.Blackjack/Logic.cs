using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialisterne.Delta.Blackjack
{
    internal class Logic
    {
        public static int CountPoints(List<Card> cards)
        {
            int points = 0;
            List<Card> sortedCards = [.. cards];

            sortedCards.Sort((u1, u2) => u1.Value.CompareTo(u2.Value));

            for (int index = cards.Count - 1; index >= 0; index--)
                points += GetCardValue(cards[index], points);

            return points;
        }

        public static bool Perfect(int points) { return points == 21; }
        public static bool Bad(int points) { return points > 21; }

        public static void Setup(Board board)
        {
            board.Draw();
            Thread.Sleep(500);
            board.AddPlayerCard();
            board.Draw();
            Thread.Sleep(500);
            board.AddDealerCard();
            board.Draw();
            Thread.Sleep(500);
            board.AddPlayerCard();
            board.Draw();
            Thread.Sleep(500);
            board.AddDealerCard();
            board.Draw();
        }

        public static void PlayerTurn(Board board)
        {
            bool playerTurn = true;

            while (playerTurn)
            {
                board.DrawPlayerActionMenu();

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) board.LeftArrow(Board.MenuType.PlayerAction);
                if (key.Key == ConsoleKey.RightArrow) board.RightArrow(Board.MenuType.PlayerAction);
                if (key.Key == ConsoleKey.Enter)
                {
                    if (board.CurrentPlayerAction == 0) PlayerHit(board);
                    if (board.CurrentPlayerAction == 1) playerTurn = false;
                }

                int points = CountPoints(board.PlayerCards);
                if (Bad(points)) playerTurn = false;
            }
        }

        private static void PlayerHit(Board board)
        {
            Thread.Sleep(500);
            board.AddPlayerCard();
            board.Draw();
        }

        public static void DealerTurn(Board board)
        {
            bool dealerTurn = true;

            while (dealerTurn)
            {
                int dealerPoints = CountPoints(board.DealerCards);
                int playerPoints = CountPoints(board.PlayerCards);
                bool done = false;

                if (Bad(playerPoints)) done = true;
                if (dealerPoints >= playerPoints) done = true;
                if (Perfect(dealerPoints)) done = true;

                if (!done) DealerHit(board);

                if (done) dealerTurn = false;
                if (Bad(dealerPoints)) dealerTurn = false;
            }

            Thread.Sleep(500);
        }

        private static void DealerHit(Board board)
        {
            Thread.Sleep(500);
            board.AddDealerCard();
            board.Draw();
        }

        public static void Result(Board board)
        {
            board.ShowDealerCards = true;
            board.Draw();

            bool resultMenu = true;

            while (resultMenu)
            {
                board.DrawResult();

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) board.LeftArrow(Board.MenuType.ResultAction);
                if (key.Key == ConsoleKey.RightArrow) board.RightArrow(Board.MenuType.ResultAction);
                if (key.Key == ConsoleKey.Enter) resultMenu = false;
            }
        }

        private static int GetCardValue(Card card, int currentPoints)
        {
            int points = card.Value;
            if (points == 11 || points == 12 || points == 13) return 10;
            if (points == 1 && currentPoints <= 10) return 11;
            if (points == 1 && currentPoints > 10) return 1;
            return points;
        }
    }
}
