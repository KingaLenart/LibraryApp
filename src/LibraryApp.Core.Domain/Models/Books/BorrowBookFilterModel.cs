namespace LibraryApp.Core.Domain.Models.Books
{
    public class BorrowBookFilterModel
    {
        public bool? IsReturned { get; set; }
        public int? UserId { get; set; }
    }
}
