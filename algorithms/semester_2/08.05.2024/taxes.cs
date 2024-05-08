using System;
using System.Collections.Generic;
using System.Linq;

public class BankAccount {
  public int AccountNumber { get; set; }
  public string Name { get; set; }
  public decimal Income { get; set; }
  public decimal Expenses { get; set; }
  public decimal Tax { get; set; }

  public decimal Balance {
    get { return Income - Expenses - Tax; }
  }
}

public class Program {
  public static void Main() {
    List<BankAccount> accounts = new List<BankAccount> {
      new BankAccount { AccountNumber = 1, Name = "John Doe", Income = 1000, Expenses = 500 },
      new BankAccount { AccountNumber = 2, Name = "Jane Doe", Income = 2000, Expenses = 1500 },
      new BankAccount { AccountNumber = 3, Name = "Jim Smith", Income = 3000, Expenses = 2500 },
      new BankAccount { AccountNumber = 4, Name = "Jill Smith", Income = 3900, Expenses = 3500 },
      new BankAccount { AccountNumber = 5, Name = "Billy Jean", Income = 10000, Expenses = 9900 },
      new BankAccount { AccountNumber = 6, Name = "Ashley Jean", Income = 10000, Expenses = 4000 }
    };

    foreach (var account in accounts) {
      account.Tax = account.Income * 0.05M;
    }

    Console.WriteLine("Клиенты с отрицательным балансом:");

    var negativeBalanceAccounts = from account in accounts
      where account.Balance < 0
      select account;

    foreach (var account in negativeBalanceAccounts) {
      Console.WriteLine($"{account.Name} ({account.AccountNumber})");
    }

    Console.WriteLine();

    var positiveBalanceAccounts = from account in accounts
      where account.Balance > 0
      select account;
    Console.WriteLine($"Кол-во клиентов с положительным балансом: {positiveBalanceAccounts.Count()}");

    Console.WriteLine();

    var maxIncomeAccounts = from account in accounts
      where account.Income == accounts.Max(a => a.Income)
      select account;

    Console.WriteLine($"Клиенты с максимальной зарплатой ({maxIncomeAccounts.First().Income}):");

    foreach (var account in maxIncomeAccounts) {
      Console.WriteLine($"{account.Name} ({account.AccountNumber})");
    }

    Console.WriteLine();
    var totalTax = from account in accounts
      select account.Tax;

    Console.WriteLine($"Общая сумма налогов: {totalTax.Sum()}");
  }
}
