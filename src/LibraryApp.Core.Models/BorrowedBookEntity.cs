namespace LibraryApp.Core.Models
{
    public class BorrowedBookEntity : IDataEntity
    {
        public int Id { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BookId { get; set; }
        public virtual BookEntity Book { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
