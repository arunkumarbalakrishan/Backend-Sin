using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Box;
using static System.Reflection.Metadata.BlobBuilder;

namespace Backend_Sin
{
    #region Delegates 

    /*what is delegates ?
        Delegates allow methods to be passed like variables.

    Why its exits ?

        Pass behavior (logic) to another method.
        Implement callbacks.
        Event systems depend on delegates.*/
    //Real World  EG : 
    public class Advance
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
                    File.AppendAllText("log.txt", msg + "\n");
                }
            }        
     }
  }
#endregion

#region Covariance and Contravariance

public class Animals
{
    public string? Name { get; set; }

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
// in this Dog list is Covariance it IEnumerable supports covariance (out T)
// in this Action Animals is Contravariance its Assigning to Dog delegate
#endregion

#region Events
public class Events
{
    public delegate void ProcessCompletedHandler();

    public event ProcessCompletedHandler? ProcessCompleted;

    public void StartProcess()
    {
        Console.WriteLine("Process Started");

        ProcessCompleted?.Invoke();
    }
}
#endregion
#region 
//Exception Handling
//Exception Handling is a mechanism to gracefully handle runtime errors so that the normal flow of a program isn't disrupted

// eg for exception handling
public class Box
{
    public int Number { get; set; }

    public void Method()
    {
        try
        {
            int a = 10;
            int b = 0;

            int result = a / b;
            Console.WriteLine(result);

        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Cannot divide by zero!");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("This always runs.");
        }

        //Multiple Catch Blocks
        try
        {
            string? input = null;
            //int number = int.Parse(input);
            int number = int.TryParse(input, out int result) ? result : throw new FormatException("Input is not a valid number.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("invailed Message" + ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Input was Null " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("unExcepted Error" + ex.Message);
        }
    }
    // Customer expection Handling
    public class AgeException : Exception
    {     
        public AgeException(string message) : base(message)
        {

        }
 
        public static void ValidateAge(int age)
        {
            if (age < 0 || age > 150)
            {
                throw new AgeException($"Invalid age: {age}");
            }

            Console.WriteLine($"Valid age: {age}");
        }
    }

}

#endregion

#region This is Base for Extension Method

public static class StringExtensions
{
    public  static string ToupperFirst (this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return char.ToUpper(value[0]) + value.Substring(1);
    }
}
#endregion
#region
// other eg for extension method 

public static class DataExtensions
{
    public static bool IsWeekend(this DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday ||
               date.DayOfWeek == DayOfWeek.Sunday;
    }
}



#endregion

#region

public class Collection
{
    //Collections are data structures that store multiple items.
    //they provide various ways to organize, access and manipulate data.
    //Collections can be categorized into several types, including:
    //-----------------------------------------------------------------------------//
    //1. Lists: Ordered collections that allow duplicate elements. Example: List<T>.
    //2. Dictionaries: Collections of key-value pairs, where each key is unique. Example: Dictionary<TKey, TValue>.
    //3. Sets: Collections of unique elements. Example: HashSet<T>.
    //4. Queues: First-in, first-out (FIFO) collections. Example: Queue<T>.
    //5. Stacks: Last-in, first-out (LIFO) collections. Example: Stack<T>.
    //6. Arrays: Fixed-size collections of elements of the same type. Example: T[].
    //Collections provide methods for adding, removing, and accessing elements, as well as iterating through the collection.
    //They are fundamental for managing data in programming and are widely used in various applications.

    public string? Name { get; set; }
    public string? Infomation { get; set; }
    public int Salary { get; set; }

}

public class CollectionExample
{
    //Example of using a List collection
    public void Display()
    {

        List<Collection> collection = new List<Collection>
        {
            new Collection { Name = "Arun", Infomation = "Software Developer", Salary = 50000 },
            new Collection { Name = "Jai", Infomation = "Data Analyst", Salary = 45000 },
            new Collection { Name = "foureyes", Infomation = "Project Manager", Salary = 60000 }
        };
        foreach (var item in collection)
        {
            Console.WriteLine($"Name: {item.Name}, Infomation: {item.Infomation}, Salary: {item.Salary}");
        }
    }

    //Example of using a Dictionary collection

    public void Dictionaryway()
    {
        Dictionary<int, Collection> employeeDictionary = new Dictionary<int, Collection>();
        employeeDictionary.Add(
           1, new Collection
           {
               Name = "Arun",
               Infomation = "Software Developer",
               Salary = 1000
           }
       );
        employeeDictionary.Add(
            2, new Collection
            {
                Name = "jai",
                Infomation = "Data Analyst",
                Salary = 2000
            }
            );
        employeeDictionary.Add(
            3, new Collection
            {
                Name = "foureyes",
                Infomation = "Project Manager",
                Salary = 3000
            }
            );


        foreach (var item in employeeDictionary)
        {
            Console.WriteLine($"key : {item.Key}\n Name : {item.Value.Name} \n Information :{item.Value.Infomation} \n Salary : {item.Value.Salary}");
        }
    }

    //Example for Using Hashset<T>

    public void EgHashset()
    {
        HashSet<int> uniqueNumber = new() { 1, 2, 3, 2, 1 };
        Console.WriteLine(uniqueNumber.Count);

        HashSet<string> frnds = new();
        frnds.Add("arun");
        frnds.Add("jai");
        frnds.Add("Arun");
        frnds.Remove("arun");


        Console.WriteLine(frnds.Count);
    }

    //Example for Using Stack<T>

    public void egStack()
    {
        Stack<int> set = new Stack<int>(new[] { 1, 2, 3, 4, 5 });
        set.Push(6);    // Add an element to the top of the stack
        set.Pop();      // Remove and return the top element (6)
        set.Peek();     // Return the top element without removing it (5)

        foreach (var item in set)
        {
            Console.WriteLine(item);
        }
    }

    // practicing example Code
    public class Empolyee
    {
        public void max()
        {
            int[] list = { 1, 2, 3, };

            IEnumerable collection = list;

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

        }
    }

    public class Volume
    {
        public void wax()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };

            list.Add("arun");
            if (list.Count > 3 )
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            };
            list.Add(4);
            list.Add(11.22);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
    public delegate int MyDelegate(int x);
   
    
    public class Converstion
    {

        public static int Inbox(int x)
        {
            
            return x + 10;   
            
        }
    }

    public class MyEvent
    {
        public event MyDelegate? Process;

        public void StartMessage ()
        {
            if (Process != null)
            {
                int x = Process(5);
                Console.WriteLine("Result: " + x);
            }
        }
    }

    public class Does
    {
        public void Wait()
        {
            try
            {
                List<int> list = new List<int>();
                list.Add(1);
                list.Add(2);
                list.Add(3);
                list.Add(4);
                if (list.Count < 4)
                {
                    list.Reverse();
                }
                else
                {
                    list.Sort();
                }
                //throw new Exception("Manual error"); ==> for testing the catch block

                Console.WriteLine(string.Join(", ", list));
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void Wait2()
        {
            try
            {
                int? store = null;

                if (store.HasValue)
                {
                    Console.WriteLine("Value: " + store.Value);

                }
                else
                {
                    Console.WriteLine("No value assigned.");
                }
            }
            catch
            {
                Console.WriteLine("An error occurred while accessing the nullable variable.");
            }
        }
    }
    
  }
public static class ExtensionMethod
{
    public static string AddHello(this string value)
    {
        return "Hello" + value;
    }
}
#endregion


#region
public class MadMan
{
   public string NameWords { get; set; } =string.Empty;
    public int ValuesWords { get; set; } = 0;

    public string Discrision {  get; set; } = string.Empty;
    public void Methor(string NameWords, int ValuesWords, string Discrision)
    {
        List<MadMan> man = new List<MadMan>();
        man.Add(new MadMan
        {
            NameWords =" Wow its Amazing",
            ValuesWords = 12345,
            Discrision = "take it as far its goes"

        });

        if (MadMan.Equals == man.Chunk)
        {
            Console.WriteLine($"the value is {NameWords}and worth it");

        }
        else
        {
            Console.WriteLine($"the value is {ValuesWords} and Not worth it");
        }

        var Result = man.ToList();
        Console.WriteLine(man.Count);

    }
}


#endregion