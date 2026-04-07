using DAL.Context;
using DAL.Repository.CartRepository;
using DAL.Repository.PlaceOrderRepository;

namespace DAL.system
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepo _ProductRepo { get; }
        public ICategoryRepo _categoryRepo { get; }
        public ICartItemRepo _cartitemRepo { get; }
        public ICartRepo _cartRepo { get; }
        public IPlaceOrderRepo _placeOrderRepo { get; }




        public UnitOfWork(AppDbContext context, IProductRepo productRepo, ICategoryRepo categoryRepo, ICartItemRepo cartitemRepo, ICartRepo cartRepo, IPlaceOrderRepo placeOrderRepo)
        {
            _context = context;
            _ProductRepo = productRepo;
            _categoryRepo = categoryRepo;
            _cartitemRepo = cartitemRepo;
            _cartRepo = cartRepo;
            _placeOrderRepo = placeOrderRepo;
        }

        public async Task SaveChange()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
