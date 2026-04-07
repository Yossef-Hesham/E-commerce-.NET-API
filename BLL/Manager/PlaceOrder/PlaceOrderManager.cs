using DAL.system;
using System.Collections;

namespace BLL.System
{
    public class PlaceOrderManager : IPlaceOrderManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authmanger;


        public PlaceOrderManager(IUnitOfWork unitOfWork, IAuthManager Authmanger)
        {
            _unitOfWork = unitOfWork;
            _authmanger = Authmanger;

        }

        public async Task PlaceOrder()
        {
            var userid = _authmanger.GetUserId();
            var cartitems = await _unitOfWork._cartitemRepo.GetCartItemsByUserId(userid);
            decimal total = 0;

            foreach (var item in cartitems)
            {
                total += item.Quantity * item.Product.Price;
            }


            var order = new Order
            {
                UserId = userid,
                TotalAmount = total,
                Status = "pending",
                ShippingAddress = "Default Address",
                PlacedAt = DateTime.UtcNow
            };
            await _unitOfWork._placeOrderRepo.Add(order);
            await _unitOfWork.SaveChange();
        }


        public async Task<IEnumerable<PlaceOrderdto>> GetOrdersAsync()
        {
            var items= await _unitOfWork._placeOrderRepo.GetAll();

            var itemsdto = items.Select(e => new PlaceOrderdto
            {
                Id=e.Id,
                Status = e.Status,
                TotalAmount=e.TotalAmount,
                ShippingAddress = e.ShippingAddress,
                PlacedAt = e.PlacedAt
            });
            return itemsdto;
        }

        public async Task<PlaceOrderdto> GetOrderByIdAsync(int id)
        {
            var e = await _unitOfWork._placeOrderRepo.GetOrderById(id);

            var orderitemdto = new PlaceOrderdto
            {
                Id = e.Id,
                Status = e.Status,
                TotalAmount = e.TotalAmount,
                ShippingAddress=e.ShippingAddress,
                PlacedAt = e.PlacedAt

            };

            return orderitemdto;
        }

    }
}
