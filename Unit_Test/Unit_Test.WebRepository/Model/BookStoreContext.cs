using Microsoft.EntityFrameworkCore;

namespace Unit_Test.WebRepository.Model
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options):base(options)
        {
        }
        public BookStoreContext()
        {
        }
        public virtual DbSet<Book> Books { get; set; }
    }
}