using System;

// На ввод N чисел
// Вывести количество элементов, меньших чем предыдущее
class LessThanPrevious {
    public static void Main(string[] args) {
        int count = 0;
        int previous = 0;
        bool previous_is_declared = false;

        Console.WriteLine("Введите N:");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nВведите N чисел:");
        for (int i = 0; i < N; i++) {
            int number = Convert.ToInt32(Console.ReadLine());

            if (!previous_is_declared) {
                previous_is_declared = true;
            } 

            if (number < previous) ++count;

            if (previous_is_declared) {
                previous = number;
            }
        }

        Console.WriteLine("Количество: {0}", count);
    }
}
