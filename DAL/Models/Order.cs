using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class Order
    {
        public int Id { get; set; }

        public string? Status { get; set; }


        // FK
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public decimal TotalAmount { get; set; }

        public string? ShippingAddress { get; set; }

        public DateTime PlacedAt { get; set; }

    }
}
