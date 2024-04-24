using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Files {
  public static int CompareByDates(string v1, string v2) {
    double date1 = Convert.ToDouble(v1.Split()[0]);
    double date2 = Convert.ToDouble(v2.Split()[0]);
    
    if (date1 > date2) {
      return 1;
    } else {
      return -1;
    }
  }

  public static void Main(string[] args) {
    Console.WriteLine("Line");
    List<string> file = File.ReadAllLines("./file.txt").ToList();
    List<string> sorted_years = new List<string>(file);
    sorted_years.Sort(CompareByDates);
    List<string> sorted_cities = new List<string>(file);
    sorted_cities.Sort((s1, s2) => s1.Split()[1].CompareTo(s2.Split()[1]));

    Console.WriteLine();
    Console.WriteLine("Отсортировано по дате:");
    using (StreamWriter sw = File.CreateText("./out_file_1.txt"))  {
      foreach (var line in sorted_years) {
        Console.WriteLine(line);
        sw.WriteLine(line);
      }
    }

    Console.WriteLine();
    Console.WriteLine("Отсортировано по городам:");
    using (StreamWriter sw = File.CreateText("./out_file_2.txt"))  {
      foreach (var line in sorted_cities) {
        string[] split_line = line.Split();
        Console.WriteLine($"{split_line[1]} {split_line[0]} {split_line[2]}");
        sw.WriteLine($"{split_line[1]} {split_line[0]} {split_line[2]}");
      }
    }

    Console.WriteLine();
    Console.WriteLine("Введите название страны:");
    string country = Console.ReadLine();
    using (StreamWriter sw = File.CreateText("./out_file_3.txt"))  {
      foreach (var line in file) {
        if (country == line.Split()[2]) {
          Console.WriteLine(line);
          sw.WriteLine(line);
        }
      }
    }

  }
}
