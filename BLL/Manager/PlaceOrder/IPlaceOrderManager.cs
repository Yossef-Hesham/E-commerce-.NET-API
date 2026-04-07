using System.Collections;


namespace BLL.System
{
    public interface IPlaceOrderManager
    {
        Task PlaceOrder();
        Task<IEnumerable<PlaceOrderdto>> GetOrdersAsync();

        Task<PlaceOrderdto> GetOrderByIdAsync(int id);
    }
}
