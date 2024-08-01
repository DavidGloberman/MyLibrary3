using System.ComponentModel.DataAnnotations;

namespace MyLibrary3.Models
{
    public class Shelf
    {
        [Display(Name = "מדף מספר")]
        public int Id { get; set; }
        [Display(Name = "שם הספרייה")]
        public int LibraryId { get; set; }
        [Display(Name = "שם הספרייה")]
        public Library Library { get; set; }
        [Display(Name = "גובה מדף")]
        public decimal Height { get; set; }
        [Display(Name = "רוחב מדף")]
        public decimal Width { get; set; }
        public List<Book>? Books { get; set; }
    }
}
