using System;

namespace Primes
{
  class Program
  {
    static void Main()
    {
      int n1 = 106732567;
      int n2 = 152673837;

      for (int i = n1; i < n2; i++)
      {
        bool flag = true;

        if ((Convert.ToInt32(Math.Sqrt(i)) * Convert.ToInt32(Math.Sqrt(i))) != i)
        {
          continue;
        }

        int count_divs = 0;
        int max_div = 0;

        for (int j = 2; j < (Math.Sqrt(i) - 1); j++)
        {
          if (i % j == 0)
          {
            count_divs += 2;
            max_div = i / j;
          }

          if (count_divs > 2)
          {
            flag = false;
            break;
          }
        }

        if (flag && count_divs == 2)
        {
          Console.WriteLine($"{i} {max_div}");
        }
      }
    }
  }
}
