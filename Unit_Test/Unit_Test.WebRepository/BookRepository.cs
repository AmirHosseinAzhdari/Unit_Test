using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unit_Test.WebRepository.Model;

namespace Unit_Test.WebRepository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public List<Book> FetchBooks() => _context.Books.ToList();

        public void AddBook(string title, string author)
        {
            _context.Books.Add(new Book()
            {
                Title = title,
                Author = author
            });
            _context.SaveChanges();
        }
    }
}
