using AP_4_LR2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBookService
    {
        int Create(Book book);
        Book Get(int id);
        IEnumerable<Book> GetAll();
        void Update(Book book);
        void Delete(int id);
    }
}
