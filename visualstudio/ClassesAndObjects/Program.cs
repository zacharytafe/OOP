using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{

    class Dog
    {
        public string name;
        public int size;
        public string breed;
        public ConsoleColor color;

        public void Walk()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is walking.");
        }
        public void Eat(string food)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is eating " + food);
        }
        public void Shit()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is shitting.");
        }
        public void Sleep()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + "is sleeping.");
        }
        public void Wag()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + "is wagging it's tail");
        }
        public void Speak()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " say: Woof!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Create instance of dog
            Dog dog1 = new Dog();
            dog1.name = "Matt";
            dog1.size = 5;
            dog1.breed = "Cavoodle";
            dog1.color = ConsoleColor.Blue;

            Dog dog2 = new Dog();
            dog2.name = "Fido";
            dog2.size = 5;
            dog2.color = ConsoleColor.Red;

            // Call methods on dog
            dog1.Walk();
            dog2.Walk();

            dog1.Speak();
            dog1.Eat("Meat");
            dog1.Shit();
            dog2.Shit();


            Console.ReadLine();
        }
    }
}
