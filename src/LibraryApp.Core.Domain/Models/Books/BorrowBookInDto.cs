namespace LibraryApp.Core.Domain.Models.Books
{
    public class BorrowBookInDto
    {
        public int Id { get; set; } 
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
    }
}
