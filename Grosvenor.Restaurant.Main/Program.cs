using System;
using Grosvenor.Restaurant.Domain.Services;

namespace Grosvenor.Restaurant.Main
{
    class Program
    {
        private static WaiterService _waiterService;

        static void Main(string[] args)
        {
            _waiterService = new WaiterService();
            RequestClientOrder(); 
        }
         
        public static void RequestClientOrder()
        {
            try
            {
                Console.WriteLine("Inform your order or write 'exit' to finish.");
                var clientOrder = Console.ReadLine();
                if (!string.IsNullOrEmpty(clientOrder) && clientOrder.Trim().Equals("exit", StringComparison.InvariantCulture))
                    return;

                Console.Clear();
                Console.WriteLine(clientOrder);
                Console.WriteLine(_waiterService.ProcessClientOrder(clientOrder));

                RequestClientOrder();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(e.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                RequestClientOrder();
            }
        }
    }
}
