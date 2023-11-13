using System;

// На ввод 10 чисел
// Вывести произведение неотрицательных четных элементов
class Product {
    public static void Main(string[] args) {
        int product = 1;

        for (int i = 0; i < 10; i++) {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number >= 0 && number % 2 == 0) {
                product *= number;
            }
        }

        Console.WriteLine("Произведение: {0}", product);
    }
}
