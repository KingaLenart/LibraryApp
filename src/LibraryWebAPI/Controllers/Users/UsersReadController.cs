using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersReadController : ControllerBase
    {
        private readonly UserReadService userReadService;

        public UsersReadController(UserReadService userReadService)
        {
            this.userReadService = userReadService;
        }

        [HttpGet]
        public async Task<List<UserOutDto>> GetAllUsersAsync()
        {
            return await userReadService.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<UserOutDto> GetUserByIdAsync(int id)
        {
            return await userReadService.GetUserByIdAsync(id);
        }
    }
}
