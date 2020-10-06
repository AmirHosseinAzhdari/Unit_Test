using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Unit_Test.WebRepository;
using Unit_Test.WebRepository.Model;

namespace Unit_Test.Tests
{
    [TestClass]
    public class WebRepositoryTests
    {
        [TestMethod]
        public void FetchBooksTest()
        {
            //Arrange
            IQueryable<Book> books = new List<Book>
            {
                new Book()
                {
                    Title = "Hamlet",
                    Author = "William"
                },
                new Book()
                {
                    Title = "Time Management",
                    Author = "Brian Tracy"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator);

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            //Act
            var repository = new BookRepository(mockContext.Object);
            var actual = repository.FetchBooks();

            //Assert
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("Hamlet", actual.First().Title);
        }

        [TestMethod]
        public void CreateBookTest()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            //Act
            var repository = new BookRepository(mockContext.Object);
            repository.AddBook("The Compound Effect" , "Darren Hardy");

            //Assert
            mockSet.Verify(m=>m.Add(It.IsAny<Book>()),Times.Once);
            mockContext.Verify(m=>m.SaveChanges(),Times.Once);
        }
    }
}