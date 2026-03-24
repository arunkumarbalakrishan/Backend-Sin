using System;
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
// in this Dog list is Covariance it IEnumerable supports covariance (out T)
// in this Action Animals is Contravariance its Assigning to Dog delegate
#endregion

#region Events
public class Events
{
    public delegate void ProcessCompletedHandler();

    public event ProcessCompletedHandler ProcessCompleted;

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
            string input = null;
            int number = int.Parse(input);
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