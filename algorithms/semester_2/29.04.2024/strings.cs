using System;
using System.Linq;
using System.Collections.Generic;

class Program {
  static void Main() {
    List<string> strings = new List<string>() {
      "JavaScript",
      "Python",
      "C",
      "C#",
      "C++",
      "Ruby",
      "Scala",
      "Rust",
      "Go",
    };

    Console.WriteLine("Исходный список:");

    foreach (string str in strings) {
      Console.Write("{0} ", str);
    }

    Console.WriteLine("\n");

    var stringQuery = from str in strings where (str.Length % 2 == 0) select str;

    Console.WriteLine("Только элементы с четным кол-вом символов:");

    foreach (string str in stringQuery) {
      Console.Write("{0} ", str);
    }

    Console.WriteLine("\n");

    strings = strings.Where((x, i) => i % 2 == 0).ToList();

    stringQuery = from str in strings where (str.Length % 2 == 0) select str;

    Console.WriteLine("Только элементы с четным кол-вом символов, каждый второй элемент исходного списка удален:");

    foreach (string str in stringQuery) {
      Console.Write("{0} ", str);
    }

    Console.WriteLine();
  }
}
