using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; } = string.Empty;

        public string? Address { get; set; }
        public string Role { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenTime { get; set; }


        public Cart? Cart{ get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();


    }
}
