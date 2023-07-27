using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Models;
using LibraryApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Core.Services.Books
{
    public class BookReadService
    {
        private readonly LibraryDatabaseContext libraryDatabaseContext;

        public BookReadService(LibraryDatabaseContext libraryDatabaseContext)
        {
            this.libraryDatabaseContext = libraryDatabaseContext;
        }
        public async Task<List<BookOutDto>> GetAllBooksAsync()
        {
            var bookList = await libraryDatabaseContext.Set<BookEntity>().ToListAsync();
            var bookOutDtoList = bookList.Select(book => new BookOutDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublicationDate = book.PublicationDate
            }).ToList();
            
            return bookOutDtoList;
        }
        public async Task<BookOutDto> GetByIdAsync(int id)
        {
            try
            {
                var displayBook = await libraryDatabaseContext.FindAsync<BookEntity>(id);

                if (displayBook == null)
                {
                    return null;
                }

                return new BookOutDto
                { 
                    Id=displayBook.Id,
                    Title = displayBook.Title,
                    Author = displayBook.Author,
                    Publisher = displayBook.Publisher,
                    PublicationDate= displayBook.PublicationDate,
                };
                

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
