using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await categoryRepository.SerializeCategoriesAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesHome()
        {
            return Ok(await categoryRepository.GetAllCategoriesHomeAsync());
        }
    }
}
