using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication61 {
    class Car {
        public string Name;
        public int Year;
        public string[] Owners;
        public int[] Healthcheckyears;
        public string Color;
        public int Engnum;

        public Car(string name, int year, string[] owners, int[] healthcheckyears, string color, int engnum) {
            this.Name = name;
            this.Year = year;
            this.Owners = owners;
            this.Healthcheckyears = healthcheckyears;
            this.Color = color;
            this.Engnum = engnum;

        }
    }

    class Program {

        static void Main(string[] args) {
            Car[] CarArray = new Car[5] {
                new Car("mazda", 1999, new string[] {
                        "Pavel",
                        "Hannah"
                        }, new int[] {
                        2000,
                        2001
                        }, "green", 1),
                    new Car("toyota", 1999, new string[] {
                            "Bob",
                            "Lucy",
                            "Robert"
                            }, new int[] {
                            1999,
                            2001,
                            2002
                            }, "red", 2),
                    new Car("porshe", 2009, new string[] {
                            "Emy"
                            }, new int[] {
                            2014
                            }, "black", 3),
                    new Car("honda", 2015, new string[] {
                            "Kim",
                            "Hannah"
                            }, new int[] {
                            2015,
                            2017
                            }, "yellow", 4),
                    new Car("bmw", 1983, new string[] {
                            "Alex"
                            }, new int[] {
                            2005
                            }, "pink", 5),
            };

            Console.WriteLine("Введите номер двигателя:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Владельцы машины:");

            for (int i = 0; i < CarArray.Length; i++) {
                if (CarArray[i].Engnum == number) {
                    for (int j = 0; j < CarArray[i].Owners.Length; j++) {
                        Console.WriteLine(CarArray[i].Owners[j]);
                    }
                }

            }

            Console.WriteLine();

            Console.WriteLine("Введите год тех. осмотра:");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Машины:");
            for (int i = 0; i < CarArray.Length; i++) {
                for (int j = 0; j < CarArray[i].Healthcheckyears.Length; j++) {
                    if (CarArray[i].Healthcheckyears[j] == year) {
                        Console.WriteLine(CarArray[i].Name);
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine("Машины с одним владельцем:");
            for (int i = 0; i < CarArray.Length; i++) {
                if (CarArray[i].Owners.Length == 1) {
                    Console.WriteLine(CarArray[i].Name);
                }
            }

        }
    }
}
