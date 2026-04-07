using DAL.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CartRepository
{
    public interface ICartItemRepo : IGenericRepo<CartItem> 
    {
        Task<IEnumerable<CartItem>> GetCartItemsByUserId(Guid ?userid);
        Task<CartItem> GetCartItemById(int id);

        Task Delete(int id);
        Task<CartItem> Update(int id);
    }
}
