// See https://aka.ms/new-console-template for more information
using Specialisterne.Delta.Blackjack;
using System.Text;

namespace Specialisterne.Delta.Blackjack;

public class Program
{

    public enum State
    {
        MainMenu,
        Playing,
        Closing,
    }

    private static State CurrentState = State.MainMenu;
    private static int CurrentMainMenuAction = 0;
    private static readonly Encoding Encoding = Console.OutputEncoding;

    public static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.CursorVisible = false;
        bool closing = false;

        while(!closing)
        {
            if (CurrentState == State.MainMenu) MainMenu();
            if (CurrentState == State.Playing) Playing();
            if (CurrentState == State.Closing) closing = true;
        }

        Console.ResetColor();
        Console.CursorVisible = true;
        Console.OutputEncoding = Encoding;
        Console.SetCursorPosition(0, 0);
    }

    private static void Playing()
    {
        bool playing = true;

        while (playing)
        {
            Board board = new();

            Logic.Setup(board);
            Logic.PlayerTurn(board);
            Logic.DealerTurn(board);
            Logic.Result(board);

            if (board.CurrentResultAction == 1) playing = false;
        }

        CurrentState = State.MainMenu;
        Console.Clear();
    }

    private static void MainMenu()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(",-----.  ,--.              ,--.      ,--.              ,--.     ");
        Console.WriteLine("|  |) /_ |  | ,--,--. ,---.|  |,-.   `--' ,--,--. ,---.|  |,-.  ");
        Console.WriteLine("|  .-.  \\|  |' ,-.  || .--'|     /   ,--.' ,-.  || .--'|     /  ");
        Console.WriteLine("|  '--' /|  |\\ '-'  |\\ `--.|  \\  \\   |  |\\ '-'  |\\ `--.|  \\  \\  ");
        Console.WriteLine("`------' `--' `--`--' `---'`--'`--'.-'  / `--`--' `---'`--'`--' ");
        Console.WriteLine("                                   '---'");

        bool mainMenu = true;

        while (mainMenu)
        {
            string play = CurrentMainMenuAction == 0 ? "► Play" : "  Play";
            string close = CurrentMainMenuAction == 1 ? "► Close" : "  Close";

            Console.SetCursorPosition(1, 7);
            Console.WriteLine(play);
            Console.SetCursorPosition(1, 8);
            Console.WriteLine(close);

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow) CurrentMainMenuAction--;
            if (key.Key == ConsoleKey.DownArrow) CurrentMainMenuAction++;

            if (CurrentMainMenuAction < 0) CurrentMainMenuAction = 0;
            if (CurrentMainMenuAction > 1) CurrentMainMenuAction = 1;

            if (key.Key == ConsoleKey.Enter)
            {
                if (CurrentMainMenuAction == 0) CurrentState = State.Playing;
                if (CurrentMainMenuAction == 1) CurrentState = State.Closing;

                mainMenu = false;
            }
        }

        Console.Clear();
    }
}
