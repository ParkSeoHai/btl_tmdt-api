using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.Cart;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartDto cartDto)
        {
            var cart = new Cart
            {
                Id = Guid.NewGuid(),
                SesstionId = cartDto.SesstionId,
            };

            return Ok(await cartRepository.CreateCart(cart));
        }

        [HttpGet]
        [Route("{sessionId}")]
        public async Task<IActionResult> GetProductCart([FromRoute] string sessionId)
        {
            return Ok(await cartRepository.GetProductCart(sessionId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDto updateCartDtoRequest)
        {
            return Ok(await cartRepository.UpdateCart(updateCartDtoRequest));
        }

        [HttpDelete]
        [Route("{sessionId}/{productId:Guid}")]
        public async Task<IActionResult> RemoveProductCart([FromRoute] string sessionId, Guid productId)
        {
            return Ok(await cartRepository.DeleteProductCart(sessionId, productId));
        }

        [HttpPost]
        public async Task<IActionResult> AddProductCart([FromBody] CreateProductCartDto productCartDto)
        {
            return Ok(await cartRepository.AddProductCart(productCartDto));
        }
    }
}
