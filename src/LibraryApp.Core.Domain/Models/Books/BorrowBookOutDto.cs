namespace LibraryApp.Core.Domain.Models.Books
{
    public class BorrowBookOutDto
    {
        public int Id { get; set; }
        public BookOutDto Book { get; set; }
        public UserOutDto User { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
