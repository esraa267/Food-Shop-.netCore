using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositryPattern.Core.Dtos;
using RepositryPattern.Core.interfaces;
using RepositryPattern.Core.models;

namespace FoodShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public OrderController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(OrderDto order)
        {
            var Order = new order
            {
                userId = order.order!.userId,
            };
            var result = await _unitofwork.Orders.AddAsync(Order);
            _unitofwork.Complete();
            var products = new List<OrderProduct>();

            foreach (var product in order.orderProduct!)
            {
                products.Add(new OrderProduct
                {
                   
                    ProductId = product.Id,
                    Name= product.Name, 
                    Price= product.Price,   
                    Description= product.Description,   
                    OrderId= result.Id,
                    Quantity= product.Quantity, 
                });
            }
            await _unitofwork.OrderProduct.AddListAsync(products);
            _unitofwork.Complete();
            return Ok(result);

        }
    }
}
