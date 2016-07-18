using LibraryMVC.Entities;
using LibraryMVC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryMVC.DataAccess
{
    public class AuthorRepository : IAuthorRepository
    {
        EFDbContext _context = new EFDbContext();
        
        public List<Author> GetAllAuthors()
        {
            return _context.Authors.Include(b => b.Books).ToList();
        }

        public Author GetAuthor(int authorId)
        {
            Author author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            return author;
        }

        public Author DeleteAuthor(int authorId)
        {
            Author author = _context.Authors.FirstOrDefault(a => a.AuthorId == authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            return author;
        }

        public void AddAuthor(Author author)
        {
            if (author.AuthorId == 0)
            {
                _context.Authors.Add(author);
            }
            else
            {
                Author authorFind = _context.Authors.FirstOrDefault(a => a.AuthorId == author.AuthorId);
                if (authorFind != null)
                {
                    authorFind.BirthDay = author.BirthDay;
                    authorFind.Name = author.Name;
                    authorFind.Patronymic = author.Patronymic;
                    authorFind.Surname = author.Surname;
                }
            }
        }

        public List<Book> GetBook(int authorId)
        {
            return _context.Books.Where(a => a.AuthorId == authorId).ToList();
        }

        public void AddBook (Book book)
        {
            if (book != null)
            {
                _context.Books.Add(book);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
