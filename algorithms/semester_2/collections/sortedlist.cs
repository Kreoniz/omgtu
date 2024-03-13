using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program {
  static void DisplayHelp() {
    Console.WriteLine("'?' - для вывода помощи");
    Console.WriteLine("'!' - для вывода из программы");
    Console.WriteLine("'1' - Add");
    Console.WriteLine("'2' - IndexOfKey");
    Console.WriteLine("'3' - IndexOfValue");
  }

  static void DisplaySortedList(SortedList sortedList) {
    for (int i = 0; i < sortedList.Count; i += 1) {
      Console.WriteLine("Key: {0},\tValue: {1}", sortedList.GetKey(i), sortedList.GetByIndex(i));
    }
    Console.WriteLine();
  }
  
  static void Main() {
    Console.WriteLine("Операции над SortedList");
    Console.WriteLine();

    SortedList slist = new SortedList();

    Console.WriteLine("Введите количество пар ключ-значение:");
    int length = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i < length; i += 1) {
      Console.WriteLine("Введите пару ключ-значение через пробел ({0} осталось):", length - i);
      string str = Console.ReadLine();
      double[] parsedStr = str.Split(" ").Select(s => Convert.ToDouble(s)).ToArray();
      double key = parsedStr[0];
      double value = parsedStr[1];
      slist.Add(key, value);
    }

    Console.WriteLine();
    DisplayHelp();
    Console.WriteLine();

    bool running = true;
    while (running) {
      Console.WriteLine();
      Console.WriteLine("SortedList:");
      DisplaySortedList(slist);
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
            Console.WriteLine("Add:");
            Console.WriteLine("Введите пару ключ-значение через пробел:");
            string str = Console.ReadLine();
            double[] parsedStr = str.Split(" ").Select(s => Convert.ToDouble(s)).ToArray();
            double key = parsedStr[0];
            double value = parsedStr[1];
            slist.Add(key, value);
            Console.WriteLine();
            Console.WriteLine("SortedList с добавленным числом:");
            DisplaySortedList(slist);
          }
          break;
        case "2":
          {
            Console.WriteLine("IndexOfKey:");
            Console.WriteLine("Введите ключ:");
            double key = Convert.ToDouble(Console.ReadLine());
            int index = slist.IndexOfKey(key);
            Console.WriteLine();
            Console.WriteLine("Индекс ключа:");
            Console.WriteLine(index);
          }
          break;
        case "3":
          {
            Console.WriteLine("IndexOfValue:");
            Console.WriteLine("Введите значение:");
            double value = Convert.ToDouble(Console.ReadLine());
            int index = slist.IndexOfValue(value);
            Console.WriteLine();
            Console.WriteLine("Индекс значения:");
            Console.WriteLine(index);
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
