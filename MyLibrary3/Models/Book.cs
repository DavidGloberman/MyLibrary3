using System.ComponentModel.DataAnnotations;

namespace MyLibrary3.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "ז'אנר")]
        public int GenerId { get; set; }
        [Display(Name = "מדף מספר")]
        public int ShelfId { get; set; }
        [Display(Name = "מדף מספר")]
        public Shelf Shelf { get; set; }
        [Display(Name = "שם הספר")]
        public string Name { get; set; }
        [Display(Name = "עובי הספר")]
        public decimal Width { get; set; }
        [Display(Name = "גובה הספר")]
        public decimal Height { get; set; }
        [Display(Name = "שם הסט")]
        public int? BookSetId { get; set; } = null;
        [Display(Name = "שם הסט")]
        public BookSet? BookSet { get; set; }
    }
}
