using System.Runtime.CompilerServices;
using static Backend_Sin.Advance;
using static Program;

public class Program
{
    public static void Main(string[] args)
    {

        OrderService service = new OrderService();

        service.PlaceOrder("Laptop", Logger.LogToConsole);

        service.PlaceOrder("Phone", Logger.LogToFile);

        List<Dog> dogs = new List<Dog>
        {
            new Dog { Name = "rocky" },
            new Dog { Name = "Lucy" },
            new Dog {Name = "Mario" }
        };

        IEnumerable<Dog> animals = dogs;

        foreach (Animals items in animals)
        {
            Console.WriteLine(items.Name);
            items.Eat();
        }

        Action<Animals> animalHandler = HandleAnimal;

        Action<Dog> dogHandler = animalHandler;

        Dog dog = new Dog { Name = "Bruno" };

        dogHandler(dog);

    }

    static void HandleAnimal(Animals animal)
    {
        Console.WriteLine("Handling animal: " + animal.Name);
    }
}