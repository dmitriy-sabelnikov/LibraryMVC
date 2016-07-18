using LibraryMVC.Entities;
using LibraryMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.WebUI.Controllers
{
    public class HomeController : Controller
    {
        static IAuthorRepository _repository;

        public HomeController (IAuthorRepository repo)
        {
            if (_repository == null)
            {
                _repository = repo;
            }
        }

        // GET: Home
        public ViewResult Index()
        {
            List<Author> authors = _repository.GetAllAuthors();
            return View(authors);
        }

        [HttpPost]
        public ActionResult Delete(int authorId)
        {
            Author author = _repository.DeleteAuthor(authorId);
            if (author != null)
            {
                TempData["message"] = String.Format("Автор {0} {1} {2} удален", author.Surname, author.Name, author.Patronymic);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int authorId)
        {
            Author author = _repository.GetAuthor(authorId);
            if (author == null)
            {
                author = new Author();
            }
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAuthor(author);
                if (author.AuthorId == 0)
                {
                    TempData["message"] = String.Format("Автор {0} {1} {2} был добавлен", author.Surname, author.Name, author.Patronymic);
                }
                else
                {
                    TempData["message"] = String.Format("Автор {0} {1} {2} был изменен", author.Surname, author.Name, author.Patronymic);
                }
                _repository.SaveChanges();
                _repository = null;
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Create()
        {
            return RedirectToAction("Edit", new { authorId = 0 });
        }

        public PartialViewResult AddBook (int authorId)
        {
            Book book = new Book();
            book.AuthorId = authorId;
            return PartialView(book);
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBook(book);
                TempData["message"] = String.Format("Книга {0} добавлена", book.Name);
            }
            return RedirectToAction("Edit", new { authorId = book.AuthorId});
        }
    }
}