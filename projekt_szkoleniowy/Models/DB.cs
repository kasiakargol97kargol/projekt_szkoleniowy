using System.Data.Entity;

namespace projekt_szkoleniowy.Models
{
    public class DB : DbContext
    {
        public DbSet<Author> tAuthors { get; set; }
        public DbSet<Book> tBooks { get; set; }
    }
}