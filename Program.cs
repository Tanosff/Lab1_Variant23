using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // щоб українські букви нормально відображались
        Console.OutputEncoding = Encoding.UTF8;

        Task1_23();
        Console.WriteLine();

        Task2_23();
        Console.WriteLine();

        Task3_23();

        Console.ReadKey();
    }

    // Завдання 1.23
    static void Task1_23()
    {
        Console.WriteLine("===== Завдання 1.23 =====");

        Random rand = new Random();
        List<int> numbers = new List<int>();

        // генеруємо унікальні числа
        while (numbers.Count < 10)
        {
            int value = rand.Next(1, 100);
            if (!numbers.Contains(value))
                numbers.Add(value);
        }

        Console.WriteLine("Початковий список:");
        Console.WriteLine(string.Join(" ", numbers));

        int minIndex = numbers.IndexOf(numbers.Min());
        int maxIndex = numbers.IndexOf(numbers.Max());

        // обмін
        int temp = numbers[minIndex];
        numbers[minIndex] = numbers[maxIndex];
        numbers[maxIndex] = temp;

        Console.WriteLine("Після обміну мінімального і максимального:");
        Console.WriteLine(string.Join(" ", numbers));

        SaveToJson(numbers, "task1_23_result.json");
    }

    // Завдання 2.23
    static void Task2_23()
    {
        Console.WriteLine("===== Завдання 2.23 =====");

        Random rand = new Random();

        Dictionary<string, int> subjects = new Dictionary<string, int>
        {
            { "Math", rand.Next(60, 100) },
            { "Physics", rand.Next(60, 100) },
            { "Chemistry", rand.Next(60, 100) }
        };

        Console.WriteLine("Початковий словник:");
        foreach (var item in subjects)
            Console.WriteLine($"{item.Key}: {item.Value}");

        var sorted = subjects
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        Console.WriteLine("Відсортований словник за спаданням:");
        foreach (var item in sorted)
            Console.WriteLine($"{item.Key}: {item.Value}");

        SaveToJson(sorted, "task2_23_result.json");
    }

    // Завдання 3.23
    static void Task3_23()
    {
        Console.WriteLine("===== Завдання 3.23 =====");

        Random rand = new Random();
        List<int> numbers = new List<int>();

        for (int i = 0; i < 10; i++)
            numbers.Add(rand.Next(1, 100)); // тільки додатні

        Console.WriteLine("Початкова послідовність:");
        Console.WriteLine(string.Join(" ", numbers));

        var oddNumbers = numbers.Where(x => x % 2 != 0);
        Console.WriteLine("Непарні числа:");
        Console.WriteLine(string.Join(" ", oddNumbers));

        var result = numbers
            .Where(x => x % 2 != 0)
            .Select(x => x.ToString())
            .OrderBy(x => x)
            .ToList();

        Console.WriteLine("Результат (рядки, відсортовані лексикографічно):");
        Console.WriteLine(string.Join(" ", result));

        SaveToJson(result, "task3_23_result.json");
    }

    // збереження в JSON
    static void SaveToJson<T>(T data, string fileName)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(path, json);

        Console.WriteLine($"Результат збережено у файл: {path}");
    }
}