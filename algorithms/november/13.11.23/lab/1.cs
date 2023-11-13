using System;
using System.Linq;

// Дан двумерный массив MxN, необходимо:
// 1. Определить в каждой строке максимальный отрицательный элемент
// 2. Определить в каждом столбце кол-во элементов, отличных от минимального
// элемента массива
// 3. Заменить элементы строки с наибольшей суммой четных элементов на
// единички, если таких строк несколько, заменить в каждой строке элементы
class Negative {
    public static void printMatrix(int[, ] matrix) {
        int nrows = matrix.GetLength(0);
        int ncols = matrix.GetLength(1);

        int max_digits = getLongestElement(matrix);

        for (int i = 0; i < nrows; i++) {
            for (int j = 0; j < ncols; j++) {
                if (j == 0) {
                    Console.Write('[');
                }

                Console.Write($"{Convert.ToString(matrix[i, j]).PadLeft(max_digits, ' ')}");

                if (j != ncols - 1) {
                    Console.Write(", ");
                } else {
                    Console.Write(']');
                }

            }

            Console.WriteLine();
        }
    }

    public static int getLongestElement(int[, ] matrix) {
        int nrows = matrix.GetLength(0);
        int ncols = matrix.GetLength(1);

        int length = 0;

        for (int i = 0; i < nrows; i++) {
            for (int j = 0; j < ncols; j++) {
                if (Convert.ToString(matrix[i, j]).Length > length) {
                    length = Convert.ToString(matrix[i, j]).Length;
                }
            }
        }

        return length;
    }

    public static int[, ] populateArray(int m, int n) {
        int[, ] matrix = new int[m, n];

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        return matrix;
    }

    public static int[,] Transpose(int[,]matrix, int rows, int cols) {
        int[,] transposed = new int[cols, rows];
        for (int i = 0; i < cols; i++) {
            for (int j = 0; j < rows; j++) {
                transposed[i, j] = matrix[j, i];
            }
        }

        return transposed;
    }

    public static void Main(string[] args) {
        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        int[, ] matrix = populateArray(m, n);

        int[] evenSums = new int[m];
        for (int i = 0; i < m; i++) {
            evenSums[i] = 0;
        }

        int[] maxNegatives = new int[m];

        int matrixMinValue = Int32.MaxValue;

        for (int i = 0; i < m; i++) {
            int maxRowNegative = 0;

            for (int j = 0; j < n; j++) {
                int value = matrix[i, j];

                if (value % 2 == 0) {
                    evenSums[i] += value;
                }

                if (value < 0 && (value != 0 || value > maxRowNegative)) {
                    maxRowNegative = value;
                }

                if (value < matrixMinValue) {
                    matrixMinValue = value;
                }
            }

            maxNegatives[i] = maxRowNegative;
        }

        int[] colsDiffFromMin = new int[n];
        for (int i = 0; i < n; i++) {
            colsDiffFromMin[i] = 0;
        }

        int[, ] transposed = Transpose(matrix, m, n);

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (transposed[i, j] != matrixMinValue) {
                    colsDiffFromMin[i]++;
                }
            }
        }

        Console.WriteLine("Двумерный массив:");
        printMatrix(matrix);
        Console.WriteLine();
        Console.WriteLine("Транспонированный двумерный массив:");
        printMatrix(transposed);
        Console.WriteLine();

        Console.WriteLine("Максимальный отрицательный элемент каждой строки:");
        for (int i = 0; i < maxNegatives.Length; i++) {
            if (maxNegatives[i] == 0) {
                Console.WriteLine($"{i + 1}: такого элемента нет");
            } else {
                Console.WriteLine($"{i + 1}: {maxNegatives[i]}");
            }
        }

        Console.WriteLine();

        Console.WriteLine("Кол-во элементов каждого столбца, отличных от минимального элемента массива:");
        for (int i = 0; i < colsDiffFromMin.Length; i++) {
            Console.WriteLine($"{i + 1}: {colsDiffFromMin[i]}");
        }

        int maxEvenSum = evenSums.Max();
        int[] maxEvenSumsIndexes = new int[1 + evenSums.Count(x => x == maxEvenSum)];

        int pointer = 0;

        for (int i = 0; i < evenSums.Length; i++) {
            if (evenSums[i] == maxEvenSum) {
                maxEvenSumsIndexes[pointer] = i;
                pointer++;
            }
        }

        int[, ] onesMatrix = matrix.Clone() as int[, ];

        pointer = 0;
        for (int i = 0; i < m; i++) {
            if (maxEvenSumsIndexes[pointer] == i) {
                for (int j = 0; j < n; j++) {
                    onesMatrix[i, j] = 1;
                }
                pointer++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Массив элементы строк с наибольшей суммой четных чисел которого - единички:");
        printMatrix(onesMatrix);
    }
}
