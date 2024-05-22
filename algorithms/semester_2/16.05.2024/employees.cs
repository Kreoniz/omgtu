using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Production
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public string ProductCategory { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}


class Employees
{
    static void Main()
    {
        List<Production> productions = new List<Production>
        {
            new Production { EmployeeId = 1, FullName = "John Doe", Position = "Worker", Salary = 10m, ProductCategory = "Category 1", Quantity = 10, Price = 10.5m },
            new Production { EmployeeId = 2, FullName = "Jane Doe", Position = "Worker", Salary = 1500m, ProductCategory = "Category 2", Quantity = 5, Price = 20.0m },
            new Production { EmployeeId = 3, FullName = "Jim Smith", Position = "Worker", Salary = 2000m, ProductCategory = "Category 1", Quantity = 15, Price = 15.0m },
            new Production { EmployeeId = 4, FullName = "Billy Jean", Position = "Worker", Salary = 1500m, ProductCategory = "Category 2", Quantity = 5, Price = 30.0m },
        };

        int workersWithSalaryLessThanProduction = productions
            .Count(p => p.Salary < p.Quantity * p.Price);
        Console.WriteLine($"Кол-во рабочих, которые получают ЗП < сумма выработанной продукции: {workersWithSalaryLessThanProduction}");
        Console.WriteLine();

        var productionByCategory = productions
            .GroupBy(p => p.ProductCategory)
            .Select(g => new { Category = g.Key, Quantity = g.Sum(p => p.Quantity), TotalValue = g.Sum(p => p.Quantity * p.Price) });
        foreach (var item in productionByCategory)
        {
            Console.WriteLine($"Категория {item.Category}: {item.Quantity} шт. ({item.TotalValue})");
        }
        Console.WriteLine();

        decimal totalProductionQuantity = productions.Sum(p => p.Quantity);
        decimal totalProductionValue = productions.Sum(p => p.Quantity * p.Price);
        Console.WriteLine("Общий суммарный объём произведённой продукции:");
        Console.WriteLine($"В количественном эквиваленте: {totalProductionQuantity}");
        Console.WriteLine($"В денежном эквиваленте: {totalProductionValue}");
        Console.WriteLine();

        int employeesWithSalaryGreaterThanHalfOfProduction = productions
            .Count(p => p.Salary > p.Quantity * p.Price * 0.5m);
        Console.WriteLine($"Кол-во сотрудников, получающих > 50% от суммы производимого ими продукта: {employeesWithSalaryGreaterThanHalfOfProduction}");
    }
}
