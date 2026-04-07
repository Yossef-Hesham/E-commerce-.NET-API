using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class ProductCreateDto
    {
        public required string Name { get; set; }
        public string? Desciption { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
