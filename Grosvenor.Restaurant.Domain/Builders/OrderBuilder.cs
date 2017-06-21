using System;
using System.Collections.Generic;
using System.Linq;
using Grosvenor.Restaurant.Domain.Entities;

namespace Grosvenor.Restaurant.Domain.Builders
{
    public static class OrderBuilder
    {
        public static Order CreateOrder(Menu menu, List<string> clientRequestList)
        {
            var order = new Order { Menu = menu, Request = new List<OrderRequest>() };
            
            //Remove the menu id
            clientRequestList.Remove(clientRequestList.Find(menuid => menuid.Equals(menu.Id, StringComparison.InvariantCultureIgnoreCase)));

            if (clientRequestList.All(request => string.IsNullOrEmpty(request.Trim())))
                throw new Exception("There is no order itens.");

            clientRequestList
                .GroupBy(g => g)
                .ToList()
                .ForEach(request =>
                {
                    int value;
                    if (int.TryParse(request.Key, out value) && Enum.IsDefined(typeof(DishesType), value))
                    {
                        var dishType = (DishesType) Convert.ToInt16(request.Key);
                        var menuDish = menu.Dishes.FirstOrDefault(dish => dish.Type == dishType);

                        if (menuDish != null && (!menuDish.HasLimit || request.Count() <= menuDish.Limit))
                        {
                            order.Request.Add(new OrderRequest
                            {
                                Quantity = request.Count(),
                                Type = dishType
                            });
                        }
                        else
                            order.HasError = true; //menu doesn't have the requested dish, or the dish type was exceeded 
                    }
                    else
                        order.HasError = true; //invalid entry
                });

            return order;
        }
    }
}
