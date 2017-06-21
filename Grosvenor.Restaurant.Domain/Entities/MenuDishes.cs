using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Restaurant.Domain.Entities
{
    public class MenuDishes
    {
        public DishesType Type { get; set; }
        public bool HasLimit { get; set; }
        public int Limit { get; set; }
        public string Description { get; set; }
    }
}
