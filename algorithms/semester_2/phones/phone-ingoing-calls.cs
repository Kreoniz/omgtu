using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class PhoneReport {
  public static void Main(string[] args) {
    List<string> entries = new List<string>();

    Console.WriteLine("Введите номера ('!' - чтобы закончить ввод)");
    Console.WriteLine("Введите номер телефона звонителя, номер звонимого, дата разговора, кол-во минут (через пробел):");

    string str = Console.ReadLine();
    Console.WriteLine();

    while (str != "!") {
      Console.WriteLine("Введите номер телефона звонителя, номер звонимого, дата разговора, кол-во минут (через пробел):");
      entries.Add(str);

      str = Console.ReadLine();
      Console.WriteLine();
    }

    Hashtable report = new Hashtable();

    List<string> recordedDates = new List<string>();

    Console.WriteLine();

    for (int i = 0; i < entries.Count; i += 1) {
      Hashtable durations = new Hashtable();
      string curDate = entries[i].Split()[2];

      for (int j = 0; j < entries.Count; j += 1) {
        string number = entries[j];
        string[] subs = number.Split();

        string outgoingNumber = subs[0];
        string ingoingNumber = subs[1];
        string date = subs[2];
        double duration = Convert.ToDouble(subs[3]);
        
        if (date == curDate && !recordedDates.Contains(date)) {
          if (durations.ContainsKey(ingoingNumber)) {
            durations[ingoingNumber] = Convert.ToDouble(durations[ingoingNumber]) + duration;
          } else {
            durations.Add(ingoingNumber, duration);
          }
        }
      }

      string phone = "";
      double max = 0;
      foreach (DictionaryEntry entry in durations) {
        if (Convert.ToDouble(entry.Value) > max) {
          max = Convert.ToDouble(entry.Value);
          phone = Convert.ToString(entry.Key);
        }
      }

      if (!report.ContainsKey(curDate)) {
        report.Add(curDate, phone);
      }
      recordedDates.Add(curDate);
    }

    Console.WriteLine("Отчет:");
    foreach (DictionaryEntry entry in report) {
      Console.WriteLine($"{entry.Key}: {entry.Value}\n");
    }
  }
}
