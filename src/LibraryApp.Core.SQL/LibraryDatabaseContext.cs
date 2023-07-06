using LibraryApp.Core.SQL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Core.SQL
{
    public class LibraryDatabaseContext : DbContext
    {

        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowBookConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}