/**************************************************************************************************************************************************************************************
new Game().Play();
new Game().Replay();

class Game()
{
    public void Play()
    {
        Board board = new Board();
        Player firstPlayer = new Player(Cell.X);
        Player secondPlayer = new Player(Cell.O);

        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Continue();

        Console.WriteLine("First player, please enter your name: ");
        firstPlayer.Name = Console.ReadLine();
        Console.WriteLine($"Welcome {firstPlayer.Name}. Your symbol is {firstPlayer.Symbol}.");
        Continue();

        Console.WriteLine("Second player, please enter your name: ");
        secondPlayer.Name = Console.ReadLine();
        Console.WriteLine($"Welcome {secondPlayer.Name}. Your symbol is {secondPlayer.Symbol}.");
        Continue();

        Player currentPlayer = firstPlayer;

        while (!board.IsBoardFull())
        {
            board.Draw();
            currentPlayer.MakeMove(board);
            Console.Clear();

            if (HasWon(board, currentPlayer.Symbol))
            {
                Console.WriteLine($"{currentPlayer.Name} has won the game!");
                return;
            }

            currentPlayer = currentPlayer == firstPlayer ? secondPlayer : firstPlayer;
        }

        Console.WriteLine("It's a draw!");
    }

    public void Replay()
    {
        Console.WriteLine("Play again? (Y or N)");
        string? restartGame = Console.ReadLine();

        if (restartGame == "Y" || restartGame == "y")
        {
            Play();
        }
        else if (restartGame == "N" || restartGame == "n")
        {
            Console.WriteLine("Goodbye!");
        }
        else
        {
            Console.WriteLine("Invalid input.");
            Replay();
        }
    }

    private static bool HasWon(Board board, Cell cell)
    {
        // Check rows.
        if (board.GetCellContent(1, 1) == cell && board.GetCellContent(1, 2) == cell && board.GetCellContent(1, 3) == cell) return true;
        if (board.GetCellContent(2, 1) == cell && board.GetCellContent(2, 2) == cell && board.GetCellContent(2, 3) == cell) return true;
        if (board.GetCellContent(3, 1) == cell && board.GetCellContent(3, 2) == cell && board.GetCellContent(3, 3) == cell) return true;

        // Check columns.
        if (board.GetCellContent(1, 1) == cell && board.GetCellContent(2, 1) == cell && board.GetCellContent(3, 1) == cell) return true;
        if (board.GetCellContent(1, 2) == cell && board.GetCellContent(2, 2) == cell && board.GetCellContent(3, 2) == cell) return true;
        if (board.GetCellContent(1, 3) == cell && board.GetCellContent(2, 3) == cell && board.GetCellContent(3, 3) == cell) return true;

        // Check diagonals.
        if (board.GetCellContent(1, 1) == cell && board.GetCellContent(2, 2) == cell && board.GetCellContent(3, 3) == cell) return true;
        if (board.GetCellContent(3, 1) == cell && board.GetCellContent(2, 2) == cell && board.GetCellContent(1, 3) == cell) return true;

        return false;
    }

    private static void Continue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}

class Player
{
    public string? Name { get; set; }
    public Cell Symbol { get; }

    public Player(Cell symbol)
    {
        Name = "Player";
        Symbol = symbol;
    }

    public void MakeMove(Board board)
    {
        Console.WriteLine($"{Name}, it's your turn. Your symbol is {Symbol}.");
        Console.Write("Enter the row coordinate: ");
        int rowCoordinate = GetCoordinate();
        Console.Write("Enter the column coordinate: ");
        int columnCoordinate = GetCoordinate();

        if (board.IsCellEmpty(rowCoordinate, columnCoordinate))
        {
            board.SetCell(rowCoordinate, columnCoordinate, Symbol);
        }
        else
        {
            Console.WriteLine("This cell is already taken. Please try again.");
            MakeMove(board);
        }
    }

    static int GetCoordinate()
    {
        string? inputText = Console.ReadLine();

        if (int.TryParse(inputText, out int inputNumber))
        {
            if (inputNumber < 1 || inputNumber > 3)
            {
                Console.Write("You have entered an invalid coordinate. Please try again: ");
                return GetCoordinate();
            }
            return inputNumber;
        }
        else
        {
            Console.Write("You have not entered a coordinate. Please try again: ");
            return GetCoordinate();
        }
    }
}

class Board
{
    public Cell[,] Cells { get; } = new Cell[3, 3];

    public Board()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Cells[i, j] = Cell.Empty;
            }
        }
    }

    public void Draw()
    {
        Console.WriteLine("  | 1 | 2 | 3 |");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("---------------");
            Console.Write($"{i + 1} | ");

            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{GetCellSymbol(Cells[i, j])} | ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("---------------");
    }

    public void SetCell(int rowCoordinate, int columnCoordinate, Cell symbol)
    {
        Cells[rowCoordinate - 1, columnCoordinate - 1] = symbol;
    }

    public bool IsCellEmpty(int rowCoordinate, int columnCoordinate)
    {
        return Cells[rowCoordinate - 1, columnCoordinate - 1] == Cell.Empty;
    }

    public bool IsBoardFull()
    {
        foreach (Cell cell in Cells)
        {
            if (cell == Cell.Empty)
            {
                return false;
            }
        }
        return true;
    }

    public Cell GetCellContent(int rowCoordinate, int columnCoordinate)
    {
        return Cells[rowCoordinate - 1, columnCoordinate - 1];
    }

    private static char GetCellSymbol(Cell cell)
    {
        return cell switch
        {
            Cell.Empty => ' ',
            Cell.X => 'X',
            Cell.O => 'O',
            _ => throw new ArgumentException("Invalid cell type.")
        };
    }
}

enum Cell
{
    Empty,
    X,
    O
}
**************************************************************************************************************************************************************************************/