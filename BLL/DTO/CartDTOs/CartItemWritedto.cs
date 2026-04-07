using DAL.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class CartItemWritedto
    {
        public int Id { get; set; }

        public int productId { get; set; }

        //public int ?CartId { get; set; }
        public int Quantity { get; set; }
    }
}
