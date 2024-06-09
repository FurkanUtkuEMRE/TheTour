/**************************************************************************************************************************************************************************************
Robot Robot = new Robot();
Robot.Commands[0] = new OnCommand();
Robot.Commands[1] = new NorthCommand();
Robot.Commands[2] = new EastCommand();
Robot.Run();

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) { return; }
        robot.Y++;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) { return; }
        robot.Y--;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) { return; }
        robot.X++;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (!robot.IsPowered) { return; }
        robot.X--;
    }
}
**************************************************************************************************************************************************************************************/