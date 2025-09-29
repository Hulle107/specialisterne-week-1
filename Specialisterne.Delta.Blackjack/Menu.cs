using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialisterne.Delta.Blackjack;

internal class Menu(int x, int y)
{
    public int X = x;
    public int Y = y;
    public List<string> MenuElements = [];
    public int CurrentIndex = 0;

    public void Draw()
    {
        if (MenuElements.Count == 0) return;
        List<string> list = [.. MenuElements];
        list.Sort((u1, u2) => u1.Length.CompareTo(u2.Length));
        int maxLength = list[list.Count - 1].Length;

        for (int index = 0; index < MenuElements.Count; index++)
        {
            char selected = CurrentIndex == index ? '►' : ' ';
            int offsetX = X;
            int offsetY = Y + (index * 3);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(offsetX, offsetY + 0);
            Console.WriteLine("┌".PadRight(5 + maxLength, '─') + "┐");
            Console.SetCursorPosition(offsetX, offsetY + 1);
            Console.WriteLine("│ " + selected + " " + MenuElements[index].PadRight(maxLength) + " │");
            Console.SetCursorPosition(offsetX, offsetY + 2);
            Console.WriteLine("└".PadRight(5 + maxLength, '─') + "┘");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void Up()
    {
        CurrentIndex--;
        if (CurrentIndex == 0) CurrentIndex = 0;
    }

    public void Down()
    {
        CurrentIndex++;
        if (CurrentIndex >= MenuElements.Count) CurrentIndex = MenuElements.Count - 1;
    }
}
