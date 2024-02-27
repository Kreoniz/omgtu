using System;

// На ввод 10 чисел
// Вывести количество отрицательных
class Negative {
    public static void Main(string[] args) {
        int count = 0;

        for (int i = 0; i < 10; i++) {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 0) {
                ++count;
            }
        }

        Console.WriteLine("Количество: {0}", count);
    }
}
