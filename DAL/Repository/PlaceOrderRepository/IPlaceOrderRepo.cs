using DAL.system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.PlaceOrderRepository
{
    public interface IPlaceOrderRepo : IGenericRepo<Order>
    {
        Task<Order> GetOrderById(int id);
    }


}
