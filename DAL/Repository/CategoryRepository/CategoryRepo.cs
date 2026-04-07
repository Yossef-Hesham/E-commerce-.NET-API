using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.system
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetCategorybyId(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(e => e.Id == id);

        }
    }
}
