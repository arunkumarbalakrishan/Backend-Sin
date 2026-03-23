
#region Delegates 

/*what is delegates ?
    Delegates allow methods to be passed like variables.

Why its exits ?

    Pass behavior (logic) to another method.
    Implement callbacks.
    Event systems depend on delegates.*/
//Real World  EG : 

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


    public static void Main(string[] args)
    {
        OrderService service = new OrderService();

        service.PlaceOrder("Laptop", Logger.LogToConsole);

        service.PlaceOrder("Phone", Logger.LogToFile);
    }
}

#endregion