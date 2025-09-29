using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Specialisterne.Delta.Blackjack.Board;

namespace Specialisterne.Delta.Blackjack;

internal class Board
{
    public enum MenuType
    {
        PlayerAction,
        ResultAction,
    }
    public Deck Deck = new(7);
    public readonly List<Card> PlayerCards = [];
    public readonly List<Card> DealerCards = [];
    public bool ShowDealerCards = false;

    public int CurrentPlayerAction = 0;
    public int CurrentResultAction = 0;

    public void Draw()
    {
        Console.Clear();

        DrawBoard();
        DrawDealerCards();
        DrawDealerPoints();
        DrawPlayerCards();
        DrawPlayerPoints();
    }

    private void DrawBoard()
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒Dealer Points:  ▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒░░░░░░░▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒Player Points:  ▒▒");
        Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawPlayerCards()
    {
        if (PlayerCards.Count >= 1)
        {
            Card card = PlayerCards[0];
            card.X = 58;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 2)
        {
            Card card = PlayerCards[1];
            card.X = 50;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 3)
        {
            Card card = PlayerCards[2];
            card.X = 42;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 4)
        {
            Card card = PlayerCards[3];
            card.X = 34;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 5)
        {
            Card card = PlayerCards[4];
            card.X = 26;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 6)
        {
            Card card = PlayerCards[5];
            card.X = 18;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 7)
        {
            Card card = PlayerCards[6];
            card.X = 10;
            card.Y = 13;
            card.Draw();
        }

        if (PlayerCards.Count >= 8)
        {
            Card card = PlayerCards[7];
            card.X = 2;
            card.Y = 13;
            card.Draw();
        }
    }

    private void DrawPlayerPoints()
    {
        int points = Logic.CountPoints(PlayerCards);
        string playerPoints = points.ToString().PadLeft(2);
        Console.SetCursorPosition(63, 19);

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        if (Logic.Bad(points)) Console.ForegroundColor = ConsoleColor.Red;
        if (Logic.Perfect(points))Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(playerPoints);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawDealerCards()
    {
        if (DealerCards.Count >= 1)
        {
            Card card = DealerCards[0];
            card.X = 58;
            card.Y = 3;
            if (!ShowDealerCards) card.Hidden = true;
            else card.Hidden = false;
            card.Draw();
        }

        if (DealerCards.Count >= 2)
        {
            Card card = DealerCards[1];
            card.X = 50;
            card.Y = 3;
            card.Draw();
        }

        if (DealerCards.Count >= 3)
        {
            Card card = DealerCards[2];
            card.X = 42;
            card.Y = 3;
            card.Draw();
        }

        if (DealerCards.Count >= 4)
        {
            Card card = DealerCards[3];
            card.X = 34;
            card.Y = 3;
            card.Draw();
        }

        if (DealerCards.Count >= 5)
        {
            Card card = DealerCards[4];
            card.X = 26;
            card.Y = 3;
            card.Draw();
        }

        if (DealerCards.Count >= 6)
        {
            Card card = DealerCards[5];
            card.X = 18;
            card.Y = 3;
            card.Draw();
        }

        if (DealerCards.Count >= 7)
        {
            Card card = DealerCards[6];
            card.X = 10;
            card.Y = 3;
            card.Draw();
        }

        if (DealerCards.Count >= 8)
        {
            Card card = DealerCards[7];
            card.X = 2;
            card.Y = 3;
            card.Draw();
        }
    }

    private void DrawDealerPoints()
    {
        int points = Logic.CountPoints(DealerCards);
        string dealerPoints = points.ToString().PadLeft(2);
        Console.SetCursorPosition(63, 1);

        if (!ShowDealerCards)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Logic.Bad(points)) Console.ForegroundColor = ConsoleColor.Red;
            if (Logic.Perfect(points)) Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(dealerPoints);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void DrawPlayerActionMenu()
    {
        string hitDisplay = CurrentPlayerAction == 0 ? " ► HIT ◄ " : "   HIT   ";
        string standDisplay = CurrentPlayerAction == 1 ? "► STAND ◄" : "  STAND  ";

        Console.SetCursorPosition(12, 9);
        Console.WriteLine("┌───────────────────┐");
        Console.SetCursorPosition(12, 10);
        Console.WriteLine("│     " + hitDisplay + "     │");
        Console.SetCursorPosition(12, 11);
        Console.WriteLine("└───────────────────┘");

        Console.SetCursorPosition(34, 9);
        Console.WriteLine("┌───────────────────┐");
        Console.SetCursorPosition(34, 10);
        Console.WriteLine("│     " + standDisplay + "     │");
        Console.SetCursorPosition(34, 11);
        Console.WriteLine("└───────────────────┘");
    }

    public void DrawResult()
    {
        Console.SetCursorPosition(0, 14);
        int playerPoints = Logic.CountPoints(PlayerCards);
        int dealerPoints = Logic.CountPoints(DealerCards);

        bool winner = false;
        bool loser = false;
        bool draw = false;

        if (!Logic.Bad(playerPoints) && playerPoints > dealerPoints) winner = true;
        if (Logic.Bad(dealerPoints)) winner = true;

        if (!Logic.Bad(dealerPoints) && dealerPoints > playerPoints) loser = true;
        if (Logic.Bad(playerPoints)) loser = true;

        if (!winner && !loser) draw = true;
        if (winner && loser) draw = true;

        if (winner)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(16, 7);
            Console.WriteLine("    _ _ _ _ _  _ _  _ ____ ____    ");
            Console.SetCursorPosition(16, 8);
            Console.WriteLine("    | | | | |\\ | |\\ | |___ |__/    ");
            Console.SetCursorPosition(16, 9);
            Console.WriteLine("    |_|_| | | \\| | \\| |___ |  \\    ");
            Console.SetCursorPosition(16, 10);
            Console.WriteLine("                                   ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (loser)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(16, 7);
            Console.WriteLine("     _    ____ ____ ____ ____      ");
            Console.SetCursorPosition(16, 8);
            Console.WriteLine("     |    |  | [__  |___ |__/      ");
            Console.SetCursorPosition(16, 9);
            Console.WriteLine("     |___ |__| ___] |___ |  \\      ");
            Console.SetCursorPosition(16, 10);
            Console.WriteLine("                                   ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (draw)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(16, 7);
            Console.WriteLine("       ___  ____ ____ _ _ _        ");
            Console.SetCursorPosition(16, 8);
            Console.WriteLine("       |  \\ |__/ |__| | | |        ");
            Console.SetCursorPosition(16, 9);
            Console.WriteLine("       |__/ |  \\ |  | |_|_|        ");
            Console.SetCursorPosition(16, 10);
            Console.WriteLine("                                   ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        string newDisplay = CurrentResultAction == 0 ? " │ ► New Round ◄ │" : " │   New Round   │";
        string menuDisplay = CurrentResultAction == 1 ? " ► Main Menu ◄ │ " : "   Main Menu   │ ";

        Console.SetCursorPosition(16, 11);
        Console.WriteLine(" ┌───────────────┬───────────────┐ ");
        Console.SetCursorPosition(16, 12);
        Console.WriteLine(newDisplay);
        Console.SetCursorPosition(34, 12);
        Console.WriteLine(menuDisplay);
        Console.SetCursorPosition(16, 13);
        Console.WriteLine(" └───────────────┴───────────────┘ ");
    }

    public void LeftArrow(MenuType menuType)
    {
        if (menuType == MenuType.PlayerAction)
        {
            CurrentPlayerAction--;
            if (CurrentPlayerAction < 0) CurrentPlayerAction = 0;
        }

        if (menuType == MenuType.ResultAction)
        {
            CurrentResultAction--;
            if (CurrentResultAction < 0) CurrentResultAction = 0;
        }
    }

    public void RightArrow(MenuType menuType)
    {
        if (menuType == MenuType.PlayerAction)
        {
            CurrentPlayerAction++;
            if (CurrentPlayerAction > 1) CurrentPlayerAction = 1;
        }

        if (menuType == MenuType.ResultAction)
        {
            CurrentResultAction++;
            if (CurrentResultAction > 1) CurrentResultAction = 1;
        }
    }

    public void AddPlayerCard()
    {
        Card card = Deck.Next();
        PlayerCards.Add(card);
    }

    public void AddDealerCard()
    {
        Card card = Deck.Next();
        DealerCards.Add(card);
    }
}
