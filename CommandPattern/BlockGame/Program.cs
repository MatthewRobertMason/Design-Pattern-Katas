using CommandPattern;
using BlockGame;

GameManager gameManager = new GameManager();

void DrawGameBoard()
{
    Console.Clear();
    Console.WriteLine("Current      | Goal");
    for (int y = 0; y < gameManager.NumberOfBlocks; y++)
    {
        string[,] state = gameManager.GetGameState();

        for (int x = 0; x < gameManager.NumberOfBlocks; x++)
        {
            if (string.IsNullOrWhiteSpace(state[x, y]))
            {
                Console.Write("  ");
            }
            else
            {
                Console.Write($"{state[x, y]} ");
            }
        }

        Console.Write(" | ");

        for (int x = 0; x < gameManager.NumberOfBlocks; x++)
        {
            if (string.IsNullOrWhiteSpace(gameManager.GoalState[x, y]))
            {
                Console.Write("  ");
            }
            else
            {
                Console.Write($"{gameManager.GoalState[x, y]} ");
            }
        }
        Console.WriteLine();
    }
}

string? command = "";
do
{
    while (!gameManager.TestWin() && command.Trim().ToLower() != "quit")
    {
        DrawGameBoard();

        Console.WriteLine();
        Console.WriteLine("Possible moves [stack <top> <bottom>, unstack <block>, undo <times>, undoall, quit]");
        Console.Write("Please enter your move: ");
        command = Console.ReadLine() ?? "";

        gameManager.PerformCommand(command);
    }

    DrawGameBoard();
    Console.WriteLine("You Win! Play again?");
    command = Console.ReadLine() ?? "";
    command = command.Trim().ToLower();
}
while (command == "yes" && command != "y" && command != "quit");