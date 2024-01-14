using System;
using System.Linq;

class Determinant
{
  public static double GetDeterminant(double[,] matrix)
  {
    int size = matrix.GetLength(0);

    if (size == 1)
    {
      return matrix[0, 0];
    }

    double determinant = 0;

    for (int i = 0; i < size; i++)
    {
      double[,] reducedMatrix = ReduceMatrix(matrix, 0, i);
      determinant += Math.Pow(-1, i) * matrix[0, i] * GetDeterminant(reducedMatrix);
    }

    return determinant;
  }

  public static double[,] ReduceMatrix(double[,] matrix, int removedRow, int removedCol)
  {
    int size = matrix.GetLength(0);
    double[,] reducedMatrix = new double[size - 1, size - 1];

    int row = 0;

    for (int i = 0; i < size; i++) {
      if (i == removedRow)
      {
        continue;
      }

      int col = 0;

      for (int j = 0; j < size; j++)
      {
        if (j == removedCol)
        {
          continue;
        }

        reducedMatrix[row, col] = matrix[i, j];
        col++;
      }

      row++;
    }

    return reducedMatrix;
  }

  public static void PrintMatrix(double[,] matrix)
  {
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
      for (int j = 0; j < matrix.GetLength(1); j++)
      {
        Console.Write(matrix[i, j] + "\t");
      }
      Console.WriteLine();
    }
  }

  public static void Main(string[] args)
  {
    Console.WriteLine("Введите порядок матрицы:");
    int order = int.Parse(Console.ReadLine());

    double[,] matrix = new double[order, order];

    Console.WriteLine($"Введите {order} строк, вводя {order} элементов строки через пробел:");
    for (int i = 0; i < order; i++)
    {
      string str = Console.ReadLine();
      double[] row = Array.ConvertAll(str.Split(null), Double.Parse);

      for (int j = 0; j < order; j++)
      {
        matrix[i, j] = row[j];
      }
    }

    Console.WriteLine();
    Console.WriteLine("\nМатрица:");
    PrintMatrix(matrix);

    Console.WriteLine("\nОпределитель:");
    Console.WriteLine(GetDeterminant(matrix));
    
  }
}
