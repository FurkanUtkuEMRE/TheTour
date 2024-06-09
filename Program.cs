CreateNewGame().Play();

Game CreateNewGame()
{
    return new Game(new Map(), new Player(0, 0), new ISense[] { new EntranceSense(), new EmptySense(), new FountainSense() });
}

public class Game
{
    public Map Map { get; }
    public Player Player { get; }
    public ISense[] Senses { get; }
    public RoomType CurrentRoom => Map.GetRoomType(Player.XCoordinate, Player.YCoordinate);
    public bool IsFountainOn { get; set; }
    public bool HasWon => CurrentRoom == RoomType.Entrance && IsFountainOn;

    public Game(Map map, Player player, ISense[] senses)
    {
        Map = map;
        Player = player;
        Senses = senses;
    }

    public void Play()
    {
        Console.WriteLine("Welcome to the Cave of Objects! You must find the fountain and turn it on to win the game.");
        Console.WriteLine("After you turn on the fountain, you must go back to the entrance.");
        Console.WriteLine("You are at the entrance of the cave. Go forth and explore!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();

        ShowStatus();

        while (!HasWon)
        {

            GetCommand().Execute(this);
            ShowStatus();
        }

        Console.WriteLine("Congratulations! You have won the game!");
    }

    public void ShowStatus()
    {
        if (IsFountainOn)
        {
            Console.WriteLine("You have turned on the fountain! Go back to the entrance!");
        }

        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"You are in the room at Row {Player.XCoordinate} and Column {Player.YCoordinate}.");
        foreach (ISense sense in Senses)
            if (sense.CanSense(this))
                sense.DisplaySense(this);
    }
    public ICommand GetCommand()
    {
        if (CurrentRoom == RoomType.Fountain && !IsFountainOn)
        {
            Console.WriteLine("Do you want to turn on the fountain? (Y or N)");
            string fountainCommand = Console.ReadLine().ToUpper();
            if (fountainCommand == "Y")
            {
                return new TurnOnFountainCommand();
            }
        }

        Console.WriteLine("Enter a command (N, S, E, W): ");
        string command = Console.ReadLine().ToUpper();
        switch (command)
        {
            case "N":
                return new MoveCommand(Direction.North);

            case "S":
                return new MoveCommand(Direction.South);

            case "E":
                return new MoveCommand(Direction.East);

            case "W":
                return new MoveCommand(Direction.West);

            default:
                Console.WriteLine("Invalid command. Please try again.");
                return new InvalidCommand();
        }

    }
}

public class Player
{
    public int XCoordinate { get; set; }
    public int YCoordinate { get; set; }

    public Player(int xCoordinate, int yCoordinate)
    {
        XCoordinate = xCoordinate;
        YCoordinate = yCoordinate;
    }
}

public class Map
{
    public RoomType[,] Rooms { get; } = new RoomType[4, 4];

    public Map()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Rooms[i, j] = RoomType.Empty;
            }
        }

        Rooms[0, 0] = RoomType.Entrance;
        Rooms[0, 2] = RoomType.Fountain;
    }

    public RoomType GetRoomType(int xCoordinate, int yCoordinate)
    {
        return Rooms[xCoordinate, yCoordinate];
    }
}

public interface ICommand
{
    void Execute(Game game);
}

public class MoveCommand : ICommand
{
    public Direction Direction { get; }

    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }

    public void Execute(Game game)
    {
        switch (Direction)
        {
            case Direction.North:
                if (CheckBoundries(game.Player.YCoordinate + 1))
                {
                    Console.WriteLine("Dark walls stop your advance. You can't move north any longer.");
                    return;
                }
                game.Player.YCoordinate++;
                break;
            case Direction.South:
                if (CheckBoundries(game.Player.YCoordinate - 1))
                {
                    Console.WriteLine("Dark walls stop your advance. You can't move south any longer.");
                    return;
                }
                game.Player.YCoordinate--;
                break;
            case Direction.East:
                if (CheckBoundries(game.Player.XCoordinate + 1))
                {
                    Console.WriteLine("Dark walls stop your advance. You can't move east any longer.");
                    return;
                }
                game.Player.XCoordinate++;
                break;
            case Direction.West:
                if (CheckBoundries(game.Player.XCoordinate - 1))
                {
                    Console.WriteLine("Dark walls stop your advance. You can't move west any longer.");
                    return;
                }
                game.Player.XCoordinate--;
                break;
        }
    }

    public static bool CheckBoundries(int coordinate)
    {
        return coordinate < 0 || coordinate > 3;
    }
}

public class TurnOnFountainCommand : ICommand
{
    public void Execute(Game game)
    {
        game.IsFountainOn = true;
    }
}

public class InvalidCommand : ICommand
{
    public void Execute(Game game)
    {
        Console.WriteLine("Invalid command. Please try again.");
    }
}

public interface ISense
{
    bool CanSense(Game game);
    void DisplaySense(Game game);
}

public class EntranceSense : ISense
{
    public bool CanSense(Game game)
    {
        return game.CurrentRoom == RoomType.Entrance;
    }

    public void DisplaySense(Game game)
    {
        Console.WriteLine("You see the entrance to the cave. A small breeze dances across your skin.");
    }
}

public class EmptySense : ISense
{
    public bool CanSense(Game game)
    {
        return game.CurrentRoom == RoomType.Empty;
    }

    public void DisplaySense(Game game)
    {
        Console.WriteLine("You sense nothing. This room has nothing of interest in it.");
    }
}

public class FountainSense : ISense
{
    public bool CanSense(Game game)
    {
        return game.CurrentRoom == RoomType.Fountain;
    }

    public void DisplaySense(Game game)
    {
        Console.WriteLine("You hear the sound of running water. You are at the Fountain!");
    }
}

public enum Direction
{
    North,
    South,
    East,
    West
}

public enum RoomType
{
    Entrance,
    Empty,
    Fountain
}
