using System;
using System.IO;
using System.Linq;

class Program
{
    static int GetMinCount(string line)
    {
        int count = 0;
        int min_count = int.MaxValue;
        foreach (char c in line)
        {
            if (c == 'а')
            {
                count++;
            }
            else
            {
                if (count > 0 && count < min_count)
                {
                    min_count = count;
                }
                count = 0;
            }
        }
        return min_count;
    }

    static void Main()
    {
        using (StreamReader f = new StreamReader("input.txt"))
        {
            int min_len = int.MaxValue;
            string min_str = "";

            string line;
            int min_count = int.MaxValue;
            while ((line = f.ReadLine()) != null)
            {
                int count = GetMinCount(line);

                if (count > 0 && count < min_count)
                {
                    min_count = count;
                }

                if (min_count > 0 && min_count < min_len)
                {
                    min_len = min_count;
                    min_str = line;
                }
            }
            Console.WriteLine(min_str);
        }
    }
}
