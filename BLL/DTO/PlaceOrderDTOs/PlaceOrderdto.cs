using DAL.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class PlaceOrderdto
    {
        public int Id { get; set; }

        public string? Status { get; set; }

        // FK
        //public Guid UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? ShippingAddress { get; set; }

        public DateTime PlacedAt { get; set; }
    }
}
