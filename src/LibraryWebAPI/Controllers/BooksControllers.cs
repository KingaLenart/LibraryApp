using LibraryApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksControllers : ControllerBase
    {
        [HttpGet]
        public List<BookEntity> GetAll ()
        {
            return new List<BookEntity>();
        }
        [HttpPost]
        public async Task Add ([FromBody] BookEntity book)
        {
            var test = book; 
        }
    }
}
