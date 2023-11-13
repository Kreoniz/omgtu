using System;

// Для N вводимых целых чисел
// Кол-во элементов, у которых окончания в
// 3-, 5- и 7-миричных системах одинаково
class NNumberSystems {
    public static void Main(string[] args) {
        int N = Convert.ToInt32(Console.ReadLine());
        int count = 0;

        for (int i = 0; i < N; i++) {
            int number = Convert.ToInt32(Console.ReadLine());

            if (number % 3 == number % 5 && number % 5 == number % 7) {
                ++count;
            }
        }

        Console.WriteLine("Таких чисел: {0}", count);
    }
}
