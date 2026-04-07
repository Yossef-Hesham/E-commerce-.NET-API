using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? Created_at { get; set; }
    }
}
