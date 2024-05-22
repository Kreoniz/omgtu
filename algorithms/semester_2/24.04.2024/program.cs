using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "input.txt";
        string text = File.ReadAllText(filePath);
        int[] counts = new int[26];
        int maxCount = 0;
        char maxChar = '\0';
        HashSet<char> uniqueChars = new HashSet<char>();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                int index = char.ToLower(c) - 'a';
                counts[index]++;
                uniqueChars.Add(c);

                if (counts[index] > maxCount)
                {
                    maxCount = counts[index];
                    maxChar = c;
                }
            }
        }

        Console.WriteLine($"Символ, встречающийся чаще всего: {maxChar} ({maxCount} раз)");
        Console.WriteLine($"Количество уникальных символов: {uniqueChars.Count}");
        Console.WriteLine($"Список символов (в алфавитном порядке): {string.Join(" ", uniqueChars.OrderBy(c => c))}");
    }
}
