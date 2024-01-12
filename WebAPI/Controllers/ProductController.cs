using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsNew()
        {
            return Ok(await productRepository.GetProductsNewHome());
        }

        [HttpGet]
        [Route("{categoryId:Guid}")]
        public async Task<IActionResult> GetProductByCategory(Guid categoryId)
        {
            return Ok(await productRepository.GetProductByCategory(categoryId));
        }

        [HttpGet]
        [Route("{subCategoryId:Guid}")]
        public async Task<IActionResult> GetProductBySubCategory(Guid subCategoryId)
        {
            return Ok(await productRepository.GetProductBySubCategory(subCategoryId));
        }

        [HttpGet]
        [Route("{proId:Guid}")]
        public async Task<IActionResult> GetProductById(Guid proId)
        {
            return Ok(await productRepository.GetProductById(proId));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductSales()
        {
            return Ok(await productRepository.GetProductSaleAsync());
        }
    }
}
