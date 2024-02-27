using System;

// Для N вводимых целых чисел
// Кол-во элементов, у которых есть хотя бы одна 3 в записи числа
// ! Не использовать методы строк (только числа)
class Nthirds {
    public static void Main(string[] args) {
        int N = Convert.ToInt32(Console.ReadLine());
        int count = 0;

        for (int i = 0; i < N; i++) {
            int number = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            while (number > 0) {
                if (number % 10 == 3) {
                    ++count;
                    break;
                } else {
                    number = number / 10;
                }
            }
        }

        Console.WriteLine("Чисел с тройкой: {0}", count);
    }
}
