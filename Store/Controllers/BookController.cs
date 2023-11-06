using BusinessObject;
using DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Store.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository = null;

        public BookController() => bookRepository = new BookRepository();

        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepository.GetAll();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookRepository.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookRepository.AddNew(book);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(book);
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookRepository.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bookRepository.Update(book);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(book);
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookRepository.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                bookRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add()
        {
            ICartRepository cartRepository = new CartRepository();
            int accountId = 1;
            using var context = new PRN_Group03Context();
            int totalQuantity = cartRepository.CountTotal(accountId);
            return View();
        }
    }
}
