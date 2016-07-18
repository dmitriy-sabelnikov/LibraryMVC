using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMVC.Entities;

namespace LibraryMVC.Interface
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();
        Author GetAuthor(int authorId);
        Author DeleteAuthor(int authorId);
        void SaveChanges();
        List<Book> GetBook(int authorId);
        void AddBook(Book book);
        void AddAuthor (Author author);
    }
}
