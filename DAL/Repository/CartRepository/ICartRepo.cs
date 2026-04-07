using DAL.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CartRepository
{
    public interface ICartRepo : IGenericRepo<Cart>
    {
        Task<Cart> CartIsFound(Guid UserId);
    }
}
