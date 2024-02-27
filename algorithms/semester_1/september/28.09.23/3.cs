using System;

// На ввод 10 чисел
// Сумма элементов с одинаковым окончанием
// в 3- и 5-ричной системах счисления
class NumeralSystem {
    public static void Main(string[] args) {
        int sum = 0;

        for (int i = 0; i < 10; i++) {
            int number = Convert.ToInt32(Console.ReadLine());
            if (number % 3 == number % 5) {
                sum += number;
            }
        }

        Console.WriteLine("Сумма: {0}", sum);
    }
}
