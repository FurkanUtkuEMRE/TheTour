/**************************************************************************************************************************************************************************************
Point firstPoint = new Point(2, 3);
Point secondPoint = new Point(-4, 0);

Console.WriteLine($"First point: ({firstPoint.X}, {firstPoint.Y})");
Console.WriteLine($"Second point: ({secondPoint.X}, {secondPoint.Y})");

Color firstColor = new Color(100, 100, 100);
Color secondColor = Color.Red;

Console.WriteLine($"First color: ({firstColor.R}, {firstColor.G}, {firstColor.B})");
Console.WriteLine($"Second color: ({secondColor.R}, {secondColor.G}, {secondColor.B})");

CardColor[] cardColors = [CardColor.Red, CardColor.Green, CardColor.Blue, CardColor.Yellow];
CardRank[] cardRanks = [CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Jack, CardRank.Queen, CardRank.King];

foreach (CardColor cardColor in cardColors)
{
    foreach (CardRank cardRank in cardRanks)
    {
        Card card = new Card(cardColor, cardRank);
        Console.WriteLine($"Card: {card.CardColor} {card.CardRank}");
        Console.WriteLine($"Is face card: {card.IsFaceCard()}");
        Console.WriteLine($"Is number card: {card.IsNumberCard()}\n");
    }
}

class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point()
    {
        X = 0;
        Y = 0;
    }
}

class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    public Color(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Green { get; } = new Color(0, 255, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Cyan { get; } = new Color(0, 255, 255);
    public static Color Magenta { get; } = new Color(255, 0, 255);
    public static Color Gray { get; } = new Color(128, 128, 128);
}

class Card
{
    public CardColor CardColor { get; }
    public CardRank CardRank { get; }

    public Card(CardColor cardColor, CardRank cardRank)
    {
        CardColor = cardColor;
        CardRank = cardRank;
    }

    public bool IsFaceCard()
    {
        return CardRank == CardRank.Jack || CardRank == CardRank.Queen || CardRank == CardRank.King;
    }

    public bool IsNumberCard()
    {
        return !IsFaceCard();
    }

}

enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

enum CardRank
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}
**************************************************************************************************************************************************************************************/