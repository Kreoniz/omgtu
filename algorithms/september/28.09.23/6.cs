using System;

// На ввод N чисел
// Вывести количество элементов, меньших чем все предыдущие
class LessThanAllPrevious {
    public static void Main(string[] args) {
        int count = 0;
        int min_num = int.MaxValue;

        Console.WriteLine("Введите N:");
        int N = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nВведите N чисел:");

        for (int i = 0; i < N; i++) {
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < min_num) ++count;

            if (number < min_num) {
                min_num = number;
            }
        }

        Console.WriteLine("Количество: {0}", count - 1);
    }
}
