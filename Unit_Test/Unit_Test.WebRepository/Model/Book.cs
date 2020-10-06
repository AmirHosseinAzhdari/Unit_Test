using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Unit_Test.WebRepository.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public DateTime DatePublished { get; set; }

        public Book()
        {
            DatePublished = new DateTime();
        }
    }
}
