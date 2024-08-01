using System.ComponentModel.DataAnnotations;

namespace MyLibrary3.Models
{
    public class BookSet
    {
        public int Id { get; set; }
        [Display(Name = "שם הסט")]
        public string Title { get; set; }
        [Display(Name = "ז'אנר")]
        public int LibraryId { get; set; }
        [Display(Name = "ז'אנר")]
        public Library Library { get; set; }
        [Display(Name = ("גובה הסט"))]
        public decimal Height { get; set; }
        public List<Book>? Books { get; set; }
    }
}
