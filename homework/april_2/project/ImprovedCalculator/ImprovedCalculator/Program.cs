Console.WriteLine("This calculator can perform 5 operations: addition (+), subtraction (-), multiplication (*), and division.");
while (true)
{
    Console.WriteLine("Please type a mathematical expression, or type \"quit\" to shut down the calculator.");
    Console.Write("> ");
    string expression = Console.ReadLine();
    if (expression.ToLower() == "quit")
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    string[] parts = expression.Split(' ');
    if (parts.Length != 3)
    {
        Console.WriteLine("I do not know how to do that.");
        continue;
    }

    string operation = parts[1];
    float firstNumber;
    float secondNumber;
    try
    {
        firstNumber = float.Parse(parts[0]);
        secondNumber = float.Parse(parts[2]);
    }
    catch (FormatException)
    {
        Console.WriteLine("I do not know how to do that.");
        continue;
    }

    if (operation == "+")
    {
        Console.WriteLine(expression + " is " + (firstNumber + secondNumber));
    }
    else if (operation == "-")
    {
        Console.WriteLine(expression + " is " + (firstNumber - secondNumber));
    }
    else if (operation == "*")
    {
        Console.WriteLine(expression + " is " + (firstNumber * secondNumber));
    }
    else if (operation == "/")
    {
        if (secondNumber != 0) Console.WriteLine(expression + " is " + (firstNumber / secondNumber));
        else Console.WriteLine("Cannot divide by zero.");
    }
    else if (operation == "%")
    {
        if (secondNumber != 0) Console.WriteLine(expression + " is " + (firstNumber % secondNumber));
        else Console.WriteLine("Cannot modulus by zero.");
    }
    else
    {
        Console.WriteLine("I do not know how to do that.");
    }
}