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
    Console.WriteLine("'4' - indexOf");
    Console.WriteLine("'5' - Insert");
    Console.WriteLine("'6' - Reverse");
    Console.WriteLine("'7' - Sort");
    Console.WriteLine("'8' - Add");
  }

  static void DisplayArrayList(ArrayList arrayList) {
    foreach (double elem in arrayList) {
      Console.Write("{0} ", elem);
    }
    Console.WriteLine();
  }
  
  static void Main() {
    Console.WriteLine("Операции над ArrayList");
    Console.WriteLine();
    Console.WriteLine("Введите элементы ArrayList через пробел:");
    var array = Console.ReadLine()
      .Split(" ")
      .Select(s => Convert.ToDouble(s))
      .ToArray();

    var arlist = new ArrayList();
    arlist.AddRange(array);

    Console.WriteLine();
    DisplayHelp();
    Console.WriteLine();

    bool running = true;
    while (running) {
      Console.WriteLine();
      Console.WriteLine("Array:");
      DisplayArrayList(arlist);
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
            Console.WriteLine(arlist.Count);
          }
          break;
        case "2":
          {
            var newArrayList = new ArrayList(arlist);
            Console.WriteLine("Отсортированный ArrayList:");
            newArrayList.Sort();
            DisplayArrayList(newArrayList);

            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());
            double binSearched = newArrayList.BinarySearch(number);
            Console.WriteLine();
            Console.WriteLine("Индекс искомого числа в отсортированном множестве:");
            Console.WriteLine(binSearched);
          }
          break;
        case "3":
          {
            var newArrayList = new ArrayList(arlist);

            Console.WriteLine("Копия множества:");
            DisplayArrayList(newArrayList);
          }
          break;
        case "4":
          {
            Console.WriteLine("Поиск индекса данного числа");
            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());
            double found = arlist.IndexOf(number);
            Console.WriteLine();
            Console.WriteLine("Индекс:");
            Console.WriteLine(found);
          }
          break;
        case "5":
          {
            Console.WriteLine("Вставляем число в ArrayList");
            Console.WriteLine("Введите индекс:");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());

            arlist.Insert(index, number);

            Console.WriteLine();
            Console.WriteLine("ArrayList со вставленным числом:");
            DisplayArrayList(arlist);
          }
          break;
        case "6":
          {
            Console.WriteLine("Reversed ArrayList:");
            arlist.Reverse();
            DisplayArrayList(arlist);
          }
          break;
        case "7":
          {
            arlist.Sort();
            DisplayArrayList(arlist);
          }
          break;
        case "8":
          {
            Console.WriteLine("Введите число для добавления:");
            double number = Convert.ToDouble(Console.ReadLine());
            arlist.Add(number);
            Console.WriteLine();
            Console.WriteLine("ArrayList с добавленным числом:");
            DisplayArrayList(arlist);
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
