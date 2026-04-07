using DAL.system;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class CartItemManager : ICartItemManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthManager _authmanger;


        public CartItemManager(IUnitOfWork unitOfWork, IAuthManager Authmanger)
        {
            _unitOfWork = unitOfWork;
            _authmanger = Authmanger;

        }

        public async Task<Cart> CartFoundOrCreate()
        {
            // 1. Get user id safely
            var userId = _authmanger.GetUserId();

            if (userId == Guid.Empty)
                throw new UnauthorizedAccessException("User is not authenticated.");

            // 2. Check repo availability (important safety check)
            if (_unitOfWork?._cartRepo == null)
                throw new Exception("Cart repository is not initialized.");

            // 3. Try to find existing cart
            var cart = await _unitOfWork._cartRepo.CartIsFound(userId);

            // 4. If exists → return immediately
            if (cart != null)
                return cart;

            // 5. Create new cart
            cart = new Cart
            {
                UserId = userId,
                Created_at = DateTime.UtcNow
            };

            await _unitOfWork._cartRepo.Add(cart);
            await _unitOfWork.SaveChange();

            return cart;
        }

        public async Task AddItemToCart(CartItemWritedto cartItemDto)
        {
            // 1. Validate input
            if (cartItemDto == null)
                throw new ArgumentNullException(nameof(cartItemDto));

            if (cartItemDto.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0.");

            if (cartItemDto.productId == null)
                throw new Exception("Invalid product id.");

            // 2. Get or create cart
            var cart = await CartFoundOrCreate();

            if (cart == null)
                throw new Exception("Cart could not be created or found.");

            // 3. Create cart item
            var cartItem = new CartItem
            {
                ProductId = cartItemDto.productId,
                Quantity = cartItemDto.Quantity,
                CartId = cart.Id
            };

            // 4. Save
            await _unitOfWork._cartitemRepo.Add(cartItem);
            await _unitOfWork.SaveChange();
        }

        public async Task<IEnumerable<CartItemReaddto>> GetCartItems()
        {
            var userid = _authmanger.GetUserId();

            var cartitems =  await _unitOfWork._cartitemRepo.GetCartItemsByUserId(userid);

            var cartitemsdto = cartitems.Select(e => new CartItemReaddto { 
                Id= e.Id,
                ProductName = e.Product.Name,
                Quantity = e.Quantity,
                Price = e.Product.Price
            
            });
            return cartitemsdto;
        }
        public async Task DeleteCartItem(int id) 
        {
           await  _unitOfWork._cartitemRepo.Delete(id);
           await _unitOfWork.SaveChange();
        }

        public async Task UpdateCartItem(int id, int Quantity)
        {
           var cartitem =  await _unitOfWork._cartitemRepo.Update(id);

            cartitem.Quantity = Quantity;
            await  _unitOfWork.SaveChange();
        }



    }
}
