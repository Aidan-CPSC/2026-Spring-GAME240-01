using System;
using System.IO;

class Program
{
    void Main()
    {
        string specialPath = "";
        string logPath = "";
        string outputPath = "";
        
        while (true)
        {
            Console.WriteLine("What is the file path for today's special?");
            specialPath = Console.ReadLine();

            try
            {
                if (File.Exists(specialPath))
                    break;
                else
                    Console.WriteLine("File not found. Try again.");
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
        
        while (true)
        {
            Console.WriteLine("What is the file path for the fishmonger's log?");
            logPath = Console.ReadLine();

            try
            {
                if (File.Exists(logPath))
                    break;
                else
                    Console.WriteLine("File not found. Try again.");
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
        
        Console.WriteLine("Where do you want to save the result?");
        outputPath = Console.ReadLine();
        
        string specialLine = File.ReadAllText(specialPath).Trim();
        string[] specialParts = specialLine.Split(':');
        string specialName = specialParts[1].Trim();

        int specialCount = 0;
        int totalCount = 0;
        
        string[] lines = File.ReadAllLines(logPath);

        foreach (string line in lines)
        {
            if (line.Trim() == "") continue;
            
            string[] parts = line.Split(' ');

            int count = int.Parse(parts[0]);
            string fishName = parts[1];

            totalCount += count;

            if (fishName.ToLower() == specialName.ToLower())
            {
                specialCount += count;
            }
        }
        
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            writer.WriteLine($"Today's special is {specialName}");
            writer.WriteLine($"Total {specialName} caught: {specialCount}");
            writer.WriteLine($"Total fish caught: {totalCount}");
        }

        Console.WriteLine("Report created successfully.");
    }
}