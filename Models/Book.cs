using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrudWithAspdotnetcore.Models
{
    public class Book
    {

        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Author")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Enter ISBN")]
        public string ISBN { get; set; }
    }
}
