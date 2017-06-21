using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Restaurant.Domain.Entities
{
    public class Menu
    {
        public string Id { get; set; }
        public List<MenuDishes> Dishes { get; set; }
    }
}
