using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Domain.Models.Books;
using LibraryApp.Core.Models;
using LibraryApp.Core.SQL;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Core.Services.BorrowedBook
{
    public class BorrowBookReadService
    {
        private readonly LibraryDatabaseContext libraryDatabaseContext;

        public BorrowBookReadService(LibraryDatabaseContext libraryDatabaseContext)
        {
            this.libraryDatabaseContext = libraryDatabaseContext;
        }

        public async Task<List<BorrowBookOutDto>> GetAllBorrowBookAsync()
        {
            var borrowBookList = await libraryDatabaseContext.Set<BorrowedBookEntity>()
                .Include(bb => bb.Book)
                .Include(bb => bb.User)
                .ToListAsync();
            var borrowBookOutDtoList = new List<BorrowBookOutDto>();

            foreach (var borrowBook in borrowBookList)
            {
                borrowBookOutDtoList.Add(new BorrowBookOutDto
                {
                    Id = borrowBook.Id,
                    Book = new BookOutDto
                    {
                        Id = borrowBook.BookId, 
                        Title = borrowBook.Book.Title,
                        Author = borrowBook.Book.Author,
                        Publisher = borrowBook.Book.Publisher,
                        PublicationDate = borrowBook.Book.PublicationDate
                    },
                    User = new UserOutDto
                    {
                        Id = borrowBook.User.Id,
                        LastName = borrowBook.User.LastName,
                        FirstName = borrowBook.User.FirstName,
                        DateOfBirth = borrowBook.User.DateOfBirth,
                        Email = borrowBook.User.Email,
                        PhoneNumber = borrowBook.User.PhoneNumber,
                    }, 
                    BorrowedDate = borrowBook.BorrowedDate,
                    ReturnedDate = borrowBook.ReturnedDate

                });
            }

            return borrowBookOutDtoList;
        }

        public async Task<List<BorrowBookOutDto>> GetUnreturnedBorrowBookAsync(BorrowBookFilterModel filterModel)
        {
            var allBorrowBookList = await GetAllBorrowBookAsync();

            var usersBorroweBook = allBorrowBookList.Where(bb => (filterModel.UserId != null && filterModel.UserId == bb.User.Id) || filterModel.UserId == null).ToList();
            
            if (filterModel.IsReturned == true)
            {
                var returnedBorrowBookOutDtoList = usersBorroweBook.Where(bb => bb.ReturnedDate != null).ToList();
                return returnedBorrowBookOutDtoList;
            }

            if(filterModel.IsReturned == false )
            {
                var unreturnedBorrowBookOutDtoList = usersBorroweBook.Where(bb => bb.ReturnedDate == null).ToList();
                return unreturnedBorrowBookOutDtoList;
            }
            return usersBorroweBook;
        }

       
    }
}
