
namespace WebAPI.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<string> GetProductsNewHome();
        Task<string> GetProductById(Guid proId);
        Task<string> GetProductByCategory(Guid catgoryId);
        Task<string> GetProductSaleAsync();
        Task<string> GetProductBySubCategory(Guid subCatgoryId);
    }
}
