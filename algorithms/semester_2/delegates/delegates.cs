using System;
using System.Linq;

class Automobile {
  public bool isWashed = false;
  public string brand;

  public Automobile(string brand) {
    this.isWashed = false;
    this.brand = brand;
  }
}

class Garage {
  public Automobile[] automobiles = new Automobile[] {};

  public Garage(Automobile[] autos) {
    this.automobiles = autos;
  }
}

class CarWash {
  public static void Wash(Automobile automobile) {
    automobile.isWashed = true;
  }
}

class Delegates {
  public delegate void CarFunction(Automobile automobile);

  public static void Main(string[] args) {
    CarFunction wash = CarWash.Wash;

    Garage garage = new Garage(new Automobile[] {
        new Automobile("VolksWagen"),
        new Automobile("Toyota"),
        new Automobile("Ford")
      });

    foreach (var auto in garage.automobiles) {
      Console.WriteLine($"{auto.brand}: помыта? {auto.isWashed}");
    }

    Console.WriteLine("\nМоем\n");

    foreach (var auto in garage.automobiles) {
      wash(auto);
    }

    foreach (var auto in garage.automobiles) {
      Console.WriteLine($"{auto.brand}: помыта? {auto.isWashed}");
    }
  }
}