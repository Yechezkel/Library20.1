using Library20.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Library10.Models
{
    [Table("Items")]
    public class Item
    {
        [Key, Display(Name = "מזהה פריט")]
        public int ItemId { get; set; }




        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; }



        [Required, Display(Name = "גובה פריט")]
        public int BookHeight { get; set; }

        [Required, Display(Name = "רוחב פריט")]
        public int BookWidth { get; set; }

        [Display(Name = "מספר ספרים")]
        public int Pieces { get; set; }








    }
}
