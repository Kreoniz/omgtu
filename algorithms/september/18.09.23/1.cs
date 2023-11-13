using System;

// Две переменные меняются своими значениями
// ! Нельзя использовать третью переменную
class NumberFlip {
    public static void Main(string[] args) {
        int a, b;
        a = Convert.ToInt32(Console.ReadLine());
        b = Convert.ToInt32(Console.ReadLine());

        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine(Convert.ToString(a));
        Console.WriteLine(Convert.ToString(b));
    }
}
