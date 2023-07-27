namespace LibraryApp.Core.Models
{
    public class BookEntity : IDataEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }

        public virtual List<BorrowedBookEntity> BorrowedBooks { get; set; }

    }
}
