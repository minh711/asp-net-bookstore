using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookRepository : IBookRepository
    {
        public void AddNew(Book book)=>BookDAO.Instance.AddNew(book);

        public void Delete(int id)=>BookDAO.Instance.Delete(id);

        public IEnumerable<Book> GetAll()=>BookDAO.Instance.GetAll();

        public Book GetBook(int id)=>BookDAO.Instance.GetBook(id);
        public void Update(Book book)=>BookDAO.Instance.Update(book);
    }
}
