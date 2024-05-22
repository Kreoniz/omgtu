using System;
using System.Linq;

class Program
{
    static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number != 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static void Main()
    {
        int[] array = {
            123,
            456,
            789,
            111,
            222,
            333,
            444,
            555,
            666,
            777,
            888,
            999,
            23932,
            222233,
        };

        var result1 = array.Where(x => x % 10 % 3 == 0);
        var result2 = array.Where(x => SumOfDigits(x) % 2 == 0);

        Console.WriteLine("Элементы, у которых последняя цифра кратна трем:");
        foreach (var item in result1)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        Console.WriteLine("Элементы, у которых сумма цифр кратна двум:");
        foreach (var item in result2)
        {
            Console.WriteLine(item);
        }
    }
}
