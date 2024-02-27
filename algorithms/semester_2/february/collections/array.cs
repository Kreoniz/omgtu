using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
  static void DisplayHelp() {
    Console.WriteLine("'?' - для вывода помощи");
    Console.WriteLine("'!' - для вывода из программы");
    Console.WriteLine("'1' - Count");
    Console.WriteLine("'2' - BinSearch");
    Console.WriteLine("'3' - Copy (output full)");
    Console.WriteLine("'4' - Find");
    Console.WriteLine("'5' - FindLast");
    Console.WriteLine("'6' - indexOf");
    Console.WriteLine("'7' - Reverse");
    Console.WriteLine("'8' - Resize");
    Console.WriteLine("'9' - Sort");
  }

  static void DisplayArray(double[] array) {
    foreach (double elem in array) {
      Console.Write("{0} ", elem);
    }
    Console.WriteLine();
  }
  
  static void Main() {
    Console.WriteLine("Операции над Array");
    Console.WriteLine();
    Console.WriteLine("Введите элементы Array через пробел:");
    double[] array = Console.ReadLine()
      .Split(" ")
      .Select(s => Convert.ToDouble(s))
      .ToArray();

    Console.WriteLine();
    DisplayHelp();
    Console.WriteLine();

    bool running = true;
    while (running) {
      Console.WriteLine();
      Console.WriteLine("Array:");
      DisplayArray(array);
      Console.WriteLine();
      string command = Console.ReadLine();

      switch(command) {
        case "?":
          DisplayHelp();
          break;
        case "!":
          {
            running = false;
          }
          break;
        case "1":
          {
            Console.WriteLine("Count:");
            Console.WriteLine(array.Count());
          }
          break;
        case "2":
          {
            double[] newArray = (double[])array.Clone();
            Array.Sort(newArray); Console.WriteLine("Отсортированный Array:");
            DisplayArray(newArray);

            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());
            double binSearched = Array.BinarySearch(newArray, number);
            Console.WriteLine();
            Console.WriteLine("Индекс искомого числа в отсортированном множестве:");
            Console.WriteLine(binSearched);
          }
          break;
        case "3":
          {
            double[] newArray = (double[])array.Clone();

            Console.WriteLine("Копия множества:");
            DisplayArray(newArray);
          }
          break;
        case "4":
          {
            Console.WriteLine("Поиск первого числа множества, больше данного");
            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());
            double found = Array.Find(array, n => n > number);
            Console.WriteLine();
            Console.WriteLine("Это число:");
            Console.WriteLine(found);
          }
          break;
        case "5":
          {
            Console.WriteLine("Поиск последнего числа множества, больше данного");
            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());
            double found = Array.FindLast(array, n => n > number);
            Console.WriteLine();
            Console.WriteLine("Это число:");
            Console.WriteLine(found);
          }
          break;
        case "6":
          {
            Console.WriteLine("Поиск индекса данного числа");
            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());
            double found = Array.IndexOf(array, number);
            Console.WriteLine();
            Console.WriteLine("Индекс:");
            Console.WriteLine(found);
          }
          break;
        case "7":
          {
            Console.WriteLine("Reversed Array:");
            Array.Reverse(array);
            DisplayArray(array);
          }
          break;
        case "8":
          {
            Console.WriteLine("Введите количество элементов, которое должно остаться во множестве:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Array.Resize(ref array, length);

            Console.WriteLine();
            Console.WriteLine("'Укороченное' множество:");
            DisplayArray(array);
          }
          break;
        case "9":
          {
            Console.WriteLine("Sorted Array:");
            Array.Sort(array);
            DisplayArray(array);
          }
          break;
        default:
          {
            Console.WriteLine("Ай ду нот андерстэнд!");
            Console.WriteLine("Для списка команд введите '?'");
          }
          break;
      }
    }
  }
}
