using System;

// Количество городов K
// Каждый (кроме первого = 0) город находится на расстоянии M от начала
// Число N - минимальное расстояние от ближайших городов до заправки
// Вывести минимально возможную сумму расстояний от всех городов до заправки
class GasStation {
    public static void Main(string[] args) {
        int k = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        int[] cities = new int[k];
        int minSum = Int32.MaxValue;
        int minPos = 0;

        for (int i = 0; i < k; i++) {
            cities[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int i = 0; i < k - 1; i++) {
            for (int j = cities[i] + n; j < cities[i + 1] - n + 1; j++) {
                int sum = 0;
                for (int w = 0; w < k; w++) {
                    sum += Math.Abs(cities[w] - j);
                }
                if (sum < minSum) {
                    minSum = sum;
                    minPos = j;
                }
            }
        }

        if (minSum == Int32.MaxValue) {
            Console.WriteLine("Заправку поставить между городами нельзя");
        } else {
            Console.WriteLine($"Минимально возможная сумма путей: {minSum}");
            Console.WriteLine($"Координаты: {minPos}");
        }
    }
}
