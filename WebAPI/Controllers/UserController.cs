using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.User;
using WebAPI.Models;
using WebAPI.Repositories.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = userRequest.UserName,
                Email = userRequest.Email,
                PasswordHash = userRequest.PasswordHash,
                PhoneNumber = userRequest.PhoneNumber,
            };

            return Ok(await userRepository.CreateUserAsync(user));
        }

        [HttpGet]
        [Route("{email}/{password}")]
        public async Task<IActionResult> Login([FromRoute] string email, string password)
        {
            var user = await userRepository.LoginAsync(email, password);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user.Id);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            if(user == "") { return NotFound(); }

            return Ok(user);
        }
    }
}
