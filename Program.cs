using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Lab 1. Variant 23");
        Console.WriteLine();

        Task1();
        Console.WriteLine();

        Task2();
        Console.WriteLine();

        Task3();

        Console.WriteLine();
        Console.WriteLine("Program finished.");
        Console.ReadLine();
    }

    static void Task1()
    {
        Console.WriteLine("Task 1. Swap minimum and maximum elements in list");

        List<int> numbers = new List<int> { 12, 5, 23, 8, 1, 17, 31, 9 };

        Console.WriteLine("Original list:");
        Console.WriteLine(string.Join(" ", numbers));

        int min = numbers.Min();
        int max = numbers.Max();

        int minIndex = numbers.IndexOf(min);
        int maxIndex = numbers.IndexOf(max);

        numbers[minIndex] = max;
        numbers[maxIndex] = min;

        Console.WriteLine("Minimum element: " + min);
        Console.WriteLine("Maximum element: " + max);

        Console.WriteLine("List after swap:");
        Console.WriteLine(string.Join(" ", numbers));
    }

    static void Task2()
    {
        Console.WriteLine("Task 2. Sort dictionary by values descending and save to JSON");

        Dictionary<string, int> grades = new Dictionary<string, int>();

        grades.Add("Math", 81);
        grades.Add("Physics", 83);
        grades.Add("Chemistry", 87);

        Console.WriteLine("Original dictionary:");
        foreach (var item in grades)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }

        Dictionary<string, int> sortedGrades = grades
            .OrderByDescending(item => item.Value)
            .ToDictionary(item => item.Key, item => item.Value);

        Console.WriteLine("Sorted dictionary:");
        foreach (var item in sortedGrades)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }

        string json = "{\n";

        int counter = 0;

        foreach (var item in sortedGrades)
        {
            counter++;

            json += "  \"" + item.Key + "\": " + item.Value;

            if (counter < sortedGrades.Count)
            {
                json += ",";
            }

            json += "\n";
        }

        json += "}";

        File.WriteAllText("result.json", json);

        Console.WriteLine("Dictionary was saved to result.json");
        Console.WriteLine("File path:");
        Console.WriteLine(Path.GetFullPath("result.json"));
    }

    static void Task3()
    {
        Console.WriteLine("Task 3. LINQ: odd numbers to strings and sort");

        List<int> numbers = new List<int> { 15, 2, 7, 100, 23, 8, 11, 4, 3 };

        Console.WriteLine("Original numbers:");
        Console.WriteLine(string.Join(" ", numbers));

        List<string> result = numbers
            .Where(number => number % 2 != 0)
            .Select(number => number.ToString())
            .OrderBy(text => text)
            .ToList();

        Console.WriteLine("Result:");
        Console.WriteLine(string.Join(" ", result));
    }
}