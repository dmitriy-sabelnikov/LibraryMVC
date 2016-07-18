using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Book
    {
        public int BookId { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string Name { get; set; }

        [Display(Name = "Жанр книги")]
        [Required(ErrorMessage = "Пожалуйста, введите жанр книги")]
        public string Genre { get; set; }

        [Display(Name = "Количество страниц")]
        [Required(ErrorMessage = "Пожалуйста, введите количество страниц")]
        public string CountPage { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
