using System;

// Машина

class Car {
    public string year;
    public string color;
    public string type;
    public string owner;
    public string healthcheck;
    
    public Car(string Year, string Color, string Type, string Owner, string Healthcheck) {
        year = Year;
        color = Color;
        type = Type;
        owner = Owner;
        healthcheck = Healthcheck;
    }

    public void Info() {
        Console.WriteLine($"A {color} {type} of {year} year. Owned by {owner}, healthchecked in {healthcheck} year.");
    }
}

class Program {
    public static void Main(string[] args) {
         Car[] cars = new Car[4] {
             new Car("1999", "red", "Lada", "Egor", "2018"),
             new Car("2003", "green", "Toyota", "Nikolay", "2020"),
             new Car("1800", "brown", "Horse", "Nikita", "1900"),
             new Car("2011", "green", "Toyota", "Egor", "2016"),
         };

         Console.WriteLine("Введите (1) для выборки по году выпуска, (2) по марке, (3) по году тех осмотра");
         int option = Convert.ToInt32(Console.ReadLine());

         if (option == 1) {
             string year = Console.ReadLine();

             for (int i = 0; i < cars.Length; i++) {
                 if (cars[i].year == year) {
                     cars[i].Info();
                 }
             }

         } else if (option == 2) {
             string type = Console.ReadLine();

             for (int i = 0; i < cars.Length; i++) {
                 if (cars[i].type == type) {
                     cars[i].Info();
                 }
             }

         } else if (option == 3) {
             string healthcheck = Console.ReadLine();

             for (int i = 0; i < cars.Length; i++) {
                 if (cars[i].healthcheck == healthcheck) {
                     cars[i].Info();
                 }
             }

         }
    }
}
