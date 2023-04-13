using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment3.Models;
using System;

namespace COMP003B.Assignment3.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> _books = new List<Book>();

        //Get: Books
        public IActionResult Index()
        {
            return View(_books);
        }
        //Get: Books/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                if (!_books.Any(p => p.ISBN == book.ISBN))
                {
                    _books.Add(book);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //Get: Books/Edit/1
        [HttpGet]
        public IActionResult Edit(int? isbn)
        {
            if (isbn == null)
            {
                return NotFound();
            }
            var book = _books.FirstOrDefault(p => p.ISBN == isbn);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        //Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int isbn, Book book)
        {
            if (isbn != book.ISBN)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingBook = _books.FirstOrDefault(p => p.ISBN == book.ISBN);

                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.Genre = book.Genre;
                    existingBook.Author = book.Author;
                    existingBook.ReleaseYear = book.ReleaseYear;
                }
                return RedirectToAction(nameof(Index));


            }
            return View(book);
        }
        //get: Books/Delete/1
        [HttpGet]
        public IActionResult Delete(int? isbn)
        {
            if (isbn == null)
            {
                return NotFound();
            }
            var book = _books.FirstOrDefault(p => p.ISBN == isbn);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //Post: Books/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int isbn)
        {
            var book = _books.FirstOrDefault(p => p.ISBN == isbn);
            if (book != null)
            {
                _books.Remove(book);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
