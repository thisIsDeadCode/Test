using Microsoft.EntityFrameworkCore;
using Test.Api.Data.Models;

namespace Test.Api.Data
{
    public class TestApiContext : DbContext
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Author> Authors { get; set; }

        public TestApiContext(DbContextOptions<TestApiContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author { Id = 1, Name = "Иван", Surname = "Иванов", Rating = 100});
            modelBuilder.Entity<Author>().HasData(new Author { Id = 2, Name = "Петр", Surname = "Петров", Rating = 50});
            modelBuilder.Entity<Author>().HasData(new Author { Id = 3, Name = "Вася", Surname = "Васильев", Rating = 10});


            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 1,
                AuthorId = 1,
                Content = "Content1",
                Title = "Title1",
                CreatedDate = DateTime.UtcNow.AddDays(-2),
                ModifiedDate = DateTime.UtcNow.AddDays(-2),
                StartDate = DateTime.UtcNow.AddDays(-2),
                FinishedDate = DateTime.UtcNow.AddDays(1)
            });

            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 2,
                AuthorId = 1,
                Content = "Content2",
                Title = "Title2",
                CreatedDate = DateTime.UtcNow.AddDays(-100),
                ModifiedDate = DateTime.UtcNow.AddDays(-100),
                StartDate = DateTime.UtcNow.AddDays(-100),
                FinishedDate = DateTime.UtcNow.AddDays(600)
            });

            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 3,
                AuthorId = 1,
                Content = "Content3",
                Title = "Title3",
                CreatedDate = DateTime.UtcNow.AddDays(-100),
                ModifiedDate = DateTime.UtcNow.AddDays(-100),
                StartDate = DateTime.UtcNow.AddDays(-100),
                FinishedDate = DateTime.UtcNow.AddDays(600)
            });

            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 4,
                AuthorId = 2,
                Content = "Content4",
                Title = "Title4",
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow,
                FinishedDate = DateTime.UtcNow.AddDays(600)
            });
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 5,
                AuthorId = 3,
                Content = "Content5",
                Title = "Title5",
                CreatedDate = DateTime.UtcNow.AddDays(-100),
                ModifiedDate = DateTime.UtcNow.AddDays(-100),
                StartDate = DateTime.UtcNow.AddDays(-100),
                FinishedDate = DateTime.UtcNow.AddDays(-50),
            });
            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 6,
                AuthorId = 3,
                Content = "Content6",
                Title = "Title6",
                CreatedDate = DateTime.UtcNow.AddDays(-100),
                ModifiedDate = DateTime.UtcNow.AddDays(-100),
                StartDate = DateTime.UtcNow.AddDays(-100),
                FinishedDate = DateTime.UtcNow.AddDays(-70),
            });

            modelBuilder.Entity<Advertisement>().HasData(new Advertisement
            {
                Id = 7,
                AuthorId = 3,
                Content = "Content7",
                Title = "Title7",
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                StartDate = DateTime.UtcNow,
                FinishedDate = DateTime.UtcNow.AddDays(61)
            });
        }
    }
}
