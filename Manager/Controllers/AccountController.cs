using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Principal;

namespace Manager.Controllers
{
    public class AccountController : Controller
    {
        IAccountRepository accountRepository = null;

        public AccountController() => accountRepository = new AccountRepository();

        // GET: AccountController
        public ActionResult Index()
        {
            var books = accountRepository.GetAccounts();
            return View(books);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = accountRepository.GetAccount(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account acount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    accountRepository.AddNew(acount);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(acount);
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = accountRepository.GetAccount(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Account account)
        {
            try
            {
                if (id != account.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    accountRepository.Update(account);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(account);
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = accountRepository.GetAccount(id.Value);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                accountRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
