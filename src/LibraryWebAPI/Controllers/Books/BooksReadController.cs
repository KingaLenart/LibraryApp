using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Services.Books;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksReadController : ControllerBase
    {
        private readonly BookReadService bookReadService;

        public BooksReadController(BookReadService bookReadServices)
        {
            this.bookReadService = bookReadServices;
        }

        [HttpGet]
        public async Task<List<BookOutDto>> GetAllBooks()
        {
            return await bookReadService.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<BookOutDto> GetBookOut(int id)
        {
            return await bookReadService.GetByIdAsync(id);
        }
        
  
    }
}
