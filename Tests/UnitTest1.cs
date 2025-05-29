using Xunit;
using Moq;
using AP_4_LR2.Models;
using AP_4_LR2.UoW;
using AP_4_LR2.Repositories;
using BusinessLogic;

namespace Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IGenericRepository<Book>> _mockBookRepo;
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockBookRepo = new Mock<IGenericRepository<Book>>();

            _mockUnitOfWork.Setup(u => u.BookRepo).Returns(_mockBookRepo.Object);

            _bookService = new BookService(_mockUnitOfWork.Object);
        }

        [Fact]
        public void CreateBook_ShouldCallCreateAndSave()
        {
            var testBook = new Book { Id = 1, Title = "Test Book", Author = "Author", Pages = 123, StorageLocationId = 1 };

            var resultId = _bookService.Create(testBook);

            _mockBookRepo.Verify(r => r.Create(It.Is<Book>(b => b.Title == "Test Book")), Times.Once);
            _mockUnitOfWork.Verify(r => r.Save(), Times.Once);
        }

        [Fact]
        public void DeleteBook_ShouldCallDeleteAndSave()
        {

            int bookId = 1;

            _bookService.Delete(bookId);

            _mockBookRepo.Verify(r => r.Delete(bookId), Times.Once);
            _mockUnitOfWork.Verify(r => r.Save(), Times.Once);
        }
    }
}
