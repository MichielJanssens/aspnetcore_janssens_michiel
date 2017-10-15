﻿using aspnetcore_janssens_michiel.Entities;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_janssens_michiel.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().HasMany(b => b.Authors).WithOne(ba => ba.Book);
            modelBuilder.Entity<Book>().HasOne(b => b.Genre).WithMany(g => g.Books);

            modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>().HasMany(b => b.Books).WithOne(ba => ba.Author);


            modelBuilder.Entity<Genre>().HasKey(b => b.Id);

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
