using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersWriteController : ControllerBase
    {
        private readonly UserWriteService usersWriteService;

        public UsersWriteController(UserWriteService userWriteService)
        {
            this.usersWriteService = userWriteService;
        }

        [HttpPost]
        public async Task<string> Add([FromBody] UserInDto user)
        {
            var test = user;
            return await usersWriteService.CreateAsync(user);
        }

        [HttpPut]
        public async Task<string> Update ([FromBody] UserInDto user)
        {
            return await usersWriteService.UpdateAsync(user); 
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync (int id)
        {
            await usersWriteService.DeleteAsync(id);
        }
    }
}
