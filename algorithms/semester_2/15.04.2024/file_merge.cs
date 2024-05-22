using System;
using System.IO;

class FileMerge
{
    static void Main()
    {
        // Open input and output files
        using (StreamReader f1 = new StreamReader("input1.txt"))
        using (StreamReader f2 = new StreamReader("input2.txt"))
        using (StreamWriter f_out = new StreamWriter("output.txt"))
        {
            // Initialize pointers
            string p1 = f1.ReadLine();
            string p2 = f2.ReadLine();

            // Merge files
            while (p1 != null && p2 != null)
            {
                if (string.Compare(p1, p2) < 0)
                {
                    f_out.WriteLine(p1);
                    p1 = f1.ReadLine();
                }
                else
                {
                    f_out.WriteLine(p2);
                    p2 = f2.ReadLine();
                }
            }

            // Copy remaining elements from non-exhausted file
            while (p1 != null)
            {
                f_out.WriteLine(p1);
                p1 = f1.ReadLine();
            }

            while (p2 != null)
            {
                f_out.WriteLine(p2);
                p2 = f2.ReadLine();
            }
        }
    }
}

