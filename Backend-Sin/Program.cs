
#region Delegates 

/*what is delegates ?
    Delegates allow methods to be passed like variables.

Why its exits ?

    Pass behavior (logic) to another method.
    Implement callbacks.
    Event systems depend on delegates.*/
//Real World  EG : 

using System.Runtime.CompilerServices;
using static Program;

public class Program
{
    public delegate void LogHandler(string message);

    public class OrderService
    {
        public void PlaceOrder(string item, LogHandler logger)
        {
            Console.WriteLine("Order placed for " + item);

            logger("Order successfully placed for " + item);
        }
    }
    public class Logger
    {
        public static void LogToConsole(string msg)
        {
            Console.WriteLine("Console Log: " + msg);
        }

        public static void LogToFile(string msg)
        {
            System.IO.File.AppendAllText("log.txt", msg + "\n");
        }
    }


    public static void Mains(string[] args) // I Just Change that name for runs
    {
        OrderService service = new OrderService();

        service.PlaceOrder("Laptop", Logger.LogToConsole);

        service.PlaceOrder("Phone", Logger.LogToFile);
    }
}

#endregion

#region Covariance and Contravariance

public class Animals
{
    public string Name { get; set; }

    public void Eat()
    {
        Console.WriteLine(Name + "is Eating");
    }

}
public class Dog : Animals
{
    public void Bark()
    {
        Console.WriteLine(Name + "is barking");
    }
}

public class Humans
{
    public static void Main(string[] args)
    {
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

// in this Dog list is Covariance it IEnumerable supports covariance (out T)
// in this Action Animals is Contravariance its Assigning to Dog delegate


#endregion