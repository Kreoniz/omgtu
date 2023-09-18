using System;

// Выводит минимальное и максимальное числа
// ! Можно использовать только арифмитические операции и модуль
class MinAndMax {
    public static void Main(string[] args) {
        int a, b;
        
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());

        int min, max;

        min = (a - Math.Abs(a - b) + b) / 2;
        max = (a + Math.Abs(a - b) + b) / 2;

        Console.WriteLine("{0}\n{1}", min, max);
    }
}
