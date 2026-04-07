using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Desciption { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        // FK
        [ForeignKey("CategotyId")]
        public int CategotyId { get; set; }

        public Category? Categoty { get; set; }
    }
}
