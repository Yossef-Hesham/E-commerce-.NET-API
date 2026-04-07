using BLL.System;
using DAL.system;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemManager _cartItemManager;

        public CartItemController(ICartItemManager cartItemManager)
        {
            _cartItemManager = cartItemManager;
        }

        [HttpGet("CartItems")]
        [Authorize]
        public async Task<IEnumerable<CartItemReaddto>> GetCartItems()
        {
            return await _cartItemManager.GetCartItems();   
        }

        [HttpDelete("delete/{id:int}")]
        [Authorize]
        public async Task DeleteCartItem(int id)
        {
             await _cartItemManager.DeleteCartItem(id);
        }

        [HttpPost("Add")]
        [Authorize]
        public async Task AddProductTocart(CartItemWritedto cartItemdto)
        {
            await _cartItemManager.AddItemToCart(cartItemdto);
        }

        [HttpPut("update/{id:int}/{quantity:int}")]
        [Authorize]
        public async Task UpdateCartitem(int id, int quantity)
        {
            await _cartItemManager.UpdateCartItem(id, quantity);
        }
    }
}
