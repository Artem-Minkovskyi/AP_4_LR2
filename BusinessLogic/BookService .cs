using AP_4_LR2.Models;
using AP_4_LR2.Repositories;
using AP_4_LR2.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Create(Book book)
        {
            _unitOfWork.BookRepo.Create(book);
            _unitOfWork.Save();
            return book.Id;
        }

        public Book Get(int id)
        {
            return _unitOfWork.BookRepo.GetById(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _unitOfWork.BookRepo.GetAll();
        }

        public void Update(Book book)
        {
            _unitOfWork.BookRepo.Update(book);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.BookRepo.Delete(id);
            _unitOfWork.Save();
        }
    }



}
