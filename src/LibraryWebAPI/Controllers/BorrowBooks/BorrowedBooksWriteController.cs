using LibraryApp.Core.Domain.Models.Books;
using LibraryApp.Core.Services.BorrowedBook;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers.BorrowBooks
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedBooksWriteController : ControllerBase
    {
        private readonly BorrowBookWriteService borrowedBookWriteService; 
        
        public BorrowedBooksWriteController(BorrowBookWriteService borrowedBookWriteService)
        {
            this.borrowedBookWriteService = borrowedBookWriteService;
        }

        [HttpPost]
        public async Task<string> Add([FromBody] BorrowBookInDto borrowBook)
        {
            var test = borrowBook;
            return await borrowedBookWriteService.BorrowBookAsync(borrowBook);
        }

        [HttpPut("{id}")]
        public async Task<string> ReturnBook(int id)
        {
            return await borrowedBookWriteService.ReturnBookAsync(id);
        }
    }
}
