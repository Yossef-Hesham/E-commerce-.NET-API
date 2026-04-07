using DAL.Context;
using DAL.system;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.PlaceOrderRepository
{
    public class PlaceOrderRepo : GenericRepo<Order>, IPlaceOrderRepo
    {
        public PlaceOrderRepo(AppDbContext context) : base(context)
        {
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(e => e.Id == id);
        }

        


    }
}
