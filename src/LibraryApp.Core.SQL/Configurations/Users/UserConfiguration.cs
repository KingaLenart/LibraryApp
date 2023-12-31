﻿using LibraryApp.Core.Models;
using LibraryApp.Core.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryApp.Core.SQL.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Id).IsUnique();
            builder.Property(user => user.FirstName).IsRequired();
            builder.Property(user => user.LastName).IsRequired();
            builder.Property(user => user.DateOfBirth).IsRequired();
            builder.Property(user => user.Email).IsRequired();
            builder.HasIndex(user => user.Email).IsUnique();
            builder.Property(user => user.PhoneNumber).IsRequired();
            builder.HasIndex(user => user.PhoneNumber).IsUnique();

            builder.HasOne(user => user.Role)
                .WithMany()
                .HasForeignKey(user => user.RoleId)
                .IsRequired(false); 
        }
    }
}
