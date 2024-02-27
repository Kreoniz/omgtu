using System;

// Для N вводимых целых чисел
// Найти наименьший нечетный элемент
class NOdd {
    public static void Main(string[] args) {
        int N = Convert.ToInt32(Console.ReadLine());
        int min = Int32.MaxValue;

        for (int i = 0; i < N; i++) {
            int number = Convert.ToInt32(Console.ReadLine());

            if (number < min && number % 2 != 0) {
                min = number;
            }
        }

        if (min == Int32.MaxValue) {
            Console.WriteLine("Нечетных чисел нет!");
        } else {
            Console.WriteLine("Наименьший нечетный элемент: {0}", min);
        }
    }
}
