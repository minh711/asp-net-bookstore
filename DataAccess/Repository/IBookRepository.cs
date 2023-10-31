using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();
        public Book GetBook(int id);
        public void AddNew(Book book);
        public void Delete(int id);
        public void Update(Book book);
    }
}
