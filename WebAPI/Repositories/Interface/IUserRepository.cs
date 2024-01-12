using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<User> LoginAsync(string email, string password);
        Task<string> GetUserByIdAsync(Guid id);
    }
}
