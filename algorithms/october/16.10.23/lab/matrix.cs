using System;
using System.Linq;

// Дан массив размерностью NxM (N - строки, M - столбцы), необходимо:
// 1. Определить кол-во столбцов, в которых сумма элементов отрицательна,
// а произведение положительно
// 2. Определить, во всех ли строках минимальный элемент чётный
// 3. Посчитать кол-во ненулевых элементов в массиве
// 4. Определить в каждом столбце наибольший четный элемент
// 5. Определить кол-во пар строк, состоящих из одинаковых элементов
class Matrix {
    public static int factorial(int n) {
        int ans = 1;

        for (int i = 2; i <= n; i++) {
            ans *= i;
        }

        return ans;
    }

    public static int nchoosek(int n, int k) {
        if (n == 0) {
            return 0;
        }

        return factorial(n) / (factorial(k) * (factorial(n - k)));
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
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[n, m];
        
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int[,] transposed = Transpose(matrix, n, m);
        int cnegative = 0;

        for (int i = 0; i < m; i++) {
            int sum = 0;
            for (int j = 0; j < n; j++) {
                sum += transposed[i, j];
            }

            if (sum < 0) {
                cnegative++;
            }
        }

        bool minIsEven = true;
        for (int i = 0; i < n; i++) {
            int min = Int32.MaxValue;
            for (int j = 0; j < m; j++) {
                if (matrix[i, j] < min) {
                    min = matrix[i, j];
                }
            }
            if (min % 2 != 0) {
                minIsEven = false;
                break;
            }
        }

        int cnotzero = 0; 
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (matrix[i, j] != 0) {
                    cnotzero++;
                }

            }
        }

        int[] greatestEvens = new int[m];
        for (int i = 0; i < m; i++) {
            int maxEven = Int32.MinValue;
            for (int j = 0; j < n; j++) {
                if (transposed[i, j] % 2 == 0 && transposed[i, j] > maxEven) {
                    maxEven  = transposed[i, j];
                }
            }

            greatestEvens[i] = maxEven;
        }

        int[,] rowsInfo = new int[n, 3];
        for (int i = 0; i < n; i++) {
            int sum = 0;
            int product = 1;
            int czeroes = 0;
            for (int j = 0; j < m; j++) {
                sum += matrix[i, j];
                if (matrix[i, j] == 0) {
                    czeroes++;
                }
                product *= matrix[i, j];
            }

            rowsInfo[i, 0] = sum;
            rowsInfo[i, 1] = product;
            rowsInfo[i, 2] = czeroes;
        }

        int[] samerows = new int[n];

        int[] checkedrows = new int[n];

        for (int i = 0; i < n; i++) {
            int count = 0;
            for (int j = 0; j < n; j++) {
                if (i == j || checkedrows[j] == 1) {
                    continue;
                }
                if (rowsInfo[i, 0] == rowsInfo[j, 0] &&
                        rowsInfo[i, 1] == rowsInfo[j, 1] &&
                        rowsInfo[i, 2] == rowsInfo[j, 2]) {
                    count++;
                    checkedrows[i] = 1;
                    checkedrows[j] = 1;
                }
            }
            if (count != 0) {
                samerows[i] = count + 1;
            }
        }


        int csame = 0;
        for (int i = 0; i < n; i++) {
            csame += nchoosek(samerows[i], 2);
        }

        int rlength = -1;
        int clength = -1;
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < m; col++) {
                int nlength = Convert.ToString(matrix[row, col]).Length;
                if (nlength > clength) {
                    clength = nlength;
                }
            }
        }

        for (int row = 0; row < m; row++) {
            for (int col = 0; col < n; col++) {
                int nlength = Convert.ToString(transposed[row, col]).Length;
                if (nlength > rlength) {
                    rlength = nlength;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Матрица:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (j == 0) {
                    Console.Write("[");
                }
                Console.Write($"{Convert.ToString(matrix[i, j]).PadLeft(rlength, ' ')}");
                if (j == m - 1) {
                    Console.Write("]");
                } else {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("");
        }

        Console.WriteLine();
        Console.WriteLine("Транспонированная матрица:");
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (j == 0) {
                    Console.Write("[");
                }
                Console.Write($"{Convert.ToString(transposed[i, j]).PadLeft(clength, ' ')}");
                if (j == n - 1) {
                    Console.Write("]");
                } else {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("");
        }


        Console.WriteLine($"\nКоличество столбцов с отрицательной суммой: {cnegative}\n");

        if (minIsEven) {
            Console.WriteLine("Минимальный элемент каждой строки - четный\n");
        } else {
            Console.WriteLine("Минимальный элемент НЕ каждой строки - четный\n");
        }

        Console.WriteLine($"Количество ненулевых элементов в матрице: {cnotzero}\n");

        Console.WriteLine("Максимальные четные элементы каждого столбца:");
        for (int i = 0; i < m; i++) {
            if (greatestEvens[i] == Int32.MinValue) {
                Console.WriteLine($"{i + 1}:\tЧетных элементов нет");
            } else {
                Console.WriteLine($"{i + 1}:\t{greatestEvens[i]}");
            }
        }
        Console.WriteLine();

        Console.WriteLine($"Количество пар строк, состоящих из одинаковых элементов: {csame}");
    }
}
