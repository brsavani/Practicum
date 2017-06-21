using System;
using System.Collections.Generic;
using System.Linq;
using Grosvenor.Restaurant.Domain.Entities;

namespace Grosvenor.Restaurant.Domain.Builders
{
    public class MenuBuilder
    {
        public MenuBuilder(string id)
        {
            Menu = new Menu
            {
                Id = id,
                Dishes = new List<MenuDishes>()
            };
        }
        private Menu Menu { get; }
        
        public MenuBuilder AddDishes(DishesType type, string description, int limit = 0)
        {
            if (Menu.Dishes.Any(x=>x.Type==type))
                throw new Exception($"Menu type '{type}' already exists.");

            Menu.Dishes.Add(new MenuDishes
            {
                Description = description,
                Type = type,
                HasLimit = limit > 0,
                Limit = limit
            });

            return this;
        }

        public Menu GetResult()
        {
            return Menu;
        }
    }

    

   

    


}
