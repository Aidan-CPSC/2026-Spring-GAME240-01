Console.WriteLine("This calculator can perform 4 operations: addition, subtraction, multiplication, and division.");
Console.WriteLine("What operation would you like to perform?");
string operation = Console.ReadLine();
if (operation == "addition")
{
    Console.WriteLine("What is your first number?");
    double firstNumber = int.Parse(Console.ReadLine());
    Console.WriteLine("What is your second number?");
    double secondNumber = int.Parse(Console.ReadLine());
    Console.WriteLine(firstNumber + " + " + secondNumber + " is " + (firstNumber + secondNumber));
}
else if (operation == "subtraction")
{
    Console.WriteLine("What is your first number?");
    double firstNumber = int.Parse(Console.ReadLine());
    Console.WriteLine("What is your second number?");
    double secondNumber = int.Parse(Console.ReadLine());
    Console.WriteLine(firstNumber + " - " + secondNumber + " is " + (firstNumber - secondNumber));
}
else if (operation == "multiplication")
{
    Console.WriteLine("What is your first number?");
    double firstNumber = int.Parse(Console.ReadLine());
    Console.WriteLine("What is your second number?");
    double secondNumber = int.Parse(Console.ReadLine());
    Console.WriteLine(firstNumber + " * " + secondNumber + " is " + (firstNumber * secondNumber));
}
else if (operation == "division")
{
    Console.WriteLine("What is your first number?");
    double firstNumber = int.Parse(Console.ReadLine());
    Console.WriteLine("What is your second number?");
    double secondNumber = int.Parse(Console.ReadLine());
    if (secondNumber == 0) Console.WriteLine("You cannot divide by zero.");
    else Console.WriteLine(firstNumber + " / " + secondNumber + " is " + (firstNumber / secondNumber));
}
else
{
    Console.WriteLine("I do not know how to do that.");
}