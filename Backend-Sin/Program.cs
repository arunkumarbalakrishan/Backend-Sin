using Backend_Sin;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using static Backend_Sin.Advance;
using static Box;
using static CollectionExample;
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

        static void HandleAnimal(Animals animal)
        {
            Console.WriteLine("Handling animal: " + animal.Name);
        }

        Events events = new Events();
        events.ProcessCompleted += Email;
        events.ProcessCompleted += SMS;

        events.StartProcess();

        static void Email()
        {
            Console.WriteLine("The Email has been Send");
        }
        static void SMS()
        {
            Console.WriteLine("The SMS has been send");
        }

         Box box = new Box();
         box.Method();

            try
            {
                Box.AgeException.ValidateAge(-5);
            }
            catch (AgeException ex)
            {
                Console.WriteLine("Caught: " + ex.Message);
            }
        // This is part of the Extenion method

        string name = "Arun";

        string result = name.ToupperFirst();
       

        Console.WriteLine(result);

       DateTime today = DateTime.Now;
        DataExtensions.IsWeekend(today);

        Console.WriteLine(today.IsWeekend());

        CollectionExample collectionway = new CollectionExample();
        collectionway.Display();
        collectionway.Dictionaryway();
        collectionway.EgHashset();
        collectionway.egStack();

        Empolyee empolyee = new Empolyee();

        empolyee.max();

        Volume v = new Volume();
        v.wax();

        Converstion c = new Converstion();
        MyDelegate del = Converstion.Inbox;
        var x = del(10);
        Console.WriteLine(x);

        MyEvent ec = new MyEvent();
        ec.Process += unneed;
        ec.StartMessage();

        Does d = new Does();
        d.wait();
        d.wait2();

        string value = "Devil";
        Console.WriteLine(value.AddHello());
    }
    public static int  unneed(int value)
    {
        Console.WriteLine("This is an event");
        return value +10
;    }
}
