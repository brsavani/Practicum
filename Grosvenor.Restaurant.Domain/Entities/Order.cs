using System.Collections.Generic;
using System.Linq;

namespace Grosvenor.Restaurant.Domain.Entities
{
    public class Order
    {
        public List<OrderRequest> Request { get; set; }
        public Menu Menu { get; set; }
        public bool HasError { get; set; }

        public string Print()
        {
            var lst = new List<string>();
            foreach (var dish in Menu.Dishes)
            {
                var request = Request.FirstOrDefault(x => x.Type == dish.Type && x.Quantity > 0);
                if (request == null) continue;

                var printText = dish.Description;
                lst.Add(request.Quantity > 1 ? $"{printText}(x{request.Quantity})" : printText);
            }

            if (this.HasError)
                lst.Add("error");
            
            return string.Join(", ", lst);
        }
        
    }
}
