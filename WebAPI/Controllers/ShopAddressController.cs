using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopAddressController : ControllerBase
    {
        private readonly IShopAddressRepository shopAddressRepository;

        public ShopAddressController(IShopAddressRepository shopAddressRepository)
        {
            this.shopAddressRepository = shopAddressRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShopAddress()
        {
            return Ok(await shopAddressRepository.GetAllShopAddressAsync());
        }
    }
}
