using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Models;
using LibraryApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Core.Services.Users
{
    public class UserReadService
    {
        private readonly LibraryDatabaseContext libraryDatabaseContext;

        public UserReadService(LibraryDatabaseContext libraryDatabaseContext)
            {
            this.libraryDatabaseContext = libraryDatabaseContext;
        }

        public async Task<List<UserOutDto>> GetAllUsersAsync()
        {
            var userList = await libraryDatabaseContext.Set<UserEntity>().ToListAsync();
            var userOutDtoList = userList.Select(user => new UserOutDto
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            }).ToList();
            return userOutDtoList;
        }

        public async Task <UserOutDto> GetUserByIdAsync(int id)
        {
            try
            {
                var displayUser = await libraryDatabaseContext.FindAsync<UserEntity>(id);

                if (displayUser == null)
                {
                    return null;
                }
                return new UserOutDto
                {
                    Id = displayUser.Id,
                    LastName = displayUser.LastName,
                    FirstName = displayUser.FirstName,
                    DateOfBirth = displayUser.DateOfBirth,
                    Email = displayUser.Email,
                    PhoneNumber = displayUser.PhoneNumber,
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
