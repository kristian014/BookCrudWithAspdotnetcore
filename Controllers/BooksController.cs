using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCrudWithAspdotnetcore.Data;
using BookCrudWithAspdotnetcore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCrudWithAspdotnetcore.Controllers
{
    public class BooksController : Controller
    {
       private readonly ApplicationDbContext _db;
        [BindProperty]
        public Book Book { get; set; }
        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: Books
        public ActionResult Index()
        {
            var book = _db.Book.ToList();
            return View(book);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, Message = "Error while Retrieving data " });
            }

            var book = _db.Book.SingleOrDefault(e => e.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _db.Book.Add(book);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
           
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
               
                return Json(new { success = false, Message = "Error while Editing" });
            }

            var book = _db.Book.SingleOrDefault(e => e.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {

            // TODO: Add update logic here
            if (ModelState.IsValid)
            {
                _db.Book.Update(book);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(book);
            
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, Message = "Error while deleting" });
            }

            var book = _db.Book.SingleOrDefault(e => e.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var book = _db.Book.SingleOrDefault(x => x.BookId == id);
            if (book == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Book.Remove(book ?? throw new InvalidOperationException());
                    _db.SaveChanges();
                    return Json(new { success = true, message = "Delete successful" });
          //  return RedirectToAction("Index");


        }

        #region MyRegion

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Json(new { data = await _db.Book.ToListAsync() });
        //}

        //[HttpDelete]

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var bookFromDb = await _db.Books.FirstOrDefaultAsync(u => u.Id == id);
        //    if (bookFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while Deleting" });
        //    }
        //    _db.Books.Remove(bookFromDb);
        //    await _db.SaveChangesAsync();
        //    return Json(new { success = true, message = "Delete successful" });
        //}






        #endregion
    }
}