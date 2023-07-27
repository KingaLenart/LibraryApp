using LibraryApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Core.SQL.Configurations
{
    internal class BorrowBookConfiguration : IEntityTypeConfiguration<BorrowedBookEntity>
    {
        public void Configure(EntityTypeBuilder<BorrowedBookEntity> builder)
        {
            builder.ToTable("Borrowed Books");

            builder.HasKey(borrowedBook => borrowedBook.Id);
            builder.HasIndex(borrowedBook => borrowedBook.Id).IsUnique();

            builder.Property(borrowedBook => borrowedBook.BorrowedDate).IsRequired();

            builder.HasOne(borrowedBook => borrowedBook.User)
            .WithMany(user => user.BorrowedBooks)
            .HasForeignKey(borrowedBook => borrowedBook.UserId)
            .IsRequired();

            builder.HasOne(borrowedBook => borrowedBook.Book)
                .WithMany(book => book.BorrowedBooks)
                .HasForeignKey(borrowedBook => borrowedBook.BookId)
                .IsRequired();

            builder.Property(borrowedBook => borrowedBook.ReturnedDate);
        }
    }

}
