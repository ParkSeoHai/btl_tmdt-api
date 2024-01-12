using WebAPI.DTOs.Cart;
using WebAPI.Models;

namespace WebAPI.Repositories.Interface
{
    public interface ICartRepository
    {
        Task<Cart> CreateCart(Cart cart);
        Task<string> GetProductCart(string sesstionId);
        Task<bool> UpdateCart(UpdateCartDto updateCartDto);
        Task<bool> DeleteProductCart(string sessionId, Guid productId);
        Task<bool> AddProductCart(CreateProductCartDto productCartDto);
    }
}
