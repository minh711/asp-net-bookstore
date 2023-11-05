using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {


        private static BookDAO instance = null;
        private static readonly object instanceLock = new object();
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();

                    }
                    return instance;
                }
            }
        }

        //-------------------------------------------------------------


        public IEnumerable<Book> GetAll()
        {

            var books = new List<Book>();
            try
            {
                using var context = new PRN_Group03Context();
                books = context.Books.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return books;
        }
        //---------------------------------------------------


        public Book GetBook(int id)
        {
            Book book = null;
            try
            {
                using var context = new PRN_Group03Context();
                book = context.Books.SingleOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return book;
        }


        //--------------------------------------------------------


        public void AddNew(Book book)
        {
            try
            {
                Book book1 = GetBook(book.Id);
                if (book1 == null)
                {
                    using var context = new PRN_Group03Context();
                    context.Books.Add(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Sách đã tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //--------------------------------------------------------------


        public void Update(Book book)
        {
            try
            {
                Book book1 = GetBook(book.Id);
                if (book1 != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Books.Add(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Sách không tồn tại.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        //------------------------------------------------------------------------------


        public void Delete(int bookID)
        {
            try
            {
                Book book1 = GetBook(bookID);
                if (book1 != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Books.Remove(book1);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Sách không tồn tại.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }







    }
}
