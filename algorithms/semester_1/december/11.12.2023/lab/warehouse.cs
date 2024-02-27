using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse {
  class Product {
    public string[] ProductInfo = new string[4];
    public string[] SellInfo = new string[2];
    public string ProductName;
    public string Expiration;
    public Product(string[] productInfo, string[] sellInfo, string productName, string expiration) {
      this.ProductInfo = productInfo;
      this.SellInfo = sellInfo;
      this.ProductName = productName;
      this.Expiration = expiration;
    }

    public int getRemainder() {
      return Convert.ToInt32(this.ProductInfo[2]) - Convert.ToInt32(this.SellInfo[1]);
    }

    public double getIncome() {
      return Convert.ToDouble(this.SellInfo[1]) * Convert.ToDouble(this.ProductInfo[3]);
    }

  }

  class Program {
    static void Main(string[] args) {
      Product[] Warehouse = new Product[3] {
          new Product(new string[4] {"10.04", "09.04", "20", "100" }, new string[2] { "11.04", "10" }, "Зубная щетка", "Бессрочно"),
          new Product(new string[4] { "10.06", "09.06", "1000", "50" }, new string[2] { "12.06", "100" }, "Яблоко", "10.07"),
          new Product(new string[4] { "02.05", "01.05", "500", "80" }, new string[2] { "03.05", "255" }, "Молоко", "05.05"),
      };

      Console.WriteLine("Введите текущую дату:");
      string currentDate = Console.ReadLine();
      Console.WriteLine("Остатки годного товара:");
      for (int i = 0; i < Warehouse.Length; i += 1) {
        Product product = Warehouse[i];
        if (String.Compare(currentDate, Warehouse[i].Expiration) == -1) {
          Console.WriteLine("Cрок годности {0} в количестве {1} штук истекает {2}", product.ProductName, product.getRemainder(), product.Expiration);
        }
      }

      Console.WriteLine();
      Console.WriteLine("Остатки товара на списание:");
      for (int i = 0; i < Warehouse.Length; i += 1) {
        Product product = Warehouse[i];
        if (String.Compare(currentDate, Warehouse[i].Expiration) == 1) {
          Console.WriteLine("Cрок годности {0} в количестве {1} штук истек {2}", product.ProductName, product.getRemainder(), product.Expiration);
        }
      }

      Console.WriteLine();
      Console.WriteLine("Товары:");
      for (int i = 0; i < Warehouse.Length; i += 1) {
        Product product = Warehouse[i];
        Console.WriteLine("Продано {0} '{1}' стоимостью в {2}", product.SellInfo[1], product.ProductName, product.getIncome());
      }

      Console.WriteLine();
    }
  }
}
