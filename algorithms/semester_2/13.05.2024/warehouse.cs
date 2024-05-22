using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class Product
{
    public int Article { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Warehouse { get; set; }
}


class Warehouse
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Article = 1, Name = "Product 1", Category = "Category 1", Quantity = 10, Price = 10.5, Warehouse = "Warehouse 1" },
                new Product { Article = 2, Name = "Product 2", Category = "Category 2", Quantity = 5, Price = 20.0, Warehouse = "Warehouse 1" },
                new Product { Article = 3, Name = "Product 3", Category = "Category 1", Quantity = 15, Price = 15.0, Warehouse = "Warehouse 2" },
                new Product { Article = 4, Name = "Product 4", Category = "Category 3", Quantity = 100, Price = 50.0, Warehouse = "Warehouse 3" },
                new Product { Article = 5, Name = "Product 5", Category = "Category 3", Quantity = 100, Price = 115.0, Warehouse = "Warehouse 3" },
        };

        var totalValueByWarehouse = products
            .GroupBy(p => p.Warehouse)
            .Select(g => new { Warehouse = g.Key, TotalValue = g.Sum(p => p.Quantity * p.Price) });
        foreach (var item in totalValueByWarehouse)
        {
            Console.WriteLine($"Объем товара в денежном эквиваленте склада {item.Warehouse}: {item.TotalValue}");
        }
        Console.WriteLine();

        var maxPriceByCategory = products
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.Price) });
        foreach (var item in maxPriceByCategory)
        {
            Console.WriteLine($"Максимальная цена категории {item.Category}: {item.MaxPrice}");
        }
        Console.WriteLine();

        var averagePriceByWarehouse = products
            .GroupBy(p => p.Warehouse)
            .Select(g => new { Warehouse = g.Key, AveragePrice = g.Average(p => p.Price) });
        foreach (var item in averagePriceByWarehouse)
        {
            Console.WriteLine($"Средняя цена товара по складу {item.Warehouse}: {item.AveragePrice}");
        }
        Console.WriteLine();
        var overallAveragePrice = products.Average(p => p.Price);
        Console.WriteLine($"Средняя цена по всем складам: {overallAveragePrice}");
        Console.WriteLine();

        var cheapestProduct = products.OrderBy(p => p.Price).First();
        Console.WriteLine($"Самый дешевый товар: {cheapestProduct.Name} ({cheapestProduct.Price})");
        Console.WriteLine();

        var warehouseWithLowestTotalValue = products
            .GroupBy(p => p.Warehouse)
            .OrderBy(g => g.Sum(p => p.Quantity * p.Price))
            .First();

        Console.WriteLine($"Склад с наименьшей суммарной стоимостью товаров: {warehouseWithLowestTotalValue.Key}");
        foreach (var product in warehouseWithLowestTotalValue)
        {
            Console.WriteLine($"{product.Article}: {product.Name} ({product.Quantity} x {product.Price})");
        }
    }
}
