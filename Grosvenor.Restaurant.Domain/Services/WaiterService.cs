using System.Linq;
using Grosvenor.Restaurant.Domain.Builders;
using Grosvenor.Restaurant.Domain.Factories;

namespace Grosvenor.Restaurant.Domain.Services
{
    public class WaiterService
    {
        public string ProcessClientOrder(string clientOrder)
        {
            var clientOrderList = clientOrder.Split(',').Select(x => x.Trim()).ToList();
            
            var menu = MenuFatory.GetMenu(clientOrderList);

            var order = OrderBuilder.CreateOrder(menu, clientOrderList);
            
            return order.Print();
        }
    }
}
