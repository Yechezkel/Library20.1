using Library20.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library10.Models
{
    [Table("Shelves")]
    public class Shelf
    {
        [Key, Display(Name = "מזהה מדף")]
        public int ShelfId { get; set; }



        public int LibraryId { get; set; }
        public Library Library { get; set; }




        [Required, Display(Name = "גובה מדף")]
        public int ShelfHeight { get; set; }

        [Required, Display(Name = "רוחב מדף")]
        public int ShelfWidth { get; set; }



        [NotMapped, Display(Name = "רוחב פנוי")]
        public double ShelfAbleSpace { get; set; }


        [NotMapped, Display(Name = "ספרים, סטים")]
        public List<Item> Items { get; set; }

    }
}