using LibraryApp.Core.Services.Books;
using LibraryApp.Core.Services.BorrowedBook;
using LibraryApp.Core.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Core.Services.DI
{
    public static class LibraryServicesDI
    {
        public static void AddLibraryServices(this IServiceCollection services)
        {
            services.AddScoped<BooksWriteService>();
            services.AddScoped<BookReadService>();
            services.AddScoped<UserReadService>();
            services.AddScoped<UserWriteService>();
            services.AddScoped<BorrowBookReadService>();
            services.AddScoped<BorrowBookWriteService>();
        }
    }
}
