﻿using LibraryApp.Core.Models.Authentication;
using LibraryApp.Core.SQL.Configurations;
using LibraryApp.Core.SQL.Configurations.Roles;
using LibraryApp.Core.SQL.Seeds;
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
            modelBuilder.Entity<RoleEntity>().HasData(RolesSeed.RoleSeed);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}