
using DAL.Context;
using DAL.Repository.CartRepository;
using DAL.Repository.PlaceOrderRepository;

namespace DAL.system
{
    public interface IUnitOfWork
    {

        public IProductRepo _ProductRepo { get; }
        public ICategoryRepo _categoryRepo { get; }
        public ICartItemRepo _cartitemRepo { get; }
        public ICartRepo _cartRepo { get; }
        public IPlaceOrderRepo _placeOrderRepo { get; }

        Task SaveChange();
    }
}
