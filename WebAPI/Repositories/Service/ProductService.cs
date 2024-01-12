using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebAPI.Data;
using WebAPI.DTOs.Product;
using WebAPI.Repositories.Interface;
using WebAPI.DTOs.Brand;
using WebAPI.DTOs.Category;
using WebAPI.Models;
using WebAPI.DTOs.SubCategory;
using System.Linq;

namespace WebAPI.Repositories.Service
{
    public class ProductService : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetProductsNewHome()
        {
            var products = await dbContext.Products.ToListAsync();

            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                PriceNew = CalcPercent(p.Price, (int)p.Discount),
                DefaultImage = p.DefaultImage,
            }).ToList();

            var jsonOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(productDtos, jsonOptions);

            return jsonString;
        }

        public async Task<string> GetProductByCategory(Guid categoryId)
        {
            var products = await (from c in dbContext.Categories
                            join s in dbContext.SubCategories on c.Id equals s.CategoryId
                            join p in dbContext.Products on s.Id equals p.SubCategoryId
                            where c.Id == categoryId
                            select new ProductCategoryDto
                            {
                                Id = p.Id,
                                Name = p.Name,
                                PriceNew = CalcPercent(p.Price, (int)p.Discount),
                                DefaultImage = p.DefaultImage,
                                PriceOld = p.Price,
                                CategoryName = c.Name,
                                Discount = p.Discount
                            }).AsNoTracking()
                            .ToListAsync();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var jsonString = JsonSerializer.Serialize(products, jsonOptions);

            return jsonString;
        }

        public async Task<string> GetProductById(Guid proId)
        {
            // Get product
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == proId);
            if (product == null) return "";
            // Get brand product
            var brand = await dbContext.Brands.FirstOrDefaultAsync(b => b.Id == product.BrandId);
            var brandDto = new BrandDto();
            if (brand != null)
            {
                brandDto.Name = brand.Name;
            }
            // Get sub category
            var subCategory = await dbContext.SubCategories.FirstOrDefaultAsync(
                s => s.Id == product.SubCategoryId);
            var subCategoryDto = new SubcategoryDto();
            if(subCategory != null)
            {
                subCategoryDto.Id = subCategory.Id;
                subCategoryDto.Name = subCategory.Name;
            }
            
            // Get product images
            var images = await (from i in dbContext.ProductImages
                                where i.ProductId == proId
                                select new ProductImageDto
                                {
                                    Id = i.Id,
                                    Url = i.Url,
                                }).ToListAsync();

            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Brand = brandDto.Name,
                SubCategory = subCategoryDto.Name,
                DefaultImage = product.DefaultImage,
                Discount = product.Discount,
                PriceOld = product.Price,
                PriceNew = CalcPercent(product.Price, (int)product.Discount),
                Quantity = product.Quantity,
                Images = images
            };
            
            var jsonOptions = new JsonSerializerOptions 
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
            };

            var jsonString = JsonSerializer.Serialize(productDto, jsonOptions);
            return jsonString;
        }

        public async Task<string> GetProductSaleAsync()
        {
            var productSales = await dbContext.Products.Where(p => p.Discount > 0).ToListAsync();
            // Map product sale dto
            var productSaleDtos = productSales.Select(p => new ProductSaleDto
            {
                Id = p.Id,
                Name = p.Name,
                PriceOld = p.Price,
                PriceNew = CalcPercent(p.Price, (int)p.Discount),
                Discount = p.Discount,
                DefaultImage = p.DefaultImage,
            }).ToList();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var jsonString = JsonSerializer.Serialize(productSaleDtos, jsonOptions);
            return jsonString;
        }

        public static double CalcPercent(double price, int discount)
        {
            if (discount == 0) return price;
            double priceSale = (price * discount) / 100;

            return price - priceSale;
        }

        public async Task<string> GetProductBySubCategory(Guid subCatgoryId)
        {
            var products = await dbContext.SubCategories
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == subCatgoryId);
            if (products == null) return "";

            /*var products = await (from c in dbContext.Categories
                                 join s in dbContext.SubCategories on c.Id equals s.CategoryId
                                 join p in dbContext.Products on s.Id equals p.SubCategoryId
                                 where s.Id == subCatgoryId
                                 select new ProductCategoryDto
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     PriceOld = p.Price,
                                     PriceNew = CalcPercent(p.Price, (int)p.Discount),
                                     DefaultImage = p.DefaultImage,
                                     CategoryName = s.Name,
                                     Discount = p.Discount,
                                 }).AsNoTracking()
                            .ToListAsync();*/

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };

            var jsonString = JsonSerializer.Serialize(products, jsonOptions);

            return jsonString;
        }
    }
}
