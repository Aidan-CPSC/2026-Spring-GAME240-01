// Problem 1
int var1 = 1;
while (var1 <= 5)
{
    Console.Write(var1 + " ");
    var1++;
}
Console.WriteLine("\n");

// Problem 2
int var2 = 100;
while (var2 <= 150)
{
    Console.Write(var2 + " ");
    var2++;
}
Console.WriteLine("\n");

// Problem 3
int var3 = 0;
while (var3 <= 100)
{
    Console.Write(var3 + " ");
    var3 += 2;
}
Console.WriteLine("\n");

// Problem 4
int var4 = 20;
while (var4 >= -20)
{
    Console.Write(var4 + " ");
    var4--;
}
Console.WriteLine("\n");

// Problem 5
int var5 = 1;
while (var5 <= 100)
{
    Console.Write(var5 + " ");
    var5 += 3;
}
Console.WriteLine("\n");

// Problem 6
int var6 = 1;
while (var6 <= 1024)
{
    Console.Write(var6 + " ");
    var6 *= 2;
}
Console.WriteLine("\n");

// Problem 7
string var7;
do
{
    Console.WriteLine("Do you want the loop to stop?");
    var7 = Console.ReadLine();
}
while (var7 != "yes");
Console.WriteLine("\n");

// Problem 8
int stopCounter = 0;
bool var8 = true;
while (true)
{
    Console.Write(var8 + " ");
    var8 = !var8;

    // to prevent infinite loop
    stopCounter++;
    if (stopCounter == 100) break;
}
Console.WriteLine("\n");

// Problem 9
int var9 = 1;
bool isEven = false;
while (var9 <= 20)
{
    if (isEven) Console.Write(var9 + " is even. ");
    else Console.Write(var9 + " is odd. ");
    var9++;
    isEven = !isEven;
}
Console.WriteLine("\n");

// Problem 10
string[] words = { "once", "upon", "a", "midnight", "dreary"};
int var10 = 0;
while (var10 < words.Length)
{
    Console.Write(words[var10] + " ");
    var10++;
}