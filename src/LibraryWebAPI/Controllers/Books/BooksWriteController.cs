using LibraryApp.Core.Domain.Models;
using LibraryApp.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksWriteController : ControllerBase
    {
        private readonly BooksWriteService booksWriteService;

        public BooksWriteController(BooksWriteService booksWriteService)
        {
            this.booksWriteService = booksWriteService;
        }
        [HttpPost]
        public async Task<string> Add([FromBody] BookInDto book)
        {
            var test = book;
            return await booksWriteService.CreateAsync(book);
        }
        [HttpPut]
        public async Task<string> Update([FromBody] BookInDto book)
        {
            return await booksWriteService.UpdateAsync(book);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync (int id)
        {
            await booksWriteService.DeleteAsync(id);
        }

    }
}
