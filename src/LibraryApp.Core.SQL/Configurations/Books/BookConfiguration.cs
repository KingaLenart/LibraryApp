using LibraryApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Core.SQL.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(book => book.Id);
            builder.HasIndex(book => book.Id).IsUnique();
            builder.Property(book => book.Title).IsRequired();
            builder.Property(book => book.Author).IsRequired();
            builder.Property(book => book.PublicationDate).IsRequired();

        }
    }

}
