using System.ComponentModel.DataAnnotations;

namespace MyLibrary3.Models
{
    public class Library
    {
        [Display(Name = "ספרייה מספר")]
        public int Id { get; set; }
        [Display(Name = "ז'אנר")]
        public string Name { get; set; }
        public List<Shelf>? Shelves { get; set; }
    }
}
