using System;
using Microsoft.EntityFrameworkCore;
namespace BookListDemo.Models
{
    public class BookListDemoDbContext : DbContext
    {
        public BookListDemoDbContext(DbContextOptions<BookListDemoDbContext> options) :base(options)
        {
           
        }
        public DbSet<Book> Books { get; set; }
    }
}
