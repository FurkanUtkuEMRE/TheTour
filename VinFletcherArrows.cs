/**************************************************************************************************************************************************************************************
Arrow userArrow = new Arrow(GetArrowhead(), GetFletchling(), GetLength());
ChangeChoice();
Console.WriteLine($"Cost of your arrow is {userArrow.Cost} Gold.");

void ChangeChoice()
{
    ShowChoiceText();
    string? changeChoice = Console.ReadLine();
    Console.Clear();

    while (changeChoice != "0")
    {
        if (changeChoice == "1")
        {
            userArrow.Arrowhead = GetArrowhead();
            ShowChoiceText();
            changeChoice = Console.ReadLine();
            Console.Clear();
        }
        else if (changeChoice == "2")
        {
            userArrow.Fletchling = GetFletchling();
            ShowChoiceText();
            changeChoice = Console.ReadLine();
            Console.Clear();
        }
        else if (changeChoice == "3")
        {
            userArrow.Length = GetLength();
            ShowChoiceText();
            changeChoice = Console.ReadLine();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Invalid choice. Pick a valid option.");
            ShowChoiceText();
            changeChoice = Console.ReadLine();
            Console.Clear();
        }
    }

}

void ShowChoiceText()
{
    Console.WriteLine($"Here is your arrow of choice: {userArrow.Arrowhead} Arrowhead, {ShowUIFriendlyFletchlingName(userArrow.Fletchling)} Fletchling, {userArrow.Length} Centimeters.");
    Console.WriteLine($"Are you sure about your choice?");
    Console.WriteLine($"0. Yes");
    Console.WriteLine($"1. Change Arrowhead Type");
    Console.WriteLine($"2. Change Fletchling Type");
    Console.WriteLine($"3. Change Shaft Length");
}

string ShowUIFriendlyFletchlingName(Fletchling fletchling)
{
    return fletchling switch
    {
        Fletchling.Plastic => "Plastic",
        Fletchling.TurkeyFeathers => "Turkey Feathers",
        Fletchling.GooseFeathers => "Goose Feathers",
        _ => "Plastic"
    };
}

Arrowhead GetArrowhead()
{
    Console.WriteLine("What type of arrowhead do you want?");
    Console.WriteLine("1. Steel (Default)");
    Console.WriteLine("2. Wood");
    Console.WriteLine("3. Obsidian");
    string? arrowheadChoice = Console.ReadLine();
    Console.Clear();

    return arrowheadChoice switch
    {
        "1" => Arrowhead.Steel,
        "2" => Arrowhead.Wood,
        "3" => Arrowhead.Obsidian,
        _ => Arrowhead.Steel
    };
}

Fletchling GetFletchling()
{
    Console.WriteLine("What type of fletchling do you want?");
    Console.WriteLine("1. Plastic (Default)");
    Console.WriteLine("2. Turkey Feathers");
    Console.WriteLine("3. Goose Feathers");
    string? fletchlingChoice = Console.ReadLine();
    Console.Clear();

    return fletchlingChoice switch
    {
        "1" => Fletchling.Plastic,
        "2" => Fletchling.TurkeyFeathers,
        "3" => Fletchling.GooseFeathers,
        _ => Fletchling.Plastic
    };
}

float GetLength()
{
    Console.WriteLine("What is your desired shaft length? (60-100 Centimeters)");
    float length = Convert.ToSingle(Console.ReadLine());
    Console.Clear();

    while (length < 60 || length > 100)
    {
        Console.WriteLine("Pick between sixty and hundred centimeters.");
        length = Convert.ToSingle(Console.ReadLine());
        Console.Clear();
    }

    return length;
}

class Arrow
{
    public Arrowhead Arrowhead { get; set; } = Arrowhead.Steel;
    public Fletchling Fletchling { get; set; } = Fletchling.Plastic;
    public float Length { get; set; } = 60;

    public Arrow(Arrowhead arrowhead, Fletchling fletchling, float length)
    {
        Arrowhead = arrowhead;
        Fletchling = fletchling;
        Length = length;
    }

    public float Cost
    {
        get
        { 
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5,
                _ => 0
            };

            float fletchlingCost = Fletchling switch
            {
                Fletchling.Plastic => 10,
                Fletchling.TurkeyFeathers => 5,
                Fletchling.GooseFeathers => 3,
                _ => 0
            };

            float shaftCost = Length * 0.05f;

            return arrowheadCost + fletchlingCost + shaftCost;
        }
    }

}

enum Arrowhead
{
    Steel,
    Wood,
    Obsidian
}

enum Fletchling
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}
**************************************************************************************************************************************************************************************/