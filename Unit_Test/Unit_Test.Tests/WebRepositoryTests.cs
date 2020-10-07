using System.Collections.Generic;
using System.ComponentModel;
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
        public void FetchBooksTest_ShouldReturnAllBooks()
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
        public void CreateBookTest_ShouldAddNewBook()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            //Act
            var repository = new BookRepository(mockContext.Object);
            repository.AddBook("The Compound Effect", "Darren Hardy");

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<Book>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteBookTest_ShouldRemoveBook_WhenExist()
        {
            //Arrange
            var mockSet = new Mock<DbSet<Book>>();
            int id = 1;

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(c => c.Books).Returns(mockSet.Object);

            //Act
            var repository = new BookRepository(mockContext.Object);
            repository.DeleteBook(id);

            //Assert
            mockSet.Verify(m => m.Remove(It.IsAny<Book>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [DataTestMethod]
        [DataRow(1, "The Compound Effect", "Darren Hardy")]
        public void EditBookTest_ShouldUpdateBook_WhenBookExist(int id, string title, string author)
        {
            //Arrange
            Book book = new Book()
            {
                Id = id,
                Author = author,
                Title = title
            };

            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookStoreContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);

            //Act
            var repository = new BookRepository(mockContext.Object);
            repository.EditBook(book);

            //Assert
            mockSet.Verify(m => m.Update(It.IsAny<Book>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}