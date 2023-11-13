using System;

// На ввод N чисел
// Количество смены знаков в последовательности
class NAME {
    public static void Main(string[] args) {
        int count = 0;
        bool previous_is_positive = false;
        bool previous_is_defined = false;

        Console.WriteLine("Введите N:");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nВведите N чисел:");

        for (int i = 0; i < N; i++) {
            int number = Convert.ToInt32(Console.ReadLine());

            if (!previous_is_defined) {
                previous_is_defined = true;
            } else {
                if (previous_is_positive ^ number >= 0) ++count;
            }

            previous_is_positive = number >= 0;

        }

        Console.WriteLine("Количество: {0}", count);
    }
}
