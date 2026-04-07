using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class CartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }


        // FK
        public int CartId { get; set; }
        public Cart? Cart { get; set; }

        // FK
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
