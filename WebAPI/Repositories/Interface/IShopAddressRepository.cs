namespace WebAPI.Repositories.Interface
{
    public interface IShopAddressRepository
    {
        Task<string> GetAllShopAddressAsync();
    }
}
