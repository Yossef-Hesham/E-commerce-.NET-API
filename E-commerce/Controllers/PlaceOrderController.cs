using BLL.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOrderController : ControllerBase
    {
        private readonly IPlaceOrderManager _placeOrderManager;

        public PlaceOrderController(IPlaceOrderManager placeOrderManager)
        {
            _placeOrderManager = placeOrderManager;
        }

        [HttpPost("Add")]
        [Authorize]
        public async Task PlaceOrder()
        {
            await _placeOrderManager.PlaceOrder();
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<PlaceOrderdto>> GetOrders()
        {
           return await _placeOrderManager.GetOrdersAsync();
        }
        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<PlaceOrderdto> GetOrder(int id)
        {
            return await _placeOrderManager.GetOrderByIdAsync(id);
        }
    }
}
