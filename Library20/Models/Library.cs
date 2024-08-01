using Library20.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library10.Models
{
    [Table("Libraries")]
    public class Library
    {

        [Key, Display(Name = "מזהה ספרייה")]
        public int LibraryId { get; set; }


        [Required, Display(Name = "ספרייה")]
        public string LibraryName { get; set; }


        [NotMapped, Display(Name = "מדפים")]
        public List<Shelf> Shelves { get; set; }


        [NotMapped, Display(Name = "ספרים, סטים")]
        public List<Item> Items { get; set; }

    }
}