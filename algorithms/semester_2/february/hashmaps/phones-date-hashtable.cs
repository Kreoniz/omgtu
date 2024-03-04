using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class dates {
  public static void HashtableVersion() {
    Hashtable database = new Hashtable();

    Console.WriteLine("Сколько номеров нужно хранить?");
    int count = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine();
    for (int i = 0; i < count; i += 1) {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут (через пробел):");
      Console.WriteLine($"({count - i} Осталось)");

      string str = Console.ReadLine();
      string[] subs = str.Split();

      string date = subs[1];
      double duration = Convert.ToDouble(subs[3]);

      if (database.ContainsKey(date)) {
        database[date] = Convert.ToDouble(database[date]) + duration;
      } else {
        database.Add(date, duration);
      }

      Console.WriteLine(str);
      Console.WriteLine();
    }

    Console.WriteLine("Общая сумма минут разговора каждого номера:");
    foreach (DictionaryEntry date in database) {
      Console.WriteLine($"{date.Key}: {date.Value} minutes total");
    }
  }

  public static void DictionaryVersion() {
    var database = new Dictionary<string, double>();

    Console.WriteLine("Сколько номеров нужно хранить?");
    int count = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine();
    for (int i = 0; i < count; i += 1) {
      Console.WriteLine("Введите номер, дату разговора, время начала разговора и кол-во минут (через пробел):");
      Console.WriteLine($"({count - i} Осталось)");

      string str = Console.ReadLine();
      string[] subs = str.Split();

      string date = subs[1];
      double duration = Convert.ToDouble(subs[3]);

      if (database.ContainsKey(date)) {
        database[date] = Convert.ToDouble(database[date]) + duration;
      } else {
        database.Add(date, duration);
      }

      Console.WriteLine(str);
      Console.WriteLine();
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
