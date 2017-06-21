using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Restaurant.Domain.Entities
{
    public class OrderRequest
    {
        public DishesType Type { get; set; }
        public int Quantity { get; set; }
    }
}
