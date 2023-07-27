using LibraryApp.Core.Domain.Models.Books;
using LibraryApp.Core.Models;
using LibraryApp.Core.SQL;

namespace LibraryApp.Core.Services.BorrowedBook
{
    public  class BorrowBookWriteService
    {
        private readonly LibraryDatabaseContext libraryDatabaseContext;
        public BorrowBookWriteService(LibraryDatabaseContext libraryDatabaseContext)
        {
            this.libraryDatabaseContext = libraryDatabaseContext;
        }

        public async Task<string> BorrowBookAsync (BorrowBookInDto borrowBook)
        {
            var borrowedBookEntity = new BorrowedBookEntity
            {
                BookId = borrowBook.BookId,
                UserId = borrowBook.UserId,
                BorrowedDate = DateTime.UtcNow
            };
            
            try
            {
                libraryDatabaseContext.Add<BorrowedBookEntity>(borrowedBookEntity);
                await libraryDatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.InnerException?.Message;
            }
            return "";
        }

        public async Task<string> ReturnBookAsync (int id)
        {
            try
            {
                var existingBorrowedBook = await libraryDatabaseContext.FindAsync<BorrowedBookEntity>(id);
                if (existingBorrowedBook == null)
                {
                    return "Podana książka nie jest i nie była wypożyczona";
                }

                existingBorrowedBook.ReturnedDate = DateTime.UtcNow;
                if (existingBorrowedBook.ReturnedDate != null)
                {
                    return "Podana książka została już zwrócona!";
                }

                await libraryDatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.InnerException?.Message;
            }
            return "Zwrócona!";
        }
    }
}
