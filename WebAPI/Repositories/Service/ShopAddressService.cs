using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.DTOs.ShopAddress;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories.Service
{
    public class ShopAddressService : IShopAddressRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ShopAddressService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetAllShopAddressAsync()
        {
            var shopAddresses = await dbContext.ShopAddresses.ToListAsync();
            // Map to shop address dto
            var shopAddressDtos = shopAddresses.Select(s => new ShopAddressDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                PhoneNumber = s.PhoneNumber,
                UrlMap = s.UrlMap,
            }).ToList();

            var jsonOptions = new JsonSerializerOptions {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(shopAddressDtos, jsonOptions);
            return jsonString;
        }
    }
}
