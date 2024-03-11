using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class dates {
  public static void HashtableVersion() {
    Hashtable database = new Hashtable();

    Queue<string> queue = new Queue<string>();

    Console.WriteLine("Введите номера ('!' - чтобы закончить ввод)");
    Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут (через пробел):");

    string str = Console.ReadLine();
    Console.WriteLine();

    while (str != "!") {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут (через пробел):");
      queue.Enqueue(str);

      str = Console.ReadLine();
      Console.WriteLine();
    }

    int queueLength = queue.Count;

    Console.WriteLine();
    for (int i = 0; i < queueLength; i += 1) {
      string number = queue.Dequeue();
      string[] subs = number.Split();

      string date = subs[1];
      double duration = Convert.ToDouble(subs[3]);

      if (database.ContainsKey(date)) {
        database[date] = Convert.ToDouble(database[date]) + duration;
      } else {
        database.Add(date, duration);
      }
    }

    Console.WriteLine("Общая сумма минут разговора каждого номера:");
    foreach (DictionaryEntry date in database) {
      Console.WriteLine($"{date.Key}: {date.Value} minutes total");
    }
  }

  public static void DictionaryVersion() {
    var database = new Dictionary<string, double>();

    Queue<string> queue = new Queue<string>();

    Console.WriteLine("Введите номера ('!' - чтобы закончить ввод)");
    Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут (через пробел):");

    string str = Console.ReadLine();
    Console.WriteLine();

    while (str != "!") {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут (через пробел):");
      queue.Enqueue(str);

      str = Console.ReadLine();
      Console.WriteLine();
    }

    int queueLength = queue.Count;

    Console.WriteLine();
    for (int i = 0; i < queueLength; i += 1) {
      string number = queue.Dequeue();
      string[] subs = number.Split();

      string date = subs[1];
      double duration = Convert.ToDouble(subs[3]);

      if (database.ContainsKey(date)) {
        database[date] = Convert.ToDouble(database[date]) + duration;
      } else {
        database.Add(date, duration);
      }
    }

    Console.WriteLine("Общая сумма минут разговора каждого номера:");
    foreach (var date in database) {
      Console.WriteLine($"{date.Key}: {date.Value} minutes total");
    }
  }

  public static void Main(string[] args) {
    Console.WriteLine("Введите какую структуру данных использовать:");
    Console.WriteLine("(1) - Hashtable");
    Console.WriteLine("(2) - Dictionary");

    int version = Convert.ToInt32(Console.ReadLine());

    if (version == 1) {
      Console.WriteLine();
      Console.WriteLine("Hashtable:");
      Console.WriteLine();
      HashtableVersion();
    } else if (version == 2) {
      Console.WriteLine();
      Console.WriteLine("Dictionary:");
      Console.WriteLine();
      DictionaryVersion();
    } else {
      Console.WriteLine("Куда?!?");
    }
  }
}
