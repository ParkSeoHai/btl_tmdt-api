using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Data;
using WebAPI.DTOs.User;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Repositories.Service
{
    public class UserSevice : IUserRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public UserSevice(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<string> GetUserByIdAsync(Guid id)
        {
            var user =
                await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return "";

            var userDto = new UserDto
            {
               Id = user.Id,
               UserName = user.UserName,
               PhoneNumber = user.PhoneNumber,
               Address = user.Address,
               Email = user.Email
            };

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            var jsonString = JsonSerializer.Serialize(userDto, jsonOptions);
            return jsonString;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user =
                await _dbContext.Users.FirstOrDefaultAsync(u =>
                u.Email == email && u.PasswordHash == password);
            return user;
        }
    }
}
