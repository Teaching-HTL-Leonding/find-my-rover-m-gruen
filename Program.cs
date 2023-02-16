// Find my Rover

string movement;
long verticalMovement = 0, horizontalMovement = 0;

Console.Clear();
System.Console.WriteLine("Hello and welcome to the Find my Rover game!");
System.Console.Write("Enter your input: ");
movement = GetValidInput();

char lastChar = ' ';
for (int i = 0; i < movement.Length; i++)
{
    char c = movement[i];
    if (Char.IsDigit(c))
    {
        string numbers = c.ToString();
        if (i < movement.Length - 1)
        {
            while (Char.IsDigit(movement[i + 1]))
            {
                i++;
                numbers += movement[i].ToString();
                if (i > movement.Length - 2) { break; }
            }
        }
        long number = long.Parse(numbers) - 1;
        switch (lastChar)
        {
            case 'V': horizontalMovement += number; break;
            case '<': verticalMovement += number; break;
            case '>': verticalMovement -= number; break;
            case '^': horizontalMovement -= number; break;
        }
    }
    switch (c)
    {
        case 'V': horizontalMovement++; break;
        case '<': verticalMovement++; break;
        case '>': verticalMovement--; break;
        case '^': horizontalMovement--; break;
    }
    lastChar = c;
}

System.Console.Write("The Rover is");

if (horizontalMovement == 0 && verticalMovement == 0) { System.Console.Write("at the base!"); }
else
{
    if (verticalMovement > 0) { System.Console.Write($" {verticalMovement}m to the West"); }
    else if (verticalMovement < 0) { System.Console.Write($" {verticalMovement * -1}m to the East"); }

    if (horizontalMovement > 0) { System.Console.Write($" {horizontalMovement}m to the South"); }
    else if (horizontalMovement < 0) { System.Console.Write($" {horizontalMovement * -1}m to the North"); }
}

System.Console.WriteLine();
System.Console.WriteLine($"Linear distance = {CalculateTheDistance(horizontalMovement, verticalMovement)}m, Manhattan distance = {CalculateTheManhattanDistance(horizontalMovement, verticalMovement)}m");

string GetValidInput()
{
    string input = "";
    bool isValid = true;
    do
    {
        isValid = true;
        input = System.Console.ReadLine()!;

        for (int i = 0; i < input.Length; i++)
        {
            if (!(input[i] is 'V' or '<' or '>' or '^'))
            {
                if (Char.IsDigit(input[i]) && i != 0) { }
                else
                {
                    System.Console.Write("Try again ... ");
                    isValid = false;
                    break;
                }
            }
        }
    }
    while (!isValid);
    return input;
}

double CalculateTheDistance(long x, long y)
{
    return Math.Round(Math.Pow(Math.Pow(x, 2) + Math.Pow(y, 2), 0.5), 2);
}

long CalculateTheManhattanDistance(long x, long y)
{
    return Math.Abs(x) + Math.Abs(y);
}
