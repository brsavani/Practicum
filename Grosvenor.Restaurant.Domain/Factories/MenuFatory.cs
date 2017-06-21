using System;
using System.Collections.Generic;
using System.Linq;
using Grosvenor.Restaurant.Domain.Builders;
using Grosvenor.Restaurant.Domain.Entities;

namespace Grosvenor.Restaurant.Domain.Factories
{
    public static class MenuFatory
    {
        private static List<Menu> _listMenu;
        public static List<Menu> ListMenu => _listMenu ?? (_listMenu = LoadMenus());

        public static Menu GetMenu(List<string> clientOrderList)
        {
            var menu = ListMenu.FirstOrDefault(x => clientOrderList.Contains(x.Id, StringComparer.InvariantCultureIgnoreCase));
            if (menu == null)
                throw new Exception("Invalid period menu.");

            return menu;
        }

        private static List<Menu> LoadMenus()
        {
            return new List<Menu>
            {
                new MenuBuilder("Morning")
                    .AddDishes(DishesType.Entree, "Eggs", 1)
                    .AddDishes(DishesType.Side, "Toast", 1)
                    .AddDishes(DishesType.Drink, "Coffee")
                    .GetResult(),
                new MenuBuilder("Night")
                    .AddDishes(DishesType.Entree, "Steak", 1)
                    .AddDishes(DishesType.Side, "Potato")
                    .AddDishes(DishesType.Drink, "Wine", 1)
                    .AddDishes(DishesType.Desert, "Cake", 1)
                    .GetResult()
            };
        }

    
    }
}
