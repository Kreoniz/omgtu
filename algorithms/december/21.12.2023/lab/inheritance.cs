using System;

class Inheritance {
    class Pet
    {
        public string Name;
        public string BirthDate;
        
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
    
    class Dog : Pet
    {
        public string Breed;
        public string Color;
        
        public Dog(string name, string birthDate, string breed, string color) : base(name, birthDate)
        {
            Breed = breed;
            Color = color;  
        }
    }
    
    class Cat : Pet
    {
        public string Breed;
        public string Color;
        
        public Cat(string name, string birthDate, string breed, string color) : base(name, birthDate)
        {
            Breed = breed;
            Color = color;  
        }
        
        public void ChangeBreed(string newBreed)
        {
            Breed = newBreed;
        }
    }
    
    static void Main()
    {
        Dog[] dogArray = new Dog[5] {
            new Dog("Bobik", "2023", "Haski", "white"),
            new Dog("Rich", "2009", "Kolli", "white&black"),
            new Dog("Bob", "2016", "Labrador Retriever", "red"),
            new Dog("Jack", "2020", "Boxer", "blue"),
            new Dog("Carl", "2021", "Poodle", "green"),
        };
        
        Cat[] catArray = new Cat[5] {
            new Cat("Murzik", "2010", "Siamese cat", "grey"),
            new Cat("Ryzhik", "2023", "Siberian", "white&black"),
            new Cat("Lucy", "2020", "Bobtail", "white&black"),
            new Cat("Musya", "2001", "Ragdoll", "white&black"),
            new Cat("Mercel", "2005", "Black cat", "white"),
        };
        
        Cat randomCat = catArray[1];
        
        Console.WriteLine("{0} {1}", randomCat.Name, randomCat.Breed);
        randomCat.ChangeBreed("Word");
        Console.WriteLine("{0} {1}", randomCat.Name, randomCat.Breed);
        
        Console.WriteLine("Введите породу искомой собаки:");
        string dogBreed = Console.ReadLine();
        
        for (int i = 0; i < dogArray.Length; i++) {
            Dog dog = dogArray[i];
            if (dog.Breed == dogBreed)
            {
                Console.WriteLine(dog.Name);

            }
        }
        
        Console.WriteLine();
        
        Console.WriteLine("Введите окрас искомой кошки:");
        string catColor = Console.ReadLine();

        for (int i = 0; i < catArray.Length; i++) {
            Cat cat = catArray[i];
            if (cat.Color == catColor)
            {
                Console.WriteLine(cat.Name);

            }
        }
        
    }
}
