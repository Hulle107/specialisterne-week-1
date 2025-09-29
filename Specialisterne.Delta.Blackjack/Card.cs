using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialisterne.Delta.Blackjack;

public enum CardType
{
    Spade,
    Club,
    Heart,
    Diamond,
}

internal class Card(int x, int y, CardType type, int value)
{
    public static int Width = 7;
    public static int Height = 5;

    public int X = x;
    public int Y = y;
    public CardType Type = type;
    public int Value
    {
        get;
        set
        {
            field = value;
            if (value > 13) field = 13;
            if (value < 1) field = 1;
        }
    } = value;
    public bool Hidden = false;
    
    public char Symbol { 
        get {
            return Type switch
            {
                CardType.Spade => '\u2660',
                CardType.Club => '\u2663',
                CardType.Heart => '\u2665',
                CardType.Diamond => '\u2666',
                _ => '?',
            };
        } 
    }

    public ConsoleColor Color
    {
        get
        {
            return Type switch
            {
                CardType.Spade => ConsoleColor.Black,
                CardType.Club => ConsoleColor.Black,
                CardType.Heart => ConsoleColor.Red,
                CardType.Diamond => ConsoleColor.Red,
                _ => ConsoleColor.Green,
            };
        }
    }

    public ConsoleColor BackColor = ConsoleColor.DarkBlue;

    public void Draw()
    {
        if (Value == 1) DrawAce();
        if (Value == 2) DrawTwo();
        if (Value == 3) DrawThree();
        if (Value == 4) DrawFour();
        if (Value == 5) DrawFive();
        if (Value == 6) DrawSix();
        if (Value == 7) DrawSeven();
        if (Value == 8) DrawEight();
        if (Value == 9) DrawNine();
        if (Value == 10) DrawTen();
        if (Value == 11) DrawJack();
        if (Value == 12) DrawQueen();
        if (Value == 13) DrawKing();
        if (Hidden) DrawHidden();
    }

    private void DrawHidden()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = BackColor;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine(" ▄▄▄▄▄ ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" █▓▓▓█ ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine(" █▓▓▓█ ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" █▓▓▓█ ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine(" ▀▀▀▀▀ ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawAce()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("A      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine("       ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine("       ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("      A");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawTwo()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("2      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("       ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("      2");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawThree()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("3      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("      3");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawFour()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("4      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("       ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("      4");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawFive()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("5      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("      5");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawSix()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("6      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("      6");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawSeven()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("7  " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("   " + Symbol + "  7");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawEight()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("8  " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("   " + Symbol + "  8");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawNine()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("9  " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + " " + Symbol + " " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + " " + Symbol + " " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("   " + Symbol + "  9");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawTen()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("10 " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" " + Symbol + " " + Symbol + " " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine(" " + Symbol + "   " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" " + Symbol + " " + Symbol + " " + Symbol + " ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("   " + Symbol + " 10");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawJack()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("J      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine("   " + Symbol + "   ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine(" ⌠//// ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" {===} ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("       ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawQueen()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("Q      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(".._" + Symbol + "_..");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine(" \\\\|// ");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" {===} ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("       ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void DrawKing()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(X, Y + 0);
        Console.WriteLine("K      ");
        Console.SetCursorPosition(X, Y + 1);
        Console.WriteLine(" _.+._ ");
        Console.SetCursorPosition(X, Y + 2);
        Console.WriteLine("(" + Symbol + "*" + Symbol + "*" + Symbol + ")");
        Console.SetCursorPosition(X, Y + 3);
        Console.WriteLine(" {===} ");
        Console.SetCursorPosition(X, Y + 4);
        Console.WriteLine("       ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }
}
