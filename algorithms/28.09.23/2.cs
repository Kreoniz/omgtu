using System;

// На ввод 10 чисел
// Вывести количество чисел, которые оканчиваются на 3
class Triplets {
    public static void Main(string[] args) {
        int count = 0;

        for (int i = 0; i < 10; i++) {
            string number = Console.ReadLine();
            if (number[number.Length - 1] == '3') {
                ++count;
            }
        }

        Console.WriteLine("Количество: {0}", count);
    }
}
