namespace LibraryApp.Core.Models
{
    public class UserEntity : IDataEntity
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public virtual List<BorrowedBookEntity> BorrowedBooks { get; set; }
    }
}
