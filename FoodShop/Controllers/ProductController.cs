using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositryPattern.Core.Dtos;
using RepositryPattern.Core.interfaces;
using RepositryPattern.Core.models;

namespace FoodShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public ProductController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByID(int id)
        {

            try
            {
                var product =  await _unitofwork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error");

            }
         
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _unitofwork.Products.GetAllAsync();
                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch
            {
                return BadRequest("Internal server error");
            }
        }
        [HttpPost("Add")]

        public async Task<IActionResult> AddProduct(productDto product)
        {

            if (product == null) { return BadRequest(); }

            if (ModelState.IsValid)
            {
                var Product = new product
                {
                    Name = product.Name,    
                    Price=product.Price,
                    Description = product.Description,  
                };
                
                var result = await _unitofwork.Products.AddAsync(Product);
                if (result == null)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error creating new product");
                }
                _unitofwork.Complete();
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public  async Task<IActionResult> UpdateProduct(int id, [FromBody] product product)

        {
            var Product = await _unitofwork.Products.GetByIdAsync(id);
            if (Product is not null)
            {
                Product.Name = product.Name!;
                Product.Price = product.Price!;
                Product.Description = product.Description!;
                  var result=  _unitofwork.Products.Update(Product);
                 _unitofwork.Complete();
                 return Ok(result);
            }
           
             return NotFound(); 
          
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var Product = await _unitofwork.Products.GetByIdAsync(id);

            if (Product is not null)
            {
                _unitofwork.Products.Delete(Product);
                 _unitofwork.Complete();
                return Ok();
            }
            

            return NotFound("Not Found");
        }

    }
}
