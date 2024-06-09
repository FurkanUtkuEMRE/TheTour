/**************************************************************************************************************************************************************************************
Play(1, 10, 15);

static void Play(int currentRound, int manticoreHealth, int consolasHealth)
{
    string gameMode = GameMode();
    int currentDistance = GetCurrentDistance(gameMode);

    while (manticoreHealth > 0 && consolasHealth > 0)
    {
        ShowCurrentStatus(currentRound, manticoreHealth, consolasHealth);

        int temporaryManticoreHealth = AttackManticore(currentRound, manticoreHealth, currentDistance);

        consolasHealth = AttackConsolas(consolasHealth);

        if (temporaryManticoreHealth < manticoreHealth)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Manticore is changing location!");
            Console.ResetColor();
            currentDistance = GetCurrentDistance(gameMode);
        }

        manticoreHealth = temporaryManticoreHealth;

        currentRound++;
    }

    CheckGameState(manticoreHealth, consolasHealth);
}

static void ShowCurrentStatus(int currentRound, int manticoreHealth, int consolasHealth)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"Round {currentRound}:");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Manticore Health: {manticoreHealth}");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Consolas Health: {consolasHealth} \n");
    Console.ResetColor();

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

static int GetCurrentDistance(string gameMode)
{
    int currentDistance;

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Pilot of the Uncoded One is flying the Manticore...");
    Console.ResetColor();

    if (gameMode == "S" || gameMode == "s")
    {
        Random random = new Random();
        currentDistance = random.Next(0, 100);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();

        return currentDistance;
    }

    Console.Write("Your distance from the City of Consolas: ");

    currentDistance = GetNumberFromUser();

    while (currentDistance <= 0 || currentDistance >= 100)
    {
        Console.WriteLine("You probably made a mistake pilot, you should be within zero to a hundred range from the city...");
        Console.Write("Now, once more, your distance from the City of Consolas: ");
        currentDistance = GetNumberFromUser();
    }

    Console.Clear();

    return currentDistance;
}

static int AttackManticore(int currentRound, int manticoreHealth, int currentDistance)
{
    int currentDamage = CalculateDamage(currentRound);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Hero is attacking the Manticore with cannons!");
    Console.ResetColor();

    Console.WriteLine($"Cannon is expected to deal {currentDamage} Damage this round!");
    Console.Write("Your targeted range is: ");

    int targetedRange = GetNumberFromUser();

    while (targetedRange <= 0 || targetedRange >= 100)
    {
        Console.WriteLine("You probably made a mistake hero, you should target zero to a hundred range from the city...");
        Console.Write("Now, once more, your targeted range is: ");
        targetedRange = GetNumberFromUser();
    }

    if (targetedRange == currentDistance)
    {
        manticoreHealth -= currentDamage;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nDirect hit! You have dealt {currentDamage} Damage!");
        Console.ResetColor();
    }
    else if (targetedRange < currentDistance)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYour attack fell short!");
        Console.ResetColor();
    }
    else if (targetedRange > currentDistance)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYou overshot the target!");
        Console.ResetColor();
    }

    return manticoreHealth;
}

static int AttackConsolas(int consolasHealth)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nThunder and lightning!");
    Console.WriteLine("Manticore have dealt 1 Damage to the City of Consolas!\n");
    Console.ResetColor();

    consolasHealth -= 1;

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();

    return consolasHealth;
}

static int CalculateDamage(int currentRound)
{
    if (currentRound % 3 == 0 && currentRound % 5 == 0)
    {
        return 10;
    }
    else if (currentRound % 3 == 0)
    {
        return 3;
    }
    else if (currentRound % 5 == 0)
    {
        return 3;
    }
    else
    {
        return 1;
    }
}

static int GetNumberFromUser()
{
    string? inputText = Console.ReadLine();

    if (int.TryParse(inputText, out int inputNumber))
    {
        return inputNumber;
    }
    else
    {
        Console.Write("You have not entered a number. Please try again: ");
        return GetNumberFromUser();
    }
}

static void CheckGameState(int manticoreHealth, int consolasHealth)
{
    if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Congratulations hero, you have defeated the Manticore!");
        Console.ResetColor();
    }
    else if (consolasHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Manticore have destroyed the City of Consolas!");
        Console.ResetColor();
    }
    else
    {
        return;
    }

    RestartGame();
}

static void RestartGame()
{
    Console.WriteLine("Play again? (Y or N)");
    string? restartGame = Console.ReadLine();

    if (restartGame == "Y" || restartGame == "y")
    {
        Play(1, 10, 15);
    }
    else if (restartGame == "N" || restartGame == "n")
    {
        Console.WriteLine("Goodbye hero!");
    }
    else
    {
        Console.WriteLine("Invalid input.");
        RestartGame();
    }
}

static string GameMode()
{
    Console.WriteLine("Singleplayer or Multiplayer? (S or M)");
    string? gameMode = Console.ReadLine();

    if (gameMode == "S" || gameMode == "s")
    {
        Console.WriteLine("Starting Singleplayer. Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        return gameMode;
    }
    else if (gameMode == "M" || gameMode == "m")
    {
        Console.WriteLine("Starting Multiplayer. Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        return gameMode;
    }
    else
    {
        Console.WriteLine("Invalid input.");
        return GameMode();
    }
}
**************************************************************************************************************************************************************************************/