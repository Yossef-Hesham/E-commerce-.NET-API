using DAL.Context;
using DAL.system;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CartRepository
{
    public class CartRepo : GenericRepo<Cart>, ICartRepo
    {
        public CartRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Cart> CartIsFound(Guid UserId)
        {
           return  await _context.Carts.FirstOrDefaultAsync(e => e.UserId == UserId);
        }


    }
}
