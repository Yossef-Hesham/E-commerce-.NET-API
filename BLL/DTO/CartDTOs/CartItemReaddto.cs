using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class CartItemReaddto
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public decimal Price { get; set; }
        //public Cartdto? Cart { get; set; }
        public int Quantity { get; set; }
    }
}
