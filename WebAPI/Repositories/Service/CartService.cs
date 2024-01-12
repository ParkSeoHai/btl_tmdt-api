using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.DTOs.Cart;
using WebAPI.DTOs.Product;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories.Service
{
    public class CartService : ICartRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CartService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Tạo cart
        public async Task<Cart> CreateCart(Cart cart)
        {
            await dbContext.Carts.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            return cart;
        }

        public async Task<string> GetProductCart(string sesstionId)
        {
            var cart = await dbContext.Carts
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync(c => c.SesstionId == sesstionId);

            if(cart == null)
            {
                return "";
            }

            var productsCart = (from c in dbContext.Carts
                                from cp in dbContext.CartProducts
                                from p in dbContext.Products
                                where c.Id == cp.CartId && cp.ProductId == p.Id
                                && c.SesstionId == sesstionId
                                select new ProductCartDto
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    DefaultImage = p.DefaultImage,
                                    Price = cp.Price,
                                    Quantity = cp.Quantity
                                }).ToList();

            var cartDtos = new CartDto
            {
                Id = cart.Id,
                sessionId = cart.SesstionId,
                productCartDtos = productsCart
            };

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(cartDtos, jsonOptions);

            return jsonString;
        }

        public async Task<bool> UpdateCart(UpdateCartDto updateCartDto)
        { 
            var cart = await dbContext.Carts.FirstOrDefaultAsync(c => c.SesstionId == updateCartDto.SessionId);
            if (cart == null)
            {
                return false;
            }

            var cartProduct = await dbContext.CartProducts.FirstOrDefaultAsync(c =>
                c.CartId == cart.Id && c.ProductId == Guid.Parse(updateCartDto.ProductId)
            );

            if (cartProduct == null)
            {
                return false;
            } else
            {
                cartProduct.Quantity = updateCartDto.Quantity;
            }

            dbContext.CartProducts.Update(cartProduct);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductCart(string sessionId, Guid productId)
        {
            var cart = await dbContext.Carts.FirstOrDefaultAsync(c => c.SesstionId == sessionId);
            if (cart == null) { return false; }

            var cartProduct = await dbContext.CartProducts
                .FirstOrDefaultAsync(c => c.CartId == cart.Id && c.ProductId == productId);

            dbContext.CartProducts.Remove(cartProduct);
            dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> AddProductCart(CreateProductCartDto productCartDto)
        {
            var cart = await dbContext.Carts.FirstOrDefaultAsync(c => c.SesstionId == productCartDto.SessionId);
            if (cart == null) return false;

            var cartProduct = new CartProduct
            {
                CartId = cart.Id,
                ProductId = productCartDto.ProductId,
                Quantity = productCartDto.Quantity,
                Price = productCartDto.Price,
            };

            await dbContext.CartProducts.AddAsync(cartProduct);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
