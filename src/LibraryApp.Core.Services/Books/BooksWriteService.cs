using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Models;
using LibraryApp.Core.SQL;

namespace LibraryApp.Core.Services
{
    public class BooksWriteService
    {

        private readonly LibraryDatabaseContext libraryDatabaseContext;

        public BooksWriteService(LibraryDatabaseContext libraryDatabaseContext)
        {
            this.libraryDatabaseContext = libraryDatabaseContext;
        }

        public async Task<string> CreateAsync(BookInDto book)
        {
            var bookEntity = new BookEntity 
            {
                Title = book.Title,
                Author = book.Author,
                Publisher = book.Publisher,
                PublicationDate = book.PublicationDate
            };

            try
            {
                libraryDatabaseContext.Add<BookEntity>(bookEntity);
                await libraryDatabaseContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return ex.InnerException?.Message;
            }            

            return "";
        }

        public async Task<string> UpdateAsync (BookInDto book)
        {
            try
            {
                var existingBook = await libraryDatabaseContext.FindAsync<BookEntity>(book.Id);
                if (existingBook == null)
                {
                    return "Nie znaleziono książki o podanym ID";
                }

                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Publisher = book.Publisher;
                existingBook.PublicationDate = book.PublicationDate;

                await libraryDatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.InnerException?.Message;
            }
            return "";

        }
        public async Task DeleteAsync (int id)
        {

            var bookToRemove = await libraryDatabaseContext.FindAsync<BookEntity>(id);

            if (bookToRemove != null)
            {
                libraryDatabaseContext.Remove(bookToRemove);
                await libraryDatabaseContext.SaveChangesAsync();
            }else
            {
                throw new Exception("Nie ma takiej ksiązki w bazie!");
            }
            
            
        }

    }
}