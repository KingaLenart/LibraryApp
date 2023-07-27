using LibraryApp.Core.Domain.Models.Books;
using LibraryApp.Core.Services.BorrowedBook;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers.BorrowBooks
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BorrowBooksReadController : ControllerBase
    {
        private readonly BorrowBookReadService borrowBookReadService; 

        public BorrowBooksReadController(BorrowBookReadService borrowBookReadService)
        {
            this.borrowBookReadService = borrowBookReadService;
        }

        [HttpGet]
        public async Task <List<BorrowBookOutDto>> GetAllBorrowBooks()
        {
            return await borrowBookReadService.GetAllBorrowBookAsync();
        }

        [HttpGet("filter")]
        public async Task<List<BorrowBookOutDto>> GetUnreturnedBorrowBooks([FromBody]BorrowBookFilterModel filterModel)
        {
            return await borrowBookReadService.GetUnreturnedBorrowBookAsync(filterModel);
        }
    }
}
