using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Library.Data;


namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                var allBooks = db.Books.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
            {
                return RedirectToAction("Index");
            }

            Book newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
            using (var db = new LibraryDbContext())
            {
                db.Add(newBook);
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Books.FirstOrDefault(t => t.Id == id);
                return View(bookToEdit);
            }

        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new LibraryDbContext())
            {
                var bookToEdit = db.Books.FirstOrDefault(t => t.Id == book.Id);
                bookToEdit.Title = book.Title;
                bookToEdit.Author = book.Author;
                bookToEdit.Price = book.Price;
                db.SaveChanges();
            }
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var bookToDelete = db.Books.FirstOrDefault(t => t.Id == id);
                return View(bookToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}