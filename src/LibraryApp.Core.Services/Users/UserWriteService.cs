using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Models;
using LibraryApp.Core.SQL;

namespace LibraryApp.Core.Services.Users
{
    public class UserWriteService
    {
        private readonly LibraryDatabaseContext libraryDatabaseContext;

        public UserWriteService(LibraryDatabaseContext libraryDatabaseContext)
        {
            this.libraryDatabaseContext = libraryDatabaseContext;
        }

        public async Task<string> CreateAsync (UserInDto user)
        {
            var userEntity = new UserEntity
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            try
            {
                libraryDatabaseContext.Add<UserEntity>(userEntity);
                await libraryDatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        public async Task<string> UpdateAsync (UserInDto user)
        {
            try
            {
                var existingUser = await libraryDatabaseContext.FindAsync<UserEntity>(user.Id);

                if (existingUser == null)
                {
                    return "Nie znaleziono użytkownika o podanym ID";
                }

                existingUser.LastName = user.LastName;
                existingUser.FirstName = user.FirstName;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;

                await libraryDatabaseContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return ex.InnerException?.Message;
            }
            return "";
        }

        public async Task DeleteAsync (int id)
        {
            var userToRemove = await libraryDatabaseContext.FindAsync<UserEntity>(id);
            
            if (userToRemove != null)
            {
                libraryDatabaseContext.Remove(userToRemove);
                await libraryDatabaseContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nie ma takiego użytkownika w bazie");
            }
        }

    }
}
