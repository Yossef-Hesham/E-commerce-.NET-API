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
    public class CartItemRepo : GenericRepo<CartItem>, ICartItemRepo
    {
        public CartItemRepo(AppDbContext context) : base(context)
        {
        }

        
        // Get cart items by cart id
        public async Task<IEnumerable<CartItem>> GetCartItemsByUserId(Guid ?Userid)
        {
            return await _context.CartItems.Include(e => e.Product).Where(e => e.Cart.UserId == Userid).ToListAsync();
        }

        

        Task<IEnumerable<CartItem>> IGenericRepo<CartItem>.GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> GetCartItemById(int id)
        {
            var cartitem =  await _context.CartItems.Include(e => e.Product).FirstOrDefaultAsync(e => e.Id == id);

            if(cartitem is null)
                throw new Exception("Invalid Cartitem id.");

            return cartitem;
        }

        public async Task Delete(int id)
        {
            var cartitem = await _context.CartItems.Include(e => e.Product).FirstOrDefaultAsync(e => e.Id == id);

            if (cartitem is null)
                throw new Exception("Invalid Cartitem id.");

            _context.Remove(cartitem);
        }

        public async Task<CartItem> Update(int id)
        {
            var cartitem = await _context.CartItems.Include(e => e.Product).FirstOrDefaultAsync(e => e.Id == id);
            if (cartitem is null)
                throw new Exception("Invalid Cartitem id.");

            return cartitem;
        }
    }
}
