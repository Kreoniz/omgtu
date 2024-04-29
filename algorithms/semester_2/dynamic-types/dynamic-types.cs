using System;
using System.Linq;

public class A<T> {
  public T a {get; set;}
  public T b {get; set;}

  public A(T a, T b) {
    this.a = a;
    this.b = b;
  }

  public T GetSum() {
    dynamic a_1 = a;
    dynamic b_1 = b;
    return a_1 + b_1;
  }

  public T GetDifference() {
    dynamic a_1 = a;
    dynamic b_1 = b;
    return a_1 - b_1;
  }

  public T GetProduct() {
    dynamic a_1 = a;
    dynamic b_1 = b;
    return a_1 * b_1;
  }

  public T GetQuotient() {
    dynamic a_1 = a;
    dynamic b_1 = b;
    return a_1 / b_1;
  }
}

class DynamicTypes {
  public static void Main(string[] args) {
    A<int> aint1 = new A<int>(3, 5);
    int intSum = aint1.GetSum();
    Console.WriteLine(intSum);

    A<double> adouble1 = new A<double>(2.34, 5.67);
    double doubleSum = adouble1.GetSum();
    Console.WriteLine(doubleSum);

    A<int> aint2 = new A<int>(3, 5);
    int intDifference = aint2.GetDifference();
    Console.WriteLine(intDifference);

    A<double> adouble2 = new A<double>(2.34, 5.67);
    double doubleDifference = adouble2.GetDifference();
    Console.WriteLine(doubleDifference);

    A<int> aint3 = new A<int>(3, 5);
    int intProduct = aint3.GetProduct();
    Console.WriteLine(intProduct);

    A<double> adouble3 = new A<double>(2.34, 5.67);
    double doubleProduct = adouble3.GetProduct();
    Console.WriteLine(doubleProduct);

    A<int> aint4 = new A<int>(3, 5);
    int intQuotient = aint4.GetQuotient();
    Console.WriteLine(intQuotient);

    A<double> adouble4 = new A<double>(2.34, 5.67);
    double doubleQuotient = adouble4.GetQuotient();
    Console.WriteLine(doubleQuotient);
  }
}
