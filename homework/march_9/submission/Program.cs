int[] numbers = {4, 2, 99, 100, -5};

int smallest = numbers[0];
int largest = numbers[0];

for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] < smallest)
    {
        smallest = numbers[i];
    }

    if (numbers[i] > largest)
    {
        largest = numbers[i];
    }
}

Console.WriteLine("The largest number is " + largest + ". The smallest number is " + smallest + ".");