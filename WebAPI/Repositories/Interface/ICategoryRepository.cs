using WebAPI.DTOs.Category;
using WebAPI.Models;

namespace WebAPI.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<string> SerializeCategoriesAsync();
        Task<string> GetAllCategoriesHomeAsync();
    }
}
