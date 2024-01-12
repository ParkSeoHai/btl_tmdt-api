using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.DTOs.Category;

namespace WebAPI.Repositories.Service
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetAllCategoriesHomeAsync()
        {
            var categories = await dbContext.Categories.ToListAsync();

            var categorieDtos = categories.Select(c => new CategoryHomeDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            var jsonOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var jsonString = JsonSerializer.Serialize(categorieDtos, jsonOptions);

            return jsonString;
        }

        public async Task<string> SerializeCategoriesAsync()
        {
            var categories = await dbContext.Categories
                .Include(c => c.SubCategories)
                .ToListAsync();

            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                // Map other properties as needed
                Subcategories = c.SubCategories.Select(sc => new SubcategoryDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                }).ToList()
            }).ToList();

            var jsonOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // WriteIndented = true,   // This makes the JSON output formatted with indentation
            };

            var jsonString = JsonSerializer.Serialize(categoryDtos, jsonOptions);

            return jsonString;
        }
    }
}
